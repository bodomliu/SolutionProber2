using CommonComponentLibrary;
using VisionLibrary;
using MotionLibrary;
using WaferMapLibrary;
namespace MainForm
{
    public partial class PadRegistrationForm : Form
    {
        public PadRegistrationForm()
        {
            this.TopLevel = false; this.FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
            panel2.Controls.Add(new PadControl());
            //WaferMapLibrary.LoadPads("Pad.json");
        }

        private void PadRegistrationForm_Load(object sender, EventArgs e)
        {


        }

        private void btnRefPadReg_Click(object sender, EventArgs e)
        {
            //获得当前XY坐标
            Motion.GetUserPos(Compensation.Area.Align, out double RefPadX, out double RefPadY);
            CommonFunctions.IndexUserPosAfterAlign(WaferMap.CurrentIndexX, WaferMap.CurrentIndexY, out double X, out double Y);
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
        }

        private void UpdateUI()
        {
            //Motion.GetUserPos(Compensation.Area.Align, out double usrX, out double usrY);
            //lblFromDieOrgX.Text = ((int)(usrX - WaferMapLibrary.Entity.RefDieUserPosX)).ToString();
            //lblFromDieOrgY.Text = ((int)(usrY - WaferMapLibrary.Entity.RefDieUserPosY)).ToString();
            //lblFromRefPadX.Text = ((int)(usrX - WaferMapLibrary.Entity.RefPadUserPosX)).ToString();
            //lblFromRefPadY.Text = ((int)(usrY - WaferMapLibrary.Entity.RefPadUserPosY)).ToString();

            TxtTotalPad.Text = PadData.Entity.Pads.Count.ToString();
        }

        private void btnReadyToApply_Click(object sender, EventArgs e)
        {
            PadData.SavePads(DeviceData.Entity.PinAlignment.PadDataPath);
            MessageBox.Show("Pads Saved!");
        }

        private void BtnHighMag_Click(object sender, EventArgs e)
        {
            Vision.ChangeCamera(Vision.WaferHighMag);
            Motion.TogglePosition(0);
            BtnLowMag.Enabled = true; BtnHighMag.Enabled = false;
            //Vision.WaferHighMag.halconClass.bDisplayPad = true;
        }
        private void BtnLowMag_Click(object sender, EventArgs e)
        {
            //Vision.WaferHighMag.halconClass.bDisplayPad = false;
            Vision.ChangeCamera(Vision.WaferLowMag);
            Motion.TogglePosition(1);
            BtnLowMag.Enabled = false; BtnHighMag.Enabled = true;
        }

        private void btnUpdatePad_Click(object sender, EventArgs e)
        {
            PadData.Entity.Pads.Add(new Pad { PosX = 0, PosY = 10 });
            UpdateUI();
        }

        private void btnDeleteAllPad_Click(object sender, EventArgs e)
        {
            PadData.Entity.Pads.Clear();
            PadData.Entity.Pads = new List<Pad> { };
            UpdateUI();
        }

        private void btnDeletePad_Click(object sender, EventArgs e)
        {
            if (PadData.Entity.Pads == null) return;
            PadData.Entity.Pads.RemoveAt(PadData.CurrentIndex);
        }

        private void BtnInsertPad_Click(object sender, EventArgs e)
        {
            PadData.Entity.Pads.Insert(PadData.CurrentIndex, new Pad { PosX = 0, PosY = 10 });
            UpdateUI();
        }

        private void PadRegistrationForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible) panel1.Controls.Add(CommonPanel.Entity);
        }

        public static void MoveToPad()
        {
            Vision.WaferHighMag.TriggerMode();
            Vision.WaferHighMag.TriggerExec();

            int res = Vision.WaferHighMag.halconClass.FindShapeModelPad(DeviceData.Entity.PinAlignment.PadPatten,
                0, out double DeltaX, out double DeltaY,out double[] X, out double[] Y, out double[] Angle, out double[] Score);
            if (res != 0) { MessageBox.Show("Move To Pad Error."); return; }

            Motion.XYZ_AxisMoveRel(1, Convert.ToInt32(DeltaX), Convert.ToInt32(DeltaY), 0, 600, 10, 10, 20);
            Vision.WaferHighMag.ContinuesMode();
        }
    }
}
