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
using WaferMapLibrary;

namespace UtilityForm
{
    public partial class Invar36Control : UserControl
    {
        public Invar36Control()
        {
            InitializeComponent();
        }

        private void BtnMove_Click(object sender, EventArgs e)
        {
            double encodeX = double.Parse(EncodeX.Text);
            double encodeY = double.Parse(EncodeY.Text);
            double encodeZ = double.Parse(EncodeZ.Text);
            MotionLibrary.Motion.XYZ_AxisMoveAbs(1, encodeX, encodeY, encodeZ, 600, 10, 10, 20);
        }

        private void BtnRegPattern_Click(object sender, EventArgs e)
        {
            Vision.WaferHighMag.halconClass.CreateShapeModel(PatternName.Text);
        }

        private void BtnMatchWithMove_Click(object sender, EventArgs e)
        {
            CommonFunctions.Match_With_Move(PatternName.Text, Vision.WaferHighMag, out _, out _);
        }
    }
}
