using DeviceDataSettings;
using WaferMapLibrary;

namespace MainForm
{
    public partial class DeviceDataSettingsForm : Form
    {
        public DeviceDataSettingsForm()
        {
            this.TopLevel = false; this.FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();

            //¡Ÿ ±¥˙¬Î
            WaferMap.Load("DeviceData/ErrorMapWaferMap.json");
            DeviceData.Load("DeviceData/ErrorMapDeviceData.json");
            TxtFileName.Text = "DeviceData/ErrorMapDeviceData.json";
        }

        private void BtnWaferMap_Click(object sender, EventArgs e)
        {
            panelForm.Controls.Add(new WaferMapSettingControl());
        }

        private void BtnDeviceData_Click(object sender, EventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            WaferMap.Save("DeviceData/ErrorMapWaferMap.json");
            DeviceData.Save("DeviceData/ErrorMapDeviceData.json");
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            WaferMap.Load("DeviceData/ErrorMapWaferMap.json");
            DeviceData.Load("DeviceData/ErrorMapDeviceData.json");
        }
    }
}
