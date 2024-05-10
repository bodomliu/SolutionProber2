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
using VisionLibrary;

namespace test
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.TopLevel = true;
            //WaferMapCanvas mapCanvas = WaferMapCanvas.Canvas;
            panel1.Controls.Add(new CommonPanel());
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

        private void button1_Click(object sender, EventArgs e)
        {
            Vision.ChangeCamera(0);
        }
    }
}
