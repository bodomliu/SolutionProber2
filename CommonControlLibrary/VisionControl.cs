using VisionLibrary;
using MotionLibrary;
namespace CommonComponentLibrary
{
    public partial class VisionControl : UserControl
    {
        public VisionControl()
        {
            InitializeComponent();
        }

        private void BtnSetPart_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null) return;
            Vision.CameraList[comboBox1.SelectedIndex].halconClass.SetPart(1280, 1024);
        }

        private void BtnSetExpo_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null) return;
            CameraClass Mag = Vision.CameraList[comboBox1.SelectedIndex];
            float expo = float.Parse(TxtExpo.Text);
            Mag.SetExposureTime(expo);
        }

        private void BtnSaveImg_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null) return;
            string path = DateTime.Now.ToString("yyyyMMddHHMMmmfff") + ".bmp";
            Vision.CameraList[comboBox1.SelectedIndex].halconClass.SaveImage(path);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Vision.ChangeCamera(comboBox1.SelectedIndex);

            CameraClass Mag = Vision.CameraList[comboBox1.SelectedIndex];
            Mag.GetExposureTime(out float expo);
            TxtExpo.Text = expo.ToString();
        }
        private class MatchPoint
        {
            public int index { get; set; }
            public double Row { get; set; }
            public double Column { get; set; }
            public double EncodeX { get; set; }
            public double EncodeY { get; set; }
        }
        List<MatchPoint> MatchPoints = new List<MatchPoint>();

        private void BtnMatch_Click(object sender, EventArgs e)
        {
            CameraClass mag = Vision.CameraList[comboBox1.SelectedIndex];
            mag.TriggerMode();//单拍模式
            int res = mag.halconClass.FindShapeModel("temp.shm", 0, out double DeltaX, out double DeltaY,
                out double[] Row, out double[] Column, out double[] Angle, out double[] Score);

            if (res == 0)//如果匹配成功
            {
                MatchPoints.Add(new MatchPoint()
                {
                    index = MatchPoints.Count,
                    Row = Row[0],
                    Column = Column[0],
                    EncodeX = Motion.GetEncPos(1, 1),
                    EncodeY = Motion.GetEncPos(1, 2),
                });
                dataGridView1.DataSource = null;//删掉报错
                dataGridView1.DataSource = MatchPoints;
            }
            //Application.DoEvents();
            Thread.Sleep(500);//显示下绘图再返回连拍
            mag.ContinuesMode();//连拍模式，匹配完，切回连拍模式
            return;//若匹配失败，直接返回findShapeModel错误结果
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            int RowIndex = dataGridView1.CurrentCell.RowIndex;
            if (RowIndex >= 0)
            {
                MatchPoints.RemoveAt(RowIndex);
                dataGridView1.DataSource = null;//删掉报错
                dataGridView1.DataSource = MatchPoints;
            }
        }

        private void BtnGenCalibration_Click(object sender, EventArgs e)
        {
            int count = MatchPoints.Count;
            double[] row = new double[count];
            double[] column = new double[count];
            double[] FeedbackX = new double[count];
            double[] FeedbackY = new double[count];
            for (int i = 0; i < count; i++)
            {
                row[i] = MatchPoints[i].Row;
                column[i] = MatchPoints[i].Column;
                FeedbackX[i] = MatchPoints[i].EncodeX;
                FeedbackY[i] = MatchPoints[i].EncodeY;
            }
            Vision.CameraList[comboBox1.SelectedIndex].halconClass.m_Calibration.GenHomMat2d(row, column, FeedbackX, FeedbackY);

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "bin文件(*.bin文件)|*.bin|所有文件|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string path = sfd.FileName.ToString(); //获得文件路径 
                Vision.CameraList[comboBox1.SelectedIndex].halconClass.m_Calibration.SaveHomMat2d(path);
            }
        }

        private void BtnCreateModel_Click(object sender, EventArgs e)
        {
            CameraClass mag = Vision.CameraList[comboBox1.SelectedIndex];
            mag.halconClass.CreateShapeModel("temp.shm");
        }

        private void BtnClearAll_Click(object sender, EventArgs e)
        {
            MatchPoints.Clear();
            dataGridView1.DataSource = null;//删掉报错
            dataGridView1.DataSource = MatchPoints;
        }
    }
}
