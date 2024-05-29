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
            BringToFront();
            Location = new Point(1000, 500);
            Hide();
        }
        public static WaitingControl WF = new();//改为静态变量
        private void WaitingControl_Load(object sender, EventArgs e)
        {
            
        }

        public void Start()
        {
            BringToFront();
            Show();
            Application.DoEvents();//TODO 待优化
        }

        public void End()
        {
            Hide();
        }
    }
}
