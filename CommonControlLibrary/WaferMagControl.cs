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

        private void UpdateUI()
        {
            if (Vision.activeCamera == Camera.WaferLowMag)
            {
                BtnLowMag.Enabled = false;
                BtnHighMag.Enabled = true;
            }
            else if (Vision.activeCamera == Camera.WaferHighMag)
            {
                BtnLowMag.Enabled = true;
                BtnHighMag.Enabled = false;
            }
            else
            {
                BtnLowMag.Enabled = true;
                BtnHighMag.Enabled = true;
            }
        }

        private void WaferMagControl_Load(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void BtnHighMag_Click(object sender, EventArgs e)
        {
            WaitingControl.WF.Start();
            Vision.ChangeCamera(Vision.WaferHighMag);
            Motion.TogglePosition(0);
            WaitingControl.WF.End();
            UpdateUI();
        }

        private void BtnLowMag_Click(object sender, EventArgs e)
        {
            WaitingControl.WF.Start();
            Vision.ChangeCamera(Vision.WaferLowMag);
            Motion.TogglePosition(1);
            WaitingControl.WF.End();
            UpdateUI();
        }
     }
}
