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
            WaferMap.Load("Maps/0411.json");
        }

        private void BtnWaferMap_Click(object sender, EventArgs e)
        {

        }

        private void BtnDeviceData_Click(object sender, EventArgs e)
        {

        }
    }
}
