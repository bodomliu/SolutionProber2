﻿using MotionLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UtilityForm
{
    public partial class PlanarityHeight : UserControl
    {
        public PlanarityHeight()
        {
            InitializeComponent();
        }

        public void updateUI_Z()
        {         
            Planarity.UpdateHeightAndDiff();
            
            double[] z = Planarity.PointsToSet.Select(p => p.z - (checkBox1.Checked ? Motion.parameter.ZORIGIN : 0)).ToArray();
            tb_DiffZ.Text = Planarity.Difference.ToString();

            var ZButton = new Button[] { Z0, Z1, Z2, Z3, Z4, Z5, Z6, Z7, Z8 };
            var ZDiff = new Label[] { Z0_diff, Z1_diff, Z2_diff, Z3_diff, Z4_diff, Z5_diff, Z6_diff, Z7_diff, Z8_diff };

            for (int i = 0; i < z.Length; i++)
            {
                ZButton[i].Text = z[i].ToString();
                ZDiff[i].Text = (z[i] - z[0]).ToString();
            }
        }
        private async void JOG_CLick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            String str = button.Name.Substring(1);
            label_index.Text = str;

            int index = int.Parse(str);
            Planarity.Index = index;
            await Task.Run(() =>  Motion.XY_AxisMoveAbs(1, Planarity.PointsToSet[index].x, Planarity.PointsToSet[index].y,600,10,10,20));
        }
        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            if (Planarity.PointsToSet.Count == 0)
            {
                return;
            }
            updateUI_Z();
        }
        private void PlanarityHeight_Load(object sender, EventArgs e)
        {
        }

    }
}
