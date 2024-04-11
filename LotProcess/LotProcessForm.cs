using log4net;
using log4net.Config;
using CommonComponentLibrary;

namespace MainForm
{
    public partial class LotProcessForm : Form
    {
        // Define a static logger variable so that it references the
        // Logger instance named "LotProcessForm".
        private static readonly ILog log = LogManager.GetLogger(typeof(LotProcessForm));
        public LotProcessForm()
        {
            //�����ؼ���Ϊfalse��ȡ��������
            this.TopLevel = false; this.FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();

            GlobalContext.Properties["name"] = this.GetType().Name;//��logʱ���Զ����ļ���
            XmlConfigurator.Configure(new FileInfo("log4net.config"));//��ȡ����
            

        }

        private void BtnVision_Click(object sender, EventArgs e)
        {
            //���commonPanel
            CommonPanel visionPanel = new CommonPanel();
            panelForm.Controls.Add(visionPanel);
            visionPanel.Dock = DockStyle.Fill;
        }

        private void LotProcessForm_Load(object sender, EventArgs e)
        {
            log.Debug("Entering LotProcessForm.");
        }
    }
}
