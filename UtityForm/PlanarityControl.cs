using CommonComponentLibrary;
using MotionLibrary;
using System.Threading;
using UtilityForm;
using VisionLibrary;
using WaferMapLibrary;
namespace MainForm
{
    public partial class PlanarityControl : UserControl
    {
        public PlanarityControl()
        {
            InitializeComponent();
            panel1.Controls.Add(new WaferMagControl());
            //BtnResetAll.Visible = false;
            panelMap.Controls.Add(new PlanarityMap());
            panelHeight.Controls.Add(new PlanarityHeight());
        }
        private void PlanarityControl_Load(object sender, EventArgs e)
        {
            //默认是With Wafer模式
            RbtnWithWafer.Checked = true;

            //默认是WaferHighMag
            RbtnWaferCamera.Checked = true;
            Vision.ChangeCamera(Vision.WaferHighMag);

            Planarity.Load("Config/CPI.json");
            CbWaferSize.SelectedItem = "12";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Planarity.Save("Config/CPI.json", 12);
            MessageBox.Show("CPI Saved Successfully.");
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            Planarity.Load("Config/CPI.json");
            MessageBox.Show("CPI Loaded Successfully.");
        }
        private async void btnMove_Click(object sender, EventArgs e)
        {
            int index = 0;

            Button btnMove = (Button)sender;
            var item = btnMove.Tag.ToString();

            if (item != null)
            {
                index = int.Parse(item);
            }
            Planarity.Index = index;
            await Task.Run(() => Motion.XY_AxisMoveAbs(1, Planarity.PointsToSet[index].x, Planarity.PointsToSet[index].y, 600, 10, 10, 20));
        }
        private async void btnCheckAllPos_Click(object sender, EventArgs e)
        {
            if (Vision.activeCamera != Camera.WaferHighMag) { MessageBox.Show("Change Camre to High Mag"); return; }

            double Thickness = (RbtnNoWafer.Checked) ? 0 : DeviceData.Entity.PhysicalInformation.Thickness;

            WaitingControl.WF.Start();

            for (int i = 0; i < 9; i++)
            {
                //中断请求
                if (cts) { cts = false; WaitingControl.WF.End(); return; }

                var res = await Task.Run<int>(() =>
                {
                    if (RbtnWaferCamera.Checked) Motion.XY_AxisMoveAbs(1, Planarity.PointsToSet[i].x, Planarity.PointsToSet[i].y, 600, 10, 10, 20);
                    return CommonFunctions.AdjustWaferHeight(Thickness, Vision.WaferHighMag);
                });

                if (res != 0) { MessageBox.Show("Adjust Wafer Height wrong "); return; }

                Planarity.PointsToSet[i].z = Motion.GetEncPos(1, 3);
            }
            Planarity.UpdateHeightAndDiff();//更新下新的avg和diff
            WaitingControl.WF.End();
        }

        private bool cts = false;//中断任务
        private void BtnAbort_Click(object sender, EventArgs e)
        {
            cts = true;
        }
        private void btnUpdatePos_Click(object sender, EventArgs e)
        {
            Planarity.RegPosition(Planarity.Index, Motion.EncodeX, Motion.EncodeY);
            MessageBox.Show("Index " + Planarity.Index.ToString() + " PosX " + Motion.EncodeX.ToString()
                + " ; PosY " + Motion.EncodeY.ToString());
        }
        private async void BtnAdjustWaferHeight_Click(object sender, EventArgs e)
        {
            WaitingControl.WF.Start();
            double Thickness = (RbtnNoWafer.Checked) ? 0 : DeviceData.Entity.PhysicalInformation.Thickness;
            if (Vision.activeCamera == Camera.WaferLowMag)
            {
                await Task.Run(() => CommonFunctions.AdjustWaferHeight(Thickness, Vision.WaferLowMag));
            }
            else if (Vision.activeCamera == Camera.WaferHighMag)
            {
                await Task.Run(() => CommonFunctions.AdjustWaferHeight(Thickness, Vision.WaferHighMag));
            }
            WaitingControl.WF.End();
        }
        private void RbtnWaferCamera_CheckedChanged(object sender, EventArgs e)
        {
            if (RbtnWaferCamera.Checked) Vision.ChangeCamera(Vision.WaferHighMag);
            else if (RbtnJigCamera.Checked) Vision.ChangeCamera(Vision.JigCamera);
        }
        private void CbWaferSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (CbWaferSize.SelectedItem)
            {
                case "6":
                    Planarity.WaferSize = 6;
                    break;
                case "8":
                    Planarity.WaferSize = 8;
                    break;
                case "12":
                    Planarity.WaferSize = 12;
                    break;
                default:
                    throw new Exception("WaferSize must be 6/8/12");
            }
        }
        private void BtnResetAll_Click(object sender, EventArgs e)
        {
            Planarity.ResetAll("Config/CPI.json");
            MessageBox.Show("CPI.jason Reset!");
        }
        private void BtnRegHeight_Click(object sender, EventArgs e)
        {
            Planarity.RegHeight(Planarity.Index, Motion.EncodeZ);
            MessageBox.Show("Index " + Planarity.Index.ToString() + " Height " + Motion.EncodeZ.ToString());
        }
    }
}
