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
            NumRefPinOffsetR.Maximum = 50000;
            NumRefPinOffsetR.Minimum = -50000;


            //PinRegistration.LoadPins("pin.json");
        }
        private void UpdateUI()
        {
            if (Vision.activeCamera == Camera.PinLowMag)
            {
                BtnLowMag.Enabled = false;
                BtnHighMag.Enabled = true;
            }
            else if (Vision.activeCamera == Camera.PinHighMag)
            {
                BtnLowMag.Enabled = true;
                BtnHighMag.Enabled = false;
            }
            else
            {
                BtnLowMag.Enabled = true;
                BtnHighMag.Enabled = true;
            }

            //LblPinOffsetX.Text = PinData.RefPinOffsetX.ToString();
            //LblPinOffsetY.Text = PinData.RefPinOffsetY.ToString();
            //LblPinOffsetZ.Text = PinData.RefPinOffsetZ.ToString();

            TxtIndex.Text = PinData.CurrentIndex.ToString();
            TxtTotal.Text = PinData.Entity.Pins.Count.ToString();
        }
        private void BtnHighMag_Click(object sender, EventArgs e)
        {
            WaitingControl.WF.Start();
            Vision.ChangeCamera(Vision.PinHighMag);
            Motion.TogglePosition(2);
            WaitingControl.WF.End();
            UpdateUI();
        }
        private void BtnLowMag_Click(object sender, EventArgs e)
        {
            WaitingControl.WF.Start();
            Vision.ChangeCamera(Vision.PinLowMag);
            Motion.TogglePosition(3);
            WaitingControl.WF.End();
            UpdateUI();
        }
        private void BtnFocusInitial_Click(object sender, EventArgs e)
        {
            if (Vision.activeCamera == Camera.PinLowMag)
            {
                //CommonFunctions.AdjustHeight(37000, 39000, Vision.PinLowMag);
                MessageBox.Show("Change to High Mag!"); return;
            }
            else if (Vision.activeCamera == Camera.PinHighMag)
            {
                WaitingControl.WF.Start();
                CommonFunctions.AdjustPinHeight(true);
                WaitingControl.WF.End();
            }
        }
        private void BtnNeedleTipFocus_Click(object sender, EventArgs e)
        {
            if (Vision.activeCamera == Camera.PinLowMag)
            {
                //CommonFunctions.AdjustHeight(37000, 39000, Vision.PinLowMag);
                MessageBox.Show("Change to High Mag!"); return;
            }
            else if (Vision.activeCamera == Camera.PinHighMag)
            {
                WaitingControl.WF.Start();
                CommonFunctions.AdjustPinHeight(false);
                WaitingControl.WF.End();
            }
        }
        private void BtnMovePinToTheCenter_Click(object sender, EventArgs e)
        {
            CommonFunctions.MovePinToCenter();
            UpdateUI();
        }
        private void BtnGoToPin_Click(object sender, EventArgs e)
        {
            bool islowMode = (Vision.activeCamera == Camera.PinLowMag);
            CommonFunctions.GoToPin(int.Parse(TxtIndex.Text));
            UpdateUI();
        }
        private void BtnRefPinRegistration_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Reference pin will be located and all the other pins will follow the ref.",
                "Ref Pin Registration", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (res == DialogResult.OK)
            {
                Motion.XYZ_GetEncPos(out double encodeX, out double encodeY, out double encodeZ);
                //当前RefPin的位置，是否需要保存呢？
                PinData.Entity.RefPinX = encodeX;
                PinData.Entity.RefPinY = encodeY;
                PinData.Entity.RefPinZ = encodeZ;
                //当前REfPin与机台调参时候RefPin的差异
                //PinData.RefPinOffsetX = PinData.Entity.RefPinX - Motion.parameter.PROBING.XOrgPin;
                //PinData.RefPinOffsetY = PinData.Entity.RefPinY - Motion.parameter.PROBING.YOrgPin;
                //PinData.RefPinOffsetZ = PinData.Entity.RefPinZ - Motion.parameter.PROBING.ZOrgPin;
                UpdateUI();
            }
        }
        private void BtnReadyToApply_Click(object sender, EventArgs e)
        {
            PinData.Save(DeviceData.Entity.PinAlignment.PinDataPath);
            UpdateProbePosition();//更新Probe参数
            PinData.IsPinAlignCompleted = true;
            MessageBox.Show("Pins Saved!");
        }
        public void UpdateProbePosition()
        {
            double waferOffset = WaferMap.WaferHeight - Motion.parameter.PROBING.ZOrgWaferHeight;//wafer比注册高了waferOffset
            double pinOffset = PinData.Entity.RefPinZ - Motion.parameter.PROBING.ZOrgPin;//pin比注册高了pinOffset
            double upPos = Motion.parameter.PROBING.ZOrgWaferHeight + Motion.parameter.PROBING.ZPad2Pin;//注册时候upPos

            DeviceData.Entity.Probing.ZUpPosition = upPos - waferOffset + pinOffset;//当前的upPos理论值
            DeviceData.Entity.Probing.ZDownPosition = DeviceData.Entity.Probing.ZUpPosition + DeviceData.Entity.Probing.ZClearance;
        }
        private void BtnRefreshPinDataFromPadData_Click(object sender, EventArgs e)
        {
            PinData.Entity.Pins.Clear();
            foreach (var pad in PadData.Entity.Pads)
            {
                PinData.Entity.Pins.Add(new Pin { PosX = pad.PosX, PosY = pad.PosY });
            }
            UpdateUI();
        }
        private void BtnDeletePinWPad_Click(object sender, EventArgs e)
        {

        }
        private void BtnAddPinWPad_Click(object sender, EventArgs e)
        {
            //获得当前XY坐标
            Motion.GetUserPos(Compensation.Area.Probing, out double X, out double Y);
            Compensation.Transform(Compensation.Area.Probing, Compensation.Dir.Encode2User,
                PinData.Entity.RefPinX, PinData.Entity.RefPinY, out double RefX, out double RefY);
            double posX = X - RefX;//以refpin为原点的坐标
            double posY = Y - RefY;//以refpin为原点的坐标

            PinData.Entity.Pins.Add(new Pin { PosX = posX, PosY = posY });
            PinData.CurrentIndex = PinData.Entity.Pins.Count - 1;
            UpdateUI();
        }
        private void BtnGoToRefPin_Click(object sender, EventArgs e)
        {
            bool islowMode = (Vision.activeCamera == Camera.PinLowMag);
            CommonFunctions.GoToPin(0, islowMode);
            UpdateUI();
        }
        private void BtnUpdatePinWPad_Click(object sender, EventArgs e)
        {
            //获得当前XY坐标
            Motion.GetUserPos(Compensation.Area.Probing, out double X, out double Y);
            Compensation.Transform(Compensation.Area.Probing, Compensation.Dir.Encode2User,
                PinData.Entity.RefPinX, PinData.Entity.RefPinY, out double RefX, out double RefY);
            double posX = X - RefX;//以refpin为原点的坐标
            double posY = Y - RefY;//以refpin为原点的坐标

            PinData.Entity.Pins[PinData.CurrentIndex].PosX = posX;
            PinData.Entity.Pins[PinData.CurrentIndex].PosY = posY;
            UpdateUI();
        }
        #region 绘图
        private void PinRegistrationForm_ParentChanged(object sender, EventArgs e)
        {

        }
        private void PaintPins()
        {
            Vision.PinLowMag.halconClass.PaintPins(PinEncodeX, PinEncodeY, 0, PinData.Entity.PinsAngle);
        }
        double[]? PinEncodeX;
        double[]? PinEncodeY;
        private void TransformPins()
        {
            int PinCount = PinData.Entity.Pins.Count;
            PinEncodeX = new double[PinCount];
            PinEncodeY = new double[PinCount];
            //这一步比较费时，先转好
            for (int i = 0; i < PinCount; i++)
            {
                //粗定位画图，精度不要紧，主要为了变换坐标系，确保符号方向一致。标定过程是用的encode坐标，所以画图最好也用encode坐标
                Compensation.Transform(Compensation.Area.Align, Compensation.Dir.User2Encode, PinData.Entity.Pins[i].PosX,
                    PinData.Entity.Pins[i].PosY, out double Xout, out double Yout);
                PinEncodeX[i] = Xout;
                PinEncodeY[i] = Yout;
            }
        }
        private void CBShowPins_CheckedChanged(object sender, EventArgs e)
        {
            if (CBShowPins.Checked)
            {
                TransformPins();
                Vision.PinLowMag.halconClass.OnPaintEvent += PaintPins;
            }
            else
            {
                Vision.PinLowMag.halconClass.OnPaintEvent -= PaintPins;
            }
        }
        #endregion
        private void BtnUpdateDegree_Click(object sender, EventArgs e)
        {
            PinData.Entity.PinsAngle = double.Parse(NumRefPinOffsetR.Text);
        }
        private void PinRegistrationForm_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                panel1.Controls.Add(CommonPanel.Entity);
                //默认是低倍相机启动
                Vision.ChangeCamera(Vision.PinLowMag);//默认粗定位
                UpdateUI();
            }
            else
            {

            }
        }
        private void BtnGoToNextPin_Click(object sender, EventArgs e)
        {

        }
        private void BtnGoToPrevPin_Click(object sender, EventArgs e)
        {

        }
    }
}
