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
    public partial class WaferMapSettingMap : UserControl
    {

        private readonly WaferMapCanvas _waferMap;

        public WaferMapSettingMap(WaferMapCanvas waferMap)
        {
            InitializeComponent();
            this._waferMap = waferMap;
        }

        private void generationButton_Click(object sender, EventArgs e)
        {
            WaferMap.Entity.MappingPoints?.Clear();
            WaferMap.Entity.MappingPoints = new List<MappingPoint>();

            WaferMapCanvas.CircleCentre(out double ccx, out double ccy);

            for (int i = 0; i < WaferMap.Entity.DieNumX; i++)
            {
                for (int j = 0; j < WaferMap.Entity.DieNumY; j++)
                {
                    MappingPoint mp = new MappingPoint();
                    mp.IndexX = i;
                    mp.IndexY = j;

                    double pointX = WaferMap.Entity.DieSizeX * i;
                    double pointY = WaferMap.Entity.DieSizeY * j;
                    int count = 0;
                    if (Math.Pow(pointX - ccx, 2) + Math.Pow(pointY - ccy, 2) < Math.Pow(WaferMap.Entity.WaferDiameter / 2, 2))
                        count++;
                    pointX += WaferMap.Entity.DieSizeX;
                    if (Math.Pow(pointX - ccx, 2) + Math.Pow(pointY - ccy, 2) < Math.Pow(WaferMap.Entity.WaferDiameter / 2, 2))
                        count++;
                    pointY += WaferMap.Entity.DieSizeY;
                    if (Math.Pow(pointX - ccx, 2) + Math.Pow(pointY - ccy, 2) < Math.Pow(WaferMap.Entity.WaferDiameter / 2, 2))
                        count++;
                    pointX -= WaferMap.Entity.DieSizeX;
                    if (Math.Pow(pointX - ccx, 2) + Math.Pow(pointY - ccy, 2) < Math.Pow(WaferMap.Entity.WaferDiameter / 2, 2))
                        count++;

                    if (count == 4)
                        mp.BIN = 1;
                    else if (count == 0)
                        mp.BIN = 0;
                    else mp.BIN = 3;

                    WaferMap.Entity.MappingPoints.Add(mp);
                }
            }
            _waferMap.RefreshCanvas();
            WaferMapSettingMap_Load(sender, EventArgs.Empty);
        }

        private void WaferMapSettingMap_Load(object sender, EventArgs e)
        {
            int count = 0;
            if (WaferMap.Entity.MappingPoints != null)
            {
                foreach (var item in WaferMap.Entity.MappingPoints)
                {
                    if (item.BIN == 1)
                        count++;
                }
            }
            testDieNum.Text = count.ToString();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.Focus();
            Console.WriteLine(this.ContainsFocus);
            
        }
    }
}
