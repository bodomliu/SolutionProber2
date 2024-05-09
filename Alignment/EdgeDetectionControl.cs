using VisionLibrary;
using MotionLibrary;
using WaferMapLibrary;
namespace MainForm
{
    public partial class EdgeDetectionControl : UserControl
    {
        public EdgeDetectionControl()
        {
            InitializeComponent();
            NumThreshold.Minimum = 0;
            NumThreshold.Maximum = 255;
            NumLight.Minimum = 0;
            NumLight.Maximum = 255;
            NumAuxLight.Minimum = 0;
            NumAuxLight.Maximum = 255;
        }
        private void EdgeDetectionControl_Load(object sender, EventArgs e)
        {
            NumThreshold.Value = 128;
            NumLight.Value = 128;
            NumAuxLight.Value = 128;

            UpdateUI();
        }

        public int ToEdgeTimes = 0;
        private void BtnToEdge_Click(object sender, EventArgs e)
        {
            int index = ToEdgeTimes % 4;
            DetecetEdge(index);
            ToEdgeTimes++;
        }
        private int DetecetEdge(int index)
        {
            //运动到Edge 定位并获取值
            Motion.XYZ_AxisMoveAbs(1, Motion.parameter.EdgeX[index], Motion.parameter.EdgeY[index], 54000, 600, 10, 10, 20);//运动到边缘点
            //执行Blob
            int res = Blob(true, out double DeltaX, out double DeltaY);//先bigROI找
            if (res != 0) { MessageBox.Show("Edge Detected Error."); return res; }

            //相对运动，进行Match
            Motion.XY_AxisMoveRel(1, DeltaX, DeltaY, 600, 10, 10, 20);

            //为了绘图+确认，再单拍一张
            res = Blob(false, out _, out _);//再SmallROI确认
            //如果匹配错误则返回
            if (res != 0) { MessageBox.Show("Edge Confirm Error."); return res; }
            return 0;
        }
        private void BtnAutoDetectWaferCenter_Click(object sender, EventArgs e)
        {
            double[] EdgeX = new double[4];
            double[] EdgeY = new double[4];

            //切换到单拍模式
            //Vision.WaferLowMag.TriggerMode();

            for (int i = 0; i < 4; i++)
            {
                if (DetecetEdge(i) != 0) { return; }
                //这里采集了边缘点，所以就不用userpos来计算了                
                Motion.GetUserPos(Compensation.Area.Align, out EdgeX[i], out EdgeY[i]);
            }

            //生成拟合圆，CenterX 和 CenterY是粗定位下的坐标
            Vision.WaferLowMag.halconClass.FitCircle(EdgeX, EdgeY, out double CenterX, out double CenterY, out double R);

            //TODO:增加圆心校验 TODO：确认方向，暂时这么处理，X反向，Y同向
            //算出来则写入WaferMap,圆心是粗定位值，不太可靠，TODO可以计算确认位置是否偏移的过量了
            WaferMap.WaferCenterX = CenterX;
            WaferMap.WaferCenterY = CenterY;
            WaferMap.IsWaferCenterCompleted = true;

            UpdateUI();
        }
        private void UpdateUI()
        {
            lblWaferCenterX.Text = WaferMap.WaferCenterX.ToString("F0");
            lblWaferCenterY.Text = WaferMap.WaferCenterY.ToString("F0");
        }
        private void Close_Click(object sender, EventArgs e)
        {
            //当关闭时，销毁
            this.Dispose();
        }
        private void BtnToCenter_Click(object sender, EventArgs e)
        {
            //粗定位 TODO：确认方向，暂时这么处理，X反向，Y同向
            Motion.UserPosMoveAbs(Compensation.Area.Align, WaferMap.WaferCenterX, WaferMap.WaferCenterY);
        }
        private void BtnBlob_Click(object sender, EventArgs e)
        {
            int res = Blob(false, out double DeltaX, out double DeltaY);
            //如果匹配错误则返回
            if (res != 0) MessageBox.Show("Error Code = " + res.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        /// <summary>
        /// BigROI 找边，SmallROI确认
        /// </summary>
        /// <param name="BigROI"></param>
        /// <param name="DeltaX"></param>
        /// <param name="DeltaY"></param>
        /// <returns></returns>
        private int Blob(bool BigROI, out double DeltaX, out double DeltaY)
        {
            //切换到单拍模式
            Vision.WaferLowMag.TriggerMode();
            //Blob时候放大ROI
            if (BigROI) Vision.WaferLowMag.halconClass.m_Roi.Resize2(512, 640, 600, 600);
            Vision.WaferLowMag.TriggerExec();
            int res = Vision.WaferLowMag.halconClass.GetWaferEdge(out DeltaX, out DeltaY);
            Application.DoEvents();
            Thread.Sleep(100);//显示效果            
            //完成后缩小ROI
            Vision.WaferLowMag.halconClass.m_Roi.Resize2(512, 640, 400, 400);
            //切换到单拍模式
            Vision.WaferLowMag.ContinuesMode();
            return res;
        }
    }
}