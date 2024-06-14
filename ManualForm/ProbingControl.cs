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
using VisionLibrary;
using WaferMapLibrary;
namespace ManualForm
{
    public partial class ProbingControl : UserControl
    {
        public ProbingControl()
        {
            InitializeComponent();
            panel1.Controls.Add(WaferMapCanvas.Canvas);
            groupBox5.Controls.Add(new WaferMapIndexControl(true));
            this.Dock = DockStyle.Fill;
        }
        private void ProbingControl_Load(object sender, EventArgs e)
        {
            UpdateUI();
            ParentForm.FormClosed += (sender, e) =>
            {
                Dispose(true);
            };

            timer1.Start();
        }

        private void ProbingControl_ParentChanged(object sender, EventArgs e)
        {

        }
        private void UpdateUI()
        {
            TxtZDownPosition.Text = DeviceData.Entity.Probing.ZDownPosition.ToString("F0");
            TxtZUpPosition.Text = DeviceData.Entity.Probing.ZUpPosition.ToString("F0");
            TxtOverDrive.Text = DeviceData.Entity.Probing.Overdrive.ToString("F0");
            TxtFirstContact.Text = DeviceData.Entity.Probing.FirstContactHeight.ToString("F0");
            TxtAllContact.Text = DeviceData.Entity.Probing.AllContactHeight.ToString("F0");

            txtPad2PinX.Text = Motion.parameter.PROBING.XPad2Pin.ToString("F0");
            txtPad2PinY.Text = Motion.parameter.PROBING.YPad2Pin.ToString("F0");

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
            encodeX -= deltaX; encodeY -= deltaY;

            //求pad因为旋转产生的位移
            CommonFunctions.RotatePoint(encodeX, encodeY, Motion.parameter.XROTATE, Motion.parameter.YROTATE,
                -PinData.Entity.PinsAngle, out double Xout, out double Yout);

            await Task.Run(() =>
            {
                Motion.AxisMoveRel(1, 4, -PinData.Entity.PinsAngle, 600, 10, 10, 20);
                Motion.XY_AxisMoveAbs(1, Xout, Yout, 600, 10, 10, 20);
            });
            UpdateUI();
        }
        private async void BtnWaferPinAlign_Click(object sender, EventArgs e)
        {
            //临时的代码，用于单pin实验
            //考虑Pad需要再运行offset才能被珍扎到，该offset为机台最初标定时确定
            //Pin针位置也与最初标定时发生变化
            //旋转pinAngle导致的位移
            //最外层的ProbingShift
            //获得所有的offset合计
            double deltaX = Motion.parameter.PROBING.XPad2Pin + PinData.Entity.RefPinX
               - Motion.parameter.PROBING.XOrgPin + DeviceData.Entity.Probing.ProbingShiftX;
            double deltaY = Motion.parameter.PROBING.YPad2Pin + PinData.Entity.RefPinY
                - Motion.parameter.PROBING.YOrgPin + DeviceData.Entity.Probing.ProbingShiftY;

            //获得当前Encode位置
            Motion.XY_GetEncPos(out double encodeX, out double encodeY);
            //求pad因为旋转产生的位移
            CommonFunctions.RotatePoint(encodeX, encodeY, Motion.parameter.XROTATE, Motion.parameter.YROTATE,
                PinData.Entity.PinsAngle, out double Xout, out double Yout);
            double xCausedByAngle = Xout - encodeX; double yCausedByAngle = Yout - encodeY;

            //将当前点位进行虚拟pad2pin移动
            Compensation.Transform(Compensation.Area.Align, Compensation.Dir.Encode2User,
                encodeX + deltaX + xCausedByAngle, encodeY + deltaY + yCausedByAngle, out double userPosX, out double userPosY);
            //运行到Proing位置
            await Task.Run(() =>
            {
                Motion.UserPosMoveAbs(Compensation.Area.Probing, userPosX, userPosY);
            });
            Motion.AxisMoveRel(1, 4, PinData.Entity.PinsAngle, 600, 10, 10, 20);
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
        private async void BtnSetProbeStartDie_Click(object sender, EventArgs e)
        {
            WaitingControl.WF.Start();
            await Task.Run(() =>
            {
                CommonFunctions.PinPadMatch();
            });
            WaitingControl.WF.End();
        }

        private async void BtnShowZRepeatUtility_Click(object sender, EventArgs e)
        {
            WaitingControl.WF.Start();

            if (WaferMap.Entity.MappingPoints == null) return;
            //遍历ErrorMap，选取所有Coordinates = 1
            List<MappingPoint> toChkPts = WaferMap.Entity.MappingPoints.Where(p => p.Order != 0).ToList();
            var sortList = toChkPts.OrderBy(o => o.Order).ToList();
            for (int i = 0; i < sortList.Count; i++)
            {
                await Task.Run(() =>
                {
                    WaferMap.CurrentIndexX = sortList[i].IndexX;
                    WaferMap.CurrentIndexY = sortList[i].IndexY;
                    CommonFunctions.PinPadMatch();
                });
                Motion.AxisMoveAbs(1, 3, DeviceData.Entity.Probing.ZUpPosition + DeviceData.Entity.Probing.Overdrive, 600, 10, 10, 20);                
                Thread.Sleep(3000);
                Motion.AxisMoveAbs(1, 3, DeviceData.Entity.Probing.ZDownPosition, 600, 10, 10, 20);
                Thread.Sleep(1000);
            }
            
            WaitingControl.WF.End();
        }
    }
}
