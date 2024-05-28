using System.ComponentModel.Design;
using System.Text.Json;
using static GTN.mc;

namespace MotionLibrary
{
    public class Parameter
    {
        public int PRESLEEP { get; set; } = 50;//读取信号前的sleep时间
        public int POSTSLEEP { get; set; } = 50;//读取信号后的sleep时间
        public double RAXISZERO { get; set; } = 3537091;//R轴零点位置
        //软限位
        public int XLIMITP { get; set; } = 4170000;
        public int XLIMITN { get; set; } = -150000;
        public int YLIMITP { get; set; } = 8380000;
        public int YLIMITN { get; set; } = -130000;
        public int ZLIMITP { get; set; } = 150000;
        public int ZLIMITN { get; set; } = -090000;

        //设备参数，精定位下的原始位置坐标：X，Y为chuck到达highMag视野中心，Z为对焦完成（无晶圆）
        public double XORIGIN { get; set; } = 2106910;
        public double YORIGIN { get; set; } = 1701615;
        public double ZORIGIN { get; set; } = 46000;
        //设备参数，Chuck旋转中心，区别于物理中心，这个参数需要标定后再定，故使用的用户坐标系定，再转为encode坐标系存储
        public double XROTATE { get; set; } = 2113182;
        public double YROTATE { get; set; } = 1620140;

        //设备参数，粗定位晶圆相机到精定位晶圆相机
        public double XWAFERLOW2HIGHT { get; set; } = -370578;
        public double YWAFERLOW2HIGHT { get; set; } = -3832;
        public double ZWAFERLOW2HIGHT { get; set; } = -8000;

        //设备参数，精定位晶圆相机到JigCamera（Probe区域）
        //因为不是每个die（或pad）从Align区到Probe区都是该固定值（encode值未校准），所以只用作去probe区域标定用
        public double XALIGN2PROBE { get; set; } = 225000;//encode值
        public double YALIGN2PROBE { get; set; } = 4375000;//encode值
        public double ZALIGN2PROBE { get; set; } = -137;

        //设备参数，粗定位探针相机到精定位探针相机
        public double XPINLOW2HIGH { get; set; } = 769641;
        public double YPINLOW2HIGH { get; set; } = -1627;

        //设备参数，探针卡Plate的高度
        public double ZPROBECARDUPPERPLATEBASE { get; set; } = 133500;

        //LeftUp, RightUp,  RightDown, LeftDown
        public double[] EdgeX { get; set; } = new double[] { 3540000, 1410000, 1400000, 3560000 };
        public double[] EdgeY { get; set; } = new double[] { 580000, 580000, 2660000, 2660000 };
        //设备参数，标定区和探针区的分界线
        public double PROBEDIVIDEY { get; set; } = 3700000;//高于3700000，表示可以能在扎针区域
        public double PROBEDIVIDEZ { get; set; } = 50000;//高于50000，表示可以能在扎针状态
        public PinPadContact PROBING { get; set; } = new PinPadContact();
    }
    public class PinPadContact
    {
        public double XOrgPin { get; set; } = 2982674;//定机台参数时，Abspin X
        public double YOrgPin { get; set; } = 4125571;//定机台参数时，refpin Y
        public double ZOrgPin { get; set; } = 77120;//定机台参数时，refpin高度
        public double ZOrgWaferHeight { get; set; } = 38422;//定机台参数时，wafer高度
        public double XPad2Pin { get; set; } = 0;//13083定机台参数时，pad需要位移XPad2Pin才能扎到中心      
        public double YPad2Pin { get; set; } = 0;//-3937定机台参数时，pad需要位移YPad2Pin才能扎到中心            
        public double ZPad2Pin { get; set; } = 0;//88000定机台参数时，pad从Zwafer上升ZPad2Pin时，正好扎到针
    }

    static public class Motion
    {
        private static short Res;//返回值
        public static Parameter parameter = new Parameter();//定义参数集
        //public static bool IsProbeArea = false;//定义当前轴是否在探针区，默认在标定区
        public static Compensation.Area CurrentArea = Compensation.Area.Align;
        public class AxisStatus
        {
            public double PrfPos;
            public double EncPos;
            public double PrfVel;
            public double EncVel;
            public bool AxisOn;
            public bool AxisAlarm;
            public bool P_Lmt;
            public bool N_Lmt;
            public bool Motion;
            public bool Arrive;
            public bool SmoothStop;
            public bool AbruptStop;
            public bool FollowError;
            public int PrfMode;
            //点位运动 = 0,
            //JOG运动 = 1,
            //PT运动 = 2,
            //电子齿轮运动 = 3,
            //FOLLOW运动 = 4,
            //插补运动 = 5,
            //PVT运动 = 6       
        }
        public static void Initial()
        {
            Load("Config/MotionParameter.json");
            OpenCard();
            MultiAxisOn(1, 4);
            MultiAxisOn(2, 6);
        }
        public static void Save(string filePath)
        {
            JsonSerializerOptions options = new()
            {
                WriteIndented = true,
            };
            string jsonString = JsonSerializer.Serialize(parameter, options);
            File.WriteAllText(filePath, jsonString);
        }
        public static void Load(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            var item = JsonSerializer.Deserialize<Parameter>(jsonString);
            if (item != null) parameter = item;
        }

        /// <summary>
        /// 输出反馈
        /// </summary>
        /// <param name="command"></param>
        /// <param name="error"></param>
        public static void CommandHandler(string command, short error) //输出窗口提示
        {
            if (error != 0)
            {
                Console.WriteLine(command + "=" + error);
            }
        }

        /// <summary>
        /// 轴上使能
        /// </summary>
        /// <param name="core">核心=1</param>
        /// <param name="axis">X轴=1；Y轴=2；Z轴=3；R轴=4</param>
        public static void AxisOn(short core, short axis)//使能轴
        {
            GTN.mc.GTN_ClrSts(core, axis, 1);//清除轴状态
            GTN.mc.GTN_AxisOn(core, axis);//使能
        }

        /// <summary>
        /// 多轴使能
        /// </summary>
        /// <param name="core"></param>
        /// <param name="axisCount"></param>
        public static void MultiAxisOn(short core, short axisCount)
        {
            //核1=4轴，核2=6轴
            GTN.mc.GTN_ClrSts(core, 1, axisCount);//清除轴状态
            uint AxisOnMask = Convert.ToUInt32(Math.Pow(2, axisCount)) - 1;
            GTN.mc.GTN_MultiAxisOn(core, AxisOnMask);
        }

