using CommonComponentLibrary;

namespace MainForm
{
    public partial class UtilityForm : Form
    {
        public UtilityForm()
        {
            //�����ؼ���Ϊfalse��ȡ��������
            this.TopLevel = false; this.FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
            
            panel2.Controls.Add(new PlanarityControl());
        }

        private void BtnChuckFlatness_Click(object sender, EventArgs e)
        {

        }

        private void UtilityForm_VisibleChanged(object sender, EventArgs e)
        {
            if (panel1.Visible)
            {
                panel1.Controls.Add(CommonPanel.Entity);
            }
        }
    }
}
