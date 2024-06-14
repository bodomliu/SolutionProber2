using CommonComponentLibrary;
using MotionLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
                NumIndex.Maximum = PinData.Entity.Pins.Count - 1;
            }
        }
        private void UpdateUI()
        {
            int indexTotal = PinData.CurrentIndex;//获得当前pin总序号
            int numEachSite = PadData.Entity.Pads.Count;//获得每个Site有多少根pin
            int dutCount = DUTData.Entity.DUTs.Count;//获得dut数

            int indexOfDut = indexTotal / numEachSite;//除，得到pin属于几号dut
            int indexOfSite = indexTotal % numEachSite;//取余，得到是某个site第几号pin


            TxtIndex.Text = indexOfSite.ToString() + " / " + numEachSite.ToString();
            TxtDUT.Text = indexOfDut.ToString() + " / " + dutCount.ToString();
            NumIndex.Value = PinData.CurrentIndex;
        }
        private async void BtnGoToPin_Click(object sender, EventArgs e)
        {
            bool islowMode = (Vision.activeCamera == Camera.PinLowMag);
            WaitingControl.WF.Start();
            await Task.Run(() =>
            {
                int index = (int)NumIndex.Value;
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
                await Task.Run(() => CommonFunctions.AdjustPinHeight(false));
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
            //teach时候，如果是refpin则执行注册refpin，否则执行校准
            if (PinData.CurrentIndex == 0)
            {
                Motion.XYZ_GetEncPos(out double encodeX, out double encodeY, out double encodeZ);
                //当前RefPin的位置，是否需要保存呢？
                PinData.Entity.RefPinX = encodeX;
                PinData.Entity.RefPinY = encodeY;
                PinData.Entity.RefPinZ = encodeZ;
            }
            else 
            {
                //获得当前XY坐标
                Motion.GetUserPos(Compensation.Area.Probing, out double X, out double Y);
                Compensation.Transform(Compensation.Area.Probing, Compensation.Dir.Encode2User,
                    PinData.Entity.RefPinX, PinData.Entity.RefPinY, out double RefX, out double RefY);
                double posX = X - RefX;//以refpin为原点的坐标
                double posY = Y - RefY;//以refpin为原点的坐标

                PinData.Entity.Pins[PinData.CurrentIndex].CurrentPosX = -posX;//标定用的坐标系，和探针卡方向相反
                PinData.Entity.Pins[PinData.CurrentIndex].CurrentPosY = -posY;//标定用的坐标系，和探针卡方向相反
                PinData.Entity.Pins[PinData.CurrentIndex].CurrentPosZ = Motion.EncodeZ;
            }
           
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
    }
}
