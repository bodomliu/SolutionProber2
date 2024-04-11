//using HalconDotNet;
using CommonComponentLibrary;
using VisionLibrary;
using WaferMapLibrary;

namespace MainForm
{
    public partial class AlignmentForm : Form
    {
        LowModel lowModel = new LowModel();
        HighModel highModel = new HighModel();
        EdgeDetectionControl edgeDetectionControl = new EdgeDetectionControl();
        WaferMapCanvas waferMapCanvas = WaferMapCanvas.Canvas;
        CommonPanel commonPanel = new CommonPanel();//引入通用的CommonPanel

        public AlignmentForm()
        {
            this.TopLevel = false; this.FormBorderStyle = FormBorderStyle.None;

            InitializeComponent();

            panelModel.Controls.Add(lowModel);
            lowModel.Dock = DockStyle.Fill;

            panelModel.Controls.Add(highModel);
            highModel.Dock = DockStyle.Fill;
            highModel.Visible = false;

            //默认不显示edgeDetection
            this.Controls.Add(edgeDetectionControl);
            edgeDetectionControl.Visible = false;

            //Map
            panelMap.Controls.Add(waferMapCanvas);
            waferMapCanvas.LoadCanvas();

            //CommonPanel
            commonPanel = new CommonPanel();
            panel1.Controls.Add(commonPanel);
        }

        public enum ActiveModel
        {
            LowModel = 0,
            HighModel = 1
        }

        public ActiveModel activeModel;

        private void AlignmentForm_Load(object sender, EventArgs e)
        {
            //默认是低倍相机启动
            Vision.ChangeCamera(Vision.WaferLowMag);
            Thread.Sleep(200);
            Vision.WaferLowMag.halconClass.SetPart(1280, 1024);//1280*1024显示

            BtnLowMag.Enabled = false; BtnHighMag.Enabled = true;
            activeModel = ActiveModel.LowModel;

            WaferMap.OnAlignChange += UpdateAlignFlag;//注册falg事件
        }

        private void BtnHighMag_Click(object sender, EventArgs e)
        {
            Vision.ChangeCamera(Vision.WaferHighMag);
            BtnLowMag.Enabled = true; BtnHighMag.Enabled = false;
        }

        private void BtnLowMag_Click(object sender, EventArgs e)
        {
            Vision.ChangeCamera(Vision.WaferLowMag);
            BtnLowMag.Enabled = false; BtnHighMag.Enabled = true;
        }

        private void BtnGoForModel_Click(object sender, EventArgs e)
        {
            if (activeModel == ActiveModel.LowModel)
            {
                activeModel = ActiveModel.HighModel;
                BtnGoForModel.Text = "Go For Low Model";
                lowModel.Visible = false;
                highModel.Visible = true;
            }
            else if (activeModel == ActiveModel.HighModel)
            {
                activeModel = ActiveModel.LowModel;
                BtnGoForModel.Text = "Go For High Model";
                lowModel.Visible = true;
                highModel.Visible = false;
            }
        }

        private void BtnAdjustWaferHeight_Click(object sender, EventArgs e)
        {
            WaitingControl wf = new WaitingControl();
            wf.Show();

            if (Vision.activeCamera == Camera.WaferLowMag)
            {
                Alignment.AdjustWaferHeight(30000, 60000, Vision.WaferLowMag);
            }
            else if (Vision.activeCamera == Camera.WaferHighMag)
            {
                Alignment.AdjustWaferHeight(37000, 39000, Vision.WaferHighMag);
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
            edgeDetectionControl.Visible = true;
            edgeDetectionControl.Location = new Point(1150, 150);
            edgeDetectionControl.BringToFront();
            Vision.ChangeCamera(Camera.WaferLowMag);//需要转到lowMag
        }

        private void BtnWaferAlignment_Click(object sender, EventArgs e)
        {

        }

        public void UpdateAlignFlag(bool center ,bool low, bool high)
        {
            lblWaferCenterFlag.BackColor = (center)? Color.Green: Color.Red;
            lblLowAlignFlag.BackColor = (low) ? Color.Green : Color.Red;
            lblHighAlignFlag.BackColor = (high) ? Color.Green : Color.Red;
        }

        private void BtnAutoHeight_Click(object sender, EventArgs e)
        {
            //Vision.ChangeCamera(Vision.WaferHighMag);
            //double[] Z = new double[9];

            //WaferMap.Generate9Pionts(out double[] userX, out double[] userY);

            //for (int i = 0; i < 9; i++)
            //{
            //    Application.DoEvents();

            //    Motion.UserPosMoveAbs(Compensation.Area.Align, userX[i], userY[i]);

            //    int res = Alignment.AdjustWaferHeight(37000, 39000, Vision.WaferHighMag);
            //    if (res != 0) { MessageBox.Show("Focus Error"); return; }

            //    Z[i] = Motion.GetEncPos(1, 3);
            //}

            //WaferMap.Thickness = Z.Average();
            //lblAvgZ.Text = Z.Average().ToString();
            //lblDiffZ.Text = (Z.Max() - Z.Min()).ToString();
        }
    }
}
