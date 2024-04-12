using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommonComponentLibrary
{
    public partial class WaitingControl : UserControl
    {
        public WaitingControl()
        {
            InitializeComponent();
        }

        private void WaitingControl_Load(object sender, EventArgs e)
        {
            this.Location = new Point(1000, 500);
            this.BringToFront();
            
        }

    }
}
