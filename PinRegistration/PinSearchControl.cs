using CommonComponentLibrary;
using MotionLibrary;
using VisionLibrary;
using WaferMapLibrary;
namespace PinRegistration
{
    public partial class PinSearchControl : UserControl
    {
        public PinSearchControl()
        {
            InitializeComponent();
        }
        private void PinSearchControl_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                int cnt = PadData.Entity.Pads.Count;
                LblIndex.Text = "Index: " + cnt.ToString();
                NumIndex.Maximum = cnt - 1;

                cnt = DUTData.Entity.DUTs.Count;
                LblDut.Text = "Dut: " + cnt.ToString();
                NumDut.Maximum = cnt - 1;

                cnt = PinData.Entity.Pins.Count;
                LblIndexTotal.Text = "Index Total: " + cnt.ToString();
                NumIndexTotal.Maximum = PinData.Entity.Pins.Count - 1;
            }
        }

        //根据PinData.currentIndex更新界面
        private void UpdateUI()
        {
            int indexTotal = PinData.CurrentIndex;//获得当前pin总序号
            int numEachSite = PadData.Entity.Pads.Count;//获得每个Site有多少根pin
            int dutCount = DUTData.Entity.DUTs.Count;//获得dut数

            int indexOfSite = indexTotal % numEachSite;//取余，得到是某个site第几号pin

            NumIndex.Value = indexOfSite;
            NumDut.Value = PinData.Entity.Pins[PinData.CurrentIndex].DUTindex;
            NumIndexTotal.Value = PinData.CurrentIndex;
        }
        private async void BtnGoToPin_Click(object sender, EventArgs e)
        {
            bool islowMode = (Vision.activeCamera == Camera.PinLowMag);
            WaitingControl.WF.Start();
            await Task.Run(() =>
            {
                int index = (int)NumIndexTotal.Value;
                PinAlignLib.GoToPin(index, islowMode);
            });
            WaitingControl.WF.End();
            UpdateUI();
        }
        private void PinSearchControl_Load(object sender, EventArgs e)
        {

        }
        private async void BtnGoToPrevPin_Click(object sender, EventArgs e)
        {
            if (PinData.Entity.Pins == null) return;
            int Index = (PinData.CurrentIndex <= 0) ? PinData.Entity.Pins.Count - 1 : PinData.CurrentIndex - 1;

            bool islowMode = (Vision.activeCamera == Camera.PinLowMag);
            WaitingControl.WF.Start();
            await Task.Run(() =>
            {
                PinAlignLib.GoToPin(Index, islowMode);
            });
            WaitingControl.WF.End();
            UpdateUI();
        }
        private async void BtnGoToRefPin_Click(object sender, EventArgs e)
        {
            bool islowMode = (Vision.activeCamera == Camera.PinLowMag);
            WaitingControl.WF.Start();
            await Task.Run(() =>
            {
                PinAlignLib.GoToPin(0, islowMode);
            });
            WaitingControl.WF.End();
            UpdateUI();
        }
        private async void BtnGoToNextPin_Click(object sender, EventArgs e)
        {
            if (PinData.Entity.Pins == null) return;
            int Index = (PinData.CurrentIndex >= PinData.Entity.Pins.Count - 1) ? 0 : PinData.CurrentIndex + 1;

            bool islowMode = (Vision.activeCamera == Camera.PinLowMag);
            WaitingControl.WF.Start();
            await Task.Run(() =>
            {
                PinAlignLib.GoToPin(Index, islowMode);
            });
            WaitingControl.WF.End();
            UpdateUI();
        }
        private async void BtnNeedleTipFocus_Click(object sender, EventArgs e)
        {
            if (Vision.activeCamera == Camera.PinLowMag)
            {
                //CommonFunctions.AdjustHeight(37000, 39000, Vision.PinLowMag);
                MessageBox.Show("Change to High Mag!"); return;
            }
            else if (Vision.activeCamera == Camera.PinHighMag)
            {
                WaitingControl.WF.Start();
                await Task.Run(() => AdjustHeight.PinFocus(false));
                WaitingControl.WF.End();
            }
        }
        private async void BtnMovePinToTheCenter_Click(object sender, EventArgs e)
        {
            WaitingControl.WF.Start();
            await Task.Run(() => PinAlignLib.MovePinToCenter());
            WaitingControl.WF.End();

            UpdateUI();
        }

        private void BtnTeachPin_Click(object sender, EventArgs e)
        {
            //获取当前位置
            Motion.XYZ_GetEncPos(out double encodeX, out double encodeY, out double encodeZ);

            PinData.Entity.Pins[PinData.CurrentIndex].CurrentPosX = encodeX - PinData.Entity.RefPinX;
            PinData.Entity.Pins[PinData.CurrentIndex].CurrentPosY = encodeY - PinData.Entity.RefPinY;
            PinData.Entity.Pins[PinData.CurrentIndex].CurrentPosZ = Motion.EncodeZ;

            PinData.Save(DeviceData.Entity.PinAlignment.PinDataPath);
            MessageBox.Show("The pin has been teached.");
            UpdateUI();
        }
        private void BtnNextFail_Click(object sender, EventArgs e)
        {

        }

        private void BtnPrevFail_Click(object sender, EventArgs e)
        {

        }

        private void NumDut_ValueChanged(object sender, EventArgs e)
        {
            ChangeIndexTotal();
        }

        private void NumIndex_ValueChanged(object sender, EventArgs e)
        {
            ChangeIndexTotal();
        }

        private void ChangeIndexTotal()
        {
            int dut = (int)NumDut.Value;
            int index = (int)NumIndex.Value;
            int numEachSite = PadData.Entity.Pads.Count;//获得每个Site有多少根pin 
            NumIndexTotal.Value = dut * numEachSite + index;
        }
    }
}
