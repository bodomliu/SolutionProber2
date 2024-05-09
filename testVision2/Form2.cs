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

namespace test
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.TopLevel = false;
            //WaferMapCanvas mapCanvas = WaferMapCanvas.Canvas;
            panel1.Controls.Add(CommonPanel.Entity);
            //mapCanvas.LoadCanvas();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Console.WriteLine(this.Visible.ToString());
        }

        private void Form2_VisibleChanged(object sender, EventArgs e)
        {
            Console.WriteLine(this.Visible.ToString());
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            
        }
    }
}
