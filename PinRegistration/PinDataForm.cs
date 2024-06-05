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

namespace PinRegistration
{
    public partial class PinDataForm : Form
    {
        public PinDataForm()
        {
            InitializeComponent();
        }

        private class m_Pin:Pin
        {
            public  int index { get; set; } = 0;
            public int deltaX { get; set; } = 0;
            public int deltaY { get; set; } = 0;
            public int deltaZ { get; set; } = 0;

        }
        private void PinDataForm_Load(object sender, EventArgs e)
        {
            List<m_Pin> pinList = new List<m_Pin>();
            int i = 0;
            foreach (var pin in PinData.Entity.Pins)
            {
                pinList.Add(new m_Pin
                {
                    index = i++,
                    PosX = pin.PosX,
                    PosY = pin.PosY,
                    PosZ = pin.PosZ,
                    CurrentPosX = pin.CurrentPosX,
                    CurrentPosY = pin.CurrentPosY,
                    CurrentPosZ = pin.CurrentPosZ,
                    deltaX = (pin.CurrentPosX == 0) ? 0 : (int)(pin.CurrentPosX - pin.PosX),
                    deltaY = (pin.CurrentPosY == 0) ? 0 : (int)(pin.CurrentPosY - pin.PosY),
                    deltaZ = (pin.CurrentPosZ == 0) ? 0 : (int)(pin.CurrentPosZ - pin.PosZ),
                });
            }

            dataGridView1.DataSource = new BindingList<m_Pin>(pinList);
        }
    }
}
