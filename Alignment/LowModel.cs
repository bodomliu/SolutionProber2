using CommonComponentLibrary;
using MainForm;
using VisionLibrary;
using WaferMapLibrary;

namespace MainForm
{
    public partial class LowModel : UserControl
    {
        //作为临时性的shm模板
        public string PattenModel1 = "tempSHM";

        public LowModel()
        {
            InitializeComponent();
            panelIndex.Controls.Add(new WaferMapIndexControl());
        }
        private void BtnIstantLowAlign_Click(object sender, EventArgs e)
        {
            Vision.WaferLowMag.halconClass.CreateShapeModel(PattenModel1);
            //做模板完了后加延时,TODO 增加校验步骤，延时不太可靠
            //Thread.Sleep(500);
            int L = int.Parse(txtL.Text);
            int R = int.Parse(txtR.Text);

            int res = Alignment.AlignX(Vision.WaferLowMag, PattenModel1, L, R, WaferMap.Entity.DieSizeX);
            if (res != 0) MessageBox.Show(res.ToString());
        }

        private void BtnTeachLowerLeftCorner_Click(object sender, EventArgs e)
        {
            //LowMag下，参考Die（Origin DIE）LowerLeftCorner的轴坐标
            Motion.GetUserPos(Compensation.Area.Align, out double LowerLeftCornerX, out double LowerLeftCornerY);
            double cornerX = LowerLeftCornerX - WaferMap.WaferCenterX;//LowerLeftCorner是粗略坐标
            double cornerY = LowerLeftCornerY - WaferMap.WaferCenterY;//LowerLeftCorner是粗略坐标
            string str = "Center2RefDieCornerX: " + WaferMap.Entity.Center2RefDieCornerX.ToString() + " → " + cornerX.ToString() + "\r\n";
            str += "Center2RefDieCornerY: " + WaferMap.Entity.Center2RefDieCornerY.ToString() + " → " + cornerY.ToString() + "\r\n";
            //如果要测准，则用精定位去定位LowerLeftCorner与RefDie
            DialogResult res = MessageBox.Show(str, "Caution", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (res == DialogResult.OK)
            {
                WaferMap.Entity.Center2RefDieCornerX = cornerX;
                WaferMap.Entity.Center2RefDieCornerY = cornerY;
            }
        }

        private void BtnMatchIndex_Click(object sender, EventArgs e)
        {
            CommonPanel.IndexX = WaferMap.CurrentIndexX;
            CommonPanel.IndexY = WaferMap.CurrentIndexY;
        }

        private void BtnAlignConfirm_Click(object sender, EventArgs e)
        {
            WaferMap.IsLowAlignCompleted = true;
            MessageBox.Show("Low Alignment Successful.");
        }

        private void BtnSetRefDie_Click(object sender, EventArgs e)
        {
            //将按当前index赋值给RefDie，也就是需要先Match完index
            WaferMap.Entity.RefDieX = WaferMap.CurrentIndexX;
            WaferMap.Entity.RefDieY = WaferMap.CurrentIndexY;
        }

        private void BtnPat1Reg_Click(object sender, EventArgs e)
        {
            Motion.GetUserPos(Compensation.Area.Align, out double DieOrgX, out double DieOrgY);

            double corner2orgX = DieOrgX - (WaferMap.WaferCenterX + WaferMap.Entity.Center2RefDieCornerX);//LowerLeftCorner是粗略坐标
            double corner2orgY = DieOrgY - (WaferMap.WaferCenterY + WaferMap.Entity.Center2RefDieCornerY);//LowerLeftCorner是粗略坐标

            string str = "Corner2OrgX: " + WaferMap.Entity.Corner2OrgX.ToString() + " → " + corner2orgX.ToString() + "\r\n";
            str += "Corner2OrgY: " + WaferMap.Entity.Corner2OrgY.ToString() + " → " + corner2orgY.ToString();
            //如果要测准，则用精定位去定位LowerLeftCorner与RefDie
            DialogResult res = MessageBox.Show(str, "Caution", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (res == DialogResult.OK)
            {
                WaferMap.Entity.Corner2OrgX = corner2orgX;
                WaferMap.Entity.Corner2OrgY = corner2orgY;
                Vision.WaferLowMag.halconClass.CreateShapeModel(DeviceData.Entity.WaferAlignment.LowPattern1);
            }
        }
        private void BtnMoveToRefDie_Click(object sender, EventArgs e)
        {
            Motion.UserPosMoveAbs(Compensation.Area.Align, WaferMap.WaferCenterX + WaferMap.Entity.Center2RefDieCornerX + WaferMap.Entity.Corner2OrgX,
                WaferMap.WaferCenterY + WaferMap.Entity.Center2RefDieCornerY + WaferMap.Entity.Corner2OrgY);
            WaferMap.CurrentIndexX = WaferMap.Entity.RefDieX;
            WaferMap.CurrentIndexY = WaferMap.Entity.RefDieY;
        }

        private void BtnPat2Reg_Click(object sender, EventArgs e)
        {
            Vision.WaferLowMag.halconClass.CreateShapeModel(DeviceData.Entity.WaferAlignment.LowPattern2);
        }

        private void BtnMatch1_Click(object sender, EventArgs e)
        {
            CommonFunctions.Match(DeviceData.Entity.WaferAlignment.LowPattern1, Vision.WaferLowMag, out _, out _);
        }

        private void BtnMatch2_Click(object sender, EventArgs e)
        {
            CommonFunctions.Match(DeviceData.Entity.WaferAlignment.LowPattern2, Vision.WaferLowMag, out _, out _);
        }
    }
}
