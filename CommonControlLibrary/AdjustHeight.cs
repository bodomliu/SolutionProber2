using MotionLibrary;
using VisionLibrary;
using WaferMapLibrary;

namespace CommonComponentLibrary
{
    public static class AdjustHeight
    {
        public static int PinFocus(bool FocusInitial = false)
        {
            int TipFocusXArea = DeviceData.Entity.PinAlignment.TipFocusXArea;
            int TipFocusYArea = DeviceData.Entity.PinAlignment.TipFocusYArea;
            Vision.PinHighMag.halconClass.m_Roi.Resize2(512, 640, TipFocusXArea, TipFocusYArea);//blobROI
            Vision.PinHighMag.SetExposureTime(DeviceData.Entity.PinAlignment.TipFocusExposureTime);//blob曝光
            Thread.Sleep(500);//避免没生效
            //FocusInitial = 133500 - 60000 = 73500
            double target = (FocusInitial) ?
                Motion.parameter.ZPROBECARDUPPERPLATEBASE - DeviceData.Entity.PinAlignment.NeddleTipFocusOffset
                : PinData.Entity.RefPinZ;
            double range = (FocusInitial) ? 10000 : 1000;
            double slowStep = 10;
            double fastStep = 100;

            return AdjustHight(Vision.PinHighMag, target, range, slowStep, fastStep, out _);
        }
        public static int WaferFocus(CameraClass Mag, bool withWafer)
        {
            //均以精定位为准
            double thickness = (withWafer) ? DeviceData.Entity.PhysicalInformation.Thickness : 0;//处理有没有晶圆
            double target = Motion.parameter.ZORIGIN - thickness;//46000 - 8000 = 38000
            double range = 1000;//精定位1000
            double slowStep = 10;
            double fastStep = 100;

            if (Mag == Vision.WaferLowMag)
            {
                target -= Motion.parameter.ZWAFERLOW2HIGHT;//38000 - （-8000）= 46000;
                range = 10000;//粗定位range = 1mm
                slowStep = 100;//粗定位slowStep = 10um
                fastStep = 1000;//粗定位fastStep = 100um
            }
            else if (Mag == Vision.WaferHighMag)
            {

            }
            else if (Mag == Vision.JigCamera)
            {
                target += Motion.parameter.ZALIGN2PROBE;//38000 + 45823 = 83823
            }

            return AdjustHight(Mag, target, range, slowStep, fastStep, out _);
        }

        //在当前高度进行微调
        public static int MinorAdjustment(CameraClass Mag)
        {
            //均以精定位为准
            double target = Motion.EncodeZ;//当前encodeZ就是目标
            double range = 1000;//精定位1000
            double slowStep = 10;
            double fastStep = 100;

            if (Mag == Vision.WaferLowMag)
            {
                range = 10000;//粗定位range = 1mm
                slowStep = 100;//粗定位slowStep = 10um
                fastStep = 1000;//粗定位fastStep = 100um
            }
            else if (Mag == Vision.WaferHighMag)
            {

            }
            else if (Mag == Vision.JigCamera)
            {
                target += Motion.parameter.ZALIGN2PROBE;//38000 + 45823 = 83823
            }

            return AdjustHight(Mag, target, range, slowStep, fastStep, out _);
        }


        private static int AdjustHight(CameraClass Mag, double target, double range, double slowStep, double fastStep, out double peak)
        {
            Mag.TriggerMode();

            int res = Traverse(Mag, target, range, fastStep, 0.8, out peak, out double peakValue);//先做一轮粗寻
            if (res != 0) { Mag.ContinuesMode(); return res; }//如果最高点再两端，则直接退出

            res = Traverse(Mag, peak, fastStep, slowStep, 0.8, out peak, out peakValue);//以fastStep为范围，peak为目标，再精定位一轮
            Motion.AxisMoveAbs(1, 3, peak, 600, 20, 20, 10);//无论是否精定位成功，都运动到peak
            Mag.ContinuesMode();
            return res;
        }
        private static int Traverse(CameraClass Mag, double target, double range, double step, double threshold,
            out double peak, out double peakValue)
        {
            List<double> pos = new();
            List<double> def = new();

            peak = target - range;//初始值=起始位
            peakValue = 0;//初始值=0
            for (double z = target - range; z < target + range; z += step)
            {
                Motion.AxisMoveAbs(1, 3, z, 600, 20, 20, 10);
                Mag.TriggerExec();
                Mag.halconClass.EvaluateDefinition(out double Definition);//计算清晰度

                pos.Add(z);
                def.Add(Definition);

                peakValue = def.Max();//峰值赋值

                Console.WriteLine("pos= " + z + "  def= " + Definition);
                if (Definition / peakValue < threshold) break;//如果当前的清晰度/最大值 < 阈值 则提前结束
            }

            int peakIdx = def.IndexOf(peakValue);//找Def最大处的index值
            peak = pos[peakIdx];//return the peak Postion

            if (peakIdx == 0 || peakIdx == def.Count - 1) return 1;//最大值在起始或终点位置
            return 0;
        }
    }
}
