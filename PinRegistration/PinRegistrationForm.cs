using CommonComponentLibrary;
using MotionLibrary;
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
            //默认是低倍相机启动
            Vision.ChangeCamera(Vision.PinLowMag);
            BtnLowMag.Enabled = false; BtnHighMag.Enabled = true;
            //PinRegistration.LoadPins("pin.json");
        }

        private void BtnHighMag_Click(object sender, EventArgs e)
        {
            Vision.ChangeCamera(Vision.PinHighMag);
            Motion.TogglePosition(2);
            BtnLowMag.Enabled = true; BtnHighMag.Enabled = false;
        }
        private void BtnLowMag_Click(object sender, EventArgs e)
        {
            Vision.ChangeCamera(Vision.PinLowMag);
            Motion.TogglePosition(3);
            BtnLowMag.Enabled = false; BtnHighMag.Enabled = true;
        }
        private void BtnNeedleTipFocus_Click(object sender, EventArgs e)
        {
            WaitingControl wf = new();
            wf.Show();
            //if (Vision.activeMag == ActiveMag.PinLowMag)
            //{
            //    Alignment.AdjustWaferHeight(37000, 39000, Vision.PinLowMag);
            //}
            //else if (Vision.activeMag == ActiveMag.PinHighMag)
            //{
            //    Vision.PinHighMag.halconClass.m_Roi.Resize2(512, 640, 100, 100);
            //    Vision.PinHighMag.SetExposureTime(100);
            //    Thread.Sleep(500);//避免曝光没有生效
            //    double pinHeight = Motion.ZPROBECARDUPPERPLATEBASE - PinRegistration.Entity.NeddleTipFocusOffset;
            //    if (pinHeight > 100000) { MessageBox.Show("wrong pin height :" + pinHeight); return; }
            //    Alignment.AdjustWaferHeight(pinHeight - 1000, pinHeight + 1000, Vision.PinHighMag);
            //    Vision.PinHighMag.halconClass.m_Roi.Resize2(512, 640, 400, 400);
            //    Vision.PinHighMag.SetExposureTime(500);
            //}
            wf.Dispose();
        }
        private void BtnMovePinToTheCenter_Click(object sender, EventArgs e)
        {
            //PinRegistration.MoveToPin();
        }
        private void BtnGoToPin_Click(object sender, EventArgs e)
        {
            //Motion.XYZ_AxisMoveAbs(1, PinRegistration.Entity.RefPinX, PinRegistration.Entity.RefPinY, PinRegistration.Entity.RefPinZ, 600, 10, 10, 20);
            //int res = PinRegistration.FindPin(int.Parse(TxtIndex.Text), out double encodeX, out double encodeY);
            //if (res == 0)
            //{
            //    Motion.XYZ_AxisMoveAbs(1, encodeX, encodeY, PinRegistration.Entity.RefPinZ, 600, 10, 10, 20);
            //}
            //else
            //{
            //    //临时代码
            //    Motion.XYZ_AxisMoveAbs(1, Motion.XPROBER, Motion.YPROBER, Motion.ZPROBER, 600, 10, 10, 20);
            //}
        }
        private void BtnRefPinRegistration_Click(object sender, EventArgs e)
        {
            //Motion.XYZ_GetEncPos(out double encodeX, out double encodeY, out double encodeZ);
            ////当前RefPin的位置，是否需要保存呢？
            //PinRegistration.Entity.RefPinX = encodeX;
            //PinRegistration.Entity.RefPinY = encodeY;
            //PinRegistration.Entity.RefPinZ = encodeZ;
            ////当前REfPin与机台调参时候RefPin的差异
            //PinRegistration.PinOffsetX = PinRegistration.Entity.RefPinX - PinPadContact.Entity.XProber;
            //PinRegistration.PinOffsetY = PinRegistration.Entity.RefPinY - PinPadContact.Entity.YProber;
            //PinRegistration.PinOffsetZ = PinRegistration.Entity.RefPinZ - PinPadContact.Entity.ZProber;

            //LblPinOffsetX.Text = PinRegistration.PinOffsetX.ToString();
            //LblPinOffsetY.Text = PinRegistration.PinOffsetY.ToString();
            //LblPinOffsetZ.Text = PinRegistration.PinOffsetZ.ToString();
        }
        private void BtnReadyToApply_Click(object sender, EventArgs e)
        {
            ////暂时用作保存参数
            //SaveFileDialog sfd = new SaveFileDialog();
            //sfd.Filter = "json文件(*.json文件)|*.json|所有文件|*.*";
            //if (sfd.ShowDialog() == DialogResult.OK) //用户点击确认按钮，发送确认消息
            //{
            //    PinRegistration.SavePins(sfd.FileName);
            //}
        }
        private void BtnRefreshPinDataFromPadData_Click(object sender, EventArgs e)
        {
            //OpenFileDialog ofd = new OpenFileDialog();
            //ofd.Filter = "json文件(*.json文件)|*.json|所有文件|*.*";
            //if (ofd.ShowDialog() == DialogResult.OK) //用户点击确认按钮，发送确认消息
            //{
            //    PinRegistration.LoadPins(ofd.FileName);
            //}
        }
        private void BtnDeletePinWPad_Click(object sender, EventArgs e)
        {

        }
        private void BtnAddPinWPad_Click(object sender, EventArgs e)
        {
            //PinRegistration.AddPin();
        }

        #region 绘图
        private void PinRegistrationForm_ParentChanged(object sender, EventArgs e)
        {
            if (this.Parent != null)
            {
                panel1.Controls.Add(CommonPanel.Entity);
            }
            else
            {

            }
        }
        private void PaintPins()
        {
            Vision.PinLowMag.halconClass.PaintPins(PadEncodeX, PadEncodeY, 0);
        }
        double[]? PadEncodeX;
        double[]? PadEncodeY;
        private void TransformPads()
        {
            int PadCount = PadData.Entity.Pads.Count;
            PadEncodeX = new double[PadCount];
            PadEncodeY = new double[PadCount];
            //这一步比较费时，先转好
            for (int i = 0; i < PadCount; i++)
            {
                //粗定位画图，精度不要紧，主要为了变换坐标系，确保符号方向一致。TODO：用户坐标系方向用起来，则不用这步骤
                Compensation.Transform(Compensation.Area.Align, Compensation.Dir.User2Encode, PadData.Entity.Pads[i].PosX,
                    PadData.Entity.Pads[i].PosY, out double Xout, out double Yout);
                PadEncodeX[i] = Xout;
                PadEncodeY[i] = Yout;
            }
        }
        private void CBShowPins_CheckedChanged(object sender, EventArgs e)
        {
            if (CBShowPins.Checked)
            {
                TransformPads();
                Vision.PinLowMag.halconClass.OnPaintEvent += PaintPins;
            }
            else
            {
                Vision.PinLowMag.halconClass.OnPaintEvent -= PaintPins;
            }
        }
        #endregion
    }
}
