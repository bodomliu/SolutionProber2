using CommonComponentLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeviceDataSettings
{
    public partial class WaferMapSettingControl : UserControl
    {

        private readonly WaferMapCanvas _waferMap = WaferMapCanvas.Canvas;

        private readonly WaferMapSettingBase _wmsb;

        private readonly WaferMapSettingMargin _wmsm;

        private readonly WaferMapSettingCoordinate _wmsc;

        private readonly WaferMapSettingMap _wmsmap;
        public WaferMapSettingControl()
        {
            InitializeComponent();
            this._wmsb = new(_waferMap);
            this._wmsm = new(_waferMap);
            this._wmsc = new(_waferMap);
            this._wmsmap = new(_waferMap);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            panel2.Controls.Add(_wmsb);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            panel3.Controls.Add(_waferMap);
            _waferMap.LoadCanvas();
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                panel2.Controls.Clear();
                panel2.Controls.Add(_wmsb);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                panel2.Controls.Clear();
                panel2.Controls.Add(_wmsm);
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                panel2.Controls.Clear();
                panel2.Controls.Add(_wmsc);
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            panel4.Controls.Add(new WaferMapIndexControl());
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            panel5.Controls.Add(new WaferMapColorCard());
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                panel2.Controls.Clear();
                panel2.Controls.Add(_wmsmap);
            }
        }
    }
}
