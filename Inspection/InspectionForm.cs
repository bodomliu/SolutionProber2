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
using CommonComponentLibrary;
using MotionLibrary;
using WaferMapLibrary;

namespace MainForm
{
    public partial class InspectionForm : Form
    {
        public InspectionForm()
        {
            this.TopLevel = false; this.FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
            panelCamera.Controls.Add(new WaferMagControl());
            paneIndexControl.Controls.Add(new WaferMapIndexControl());

            WaferMapCanvas waferMapCanvas = WaferMapCanvas.Canvas;
            panelMap.Controls.Add(waferMapCanvas);
            waferMapCanvas.SetRatio(1, 1);
            waferMapCanvas.LoadCanvas();

            PadData.OnIndexChange += PadData_OnIndexChange;
        }

        private void InspectionForm_Load(object sender, EventArgs e)
        {
            TxtShiftX.Text = DeviceData.Entity.Probing.ProbingShiftX.ToString();
            TxtShiftY.Text = DeviceData.Entity.Probing.ProbingShiftY.ToString();
        }
        private void PadData_OnIndexChange(int index)
        {
            TxtIndex.Text = index.ToString();
        }

        private void btnNextPad_Click(object sender, EventArgs e)
        {
            if (PadData.Entity.Pads == null) return;
            int Index = (PadData.CurrentIndex >= PadData.Entity.Pads.Count - 1) ? 0 : PadData.CurrentIndex + 1;
            WaitingControl.WF.Start();
            CommonFunctions.GotoPad(WaferMap.CurrentIndexX, WaferMap.CurrentIndexY, Index);
            WaitingControl.WF.End();
        }

        private void btnPrevPad_Click(object sender, EventArgs e)
        {
            if (PadData.Entity.Pads == null) return;
            int Index = (PadData.CurrentIndex <= 0) ? PadData.Entity.Pads.Count - 1 : PadData.CurrentIndex - 1;
            WaitingControl.WF.Start();
            CommonFunctions.GotoPad(WaferMap.CurrentIndexX, WaferMap.CurrentIndexY, Index);
            WaitingControl.WF.End();
        }
        private void btnMoveToPad_Click(object sender, EventArgs e)
        {
            int Index = int.Parse(TxtIndex.Text);
            WaitingControl.WF.Start();
            CommonFunctions.GotoPad(WaferMap.CurrentIndexX, WaferMap.CurrentIndexY, Index);
            WaitingControl.WF.End();
        }

        private void BtnMoveToDie_Click(object sender, EventArgs e)
        {
            CommonFunctions.IndexMove(Compensation.Area.Align, WaferMap.CurrentIndexX, WaferMap.CurrentIndexY);
        }
        private double SetFromX = 0;
        private double SetFromY = 0;
        private void BtnSetFrom_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
            {
                timer1.Interval = 500;
                timer1.Enabled = true;
                Motion.XY_GetEncPos(out SetFromX, out SetFromY);
            }
            else
            {
                Motion.XY_GetEncPos(out double ToX, out double ToY);
                TxtShiftX.Text = (ToX - SetFromX).ToString();
                TxtShiftY.Text = (ToY - SetFromY).ToString();
                timer1.Enabled = false;
                BtnSetFrom.BackColor = Color.White;
            }

        }
        private void BtnApply_Click(object sender, EventArgs e)
        {
            DeviceData.Entity.Probing.ProbingShiftX = double.Parse(TxtShiftX.Text);
            DeviceData.Entity.Probing.ProbingShiftY = double.Parse(TxtShiftY.Text);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (BtnSetFrom.BackColor != Color.Red) BtnSetFrom.BackColor = Color.Red;
            else BtnSetFrom.BackColor = Color.White;
        }
        private void InspectionForm_ParentChanged(object sender, EventArgs e)
        {
            
        }

        private void InspectionForm_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                panel1.Controls.Clear();
                panel1.Controls.Add(CommonPanel.Entity);
            }
        }
    }
}
