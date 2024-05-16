using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeviceDataSettings
{
    public partial class WaferMapSettingDUT : UserControl
    {

        private readonly DUTCanvas _dut;
        public WaferMapSettingDUT(DUTCanvas dut)
        {
            InitializeComponent();
            _dut = dut;
        }

        private void WaferMapSettingDUT_Load(object sender, EventArgs e)
        {
            RefreshText();
            Location.TextChanged += Location_TextChanged;
            CardId.TextChanged += CardId_TextChanged;
        }

        private void CardId_TextChanged(object? sender, EventArgs e)
        {
            DUTData.Entity.CardId = CardId.Text;
        }

        private void Location_TextChanged(object? sender, EventArgs e)
        {
            DUTData.Entity.Location = Location.Text;
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
        }
        #endregion

    }
}
