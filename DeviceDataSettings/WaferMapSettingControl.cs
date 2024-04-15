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

        private readonly WaferMapSetting_1 _wms1;
        public WaferMapSettingControl()
        {
            InitializeComponent();
            this._wms1 = new(_waferMap);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                panel2.Controls.Clear();
                panel2.Controls.Add(_wms1);
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            panel3.Controls.Add(_waferMap);
            _waferMap.LoadCanvas();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            panel2.Controls.Add(_wms1);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                panel2.Controls.RemoveAt(0);
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
    }
}