        /// <summary>
        /// 多轴下使能
        /// </summary>
        /// <param name="core"></param>
        /// <param name="axisCount"></param>
        public static void MultiAxisOff(short core, short axisCount)
        {
            uint AxisOffMask = Convert.ToUInt32(Math.Pow(2, axisCount)) - 1;
            GTN.mc.GTN_MultiAxisOff(core, AxisOffMask);
        }

        /// <summary>
        /// 轴下使能
        /// </summary>
        /// <param name="core">核心=1</param>
        /// <param name="axis">X轴=1；Y轴=2；Z轴=3；R轴=4</param>
        public static void AxisOff(short core, short axis)//下使能
        {
            GTN.mc.GTN_AxisOff(core, axis);//使能
        }

        /// <summary>
        /// 开卡并设置i参数
        /// </summary>
        public static void OpenCard()
        {
            Res = GTN.mc.GTN_OpenCard(CHANNEL_PCIE, null, null);//P238 两个Null为保留值
            CommandHandler("GTN_OpenCard", Res);
            //GDN 运动控制器上电 GTN_OpenCard 初始化之后，程序必须首先调用 GTN_NetInit 指令初始化
            //EtherCAT 网络（该指令同时初始化了等环网），pStatus 返回值为 1 时表示 EtherCAT 从站和运动控制器
            //实现正常通讯，返回其他值表示通讯未建立。
            Res = GTN.mc.GTN_NetInit(2, "Gecat.xml", 0, out long pStatus);
            CommandHandler("GTN_NetInit", Res);
            //0：初始化网络成功
            //17701：overTime 参数设置错误
            //11702：EtherCAT 网络初始化错误
            //11703：获取控制器类型错误
            //11704：急停所有轴失败
            //11705：等环网初始化错误
            //11706：初始化控制器资源错误
            //11902：缺少主站库/没有Gecat.xml/Gecat.xml里的文件不对
            //11905:
            //Z = GTN_OpenRingNet(5, 2, "RingNetConfig-Board1.cfg", 1, 1);//开卡
            //commandHandler("GTN_OpenRingNet", Z);
            //Z = GTN.mc.GTN_SetDeviceShareMax(1, 2);//双开
            //commandHandler("GTN_SetDeviceShareMax", Z);

            //读UUID
            //byte[] pcode = new byte[16];
            //Z = GTN.mc.GTN_GetUuid(1, out pcode[0], 16);
            //string str = System.Text.Encoding.UTF8.GetString(pcode);
            //lab_uuid.Text = "uuid:" + str;

            Res = GTN.mc.GTN_Reset(1);//复位核1
            CommandHandler("GTN_Reset", Res);
            Res = GTN.mc.GTN_LoadConfig(1, "gsne_core1.cfg");//加载配置文件1
            CommandHandler("GTN_LoadConfig1", Res);
            Res = GTN.mc.GTN_Reset(2);//复位核2
            CommandHandler("GTN_Reset", Res);
            Res = GTN.mc.GTN_LoadConfig(2, "gsne_core2.cfg");//加载配置文件2
            CommandHandler("GTN_LoadConfig2", Res);
            Res = GTN.mc.GTN_ClrSts(1, 1, 12);//清除核1的32个轴的状态
            CommandHandler("GTN_ClrSts1", Res);
            Res = GTN.mc.GTN_ClrSts(2, 1, 12);//清除核2的32个轴的状态
            CommandHandler("GTN_ClrSts2", Res);
            Res = GTN.mc.GTN_GetResMax(1, MC_AXIS, out short Core1_Axis);//读取主卡最大资源个数 
            CommandHandler("GTN_GetResCount1", Res);
            Res = GTN.mc.GTN_GetResMax(2, MC_AXIS, out short Core2_Axis);//读取核2卡最大资源个数 
            CommandHandler("GTN_GetResCount2", Res);
            //short CoreAxis = Convert.ToInt16(Core1_Axis + Core2_Axis);
            //for (short i = 1; i <= Core1_Axis; i++)
            //{
            //    Z = GTN_SetAxisBand(1, i, 5, 20);//设置轴的到位误差带
            //    //Z = GTN_SetAxisBand(2, i, 20, 10);
            //    commandHandler(" GTN_SetAxisBand", Z);
            //}
            Res = GTN_SetAxisBand(1, 1, 10, 40);//设置轴的到位误差带 40 * 250us = 10ms
            Res = GTN_SetAxisBand(1, 2, 10, 40);//设置轴的到位误差带 40 * 250us = 10ms
            Res = GTN_SetAxisBand(1, 3, 10, 40);//设置轴的到位误差带 40 * 250us = 10ms
            Res = GTN_SetAxisBand(1, 4, 10, 40);//设置轴的到位误差带 40 * 250us = 10ms
            Res = GTN.mc_ringnet.GTN_RN_SetEncMultiLinesEx(1, 4, 0);// 设置R轴多圈

            Res = GTN_SetSoftLimit(1, 1, parameter.XLIMITP, parameter.XLIMITN);
            Res = GTN_SetSoftLimit(1, 2, parameter.YLIMITP, parameter.YLIMITN);
            Res = GTN_SetSoftLimit(1, 3, parameter.ZLIMITP, parameter.ZLIMITN);

            //0 SOFT_LIMIT_MODE_STOP //超越软限位位置后开始减速停止
            //1 SOFT_LIMIT_MODE_LIMIT //限制在软限位范围之内
            Res = GTN_SetSoftLimitMode(1, 1, 1);
            Res = GTN_SetSoftLimitMode(1, 2, 1);
            Res = GTN_SetSoftLimitMode(1, 3, 1);

            //lab_CardNum.Text = "卡总轴数：" + CoreAxis + "轴";
            //timer1.Enabled = true;
            //timer1.Interval = 200;//10ms会出现超时错误,100ms也偶尔出现
            //textBox50.Text = "1、回零状态：0-停止运动，1-正在回原点\r\n2、回零阶段：0-未启动回原点，1-启动回原点，2-正在脱离原点/限位，10-正在寻找限位，11-触发限位停止，13-反方向运动脱离限位，15-重新回到限位，16-重新回到限位停止，20-正在搜索Home,22-搜索到Home停止，25-搜索到Home后运动到捕获位置，30-正在搜索Index，40-正在搜索GPI，45-搜索到GPI后运动到捕获GPI的位置，80-正在执行回原点过程，100-回原点结束\r\n3、回零错误：0-未发生错误，1-执行回零的轴不是处于点位运动模式，2-执行回零的轴未使能，3-执行回零的轴驱动报警，4-未完成回零停止运动（搜索距离短或触发限位），5-回零阶段错误，6-模式错误，7-设置Home捕获模式失败，8-未找到Home，9-设置Index捕获模式失败，10-未找到Index";
            //textBox51.Text = "注意事项：1、回零前，确定规划位置和实际位置是否同向，如果使用的电机为步进电机，没有配备编码器，那么需要把控制器的编码器选项配置为脉冲计数器\r\n2、回零前，需要使能轴，否则无法执行回零\r\n3、回零前，先调用 GT_ZeroPos 把规划位置和实际位置清零，防止规划位置和实际位置不一致造成回零不准确\r\n4、回零时，要查看回零状态，如果发现电机不动了，并已经运动到设定的位置，但是回零状态没有显示回零完成，需要检查一下零点搜索范围是否合理，原点开关是否异常\r\n5、回零完成，Smart Home 不会自动清零位置，需要用户调用 GT_ZeroPos 把当前位置清零来确定零点\r\n";
        }

