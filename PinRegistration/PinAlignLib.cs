using CommonComponentLibrary;
using MotionLibrary;
using VisionLibrary;
using WaferMapLibrary;

namespace PinRegistration
{
    internal static class PinAlignLib
    {
        public static void MovePinToCenter()
        {
            int GetPinXArea = DeviceData.Entity.PinAlignment.GetPinXArea;
            int GetPinYArea = DeviceData.Entity.PinAlignment.GetPinYArea;
            Vision.PinHighMag.halconClass.m_Roi.Resize2(512, 640, GetPinXArea, GetPinYArea);//blobROI
            float expo = DeviceData.Entity.PinAlignment.GetPinExposureTime;
            Vision.PinHighMag.SetExposureTime(expo);//blob曝光
            Thread.Sleep(500);//避免没生效
            Vision.PinHighMag.TriggerMode();
            Vision.PinHighMag.TriggerExec();
            int res = Vision.PinHighMag.halconClass.GetPin(out double DeltaX, out double DeltaY);
            if (res != 0)
            {
                MessageBox.Show("Move To Pin Error.");
            }
            else
            {
                Motion.XY_AxisMoveRel(1, Convert.ToInt32(DeltaX), Convert.ToInt32(DeltaY), 600, 10, 10, 20);
            }
            Vision.PinHighMag.ContinuesMode();
        }
        public static void GoToPin(int index, bool isLowMode = false)
        {
            if (PinData.Entity.Pins.Count == 0) return;
            if (index > PinData.Entity.Pins.Count || index < 0) return;

            //第一步，得到该理论点旋转后的坐标
            CommonFunctions.RotatePoint(PinData.Entity.Pins[index].PosX, PinData.Entity.Pins[index].PosY,
                   0, 0, PinData.Entity.PinsAngle, out double x, out double y);

            //第二步，加上refPin坐标
            x += PinData.Entity.RefPinX;
            y += PinData.Entity.RefPinY;
            double z = PinData.Entity.RefPinZ;

            //根据粗精模式走点
            if (isLowMode)
            {
                x -= Motion.parameter.XPINLOW2HIGH;
                y -= Motion.parameter.YPINLOW2HIGH;
                z -= Motion.parameter.ZPINLOW2HIGH;
            }

            //第三步，上针，在waferAlign区，Z高度会到接近140000，pinAlign区90000
            Motion.AxisMoveAbs(1, 3, z, 600, 10, 10, 20);
            //第三步，走用户坐标
            Motion.XY_AxisMoveAbs(1, x, y, 600, 10, 10, 20);

            PinData.CurrentIndex = index;
        }
        //测试用，后续取消
        public static void TestRotatePins()
        {
            //根据预设的angle，并旋转所有pins
            for (int i = 0; i < PinData.Entity.Pins.Count; i++)
            {
                //encode坐标系是标准笛卡尔坐标系，
                CommonFunctions.RotatePoint(PinData.Entity.Pins[i].CurrentPosX, PinData.Entity.Pins[i].CurrentPosY,
                    PinData.Entity.Pins[0].CurrentPosX, PinData.Entity.Pins[0].CurrentPosY,
                    -PinData.Entity.PinsAngle, out double posX, out double posY);
                PinData.Entity.Pins[i].PosX = posX - PinData.Entity.Pins[0].CurrentPosX;
                PinData.Entity.Pins[i].PosY = posY - PinData.Entity.Pins[0].CurrentPosY;
            }
        }

        //根据pins[0]绕angle后的x,y坐标
        public static void RotateAroundRefPin(out double[] encodeX,out double[] encodeY)
        {
            int cnt = PinData.Entity.Pins.Count;
            encodeX = new double[cnt];encodeY = new double[cnt];
            //根据预设的angle，并旋转所有pins
            for (int i = 0; i < cnt; i++)
            {
                //encode坐标系是标准笛卡尔坐标系，所以角度不变
                CommonFunctions.RotatePoint(PinData.Entity.Pins[i].PosX, PinData.Entity.Pins[i].PosY,
                    PinData.Entity.Pins[0].PosX, PinData.Entity.Pins[0].PosY,
                    PinData.Entity.PinsAngle, out encodeX[i], out encodeY[i]);
            }
        }

        //currentPos直接和理想的pin位置做匹配求角度
        public static int AdjustAngle(int AlignMode, out double PinAngle)
        {
            PinAngle = 0;

            //int cntPins = PinData.Entity.Pins.Count;
            //int cntPads = PadData.Entity.Pads.Count;
            //int cntDut = DUTData.Entity.DUTs.Count;
            //if (cntDut * cntPads != cntPins) return 1;//数量不匹配

            //List<Pin> Pads = new List<Pin>();
            ////寻pin时，按dut顺序找，所以pads和pins顺序一致 
            ////Step1: 先构造pads队列
            //for (int dutIndex = 0; dutIndex < cntDut; dutIndex++)
            //{
            //    for (int padIndex = 0; padIndex < cntPads; padIndex++)
            //    {
            //        int pinIndex = dutIndex * cntPads + padIndex;
            //        if (PinData.Entity.Pins[pinIndex].AlignMode == AlignMode)
            //        {
            //            double posX = PadData.Entity.Pads[padIndex].PosX + DUTData.Entity.DUTs[dutIndex].X * WaferMap.Entity.DieSizeX;
            //            double posY = PadData.Entity.Pads[padIndex].PosY + DUTData.Entity.DUTs[dutIndex].Y * WaferMap.Entity.DieSizeY;

            //            Pads.Add(new Pin { PosX = posX, PosY = posY });
            //        }
            //    }
            //}
            ////Step2: 再对pins筛选
            //List<Pin> Pins = PinData.Entity.Pins.Where(p => p.AlignMode == AlignMode).ToList();


            ////Step3: 求每个 pad/pin 到 refpad/refpin 的角度/距离
            //int pinsSelect = Pins.Count;
            //double[] anglePad = new double[pinsSelect];
            //double[] anglePin = new double[pinsSelect];
            //double[] deltaAngle = new double[pinsSelect];
            //double[] distance = new double[pinsSelect];
            //for (int index = 1; index < pinsSelect; index++)
            //{
            //    anglePad[index] = Math.Atan2(Pads[index].PosY, Pads[index].PosX);
            //    anglePin[index] = Math.Atan2(Pins[index].CurrentPosY, Pins[index].CurrentPosX);
            //    deltaAngle[index] = anglePin[index] - anglePad[index];
            //    //Console.WriteLine()
            //    distance[index] = Math.Sqrt(Pads[index].PosX * Pads[index].PosX + Pads[index].PosY * Pads[index].PosY);
            //}
            ////Step4: 根据权重，求deltaAngle的赋值，当前为一次平均
            //double distSum = distance.Sum();
            //for (int index = 0; index < pinsSelect; index++)
            //{
            //    PinAngle += deltaAngle[index] * distance[index] / distance.Sum();
            //}
            //PinAngle = -PinAngle / Math.PI * 180 * 10000;//返回角度，因为用用户坐标系计算的角度，与标准笛卡尔坐标系差一个符号
            //Console.WriteLine("{0} points Matched, Pin Angle = {1} degree.", pinsSelect, PinAngle);
            return 0;
        }
    }
}
