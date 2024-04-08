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

namespace CommonComponentLibrary
{
    public partial class WaferMapIndexControl : UserControl
    {
        public WaferMapIndexControl()
        {
            InitializeComponent();
        }

        private void WaferMapIndexControl_Load(object sender, EventArgs e)
        {
            UpdateIndex();
        }

        public void UpdateIndex()
        {
            TxtIndexX.Text = WaferMap.CurrentIndexX.ToString();
            TxtIndexY.Text = WaferMap.CurrentIndexY.ToString();
        }

        private void BtnUp_Click(object sender, EventArgs e)
        {
            WaferMap.CurrentIndexY--;
            Console.WriteLine(WaferMap.CurrentIndexY.ToString());
            //UpdateIndex();
        }

        private void BtnDown_Click(object sender, EventArgs e)
        {
            WaferMap.CurrentIndexY++;
            //UpdateIndex();
        }

        private void BtnLeft_Click(object sender, EventArgs e)
        {
            WaferMap.CurrentIndexX--;
            //UpdateIndex();
        }

        private void BtnRight_Click(object sender, EventArgs e)
        {
            WaferMap.CurrentIndexX++;
            //UpdateIndex();
        }

        private void WaferMapIndexControl_Paint(object sender, PaintEventArgs e)
        {
            UpdateIndex();
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            WaferMap.CurrentIndexX = int.Parse(TxtIndexX.Text);
            WaferMap.CurrentIndexY = int.Parse(TxtIndexY.Text);
            //UpdateIndex();
        }
    }
}
