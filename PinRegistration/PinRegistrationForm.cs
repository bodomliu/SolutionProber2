using CommonComponentLibrary;
using JsonDataShow;
using MotionLibrary;
using PinRegistration;//需要pinMagControl控件
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using VisionLibrary;
using WaferMapLibrary;

namespace MainForm
{
    public partial class PinRegistrationForm : Form
    {
        public PinRegistrationForm()
        {
            this.TopLevel = false; this.FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
        }
        private void PinRegistrationForm_Load(object sender, EventArgs e)
        {
            NumRefPinOffsetR.Maximum = 100000;
            NumRefPinOffsetR.Minimum = -100000;
            groupBox1.Controls.Add(new PinSearchControl());
            panelMag.Controls.Add(new PinMagControl());
        }
        private void UpdateUI()
        {
            NumRefPinOffsetR.Value = decimal.Parse(PinData.Entity.PinsAngle.ToString());
        }
        private void BtnFocusInitial_Click(object sender, EventArgs e)
        {
            if (Vision.activeCamera == Camera.PinLowMag)
            {
                //CommonFunctions.AdjustHeight(37000, 39000, Vision.PinLowMag);
                MessageBox.Show("Change to High Mag!"); return;
            }
            else if (Vision.activeCamera == Camera.PinHighMag)
            {
                WaitingControl.WF.Start();
                AdjustHeight.PinFocus(true);
                WaitingControl.WF.End();
            }
        }
        private void BtnRefPinRegistration_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Reference pin will be located and all the other pins will follow the ref.",
                "Ref Pin Registration", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (res == DialogResult.OK)
            {
                Motion.XYZ_GetEncPos(out double encodeX, out double encodeY, out double encodeZ);
                //当前RefPin的位置，是否需要保存呢？
                PinData.Entity.RefPinX = encodeX;
                PinData.Entity.RefPinY = encodeY;
                PinData.Entity.RefPinZ = encodeZ;

                PinData.Save(DeviceData.Entity.PinAlignment.PinDataPath);
                UpdateUI();
            }
        }
        private void BtnReadyToApply_Click(object sender, EventArgs e)
        {
            UpdateProbePosition();//更新Probe参数
            PinData.IsPinAlignCompleted = true;
            MessageBox.Show("Pin Alignment Compeleted!");
        }
        /// <summary>
        /// 更新所有Probe所需要的参数
        /// </summary>
        public void UpdateProbePosition()
        {
            double waferOffset = WaferMap.WaferHeight - Motion.parameter.PROBING.ZOrgWaferHeight;//wafer比注册高了waferOffset
            double pinOffset = PinData.Entity.RefPinZ - Motion.parameter.PROBING.ZOrgPin;//pin比注册高了pinOffset
            double orgZUp = Motion.parameter.PROBING.ZOrgWaferHeight + Motion.parameter.PROBING.ZPad2Pin;//注册时候upPos

            DeviceData.Entity.Probing.ZUpPosition = orgZUp - waferOffset + pinOffset;//当前的upPos理论值
            DeviceData.Entity.Probing.ZDownPosition = DeviceData.Entity.Probing.ZUpPosition + DeviceData.Entity.Probing.ZClearance;
        }
        private void BtnRefreshPinDataFromPadData_Click(object sender, EventArgs e)
        {
            PinData.Entity.Pins.Clear();
            PinData.Entity.PinsAngle = 0;
            // 获取相关实体数据的引用以减少重复访问
            var duts = DUTData.Entity.DUTs;
            var pads = PadData.Entity.Pads;
            var dieSizeX = WaferMap.Entity.DieSizeX;
            var dieSizeY = WaferMap.Entity.DieSizeY;

            // 遍历 DUT 和 Pad 并更新 PinData
            foreach (var dut in duts)
            {
                foreach (var pad in pads)
                {
                    // 计算每个 Pin 的位置
                    double x = pad.PosX + dut.X * dieSizeX;
                    double y = pad.PosY + dut.Y * dieSizeY;

                    // 添加计算后的 Pin 到 Pins 列表中
                    PinData.Entity.Pins.Add(new Pin { PosX = x, PosY = y });
                }
            }

            PinData.Save(DeviceData.Entity.PinAlignment.PinDataPath);
            MessageBox.Show("All Pins are refreshed from pad data!");
            UpdateUI();
        }
        private void BtnDeletePinWPad_Click(object sender, EventArgs e)
        {

        }
        private void BtnAddPinWPad_Click(object sender, EventArgs e)
        {
            //获得当前XY坐标
            Motion.GetUserPos(Compensation.Area.Probing, out double X, out double Y);
            Compensation.Transform(Compensation.Area.Probing, Compensation.Dir.Encode2User,
                PinData.Entity.RefPinX, PinData.Entity.RefPinY, out double RefX, out double RefY);
            double posX = X - RefX;//以refpin为原点的坐标
            double posY = Y - RefY;//以refpin为原点的坐标

            PinData.Entity.Pins.Add(new Pin { PosX = -posX, PosY = -posY });//标定用的坐标系，和探针卡方向相反
            PinData.CurrentIndex = PinData.Entity.Pins.Count - 1;
            PinData.Save(DeviceData.Entity.PinAlignment.PinDataPath);
            UpdateUI();
        }
        private void BtnUpdatePinWPad_Click(object sender, EventArgs e)
        {
            //获得当前XY坐标
            Motion.GetUserPos(Compensation.Area.Probing, out double X, out double Y);
            Compensation.Transform(Compensation.Area.Probing, Compensation.Dir.Encode2User,
                PinData.Entity.RefPinX, PinData.Entity.RefPinY, out double RefX, out double RefY);
            double posX = X - RefX;//以refpin为原点的坐标
            double posY = Y - RefY;//以refpin为原点的坐标

            PinData.Entity.Pins[PinData.CurrentIndex].PosX = -posX;//标定用的坐标系，和探针卡方向相反
            PinData.Entity.Pins[PinData.CurrentIndex].PosY = -posY;//标定用的坐标系，和探针卡方向相反
            PinData.Entity.Pins[PinData.CurrentIndex].PosZ = Motion.EncodeZ;
            PinData.Save(DeviceData.Entity.PinAlignment.PinDataPath);
            UpdateUI();
        }

