﻿using CommonComponentLibrary;
using MotionLibrary;
using VisionLibrary;
using WaferMapLibrary;

namespace MainForm
{
    public partial class AlignmentForm : Form
    {
        LowModel lowModel = new LowModel();
        HighModel highModel = new HighModel();
        public AlignmentForm()
        {
            this.TopLevel = false; this.FormBorderStyle = FormBorderStyle.None;

            InitializeComponent();

            //low model
            panelModel.Controls.Add(lowModel);
            lowModel.Dock = DockStyle.Fill;
            //high model
            panelModel.Controls.Add(highModel);
            highModel.Dock = DockStyle.Fill;
            //Map
            WaferMapCanvas waferMapCanvas = WaferMapCanvas.Canvas;
            panelMap.Controls.Add(waferMapCanvas);
            waferMapCanvas.SetRatio(1, 1);
            waferMapCanvas.LoadCanvas();

            //CommonPanel
            CommonPanel commonPanel = new CommonPanel();//引入通用的CommonPanel
            panel1.Controls.Add(commonPanel);
        }
        /// <summary>
        /// 更新界面上控件的状态
        /// </summary>
        public void UpdateUI()
        {
            bool isLowModel = (Vision.activeCamera == Camera.WaferLowMag) ? true : false;//确认当前的相机是什么
            BtnLowMag.Enabled = !isLowModel;
            BtnHighMag.Enabled = isLowModel;
            BtnGoForModel.Text = (isLowModel) ? "Go For High Model" : "Go For Low Model";
            lowModel.Visible = isLowModel;
            highModel.Visible = !isLowModel;

            txtIndexSizeX.Text = WaferMap.Entity.DieSizeX.ToString();
            txtIndexSizeY.Text = WaferMap.Entity.DieSizeY.ToString();
        }
        private void AlignmentForm_Load(object sender, EventArgs e)
        {
            //默认是低倍相机启动
            Vision.ChangeCamera(Vision.WaferLowMag);
            Thread.Sleep(200);
            Vision.WaferLowMag.halconClass.SetPart(1280, 1024);//1280*1024显示

            WaferMap.OnAlignChange += UpdateAlignFlag;//注册flag事件
            UpdateUI();
        }
        private void BtnHighMag_Click(object sender, EventArgs e)
        {
            GoForHighModel();
        }
        private void BtnLowMag_Click(object sender, EventArgs e)
        {
            GoForLowModel();
        }
        private void BtnGoForModel_Click(object sender, EventArgs e)
        {
            BtnGoForModel.Enabled = false;
            if (BtnGoForModel.Text == "Go For Low Model") GoForLowModel();
            else GoForHighModel();
            BtnGoForModel.Enabled = true;
        }
        private void GoForLowModel()
        {
            Vision.ChangeCamera(Vision.WaferLowMag);
            Motion.TogglePosition(1);
            UpdateUI();
        }
        private void GoForHighModel()
        {
            Vision.ChangeCamera(Vision.WaferHighMag);
            Motion.TogglePosition(0);
            UpdateUI();
        }
        private void BtnAdjustWaferHeight_Click(object sender, EventArgs e)
        {
            WaitingControl wf = new WaitingControl();
            this.Controls.Add(wf);
            wf.Show();

            if (Vision.activeCamera == Camera.WaferLowMag)
            {
                CommonFunctions.AdjustWaferHeight(DeviceData.Entity.PhysicalInformation.Thickness, Vision.WaferLowMag);
            }
            else if (Vision.activeCamera == Camera.WaferHighMag)
            {
                CommonFunctions.AdjustWaferHeight(DeviceData.Entity.PhysicalInformation.Thickness, Vision.WaferHighMag);
            }

            wf.Dispose();
        }
        private void txtIndexSizeX_TextChanged(object sender, EventArgs e)
        {
            WaferMap.Entity.DieSizeX = double.Parse(txtIndexSizeX.Text);
        }
        private void txtIndexSizeY_TextChanged(object sender, EventArgs e)
        {
            WaferMap.Entity.DieSizeY = double.Parse(txtIndexSizeY.Text);
        }
        private void BtnVisionPara_Click(object sender, EventArgs e)
        {
            EdgeDetectionControl edgeDetectionControl = new EdgeDetectionControl();
            edgeDetectionControl.Location = new Point(1150, 150);
            this.Controls.Add(edgeDetectionControl);
            edgeDetectionControl.BringToFront();
            Vision.ChangeCamera(Camera.WaferLowMag);//需要转到lowMag
        }
        private void BtnWaferAlignment_Click(object sender, EventArgs e)
        {
            CommonFunctions.InitialMappingPoints();
        }
        private void UpdateAlignFlag(bool center, bool low, bool high)
        {
            lblWaferCenterFlag.BackColor = (center) ? Color.Green : Color.Red;
            lblLowAlignFlag.BackColor = (low) ? Color.Green : Color.Red;
            lblHighAlignFlag.BackColor = (high) ? Color.Green : Color.Red;

            TxtAlignData.Text = "WaferOffset :\r\n" + WaferMap.WaferOffsetX.ToString()
                + "\r\n" + WaferMap.WaferOffsetY.ToString();
        }
        /// <summary>
        /// 临时做一下高度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAutoHeight_Click(object sender, EventArgs e)
        {
            Vision.ChangeCamera(Vision.WaferHighMag);
            double[] Z = new double[9];

            CommonFunctions.Generate9Pionts(out double[] userX, out double[] userY);

            for (int i = 0; i < 9; i++)
            {
                Application.DoEvents();

                Motion.UserPosMoveAbs(Compensation.Area.Align, userX[i], userY[i]);

                int res = CommonFunctions.AdjustWaferHeight(DeviceData.Entity.PhysicalInformation.Thickness, Vision.WaferHighMag);
                if (res != 0) { MessageBox.Show("Focus Error"); return; }

                Z[i] = Motion.GetEncPos(1, 3);
            }

            double height = Z.Average();
            Motion.AxisMoveAbs(1, 3, height, 600, 20, 20, 10);
            lblAvgZ.Text = Z.Average().ToString();
            lblDiffZ.Text = (Z.Max() - Z.Min()).ToString();
        }
    }
}
