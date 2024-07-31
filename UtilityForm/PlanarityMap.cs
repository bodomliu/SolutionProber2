using CommonComponentLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UtilityForm
{
    public partial class PlanarityMap : UserControl
    {
        public PlanarityMap()
        {
            InitializeComponent();
        }
        public void updateUI_XY()
        {
            double[] X = new double[9];
            double[] Y = new double[9];
            if (cb_CalXY.Checked)
            {
                for (int i = 0; i < 9; i++)
                {
                    X[i] = Planarity.PointsToSet[i].x - Planarity.PointsToSet[0].x;
                    Y[i] = Planarity.PointsToSet[i].y - Planarity.PointsToSet[0].y;
                }
            }
            else
            {
                for (int i = 0; i < 9; i++)
                {
                    X[i] = Planarity.PointsToSet[i].x;
                    Y[i] = Planarity.PointsToSet[i].y;
                }
            }
            var tb_X = new TextBox[] { X1, X2, X3, X4, X5, X6, X7, X8 };
            var tb_Y = new TextBox[] { Y1, Y2, Y3, Y4, Y5, Y6, Y7, Y8 };
            for (int i = 1; i < 9; i++)
            {
                tb_X[i - 1].Text = X[i].ToString();                
                tb_Y[i - 1].Text = Y[i].ToString();
                tb_X[i - 1].ForeColor = Color.Black;//改下颜色
                tb_Y[i - 1].ForeColor = Color.Black;//改下颜色
            }
        }
        private void PlanarityMap_Load(object sender, EventArgs e)
        {

        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            if (Planarity.PointsToSet.Count == 0)
            {
                return;
            }
            updateUI_XY();
        }
    }
}
