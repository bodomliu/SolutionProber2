﻿using WaferMapLibrary;
using VisionLibrary;
using MotionLibrary;
namespace CommonComponentLibrary
{
    public partial class CommonPanel : UserControl
    {
        //public static CommonPanel Entity = new CommonPanel();//这个写法有问题
        public static CommonPanel Entity => new();//改为静态变量，避免消耗太多资源
        public static int IndexX = 0;//独立的用于显示的Index
        public static int IndexY = 0;//独立的用于显示的Index
        private double ZeroX = 0, ZeroY = 0, ZeroZ = 0;//临时用户坐标系
        public CommonPanel()
        {
            InitializeComponent();

            //优化为在构造函数添加
            canvas.Controls.Add(Vision.m_HSmartWindowControl);
            Vision.m_HSmartWindowControl.Dock = DockStyle.Fill;

            canvas.MouseWheel += M_HSmartWindowControl_HMouseWheel;
        }
        private void UserControl_Load(object sender, EventArgs e)
        {
            TimMotion.Start();

            BtnSetZeroPosition.Visible = false;

            JogSlow_Click(JogSlow, e);//初始slow速度
            BtnStep_Click(BtnStep, e);//初始Step模式
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
            JogSpeed = 10;
            Acc = 10;
            Dec = 10;
            JogBackColor(sender);
        }
        private void JogFast_Click(object sender, EventArgs e)
        {
            JogSpeed = 20;
            Acc = 20;
            Dec = 20;
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
                BtnTogglePosition.Text = "Toggle Position (Match_With_Move)";
            }
            BtnSetZeroPosition.Visible = !BtnSetZeroPosition.Visible;//变更ZeroPosion可见性
        }
        private void BtnSetZeroPosition_Click(object sender, EventArgs e)
        {
            //需要在相同坐标系来做差
            if (CbCompensation.Checked)
            {
                Motion.GetUserPos(Motion.CurrentArea, out ZeroX, out ZeroY);
            }
            else
            {
                Motion.XY_GetEncPos(out ZeroX, out ZeroY);
            }
            ZeroZ = Motion.GetEncPos(1, 3);
        }
        //跨线程调用
        private delegate void delegateLabelUI(bool isAlign);
        private void UpdateLabelUI(bool isAlign)
        {
            LblIsProbingArea.Text = (isAlign) ? "Align Area" : "Probing Area";
            LblIsProbingArea.BackColor = (isAlign) ? Color.LimeGreen : Color.Red;
        }
        private delegate void delegateTextboxUI(double[] pos);
        private void UpdateTextboxUI(double[] pos)
        {
            txtEncodeX.Text = (pos[0] - ZeroX).ToString("F0");
            txtEncodeY.Text = (pos[1] - ZeroY).ToString("F0");
            txtEncodeZ.Text = (pos[2] - ZeroZ).ToString("F0");
            txtEncodeR.Text = pos[3].ToString("F0");

            TxtIndex.Text = "X:" + WaferMap.CurrentIndexX.ToString() +
                "      Y:" + WaferMap.CurrentIndexY.ToString();
        }
        private void TimMotion_Tick(object sender, EventArgs e)
        {
            //当Y值很大时，Area变更
            bool isAlign = (Motion.CurrentArea == Compensation.Area.Align) ? true : false;
            if (IsHandleCreated) BeginInvoke(new delegateLabelUI(UpdateLabelUI), isAlign);

            //如果使用用户坐标系
            double X = (CbCompensation.Checked) ? Motion.UserX : Motion.EncodeX;
            double Y = (CbCompensation.Checked) ? Motion.UserY : Motion.EncodeY;
            double Z = Motion.EncodeZ;
            double R = Motion.EncodeR;

            //注意当跨区使用时，不能用户坐标系
            if (IsHandleCreated) BeginInvoke(new delegateTextboxUI(UpdateTextboxUI), new double[] { X, Y, Z, R });
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
        private void M_HSmartWindowControl_HMouseWheel(object? sender, MouseEventArgs e)
        {
            Vision.m_HSmartWindowControl.HSmartWindowControl_MouseWheel(sender, e);
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
            IndexMoveRel(-1, 0);//向左
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
            if (CbCompensation.Checked)
            {
                Motion.UserPosMoveRel(Motion.CurrentArea, X * WaferMap.Entity.DieSizeX, Y * WaferMap.Entity.DieSizeY);
            }
            else
            {
                Motion.XY_AxisMoveRel(1, -X * WaferMap.Entity.DieSizeX, Y * WaferMap.Entity.DieSizeY, 600, 20, 20, 10);
            }
            IndexX += X;
            IndexY += Y;
        }

        private void CommonPanel_ParentChanged(object sender, EventArgs e)
        {

        }

        private async void BtnMinorAdjustment_Click(object sender, EventArgs e)
        {
            WaitingControl.WF.Start();

            if (Vision.activeCamera == Camera.WaferLowMag)
            {
                await Task.Run(() =>
                AdjustHeight.MinorAdjustment(Vision.WaferLowMag)
                );
            }
            else if (Vision.activeCamera == Camera.WaferHighMag)
            {
                await Task.Run(() =>
                AdjustHeight.MinorAdjustment(Vision.WaferHighMag)
                );
            }

            WaitingControl.WF.End();
        }
    }
}
