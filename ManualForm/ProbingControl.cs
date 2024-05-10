using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonComponentLibrary;
using MotionLibrary;
using WaferMapLibrary;
namespace ManualForm
{
    public partial class ProbingControl : UserControl
    {
        public ProbingControl()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private void ProbingControl_Load(object sender, EventArgs e)
        {

        }

        private void ProbingControl_ParentChanged(object sender, EventArgs e)
        {
            if (this.Parent != null)
            {
                panel1.Controls.Clear();
                panel1.Controls.Add(WaferMapCanvas.Canvas);
            }
        }

        private void UpdateUI()
        {
            //当Y大于分界线时，表示在Probe区域
            if (Motion.GetEncPos(1, 2) > Motion.parameter.PROBEDIVIDEY)
            {
                BtnWaferPinAlign.Enabled = false;
                //当Z大于分界线时，表示在扎针状态
                if (Motion.GetEncPos(1, 3) > DeviceData.Entity.Probing.ZUpPosition + DeviceData.Entity.Probing.ZClearance / 2)
                {
                    BtnZToggle.Text = "Z Down";
                    BtnZToggle.BackColor = Color.Red;
                    BtnInspection.Enabled = false;
                }
                else
                {
                    BtnZToggle.Text = "Z Up";
                    BtnZToggle.BackColor = Color.YellowGreen;
                    BtnInspection.Enabled = true;
                }
            }
            else
            {
                //只有在Align区域，才给运动到Probe区域
                BtnWaferPinAlign.Enabled = true;
            }
        }
        private void BtnApply_Click(object sender, EventArgs e)
        {

        }

        private void BtnZToggle_Click(object sender, EventArgs e)
        {
            BtnZToggle.Enabled = false;

            //当Z大于分界线时，表示在扎针状态
            if (Motion.GetEncPos(1, 3) > DeviceData.Entity.Probing.ZUpPosition + DeviceData.Entity.Probing.ZClearance / 2)
            {
                Motion.AxisMoveAbs(1, 3, DeviceData.Entity.Probing.ZDownPosition, 600, 10, 10, 20);
            }
            else
            {
                Motion.AxisMoveAbs(1, 3, DeviceData.Entity.Probing.ZUpPosition + DeviceData.Entity.Probing.Overdrive, 600, 10, 10, 20);
            }
            BtnZToggle.Enabled = true;
            UpdateUI();
        }

        public delegate void OnBtnInspectionClickHander(); //定义一个委托
        public static event OnBtnInspectionClickHander? OnBtnInspectionClick;
        private void BtnInspection_Click(object sender, EventArgs e)
        {
            //临时的代码，用于单pin实验
            double deltaX = Motion.parameter.PROBING.XPad2Pin + PinData.Entity.RefPinX 
                - Motion.parameter.PROBING.XOrgPin + DeviceData.Entity.Probing.ProbingShiftX;
            double deltaY = Motion.parameter.PROBING.YPad2Pin + PinData.Entity.RefPinY 
                - Motion.parameter.PROBING.YOrgPin + DeviceData.Entity.Probing.ProbingShiftY;

            Motion.XY_AxisMoveRel(1, -deltaX, -deltaY, 600, 10, 10, 20);
            Motion.GetUserPos(Compensation.Area.Probing, out double userPosX, out double userPosY);
            Motion.UserPosMoveAbs(Compensation.Area.Align, userPosX, userPosY);
            if (OnBtnInspectionClick != null) OnBtnInspectionClick();
        }

        private void BtnWaferPinAlign_Click(object sender, EventArgs e)
        {
            //临时的代码，用于单pin实验
            //获得当前位置
            Motion.GetUserPos(Compensation.Area.Align, out double userPosX, out double userPosY);
            //运行到Proing位置
            Motion.UserPosMoveAbs(Compensation.Area.Probing, userPosX, userPosY);
            //考虑Pad需要再运行offset才能被珍扎到，该offset为机台最初标定时确定
            //Pin针位置也与最初标定时发生变化 
            //最外层的ProbingShift
            double deltaX = Motion.parameter.PROBING.XPad2Pin + PinData.Entity.RefPinX 
                - Motion.parameter.PROBING.XOrgPin + DeviceData.Entity.Probing.ProbingShiftX;
            double deltaY = Motion.parameter.PROBING.YPad2Pin + PinData.Entity.RefPinY 
                - Motion.parameter.PROBING.YOrgPin + DeviceData.Entity.Probing.ProbingShiftY;
            Motion.XY_AxisMoveRel(1, deltaX, deltaY, 600, 10, 10, 20);
        }

        private void BtnFirstContact_Click(object sender, EventArgs e)
        {
            DeviceData.Entity.Probing.FirstContactHeight = double.Parse(TxtFirstContact.Text);
        }

        private void BtnAllContact_Click(object sender, EventArgs e)
        {
            DeviceData.Entity.Probing.AllContactHeight = double.Parse(TxtAllContact.Text);
        }
    }
}
