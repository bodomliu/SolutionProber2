using log4net;
using log4net.Config;
using WaferMapLibrary;
using System.Windows.Forms;
using VisionLibrary;
using CommonComponentLibrary;
using MotionLibrary;
using PinRegistration;
using PadRegistration;
namespace MainForm
{
    public partial class MainForm : Form
    {
        // Define a static logger variable so that it references the
        // Logger instance named "MainForm".
        private static readonly ILog log = LogManager.GetLogger(typeof(MainForm));

        readonly LotProcessForm lotProcessForm = new();
        readonly ErrorCompensationForm errorCompensatioForm = new();
        readonly MotionControl motionControl = new();
        readonly AlignmentForm alignmentForm = new();
        readonly DeviceDataSettingsForm deviceDataSettingsForm = new();
        readonly UtilityForm.UtilityForm utilityForm = new();
        readonly PadRegistrationForm padRegistrationFrom = new();
        readonly PinRegistrationForm pinRegistrationFrom = new();
        readonly InspectionForm inspectionForm = new();
        readonly ManualForm.ManualForm manualForm = new();
        readonly StatusBar statusBar = new ();
        public MainForm()
        {
            InitializeComponent();
            // Set up a simple configuration that logs on the console.
            //BasicConfigurator.Configure();
            GlobalContext.Properties["name"] = this.GetType().Name;//指定文件名
            XmlConfigurator.Configure(new FileInfo("log4net.config"));//读取配置
            panelStatus.Controls.Add(statusBar);
            log.Info("Entering application.");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //主界面最大化
            this.WindowState = FormWindowState.Maximized;

            Vision.Initial();
            Compensation.Initial();
            Motion.Initial();
            Motion.MultiAxisOn(1, 4);

            Controls.Add(WaitingControl.WF);
        }

        private void BtnLotProcess_Click(object sender, EventArgs e)
        {
            ChangeForm(lotProcessForm);
        }

        private void BtnErrorCompensation_Click(object sender, EventArgs e)
        {
            ChangeForm(errorCompensatioForm);
        }

        private void BtnMotionControl_Click(object sender, EventArgs e)
        {
            ChangeForm(motionControl);
        }

        private void BtnAlignment_Click(object sender, EventArgs e)
        {
            ChangeForm(alignmentForm);
        }

        private void BtnDeviceSettings_Click(object sender, EventArgs e)
        {
            ChangeForm(deviceDataSettingsForm);
        }

        private void BtnSetupUtility_Click(object sender, EventArgs e)
        {
            ChangeForm(utilityForm);
        }
        private void ChangeForm(Control form)
        {
            //Clear 和 Add会触发Control.VisibleChange事件两次，Visible从false到true            
            panelForm.Controls.Clear();
            panelForm.Controls.Add(form);
            form.Show();
            form.Dock = DockStyle.Fill;
        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Vision.CloseAllCamera();
            Motion.CloseCard();
        }

        private void BtnPadRegistration_Click(object sender, EventArgs e)
        {
            ChangeForm(padRegistrationFrom);//当没有静态变量需要保持时，可以用new Form();
        }

        private void BtnPinRegistration_Click(object sender, EventArgs e)
        {
            ChangeForm(pinRegistrationFrom);
        }

        private void BtnInspection_Click(object sender, EventArgs e)
        {
            ChangeForm(inspectionForm);
        }

        private void BtnManual_Click(object sender, EventArgs e)
        {
            ChangeForm(manualForm);
        }
    }
}