using CommonComponentLibrary;
using MotionLibrary;
using VisionLibrary;
using WaferMapLibrary;

namespace MainForm
{
    public partial class LowModel : UserControl
    {
        //作为临时性的shm模板
        public string PattenModel1 = "tempSHM";
        //LowMag下，参考Die（Origin DIE）的轴坐标
        public double RefDieX = 0;
        public double RefDieY = 0;
        //LowMag下，参考Die（Origin DIE）LowerLeftCorner的轴坐标
        public double LowerLeftCornerX = 0;
        public double LowerLeftCornerY = 0;
        public LowModel()
        {
            InitializeComponent();
            panelIndex.Controls.Add(new WaferMapIndexControl());
        }
        private void BtnIstantLowAlign_Click(object sender, EventArgs e)
        {
            if (Vision.activeCamera != Camera.WaferLowMag)
            {
                MessageBox.Show("Please Change Camera to Low Mag,");
                return;
            }
            Vision.WaferLowMag.halconClass.CreateShapeModel(PattenModel1);
            //做模板完了后加延时,TODO 增加校验步骤，延时不太可靠
            Thread.Sleep(500);
            int L = int.Parse(txtL.Text);
            int R = int.Parse(txtR.Text);

            int res = Alignment.AlignX(Vision.WaferLowMag, PattenModel1, L, R, WaferMap.Entity.DieSizeX);
            if (res != 0) MessageBox.Show(res.ToString());
        }

        private void BtnTeachLowerLeftCorner_Click(object sender, EventArgs e)
        {
            Motion.XY_GetEncPos(out LowerLeftCornerX, out LowerLeftCornerY);
        }

        private void BtnMatchIndex_Click(object sender, EventArgs e)
        {
            //临时测试代码
            //Alignment.Match(DeviceData.Entity.WaferAlignment.LowPattern, Vision.WaferLowMag, out double X, out double Y);
        }

        private void BtnAlignConfirm_Click(object sender, EventArgs e)
        {
            WaferMap.IsLowAlignCompleted = true;
            MessageBox.Show("Low Alignment Successful.");
        }

        private void BtnSetRefDie_Click(object sender, EventArgs e)
        {
            Motion.XY_GetEncPos(out RefDieX, out RefDieY);
        }

        private void BtnPat1Reg_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "shm文件(*.shm文件)|*.shm|所有文件|*.*";
            if (sfd.ShowDialog() == DialogResult.OK) //用户点击确认按钮，发送确认消息
            {
                Vision.WaferLowMag.halconClass.CreateShapeModel(sfd.FileName);
            }
        }

        private void BtnMoveToRefDie_Click(object sender, EventArgs e)
        {
            if (RefDieX == 0 && RefDieY == 0) return;
            Motion.XY_AxisMoveAbs(1, RefDieX, RefDieY,600,20,20,10);
        }

        private void BtnMatch_Click(object sender, EventArgs e)
        {
            Alignment.Match(DeviceData.Entity.WaferAlignment.LowPattern, Vision.WaferLowMag, out _, out _);
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            Compensation.Transform(Compensation.Area.Align, Compensation.Dir.Encode2User,
                WaferMap.WaferCenterX, WaferMap.WaferCenterY, out double centerX, out double centerY);//WaferCenter是粗略坐标
            Compensation.Transform(Compensation.Area.Align, Compensation.Dir.Encode2User,
                LowerLeftCornerX, LowerLeftCornerY, out double llcX, out double llcY);//LowerLeftCorner是粗略坐标
            Compensation.Transform(Compensation.Area.Align, Compensation.Dir.Encode2User,
                RefDieX, RefDieY, out double rdX, out double rdY);//RefDie是粗略坐标

            double cornerX = llcX - centerX;//LowerLeftCorner是粗略坐标
            double cornerY = llcY - centerY;//LowerLeftCorner是粗略坐标
            double c2pX = rdX - llcX;//LowerLeftCorner是粗略坐标
            double c2pY = rdY - llcY;//LowerLeftCorner是粗略坐标

            string str = "Center2OriginDieCornerX: " + WaferMap.Entity.Center2OriginDieCornerX.ToString() + " → " + cornerX.ToString() + "\r\n";
            str += "Center2OriginDieCornerY: " + WaferMap.Entity.Center2OriginDieCornerY.ToString() + " → " + cornerY.ToString() + "\r\n";
            str += "Corner2PatternX: " + WaferMap.Entity.Corner2PatternX.ToString() + " → " + c2pX.ToString() + "\r\n";
            str += "Corner2PatternY: " + WaferMap.Entity.Corner2PatternY.ToString() + " → " + c2pY.ToString();
            //如果要测准，则用精定位去定位LowerLeftCorner与RefDie
            DialogResult res = MessageBox.Show(str, "Caution", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (res == DialogResult.OK)
            {
                WaferMap.Entity.Center2OriginDieCornerX = cornerX;
                WaferMap.Entity.Center2OriginDieCornerY = cornerY;
                WaferMap.Entity.Corner2PatternX = c2pX;
                WaferMap.Entity.Corner2PatternY = c2pY;
            }
        }
    }
}
