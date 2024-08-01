using CommonComponentLibrary;
using MotionLibrary;
using VisionLibrary;
using WaferMapLibrary;
using static GTN.mc;

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
            TxtX1.Text = Motion.EncodeX.ToString();
            TxtY1.Text = Motion.EncodeY.ToString();
        }

        private void BtnGetPos2_Click(object sender, EventArgs? e)
        {
            TxtX2.Text = Motion.EncodeX.ToString();
            TxtY2.Text = Motion.EncodeY.ToString();
        }

        private void BtnRNeg_Click(object sender, EventArgs e)
        {
            Motion.AxisMoveRel(1, 4, -double.Parse(TxtPulse.Text), 600, 10, 10, 20);
        }

        private void BtnRPlus_Click(object sender, EventArgs e)
        {
            Motion.AxisMoveRel(1, 4, double.Parse(TxtPulse.Text), 600, 10, 10, 20);
        }

        //作为临时性的shm模板
        public string PattenModel1 = "tempSHM";
        public double OrgX = 0;
        public double OrgY = 0;
        public double OrgZ = 0;
        public double OrgR = 0;
        private async void BtnRepeatRotate_Click(object sender, EventArgs e)
        {
            RegPattern();

            int times = int.Parse(TxtTimes.Text);
            double pulse = double.Parse(TxtPulse.Text);

            Vision.WaferHighMag.TriggerMode();
            WaitingControl.WF.Start();
            for (int i = 0; i < times; i++)
            {
                await Task.Run(() =>
                {
                    Motion.AxisMoveRel(1, 4, pulse, 600, 10, 10, 20);
                });

                double DeltaX = 0;
                double DeltaY = 0;
                //var res = await Task.Run<int>(() =>
                //{
                //    return 
                //});
                int res = CommonFunctions.Match_Without_Move(PattenModel1, Vision.WaferHighMag, out DeltaX, out DeltaY, out _, out _);
                if (res != 0)
                {
                    WaitingControl.WF.End();
                    Vision.WaferHighMag.ContinuesMode();
                    return;
                }
                Motion.XY_AxisMoveRel(1, DeltaX, DeltaY, 600, 10, 10, 20);
                Vision.WaferHighMag.TriggerExec();

                progressBar1.Value = (i + 1) * 100 / times;
            }
            progressBar1.Value = 100;
            WaitingControl.WF.End();
            Vision.WaferHighMag.ContinuesMode();
        }

        private void BtnRegPattern_Click(object sender, EventArgs e)
        {
            RegPattern();
        }

        private void RegPattern()
        {
            Vision.WaferHighMag.halconClass.CreateShapeModel(PattenModel1);
            OrgX = Motion.EncodeX;
            OrgY = Motion.EncodeY;
            OrgZ = Motion.EncodeZ;
            OrgR = Motion.EncodeR;

            labelX.Text = OrgX.ToString("F0");
            labelY.Text = OrgY.ToString("F0");
            labelR.Text = OrgR.ToString("F0");
        }

        private void BtnMatch_Click(object sender, EventArgs e)
        {
            if (Vision.activeCamera == Camera.WaferLowMag)
            {
                //CommonFunctions.Match_With_Move(DeviceData.Entity.WaferAlignment.LowPattern1, Vision.WaferLowMag, out _, out _);
                return;
            }
            else if (Vision.activeCamera == Camera.WaferHighMag)
            {
                CommonFunctions.Match_With_Move(PattenModel1, Vision.WaferHighMag, out _, out _);
            }
        }

        private void BtnResetPostion_Click(object sender, EventArgs e)
        {
            Motion.XYZ_AxisMoveAbs(1, OrgX, OrgY, OrgZ, 600, 10, 10, 20);
            Motion.AxisMoveAbs(1, 4, OrgR, 600, 10, 10, 20);            
        }
    }
}
