using CommonComponentLibrary;
using VisionLibrary;
using MotionLibrary;
using WaferMapLibrary;
namespace PadRegistration
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
        private void UpdateUI()
        {
            if (PadData.Entity.Pads.Count > 0)
            {
                int index = PadData.CurrentIndex;
                lblFromRefPadX.Text = (PadData.Entity.Pads[index].PosX).ToString("F0");
                lblFromRefPadY.Text = (PadData.Entity.Pads[index].PosY).ToString("F0");
                lblFromDieOrgX.Text = (PadData.Entity.Pads[index].PosX + PadData.Entity.DieOrg2RefPadX).ToString("F0");
                lblFromDieOrgY.Text = (PadData.Entity.Pads[index].PosY + PadData.Entity.DieOrg2RefPadY).ToString("F0");
                TxtCurrentPad.Text = index.ToString();
                TxtTotalPad.Text = PadData.Entity.Pads.Count.ToString();
            }
            _padCanvas.DrawPad();
        }

        #region Registration
        private void btnRefPadReg_Click(object sender, EventArgs e)
        {
            //获得当前XY坐标
            Motion.XY_GetEncPos(out double RefPadX, out double RefPadY);
            CommonFunctions.LocateDie(WaferMap.CurrentIndexX, WaferMap.CurrentIndexY, out _, out _, out double X, out double Y);
            double DieOrg2RefPadX = RefPadX - X;
            double DieOrg2RefPadY = RefPadY - Y;
            string str = "DieOrg2RefPadX: " + PadData.Entity.DieOrg2RefPadX.ToString() + " → " + DieOrg2RefPadX.ToString() + "\r\n";
            str += "DieOrg2RefPadY: " + PadData.Entity.DieOrg2RefPadY.ToString() + " → " + DieOrg2RefPadY.ToString();

            DialogResult res = MessageBox.Show(str, "Caution", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (res == DialogResult.OK)
            {
                PadData.Entity.DieOrg2RefPadX = DieOrg2RefPadX;//encode值
                PadData.Entity.DieOrg2RefPadY = DieOrg2RefPadY;//encode值
            }
            if (PadData.Entity.Pads.Count == 0) PadData.Entity.Pads.Add(new Pad { PosX = 0, PosY = 0 });
            UpdateUI();
        }
        private void btnReadyToApply_Click(object sender, EventArgs e)
        {
            PadData.Save(DeviceData.Entity.PinAlignment.PadDataPath);
            MessageBox.Show("Pads Saved!");
        }
        private void btnAddPad_Click(object sender, EventArgs e)
        {
            //获得当前XY坐标
            EncodeFromRefPad(out double encodeX, out double encodeY);
            PadData.Entity.Pads.Add(new Pad { PosX = encodeX, PosY = encodeY });//标定用的坐标系，和探针卡方向相反
            PadData.CurrentIndex = PadData.Entity.Pads.Count - 1;
            UpdateUI();
        }
        private void btnUpdatePad_Click(object sender, EventArgs e)
        {
            //获得当前XY坐标
            EncodeFromRefPad(out double encodeX, out double encodeY);
            PadData.Entity.Pads[PadData.CurrentIndex].PosX = encodeX;
            PadData.Entity.Pads[PadData.CurrentIndex].PosY = encodeY;
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
            UpdateUI();
        }
        private void BtnInsertPad_Click(object sender, EventArgs e)
        {
            //获得当前XY坐标
            EncodeFromRefPad(out double encodeX, out double encodeY);
            PadData.Entity.Pads.Insert(PadData.CurrentIndex, new Pad { PosX = encodeX, PosY = encodeY });
            UpdateUI();
        }
        private void btnPadN_Click(object sender, EventArgs e)
        {
            //PadData.Entity.PadWidth--;
        }
        //获取当前Pad的注册坐标，当RefDie已存在时
        private void EncodeFromRefPad(out double encodeX, out double encodeY)
        {
            //获得当前XY坐标
            Motion.XY_GetEncPos(out encodeX, out encodeY);
            //获得当前die Org坐标
            CommonFunctions.LocateDie(WaferMap.CurrentIndexX, WaferMap.CurrentIndexY, out _, out _, out double OrgX, out double OrgY);
            encodeX -= OrgX + PadData.Entity.DieOrg2RefPadX;//以refdie为原点的坐标
            encodeY -= OrgY + PadData.Entity.DieOrg2RefPadY;//以refdie为原点的坐标
        }
        #endregion

        #region Searching
        private void btnRefDie_Click(object sender, EventArgs e)
        {
            //已好精定位，直接IndexMove
            bool isLowMode = (Vision.activeCamera == Camera.WaferLowMag);
            CommonFunctions.GoToDie(WaferMap.Entity.RefDieX, WaferMap.Entity.RefDieY, isLowMode);
        }
        private void btnRefPad_Click(object sender, EventArgs e)
        {
            WaitingControl.WF.Start();
            CommonFunctions.GotoPad(WaferMap.Entity.RefDieX, WaferMap.Entity.RefDieY, 0);
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
            //ROI临时放大
            Vision.WaferHighMag.halconClass.m_Roi.Resize2(512, 640,
                DeviceData.Entity.PinAlignment.PadWidth * 2, DeviceData.Entity.PinAlignment.PadHeight * 2);
            //找pad
            int res = Vision.WaferHighMag.halconClass.GetPad(DeviceData.Entity.ProbeMarkInspection.Threshold,
                DeviceData.Entity.PinAlignment.PadWidth * DeviceData.Entity.PinAlignment.PadHeight, out double DeltaX, out double DeltaY);
            //ROI恢复
            Vision.WaferHighMag.halconClass.m_Roi.Resize2(512, 640,
                DeviceData.Entity.PinAlignment.PadWidth, DeviceData.Entity.PinAlignment.PadHeight);
            Vision.WaferHighMag.ContinuesMode();

            if (res != 0) { MessageBox.Show("Move To Pad Error."); return; }
            Motion.XY_AxisMoveRel(1, Convert.ToInt32(DeltaX), Convert.ToInt32(DeltaY), 600, 10, 10, 20);
        }
        #endregion

        private void PadRegistrationForm_ParentChanged(object sender, EventArgs e)
        {
            if (Parent != null)
            {
                panel1.Controls.Clear();
                panel1.Controls.Add(CommonPanel.Entity);
                Vision.WaferHighMag.halconClass.m_Roi.Resize2(512, 640, DeviceData.Entity.PinAlignment.PadWidth, DeviceData.Entity.PinAlignment.PadHeight);
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
