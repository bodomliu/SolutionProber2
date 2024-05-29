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
    public partial class WaferMapSettingBase : UserControl
    {

        private readonly WaferMapCanvas _waferMap;
        public WaferMapSettingBase(WaferMapCanvas waferMap)
        {
            InitializeComponent();
            this._waferMap = waferMap;
            SizeY.KeyPress += this.CheckFloat;
            SizeX.KeyPress += this.CheckFloat;
            offsetX.KeyPress += this.CheckFloat;
            offsetY.KeyPress += this.CheckFloat;
            Org2PatIIX.KeyPress += this.CheckFloat;
            Org2PatIIY.KeyPress += this.CheckFloat;
            Corner2OrgX.KeyPress += this.CheckFloat;
            Corner2OrgY.KeyPress += this.CheckFloat;
        }

        public void ReLoad()
        {
            WaferSize.Text = WaferMap.Entity.WaferSize.ToString();
            // X 默认放大倍数
            ratioX.SelectedIndex = 0;
            // Y 默认放大倍数
            ratioY.SelectedIndex = 0;

            SizeX.Text = WaferMap.Entity.DieSizeX.ToString();
            SizeY.Text = WaferMap.Entity.DieSizeY.ToString();

            NumX.Text = WaferMap.Entity.DieNumX.ToString();
            NumY.Text = WaferMap.Entity.DieNumY.ToString();

            offsetX.Text = WaferMap.Entity.Center2RefDieCornerX.ToString();
            offsetY.Text = WaferMap.Entity.Center2RefDieCornerY.ToString();

            Org2PatIIX.Text = WaferMap.Entity.Org2PatIIX.ToString();
            Org2PatIIY.Text = WaferMap.Entity.Org2PatIIY.ToString();

            Corner2OrgX.Text = WaferMap.Entity.Corner2OrgX.ToString();
            Corner2OrgY.Text = WaferMap.Entity.Corner2OrgY.ToString();
        }

        private void SetRatio_Click(object sender, EventArgs e)
        {
            this._waferMap.SetRatio(double.Parse(ratioX.Text), double.Parse(ratioY.Text));
        }

        private void WaferMapSettingBaseLoad(object sender, EventArgs e)
        {
            ReLoad();
        }

        protected override void OnBindingContextChanged(EventArgs e)
        {
            base.OnBindingContextChanged(e);
            if (null == this.ParentForm)
            {
                this._waferMap.SetRatio(1, 1);
                ratioX.Text = 1.ToString();
                ratioY.Text = 1.ToString();
            }
        }

        private void Apply_Click(object sender, EventArgs e)
        {
            WaferMap.Entity.WaferSize = int.Parse(WaferSize.Text);
            WaferMap.Entity.DieSizeX = double.Parse(SizeX.Text);
            WaferMap.Entity.DieSizeY = double.Parse(SizeY.Text);

            WaferMap.Entity.DieNumX = (int)(WaferMap.Entity.WaferDiameter / WaferMap.Entity.DieSizeX);
            WaferMap.Entity.DieNumY = (int)(WaferMap.Entity.WaferDiameter / WaferMap.Entity.DieSizeY);

            NumX.Text = WaferMap.Entity.DieNumX.ToString();
            NumY.Text = WaferMap.Entity.DieNumY.ToString();

            ratioX.Text = 1.ToString();
            ratioY.Text = 1.ToString();

            WaferMap.Entity.Center2RefDieCornerX = int.Parse(offsetX.Text);
            WaferMap.Entity.Center2RefDieCornerY = int.Parse(offsetY.Text);


            _waferMap.LoadCanvas();
        }

        private void Margin_Click(object sender, EventArgs e)
        {

        }

        internal static MappingPoint? GetMappingPint(int x, int y)
        {
            if (null == WaferMap.Entity.MappingPoints)
                return null;
            // 计算具体的 index
            int index = WaferMap.Entity.DieNumX * y + x;
            if (index >= WaferMap.Entity.MappingPoints.Count)
                return null;
            var p = WaferMap.Entity.MappingPoints?[index];
            if (null == p || p.IndexX != x || p.IndexY != y)
            {
                return WaferMap.Entity.MappingPoints?.Find(f => f.IndexX == x && f.IndexY == y);
            }

            return p;
        }

    }
}
