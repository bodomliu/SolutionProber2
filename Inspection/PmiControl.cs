using CommonComponentLibrary;
using JsonDataShow;
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

namespace Inspection
{
    public partial class PmiControl : UserControl
    {
        public PmiControl()
        {
            InitializeComponent();
            //this.Dock = DockStyle.Fill;
        }

        private void PmiControl_Load(object sender, EventArgs e)
        {

        }

        private void BtnPmiSetup_Click(object sender, EventArgs e)
        {
            JsonDataForm form = new JsonDataForm("DeviceData/0411DeviceData.json", DeviceData.Entity);
            DialogResult res = form.ShowDialog();
        }

        private async void BtnPmiOnSetDie_Click(object sender, EventArgs e)
        {
            WaitingControl.WF.Start();
            Vision.WaferHighMag.TriggerMode();
            await Task.Run(() =>
            {
                PmiSingle(WaferMap.CurrentIndexX, WaferMap.CurrentIndexY, PinData.CurrentIndex, true);
                Thread.Sleep(500);
            });
            Vision.WaferHighMag.ContinuesMode();
            WaitingControl.WF.End();
        }

        private void PmiSingle(int dieIndexX, int dieIndexY, int padIndex, bool saveImg,bool setToRef = false)
        {
            CommonFunctions.GotoPad(dieIndexX, dieIndexY, padIndex);
            Vision.WaferHighMag.TriggerExec();

            Vision.WaferHighMag.halconClass.GetProbeMark(
                DeviceData.Entity.ProbeMarkInspection.Threshold,
                DeviceData.Entity.ProbeMarkInspection.AreaPad,
                DeviceData.Entity.ProbeMarkInspection.AreaMark,
                out double top, out double bottom, out double left, out double right, out double deltaX, out double deltaY);

            Result item = new Result
            {
                DieIndexX = dieIndexX,
                DieIndexY = dieIndexY,
                PadIndex = padIndex,
                Top = top,
                Bottom = bottom,
                Left = left,
                Right = right,
                DeltaX = deltaX,
                DeltaY = deltaY,
            };
            PmiData.Results.Add(item);

            if (setToRef) PmiData.PmiRef.Add(item);

            UpdateUI(deltaX,deltaY);
            if (saveImg)
            {
                if (!Directory.Exists("Img"))
                {
                    Directory.CreateDirectory("Img");
                }
                string Path = System.Environment.CurrentDirectory + "/Img/"
                    + WaferMap.CurrentIndexX.ToString() + "_"
                    + WaferMap.CurrentIndexY.ToString() + "_"
                    + System.DateTime.Now.ToString("yyMMdd")
                    + System.DateTime.Now.ToString("HHmmss.bmp");
                Vision.WaferHighMag.halconClass.SaveResultImage(Path);
            }
        }
        delegate void SetIndexCallBack(double x, double y);
        private void UpdateUI(double x, double y)
        {
            if (this.TxtDeltaX.InvokeRequired || this.TxtDeltaY.InvokeRequired)
            {
                SetIndexCallBack sicb = new SetIndexCallBack(UpdateUI);
                this.Invoke(sicb, new object[] { x, y });
            }
            else
            {
                TxtDeltaX.Text = x.ToString("F0");
                TxtDeltaY.Text = y.ToString("F0");
            }
        }

        private void BtnClearResult_Click(object sender, EventArgs e)
        {
            PmiData.Results.Clear();
        }

        private void BtnShowResult_Click(object sender, EventArgs e)
        {
            PmiDataForm form = new();
            DialogResult res = form.ShowDialog();
        }

        private async void BtnPmiAll_Click(object sender, EventArgs e)
        {
            WaitingControl.WF.Start();
            Vision.WaferHighMag.TriggerMode();

            if (WaferMap.Entity.MappingPoints == null) return;
            List<MappingPoint> toChkPts = WaferMap.Entity.MappingPoints.Where(p => p.Order != 0).ToList();
            var sortList = toChkPts.OrderBy(o => o.Order).ToList();
            for (int i = 0; i < sortList.Count; i++)
            {
                await Task.Run(() =>
                {
                    PmiSingle(sortList[i].IndexX, sortList[i].IndexY, 0, true);
                });
            }
            Vision.WaferHighMag.ContinuesMode();
            WaitingControl.WF.End();
        }

        private async void BtnSetToRefPmi_Click(object sender, EventArgs e)
        {
            WaitingControl.WF.Start();
            Vision.WaferHighMag.TriggerMode();
            await Task.Run(() =>
            {
                PmiSingle(WaferMap.CurrentIndexX, WaferMap.CurrentIndexY, PinData.CurrentIndex, true,true);
            });
            Vision.WaferHighMag.ContinuesMode();
            WaitingControl.WF.End();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            PmiData.Save("Pmidata.json");
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            PmiData.Load("Pmidata.json");
        }
    }
}
