using VisionLibrary;
using MotionLibrary;
using CommonComponentLibrary;
using System.Text.Encodings.Web;

namespace test
{
    public partial class Form1 : Form
    {
        CommonPanel commonPanel;//引入通用的CommonPanel
        public Form1()
        {
            InitializeComponent();

            //CommonPanel
            commonPanel = new CommonPanel();
            this.panel1.Controls.Add(commonPanel);
            //this.panel1.Controls.SetChildIndex(commonPanel, 0);//这个作用是将控件置于顶层，该处不需要


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Vision.ResetConfig();
            //Vision.Save("VisionConfig.json");
            Vision.Initial();
            Compensation.Initial();
            Motion.OpenCard();
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
        }

        private void BtnSetPart_Click(object sender, EventArgs e)
        {
            Vision.CameraList[comboBox1.SelectedIndex].halconClass.SetPart(1280, 1024);
        }

      
    }
}
