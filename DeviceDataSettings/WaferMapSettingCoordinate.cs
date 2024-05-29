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
    public partial class WaferMapSettingCoordinate : UserControl
    {

        private readonly WaferMapCanvas _wmc;
        public WaferMapSettingCoordinate(WaferMapCanvas wmc)
        {
            InitializeComponent();
            this._wmc = wmc;
            originX.KeyPress += this.CheckInteger;
            originY.KeyPress += this.CheckInteger;
        }

        public void Reload()
        {
            leftOrRight.Text = WaferMap.Entity.DirectionX;
            upOrDown.Text = WaferMap.Entity.DirectionY;
            originX.Text = WaferMap.Entity.RefDieX.ToString();
            originY.Text = WaferMap.Entity.RefDieY.ToString();
        }

        private void WaferMapSettingCoordinate_Load(object sender, EventArgs e)
        {
            Reload();
        }

        private void LeftOrRight_Click(object sender, EventArgs e)
        {
            string lr = leftOrRight.Text;
            if (lr == "RIGHT")
                lr = "LEFT";
            else
                lr = "RIGHT";

            WaferMap.Entity.DirectionX = lr;
            leftOrRight.Text = lr;
        }

        private void UpOrDown_Click(object sender, EventArgs e)
        {
            string ud = upOrDown.Text;
            if (ud == "UP")
                ud = "DOWN";
            else
                ud = "UP";

            WaferMap.Entity.DirectionY = ud;
            upOrDown.Text = ud;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            WaferMap.Entity.RefDieX = int.Parse(originX.Text);
            WaferMap.Entity.RefDieY = int.Parse(originY.Text);
            _wmc.RefreshCanvas();
        }
    }
}
