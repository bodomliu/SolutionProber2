using CommonComponentLibrary;

namespace MainForm
{
    public partial class UtilityForm : Form
    {
        CommonPanel commonpanel = new CommonPanel();
        public UtilityForm()
        {
            //�����ؼ���Ϊfalse��ȡ��������
            this.TopLevel = false; this.FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
            panel1.Controls.Add(commonpanel);
            panel2.Controls.Add(new PlanarityControl());
        }

        private void BtnChuckFlatness_Click(object sender, EventArgs e)
        {
            
        }
    }
}
