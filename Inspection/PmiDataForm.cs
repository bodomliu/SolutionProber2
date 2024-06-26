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

namespace Inspection
{
    public partial class PmiDataForm : Form
    {
        public PmiDataForm()
        {
            InitializeComponent();
            this.Width = 1000;
        }

        private void PmiDataForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new BindingList<Result>(PmiData.Results);

        }
    }
}