        /// <summary>
        /// 关卡，建议在FormClosing中调用
        /// </summary>
        public static void CloseCard()
        {
            Res = GTN_Stop(1, 255, 0);//停止核1的8根轴，0=平滑停止
            CommandHandler("GTN_Stop", Res);
            Res = GTN_MultiAxisOff(1, 255);//核1多轴下使能
            CommandHandler("GTN_MultiAxisOff", Res);
            Res = GTN_Stop(2, 255, 0);//停止核2的8根轴，0=平滑停止
            CommandHandler("GTN_Stop", Res);
            Res = GTN_MultiAxisOff(2, 255);//核2多轴下使能
            CommandHandler("GTN_MultiAxisOff", Res);
            Thread.Sleep(100);
            Res = GTN_Close();//关闭轴卡
            CommandHandler("GTN_Close", Res);

        }

        /// <summary>
        /// 读取轴的当前值
        /// </summary>
        /// <param name="core"></param>
        /// <param name="axis"></param>
        /// <returns></returns>
        public static double GetEncPos(short core, short axis)
        {
            Res = GTN.mc.GTN_GetEncPos(core, axis, out double encPos, 1, out uint pClock);
            return encPos;
        }

        /// <summary>
        /// 获取XY值
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public static void XY_GetEncPos(out double X, out double Y)
        {
            double[] pEncPos = new double[2];
            Res = GTN.mc.GTN_GetEncPos(1, 1, out pEncPos[0], 2, out uint pClock);
            X = pEncPos[0];
            Y = pEncPos[1];
            return;
        }

        /// <summary>
        /// 获取XYZ值
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        public static void XYZ_GetEncPos(out double X, out double Y, out double Z)
        {
            double[] pEncPos = new double[3];
            Res = GTN.mc.GTN_GetEncPos(1, 1, out pEncPos[0], 3, out uint pClock);
            X = pEncPos[0];
            Y = pEncPos[1];
            Z = pEncPos[2];
            return;
        }

        /// <summary>
        /// 获取用户坐标
        /// </summary>
        /// <param name="area"></param>
        /// <param name="userPosX"></param>
        /// <param name="userPosY"></param>
        /// <returns></returns>
        public static int GetUserPos(Compensation.Area area, out double userPosX, out double userPosY)
        {
            XYZ_GetEncPos(out double encodeX, out double encodeY, out _);
            Compensation.Transform(area, Compensation.Dir.Encode2User, encodeX, encodeY, out userPosX, out userPosY);
            return 0;
        }

        /// <summary>
        /// 用户坐标系走点：绝对运动
        /// </summary>
        /// <param name="area">"Match"标定区；"Probing"工作区</param>
        /// <param name="userX"></param>
        /// <param name="userY"></param>
        /// <returns>0 = 成功；1=取点失败</returns>
        public static int UserPosMoveAbs(Compensation.Area area, double userPosX, double userPosY)
        {
            int res = Compensation.Transform(area, Compensation.Dir.User2Encode, userPosX, userPosY, out double FeedbackX, out double FeedbackY);
            if (res != 0) return res;
            XY_AxisMoveAbs(1, FeedbackX, FeedbackY, 600, 10, 10, 20);
            return 0;
        }

        /// <summary>
        /// 用户坐标系走点：相对运动
        /// </summary>
        /// <param name="area">"Match"标定区；"Probing"工作区</param>
        /// <param name="userPosX">相对位移</param>
        /// <param name="userPosY">相对位移</param>
        /// <returns>0 = 成功；1=取点失败</returns>
        public static int UserPosMoveRel(Compensation.Area area, double userPosX, double userPosY)
        {
            GetUserPos(area, out double X, out double Y);//先获取当前XY的userPos
            return UserPosMoveAbs(area, X + userPosX, Y + userPosY);//再绝对走一个坐标位置
        }

        /// <summary>
        /// 读取R轴参数
        /// </summary>
        /// <param name="absEncPosEx"></param>
        public static void R_GetAbsEncPoR(out long absEncPosEx)
        {
            Res = GTN.mc_ringnet.GTN_RN_GetAbsEncPosEx(1, 4, out absEncPosEx);
        }

        /// <summary>
        /// Jog运动方向 由速度正负决定
        /// </summary>
        /// <param name="core"></param>
        /// <param name="axis"></param>
        /// <param name="vel"></param>
        /// <param name="acc"></param>
        /// <param name="dec"></param>
        /// <param name="smoothtime">时间[0,1)</param>
        public static void AxisJog(short core, short axis, double vel, double acc, double dec, double smoothtime)
        {
            Res = GTN.mc.GTN_GetEncPos(core, axis, out double EncPos, 1, out uint pClock);//读取规划位置
            GTN.mc.TJogPrm tJogPrm = new GTN.mc.TJogPrm();//Jog参数
            Res = GTN.mc.GTN_PrfJog(core, axis);  //设置轴为Jog运动模式
            CommandHandler("GTN_PrfJog", Res);
            tJogPrm.acc = acc;
            tJogPrm.dec = dec;
            tJogPrm.smooth = smoothtime;
            Res = GTN.mc.GTN_SetJogPrm(core, axis, ref tJogPrm);  //设置轴为Jog运动参数acc,dec,smooth
            CommandHandler("GTN_SetJogPrm", Res);
            Res = GTN.mc.GTN_SetVel(core, axis, vel);  //设置Jog正向运动的速度vel
            CommandHandler("GTN_SetVel", Res);
            Res = GTN.mc.GTN_Update(core, 1 << (axis - 1));  //更新轴运动
            CommandHandler("GTN_Update", Res);
        }

        /// <summary>
        /// 停止，option = 0:缓停，1：急停
        /// </summary>
        /// <param name="core"></param>
        /// <param name="axis"></param>
        /// <param name="option"></param>
        public static void AxisStop(short core, short axis, int option)
        {
            Res = GTN.mc.GTN_Stop(core, 1 << (axis - 1), option);
            CommandHandler("GTN_Stop", Res);
        }

