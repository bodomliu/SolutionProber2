using CommonComponentLibrary;
using MotionLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisionLibrary;
using WaferMapLibrary;

namespace UtilityForm
{
    public partial class CenterControl : UserControl
    {
        public CenterControl()
        {
            InitializeComponent();
        }

        private void CenterControl_Load(object sender, EventArgs e)
        {
            panel1.Controls.Add(new CommonComponentLibrary.WaferMagControl());
        }

        /// <summary>
        /// 已知旋转前后的点坐标计算旋转中心坐标
        /// https://blog.csdn.net/lmn11004020215/article/details/103575932/
        /// </summary>
        /// <param name="R">弧度，逆时针为正,考虑用户坐标系与笛卡尔坐标系相反手系，所以R取反</param>
        /// <param name="X1">旋转前的坐标</param>
        /// <param name="Y1"></param>
        /// <param name="X2">旋转后的坐标</param>
        /// <param name="Y2"></param>
        /// <param name="CenterX"></param>
        /// <param name="CenterY"></param>
        private void GetRotateCenter(double R, double X1, double Y1, double X2, double Y2, out double X, out double Y)
        {
            double cosR = Math.Cos(R);
            double sinR = Math.Sin(R);
            //X2 - X = cosR * (X1 - X) - sinR * (Y1 - Y)
            //Y2 - Y = sinR * (X1 - X) + cosR * (Y1 - Y)
            X = ((sinR * X1 + cosR * Y1 - Y2) / (cosR - 1) - (X2 - cosR * X1) / sinR - Y1) /
                ((cosR - 1) / sinR + sinR / (cosR - 1));
            Y = ((cosR - 1) * X + X2 - cosR * X1) / sinR + Y1;
        }

        private void BtnGetRotateCenter_Click(object sender, EventArgs? e)
        {
            try
            {
                double R = double.Parse(TxtR.Text) / 10000 / 180 * Math.PI;
                double X1 = double.Parse(TxtX1.Text);
                double Y1 = double.Parse(TxtY1.Text);
                double X2 = double.Parse(TxtX2.Text);
                double Y2 = double.Parse(TxtY2.Text);
                GetRotateCenter(R, X1, Y1, X2, Y2, out double X, out double Y);
                TxtX.Text = X.ToString("F0");
                TxtY.Text = Y.ToString("F0");
            }
            catch
            {
                MessageBox.Show("Rrong Input !");
            }
        }

        private void BtnGetPos1_Click(object sender, EventArgs? e)
        {
            double X; double Y;
            if (CbCompensation.Checked)
            {
                Motion.GetUserPos(Compensation.Area.Align, out X, out Y);
            }
            else
            {
                Motion.XY_GetEncPos(out X, out Y);
            }
            TxtX1.Text = X.ToString();
            TxtY1.Text = Y.ToString();
        }

        private void BtnGetPos2_Click(object sender, EventArgs? e)
        {
            double X; double Y;
            if (CbCompensation.Checked)
            {
                Motion.GetUserPos(Compensation.Area.Align, out X, out Y);
            }
            else
            {
                Motion.XY_GetEncPos(out X, out Y);
            }
            TxtX2.Text = X.ToString();
            TxtY2.Text = Y.ToString();
        }

        private void BtnRNeg_Click(object sender, EventArgs e)
        {
            Motion.AxisMoveRel(1, 4, -double.Parse(TxtPulse.Text), 600, 10, 10, 20);
        }

        private void BtnRPlus_Click(object sender, EventArgs e)
        {
            Motion.AxisMoveRel(1, 4, double.Parse(TxtPulse.Text), 600, 10, 10, 20);
        }

        private void BtnAlignX_Click(object sender, EventArgs e)
        {
            int interval = int.Parse(TxtLR.Text);
            CommonFunctions.AlignX(Vision.WaferHighMag, DeviceData.Entity.WaferAlignment.HighPattern1, interval, interval,
                WaferMap.Entity.DieSizeX, out double RotateX);
            TxtX.Text = RotateX.ToString("F0");
        }

        private void BtnAlignY_Click(object sender, EventArgs e)
        {
            int interval = int.Parse(TxtUD.Text);
            CommonFunctions.AlignY(Vision.WaferHighMag, DeviceData.Entity.WaferAlignment.HighPattern1, interval, interval,
                WaferMap.Entity.DieSizeY, out double RotateY);
            TxtY.Text = RotateY.ToString("F0");
        }

