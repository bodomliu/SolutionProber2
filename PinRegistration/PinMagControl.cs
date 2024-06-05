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

namespace PinRegistration
{
    public partial class PinMagControl : UserControl
    {
        public PinMagControl()
        {
            InitializeComponent();
        }
        bool activeCameraIsPinMag = false;
        private void UpdateUI()
        {
            if (Vision.activeCamera == Camera.PinLowMag)
            {
                BtnLowMag.Enabled = false;
                BtnHighMag.Enabled = true;
                activeCameraIsPinMag = true;
            }
            else if (Vision.activeCamera == Camera.PinHighMag)
            {
                BtnLowMag.Enabled = true;
                BtnHighMag.Enabled = false;
                activeCameraIsPinMag = true;
            }
            else
            {
                BtnLowMag.Enabled = true;
                BtnHighMag.Enabled = true;
                activeCameraIsPinMag = false;//当前的激活相机不是Pin Mag
            }
        }
        private async void BtnHighMag_Click(object sender, EventArgs e)
        {
            WaitingControl.WF.Start();
            await Task.Run(() =>
            {
                Vision.ChangeCamera(Vision.PinHighMag);
                if (activeCameraIsPinMag) Motion.TogglePosition(2);//如果当前激活相机是Mag，则增加一个运动
            });
            WaitingControl.WF.End();
            UpdateUI();
        }
        private async void BtnLowMag_Click(object sender, EventArgs e)
        {
            WaitingControl.WF.Start();
            await Task.Run(() =>
            {
                Vision.ChangeCamera(Vision.PinLowMag);
                if (activeCameraIsPinMag) Motion.TogglePosition(3);//如果当前激活相机是Mag，则增加一个运动
            });
            WaitingControl.WF.End();
            UpdateUI();
        }

        private void PinMagControl_Load(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void BtnLowMag_VisibleChanged(object sender, EventArgs e)
        {
            //显示后，刷新下界面情况
            if(Visible) UpdateUI();
        }
    }
}
