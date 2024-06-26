using CommonComponentLibrary;
using log4net;
using log4net.Config;
using Microsoft.VisualBasic.Logging;
using MotionLibrary;
using System.IO;
using VisionLibrary;
using WaferMapLibrary;

namespace testVision2
{
    public partial class Form1 : Form
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Form1));
        public Form1()
        {
            InitializeComponent();
            this.Controls.Add(WaitingControl.WF);
            WaitingControl.WF.BringToFront();
            //panel2.Controls.Add(form2);
            //form2.Show();

            panel1.Controls.Add(new CommonPanel());
            GlobalContext.Properties["name"] = this.GetType().Name;//指定文件名
            XmlConfigurator.Configure(new FileInfo("log4net.config"));//读取配置

            
        }

        //Form2 form2 = new Form2();
        private void Form1_Load(object sender, EventArgs e)
        {
            //Vision.ResetConfig();
            //Vision.Save("VisionConfig.json");
            Vision.Initial();
            Compensation.Initial();
            Motion.Initial();
            Motion.MultiAxisOn(1, 4);
            log.Debug("Entering application.");
            //WaitingControl.WF.Start();

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
                Mag.halconClass.EvaluateDefinition(out double Definition);//计算清晰度
                pos.Add(z);
                def.Add(Definition);

                //判断斜率，然后看i是否要增加
                z += step;
            }
            int maxIndex = def.IndexOf(def.Max());//找Def最大处的index值
            double Target = pos[maxIndex];
            Motion.AxisMoveAbs(1, 3, Target, 600, 20, 20, 10);

            Mag.ContinuesMode();
            int res = (maxIndex == 0 || maxIndex == pos.Count - 1) ? 1 : 0;//如果最大值在两端，则报1
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
            string path = DateTime.Now.ToString("yyyyMMddHHMMmmfff") + ".bmp";
            Vision.CameraList[comboBox1.SelectedIndex].halconClass.SaveImage(path);
        }

        private void work()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine(i.ToString());
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DeviceData.Load("DeviceData/" + "0411DeviceData.json");
            WaferMap.Load(DeviceData.Entity.WaferAlignment.WaferMapPath);
            PadData.Load(DeviceData.Entity.PinAlignment.PadDataPath);
            PinData.Load(DeviceData.Entity.PinAlignment.PinDataPath);
            DUTData.Load(DeviceData.Entity.WaferAlignment.DutPath);
            MessageBox.Show("File Load Success!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void Form1_Activated(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var a = Task.Run(() => work());
            a.Wait();
            Console.WriteLine("done");
        }

        private  void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Vision.CameraList[comboBox1.SelectedIndex].halconClass.LoadImage(ofd.FileName);
            }
            
            Vision.CameraList[comboBox1.SelectedIndex].halconClass.GetProbeMark(150,6000,1000,
                out double up,out double down,out double left,out double right,out double deltaX,out double deltaY);
            Console.WriteLine(up.ToString() + " " + down.ToString() + " " + left.ToString() + " " + right.ToString() + " " + deltaX.ToString() + " " + deltaY.ToString());
        }
    }
}
