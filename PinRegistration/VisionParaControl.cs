using WaferMapLibrary;

namespace PinRegistration
{
    public partial class VisionParaControl : UserControl
    {
        public VisionParaControl()
        {
            InitializeComponent();

            NumThreshold.Maximum = 255;
            NumThreshold.Value = DeviceData.Entity.PinAlignment.GetPinThreshold;
            NumExposureTime.Maximum = 10000000;
            NumExposureTime.Value = (int)DeviceData.Entity.PinAlignment.GetPinExposureTime;
            NumSearchAreaX.Maximum = 1280;
            NumSearchAreaX.Value = DeviceData.Entity.PinAlignment.GetPinXArea;
            NumSearchAreaY.Maximum = 1024;
            NumSearchAreaY.Value = DeviceData.Entity.PinAlignment.GetPinYArea;
            NumMaxBlob.Maximum = 10000000;
            NumMaxBlob.Value = DeviceData.Entity.PinAlignment.GetPinMaxBlob;
            NumMinBlob.Maximum = 10000000;
            NumMinBlob.Value = DeviceData.Entity.PinAlignment.GetPinMinBlob;
            NumFilter.Maximum = 15;
            NumFilter.Value = DeviceData.Entity.PinAlignment.GetPinFilter;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void VisionParaControl_Load(object sender, EventArgs e)
        {

        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            DeviceData.Entity.PinAlignment.GetPinThreshold = (int)NumThreshold.Value;
            DeviceData.Entity.PinAlignment.GetPinExposureTime = (float)NumExposureTime.Value;
            DeviceData.Entity.PinAlignment.GetPinXArea = (int)NumSearchAreaX.Value;
            DeviceData.Entity.PinAlignment.GetPinYArea = (int)NumSearchAreaY.Value;
            DeviceData.Entity.PinAlignment.GetPinMaxBlob = (int)NumMaxBlob.Value;
            DeviceData.Entity.PinAlignment.GetPinMinBlob = (int)NumMinBlob.Value;
            DeviceData.Entity.PinAlignment.GetPinFilter = (int)NumFilter.Value;
            DeviceData.Save("DeviceData/0411DeviceData.json");
            MessageBox.Show("Device Data Saved!");
        }

        private async void BtnBlob_Click(object sender, EventArgs e)
        {
            var (res, area) = await Task.Run(() =>
            {
                double areaResult;
                int result = PinAlignLib.GetPin(true, out _, out _, out areaResult);
                return (result, areaResult);
            });
            LblArea.Text = area.ToString();
        }
    }
}
