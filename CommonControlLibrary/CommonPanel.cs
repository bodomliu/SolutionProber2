using VisionLibrary;
using MotionLibrary;

namespace CommonComponentLibrary
{
    public partial class CommonPanel : UserControl
    {
        private double ZeroX = 0, ZeroY = 0, ZeroZ = 0;//临时用户坐标系
        public CommonPanel()
        {
            InitializeComponent();
        }
        private void UserControl_Load(object sender, EventArgs e)
        {
            TimMotion.Enabled = true;
            BtnSetZeroPosition.Visible = false;
            JogSlow.BackColor = Color.Orange;
        }

        private double JogSpeed = 1, Acc = 1, Dec = 1;
        //Jog
        private void JogFast_Click(object sender, EventArgs e)
        {
            JogBackColor();
            JogSpeed = 10;
            Acc = 10;
            Dec = 10;
            JogFast.BackColor = Color.Orange;
        }

        private void JogBackColor()
        {
            JogSlow.BackColor = Color.White;
            JogMedium.BackColor = Color.White;
            JogFast.BackColor = Color.White;
        }

        private void JogSlow_Click(object sender, EventArgs e)
        {
            JogBackColor();
            JogSpeed = 1;
            Acc = 1;
            Dec = 1;
            JogSlow.BackColor = Color.Orange;
        }

        private void JogMedium_Click(object sender, EventArgs e)
        {
            JogBackColor();
            JogSpeed = 5;
            Acc = 5;
            Dec = 5;
            JogMedium.BackColor = Color.Orange;
        }

        private void BtnRight_MouseDown(object sender, MouseEventArgs e)
        {
            Motion.AxisJog(1, 1, JogSpeed, Acc, Dec, 0);
        }

        private void BtnRight_MouseUp(object sender, MouseEventArgs e)
        {
            Motion.AxisStop(1, 1, 0);
        }

        private void BtnLeft_MouseDown(object sender, MouseEventArgs e)
        {
            Motion.AxisJog(1, 1, -JogSpeed, Acc, Dec, 0);
        }

        private void BtnLeft_MouseUp(object sender, MouseEventArgs e)
        {
            Motion.AxisStop(1, 1, 0);
        }

        private void BtnTogglePosition_Click(object sender, EventArgs e)
        {
            if (BtnSetZeroPosition.Visible)
            {
                //如果置零按钮可见，说明要切换到Zero = 0模式
                BtnTogglePosition.Text =  "Toggle Position (View)";
                ZeroX = 0; ZeroY = 0; ZeroZ = 0;
            }
            else 
            {
                //如果置零按钮不可见，说明要切换到Zero 用户配置模式
                BtnTogglePosition.Text = "Toggle Position (Match)" ;
            }
            BtnSetZeroPosition.Visible = !BtnSetZeroPosition.Visible;//变更ZeroPosion可见性
        }

        private void BtnSetZeroPosition_Click(object sender, EventArgs e)
        {
            //需要在相同坐标系来做差
            if (RbtnAlign.Checked) Motion.GetUserPos(Compensation.Area.Align, out ZeroX, out ZeroY);
            if (RbtnProbing.Checked) Motion.GetUserPos(Compensation.Area.Probing, out ZeroX, out ZeroY);
            if (RbtnMotion.Checked) Motion.XY_GetEncPos(out ZeroX, out ZeroY);

            ZeroZ = Motion.GetEncPos(1, 3);
        }

        private void TimMotion_Tick(object sender, EventArgs e)
        {
            double X = double.NaN;double Y = double.NaN;
            if (RbtnAlign.Checked) Motion.GetUserPos(Compensation.Area.Align, out X, out Y);
            if (RbtnProbing.Checked) Motion.GetUserPos(Compensation.Area.Probing, out X, out Y);
            if (RbtnMotion.Checked) Motion.XY_GetEncPos(out X, out Y);
            
            txtEncodeX.Text = (X - ZeroX).ToString("F0");
            txtEncodeY.Text = (Y - ZeroY).ToString("F0");

            double Z = Motion.GetEncPos(1, 3);
            txtEncodeZ.Text = (Z - ZeroZ).ToString("F0");
            double R = Motion.GetEncPos(1, 4);
            txtEncodeR.Text = R.ToString("F0");
        }

        private void BtnUp_MouseDown(object sender, MouseEventArgs e)
        {
            Motion.AxisJog(1, 2, JogSpeed, Acc, Dec, 0);
        }

        private void BtnUp_MouseUp(object sender, MouseEventArgs e)
        {
            Motion.AxisStop(1, 2, 0);
        }

        private void BtnDown_MouseDown(object sender, MouseEventArgs e)
        {
            Motion.AxisJog(1, 2, -JogSpeed, Acc, Dec, 0);
        }

        private void BtnDown_MouseUp(object sender, MouseEventArgs e)
        {
            Motion.AxisStop(1, 2, 0);
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            canvas.Controls.Add(Vision.m_HSmartWindowControl);
            Vision.m_HSmartWindowControl.Dock = DockStyle.Fill;
        }

        private void BtnJogZup_MouseDown(object sender, MouseEventArgs e)
        {
            Motion.AxisJog(1, 3, JogSpeed, Acc, Dec, 0);
        }

        private void BtnJogZup_MouseUp(object sender, MouseEventArgs e)
        {
            Motion.AxisStop(1, 3, 0);
        }

        private void BtnJogZdown_MouseDown(object sender, MouseEventArgs e)
        {
            Motion.AxisJog(1, 3, -JogSpeed, Acc, Dec, 0);
        }

        private void BtnJogZdown_MouseUp(object sender, MouseEventArgs e)
        {
            Motion.AxisStop(1, 3, 0);
        }

        private void BtnScan_Click(object sender, EventArgs e)
        {

        }

        private void BtnIndex_Click(object sender, EventArgs e)
        {

        }

        private void BtnStep_Click(object sender, EventArgs e)
        {

        }
    }
}
