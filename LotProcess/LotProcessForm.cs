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
            //顶级控件置为false，取消标题栏
            this.TopLevel = false; this.FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();

            GlobalContext.Properties["name"] = this.GetType().Name;//存log时，自定义文件名
            XmlConfigurator.Configure(new FileInfo("log4net.config"));//读取配置
        }

        private void BtnVision_Click(object sender, EventArgs e)
        {
            panelForm.Controls.Clear();
            VisionControl visionControl = new VisionControl();
            panelForm.Controls.Add(visionControl);
            visionControl.Dock = DockStyle.Right;

            panelForm.Controls.Add(CommonPanel.Entity);
        }

        private void LotProcessForm_Load(object sender, EventArgs e)
        {
            log.Debug("Entering LotProcessForm.");
            Dock = DockStyle.Fill;
        }

        private void LotProcessForm_ParentChanged(object sender, EventArgs e)
        {
            if (Parent != null)
            {
                panelForm.Controls.Clear();
            }

        }
    }
}