        public static int commandIn = 0;
        public static int commandOut = 0;
        /// <summary>
        /// 单轴绝对运动
        /// </summary>
        /// <param name="core"></param>
        /// <param name="axis"></param>
        /// <param name="pulse"></param>
        /// <param name="vel"></param>
        /// <param name="acc"></param>
        /// <param name="dec"></param>
        /// <param name="smoothtime">平滑时间[0,50]</param>
        public static void AxisMoveAbs(short core, short axis, double pulse, double vel, double acc, double dec, short smoothtime)
        {
            commandIn++;
            GTN.mc.TTrapPrm trap = new GTN.mc.TTrapPrm();
            Res = GTN.mc.GTN_PrfTrap(core, axis); //将轴设置为点位运动模式
            CommandHandler("GTN_PrfTrap", Res);
            trap.acc = acc; //增量运动的加速度
            trap.dec = dec; //增量运动的减速度
            trap.smoothTime = smoothtime;//增量运动的平滑时间[0,50]
            trap.velStart = 0; //起跳速度
            Res = GTN.mc.GTN_SetTrapPrm(core, axis, ref trap);//设置点位运动参数
            CommandHandler("GTN_SetTrapPrm", Res);
            Res = GTN.mc.GTN_SetVel(core, axis, vel);//设置目标速度
            CommandHandler("GTN_SetVel", Res);
            Res = GTN.mc.GTN_SetPos(core, axis, (int)pulse);//设置目标位置            
            CommandHandler("GTN_SetPos", Res);
            Res = GTN.mc.GTN_Update(core, 1 << (axis - 1));//更新轴运动
            CommandHandler("GTN_Update", Res);
            Thread.Sleep(parameter.PRESLEEP);
            int pStatus;
            do
            {
                Application.DoEvents();//用于对焦.TODO:不好的方式，容易卡死界面，待优化
                Res = GTN.mc.GTN_GetSts(core, axis, out pStatus, 1, out uint pClock);
            } while ((pStatus & 0x800) == 0);//等待轴到位
            Thread.Sleep(parameter.POSTSLEEP);
            commandOut++;
        }

        /// <summary>
        /// XY轴的独立运动，Z保持不动
        /// </summary>
        /// <param name="core"></param>
        /// <param name="pulseX"></param>
        /// <param name="pulseY"></param>
        /// <param name="vel"></param>
        /// <param name="acc"></param>
        /// <param name="dec"></param>
        /// <param name="smoothtime">平滑时间[0,50]</param>
        public static void XY_AxisMoveAbs(short core, double pulseX, double pulseY, double vel, double acc, double dec, short smoothtime)
        {
            commandIn++;
            GTN.mc.TTrapPrm trap = new GTN.mc.TTrapPrm();
            Res = GTN.mc.GTN_PrfTrap(core, 1); //将轴设置为点位运动模式
            Res = GTN.mc.GTN_PrfTrap(core, 2); //将轴设置为点位运动模式
            trap.acc = acc; //增量运动的加速度
            trap.dec = dec; //增量运动的减速度
            trap.smoothTime = smoothtime;//增量运动的平滑时间[0,50]
            trap.velStart = 0; //起跳速度
            Res = GTN.mc.GTN_SetTrapPrm(core, 1, ref trap);//设置点位运动参数
            Res = GTN.mc.GTN_SetTrapPrm(core, 2, ref trap);//设置点位运动参数

            Res = GTN.mc.GTN_SetVel(core, 1, vel);//设置目标速度
            Res = GTN.mc.GTN_SetVel(core, 2, vel);//设置目标速度
            Res = GTN.mc.GTN_SetPos(core, 1, (int)(pulseX));//设置目标位置
            Res = GTN.mc.GTN_SetPos(core, 2, (int)(pulseY));//设置目标位置

            Res = GTN.mc.GTN_Update(core, 3);//更新XYZ轴运动
            Thread.Sleep(parameter.PRESLEEP);
            int[] pStatus = new int[2];
            do
            {
                Application.DoEvents();//TODO:不好的方式，容易卡死界面，待优化
                Res = GTN.mc.GTN_GetSts(core, 1, out pStatus[0], 2, out uint pClock);
            } while (((pStatus[0] & 0x800) == 0) || ((pStatus[1] & 0x800) == 0));//等待轴到位
            Thread.Sleep(parameter.POSTSLEEP);
            commandOut++;
        }

        /// <summary>
        /// XYZ三轴独立运动
        /// </summary>
        /// <param name="core"></param>
        /// <param name="pulseX"></param>
        /// <param name="pulseY"></param>
        /// <param name="pulseZ"></param>
        /// <param name="vel"></param>
        /// <param name="acc"></param>
        /// <param name="dec"></param>
        /// <param name="smoothtime">平滑时间[0,50]</param>
        public static void XYZ_AxisMoveAbs(short core, double pulseX, double pulseY, double pulseZ, double vel, double acc, double dec, short smoothtime)
        {
            commandIn++;
            GTN.mc.TTrapPrm trap = new GTN.mc.TTrapPrm();
            Res = GTN.mc.GTN_PrfTrap(core, 1); //将轴设置为点位运动模式
            Res = GTN.mc.GTN_PrfTrap(core, 2); //将轴设置为点位运动模式
            Res = GTN.mc.GTN_PrfTrap(core, 3); //将轴设置为点位运动模式
            trap.acc = acc; //增量运动的加速度
            trap.dec = dec; //增量运动的减速度
            trap.smoothTime = smoothtime;//增量运动的平滑时间[0,50]
            trap.velStart = 0; //起跳速度
            Res = GTN.mc.GTN_SetTrapPrm(core, 1, ref trap);//设置点位运动参数
            Res = GTN.mc.GTN_SetTrapPrm(core, 2, ref trap);//设置点位运动参数
            Res = GTN.mc.GTN_SetTrapPrm(core, 3, ref trap);//设置点位运动参数
            Res = GTN.mc.GTN_SetVel(core, 1, vel);//设置目标速度
            Res = GTN.mc.GTN_SetVel(core, 2, vel);//设置目标速度
            Res = GTN.mc.GTN_SetVel(core, 3, vel);//设置目标速度
            Res = GTN.mc.GTN_SetPos(core, 1, (int)(pulseX));//设置目标位置
            Res = GTN.mc.GTN_SetPos(core, 2, (int)(pulseY));//设置目标位置
            Res = GTN.mc.GTN_SetPos(core, 3, (int)(pulseZ));//设置目标位置

            Res = GTN.mc.GTN_Update(core, 7);//更新XYZ轴运动
            Thread.Sleep(parameter.PRESLEEP);
            int[] pStatus = new int[3];
            do
            {
                Application.DoEvents();//TODO:不好的方式，容易卡死界面，待优化
                Res = GTN.mc.GTN_GetSts(core, 1, out pStatus[0], 3, out uint pClock);
            } while (((pStatus[0] & 0x800) == 0) || ((pStatus[1] & 0x800) == 0) || ((pStatus[2] & 0x800) == 0));//等待轴到位

            Thread.Sleep(parameter.POSTSLEEP);
            commandOut++;
        }

