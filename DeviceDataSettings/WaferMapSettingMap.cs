﻿using CommonComponentLibrary;
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

        private int _chooserBin = 0;

        private int _testDieCount = 0;

        public WaferMapSettingMap(WaferMapCanvas waferMap)
        {
            InitializeComponent();
            this._waferMap = waferMap;
        }

        private void GenerationButton_Click(object sender, EventArgs e)
        {
            WaferMap.Entity.MappingPoints?.Clear();
            WaferMap.Entity.MappingPoints = new List<MappingPoint>();

            WaferMapCanvas.CircleCentre(out double ccx, out double ccy);
            for (int j = 0; j < WaferMap.Entity.DieNumY; j++)
            {
                for (int i = 0; i < WaferMap.Entity.DieNumX; i++)
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

                    double deltaX = (i - WaferMap.Entity.RefDieX) * WaferMap.Entity.DieSizeX;
                    if ("LEFT".Equals(WaferMap.Entity.DirectionX))
                        deltaX = -deltaX;

                    double deltaY = (j - WaferMap.Entity.RefDieY) * WaferMap.Entity.DieSizeY;
                    if ("UP".Equals(WaferMap.Entity.DirectionY))
                        deltaY = -deltaY;

                    mp.UserPosX = WaferMap.Entity.Center2RefDieCornerX + deltaX + WaferMap.Entity.Corner2OrgX;//临时代码
                    mp.UserPosY = WaferMap.Entity.Center2RefDieCornerY + deltaY + WaferMap.Entity.Corner2OrgY;//临时代码

                    WaferMap.Entity.MappingPoints.Add(mp);
                }
            }
            _waferMap.RefreshCanvas();
            Reload();
        }

        public void Reload()
        {
            _testDieCount = 0;
            if (WaferMap.Entity.MappingPoints != null)
            {
                foreach (var item in WaferMap.Entity.MappingPoints)
                {
                    if (item.BIN == 1)
                        _testDieCount++;
                }
            }
            testDieNum.Text = _testDieCount.ToString();
        }

        private void WaferMapSettingMap_Load(object sender, EventArgs e)
        {
            Reload();
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                _chooserBin = 0;
            }
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                _chooserBin = 1;
            }
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                _chooserBin = 2;
            }
        }

        private void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                _chooserBin = 3;
            }
        }

        private void Apply_Click(object sender, EventArgs e)
        {
            MappingPoint? mp = WaferMapSettingBase.GetMappingPint(WaferMap.CurrentIndexX, WaferMap.CurrentIndexY);
            if (null == mp)
                return;
            if (mp.BIN == 1)
                _testDieCount--;
            if (_chooserBin == 1)
                _testDieCount++;
            testDieNum.Text = _testDieCount.ToString();
            mp.BIN = _chooserBin;
            _waferMap.RefreshCanvas();
        }

        
    }
}
