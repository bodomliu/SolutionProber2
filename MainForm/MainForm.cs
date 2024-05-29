using log4net;
using log4net.Config;
using WaferMapLibrary;
using System.Windows.Forms;
using VisionLibrary;
using CommonComponentLibrary;
using MotionLibrary;
namespace MainForm
{
    public partial class MainForm : Form
    {
        // Define a static logger variable so that it references the
        // Logger instance named "MainForm".
        private static readonly ILog log = LogManager.GetLogger(typeof(MainForm));

        readonly LotProcessForm lotProcessForm = new ();
        readonly ErrorCompensationForm errorCompensatioForm = new();
        readonly MotionControl motionControl = new();
        readonly AlignmentForm alignmentForm = new();
        readonly DeviceDataSettingsForm deviceDataSettingsForm = new();
        readonly UtilityForm utilityForm = new();
        readonly PadRegistrationForm padRegistrationFrom = new();
        readonly PinRegistrationForm pinRegistrationFrom = new();
        readonly InspectionForm inspectionForm = new();
        readonly ManualForm manualForm = new();

        public MainForm()
        {
            InitializeComponent();
            // Set up a simple configuration that logs on the console.
            //BasicConfigurator.Configure();
            GlobalContext.Properties["name"] = this.GetType().Name;//ָ���ļ���
            XmlConfigurator.Configure(new FileInfo("log4net.config"));//��ȡ����

            log.Info("Entering application.");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //���������
            this.WindowState = FormWindowState.Maximized;

            Vision.Initial();
            Motion.Initial();
            Motion.MultiAxisOn(1, 4);
            Compensation.Initial();

            Controls.Add(WaitingControl.WF);
            panelForm.Controls.Add(lotProcessForm);
            panelForm.Controls.Add(errorCompensatioForm);
            panelForm.Controls.Add(motionControl);
            panelForm.Controls.Add(alignmentForm);
            panelForm.Controls.Add(deviceDataSettingsForm);
            panelForm.Controls.Add(utilityForm);
            panelForm.Controls.Add(padRegistrationFrom);
            panelForm.Controls.Add(pinRegistrationFrom);
            panelForm.Controls.Add(inspectionForm);
            panelForm.Controls.Add(manualForm);
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
            //Clear �� Add�ᴥ��Control.VisibleChange�¼����Σ�Visible��false��true            
            lotProcessForm.Hide();
            errorCompensatioForm.Hide();
            motionControl.Hide();
            alignmentForm.Hide();
            deviceDataSettingsForm.Hide();
            utilityForm.Hide();
            padRegistrationFrom.Hide();
            pinRegistrationFrom.Hide();
            inspectionForm.Hide();
            manualForm.Hide(); 
            
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
            ChangeForm(padRegistrationFrom);//��û�о�̬������Ҫ����ʱ��������new Form();
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