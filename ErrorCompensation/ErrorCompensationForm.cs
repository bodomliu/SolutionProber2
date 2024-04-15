using CommonComponentLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisionLibrary;
using WaferMapLibrary;
//using static CommonComponentLibrary.AlignmentForm;

namespace MotionLibrary
{
    /// <summary>
    /// 0 = 标定区；1 = 工作区
    /// </summary>
    public enum Area
    {
        Align = 0,
        Probing = 1,
    }

    public partial class ErrorCompensationForm : Form
    {
        //WaferMapCanvas mapCanvas = new();

        CommonPanel commonPanel;//引入通用的CommonPanel

        bool StopFlag = true;//连续运行的flag
        public ErrorCompensationForm()
        {
            this.TopLevel = false; this.FormBorderStyle = FormBorderStyle.None;

            InitializeComponent();
            //CommonPanelt添加
            commonPanel = new CommonPanel();
            this.Controls.Add(commonPanel);
            this.Controls.SetChildIndex(commonPanel, 0);

            WaferMapIndexControl indexControl = new WaferMapIndexControl();
            panelIndexControl.Controls.Add(indexControl);

            WaferMapCanvas mapCanvas = WaferMapCanvas.Canvas;
            panelMap.Controls.Add(mapCanvas);
            mapCanvas.LoadCanvas();

            //WaferMapCanvas mapCanvasMini = new WaferMapCanvas();
            //panelMapMini.Controls.Add(mapCanvasMini);
            //mapCanvasMini.Dock = DockStyle.Fill;
        }

        private void ErrorCompensationForm_Load(object sender, EventArgs e)
        {
            //默认是Align Camera
            Vision.ChangeCamera(Vision.WaferHighMag);
            RbtnWaferCamera.Checked = true;

            //默认
            commonPanel.Visible = false;
            
            RefreshChart();
        }

        private void BtnMapScreen_Click(object sender, EventArgs e)
        {
            commonPanel.Visible = !commonPanel.Visible;
            BtnMapScreen.Text = (commonPanel.Visible) ? "Map Screen" : "Camera Screen";
        }

        private void RbtnWaferCamera_CheckedChanged(object sender, EventArgs e)
        {
            Vision.ChangeCamera(Vision.WaferHighMag);
            Vision.WaferHighMag.ContinuesMode();
        }

        private void RbtnJigCamera_CheckedChanged(object sender, EventArgs e)
        {
            Vision.ChangeCamera(Vision.JigCamera);
        }

        private void RefreshChart()
        {
            float penWidth = 1;//画线条的粗细，默认=1
            Bitmap bitmap = new Bitmap(pbX.Width, pbX.Height);
            Graphics gp = Graphics.FromImage(bitmap);
            for (int i = 0; i < 9; i++)
            {
                penWidth = (i == 4) ? 3 : 1;//中间一根线粗一点
                gp.DrawLine(new Pen(Color.Black, penWidth), 0, (i + 1) * pbX.Height / 10, pbX.Width, (i + 1) * pbX.Height / 10);
            }
            pbX.Image = bitmap;


            Bitmap bitmap2 = new Bitmap(pbY.Width, pbY.Height);
            Graphics gp2 = Graphics.FromImage(bitmap2);
            gp2.Clear(Color.White);
            for (int i = 0; i < 9; i++)
            {
                penWidth = (i == 4) ? 3 : 1;//中间一根线粗一点
                gp2.DrawLine(new Pen(Color.Black, penWidth), (i + 1) * pbY.Width / 10, 0, (i + 1) * pbY.Width / 10, pbY.Height);
            }
            pbY.Image = bitmap2;
        }

        private void DrawPoint(int indexX, int indexY, double errorX, double errorY)
        {
            Graphics gp = Graphics.FromImage(pbX.Image);
            float PointX = (indexX + 1) * pbX.Width / (WaferMap.Entity.DieNumX + 1);
            float PointY = (float)(pbX.Height / 2 + errorY / 10 * pbX.Height / 10);
            gp.FillEllipse(new SolidBrush(Color.Blue), PointX, PointY, 4, 4);
            pbX.Refresh();

            gp = Graphics.FromImage(pbY.Image);
            PointY = (indexY + 1) * pbY.Height / (WaferMap.Entity.DieNumY + 1);
            PointX = (float)(pbY.Width / 2 + errorX / 10 * pbY.Width / 10);
            gp.FillEllipse(new SolidBrush(Color.Blue), PointX, PointY, 4, 4);
            pbY.Refresh();
        }

        private void ErrorCompensationForm_Paint(object sender, PaintEventArgs e)
        {
            //panelMap.Controls.Add(WaferMap.Canvas);
            //WaferMap.Canvas.Dock = DockStyle.Fill;
            //WaferMap.Canvas.RefreshCanvas();

            //panelIndexControl.Controls.Add(WaferMap.IndexControl);
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
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
        }

