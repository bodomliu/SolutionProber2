using MotionLibrary;
using VisionLibrary;
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
            Motion.XYZ_AxisMoveAbs(1, Motion.EdgeX[index], Motion.EdgeY[index], 54000, 600, 10, 10, 20);//运动到边缘点
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
                Motion.XYZ_GetEncPos(out EdgeX[i], out EdgeY[i], out double Z);
            }

            //切换到连续拍模式
            Vision.WaferLowMag.ContinuesMode();
            //生成拟合圆
            Vision.WaferLowMag.halconClass.FitCircle(EdgeX, EdgeY, out double CenterX, out double CenterY, out double R);

            lblWaferCenterX.Text = CenterX.ToString();//modify by bodom
            lblWaferCenterY.Text = CenterY.ToString();//modify by bodom

            //算出来则写入WaferMap
            WaferMap.WaferCenterX = CenterX;
            WaferMap.WaferCenterY = CenterY;
            WaferMap.IsWaferCenterCompleted = true;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            //缩回ROI
            Vision.WaferLowMag.halconClass.m_Roi.Resize2(512, 640, 400, 400);
            //当关闭时，隐藏自己
            //this.Visible = false;
            this.Dispose();
        }

        private void BtnToCenter_Click(object sender, EventArgs e)
        {
            Motion.XY_AxisMoveAbs(1, double.Parse(lblWaferCenterX.Text), double.Parse(lblWaferCenterY.Text), 600, 10, 10, 0);
        }
    }
}