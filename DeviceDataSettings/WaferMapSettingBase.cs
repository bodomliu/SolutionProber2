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
            // wafer 默认尺寸
            WaferSize.SelectedIndex = 2;
            // X 默认放大倍数
            ratioX.SelectedIndex = 0;
            // Y 默认放大倍数
            ratioY.SelectedIndex = 0;
            this._waferMap = waferMap;
            this.ControlRemoved += WaferMapSettingBase_ControlRemoved;
            this.ControlAdded += WaferMapSettingBase_ControlAdded;
            this.BindingContextChanged += WaferMapSettingBase_BindingContextChanged;

        }

        private void WaferMapSettingBase_BindingContextChanged(object? sender, EventArgs e)
        {
            if (this.ParentForm is not null && this.ParentForm.Controls.Contains(this))
            {
                Console.WriteLine("AAAAA");
            }
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
        }

        private void WaferMapSettingBase_ControlAdded(object? sender, ControlEventArgs e)
        {
            Console.WriteLine("aaaa");
            
        }

        private void WaferMapSettingBase_ControlRemoved(object? sender, ControlEventArgs e)
        {
            Console.WriteLine("wwww");
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

            offsetX.Text = WaferMap.Entity.Center2RefDieCornerX.ToString();
            offsetY.Text = WaferMap.Entity.Center2RefDieCornerY.ToString();
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

        //private void Generation_Click(object sender, EventArgs e)
        //{
            
        //}



    }
}
