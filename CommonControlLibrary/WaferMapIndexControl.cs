using WaferMapLibrary;
using MotionLibrary;
using System;
namespace CommonComponentLibrary
{
    public partial class WaferMapIndexControl : UserControl
    {
        public WaferMapIndexControl(bool BtnMatchVisible = false)
        {
            InitializeComponent();
            BtnPinPadMatch.Visible = BtnMatchVisible;
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
            if (this.TxtIndexX.InvokeRequired || this.TxtIndexY.InvokeRequired)
            {
                SetIndexCallBack sicb = new SetIndexCallBack(onIndexChange);
                this.Invoke(sicb, new object[] { x, y });
            }
            else
            {
                TxtIndexX.Text = x.ToString();
                TxtIndexY.Text = y.ToString();
            }
        }
        delegate void SetIndexCallBack(int x, int y);

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

        private async void BtnEnter_Click(object sender, EventArgs e)
        {
            WaferMap.setCurrentIndex(int.Parse(TxtIndexX.Text), int.Parse(TxtIndexY.Text));
           
            WaitingControl.WF.Start();
            await Task.Run(() =>
            {
                CommonFunctions.IndexMove(Motion.CurrentArea, WaferMap.CurrentIndexX, WaferMap.CurrentIndexY);
            });
            WaitingControl.WF.End();
        }

        private async void BtnPinPadMatch_Click(object sender, EventArgs e)
        {
            WaitingControl.WF.Start();
            await Task.Run(() =>
            {
                CommonFunctions.PinPadMatch();
            });
            WaitingControl.WF.End();
        }
    }
}
