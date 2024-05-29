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
using WaferMapLibrary;
namespace DeviceDataSettings
{
    public partial class WaferMapSettingControl : UserControl
    {

        private readonly WaferMapCanvas _waferMap = WaferMapCanvas.Canvas;

        private readonly WaferMapSettingBase _wmsb;

        private readonly WaferMapSettingMargin _wmsm;

        private readonly WaferMapSettingCoordinate _wmsc;

        private readonly WaferMapSettingMap _wmsmap;

        private readonly WaferMapSettingStatus _wmss;

        private readonly WaferMapSettingProbingSequenceControl _wmsps;

        private readonly WaferMapSettingDUT _wmsDUT;

        private readonly DUTCanvas dUTCanvas;
        public WaferMapSettingControl()
        {
            InitializeComponent();
            dUTCanvas = new();
            _waferMap.MouseClickDefineCurrentIndex = true;
            this._wmsb = new(_waferMap);
            this._wmsm = new(_waferMap);
            this._wmsc = new(_waferMap);
            this._wmsmap = new(_waferMap);
            this._wmss = new();
            this._wmsps = new(_waferMap);
            _wmsDUT = new(dUTCanvas, _wmsps);
            WaferMap.OnWaferMapChange += WaferMap_OnWaferMapChange;
        }

        private void WaferMap_OnWaferMapChange()
        {
            _waferMap.LoadCanvas();
            _wmsb.ReLoad();
            _wmsm.Reload();
            _wmsc.Reload();
            _wmsmap.Reload();
        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {
            panel2.Controls.Add(_wmsb);
        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {
            panel3.Controls.Add(_waferMap);
            _waferMap.LoadCanvas();
        }
        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                panel2.Controls.Clear();
                panel2.Controls.Add(_wmsb);
                _wmsb.ReLoad();
            }
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                panel2.Controls.Clear();
                panel2.Controls.Add(_wmsm);
                _wmsm.Reload();
            }
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                panel2.Controls.Clear();
                panel2.Controls.Add(_wmsc);
                _wmsc.Reload();
            }
        }

        private void Panel4_Paint(object sender, PaintEventArgs e)
        {
            panel4.Controls.Add(new WaferMapIndexControl());
        }

        private void Panel5_Paint(object sender, PaintEventArgs e)
        {
            panel5.Controls.Add(new WaferMapColorCard());
        }

        private void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                panel2.Controls.Clear();
                panel2.Controls.Add(_wmsmap);
                _wmsmap.Reload();
            }
        }

        private void RadioButton7_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                panel2.Controls.Clear();
                panel2.Controls.Add(_wmss);
                _wmss.Reload();
            }
        }

        private void RadioButton6_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                panel2.Controls.Clear();
                panel2.Controls.Add(_wmsps);
                _wmsps.Reload();
            }
            else
            {
                _wmsps.Unload();
            }
        }


        private void RadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                panel2.Controls.Clear();
                panel2.Controls.Add(_wmsDUT);
                _wmsDUT.Reload();

                panel3.Controls.Clear();
                panel3.Controls.Add(dUTCanvas);
                dUTCanvas.RefreshCanvas();
            }
            else
            {
                panel2.Controls.Clear();
                panel3.Controls.Clear();
                panel3.Controls.Add(_waferMap);
            }
        }
    }
}
