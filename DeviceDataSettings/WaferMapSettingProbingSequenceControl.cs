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
            if (null != WaferMap.Entity.OrderClasses)
            {
                _totalNum = WaferMap.Entity.OrderClasses.Count;
            }
            TotalNum.Text = _totalNum.ToString();
            _wmc.IsDisplaySequenceOrder = true;
            _wmc.RefreshCanvas();

            panel1.Controls.Clear();
            checkBoxes.Clear();
            for (int i = 0; i < DUTData.Entity.DUTs.Count; i++)
            {
                CheckBox checkBox = new()
                {
                    Name = "checkBox" + i,
                    Text = "Dut " + i.ToString(),
                    AutoSize = true,
                    Size = new Size(89, 21),
                    TabIndex = i,
                    UseVisualStyleBackColor = true,
                    Checked = DUTData.Entity.DUTs[i].Enable,
                };
                checkBox.CheckedChanged += CheckBox_CheckedChanged;

                if (i > 12)
                {
                    checkBox.Location = new Point(73, 3 + 20 * (i - 13));
                }
                else
                {
                    checkBox.Location = new Point(3, 3 + 20 * i);
                }

                panel1.Controls.Add(checkBox);
                checkBoxes.Add(checkBox);
            }
            panel1.Refresh();

        }


        private void WaferMap_OnIndexChange(int x, int y)
        {
            RefreshCurrentNum(x, y);
        }

        private void RefreshCurrentNum(int x, int y)
        {
            MappingPoint? mp = WaferMapSettingBase.GetMappingPint(x, y);
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
            if (Add(x, y))
            {
                CurrentNum.Text = _totalNum.ToString();
                TotalNum.Text = _totalNum.ToString();
                _wmc.RefreshCanvas();
            }
        }

        private Boolean Add(int indexX, int indexY)
        {
            int count = 0;
            for (int i = 0; i < DUTData.Entity.DUTs.Count; i++)
            {
                if (!DUTData.Entity.DUTs[i].Enable)
                    continue;
                int x = indexX + DUTData.Entity.DUTs[i].X;
                int y = indexY + DUTData.Entity.DUTs[i].Y;
                var mp = WaferMapSettingBase.GetMappingPint(x, y);
                if (mp == null)
                    return false;
                if (mp.Order > 0)
                    return false;
                if (mp.BIN != 1)
                    return false;
                count++;
            }

            if (count == 0)
                return false;

            _totalNum++;
            if (null == WaferMap.Entity.OrderClasses)
                WaferMap.Entity.OrderClasses = new List<OrderClass>();

            OrderClass oc = new()
            {
                IndexX = indexX,
                IndexY = indexY,
                PMI = new()
            };
            for (int i = 0; i < DUTData.Entity.DUTs.Count; i++)
            {
                if (!DUTData.Entity.DUTs[i].Enable)
                    continue;
                int x = indexX + DUTData.Entity.DUTs[i].X;
                int y = indexY + DUTData.Entity.DUTs[i].Y;
                var mp = WaferMapSettingBase.GetMappingPint(x, y);
                if (mp == null)
                    continue;
                mp.Order = _totalNum;
                oc.PMI.Add(i);
            }
            WaferMap.Entity.OrderClasses.Add(oc);

            return true;
        }

        private void DeleteCurrent_Click(object sender, EventArgs e)
        {
            int x = WaferMap.CurrentIndexX;
            int y = WaferMap.CurrentIndexY;
            var mp = WaferMapSettingBase.GetMappingPint(x, y);
            if (mp == null)
                return;
            if (mp.Order == 0)
                return;
            int order = mp.Order;
            WaferMap.Entity.OrderClasses?.RemoveAt(mp.Order - 1);
            WaferMap.Entity.MappingPoints?.ForEach(m =>
            {
                if (m.Order == order)
                    m.Order = 0;
                if (m.Order > order)
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
                    Add(j, i);
                }
                i++;
                if (i >= WaferMap.Entity.DieNumY)
                    break;
                for (int j = WaferMap.Entity.DieNumX - 1; j >= 0; j--)
                {
                    Add(j, i);
                }
            }
            TotalNum.Text = _totalNum.ToString();
            RefreshCurrentNum(WaferMap.CurrentIndexX, WaferMap.CurrentIndexY);
            _wmc.RefreshCanvas();
        }

        //private void SetOrder(int x, int y)
        //{
        //    var mp = WaferMapSettingBase.getMappingPint(x, y);
        //    if (mp == null)
        //        return;
        //    if (mp.BIN != 1)
        //        return;
        //    if (mp.Order > 0)
        //        return;
        //    _totalNum++;
        //    mp.Order = _totalNum;
        //}

        private void DeleteAll_Click(object sender, EventArgs e)
        {
            DeleteAll();
        }

        internal void DeleteAll()
        {
            _totalNum = 0;
            WaferMap.Entity.MappingPoints?.ForEach(m =>
            {
                m.Order = 0;
            });
            CurrentNum.Text = "0";
            WaferMap.Entity.OrderClasses?.Clear();
            TotalNum.Text = _totalNum.ToString();
            _wmc.RefreshCanvas();
        }

        private readonly List<CheckBox> checkBoxes = new();
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            if (null == sender)
                return;
            CheckBox checkBox = (CheckBox)sender;
            int index = int.Parse(checkBox.Name[8..]);
            DUTData.Entity.DUTs[index].Enable = checkBox.Checked;
            _wmc.RefreshCanvas();
        }

        private void ButtonReorder_Click(object sender, EventArgs e)
        {
            if (null == WaferMap.Entity.OrderClasses)
                return;
            WaferMap.Entity.OrderClasses = WaferMap.Entity.OrderClasses.OrderBy(o => o.IndexY).ThenBy(t => t.IndexX).ToList();
            for (int i = 0; i < WaferMap.Entity.OrderClasses.Count; i++)
            {
                var oc = WaferMap.Entity.OrderClasses[i];
                oc.PMI = oc.PMI?.OrderBy(o => o).ToList();
                for (int j = 0; j < oc.PMI?.Count; j++)
                {
                    var mp = WaferMapSettingBase.GetMappingPint(oc.IndexX + DUTData.Entity.DUTs[oc.PMI[j]].X, oc.IndexY + DUTData.Entity.DUTs[oc.PMI[j]].Y);
                    if (null == mp)
                        continue;
                    mp.Order = i + 1;
                }
            }
            _wmc.RefreshCanvas();
        }
    }
}
