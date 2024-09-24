using CommonComponentLibrary;
using MotionLibrary;
using VisionLibrary;
using WaferMapLibrary;

namespace PinRegistration
{
    internal static class PinAlignLib
    {
        /// <summary>
        /// 图像处理，获得pin
        /// </summary>
        /// <param name="deltaX"></param>
        /// <param name="deltaY"></param>
        public static int GetPin(bool paintObj, out double deltaX, out double deltaY, out double area)
        {
            int GetPinThreshold = DeviceData.Entity.PinAlignment.GetPinThreshold;
            int GetPinXArea = DeviceData.Entity.PinAlignment.GetPinXArea;
            int GetPinYArea = DeviceData.Entity.PinAlignment.GetPinYArea;
            int blobMin = DeviceData.Entity.PinAlignment.GetPinMinBlob;
            int blobMax = DeviceData.Entity.PinAlignment.GetPinMaxBlob;
            Vision.PinHighMag.halconClass.m_Roi.Resize2(512, 640, GetPinXArea, GetPinYArea);//blobROI
            float expo = DeviceData.Entity.PinAlignment.GetPinExposureTime;
            Vision.PinHighMag.SetExposureTime(expo);//blob曝光
            Thread.Sleep(500);//避免没生效
            Vision.PinHighMag.TriggerMode();
            Vision.PinHighMag.TriggerExec();
            int res = Vision.PinHighMag.halconClass.GetPin(GetPinThreshold, blobMin, blobMax, 5,paintObj,
                out deltaX, out deltaY, out area);
            Thread.Sleep(500);//给0.5秒看到paint
            Vision.PinHighMag.ContinuesMode();
            return res;
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
            //第三步，走encode坐标
            Motion.XY_AxisMoveAbs(1, x, y, 600, 10, 10, 20);

            PinData.CurrentIndex = index;
        }

        public static int MovePinToCenter()
        {
            var res = GetPin(true, out double deltaX, out double deltaY, out _);
            if (res != 0) return res;
            Motion.XY_AxisMoveRel(1, Convert.ToInt32(deltaX), Convert.ToInt32(deltaY), 600, 10, 10, 20);
            return 0;
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

            List<Pin> pins = PinData.Entity.Pins.Where(e => e.CurrentPosX != 0 && e.CurrentPosY != 0 && e.CurrentPosZ != 0).ToList();

            Point currentOrigin = new() { X = 0, Y = 0 };
            Point posOrigin = new() { X = 0, Y = 0 };
            foreach (var p in pins)
            {
                currentOrigin.X += p.CurrentPosX;
                currentOrigin.Y += p.CurrentPosY;
                posOrigin.X += p.PosX;
                posOrigin.Y += p.PosY;
            }
            currentOrigin.X /= pins.Count;
            currentOrigin.Y /= pins.Count;
            posOrigin.X /= pins.Count;
            posOrigin.Y /= pins.Count;


            double[] xs = new double[pins.Count];
            double[] ys = new double[pins.Count];

            for (int i = 0; i < pins.Count; i++)
            {
                Pin p = pins[i];
                Point point = InitPoint(
                    new() { X = p.PosX - posOrigin.X, Y = p.PosY - posOrigin.Y },
                    new() { X = p.CurrentPosX - currentOrigin.X, Y = p.CurrentPosY - currentOrigin.Y });
                xs[i] = point.X;
                ys[i] = point.Y;
            }
            Tuple<double, double> tuple = FitLine(xs, ys);
            
            double radians = Math.Atan(tuple.Item1);

            PinAngle = radians * 180 / Math.PI * 10000;

            return 0;
        }

        public static Tuple<double, double> RotatePoint(double x, double y, double angle)
        {
            double cosTheta = Math.Cos(angle);
            double sinTheta = Math.Sin(angle);

            double newX = x * cosTheta - y * sinTheta;
            double newY = x * sinTheta + y * cosTheta;

            return Tuple.Create(newX, newY);
        }
       

        /// <summary>
        /// 拟合直线
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        static Tuple<double, double> FitLine(double[] x, double[] y)
        {
            if (x.Length != y.Length)
                throw new ArgumentException("x 和 y 数组的长度必须相同");

            int n = x.Length;
            double sumX = x.Sum();
            double sumY = y.Sum();
            double sumXY = x.Zip(y, (xi, yi) => xi * yi).Sum();
            double sumX2 = x.Sum(xi => xi * xi);

            double slope = (n * sumXY - sumX * sumY) / (n * sumX2 - sumX * sumX);
            double intercept = (sumY - slope * sumX) / n;

            return Tuple.Create(slope, intercept);
        }

        static Point InitPoint(Point pos, Point currentPos)
        {
            
            double dotProduct = pos.X * currentPos.X + pos.Y * currentPos.Y;
            double crossProduct = currentPos.X * pos.Y - pos.X * currentPos.Y;

            double posLength = Math.Sqrt(pos.X * pos.X + pos.Y * pos.Y);
            double currentPosLength = Math.Sqrt(currentPos.X * currentPos.X + currentPos.Y * currentPos.Y);

            return new()
            {
                X = dotProduct / posLength,
                Y = crossProduct / posLength
            };
        }
        private class Point
        {
            public double X;
            public double Y;
        }
    }

    
}
