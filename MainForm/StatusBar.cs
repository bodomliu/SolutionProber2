using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MotionLibrary;
namespace MainForm
{
    public partial class StatusBar : UserControl
    {
        public StatusBar()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private void StatusBar_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblStage.BackColor =Motion.StageReady?Color.Green:Color.Red;
        }
    }
}
