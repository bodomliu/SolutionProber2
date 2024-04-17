using CommonComponentLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WaferMapLibrary;

namespace DeviceDataSettings
{
    public partial class WaferMapSetting_1 : UserControl
    {

        private readonly WaferMapCanvas _waferMap;
        public WaferMapSetting_1(WaferMapCanvas waferMap)
        {
            InitializeComponent();
            // wafer 默认尺寸
            WaferSize.SelectedIndex = 2;
            // X 默认放大倍数
            ratioX.SelectedIndex = 0;
            // Y 默认放大倍数
            ratioY.SelectedIndex = 0;
            this._waferMap = waferMap;

        }

        private void SetRatio_Click(object sender, EventArgs e)
        {
            this._waferMap.SetRatio(double.Parse(ratioX.Text), double.Parse(ratioY.Text));
        }

        private void WaferMapSetting_1_Load(object sender, EventArgs e)
        {
            SizeX.Text = WaferMap.Entity.DieSizeX.ToString();
            SizeY.Text = WaferMap.Entity.DieSizeY.ToString();

            NumX.Text = WaferMap.Entity.DieNumX.ToString();
            NumY.Text = WaferMap.Entity.DieNumY.ToString();
        }

        private void Apply_Click(object sender, EventArgs e)
        {
            WaferMap.Entity.WaferSize = int.Parse(WaferSize.Text);
            WaferMap.Entity.DieSizeX = double.Parse(SizeX.Text);
            WaferMap.Entity.DieSizeY = double.Parse(SizeY.Text);

            NumX.Text = WaferMap.Entity.DieNumX.ToString();
            NumY.Text = WaferMap.Entity.DieNumY.ToString();

            ratioX.Text = 1.ToString();
            ratioY.Text = 1.ToString();
            _waferMap.LoadCanvas();
        }

        private void Margin_Click(object sender, EventArgs e)
        {

        }

        private void Generation_Click(object sender, EventArgs e)
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
                    else if(count == 0)
                        mp.BIN = 0;
                    else mp.BIN = 3;

                    WaferMap.Entity.MappingPoints.Add(mp);
                }
            }
            _waferMap.LoadCanvas();
        }


        // 判断 die 是否在 圆内

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
