using CommonComponentLibrary;

namespace UtilityForm
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
           
        }

        private void BtnChuckCenter_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            panel2.Controls.Add(centerControl);
        }

        private void UtilityForm_ParentChanged(object sender, EventArgs e)
        {
            if (Parent!=null)
            {
                panel1.Controls.Clear();
                panel1.Controls.Add(CommonPanel.Entity);
            }
        }
    }
}
