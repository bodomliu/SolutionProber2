using CommonComponentLibrary;
using VisionLibrary;
using MotionLibrary;
using WaferMapLibrary;
using ErrorCompensation;

namespace MainForm
{
    public partial class ErrorCompensationForm : Form
    {
        bool StopFlag = true;//连续运行的flag
        
        public ErrorCompensationForm()
        {
            this.TopLevel = false; this.FormBorderStyle = FormBorderStyle.None;

            InitializeComponent();

            WaferMapIndexControl indexControl = new WaferMapIndexControl();
            panelIndexControl.Controls.Add(indexControl);

            WaferMapCanvas mapCanvas1 = WaferMapCanvas.Canvas;
            panelMapMini.Controls.Add(mapCanvas1);
            mapCanvas1.LoadCanvas();
        }
        private void ErrorCompensationForm_Load(object sender, EventArgs e)
        {
            //默认是Align Camera
            Vision.ChangeCamera(Vision.WaferHighMag);
            RbtnWaferCamera.Checked = true;
        }
        private void ErrorCompensationForm_VisibleChanged(object sender, EventArgs e)
        {
           
        }
        private void BtnMapScreen_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            if (BtnMapScreen.Text == "Map Screen")
            {
                BtnMapScreen.Text = "Camera Screen";
                panel1.Controls.Add(ErrorCanvas.Entity);
            }
            else
            {
                BtnMapScreen.Text = "Map Screen";
                panel1.Controls.Add(CommonPanel.Entity);

            }
        }

