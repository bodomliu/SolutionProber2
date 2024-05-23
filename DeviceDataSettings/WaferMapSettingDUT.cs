using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WaferMapLibrary;

namespace DeviceDataSettings
{
    public partial class WaferMapSettingDUT : UserControl
    {

        private readonly DUTCanvas _dut;

        private WaferMapSettingProbingSequenceControl _psc;
        public WaferMapSettingDUT(DUTCanvas dut, WaferMapSettingProbingSequenceControl psc)
        {
            InitializeComponent();
            _dut = dut;
            _psc = psc;
            DUTData.OnIndexChange += DUTData_OnIndexChange;
        }

        private void DUTData_OnIndexChange()
        {
            var d = DUTData.Entity.DUTs.Find(x => x.X == DUTData.CurrentIndexX && x.Y == DUTData.CurrentIndexY);
            if (d == null)
            {
                ButtonEnable.Enabled = false;
                return;
            }
            ButtonEnable.Enabled = true;
            if (d.Enable)
            {
                ButtonEnable.Text = "Disable";
            }
            else
            {
                ButtonEnable.Text = "Enable";
            }
        }

        private void WaferMapSettingDUT_Load(object sender, EventArgs e)
        {
            RefreshText();
            TextBoxLocation.TextChanged += Location_TextChanged;
            CardId.TextChanged += CardId_TextChanged;
        }

        private void CardId_TextChanged(object? sender, EventArgs e)
        {
            DUTData.Entity.CardId = CardId.Text;
        }

        private void Location_TextChanged(object? sender, EventArgs e)
        {
            DUTData.Entity.Location = TextBoxLocation.Text;
        }

        private void RefreshText()
        {
            int maxX = DUTData.Entity.DUTs.Max(x => x.X);
            int minX = DUTData.Entity.DUTs.Min(x => x.X);
            int maxY = DUTData.Entity.DUTs.Max(x => x.Y);
            int minY = DUTData.Entity.DUTs.Min(x => x.Y);
            XSize.Text = maxX - minX + 1 + "";
            YSize.Text = maxY - minY + 1 + "";
            SiteNum.Text = DUTData.Entity.DUTs.Count + "";
        }

        public void Reload()
        {
            ButtonEdit.Enabled = true;
            ButtonAdd.Enabled = false;
            ButtonDelete.Enabled = false;

            CardId.Text = DUTData.Entity.CardId;
            TextBoxLocation.Text = DUTData.Entity.Location;
        }

        #region 按钮事件
        private void ButtonUP_Click(object sender, EventArgs e)
        {
            DUTData.CurrentIndexY--;
        }

        private void ButtonDown_Click(object sender, EventArgs e)
        {
            DUTData.CurrentIndexY++;
        }

        private void ButtonLeft_Click(object sender, EventArgs e)
        {
            DUTData.CurrentIndexX--;
        }

        private void ButtonRight_Click(object sender, EventArgs e)
        {
            DUTData.CurrentIndexX++;
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var d = DUTData.Entity.DUTs.Find(x => x.X == DUTData.CurrentIndexX && x.Y == DUTData.CurrentIndexY);
            if (d != null)
            {
                return;
            }
            DUTData.Entity.DUTs.Add(new DUT() { X = DUTData.CurrentIndexX, Y = DUTData.CurrentIndexY });
            _dut.RefreshCanvas();
            RefreshText();
            DUTData_OnIndexChange();
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (DUTData.CurrentIndexX == 0 && DUTData.CurrentIndexY == 0)
            {
                return;
            }
            var d = DUTData.Entity.DUTs.Find(x => x.X == DUTData.CurrentIndexX && x.Y == DUTData.CurrentIndexY);
            if (d == null)
            {
                return;
            }
            DUTData.Entity.DUTs.Remove(d);
            _dut.RefreshCanvas();
            RefreshText();
            DUTData_OnIndexChange();
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            ButtonAdd.Enabled = true;
            ButtonDelete.Enabled = true;
            ButtonEdit.Enabled = false;
            _psc.DeleteAll();
        }
        #endregion

        private void ButtonE_Click(object sender, EventArgs e)
        {
            var d = DUTData.Entity.DUTs.Find(x => x.X == DUTData.CurrentIndexX && x.Y == DUTData.CurrentIndexY);
            if (d == null)
            {
                return;
            }
            d.Enable = !d.Enable;
            DUTData_OnIndexChange();
            _dut.RefreshCanvas();
        }
    }
}
