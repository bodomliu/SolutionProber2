using MotionLibrary;
using VisionLibrary;
using WaferMapLibrary;
namespace UtityForm
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
            //切换到单拍模式
            Vision.WaferLowMag.TriggerMode();

            int index = ToEdgeTimes % 4;
            DetecetEdge(index);
            ToEdgeTimes++;

            //切换到单拍模式
            Vision.WaferLowMag.ContinuesMode();
        }

        private int DetecetEdge(int index)
        {
            //运动到Edge 定位并获取值
            Motion.XYZ_AxisMoveAbs(1, Motion.parameter.EdgeX[index], Motion.parameter.EdgeY[index], 54000, 600, 10, 10, 20);//运动到边缘点
            //考虑晶圆边缘定位一致性不好，临时性放大ROI，完成了以后还原
            Vision.WaferLowMag.halconClass.m_Roi.Resize2(512, 640, 600, 600);
            //采集一张照片
            Vision.WaferLowMag.TriggerExec();
            //获取边缘置于中心的位移XY
            int res = Vision.WaferLowMag.halconClass.GetWaferEdge(out double DeltaX, out double DeltaY);

            //如果匹配错误则返回
            if (res != 0) { MessageBox.Show("Edge Detected Error."); return res; }
            //相对运动，进行Match
            Motion.XY_AxisMoveRel(1, DeltaX, DeltaY, 600, 10, 10, 20);
            //为了绘图，再单拍一张
            Vision.WaferLowMag.TriggerExec();

            Vision.WaferLowMag.halconClass.GetWaferEdge(out _, out _);
            Application.DoEvents();
            return 0;
        }

        private void BtnAutoDetectWaferCenter_Click(object sender, EventArgs e)
        {
            double[] EdgeX = new double[4];
            double[] EdgeY = new double[4];

            //切换到单拍模式
            Vision.WaferLowMag.TriggerMode();

            for (int i = 0; i < 4; i++)
            {
                if (DetecetEdge(i) != 0) return;
                //这里采集了边缘点，所以就不用userpos来计算了
                Motion.XYZ_GetEncPos(out EdgeX[i], out EdgeY[i], out double Z);
            }

            //切换到连续拍模式
            Vision.WaferLowMag.ContinuesMode();
            //生成拟合圆
            Vision.WaferLowMag.halconClass.FitCircle(EdgeX, EdgeY, out double CenterX, out double CenterY, out double R);

            //TODO:增加圆心校验
            //算出来则写入WaferMap,圆心是粗定位值，不太可靠，主要用来确认位置是否偏移的过量了
            WaferMap.WaferCenterX = CenterX + Motion.parameter.XWAFERLOW2HIGHT;
            WaferMap.WaferCenterY = CenterY + Motion.parameter.YWAFERLOW2HIGHT;
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
            //缩回ROI
            Vision.WaferLowMag.halconClass.m_Roi.Resize2(512, 640, 400, 400);
            //当关闭时，销毁
            this.Dispose();
        }

        private void BtnToCenter_Click(object sender, EventArgs e)
        {
            //粗定位
            Motion.XY_AxisMoveAbs(1, WaferMap.WaferCenterX - Motion.parameter.XWAFERLOW2HIGHT,
                WaferMap.WaferCenterY - Motion.parameter.YWAFERLOW2HIGHT,600,20,20,10);
        }
    }
}