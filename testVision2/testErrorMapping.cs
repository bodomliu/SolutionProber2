using MotionLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GTN.mc_la;
using WaferMapLibrary;
using static MotionLibrary.Compensation;
using System.Reflection;
using System.Drawing.Imaging;
using CommonComponentLibrary;

namespace test
{
    public partial class testErrorMapping : Form
    {
        public testErrorMapping()
        {
            InitializeComponent();

            TbarX.Minimum = Motion.parameter.XLIMITN;
            TbarX.Maximum = Motion.parameter.XLIMITP;
            NumEncodeX.Minimum = Motion.parameter.XLIMITN;
            NumEncodeX.Maximum = Motion.parameter.XLIMITP;

            TbarY.Minimum = Motion.parameter.YLIMITN;
            TbarY.Maximum = Motion.parameter.YLIMITP;
            NumEncodeY.Minimum = Motion.parameter.YLIMITN;
            NumEncodeY.Maximum = Motion.parameter.YLIMITP;


            WaferMapCanvas mapCanvas = WaferMapCanvas.Canvas;
            panel1.Controls.Add(mapCanvas);
            mapCanvas.LoadCanvas();
        }

        RectangleF[]? rects;
        private void testErrorMapping_Load(object sender, EventArgs e)
        {
            Compensation.Initial();

            //将grids的值都赋值给RectangleF
            var grids = Compensation.CalibrationGrids;
            if (grids == null) return;
            rects = new RectangleF[grids.Count];

            for (int i = 0; i < grids.Count; i++)
            {
                RectangleF rect = Grid2Rect(grids[i]);
                rects[i] = rect;
            }

            RefreshBackground();
        }

        private void encode2Pixel(double encodeX, double encodeY, out float pixelX, out float pixelY)
        {
            double Xmin = (double)NumEncodeX.Minimum;
            double Xmax = (double)NumEncodeX.Maximum;
            double Ymin = (double)NumEncodeY.Minimum;
            double Ymax = (double)NumEncodeY.Maximum;
            double Xpar = (encodeX - Xmin) / (Xmax - Xmin);
            double Ypar = (encodeY - Ymin) / (Ymax - Ymin);
            pixelX = (float)Xpar * canvas.Width;
            pixelY = (float)(1 - Ypar) * canvas.Height;
        }
        private void TbarX_Scroll(object sender, EventArgs e)
        {
            NumEncodeX.Value = TbarX.Value;
        }

        private void TbarY_Scroll(object sender, EventArgs e)
        {
            NumEncodeY.Value = TbarY.Value;
        }

        private void NumEncodeX_ValueChanged(object sender, EventArgs e)
        {
            TbarX.Value = (int)NumEncodeX.Value;
            updateUserPos();
        }

        private void NumEncodeY_ValueChanged(object sender, EventArgs e)
        {
            TbarY.Value = (int)NumEncodeY.Value;
            updateUserPos();
        }

        private void updateUserPos()
        {
            double X = double.NaN; double Y = double.NaN;
            if (RbtnAlign.Checked) Compensation.Transform(Compensation.Area.Align, Compensation.Dir.Encode2User,
                (double)NumEncodeX.Value, (double)NumEncodeY.Value, out X, out Y);
            if (RbtnProbing.Checked) Compensation.Transform(Compensation.Area.Align, Compensation.Dir.Encode2User,
                (double)NumEncodeX.Value, (double)NumEncodeY.Value, out X, out Y);

            TxtUserPosX.Text = X.ToString();
            TxtUserPosY.Text = Y.ToString();

            //draw it
            RefreshBackground();
            DrawPoint();
        }

        //drawBackground
        private void RefreshBackground()
        {
            float penWidth = 1;//画线条的粗细，默认=1
            Bitmap bitmap = new Bitmap(canvas.Width, canvas.Height);
            Graphics gp = Graphics.FromImage(bitmap);
            if (rects != null) gp.DrawRectangles(new Pen(Color.Black, penWidth), rects);
            canvas.Image = bitmap;
        }

        private void DrawPoint()
        {
            double encodeX = (double)NumEncodeX.Value;
            double encodeY = (double)NumEncodeY.Value;
            Graphics gp = Graphics.FromImage(canvas.Image);
            encode2Pixel(encodeX, encodeY, out float pixelX, out float pixelY);
            //画当前的点
            gp.FillEllipse(new SolidBrush(Color.Blue), pixelX, pixelY, 10, 10);
            //画NearestGird
            if (Compensation.CalibrationGrids == null) return;
            Grid nearestGrid = Compensation.NearestGrid(Dir.Encode2User, Compensation.CalibrationGrids, encodeX, encodeY);
            RectangleF rect = Grid2Rect(nearestGrid);
            gp.FillRectangle(new SolidBrush(Color.Purple), rect);
        }

        private RectangleF Grid2Rect(Grid grid)
        {
            double LUX = grid.Pt[1].EncodeX;
            double LUY = grid.Pt[1].EncodeY;
            double RDX = grid.Pt[3].EncodeX;
            double RDY = grid.Pt[3].EncodeY;
            encode2Pixel(LUX, LUY, out float pixelLUX, out float pixelLUY);
            encode2Pixel(RDX, RDY, out float pixelRDX, out float pixelRDY);
            float width = (float)(pixelRDX - pixelLUX);
            float height = (float)(pixelRDY - pixelLUY);
            RectangleF rect = new RectangleF(pixelLUX, pixelLUY, width, height);
            return rect;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Motion.Save("Config/MotionParameter.json");
        }
    }
}
