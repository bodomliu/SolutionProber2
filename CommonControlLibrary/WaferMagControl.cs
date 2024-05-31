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

namespace CommonComponentLibrary
{
    public partial class WaferMagControl : UserControl
    {
        public WaferMagControl()
        {
            InitializeComponent();
        }

        bool activeCameraIsWaferMag = false;
        private void UpdateUI()
        {
            if (Vision.activeCamera == Camera.WaferLowMag)
            {
                BtnLowMag.Enabled = false;
                BtnHighMag.Enabled = true;
                activeCameraIsWaferMag = true;
            }
            else if (Vision.activeCamera == Camera.WaferHighMag)
            {
                BtnLowMag.Enabled = true;
                BtnHighMag.Enabled = false;
                activeCameraIsWaferMag = true;
            }
            else
            {
                BtnLowMag.Enabled = true;
                BtnHighMag.Enabled = true;
                activeCameraIsWaferMag = false;//当前的激活相机不是wafer Mag
            }
        }

        private void WaferMagControl_Load(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private async void BtnHighMag_Click(object sender, EventArgs e)
        {
            WaitingControl.WF.Start();
            await Task.Run(() =>
            {
                Vision.ChangeCamera(Vision.WaferHighMag);
                if(activeCameraIsWaferMag)Motion.TogglePosition(0);//如果当前激活相机是Mag，则增加一个运动
            });
            WaitingControl.WF.End();
            UpdateUI();
        }

        private async void BtnLowMag_Click(object sender, EventArgs e)
        {
            WaitingControl.WF.Start();
            await Task.Run(() =>
            {
                Vision.ChangeCamera(Vision.WaferLowMag);
                if (activeCameraIsWaferMag) Motion.TogglePosition(1);//如果当前激活相机是Mag，则增加一个运动
            });
            WaitingControl.WF.End();
            UpdateUI();
        }

        private void WaferMagControl_ParentChanged(object sender, EventArgs e)
        {

        }

        private void WaferMagControl_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                UpdateUI();
            }
        }
    }
}
