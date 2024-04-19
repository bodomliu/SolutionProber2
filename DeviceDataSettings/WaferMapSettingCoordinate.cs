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
        }

        private void WaferMapSettingCoordinate_Load(object sender, EventArgs e)
        {
            leftOrRight.Text = WaferMap.Entity.DirectionX;
            upOrDown.Text = WaferMap.Entity.DirectionY;
            originX.Text = WaferMap.Entity.OriginDieX.ToString();
            originY.Text = WaferMap.Entity.OriginDieY.ToString();
        }

        private void leftOrRight_Click(object sender, EventArgs e)
        {
            string lr = leftOrRight.Text;
            if (lr == "RIGHT")
                lr = "LEFT";
            else
                lr = "RIGHT";

            WaferMap.Entity.DirectionX = lr;
            leftOrRight.Text = lr;
        }

        private void upOrDown_Click(object sender, EventArgs e)
        {
            string ud = upOrDown.Text;
            if (ud == "UP")
                ud = "DOWN";
            else
                ud = "UP";

            WaferMap.Entity.DirectionY = ud;
            upOrDown.Text = ud;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WaferMap.Entity.OriginDieX = int.Parse(originX.Text);
            WaferMap.Entity.OriginDieY = int.Parse(originY.Text);
            _wmc.RefreshCanvas();
        }
    }
}
