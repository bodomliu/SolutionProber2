using VisionLibrary;
using MotionLibrary;
using WaferMapLibrary;

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

            JogSlow_Click(JogSlow,e);//初始slow速度
            BtnStep_Click(BtnStep,e);//初始Step模式
        }
        private double JogSpeed = 1, Acc = 1, Dec = 1;
        private void JogSlow_Click(object sender, EventArgs e)
        {
            JogSpeed = 1;
            Acc = 1;
            Dec = 1;
            JogBackColor(sender);
        }
        private void JogMedium_Click(object sender, EventArgs e)
        {
            JogSpeed = 5;
            Acc = 5;
            Dec = 5;
            JogBackColor(sender);
        }
        private void JogFast_Click(object sender, EventArgs e)
        {
            JogSpeed = 10;
            Acc = 10;
            Dec = 10;
            JogBackColor(sender);
        }
        private void JogBackColor(object sender)
        {
            JogSlow.BackColor = Color.White;
            JogMedium.BackColor = Color.White;
            JogFast.BackColor = Color.White;
            Button btn = (Button)sender;
            btn.BackColor = Color.Orange;
        }
        private void BtnRight_MouseDown(object? sender, MouseEventArgs e)
        {
            Motion.AxisJog(1, 1, JogSpeed, Acc, Dec, 0);
        }
        private void BtnRight_MouseUp(object? sender, MouseEventArgs e)
        {
            Motion.AxisStop(1, 1, 0);
        }
        private void BtnLeft_MouseDown(object? sender, MouseEventArgs e)
        {
            Motion.AxisJog(1, 1, -JogSpeed, Acc, Dec, 0);
        }
        private void BtnLeft_MouseUp(object? sender, MouseEventArgs e)
        {
            Motion.AxisStop(1, 1, 0);
        }
        private void BtnTogglePosition_Click(object sender, EventArgs e)
        {
            if (BtnSetZeroPosition.Visible)
            {
                //如果置零按钮可见，说明要切换到Zero = 0模式
                BtnTogglePosition.Text = "Toggle Position (View)";
                ZeroX = 0; ZeroY = 0; ZeroZ = 0;
            }
            else
            {
                //如果置零按钮不可见，说明要切换到Zero 用户配置模式
                BtnTogglePosition.Text = "Toggle Position (Match)";
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
            double X = double.NaN; double Y = double.NaN;
            if (RbtnAlign.Checked) Motion.GetUserPos(Compensation.Area.Align, out X, out Y);
            if (RbtnProbing.Checked) Motion.GetUserPos(Compensation.Area.Probing, out X, out Y);
            if (RbtnMotion.Checked) Motion.XY_GetEncPos(out X, out Y);

            txtEncodeX.Text = (X - ZeroX).ToString("F0");
            txtEncodeY.Text = (Y - ZeroY).ToString("F0");

            double Z = Motion.GetEncPos(1, 3);
            txtEncodeZ.Text = (Z - ZeroZ).ToString("F0");
            double R = Motion.GetEncPos(1, 4);
            txtEncodeR.Text = R.ToString("F0");

            TxtIndex.Text = "X: " + WaferMap.CurrentIndexX.ToString() + "  Y: " + WaferMap.CurrentIndexY.ToString();
        }
        private void BtnUp_MouseDown(object? sender, MouseEventArgs e)
        {
            Motion.AxisJog(1, 2, JogSpeed, Acc, Dec, 0);
        }
        private void BtnUp_MouseUp(object? sender, MouseEventArgs e)
        {
            Motion.AxisStop(1, 2, 0);
        }
        private void BtnDown_MouseDown(object? sender, MouseEventArgs e)
        {
            Motion.AxisJog(1, 2, -JogSpeed, Acc, Dec, 0);
        }
        private void BtnDown_MouseUp(object? sender, MouseEventArgs e)
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
        private void BtnStep_Click(object sender, EventArgs e)
        {
            ClearMouseEvent();
            BtnLeft.MouseUp += BtnLeft_MouseUp;
            BtnLeft.MouseDown += BtnLeft_MouseDown;

            BtnRight.MouseUp += BtnRight_MouseUp;
            BtnRight.MouseDown += BtnRight_MouseDown;

            BtnUp.MouseUp += BtnUp_MouseUp;
            BtnUp.MouseDown += BtnUp_MouseDown;

            BtnDown.MouseUp += BtnDown_MouseUp;
            BtnDown.MouseDown += BtnDown_MouseDown;

            ModeBackColor(sender);
        }
        private void BtnIndex_Click(object sender, EventArgs e)
        {
            ClearMouseEvent();

            BtnLeft.Click += BtnLeft_Click;

            BtnRight.Click += BtnRight_Click;

            BtnUp.Click += BtnUp_Click;

            BtnDown.Click += BtnDown_Click;

            ModeBackColor(sender);
        }
        private void ClearMouseEvent()
        {
            BtnLeft.Click -= BtnLeft_Click;
            BtnLeft.MouseUp -= BtnLeft_MouseUp;
            BtnLeft.MouseDown -= BtnLeft_MouseDown;

            BtnRight.Click -= BtnRight_Click;
            BtnRight.MouseUp -= BtnRight_MouseUp;
            BtnRight.MouseDown -= BtnRight_MouseDown;

            BtnUp.Click -= BtnUp_Click;
            BtnUp.MouseUp -= BtnUp_MouseUp;
            BtnUp.MouseDown -= BtnUp_MouseDown;

            BtnDown.Click -= BtnDown_Click;
            BtnDown.MouseUp -= BtnDown_MouseUp;
            BtnDown.MouseDown -= BtnDown_MouseDown;
        }
        private void BtnScan_Click(object sender, EventArgs e)
        {

        }
        private void ModeBackColor(object sender)
        {
            BtnStep.BackColor = Color.White;
            BtnIndex.BackColor = Color.White;
            BtnScan.BackColor = Color.White;
            Button btn = (Button)sender;
            btn.BackColor = Color.Orange;
        }

        private void BtnLeft_Click(object? sender, EventArgs e)
        {
            IndexMoveRel(-1,0);//向左
        }
        private void BtnRight_Click(object? sender, EventArgs e)
        {
            IndexMoveRel(1, 0);//向右
        }
        private void BtnUp_Click(object? sender, EventArgs e)
        {
            IndexMoveRel(0, -1);//向上
        }
        private void BtnDown_Click(object? sender, EventArgs e)
        {
            IndexMoveRel(0, 1);//向下
        }
        private void IndexMoveRel(int X, int Y)
        {
            if (RbtnAlign.Checked)
            {
                Motion.UserPosMoveRel(Compensation.Area.Align, X * WaferMap.Entity.DieSizeX, Y * WaferMap.Entity.DieSizeY);
            }
            else if (RbtnProbing.Checked)
            {
                Motion.UserPosMoveRel(Compensation.Area.Probing, X * WaferMap.Entity.DieSizeX, Y * WaferMap.Entity.DieSizeY);
            }
            else if (RbtnMotion.Checked)
            {
                Motion.XY_AxisMoveRel(1,-X * WaferMap.Entity.DieSizeX, -Y * WaferMap.Entity.DieSizeY,600,20,20,10);
            }
            WaferMap.CurrentIndexX += X;
            WaferMap.CurrentIndexY += Y;
        }
    }
}
