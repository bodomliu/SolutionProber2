﻿using CommonComponentLibrary;
using VisionLibrary;
using MotionLibrary;
using WaferMapLibrary;
namespace MainForm
{
    public partial class PadRegistrationForm : Form
    {
        private readonly PadCanvas _padCanvas = new();
        public PadRegistrationForm()
        {
            this.TopLevel = false; this.FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
            panel2.Controls.Add(_padCanvas);
            panelMag.Controls.Add(new WaferMagControl());
            //WaferMapLibrary.Load("Pad.json");
        }
        private void PadRegistrationForm_Load(object sender, EventArgs e)
        {
            PadData.OnIndexChange += PadData_OnIndexChange;
        }
        private void PadData_OnIndexChange(int index)
        {
            UpdateUI();
        }
        private void btnRefPadReg_Click(object sender, EventArgs e)
        {
            //获得当前XY坐标
            Motion.GetUserPos(Compensation.Area.Align, out double RefPadX, out double RefPadY);
            CommonFunctions.LocateDie(WaferMap.CurrentIndexX, WaferMap.CurrentIndexY, out double X, out double Y,out _,out _);
            double DieOrg2RefPadX = RefPadX - X;
            double DieOrg2RefPadY = RefPadY - Y;
            string str = "DieOrg2RefPadX: " + PadData.Entity.DieOrg2RefPadX.ToString() + " → " + DieOrg2RefPadX.ToString() + "\r\n";
            str += "DieOrg2RefPadY: " + PadData.Entity.DieOrg2RefPadY.ToString() + " → " + DieOrg2RefPadY.ToString();

            DialogResult res = MessageBox.Show(str, "Caution", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (res == DialogResult.OK)
            {
                PadData.Entity.DieOrg2RefPadX = DieOrg2RefPadX;
                PadData.Entity.DieOrg2RefPadY = DieOrg2RefPadY;
                Vision.WaferHighMag.halconClass.CreateShapeModel(DeviceData.Entity.PinAlignment.PadPatten);
            }
            PadData.Entity.Pads.Add(new Pad { PosX = 0, PosY = 0 });
            UpdateUI();
        }
        private void UpdateUI()
        {
            if (PadData.Entity.Pads.Count > 0)
            {
                lblFromRefPadX.Text = (PadData.Entity.Pads[PadData.CurrentIndex].PosX).ToString("F0");
                lblFromRefPadY.Text = (PadData.Entity.Pads[PadData.CurrentIndex].PosY).ToString("F0");
                lblFromDieOrgX.Text = (PadData.Entity.Pads[PadData.CurrentIndex].PosX + PadData.Entity.DieOrg2RefPadX).ToString("F0");
                lblFromDieOrgY.Text = (PadData.Entity.Pads[PadData.CurrentIndex].PosY + PadData.Entity.DieOrg2RefPadY).ToString("F0");
                TxtCurrentPad.Text = PadData.CurrentIndex.ToString();
                TxtTotalPad.Text = PadData.Entity.Pads.Count.ToString();
            }
            _padCanvas.DrawPad();
        }
        private void btnReadyToApply_Click(object sender, EventArgs e)
        {
            PadData.Save(DeviceData.Entity.PinAlignment.PadDataPath);
            MessageBox.Show("Pads Saved!");
        }
        private void btnAddPad_Click(object sender, EventArgs e)
        {
            //获得当前XY坐标
            Motion.GetUserPos(Compensation.Area.Align, out double RefPadX, out double RefPadY);
            CommonFunctions.LocateDie(WaferMap.CurrentIndexX, WaferMap.CurrentIndexY, out double OrgX, out double OrgY,out _,out _);
            double posX = RefPadX - (OrgX + PadData.Entity.DieOrg2RefPadX);//以refdie为原点的坐标
            double posY = RefPadY - (OrgY + PadData.Entity.DieOrg2RefPadY);//以refdie为原点的坐标

            PadData.Entity.Pads.Add(new Pad { PosX = posX, PosY = posY });
            PadData.CurrentIndex = PadData.Entity.Pads.Count - 1;
            UpdateUI();
        }
        private void btnUpdatePad_Click(object sender, EventArgs e)
        {
            //获得当前XY坐标
            Motion.GetUserPos(Compensation.Area.Align, out double RefPadX, out double RefPadY);
            CommonFunctions.LocateDie(WaferMap.CurrentIndexX, WaferMap.CurrentIndexY, out double OrgX, out double OrgY, out _, out _);
            double posX = RefPadX - (OrgX + PadData.Entity.DieOrg2RefPadX);//以refdie为原点的坐标
            double posY = RefPadY - (OrgY + PadData.Entity.DieOrg2RefPadY);//以refdie为原点的坐标

            PadData.Entity.Pads[PadData.CurrentIndex].PosX = posX;
            PadData.Entity.Pads[PadData.CurrentIndex].PosY = posY;
            UpdateUI();
        }
        private void btnDeleteAllPad_Click(object sender, EventArgs e)
        {
            PadData.Entity.Pads.Clear();//TODO test if ok
            PadData.Entity.Pads = new List<Pad> { };
            PadData.CurrentIndex = 0;
            UpdateUI();
        }
        private void btnDeletePad_Click(object sender, EventArgs e)
        {
            if (PadData.Entity.Pads == null) return;
            PadData.Entity.Pads.RemoveAt(PadData.CurrentIndex);
        }
        private void BtnInsertPad_Click(object sender, EventArgs e)
        {
            //获得当前XY坐标
            Motion.GetUserPos(Compensation.Area.Align, out double RefPadX, out double RefPadY);
            CommonFunctions.LocateDie(WaferMap.CurrentIndexX, WaferMap.CurrentIndexY, out double OrgX, out double OrgY, out _, out _);
            double posX = RefPadX - (OrgX + PadData.Entity.DieOrg2RefPadX);//以refdie为原点的坐标
            double posY = RefPadY - (OrgY + PadData.Entity.DieOrg2RefPadY);//以refdie为原点的坐标

            PadData.Entity.Pads.Insert(PadData.CurrentIndex, new Pad { PosX = posX, PosY = posY });
            UpdateUI();
        }
        private void btnPadN_Click(object sender, EventArgs e)
        {
            //PadData.Entity.PadWidth--;
        }
        private void btnRefPad_Click(object sender, EventArgs e)
        {
            WaitingControl.WF.Start();
            CommonFunctions.GotoPad(WaferMap.Entity.RefDieX, WaferMap.Entity.RefDieY, 0);
            WaitingControl.WF.End();
        }
        private void btnRefDie_Click(object sender, EventArgs e)
        {
            //已好精定位，直接IndexMove
            CommonFunctions.IndexMove(Compensation.Area.Align, WaferMap.Entity.RefDieX, WaferMap.Entity.RefDieY);
        }
        private void btnPrevPad_Click(object sender, EventArgs e)
        {
            if (PadData.Entity.Pads == null) return;
            int Index = (PadData.CurrentIndex <= 0) ? PadData.Entity.Pads.Count - 1 : PadData.CurrentIndex - 1;
            WaitingControl.WF.Start();
            CommonFunctions.GotoPad(WaferMap.CurrentIndexX, WaferMap.CurrentIndexY, Index);
            WaitingControl.WF.End();
        }
        private void btnNextPad_Click(object sender, EventArgs e)
        {
            if (PadData.Entity.Pads == null) return;
            int Index = (PadData.CurrentIndex >= PadData.Entity.Pads.Count - 1) ? 0 : PadData.CurrentIndex + 1;
            WaitingControl.WF.Start();
            CommonFunctions.GotoPad(WaferMap.CurrentIndexX, WaferMap.CurrentIndexY, Index);
            WaitingControl.WF.End();
        }
       
        private void btnMoveToPad_Click(object sender, EventArgs e)
        {
            Vision.WaferHighMag.TriggerMode();
            Vision.WaferHighMag.TriggerExec();

            int res = Vision.WaferHighMag.halconClass.FindShapeModel(DeviceData.Entity.PinAlignment.PadPatten,
                0, PadData.Entity.PadWidth, PadData.Entity.PadHeight, out double DeltaX, out double DeltaY);
            if (res != 0) { MessageBox.Show("Move To Pad Error."); return; }

            Motion.XY_AxisMoveRel(1, Convert.ToInt32(DeltaX), Convert.ToInt32(DeltaY), 600, 10, 10, 20);
            Vision.WaferHighMag.ContinuesMode();
        }
        private void PadRegistrationForm_ParentChanged(object sender, EventArgs e)
        {
            if (Parent!=null)
            {
                panel1.Controls.Clear();
                panel1.Controls.Add(CommonPanel.Entity);               
                Vision.WaferHighMag.halconClass.m_Roi.Resize2(512, 640, PadData.Entity.PadWidth, PadData.Entity.PadHeight);
                Vision.WaferHighMag.halconClass.m_Roi.Color = "green";
                UpdateUI();
            }
            else
            {
                Vision.WaferHighMag.halconClass.m_Roi.Resize2(512, 640, 400, 400);
                Vision.WaferHighMag.halconClass.m_Roi.Color = "red";
            }
        }

        private void PadRegistrationForm_VisibleChanged(object sender, EventArgs e)
        {
            

        }
    }
}
