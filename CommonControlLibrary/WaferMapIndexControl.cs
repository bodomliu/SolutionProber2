using WaferMapLibrary;
using MotionLibrary;
namespace CommonComponentLibrary
{
    public partial class WaferMapIndexControl : UserControl
    {
        public WaferMapIndexControl()
        {
            InitializeComponent();
        }

        private void WaferMapIndexControl_Load(object sender, EventArgs e)
        {
            UpdateIndex();
            WaferMap.OnIndexChange += onIndexChange;
            ParentForm.FormClosed += (sender, e) =>
            {
                Dispose(true);
            };
        }

        private void onIndexChange(int x, int y)
        {
            TxtIndexX.Text = x.ToString();
            TxtIndexY.Text = y.ToString();
        }

        public void UpdateIndex()
        {
            TxtIndexX.Text = WaferMap.CurrentIndexX.ToString();
            TxtIndexY.Text = WaferMap.CurrentIndexY.ToString();
        }

        private void BtnUp_Click(object sender, EventArgs e)
        {
            WaferMap.CurrentIndexY--;
            //UpdateIndex();
        }

        private void BtnDown_Click(object sender, EventArgs e)
        {
            WaferMap.CurrentIndexY++;
            //UpdateIndex();
        }

        private void BtnLeft_Click(object sender, EventArgs e)
        {
            WaferMap.CurrentIndexX--;
            //UpdateIndex();
        }

        private void BtnRight_Click(object sender, EventArgs e)
        {
            WaferMap.CurrentIndexX++;
            //UpdateIndex();
        }

        private void WaferMapIndexControl_Paint(object sender, PaintEventArgs e)
        {
            //UpdateIndex();
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            WaferMap.setCurrentIndex(int.Parse(TxtIndexX.Text), int.Parse(TxtIndexY.Text));
            CommonFunctions.IndexMove(Motion.CurrentArea, WaferMap.CurrentIndexX, WaferMap.CurrentIndexY);
        }
    }
}