        /// <summary>
        /// 单轴相对运动
        /// </summary>
        /// <param name="core"></param>
        /// <param name="axis"></param>
        /// <param name="vel"></param>
        /// <param name="acc"></param>
        /// <param name="dec"></param>
        /// <param name="smoothtime">250us控制周期[0，50]；500us控制周期[0，100]；1ms控制周期[0，200]；</param>
        public static void AxisMoveRel(short core, short axis, double pulse, double vel, double acc, double dec, short smoothtime)
        {
            commandIn++;
            GTN.mc.TTrapPrm trap = new GTN.mc.TTrapPrm();
            Res = GTN.mc.GTN_PrfTrap(core, axis); //将轴设置为点位运动模式
            CommandHandler("GTN_PrfTrap", Res);
            trap.acc = acc; //增量运动的加速度
            trap.dec = dec; //增量运动的减速度
            trap.smoothTime = smoothtime;//增量运动的平滑时间[0,50]
            trap.velStart = 0; //起跳速度
            Res = GTN.mc.GTN_SetTrapPrm(core, axis, ref trap);//设置点位运动参数
            CommandHandler("GTN_SetTrapPrm", Res);
            Res = GTN.mc.GTN_GetPrfPos(core, axis, out double prfPos, 1, out uint pClock);//读取规划位置
            CommandHandler("GTN_GetPrfPos", Res);
            Res = GTN.mc.GTN_SetVel(core, axis, vel);//设置目标速度
            CommandHandler("GTN_SetVel", Res);
            Res = GTN.mc.GTN_SetPos(core, axis, (int)(pulse + prfPos));//设置目标位置
            CommandHandler("GTN_SetPos", Res);
            Res = GTN.mc.GTN_Update(core, 1 << (axis - 1));//更新轴运动
            CommandHandler("GTN_Update", Res);
            Thread.Sleep(parameter.PRESLEEP);
            int pStatus;
            do
            {
                Application.DoEvents();//TODO:不好的方式，容易卡死界面，待优化
                Res = GTN.mc.GTN_GetSts(core, axis, out pStatus, 1, out pClock);
            } while ((pStatus & 0x800) == 0);//等待轴到位

            Thread.Sleep(parameter.POSTSLEEP);
            commandOut++;
        }

        /// <summary>
        /// XY轴独立的运动
        /// </summary>
        /// <param name="core"></param>
        /// <param name="pulseX"></param>
        /// <param name="pulseY"></param>
        /// <param name="vel"></param>
        /// <param name="acc"></param>
        /// <param name="dec"></param>
        /// <param name="smoothtime">平滑时间[0,50]</param>
        public static void XY_AxisMoveRel(short core, double pulseX, double pulseY, double vel, double acc, double dec, short smoothtime)
        {
            commandIn++;
            GTN.mc.TTrapPrm trap = new GTN.mc.TTrapPrm();
            Res = GTN.mc.GTN_PrfTrap(core, 1); //将轴设置为点位运动模式
            Res = GTN.mc.GTN_PrfTrap(core, 2); //将轴设置为点位运动模式
            trap.acc = acc; //增量运动的加速度
            trap.dec = dec; //增量运动的减速度
            trap.smoothTime = smoothtime;//增量运动的平滑时间[0,50]
            trap.velStart = 0; //起跳速度
            Res = GTN.mc.GTN_SetTrapPrm(core, 1, ref trap);//设置点位运动参数
            Res = GTN.mc.GTN_SetTrapPrm(core, 2, ref trap);//设置点位运动参数
            Res = GTN.mc.GTN_GetPrfPos(core, 1, out double prfPosX, 1, out uint pClock);//读取规划位置
            Res = GTN.mc.GTN_GetPrfPos(core, 2, out double prfPosY, 1, out pClock);//读取规划位置

            Res = GTN.mc.GTN_SetVel(core, 1, vel);//设置目标速度
            Res = GTN.mc.GTN_SetVel(core, 2, vel);//设置目标速度
            Res = GTN.mc.GTN_SetPos(core, 1, (int)(pulseX + prfPosX));//设置目标位置
            Res = GTN.mc.GTN_SetPos(core, 2, (int)(pulseY + prfPosY));//设置目标位置

            Res = GTN.mc.GTN_Update(core, 3);//更新XY轴运动

            Thread.Sleep(parameter.PRESLEEP);
            int[] pStatus = new int[2];
            do
            {
                Application.DoEvents();//TODO:不好的方式，容易卡死界面，待优化
                Res = GTN.mc.GTN_GetSts(core, 1, out pStatus[0], 2, out pClock);
            } while (((pStatus[0] & 0x800) == 0) || ((pStatus[1] & 0x800) == 0));//等待轴到位

            Thread.Sleep(parameter.POSTSLEEP);
            commandOut++;
        }

