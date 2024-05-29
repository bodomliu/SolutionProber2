using CommonComponentLibrary;
using UtilityForm;

namespace MainForm
{
    public partial class UtilityForm : Form
    {
        CenterControl centerControl = new CenterControl();
        public UtilityForm()
        {
            //顶级控件置为false，取消标题栏
            this.TopLevel = false; this.FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();

        }

        private void BtnChuckFlatness_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            panel2.Controls.Add(new PlanarityControl());
        }

        private void UtilityForm_VisibleChanged(object sender, EventArgs e)
        {
            if (panel1.Visible)
            {
                panel1.Controls.Add(CommonPanel.Entity);
            }
        }

        private void BtnChuckCenter_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            panel2.Controls.Add(centerControl);
        }
    }
}
