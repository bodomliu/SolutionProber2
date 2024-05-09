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
    public partial class WaferMapSettingStatus : UserControl
    {
        public WaferMapSettingStatus()
        {
            InitializeComponent();
        }

        public void Reload()
        {
            string s = "Device Name : " + DeviceData.Entity.PhysicalInformation.DeviceName + "\n"
                + "Wafer Size : " + WaferMap.Entity.WaferSize.ToString() + "\n"
                + "Die Size X : " + WaferMap.Entity.DieSizeX.ToString() + "\n"
                + "Die Size Y : " + WaferMap.Entity.DieSizeY.ToString() + "\n"
                + "Die Num X : " + WaferMap.Entity.DieNumX.ToString() + "\n"
                + "Die Num Y : " + WaferMap.Entity.DieNumX.ToString() + "\n"
                + "Ref Die X : " + WaferMap.Entity.RefDieX.ToString() + "\n"
                + "Ref Die Y : " + WaferMap.Entity.RefDieY.ToString() + "\n"
                + "Direction X : " + WaferMap.Entity.DirectionX.ToString() + "\n"
                + "Direction Y : " + WaferMap.Entity.DirectionY.ToString();


            this.statusText.Text = s;
        }

        private void WaferMapSettingStatus_Load(object sender, EventArgs e)
        {
            Reload();
        }
    }
}