        private void AlignCrossX()
        {
            int OriginY = WaferMap.Entity.OriginDieY;
            for (int indexX = 0; indexX < WaferMap.Entity.DieNumX; indexX++)
            {
                AlignPosition(indexX, OriginY);
            }
        }

        private void AlignCrossY()
        {
            int OriginX = WaferMap.Entity.OriginDieX;
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

            ////获取该index位置的用户位置posx和posy
            //WaferMap.GetMapPointValue(indexX, indexY, out double userPosX, out double userPosY, out _, out _, out _, out int coordinates);
            ////不是标定点，不需要进行后续align
            //if (coordinates == 0) return;

            ////计算插补后的坐标位置，需要加上highAlign后的晶圆偏移
            //Compensation.Area area = (IsProbeArea) ? Compensation.Area.Probing : Compensation.Area.Align;
            //Compensation.Transform(area, Compensation.Dir.User2Encode, userPosX + WaferMap.WaferOffsetX, userPosY + WaferMap.WaferOffsetY, out double encodeX, out double encodeY);

            ////为了绘制WaferMapCanvas
            //WaferMap.IndexX = indexX; WaferMap.IndexY = indexY;

            ////去做运动校准
            //VisionClass mag = (RbtnWaferCamera.Checked) ? Vision.WaferHighMag : Vision.JigCamera;
            //int res = Alignment.Align(WaferMap.HighModelPattern1, mag, encodeX, encodeY, out double encodeAfterAlignX, out double encodeAfterAlignY);
            ////未匹配到模板
            //if (res != 0) return;

            //if (RbtnCheckOnly.Checked)
            //{
            //    //绘制点，插值计算后的走点 - 校准后的理想点 = 差异
            //    DrawPoint(indexX, indexY, encodeX - encodeAfterAlignX, encodeY - encodeAfterAlignY);
            //}

            ////完事后覆盖encode值
            //if (RbtnWriteData.Checked)
            //{
            //    WaferMap.SetMapPointValue(indexX, indexY, userPosX + WaferMap.WaferOffsetX, userPosY + WaferMap.WaferOffsetY,
            //        encodeAfterAlignX, encodeAfterAlignY, 4, 1);
            //}
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            StopFlag = true;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            if (WaferMap.Entity.MappingPoints == null) return;

            foreach (var pt in WaferMap.Entity.MappingPoints)
            {
                pt.EncodeX = 0;
                pt.EncodeY = 0;
                if (pt.Coordinates == 1) { pt.Coordinates = 2; pt.BIN = 1; }
                if (pt.Coordinates == 2) { pt.Coordinates = 2; pt.BIN = 1; }
            }
            //WaferMap.Canvas.RefreshCanvas();
        }

        private void BtnClearPicturebox_Click(object sender, EventArgs e)
        {
            RefreshChart();
        }
        private void BtnSim_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 85; i++)
            {
                //DrawPoint(i, WaferMap.Entity.RefDieIndexY, 10, 5);
            }
        }
        private void BtnApply_Click(object sender, EventArgs e)
        {
            BtnApply.Enabled = false;
            Compensation.Initial();
            MessageBox.Show("Initial Compelete!");
            BtnApply.Enabled = true;
        }

        private static bool IsProbeArea = false;//默认不是probe区域，而是Align区
        private void BtnZ_Click(object sender, EventArgs e)
        {
            BtnZ.Enabled = false;//临时性禁止点击
            //如果当前不在probe区，则去往probe；如果当前在Probe区，则回来Align
            if (!IsProbeArea)
            {
                Motion.XYZ_AxisMoveRel(1, Motion.parameter.XALIGN2PROBE, Motion.parameter.YALIGN2PROBE, Motion.parameter.ZALIGN2PROBE, 600, 10, 10, 20);
                BtnZ.Text = "Z down";
                BtnZ.BackColor = Color.Green;
            }
            else if (IsProbeArea)
            {
                Motion.XYZ_AxisMoveRel(1, -Motion.parameter.XALIGN2PROBE, -Motion.parameter.YALIGN2PROBE, -Motion.parameter.ZALIGN2PROBE, 600, 10, 10, 20);
                BtnZ.Text = "Z up";
                BtnZ.BackColor = Color.Red;
            }

            IsProbeArea = !IsProbeArea;
            BtnZ.Enabled = true;//恢复
        }

        private void BtnAdjustWaferHeight_Click(object sender, EventArgs e)
        {
            if (RbtnWaferCamera.Checked)
            {
                //Alignment.AdjustWaferHeight(37000, 39000, Vision.WaferHighMag);
            }
            else if (RbtnJigCamera.Checked)
            {
                //Alignment.AdjustWaferHeight(37000, 39000, Vision.JigCamera);
            }
        }

        private void BtnResetErrorTable_Click(object sender, EventArgs e)
        {

        }
    }
}
