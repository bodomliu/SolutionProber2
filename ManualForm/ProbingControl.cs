using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
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
            panel1.Controls.Add(WaferMapCanvas.Canvas);
            panelIndexControl.Controls.Add(new WaferMapIndexControl());
            this.Dock = DockStyle.Fill;
        }
        private void ProbingControl_Load(object sender, EventArgs e)
        {
            TxtZDownPosition.Text = DeviceData.Entity.Probing.ZDownPosition.ToString("F0");
            TxtZUpPosition.Text = DeviceData.Entity.Probing.ZUpPosition.ToString("F0");
            TxtOverDrive.Text = DeviceData.Entity.Probing.Overdrive.ToString("F0");
            TxtFirstContact.Text = DeviceData.Entity.Probing.FirstContactHeight.ToString("F0");
            TxtAllContact.Text = DeviceData.Entity.Probing.AllContactHeight.ToString("F0");

            txtPad2PinX.Text = Motion.parameter.PROBING.XPad2Pin.ToString("F0");
            txtPad2PinY.Text = Motion.parameter.PROBING.YPad2Pin.ToString("F0");

            timer1.Start();
        }
        private void ProbingControl_ParentChanged(object sender, EventArgs e)
        {

        }
        private void UpdateUI()
        {
            //当Y大于分界线时，表示在Probe区域
            if (Motion.GetEncPos(1, 2) > Motion.parameter.PROBEDIVIDEY)
            {
                //BtnWaferPinAlign.Enabled = false;
                //当Z大于分界线时，表示在扎针状态
                if (Motion.GetEncPos(1, 3) > DeviceData.Entity.Probing.ZUpPosition + DeviceData.Entity.Probing.ZClearance / 2)
                {
                    BtnZToggle.Text = "Z Down";
                    BtnZToggle.BackColor = Color.Red;
                    //BtnInspection.Enabled = false;
                }
                else
                {
                    BtnZToggle.Text = "Z Up";
                    BtnZToggle.BackColor = Color.YellowGreen;
                    //BtnInspection.Enabled = true;
                }
            }
            else
            {
                //只有在Align区域，才给运动到Probe区域
                //BtnWaferPinAlign.Enabled = true;
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
        //public delegate void OnBtnInspectionClickHander(); //定义一个委托
        //public static event OnBtnInspectionClickHander? OnBtnInspectionClick;
        private async void BtnInspection_Click(object sender, EventArgs e)
        {
            //临时的代码，用于单pin实验
            double deltaX = Motion.parameter.PROBING.XPad2Pin + PinData.Entity.RefPinX
                - Motion.parameter.PROBING.XOrgPin + DeviceData.Entity.Probing.ProbingShiftX;
            double deltaY = Motion.parameter.PROBING.YPad2Pin + PinData.Entity.RefPinY
                - Motion.parameter.PROBING.YOrgPin + DeviceData.Entity.Probing.ProbingShiftY;
            //先降至waferheight
            Motion.AxisMoveAbs(1, 3, WaferMap.WaferHeight, 600, 10, 10, 20);
            //获取当前userPos
            Motion.GetUserPos(Compensation.Area.Probing, out double userPosX, out double userPosY);
            //计算平移
            Compensation.Transform(Compensation.Area.Align, Compensation.Dir.User2Encode, userPosX, userPosY, out double encodeX, out double encodeY);
            //将当前点位进行虚拟pad2pin的逆向移动
            encodeX -= deltaX;encodeY -= deltaY;
            await Task.Run(() =>
            {
                Motion.XY_AxisMoveAbs(1,encodeX,encodeY,600,10,10,20);
            });
            UpdateUI();
        }
        private async void BtnWaferPinAlign_Click(object sender, EventArgs e)
        {
            //临时的代码，用于单pin实验
            //考虑Pad需要再运行offset才能被珍扎到，该offset为机台最初标定时确定
            //Pin针位置也与最初标定时发生变化
            //最外层的ProbingShift
            //获得所有的offset合计
            double deltaX = Motion.parameter.PROBING.XPad2Pin + PinData.Entity.RefPinX
               - Motion.parameter.PROBING.XOrgPin + DeviceData.Entity.Probing.ProbingShiftX;
            double deltaY = Motion.parameter.PROBING.YPad2Pin + PinData.Entity.RefPinY
                - Motion.parameter.PROBING.YOrgPin + DeviceData.Entity.Probing.ProbingShiftY;
            //获得当前Encode位置
            Motion.XY_GetEncPos(out double encodeX,out double encodeY);
            //将当前点位进行虚拟pad2pin移动
            Compensation.Transform(Compensation.Area.Align, Compensation.Dir.Encode2User, encodeX + deltaX, encodeY + deltaY, out double userPosX, out double userPosY);
            //运行到Proing位置
            await Task.Run(() =>
            {
                Motion.UserPosMoveAbs(Compensation.Area.Probing, userPosX, userPosY);
            });
            Motion.AxisMoveAbs(1, 3, DeviceData.Entity.Probing.ZDownPosition, 600, 10, 10, 20);
            UpdateUI();
        }
        private void BtnFirstContact_Click(object sender, EventArgs e)
        {
            DeviceData.Entity.Probing.FirstContactHeight = double.Parse(TxtFirstContact.Text);
        }
        private void BtnAllContact_Click(object sender, EventArgs e)
        {
            DeviceData.Entity.Probing.AllContactHeight = double.Parse(TxtAllContact.Text);
        }
        private void BtnUp_Click(object sender, EventArgs e)
        {

        }
        private void BtnDown_Click(object sender, EventArgs e)
        {

        }
        private void BtnSetOverDrive_Click(object sender, EventArgs e)
        {
            DeviceData.Entity.Probing.Overdrive = int.Parse(TxtOverDrive.Text);
            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //如果使用用户坐标系
            double X = (CbCompensation.Checked) ? Motion.UserX : Motion.EncodeX;
            double Y = (CbCompensation.Checked) ? Motion.UserY : Motion.EncodeY;
            double Z = Motion.EncodeZ;
            double R = Motion.EncodeR;

            txtEncodeX.Text = X.ToString("F0");
            txtEncodeY.Text = Y.ToString("F0");
            txtEncodeZ.Text = Z.ToString("F0");
            txtEncodeR.Text = R.ToString("F0");
        }
    }
}
