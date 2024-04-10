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
using CommonComponentLibrary;

namespace MainForm
{
    public partial class LowModel : UserControl
    {
        //作为临时性的shm模板
        public string PattenModel1 = "tempSHM";
        public LowModel()
        {
            InitializeComponent();
            panelIndex.Controls.Add(new WaferMapIndexControl());
        }

        private void BtnIstantLowAlign_Click(object sender, EventArgs e)
        {
            if (Vision.activeCamera != Camera.WaferLowMag)
            {
                MessageBox.Show("Please Change Camera to Low Mag,");
                return;
            }
            Vision.WaferLowMag.halconClass.CreateShapeModel(PattenModel1);
            //做模板完了后加延时,TODO 增加校验步骤，延时不太可靠
            Thread.Sleep(500);
            int L = int.Parse(txtL.Text);
            int R = int.Parse(txtR.Text);

            Alignment.AlignX(Vision.WaferLowMag, PattenModel1, L, R, WaferMap.Entity.DieSizeX, WaferMap.Entity.DieSizeX);
        }

        private void BtnTeachLowerLeftCorner_Click(object sender, EventArgs e)
        {

        }

        private void BtnMatchIndex_Click(object sender, EventArgs e)
        {

        }

        private void BtnAlignConfirm_Click(object sender, EventArgs e)
        {
            //parent.ConfirmLowAlign();
        }

        private void BtnSetRefDie_Click(object sender, EventArgs e)
        {

        }

        private void BtnPat1Reg_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "shm文件(*.shm文件)|*.shm|所有文件|*.*";
            if (sfd.ShowDialog() == DialogResult.OK) //用户点击确认按钮，发送确认消息
            {
                Vision.WaferLowMag.halconClass.CreateShapeModel(sfd.FileName);
            }
        }

        private void BtnMoveToRefDie_Click(object sender, EventArgs e)
        {
            //double X = WaferMap.WaferCenterX + WaferMap.Entity.Center2RefDieX;
            //double Y = WaferMap.WaferCenterY + WaferMap.Entity.Center2RefDieY;
            //Motion.XY_AxisMoveAbs(1, X, Y, 600, 10, 10, 20);

        }

        private void BtnMatch_Click(object sender, EventArgs e)
        {
            //Alignment.Match(WaferMap.LowModelPattern1, Vision.WaferLowMag);
        }
    }
}
