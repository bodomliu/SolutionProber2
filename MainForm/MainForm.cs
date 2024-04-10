using CommonComponentLibrary;
using log4net;
using log4net.Config;
using MotionLibrary;
using VisionLibrary;

namespace MainForm
{
    public partial class MainForm : Form
    {
        // Define a static logger variable so that it references the
        // Logger instance named "MainForm".
        private static readonly ILog log = LogManager.GetLogger(typeof(MainForm));

        LotProcessForm lotProcessForm = new LotProcessForm();
        ErrorCompensationForm errorCompensatioForm = new ErrorCompensationForm();
        MotionControl motionControl = new MotionControl();
        AlignmentForm alignmentForm = new AlignmentForm();

        public MainForm()
        {
            InitializeComponent();
            // Set up a simple configuration that logs on the console.
            //BasicConfigurator.Configure();
            GlobalContext.Properties["name"] = this.GetType().Name;//指定文件名
            XmlConfigurator.Configure(new FileInfo("log4net.config"));//读取配置

            log.Info("Entering application.");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //主界面最大化
            this.WindowState = FormWindowState.Maximized;

            Vision.Initial();
            Motion.OpenCard();
            Motion.MultiAxisOn(1, 4);
            Compensation.Initial();
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

        private void ChangeForm(Control form)
        {
            panelForm.Controls.Clear();
            panelForm.Controls.Add(form);
            form.Show();
            form.Dock = DockStyle.Fill;
            //Console.WriteLine(panelForm.Controls.Count);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Vision.CloseAllCamera();
            Motion.CloseCard();
        }


    }
}
