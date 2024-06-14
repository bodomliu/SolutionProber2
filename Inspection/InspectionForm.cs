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

            PadData.OnIndexChange += PadData_OnIndexChange;
        }
        private void InspectionForm_Load(object sender, EventArgs e)
        {
            TxtShiftX.Text = DeviceData.Entity.Probing.ProbingShiftX.ToString();
            TxtShiftY.Text = DeviceData.Entity.Probing.ProbingShiftY.ToString();
        }

        delegate void SetIndexCallBack(int index);
        private void PadData_OnIndexChange(int index)
        {
            if (this.TxtIndex.InvokeRequired)
            {
                SetIndexCallBack sicb = new SetIndexCallBack(PadData_OnIndexChange);
                this.Invoke(sicb, new object[] { index });
            }
            else
            {
                this.TxtIndex.Text = index.ToString(); ;
            }
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
            CommonFunctions.GoToDie(WaferMap.CurrentIndexX, WaferMap.CurrentIndexY);
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
            if (Parent != null)
            {
                panel1.Controls.Clear();
                panel1.Controls.Add(CommonPanel.Entity);

                panelMap.Controls.Clear();
                WaferMapCanvas waferMapCanvas = WaferMapCanvas.Canvas;
                panelMap.Controls.Add(waferMapCanvas);
                waferMapCanvas.SetRatio(1, 1);
                waferMapCanvas.LoadCanvas();

                Vision.ChangeCamera(Camera.WaferHighMag);
            }
        }
        private void InspectionForm_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void BtnRotate_Click(object sender, EventArgs e)
        {
            double R = double.Parse(TxtAngle.Text);
            Motion.AxisMoveRel(1, 4, R, 600, 10, 10, 20);
        }

        private void BtnMoveWithAngle_Click(object sender, EventArgs e)
        {
            int Index = int.Parse(TxtAngle.Text);
            //获得当前Encode位置，因为后面算成encode补偿，所以直接用encode坐标得了
            Motion.XY_GetEncPos(out double encodeX, out double encodeY);
            //求pad因为旋转产生的位移
            CommonFunctions.RotatePoint(encodeX, encodeY, Motion.parameter.XROTATE, Motion.parameter.YROTATE,
                Index, out double Xout, out double Yout);
            Motion.XYZ_AxisMoveRel(1, Xout - encodeX, Yout - encodeY, 0, 600, 10, 10, 20);
        }

        private async void BtnCheckPads_Click(object sender, EventArgs e)
        {
            WaitingControl.WF.Start();
            if (!Directory.Exists("Img"))
            {
                Directory.CreateDirectory("Img");
            }
            Vision.WaferHighMag.TriggerMode();

            if (WaferMap.Entity.MappingPoints == null) return;
            //遍历ErrorMap，选取所有Coordinates = 1
            List<MappingPoint> toChkPts = WaferMap.Entity.MappingPoints.Where(p => p.Order != 0).ToList();
            var sortList = toChkPts.OrderBy(o => o.Order).ToList();
            for (int i = 0; i < sortList.Count; i++)
            {
                await Task.Run(() =>
                {
                    CommonFunctions.GotoPad(sortList[i].IndexX, sortList[i].IndexY, 0);
                });

                Vision.WaferHighMag.TriggerExec();

                string Path = System.Environment.CurrentDirectory + "/Img/"
                    + WaferMap.CurrentIndexX.ToString() + "_"
                    + WaferMap.CurrentIndexY.ToString() + "_"
                    + i.ToString() + "_"
                    + System.DateTime.Now.ToString("yyMMdd")
                    + System.DateTime.Now.ToString("HHmmss.bmp");
                Vision.WaferHighMag.halconClass.SaveResultImage(Path);
            }
            Vision.WaferHighMag.ContinuesMode();
            WaitingControl.WF.End();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            TxtShiftX.Text ="";
            TxtShiftY.Text = "";
            DeviceData.Entity.Probing.ProbingShiftX = 0;
            DeviceData.Entity.Probing.ProbingShiftY = 0;
        }
    }
}
