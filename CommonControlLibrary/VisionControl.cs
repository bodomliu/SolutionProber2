using System.Windows.Forms;
using VisionLibrary;

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

        private void BtnMatch_Click(object sender, EventArgs e)
        {

        }
    }
}
