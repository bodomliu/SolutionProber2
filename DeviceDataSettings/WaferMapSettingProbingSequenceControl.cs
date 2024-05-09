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
    public partial class WaferMapSettingProbingSequenceControl : UserControl
    {

        private readonly WaferMapCanvas _wmc;

        public WaferMapSettingProbingSequenceControl(WaferMapCanvas wmc)
        {
            InitializeComponent();
            _wmc = wmc;
        }

        int _totalNum = 0;

        public void Reload()
        {
            WaferMap.OnIndexChange += WaferMap_OnIndexChange;
            RefreshCurrentNum(WaferMap.CurrentIndexX, WaferMap.CurrentIndexY);
            _totalNum = 0;
            if (null != WaferMap.Entity.MappingPoints)
            {
                foreach (var mp in WaferMap.Entity.MappingPoints)
                {
                    if (mp.Order > 0)
                        _totalNum++;
                }
            }
            TotalNum.Text = _totalNum.ToString();
            _wmc.IsDisplaySequenceOrder = true;
            _wmc.RefreshCanvas();
        }


        private void WaferMap_OnIndexChange(int x, int y)
        {
            RefreshCurrentNum(x, y);
        }

        private void RefreshCurrentNum(int x, int y)
        {
            MappingPoint? mp = WaferMapSettingBase.getMappingPint(x, y);
            if (null == mp)
                CurrentNum.Text = "0";
            else CurrentNum.Text = mp.Order.ToString();
        }

        public void Unload()
        {
            WaferMap.OnIndexChange -= WaferMap_OnIndexChange;
            _wmc.IsDisplaySequenceOrder = false;
            _wmc.RefreshCanvas();
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            int x = WaferMap.CurrentIndexX;
            int y = WaferMap.CurrentIndexY;
            var mp = WaferMapSettingBase.getMappingPint(x, y);
            if (mp == null)
                return;
            if (mp.Order > 0)
                return;
            if (mp.BIN != 1)
                return;
            _totalNum++;
            mp.Order = _totalNum;
            CurrentNum.Text = _totalNum.ToString();
            TotalNum.Text = _totalNum.ToString();
            _wmc.RefreshCanvas();
        }

        private void DeleteCurrent_Click(object sender, EventArgs e)
        {
            int x = WaferMap.CurrentIndexX;
            int y = WaferMap.CurrentIndexY;
            var mp = WaferMapSettingBase.getMappingPint(x, y);
            if (mp == null)
                return;
            if (mp.Order == 0)
                return;
            WaferMap.Entity.MappingPoints?.ForEach(m =>
            {
                if (m.Order > mp.Order)
                    m.Order--;
            });
            _totalNum--;
            mp.Order = 0;
            CurrentNum.Text = "0";
            TotalNum.Text = _totalNum.ToString();
            _wmc.RefreshCanvas();
        }

        private void Automatic_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i < WaferMap.Entity.DieNumY; i++)
            {
                for (int j = 0; j < WaferMap.Entity.DieNumX; j++)
                {
                    SetOrder(j, i);
                }
                i++;
                if (i >= WaferMap.Entity.DieNumY)
                    break;
                for (int j = WaferMap.Entity.DieNumX - 1; j >= 0; j--)
                {
                    SetOrder(j, i);
                }
            }
            TotalNum.Text = _totalNum.ToString();
            RefreshCurrentNum(WaferMap.CurrentIndexX, WaferMap.CurrentIndexY);
            _wmc.RefreshCanvas();
        }

        private void SetOrder(int x, int y)
        {
            var mp = WaferMapSettingBase.getMappingPint(x, y);
            if (mp == null)
                return;
            if (mp.BIN != 1)
                return;
            if (mp.Order > 0)
                return;
            _totalNum++;
            mp.Order = _totalNum;
        }

        private void DeleteAll_Click(object sender, EventArgs e)
        {
            _totalNum = 0;
            WaferMap.Entity.MappingPoints?.ForEach(m =>
            {
                m.Order = 0;
            });
            CurrentNum.Text = "0";
            TotalNum.Text = _totalNum.ToString();
            _wmc.RefreshCanvas();
        }
    }
}