        private void RbtnWaferCamera_CheckedChanged(object sender, EventArgs e)
        {
            //两个radio button都会指向同一个事件
            if (RbtnWaferCamera.Checked)
            {
                Vision.ChangeCamera(Vision.WaferHighMag);
            }
            else if (RbtnJigCamera.Checked)
            {
                Vision.ChangeCamera(Vision.JigCamera);
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            CameraClass mag = (RbtnWaferCamera.Checked) ? Vision.WaferHighMag : Vision.JigCamera;
            mag.TriggerMode();
            StopFlag = false;//只有点了Start才置Flag

            //临时代码，先将高度运动到平均高度，定好位再做，不然不行
            //Motion.AxisMoveAbs(1, 3, WaferMap.Thickness, 600, 10, 10, 20);

            if (RbtnAllMap.Checked)
            {
                AlignAllMap();
            }
            else if (RbtnCross.Checked)
            {
                AlignCrossX(); AlignCrossY();
            }
            else if (RbtnSelective.Checked)
            {


            }
            mag.ContinuesMode();
        }
        private void AlignCrossX()
        {
            int OriginY = WaferMap.Entity.RefDieY;
            for (int indexX = 0; indexX < WaferMap.Entity.DieNumX; indexX++)
            {
                AlignPosition(indexX, OriginY);
            }
        }
        private void AlignCrossY()
        {
            int OriginX = WaferMap.Entity.RefDieX;
            for (int indexY = 0; indexY < WaferMap.Entity.DieNumY; indexY++)
            {
                AlignPosition(OriginX, indexY);
            }
        }
        private void AlignAllMap()
        {
            for (int indexY = 0; indexY < WaferMap.Entity.DieNumY; indexY++)
            {
                for (int indexX = 0; indexX < WaferMap.Entity.DieNumX; indexX++)
                {
                    AlignPosition(indexX, indexY);
                }
            }
        }
        //特征校准
        private void AlignPosition(int indexX, int indexY)
        {
            if (StopFlag) return;

            //获取该index位置的用户位置posx和posy
            //不是标定点，不需要进行后续align
            if (WaferMap.GetBIN(indexX, indexY) != 1) return;

            //计算插补后的坐标位置，需要加上highAlign后的晶圆偏移，根据哪支相机被激活了，确认去哪个区域标定
            Compensation.Area area = (RbtnWaferCamera.Checked) ? Compensation.Area.Align : Compensation.Area.Probing;
            CommonFunctions.IndexMove(area, indexX, indexY);

            //去做运动校准
            CameraClass mag = (RbtnWaferCamera.Checked) ? Vision.WaferHighMag : Vision.JigCamera;

            int res = CommonFunctions.Match_Without_Move(DeviceData.Entity.WaferAlignment.HighPattern1, mag, out double deltaX, out double deltaY, out double encodeX, out double encodeY);
            //未匹配到模板
            if (res != 0) { WaferMap.SetBIN(indexX, indexY, 5); return; }

            if (RbtnCheckOnly.Checked)
            {
                //绘制点，插值计算后的走点 - 校准后的理想点 = 差异
                ErrorCanvas.Entity.DrawPoint(indexX, indexY, deltaX, deltaY);
                WaferMap.SetBIN(indexX, indexY, 4);
            }
            else if (RbtnWriteData.Checked)
            {
                ////完事后覆盖encode值
                SetMappingValue(indexX, indexY, encodeX, encodeY, 4);
            }
        }
        private static int SetMappingValue(int indexX, int indexY, double encodeX, double encodeY, int bin)
        {
            if (WaferMap.Entity.MappingPoints == null) return 1;

            var point = WaferMap.Entity.MappingPoints.Find(p => p.IndexX == indexX && p.IndexY == indexY);
            if (point == null) return 2;

            //point.UserPosX = userPosX; point.UserPosY = userPosY;
            point.EncodeX = encodeX; point.EncodeY = encodeY;
            point.BIN = bin;
            //point.Coordinates = 1;

            return 0;
        }
        private void BtnStop_Click(object sender, EventArgs e)
        {
            StopFlag = true;
        }
        private void BtnClear_Click(object sender, EventArgs e)
        {
            WaferMap.Load("DeviceData/" + DeviceData.Entity.PhysicalInformation.DeviceName + "WaferMap.json");
            WaferMapCanvas.Canvas.RefreshCanvas();
        }
        private void BtnApply_Click(object sender, EventArgs e)
        {
            BtnApply.Enabled = false;
            Compensation.Initial();
            MessageBox.Show("Initial Compelete!");
            BtnApply.Enabled = true;
        }

        //private static bool IsProbeArea = false;//默认不是probe区域，而是Align区
        private void BtnZ_Click(object sender, EventArgs e)
        {
            BtnZ.Enabled = false;//临时性禁止点击
            //如果当前不在probe区，则去往probe；如果当前在Probe区，则回来Align
            if (Motion.CurrentArea == Compensation.Area.Align)
            {
                Motion.GetUserPos(Compensation.Area.Align, out double userPosX, out double userPosY);
                Motion.UserPosMoveAbs(Compensation.Area.Probing, userPosX, userPosY);
                Motion.AxisMoveRel(1, 3, Motion.parameter.ZALIGN2PROBE, 600, 10, 10, 20);
                BtnZ.Text = "Z down";
                BtnZ.BackColor = Color.Green;
            }
            else if (Motion.CurrentArea == Compensation.Area.Probing)
            {
                Motion.GetUserPos(Compensation.Area.Probing, out double userPosX, out double userPosY);
                Motion.AxisMoveRel(1, 3, -Motion.parameter.ZALIGN2PROBE, 600, 10, 10, 20);
                Motion.UserPosMoveAbs(Compensation.Area.Align, userPosX, userPosY);
                BtnZ.Text = "Z up";
                BtnZ.BackColor = Color.Red;
            }
            BtnZ.Enabled = true;//恢复
        }
        private void BtnAdjustWaferHeight_Click(object sender, EventArgs e)
        {
            WaitingControl wf = new WaitingControl();
            this.Controls.Add(wf);
            wf.Show();

            if (Vision.activeCamera == Camera.JigCamera)
            {
                AdjustHeight.WaferFocus(Vision.JigCamera, true);              
            }
            else if (Vision.activeCamera == Camera.WaferHighMag)
            {
                AdjustHeight.WaferFocus(Vision.WaferHighMag, true);
            }

            wf.Dispose();
        }
        private void BtnResetErrorTable_Click(object sender, EventArgs e)
        {

        }
        private void BtnWaferAlignment_Click(object sender, EventArgs e)
        {
            //临时代码

        }
        private void BtnMatch_Click(object sender, EventArgs e)
        {
            //去做运动校准
            CameraClass mag = (RbtnWaferCamera.Checked) ? Vision.WaferHighMag : Vision.JigCamera;

            CommonFunctions.Match_With_Move(DeviceData.Entity.WaferAlignment.HighPattern1, mag, out double DeltaX, out double DeltaY);
        }

        private void ErrorCompensationForm_ParentChanged(object sender, EventArgs e)
        {
            //静态添加
            if (Parent!=null)
            {
                panel1.Controls.Clear();
                panel1.Controls.Add(CommonPanel.Entity);
                BtnMapScreen.Text = "Map Screen" ;
            }
            else { }
        }
    }
}