        /// <summary>
        /// XYZ三轴独立运动
        /// </summary>
        /// <param name="core"></param>
        /// <param name="pulseX"></param>
        /// <param name="pulseY"></param>
        /// <param name="pulseZ"></param>
        /// <param name="vel"></param>
        /// <param name="acc"></param>
        /// <param name="dec"></param>
        /// <param name="smoothtime">平滑时间[0,50]</param>
        public static void XYZ_AxisMoveRel(short core, double pulseX, double pulseY, double pulseZ, double vel, double acc, double dec, short smoothtime)
        {
            commandIn++;
            GTN.mc.TTrapPrm trap = new GTN.mc.TTrapPrm();
            Res = GTN.mc.GTN_PrfTrap(core, 1); //将轴设置为点位运动模式
            Res = GTN.mc.GTN_PrfTrap(core, 2); //将轴设置为点位运动模式
            Res = GTN.mc.GTN_PrfTrap(core, 3); //将轴设置为点位运动模式
            trap.acc = acc; //增量运动的加速度
            trap.dec = dec; //增量运动的减速度
            trap.smoothTime = smoothtime;//增量运动的平滑时间[0,50]
            trap.velStart = 0; //起跳速度
            Res = GTN.mc.GTN_SetTrapPrm(core, 1, ref trap);//设置点位运动参数
            Res = GTN.mc.GTN_SetTrapPrm(core, 2, ref trap);//设置点位运动参数
            Res = GTN.mc.GTN_SetTrapPrm(core, 3, ref trap);//设置点位运动参数
            Res = GTN.mc.GTN_GetPrfPos(core, 1, out double prfPosX, 1, out uint pClock);//读取规划位置
            Res = GTN.mc.GTN_GetPrfPos(core, 2, out double prfPosY, 1, out pClock);//读取规划位置
            Res = GTN.mc.GTN_GetPrfPos(core, 3, out double prfPosZ, 1, out pClock);//读取规划位置
            Res = GTN.mc.GTN_SetVel(core, 1, vel);//设置目标速度
            Res = GTN.mc.GTN_SetVel(core, 2, vel);//设置目标速度
            Res = GTN.mc.GTN_SetVel(core, 3, vel);//设置目标速度
            Res = GTN.mc.GTN_SetPos(core, 1, (int)(pulseX + prfPosX));//设置目标位置
            Res = GTN.mc.GTN_SetPos(core, 2, (int)(pulseY + prfPosY));//设置目标位置
            Res = GTN.mc.GTN_SetPos(core, 3, (int)(pulseZ + prfPosZ));//设置目标位置

            Res = GTN.mc.GTN_Update(core, 7);//更新XYZ轴运动
            Thread.Sleep(parameter.PRESLEEP);
            int[] pStatus = new int[3];
            do
            {
                Application.DoEvents();//TODO:不好的方式，容易卡死界面，待优化
                Res = GTN.mc.GTN_GetSts(core, 1, out pStatus[0], 3, out pClock);
            } while (((pStatus[0] & 0x800) == 0) || ((pStatus[1] & 0x800) == 0) || ((pStatus[2] & 0x800) == 0));//等待轴到位

            Thread.Sleep(parameter.POSTSLEEP);
            commandOut++;
        }

        //Thread threadHome;//回零线程
        //Thread threadHomeStatus;//回零状态检测线程
        public static CancellationTokenSource homeToken = new CancellationTokenSource();//定义一个cancelTokenSource

        /// <summary>
        /// 单轴回零并等待完成
        /// </summary>
        /// <param name="core"></param>
        /// <param name="axis"></param>
        /// <param name="homePrm"></param>
        /// <param name="pHomeStatus"></param>
        private static void SmartHome(short core, short axis, GTN.mc.THomePrm homePrm, out GTN.mc.THomeStatus pHomeStatus)
        {
            //软限位无效
            GTN_LmtsOffEx(core, axis, MC_LIMIT_NEGATIVE, 1);

            int pStatus;
            uint pClock;
            GTN.mc.THomePrm tHomePrm;
            //回零前停止轴运动，清除一下状态和位置
            Res = GTN.mc.GTN_Stop(core, 1 << (axis - 1), 0);
            CommandHandler("回零前GTN_Stop", Res);
            Res = GTN.mc.GTN_ClrSts(core, axis, 1);
            CommandHandler("回零前GTN_ClrSts", Res);
            Res = GTN.mc.GTN_ZeroPos(core, axis, 1);
            CommandHandler("回零前GTN_ZeroPos", Res);
            tHomePrm = homePrm;//传参
            Res = GTN.mc.GTN_GoHome(core, axis, ref tHomePrm);//回零
            CommandHandler("GTN_GoHome", Res);
            do
            {
                Res = GTN.mc.GTN_GetHomeStatus(core, axis, out pHomeStatus);//获取回原点状态
                CommandHandler("GTN_GetHomeStatus", Res);

                if (homeToken.Token.IsCancellationRequested)
                {
                    return;//外部取消任务
                }
            } while (pHomeStatus.run == 1 || pHomeStatus.stage != 100); //等待搜索原点停止
            do
            {
                Res = GTN.mc.GTN_GetSts(core, axis, out pStatus, 1, out pClock);
                CommandHandler("GTN_GetSts", Res);
            } while ((pStatus & 0x800) == 0);//等待轴到位
            Thread.Sleep(1000);
            Res = GTN.mc.GTN_ZeroPos(core, axis, 1);//到位后位置清零
            CommandHandler("GTN_ZeroPos", Res);

            //软限位有效
            GTN_LmtsOnEx(core, axis, MC_LIMIT_NEGATIVE, 1);
        }

        /// <summary>
        /// Ecat回零。TODO多轴回零
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="speed1"></param>
        /// <param name="speed2"></param>
        /// <param name="acc"></param>
        public static void EcatGoHome(short axis, double speed1, double speed2, double acc)
        {
            //EtherCat的轴回零是由驱动器本身完成的，主站只是指定回零方式和启动回零，回零状态也是从驱动器读过来的
            //CIA402协议定义的回零模式有36种，不同厂家的驱动器回零模式可能有所不同
            short method = 27;//回零方式
            Thread threadHome;
            ushort homeStatus;
            int offset = 0;
            ushort probeFunc = 0;
            //if (threadHome != null)
            //{
            //    threadHome.Abort();
            //}
            threadHome = new Thread(() =>
            {
                //模式设为回零模式
                Res = GTN.mc.GTN_SetHomingMode(2, axis, 6);
                CommandHandler("GTN_SetHomingMode", Res);
                //设置回零参数
                Res = GTN.mc.GTN_SetEcatHomingPrm(2, axis, method, speed1, speed2, acc, offset, probeFunc);
                CommandHandler("GTN_SetEcatHomingPrm", Res);
                //启动回零
                Res = GTN.mc.GTN_StartEcatHoming(2, axis);
                CommandHandler("GTN_StartEcatHoming", Res);
                do
                {
                    Res = GTN.mc.GTN_GetEcatHomingStatus(2, axis, out homeStatus);
                    //txt_EcatHomeSts.Invoke(new Action(() =>
                    //{
                    //    txt_EcatHomeSts.Text = Convert.ToString(homeStatus);
                    //}));

                } while (3 != homeStatus);  // 等待搜索原点完成
                Thread.Sleep(1000);//延时等待
                Res = GTN.mc.GTN_ZeroPos(2, axis, 1);
                Res = GTN.mc.GTN_ClrSts(2, axis, 1);
                Res = GTN.mc.GTN_SetHomingMode(2, axis, 8); // 切换到位置控制模式
                CommandHandler("GTN_SetHomingMode", Res);
            })
            { IsBackground = true };
            threadHome.Start();
        }

