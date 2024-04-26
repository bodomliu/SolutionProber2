using CommonComponentLibrary;
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
    public partial class WaferMapSettingMargin : UserControl
    {
        private WaferMapCanvas _wmc;
        public WaferMapSettingMargin(WaferMapCanvas wmc)
        {
            InitializeComponent();
            _wmc = wmc;
            _left.KeyPress += this.CheckInteger;
            _right.KeyPress += this.CheckInteger;
            _top.KeyPress += this.CheckInteger;
            _bottom.KeyPress += this.CheckInteger;
        }

        public void Reload()
        {

            _left.Text = _wmc.MarginLeft.ToString();
            _right.Text = _wmc.MarginRight.ToString();
            _top.Text = _wmc.MarginTop.ToString();
            _bottom.Text = _wmc.MarginBottom.ToString();
            textBox.Text = WaferMap.Entity.DieNumX.ToString() + " * " + WaferMap.Entity.DieNumY.ToString();
        }

        private void WaferMapSettingMargin_Load(object sender, EventArgs e)
        {
            Reload();
        }

        private void Apply_Click(object sender, EventArgs e)
        {
            int left = int.Parse(_left.Text);
            int right = int.Parse(_right.Text);
            int top = int.Parse(_top.Text);
            int bottom = int.Parse(_bottom.Text);

            int deltaLeft = left - _wmc.MarginLeft;
            _wmc.MarginLeft = left;
            int deltaRight = right - _wmc.MarginRight;
            _wmc.MarginRight = right;
            int deltaTop = top - _wmc.MarginTop;
            _wmc.MarginTop = top;
            int deltaBottom = bottom - _wmc.MarginBottom;
            _wmc.MarginBottom = bottom;

            WaferMap.Entity.DieNumX = (WaferMap.Entity.DieNumX + deltaLeft + deltaRight);
            WaferMap.Entity.DieNumY = (WaferMap.Entity.DieNumY + deltaTop + deltaBottom);

            WaferMap.Entity.RefDieX += deltaLeft;
            WaferMap.Entity.RefDieY += deltaTop;

            _wmc.RefreshCanvas();
            textBox.Text = WaferMap.Entity.DieNumX.ToString() + " * " + WaferMap.Entity.DieNumY.ToString();
        }
    }
}
