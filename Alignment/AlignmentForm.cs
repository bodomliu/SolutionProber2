using CommonComponentLibrary;
using VisionLibrary;
using MotionLibrary;
using WaferMapLibrary;
using log4net;
using log4net.Config;
using System.Windows.Forms;
using MathNet.Numerics;
namespace MainForm
{
    public partial class AlignmentForm : Form
    {
        // Define a static logger variable so that it references the
        // Logger instance named "MainForm".
        private static readonly ILog log = LogManager.GetLogger(typeof(AlignmentForm));

        LowModel lowModel = new LowModel();
        HighModel highModel = new HighModel();
        public AlignmentForm()
        {
            this.TopLevel = false; this.FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
            GlobalContext.Properties["name"] = this.GetType().Name;//指定文件名
            XmlConfigurator.Configure(new FileInfo("log4net.config"));//读取配置
            log.Info("Entering AlignmentForm.");
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

        }
        /// <summary>
        /// 更新界面上控件的状态
        /// </summary>
        public void UpdateUI()
        {
            //bool isLowModel = (Vision.activeCamera == Camera.WaferLowMag) ? true : false;//确认当前的相机是什么
            BtnLowMag.Enabled = !isLowModel;
            BtnHighMag.Enabled = isLowModel;
            BtnGoForModel.Text = (isLowModel) ? "Go For High Model" : "Go For Low Model";
            lowModel.Visible = isLowModel;
            highModel.Visible = !isLowModel;

            txtIndexSizeX.Text = WaferMap.Entity.DieSizeX.ToString();
            txtIndexSizeY.Text = WaferMap.Entity.DieSizeY.ToString();
        }

        public bool isLowModel = true;//默认是低倍模式
        private void AlignmentForm_Load(object sender, EventArgs e)
        {
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
            WaitingControl.WF.Start();

            BtnGoForModel.Enabled = false;
            if (!isLowModel) GoForLowModel();
            else GoForHighModel();
            BtnGoForModel.Enabled = true;

            WaitingControl.WF.Hide();
        }
        private async void GoForLowModel()
        {
            await Task.Run(() =>
            {
                Vision.ChangeCamera(Vision.WaferLowMag);
                Motion.TogglePosition(1);
            });
            isLowModel = true;
            UpdateUI();
        }
        private async void GoForHighModel()
        {
            await Task.Run(() => 
            {
                Vision.ChangeCamera(Vision.WaferHighMag);
                Motion.TogglePosition(0);

            });           
            isLowModel = false;
            UpdateUI();
        }
        private async void BtnAdjustWaferHeight_Click(object sender, EventArgs e)
        {
            WaitingControl.WF.Start();

            if (Vision.activeCamera == Camera.WaferLowMag)
            {
                await Task.Run(() => 
                CommonFunctions.AdjustWaferHeight(DeviceData.Entity.PhysicalInformation.Thickness, Vision.WaferLowMag)
                );
            }
            else if (Vision.activeCamera == Camera.WaferHighMag)
            {
                await Task.Run(() =>
                CommonFunctions.AdjustWaferHeight(DeviceData.Entity.PhysicalInformation.Thickness, Vision.WaferHighMag)
                );
            }

            WaitingControl.WF.End();
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

            TxtWaferCenterX.Text = WaferMap.WaferCenterX.ToString("F0");
            TxtWaferCenterY.Text = WaferMap.WaferCenterY.ToString("F0");
            TxtWaferOffsetX.Text = WaferMap.WaferOffsetX.ToString("F0");
            TxtWaferOffsetY.Text = WaferMap.WaferOffsetY.ToString("F0");
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

            //TODO 高度插补
            WaferMap.WaferHeight = height;//将平均值赋值给WaferHeight
        }

        private void AlignmentForm_ParentChanged(object sender, EventArgs e)
        {
            //会进两次
            if (Parent!=null)
            {               
                panel1.Controls.Clear();
                panel1.Controls.Add(CommonPanel.Entity);
                if (isLowModel)
                {
                    //默认是低倍相机启动
                    Vision.ChangeCamera(Vision.WaferLowMag);
                    Vision.WaferLowMag.halconClass.SetPart(1280, 1024);//1280*1024显示
                }
                else
                {
                    Vision.ChangeCamera(Vision.WaferHighMag);
                    Vision.WaferHighMag.halconClass.SetPart(1280, 1024);//1280*1024显示
                }
                UpdateUI();
            }
            else { }
        }

        private void AlignmentForm_VisibleChanged(object sender, EventArgs e)
        {
            
        }
    }
}