        #region 绘图
        private void PinRegistrationForm_ParentChanged(object sender, EventArgs e)
        {
            if (Parent != null)
            {
                panel1.Controls.Clear();
                panel1.Controls.Add(CommonPanel.Entity);
                //默认是低倍相机启动
                //Vision.ChangeCamera(Vision.PinLowMag);//默认粗定位
                UpdateUI();
            }
            else
            {

            }
        }
        /// <summary>
        /// 将转换后的坐标丢进去显示
        /// </summary>
        private void PaintPins()
        {
            // Prepare data before painting
            (double[] encodeX, double[] encodeY) = PaintPrepare();
            // Use the prepared data for painting
            Vision.PinLowMag.halconClass.PaintPins(encodeX, encodeY, PinData.CurrentIndex);
        }
        //绘图准备，获得encode值
        private (double[] encodeX, double[] encodeY)PaintPrepare()
        {
            //对PinData先预处理，用于绘画
            int pinCount = PinData.Entity.Pins.Count;
            double[] encodeX = new double[pinCount];
            double[] encodeY = new double[pinCount];
            //将所有pin转到encode坐标系下，方便绘图
            for (int i = 0; i < pinCount; i++)
            {
                //粗定位画图，精度不要紧，主要为了变换坐标系，确保符号方向一致。标定过程是用的encode坐标，所以画图最好也用encode坐标
                Compensation.Transform(Compensation.Area.Probing, Compensation.Dir.User2Encode,
                    PinData.Entity.Pins[i].PosX, PinData.Entity.Pins[i].PosY, out double outx, out double outy);
                encodeX[i] = outx; encodeY[i] = outy;
            }
            return (encodeX, encodeY);
        }
        private void RotatePins(double Angle)
        {
            //根据预设的angle，并旋转所有pins
            for (int i = 0; i < PinData.Entity.Pins.Count; i++)
            {
                //encode坐标系是标准笛卡尔坐标系，用户坐标系Y轴反向，导致旋转方向反向
                CommonFunctions.RotatePoint(PinData.Entity.Pins[i].PosX, PinData.Entity.Pins[i].PosY, 0, 0,
                    -Angle + PinData.Entity.PinsAngle, out double posX, out double posY);
                PinData.Entity.Pins[i].PosX = posX; PinData.Entity.Pins[i].PosY = posY;
            }
            PinData.Entity.PinsAngle = Angle;
        }
        private void UpdatePinRegist(double Angle)
        {


        }
        private void CBShowPins_CheckedChanged(object sender, EventArgs e)
        {
            if (CBShowPins.Checked)
            {
                PaintPrepare();
                Vision.PinLowMag.halconClass.OnPaintEvent += PaintPins;
                Vision.PinLowMag.halconClass.bDisplayROI = true;
                Vision.PinLowMag.halconClass.bDisplayCross = true;
            }
            else
            {
                Vision.PinLowMag.halconClass.OnPaintEvent -= PaintPins;
                Vision.PinLowMag.halconClass.bDisplayROI = false;
                Vision.PinLowMag.halconClass.bDisplayCross = false;
            }
        }
        #endregion

