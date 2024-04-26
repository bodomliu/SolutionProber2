﻿using CommonComponentLibrary;
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

        }

        private void SetRatio_Click(object sender, EventArgs e)
        {
            this._waferMap.SetRatio(double.Parse(ratioX.Text), double.Parse(ratioY.Text));
        }

        private void WaferMapSetting_1_Load(object sender, EventArgs e)
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

        //private void Generation_Click(object sender, EventArgs e)
        //{

        //}



    }
}
