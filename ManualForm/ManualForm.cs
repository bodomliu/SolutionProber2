using ManualForm;

namespace ManualForm
{
    public partial class ManualForm : Form
    {
        public ManualForm()
        {
            this.TopLevel = false; this.FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
        }

        private void BtnProbing_Click(object sender, EventArgs e)
        {
            panelForm.Controls.Clear();
            panelForm.Controls.Add(new ProbingControl());
        }
    }
}
