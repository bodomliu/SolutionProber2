using VisionLibrary;
using MotionLibrary;
using CommonComponentLibrary;
using System.Text.Encodings.Web;
using MathNet.Numerics.LinearAlgebra.Factorization;

namespace test
{
    public partial class Form1 : Form
    {
        CommonPanel commonPanel;//����ͨ�õ�CommonPanel
        public Form1()
        {
            InitializeComponent();

            //CommonPanel
            commonPanel = new CommonPanel();
            this.panel1.Controls.Add(commonPanel);
            //this.panel1.Controls.SetChildIndex(commonPanel, 0);//��������ǽ��ؼ����ڶ��㣬�ô�����Ҫ


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Vision.ResetConfig();
            //Vision.Save("VisionConfig.json");
            Vision.Initial();
            Compensation.Initial();
            Motion.Initial();
            Motion.MultiAxisOn(1, 4);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Motion.CloseCard();
            Vision.CloseAllCamera();
        }

        private void commonPanel1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Vision.ChangeCamera(comboBox1.SelectedIndex);

            CameraClass Mag = Vision.CameraList[comboBox1.SelectedIndex];
            Mag.GetExposureTime(out float expo);
            TxtExpo.Text = expo.ToString();
        }

        private void BtnSetPart_Click(object sender, EventArgs e)
        {
            Vision.CameraList[comboBox1.SelectedIndex].halconClass.SetPart(1280, 1024);
        }

        private void BtnZHome_Click(object sender, EventArgs e)
        {
            Motion.AxisHome(1, 3, -1, 1, 1, 100, 10, 0);
        }

        private void BtnAdjustWaferHeight_Click(object sender, EventArgs e)
        {
            CameraClass Mag = Vision.CameraList[comboBox1.SelectedIndex];
            double start = double.Parse(TxtStart.Text);
            double end = double.Parse(TxtEnd.Text);
            double step = double.Parse(TxtStep.Text);

            Mag.TriggerMode();

            List<double> def = new();
            List<double> pos = new();

            for (double z = start; z < end;)
            {
                Motion.AxisMoveAbs(1, 3, z, 600, 20, 20, 10);
                Mag.TriggerExec();
                Mag.halconClass.EvaluateDefinition(out double Definition);//����������
                pos.Add(z);
                def.Add(Definition);

                //�ж�б�ʣ�Ȼ��i�Ƿ�Ҫ����
                z += step;
            }
            int maxIndex = def.IndexOf(def.Max());//��Def��󴦵�indexֵ
            double Target = pos[maxIndex];
            Motion.AxisMoveAbs(1, 3, Target, 600, 20, 20, 10);

            Mag.ContinuesMode();
            int res = (maxIndex == 0 || maxIndex == pos.Count - 1) ? 1 : 0;//������ֵ�����ˣ���1
            if (res != 0) MessageBox.Show("not found Peak.");
        }

        private void BtnSetExpo_Click(object sender, EventArgs e)
        {
            CameraClass Mag = Vision.CameraList[comboBox1.SelectedIndex];
            float expo = float.Parse(TxtExpo.Text);
            Mag.SetExposureTime(expo);
        }

        private void BtnSaveImg_Click(object sender, EventArgs e)
        {
            string path = DateTime.Now.ToString("yyyyMMddHHMMmmfff")+".bmp";
            Vision.CameraList[comboBox1.SelectedIndex].halconClass.SaveImage(path);
        }
    }
}
