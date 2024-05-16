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

        }

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
        }
    }
}
