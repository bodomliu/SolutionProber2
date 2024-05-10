using CommonComponentLibrary;
using VisionLibrary;
using MotionLibrary;
using WaferMapLibrary;
namespace MainForm
{
    public partial class HighModel : UserControl
    {
        //作为临时性的shm模板
        public string PattenModel1 = "tempSHM";
        //用来存临时变量
        private double HighMagOrgX = double.NaN;
        private double HighMagOrgY = double.NaN;
        public HighModel()
        {
            InitializeComponent();
            panel1.Controls.Add(new WaferMapIndexControl());
        }

        private void BtnIstantHighAlign_Click(object sender, EventArgs e)
        {
            Vision.WaferHighMag.halconClass.CreateShapeModel(PattenModel1);
            //做模板完了后加延时 TODO 增加校验处理
            //Thread.Sleep(500);

            int L = int.Parse(txtL.Text);
            int R = int.Parse(txtR.Text);

            CommonFunctions.AlignX(Vision.WaferHighMag, PattenModel1, L, R, WaferMap.Entity.DieSizeX,out _);
        }

        private void BtnMoveToRefDie_Click(object sender, EventArgs e)
        {
            //因为没有做好精定位，确定waferoffset，所以只能是粗定位下的运动到refdie，再加一个toggle
            Compensation.Transform(Compensation.Area.Align, Compensation.Dir.User2Encode,
                WaferMap.WaferCenterX + WaferMap.Entity.Center2RefDieCornerX + WaferMap.Entity.Corner2OrgX,
                WaferMap.WaferCenterY + WaferMap.Entity.Center2RefDieCornerY + WaferMap.Entity.Corner2OrgY,
                out double encodeX, out double encodeY);
            Motion.XY_AxisMoveAbs(1, encodeX + Motion.parameter.XWAFERLOW2HIGHT, encodeY + Motion.parameter.YWAFERLOW2HIGHT, 600, 20, 20, 10);
            WaferMap.CurrentIndexX = WaferMap.Entity.RefDieX;
            WaferMap.CurrentIndexY = WaferMap.Entity.RefDieY;
        }

        private void BtnAlignConfirm_Click(object sender, EventArgs e)
        {
            //将refdie对整齐后,确定当前wafer与注册理想wafer差异的动作
            Motion.GetUserPos(Compensation.Area.Align, out HighMagOrgX, out HighMagOrgY);
            //理想条件下WaferMap的center = (0，0)
            double OrgX = 0 + WaferMap.Entity.Center2RefDieCornerX + WaferMap.Entity.Corner2OrgX;
            double OrgY = 0 + WaferMap.Entity.Center2RefDieCornerY + WaferMap.Entity.Corner2OrgY;
            WaferMap.WaferOffsetX = HighMagOrgX - OrgX;
            WaferMap.WaferOffsetY = HighMagOrgY - OrgY;

            WaferMap.IsHighAlignCompleted = true;
            MessageBox.Show("High Alignment Successful.");
        }

        private void BtnPat1Reg_Click(object sender, EventArgs e)
        {
            Vision.WaferHighMag.halconClass.CreateShapeModel(DeviceData.Entity.WaferAlignment.HighPattern1);
        }

        private void BtnLowMagAlign_Click(object sender, EventArgs e)
        {

        }

        private void BtnMatch1_Click(object sender, EventArgs e)
        {
            CommonFunctions.Match(DeviceData.Entity.WaferAlignment.HighPattern1, Vision.WaferHighMag, out _, out _);
        }

        private void BtnMatch2_Click(object sender, EventArgs e)
        {
            CommonFunctions.Match(DeviceData.Entity.WaferAlignment.HighPattern2, Vision.WaferHighMag, out _, out _);
        }

        private void BtnPat2Reg_Click(object sender, EventArgs e)
        {
            if (HighMagOrgX == double.NaN) { MessageBox.Show("Comfirm Ref Die Org first!"); return; }
            Motion.GetUserPos(Compensation.Area.Align, out double Pattern2X, out double Pattern2Y);

            double org2part2X = Pattern2X - HighMagOrgX;//精定位坐标
            double org2part2Y = Pattern2Y - HighMagOrgY;//精定位坐标

            string str = "Org2PatII X: " + WaferMap.Entity.Org2PatIIX.ToString() + " → " + org2part2X.ToString() + "\r\n";
            str += "Org2PatII Y: " + WaferMap.Entity.Org2PatIIY.ToString() + " → " + org2part2Y.ToString();
            //如果要测准，则用精定位去定位LowerLeftCorner与RefDie
            DialogResult res = MessageBox.Show(str, "Caution", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (res == DialogResult.OK)
            {
                WaferMap.Entity.Org2PatIIX = org2part2X;
                WaferMap.Entity.Org2PatIIY = org2part2Y;
                Vision.WaferHighMag.halconClass.CreateShapeModel(DeviceData.Entity.WaferAlignment.HighPattern2);
            }
        }
    }
}
