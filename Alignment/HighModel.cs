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

namespace MainForm
{
    public partial class HighModel : UserControl
    {
        //作为临时性的shm模板
        public string PattenModel1 = "tempSHM";
        public HighModel()
        {
            InitializeComponent();
        }

        private void BtnIstantHighAlign_Click(object sender, EventArgs e)
        {
            if (Vision.activeCamera == Camera.WaferLowMag)
            {
                MessageBox.Show("Please Change Camera to High Mag");
                return;
            }

            Vision.WaferHighMag.halconClass.CreateShapeModel(PattenModel1);
            //做模板完了后加延时 TODO 增加校验处理
            Thread.Sleep(500);

            int L = int.Parse(txtL.Text);
            int R = int.Parse(txtR.Text);

            Alignment.AlignX(Vision.WaferHighMag, PattenModel1, L, R, WaferMap.Entity.DieSizeX);
        }

        private void BtnMoveToRefDie_Click(object sender, EventArgs e)
        {
            //WaferMap.GetMapUserPos(WaferMap.Entity.RefDieIndexX, WaferMap.Entity.RefDieIndexY, out double X, out double Y);
            //Compensation.Transform(Compensation.Area.Align, Compensation.Dir.User2Encode, X + WaferMap.WaferOffsetX, Y + WaferMap.WaferOffsetY, out double encodeX, out double encodeY);
            //Motion.XYZ_AxisMoveAbs(1, encodeX, encodeY, WaferMap.Thickness, 600, 10, 10, 20);
        }

        private void BtnAlignConfirm_Click(object sender, EventArgs e)
        {
            ////将refdie对整齐后，获取当前user坐标
            //Motion.GetUserPos(Compensation.Area.Align, out double userX, out double userY);
            ////获取参考die的用户坐标
            //WaferMap.GetMapUserPos(WaferMap.Entity.RefDieIndexX, WaferMap.Entity.RefDieIndexY, out double refPosX, out double refPosY);
            ////得到与注册位置的差异
            //parent.ConfirmHighAlign(userX - refPosX, userY - refPosY);

            ////将当前的RefDie参数存一下
            //PadRegistration.RefDieAfterAlignX = userX;
            //PadRegistration.RefDieAfterAlignY = userY;
        }

        private void BtnMatch_Click(object sender, EventArgs e)
        {
            //Alignment.Match(WaferMap.HighModelPattern1, Vision.WaferHighMag);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //panel1.Controls.Add(WaferMap.IndexControl);
        }

        private void BtnPat1Reg_Click(object sender, EventArgs e)
        {
            //SaveFileDialog sfd = new SaveFileDialog();
            //sfd.Filter = "shm文件(*.shm文件)|*.shm|所有文件|*.*";
            //if (sfd.ShowDialog() == DialogResult.OK) //用户点击确认按钮，发送确认消息
            //{
            //    Vision.WaferHighMag.halconClass.CreateShapeModel(sfd.FileName);
            //}
        }
    }
}
