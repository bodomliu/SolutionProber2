using CommonComponentLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WaferMapLibrary;

namespace ErrorCompensation
{
    public partial class ErrorCanvas : UserControl
    {
        public static ErrorCanvas Entity = new ErrorCanvas();
        public ErrorCanvas()
        {
            InitializeComponent();
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
        public void DrawPoint(int indexX, int indexY, double errorX, double errorY)
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
        private void BtnClearPicturebox_Click(object sender, EventArgs e)
        {
            RefreshChart();
        }

        private void ErrorCanvas_Load(object sender, EventArgs e)
        {
            WaferMapCanvas mapCanvas = WaferMapCanvas.Canvas;
            panelMap.Controls.Add(mapCanvas);
            mapCanvas.LoadCanvas();
        }
    }
}
