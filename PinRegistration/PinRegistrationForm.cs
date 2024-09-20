using CommonComponentLibrary;
using JsonDataShow;
using MotionLibrary;
using VisionLibrary;
using WaferMapLibrary;

namespace PinRegistration
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
            NumRefPinOffsetR.Maximum = 100000;
            NumRefPinOffsetR.Minimum = -100000;
            groupBox1.Controls.Add(new PinSearchControl());
            panelMag.Controls.Add(new PinMagControl());
            panelPinMap.Controls.Add(new PinCanvas());
        }
        private void UpdateUI()
        {
            NumRefPinOffsetR.Value = decimal.Parse(PinData.Entity.PinsAngle.ToString());
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
                AdjustHeight.PinFocus(true);
                WaitingControl.WF.End();
            }
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

                PinData.Save(DeviceData.Entity.PinAlignment.PinDataPath);
                UpdateUI();
            }
        }
        private void BtnReadyToApply_Click(object sender, EventArgs e)
        {
            UpdateProbePosition();//更新Probe参数
            PinData.IsPinAlignCompleted = true;
            MessageBox.Show("Pin Alignment Compeleted!");
        }
        /// <summary>
        /// 更新所有Probe所需要的参数
        /// </summary>
        public void UpdateProbePosition()
        {
            double waferOffset = WaferMap.WaferHeight - Motion.parameter.PROBING.ZOrgWaferHeight;//wafer比注册高了waferOffset
            double pinOffset = PinData.Entity.RefPinZ - Motion.parameter.PROBING.ZOrgPin;//pin比注册高了pinOffset
            double orgZUp = Motion.parameter.PROBING.ZOrgWaferHeight + Motion.parameter.PROBING.ZPad2Pin;//注册时候upPos

            DeviceData.Entity.Probing.ZUpPosition = orgZUp - waferOffset + pinOffset;//当前的upPos理论值
            DeviceData.Entity.Probing.ZDownPosition = DeviceData.Entity.Probing.ZUpPosition + DeviceData.Entity.Probing.ZClearance;
        }
        private void BtnRefreshPinDataFromPadData_Click(object sender, EventArgs e)
        {
            PinData.Entity.Pins.Clear();
            PinData.Entity.PinsAngle = 0;
            // 获取相关实体数据的引用以减少重复访问
            var duts = DUTData.Entity.DUTs;
            var pads = PadData.Entity.Pads;
            var dieSizeX = WaferMap.Entity.DieSizeX;
            var dieSizeY = WaferMap.Entity.DieSizeY;

            // 遍历 DUT 和 Pad 并更新 PinData
            foreach (var dut in duts)
            {
                foreach (var pad in pads)
                {
                    // 计算每个 Pin 的位置
                    double x = -pad.PosX + dut.X * dieSizeX;
                    double y = -pad.PosY - dut.Y * dieSizeY;

                    // 计算该DUT的index
                    int index = duts.IndexOf(dut);
                    // 添加计算后的 Pin 到 Pins 列表中
                    PinData.Entity.Pins.Add(new Pin { PosX = x, PosY = y, DUTindex = index });
                }
            }

            PinData.Save(DeviceData.Entity.PinAlignment.PinDataPath);
            MessageBox.Show("All Pins are refreshed from pad data!");
            UpdateUI();
        }
        private void BtnDeletePinWPad_Click(object sender, EventArgs e)
        {

        }
        private void BtnAddPinWPad_Click(object sender, EventArgs e)
        {
            ////获得当前XY坐标
            //Motion.GetUserPos(Compensation.Area.Probing, out double X, out double Y);
            //Compensation.Transform(Compensation.Area.Probing, Compensation.Dir.Encode2User,
            //    PinData.Entity.RefPinX, PinData.Entity.RefPinY, out double RefX, out double RefY);
            //double posX = X - RefX;//以refpin为原点的坐标
            //double posY = Y - RefY;//以refpin为原点的坐标

            //PinData.Entity.Pins.Add(new Pin { PosX = -posX, PosY = -posY });//标定用的坐标系，和探针卡方向相反
            //PinData.CurrentIndex = PinData.Entity.Pins.Count - 1;
            //PinData.Save(DeviceData.Entity.PinAlignment.PinDataPath);
            //UpdateUI();
        }
        private void BtnUpdatePinWPad_Click(object sender, EventArgs e)
        {
            //获得当前XY坐标
            Motion.GetUserPos(Compensation.Area.Probing, out double X, out double Y);
            Compensation.Transform(Compensation.Area.Probing, Compensation.Dir.Encode2User,
                PinData.Entity.RefPinX, PinData.Entity.RefPinY, out double RefX, out double RefY);
            double posX = X - RefX;//以refpin为原点的坐标
            double posY = Y - RefY;//以refpin为原点的坐标

            PinData.Entity.Pins[PinData.CurrentIndex].PosX = -posX;//标定用的坐标系，和探针卡方向相反
            PinData.Entity.Pins[PinData.CurrentIndex].PosY = -posY;//标定用的坐标系，和探针卡方向相反
            PinData.Entity.Pins[PinData.CurrentIndex].PosZ = Motion.EncodeZ;
            PinData.Save(DeviceData.Entity.PinAlignment.PinDataPath);
            UpdateUI();
        }

        #region 绘图
        private void PinRegistrationForm_ParentChanged(object sender, EventArgs e)
        {
            if (Parent != null)
            {
                panel1.Controls.Clear();
                panel1.Controls.Add(CommonPanel.Entity);
                //默认是低倍相机启动
                //Vision.ChangeCamera(Vision.PinLowMag);//默认粗定位
                UpdateUI();
            }
            else
            {

            }
        }
        /// <summary>
        /// 将转换后的坐标丢进去显示
        /// </summary>
        private void PaintPins()
        {
            // Prepare data before painting
            PinAlignLib.RotateAroundRefPin(out double[] encodeX, out double[] encodeY);
            // Use the prepared data for painting
            Vision.PinLowMag.halconClass.PaintPins(encodeX, encodeY, PinData.CurrentIndex);
        }
        private void CBShowPins_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = CBShowPins.Checked;
            // 根据勾选状态注册或取消注册事件，并设置显示状态
            Vision.PinLowMag.halconClass.OnPaintEvent -= PaintPins;
            if (isChecked)
            {
                Vision.PinLowMag.halconClass.OnPaintEvent += PaintPins;
            }
            Vision.PinLowMag.halconClass.bDisplayROI = isChecked;
            Vision.PinLowMag.halconClass.bDisplayCross = isChecked;
        }
        #endregion

        private void BtnUpdateDegree_Click(object sender, EventArgs e)
        {
            PinData.Entity.PinsAngle = double.Parse(NumRefPinOffsetR.Value.ToString());
            PinData.Save(DeviceData.Entity.PinAlignment.PinDataPath);//写入文件
        }
        private void PinRegistrationForm_VisibleChanged(object sender, EventArgs e)
        {

        }
        private void BtnOrgPinInitial_Click(object sender, EventArgs e)
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
                //将orgpin也定义一下
                Motion.parameter.PROBING.XOrgPin = encodeX;
                Motion.parameter.PROBING.YOrgPin = encodeY;
                Motion.parameter.PROBING.ZOrgPin = encodeZ;
                Motion.parameter.PROBING.ZOrgWaferHeight = WaferMap.WaferHeight;
                PinData.Save(DeviceData.Entity.PinAlignment.PinDataPath);
                UpdateUI();
            }
        }
        private void BtnPinData_Click(object sender, EventArgs e)
        {
            JsonDataForm form = new JsonDataForm(DeviceData.Entity.PinAlignment.PinDataPath, PinData.Entity);
            DialogResult res = form.ShowDialog();
        }


        private void BtnAdjustAngle_Click(object sender, EventArgs e)
        {
            PinAlignLib.AdjustAngle(1, out double deltaAngle);
            Console.WriteLine(deltaAngle.ToString());
        }
        private void BtnM_Pin_Click(object sender, EventArgs e)
        {
            PinDataForm form = new();
            DialogResult res = form.ShowDialog();
        }

        private void BtnVisionPara_Click(object sender, EventArgs e)
        {
            VisionParaControl visionPara = new VisionParaControl();
            visionPara.Location = new Point(1150, 200);
            this.Controls.Add(visionPara);
            visionPara.BringToFront();
        }

        private async void BtnAutoFocusAll_Click(object sender, EventArgs e)
        {
            if (Vision.activeCamera != Camera.PinHighMag)
            {
                MessageBox.Show("Change to High Mag!"); return;
            }

            PinData.ClearCurrentPos(); 
            WaitingControl.WF.Start();
            for (int i = 0; i < PinData.Entity.Pins.Count; i++)
            {
                await Task.Run(() => PinAlignLib.GoToPin(i));
                var result = await Task.Run(() => PinAlignLib.MovePinToCenter());
                if (result != 0) continue;
                result = await Task.Run(() => AdjustHeight.PinFocus(false));
                if (result != 0) continue;
                Motion.XYZ_GetEncPos(out double x, out double y, out double z);
                PinData.Entity.Pins[i].CurrentPosX = x - PinData.Entity.RefPinX;
                PinData.Entity.Pins[i].CurrentPosY = y - PinData.Entity.RefPinY;
                PinData.Entity.Pins[i].CurrentPosZ = z - PinData.Entity.RefPinZ;
            }
            WaitingControl.WF.End();
            PinData.Save(DeviceData.Entity.PinAlignment.PinDataPath);
        }
    }
}
