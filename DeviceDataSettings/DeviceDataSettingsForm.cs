using DeviceDataSettings;
using WaferMapLibrary;
using JsonDataShow;
namespace MainForm
{
    public partial class DeviceDataSettingsForm : Form
    {
        public DeviceDataSettingsForm()
        {
            this.TopLevel = false; this.FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();

            //¡Ÿ ±¥˙¬Î
            DirectoryInfo folder = new DirectoryInfo("DeviceData/");
            foreach (FileInfo file in folder.GetFiles("*.*", SearchOption.AllDirectories))
            {
                CbxDeviceData.Items.Add(file.Name);
            }
            CbxDeviceData.SelectedItem = "0411DeviceData.json";
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
            DeviceData.Save("DeviceData/" + CbxDeviceData.SelectedItem);
            WaferMap.Save(DeviceData.Entity.WaferAlignment.WaferMapPath);
            PadData.Save(DeviceData.Entity.PinAlignment.PadDataPath);
            PinData.Save(DeviceData.Entity.PinAlignment.PinDataPath);
            DUTData.Save(DeviceData.Entity.WaferAlignment.DutPath);
            MessageBox.Show("File Save Success!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void BtnLoad_Click(object sender, EventArgs e)
        {
            DeviceData.Load("DeviceData/" + CbxDeviceData.SelectedItem);
            WaferMap.Load(DeviceData.Entity.WaferAlignment.WaferMapPath);
            PadData.Load(DeviceData.Entity.PinAlignment.PadDataPath);
            PinData.Load(DeviceData.Entity.PinAlignment.PinDataPath);
            DUTData.Load(DeviceData.Entity.WaferAlignment.DutPath);
            MessageBox.Show("File Load Success!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void DeviceDataSettingsForm_Load(object sender, EventArgs e)
        {

        }
        private void BtnSettings_Click(object sender, EventArgs e)
        {
            JsonDataForm form = new JsonDataForm("DeviceData/" + CbxDeviceData.SelectedItem, DeviceData.Entity);
            DialogResult res = form.ShowDialog();
        }
    }
}
