using MotionLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            if (PinData.Entity.Pins == null) return;
            if (index > PinData.Entity.Pins.Count || index < 0) return;
            //根据粗精模式走点
            double refPinX = PinData.Entity.RefPinX;
            double refPinY = PinData.Entity.RefPinY;
            double refPinZ = PinData.Entity.RefPinZ;
            if (isLowMode)
            {
                refPinX -= Motion.parameter.XPINLOW2HIGH;
                refPinY -= Motion.parameter.YPINLOW2HIGH;
                refPinZ -= Motion.parameter.ZPINLOW2HIGH;
            }
            //第一步，得到refPin用户坐标X,Y
            Compensation.Transform(Compensation.Area.Probing, Compensation.Dir.Encode2User, refPinX, refPinY,
                out double X0, out double Y0);
            //第二步，得到目标Pin用户坐标
            double X = X0 - PinData.Entity.Pins[index].PosX;//标定时，目标点在(dX,dY)位置时的encode1，与目标从中点运动到(dX,dY)位置的encode符号相反
            double Y = Y0 - PinData.Entity.Pins[index].PosY;
            //第三步，走用户坐标
            Motion.UserPosMoveAbs(Compensation.Area.Probing, X, Y);
            //第四步，上针
            Motion.AxisMoveAbs(1, 3, refPinZ, 600, 10, 10, 20);
            PinData.CurrentIndex = index;
        }
     }
}