        private void BtnUpdateDegree_Click(object sender, EventArgs e)
        {
            double newAngle = double.Parse(NumRefPinOffsetR.Value.ToString());
            RotatePins(newAngle);//改变角度和所有点位

            PinData.Save(DeviceData.Entity.PinAlignment.PinDataPath);
            PaintPrepare();
        }
        private void PinRegistrationForm_VisibleChanged(object sender, EventArgs e)
        {

        }
        private void BtnOrgPinInitial_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Reference pin will be located and all the other pins will follow the ref.",
               "Ref Pin Registration", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (res == DialogResult.OK)
            {
                Motion.XYZ_GetEncPos(out double encodeX, out double encodeY, out double encodeZ);
                //当前RefPin的位置，是否需要保存呢？
                PinData.Entity.RefPinX = encodeX;
                PinData.Entity.RefPinY = encodeY;
                PinData.Entity.RefPinZ = encodeZ;
                //将orgpin也定义一下
                Motion.parameter.PROBING.XOrgPin = encodeX;
                Motion.parameter.PROBING.YOrgPin = encodeY;
                Motion.parameter.PROBING.ZOrgPin = encodeZ;
                Motion.parameter.PROBING.ZOrgWaferHeight = WaferMap.WaferHeight;
                PinData.Save(DeviceData.Entity.PinAlignment.PinDataPath);
                UpdateUI();
            }
        }
        private void BtnPinData_Click(object sender, EventArgs e)
        {
            JsonDataForm form = new JsonDataForm(DeviceData.Entity.PinAlignment.PinDataPath, PinData.Entity);
            DialogResult res = form.ShowDialog();
        }

        //currentPos直接和理想的pad位置做匹配求角度，不能和pin匹配的原因是累计求几次deltaAngle后，可能存在累计误差
        public static int AdjustAngle(int AlignMode, out double PinAngle) 
        {
            PinAngle = 0;

            int cntPins = PinData.Entity.Pins.Count;
            int cntPads = PadData.Entity.Pads.Count;
            int cntDut = DUTData.Entity.DUTs.Count;
            if (cntDut * cntPads != cntPins) return 1;//数量不匹配

            List<Pin> Pads = new List<Pin>();
            //寻pin时，按dut顺序找，所以pads和pins顺序一致 
            //Step1: 先构造pads队列
            for (int dutIndex = 0; dutIndex < cntDut; dutIndex++)
            {
                for (int padIndex = 0; padIndex < cntPads; padIndex++)
                {
                    int pinIndex = dutIndex * cntPads + padIndex;
                    if (PinData.Entity.Pins[pinIndex].AlignMode == AlignMode)
                    {
                        double posX = PadData.Entity.Pads[padIndex].PosX + DUTData.Entity.DUTs[dutIndex].X * WaferMap.Entity.DieSizeX;
                        double posY = PadData.Entity.Pads[padIndex].PosY + DUTData.Entity.DUTs[dutIndex].Y * WaferMap.Entity.DieSizeY;

                        Pads.Add(new Pin { PosX = posX, PosY = posY });
                    }
                }
            }
            //Step2: 再对pins筛选
            List<Pin> Pins = PinData.Entity.Pins.Where(p => p.AlignMode == AlignMode).ToList();


            //Step3: 求每个 pad/pin 到 refpad/refpin 的角度/距离
            int pinsSelect = Pins.Count;
            double[] anglePad = new double[pinsSelect];
            double[] anglePin = new double[pinsSelect];
            double[] deltaAngle = new double[pinsSelect];
            double[] distance = new double[pinsSelect];
            for (int index = 1; index < pinsSelect; index++)
            {
                anglePad[index] = Math.Atan2(Pads[index].PosY, Pads[index].PosX);
                anglePin[index] = Math.Atan2(Pins[index].CurrentPosY, Pins[index].CurrentPosX);
                deltaAngle[index] = anglePin[index] - anglePad[index];
                //Console.WriteLine()
                distance[index] = Math.Sqrt(Pads[index].PosX * Pads[index].PosX + Pads[index].PosY * Pads[index].PosY);
            }
            //Step4: 根据权重，求deltaAngle的赋值，当前为一次平均
            double distSum = distance.Sum();
            for (int index = 0; index < pinsSelect; index++)
            {
                PinAngle += deltaAngle[index] * distance[index] / distance.Sum();
            }
            PinAngle = -PinAngle / Math.PI * 180 * 10000;//返回角度，因为用用户坐标系计算的角度，与标准笛卡尔坐标系差一个符号
            Console.WriteLine("{0} points Matched, Pin Angle = {1} degree.", pinsSelect, PinAngle);
            return 0;
        }
        private void BtnAdjustAngle_Click(object sender, EventArgs e)
        {
            AdjustAngle(1, out double deltaAngle);
            Console.WriteLine(deltaAngle.ToString());
        }
        private void BtnM_Pin_Click(object sender, EventArgs e)
        {            
            PinDataForm form = new();
            DialogResult res = form.ShowDialog();
        }
    }
}
