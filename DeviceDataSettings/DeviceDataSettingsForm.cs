using WaferMapLibrary;

namespace UtityForm
{
    public partial class DeviceDataSettingsForm : Form
    {
        public DeviceDataSettingsForm()
        {
            this.TopLevel = false; this.FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();

            //¡Ÿ ±¥˙¬Î
            WaferMap.Load("DeviceData/0411WaferMap.json");
            DeviceData.Load("DeviceData/0411DeviceData.json");
            TxtFileName.Text = "DeviceData/0411DeviceData.json";
        }

        private void BtnWaferMap_Click(object sender, EventArgs e)
        {

        }

        private void BtnDeviceData_Click(object sender, EventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            DeviceData.Save(TxtFileName.Text);
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            DeviceData.Load(TxtFileName.Text);
        }
    }
}