        /// <summary>
        /// R轴回零，并等待完成
        /// </summary>
        public static void R_AxisHome()
        {
            short axis = 4;
            Res = GTN.mc.GTN_Stop(1, 1 << (axis - 1), 0);
            CommandHandler("回零前GTN_Stop", Res);
            Res = GTN.mc.GTN_ClrSts(1, axis, 1);
            CommandHandler("回零前GTN_ClrSts", Res);
            Res = GTN.mc.GTN_ZeroPos(1, axis, 1);
            CommandHandler("回零前GTN_ZeroPos", Res);

            //24048为R轴的绝对编码器零点
            GTN.mc_ringnet.GTN_RN_GetAbsEncPosEx(1, 4, out long absEncPosEx);
            double temp = parameter.RAXISZERO - absEncPosEx;
            if (Math.Abs(temp) > 100000)
            {
                Console.WriteLine("R : " + temp.ToString());
                return;
            }

            int pulse = Convert.ToInt32(temp);
            AxisMoveRel(1, 4, pulse, 100, 10, 10, 0);
            int pStatus;
            do
            {
                Res = GTN.mc.GTN_GetSts(1, 4, out pStatus, 1, out uint pClock);
                CommandHandler("GTN_GetSts", Res);
            } while ((pStatus & 0x800) == 0);//等待轴到位
            Thread.Sleep(1000);
            GTN.mc.GTN_ZeroPos(1, 4, 1);
        }

        /// <summary>
        /// 单轴回零
        /// <param name="core"></param>
        /// <param name="axis"></param>
        /// <param name="moveDir">回零方向 -1：负方向，1：正方向<para /></param>
        /// <param name="indexDir">搜索index方向 -1：负方向，1：正方向<para /></param>
        /// <param name="edge">index方向 0：下降沿 非0：上升沿</param>
        /// <param name="velHigh"></param>
        /// <param name="velLow"></param>
        /// <param name="homeOffset"></param>
        /// </summary>
        public static void AxisHome(short core, short axis, short moveDir, short indexDir, short edge, double velHigh, double velLow, int homeOffset)
        {
            GTN.mc.THomePrm tHomePrm = new GTN.mc.THomePrm();//回零参数结构体
            GTN.mc.THomeStatus tHomeStatus = new GTN.mc.THomeStatus();//回零状态结构体
            tHomePrm.moveDir = moveDir;//回零方向
            tHomePrm.indexDir = indexDir;//搜索index方向
            tHomePrm.edge = edge;//0：下降沿，非0：上升沿
            tHomePrm.velHigh = velHigh;//一段速
            tHomePrm.velLow = velLow;//二段速
            tHomePrm.acc = 1;//回零加速度
            tHomePrm.dec = 1;//回零减速度
            tHomePrm.smoothTime = 0;//平滑时间，取值范围[0,1)
            tHomePrm.homeOffset = homeOffset;//原点偏移
            tHomePrm.searchHomeDistance = 0;//home搜索距离  0表示最大805306368
            tHomePrm.searchIndexDistance = 0;//Index搜索距离  0表示最大805306368
            tHomePrm.escapeStep = 5000;//限位回原点时反向脱离距离或者压在感应器上脱离的距离

            tHomePrm.mode = GTN.mc.HOME_MODE_LIMIT_INDEX;//轴1-3的回零模式

            //回零线程 
            homeToken.Cancel();//如果之前有Task则取消之
            Thread.Sleep(1000);//需要紧跟sleep否则还没来得及取消，下个任务又来了，会出现两个task同时
            homeToken = new CancellationTokenSource();//新建一个cancelhome
            Task taskHome = new Task(() =>
            {
                SmartHome(core, axis, tHomePrm, out tHomeStatus);
                try
                {
                    homeToken.Token.ThrowIfCancellationRequested();
                    Console.WriteLine("Axis " + axis.ToString() + "home executed");
                }
                catch
                {
                    Console.WriteLine("Axis " + axis.ToString() + "home cancelled");
                }
            }, homeToken.Token);
            taskHome.Start();

            //THomeStatus homeStatus = new THomeStatus();
            //bool listenStatus = true;
            //Task taskHomeStatus = new Task(() =>
            //{
            //    do
            //    {
            //        Z = GTN.mc.GTN_GetHomeStatus(core, axis, out THomeStatus homeStatus);
            //        commandHandler("GTN_GetHomeStatus", Z);
            //        if (homeStatus.stage == 100 && homeStatus.run == 0) listenStatus = false;
            //        if (homeToken.Token.IsCancellationRequested)
            //        {
            //            Console.WriteLine("listen cancelled");
            //            break;//homeToken同样会结束监听状态                        
            //        }
            //    } while (listenStatus);
            //}, homeToken.Token);
            //taskHomeStatus.Start();
        }

        /// <summary>
        /// 用户调用，XYZR全轴回零
        /// </summary>
        public static void XYZR_AxisHome()
        {
            GTN.mc.THomePrm tHomePrm = new GTN.mc.THomePrm();//回零参数结构体
            GTN.mc.THomeStatus tHomeStatus = new GTN.mc.THomeStatus();//回零状态结构体
            tHomePrm.moveDir = -1;//回零方向
            tHomePrm.indexDir = 1;//搜索index方向
            tHomePrm.edge = 1;//0：下降沿，非0：上升沿
            tHomePrm.velHigh = 100;//一段速
            tHomePrm.velLow = 10;//二段速
            tHomePrm.acc = 1;//回零加速度
            tHomePrm.dec = 1;//回零减速度
            tHomePrm.smoothTime = 0;//平滑时间，取值范围[0,1)
            tHomePrm.homeOffset = 0;//原点偏移
            tHomePrm.searchHomeDistance = 0;//home搜索距离  0表示最大805306368
            tHomePrm.searchIndexDistance = 0;//Index搜索距离  0表示最大805306368
            tHomePrm.escapeStep = 5000;//限位回原点时反向脱离距离或者压在感应器上脱离的距离

            tHomePrm.mode = GTN.mc.HOME_MODE_LIMIT_INDEX;//轴1-3的回零模式

            //回零线程 
            homeToken.Cancel();//如果之前有Task则取消之
            Thread.Sleep(1000);//需要紧跟sleep否则还没来得及取消，下个任务又来了，会出现两个task同时
            homeToken = new CancellationTokenSource();//新建一个cancelhome
            Task taskHomeX = new Task(() =>
            {
                SmartHome(1, 1, tHomePrm, out tHomeStatus);
                try
                {
                    homeToken.Token.ThrowIfCancellationRequested();
                    Console.WriteLine("X home executed");
                }
                catch
                {
                    Console.WriteLine("X home cancelled");
                }
            }, homeToken.Token);
            taskHomeX.Start();
            Task taskHomeY = new Task(() =>
            {
                SmartHome(1, 2, tHomePrm, out tHomeStatus);
                try
                {
                    homeToken.Token.ThrowIfCancellationRequested();
                    Console.WriteLine("Y home executed");
                }
                catch
                {
                    Console.WriteLine("Y home cancelled");
                }
            }, homeToken.Token);
            taskHomeY.Start();
            Task taskHomeZ = new Task(() =>
            {
                SmartHome(1, 3, tHomePrm, out tHomeStatus);
                try
                {
                    homeToken.Token.ThrowIfCancellationRequested();
                    Console.WriteLine("Z home executed");
                }
                catch
                {
                    Console.WriteLine("Z home cancelled");
                }
            }, homeToken.Token);
            taskHomeZ.Start();
            Task taskHomeR = new Task(() =>
            {
                R_AxisHome();
                try
                {
                    homeToken.Token.ThrowIfCancellationRequested();
                    Console.WriteLine("R home executed");
                }
                catch
                {
                    Console.WriteLine("R home cancelled");
                }
            }, homeToken.Token);
            taskHomeR.Start();
        }