        private void BtnMatch_Click(object sender, EventArgs e)
        {
            if (Vision.activeCamera == Camera.WaferLowMag)
            {
                CommonFunctions.Match(DeviceData.Entity.WaferAlignment.LowPattern1, Vision.WaferLowMag, out _, out _);
            }
            else if (Vision.activeCamera == Camera.WaferHighMag)
            {
                CommonFunctions.Match(DeviceData.Entity.WaferAlignment.HighPattern1, Vision.WaferHighMag, out _, out _);
            }
        }

        private void BtnAuto_Click(object sender, EventArgs e)
        {
            //12,1
            double RotatePulse = double.Parse(TxtPulse.Text);
            double Origin_X; double Origin_Y;
            Motion.GetUserPos(Compensation.Area.Align, out Origin_X, out Origin_Y);
            Motion.AxisMoveRel(1, 4, RotatePulse, 600, 10, 10, 20);
            Thread.Sleep(2000);
            //Motion.XY_GetEncPos(out double AfterRotation_X, out double AfterRotation_Y);
            double R1 = RotatePulse / 10000 / 180 * Math.PI;
            double cosR = Math.Cos(-R1);
            double sinR = Math.Sin(-R1);
            //X2 - X = cosR * (X1 - X) - sinR * (Y1 - Y)
            //Y2 - Y = sinR * (X1 - X) + cosR * (Y1 - Y)
            double AfterRotation_X = cosR * (Origin_X - Motion.parameter.XROTATE) - sinR * (Origin_Y - Motion.parameter.YROTATE) + Motion.parameter.XROTATE;
            double AfterRotation_Y = sinR * (Origin_X - Motion.parameter.XROTATE) + cosR * (Origin_Y - Motion.parameter.YROTATE) + Motion.parameter.YROTATE;
            double DeltaX = AfterRotation_X - Origin_X;
            double DeltaY = AfterRotation_Y - Origin_Y;
            Thread.Sleep(2000);
            Motion.UserPosMoveAbs(Compensation.Area.Align, AfterRotation_X, AfterRotation_Y);
            Thread.Sleep(3000);

            if (Vision.activeCamera == Camera.WaferLowMag)
            {
                CommonFunctions.Match(DeviceData.Entity.WaferAlignment.LowPattern1, Vision.WaferLowMag, out _, out _);
            }
            else if (Vision.activeCamera == Camera.WaferHighMag)
            {
                CommonFunctions.Match(DeviceData.Entity.WaferAlignment.HighPattern1, Vision.WaferHighMag, out _, out _);
            }
            //BtnMatchLow_Click_1(this, null);

            BtnGetPos1_Click(this, null);
            Motion.AxisMoveRel(1, 4, (-2 * RotatePulse), 600, 10, 10, 20);
            Thread.Sleep(2000);

            double cosR2 = Math.Cos(R1);
            double sinR2 = Math.Sin(R1);
            //X2 - X = cosR * (X1 - X) - sinR * (Y1 - Y)
            //Y2 - Y = sinR * (X1 - X) + cosR * (Y1 - Y)
            double AfterRotation_X2 = cosR2 * (Origin_X - Motion.parameter.XROTATE) - sinR2 * (Origin_Y - Motion.parameter.YROTATE) + Motion.parameter.XROTATE;
            double AfterRotation_Y2 = sinR2 * (Origin_X - Motion.parameter.XROTATE) + cosR2 * (Origin_Y - Motion.parameter.YROTATE) + Motion.parameter.YROTATE;


            Motion.UserPosMoveAbs(Compensation.Area.Align, AfterRotation_X2, AfterRotation_Y2);

            Thread.Sleep(2000);
            if (Vision.activeCamera == Camera.WaferLowMag)
            {
                CommonFunctions.Match(DeviceData.Entity.WaferAlignment.LowPattern1, Vision.WaferLowMag, out _, out _);
            }
            else if (Vision.activeCamera == Camera.WaferHighMag)
            {
                CommonFunctions.Match(DeviceData.Entity.WaferAlignment.HighPattern1, Vision.WaferHighMag, out _, out _);
            }
            //BtnMatchLow_Click_1(this, null);
            Thread.Sleep(2000);
            BtnGetPos2_Click(this, null);
            //Thread.Sleep(2000);
            BtnGetRotateCenter_Click(this, null);
        }
    }
}