        public static void LoaderAxisHome()
        {
            Task taskHomeAxisA = new Task(() =>
            {
                EcatGoHome(1, 100000, 10000, 100000);
                try
                {
                    homeToken.Token.ThrowIfCancellationRequested();
                    Console.WriteLine("A home executed");
                }
                catch
                {
                    Console.WriteLine("A home cancelled");
                }
            }, homeToken.Token);
            taskHomeAxisA.Start();

            Task taskHomeAxisV = new Task(() =>
            {
                EcatGoHome(2, 100000, 10000, 100000);
                try
                {
                    homeToken.Token.ThrowIfCancellationRequested();
                    Console.WriteLine("V home executed");
                }
                catch
                {
                    Console.WriteLine("V home cancelled");
                }
            }, homeToken.Token);
            taskHomeAxisV.Start();

            Task taskHomeAxisW = new Task(() =>
            {
                EcatGoHome(3, 100000, 10000, 100000);
                try
                {
                    homeToken.Token.ThrowIfCancellationRequested();
                    Console.WriteLine("W home executed");
                }
                catch
                {
                    Console.WriteLine("W home cancelled");
                }
            }, homeToken.Token);
            taskHomeAxisW.Start();

            Task taskHomeAxisU1 = new Task(() =>
            {
                EcatGoHome(4, 100000, 10000, 100000);
                try
                {
                    homeToken.Token.ThrowIfCancellationRequested();
                    Console.WriteLine("U1 home executed");
                }
                catch
                {
                    Console.WriteLine("U1 home cancelled");
                }
            }, homeToken.Token);
            taskHomeAxisU1.Start();

            Task taskHomeAxisU2 = new Task(() =>
            {
                EcatGoHome(5, 100000, 10000, 100000);
                try
                {
                    homeToken.Token.ThrowIfCancellationRequested();
                    Console.WriteLine("U2 home executed");
                }
                catch
                {
                    Console.WriteLine("U2 home cancelled");
                }
            }, homeToken.Token);
            taskHomeAxisU2.Start();
        }

        /// <summary>
        /// 获取轴状态
        /// </summary>
        /// <param name="axis"></param>
        /// <returns></returns>
        public static int GetAxisStatus(out AxisStatus axis)
        {
            axis = new AxisStatus();//结构题需要实例化

            //刷新轴状态
            uint pClock; //时钟信号

            //核1轴1-4位置速度运动模式显示，获取int,double类的Value
            Res = GTN.mc.GTN_GetPrfMode(1, 1, out int pPrfMode, 1, out pClock);
            Res = GTN.mc.GTN_GetPrfPos(1, 1, out double pPrfPos, 1, out pClock);
            Res = GTN.mc.GTN_GetPrfVel(1, 1, out double pPrfVel, 1, out pClock);
            Res = GTN.mc.GTN_GetEncPos(1, 1, out double pEncPos, 1, out pClock);
            Res = GTN.mc.GTN_GetEncVel(1, 1, out double pEncVel, 1, out pClock);

            //轴状态指示灯，只能读取状态为0或1
            Res = GTN.mc.GTN_GetSts(1, 1, out int AxisStatus, 1, out pClock);//读取1-4轴状态

            //赋值并在label显示            
            axis.PrfMode = pPrfMode;
            axis.PrfPos = pPrfPos;
            axis.EncPos = pEncPos;
            axis.PrfVel = pPrfVel;
            axis.EncVel = pEncVel;
            axis.AxisAlarm = ((AxisStatus & 0x002) == 0) ? false : true;
            axis.FollowError = ((AxisStatus & 0x010) == 0) ? false : true;
            axis.P_Lmt = ((AxisStatus & 0x020) == 0) ? false : true;
            axis.N_Lmt = ((AxisStatus & 0x040) == 0) ? false : true;
            axis.SmoothStop = ((AxisStatus & 0x080) == 0) ? false : true;
            axis.AbruptStop = ((AxisStatus & 0x100) == 0) ? false : true;
            axis.AxisOn = ((AxisStatus & 0x200) == 0) ? false : true;
            axis.Motion = ((AxisStatus & 0x400) == 0) ? false : true;
            axis.Arrive = ((AxisStatus & 0x800) == 0) ? false : true;

            return 0;
        }

        /// <summary>
        /// 运动固定点的函数
        /// </summary>
        /// <param name="position">0 = Wafer Low to High；1 = Wafer High to Low;2 = Pin Low to High；3 = Pin High to Low</param>
        public static void TogglePosition(int position)
        {
            switch (position)
            {
                case 0:
                    XYZ_AxisMoveRel(1, parameter.XWAFERLOW2HIGHT, parameter.YWAFERLOW2HIGHT, parameter.ZWAFERLOW2HIGHT, 600, 10, 10, 20);
                    break;
                case 1:
                    XYZ_AxisMoveRel(1, -parameter.XWAFERLOW2HIGHT, -parameter.YWAFERLOW2HIGHT, -parameter.ZWAFERLOW2HIGHT, 600, 10, 10, 20);
                    break;
                case 2:
                    XYZ_AxisMoveRel(1, parameter.XPINLOW2HIGH, parameter.YPINLOW2HIGH, 0, 600, 10, 10, 20);
                    break;
                case 3:
                    XYZ_AxisMoveRel(1, -parameter.XPINLOW2HIGH, -parameter.YPINLOW2HIGH, 0, 600, 10, 10, 20);
                    //AxisMoveAbs(1, 3, Motion.parameter.ZPROBER, 600, 10, 10, 20);
                    break;
                default:
                    break;

            }

            return;
        }
    }
}
