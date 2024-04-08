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

namespace CommonComponentLibrary
{
    public partial class WaferMapCanvas : UserControl
    {
        //private static WaferMapClass map = WaferMap.Entity;
        private PictureBox canvas = new();
        public WaferMapCanvas()
        {
            InitializeComponent();
            this.Controls.Add(canvas);
            canvas.Dock = DockStyle.Fill;
            canvas.BorderStyle = BorderStyle.FixedSingle;
        }

        private void WaferMapCanvas_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.LightGray;

            WaferMap.OnIndexChange += test;//注册回调事件
        }

        private void DrawGrid(Graphics e)
        {
            float unitPerPixel = (float)(WaferMap.Entity.DieSizeX * WaferMap.Entity.DieNumX) / canvas.Width;
            for (int i = 0; i < WaferMap.Entity.DieNumX; i++)
            {
                e.DrawLine(new Pen(Color.Black), i * (float)WaferMap.Entity.DieSizeX / unitPerPixel, 0, i * (float)WaferMap.Entity.DieSizeX / unitPerPixel, canvas.Height);
            }
            for (int i = 0; i < WaferMap.Entity.DieNumY; i++)
            {
                e.DrawLine(new Pen(Color.Black), 0, i * (float)WaferMap.Entity.DieSizeY / unitPerPixel, canvas.Width, i * (float)WaferMap.Entity.DieSizeY / unitPerPixel);
            }
        }

        private void DrawCircle(Graphics e)
        {
            double unitPerPixel = (WaferMap.Entity.DieSizeX * WaferMap.Entity.DieNumX) / canvas.Width;
            double centerX = (WaferMap.Entity.OriginDieX * WaferMap.Entity.DieSizeX + WaferMap.Entity.Center2OriginDieCornerX) / unitPerPixel;
            double centerY = (WaferMap.Entity.OriginDieY * WaferMap.Entity.DieSizeY + WaferMap.Entity.Center2OriginDieCornerY) / unitPerPixel;
            double D = 3000000 / unitPerPixel;
            e.DrawArc(new Pen(Color.Black), (float)(centerX - D / 2), (float)(centerY - D / 2), (float)D, (float)D, 0, 360);

            //float centerX1 = canvas.Width / 2;
            //float centerY1 = canvas.Height / 2; ;
            //float D1 = (float)((double)canvas.Width * 3000000 / map.DieNumX / map.IndexSizeX);
            //e.DrawArc(new Pen(Color.Black), centerX - D / 2, centerY - D / 2, D, D, 0, 360);
        }

        private void DrawRect(int idxX, int idxY, Graphics e, Color color)
        {
            double unitPerPixel = (WaferMap.Entity.DieSizeX * WaferMap.Entity.DieNumX) / canvas.Width;

            float width = (float)WaferMap.Entity.DieSizeX / (float)unitPerPixel;
            float height = (float)WaferMap.Entity.DieSizeY / (float)unitPerPixel;
            //e.DrawRectangle(new Pen(Color.Purple), idxX * width, idxY * height, width, height);

            e.FillRectangle(new SolidBrush(color), idxX * width, idxY * height, width, height);
        }

        private void DrawIndex(Graphics e)
        {
            double unitPerPixel = (WaferMap.Entity.DieSizeX * WaferMap.Entity.DieNumX) / canvas.Width;

            float width = (float)WaferMap.Entity.DieSizeX / (float)unitPerPixel;
            float height = (float)WaferMap.Entity.DieSizeY / (float)unitPerPixel;
            e.DrawRectangle(new Pen((Color.White), 3), WaferMap.CurrentIndexX * width, WaferMap.CurrentIndexY * height, width, height);

        }

        public void RefreshCanvas()
        {
            //m_picture = canvas.CreateGraphics();
            Bitmap background = new Bitmap(canvas.Width, canvas.Height);
            Graphics gp = Graphics.FromImage(background);

            if (WaferMap.Entity.MappingPoints != null)
            {
                foreach (MappingPoint pt in WaferMap.Entity.MappingPoints)
                {
                    //if (pt.Coordinates == 1) DrawRect(pt.IndexX, pt.IndexY, gp, Color.Green);
                    //if (pt.Coordinates == 2) DrawRect(pt.IndexX, pt.IndexY, gp, Color.Yellow);
                    if (pt.BIN == 1) DrawRect(pt.IndexX, pt.IndexY, gp, Color.Yellow);
                    if (pt.BIN == 4) DrawRect(pt.IndexX, pt.IndexY, gp, Color.Green);
                }
            }

            DrawRect(WaferMap.Entity.OriginDieX, WaferMap.Entity.OriginDieY, gp, Color.Purple);//画参考die
            DrawGrid(gp);//方格
            DrawCircle(gp);//
            DrawIndex(gp);
            canvas.BackgroundImage = background;
            //canvas.Refresh();
        }

        private void RefreshCanvas(WaferMapClass m)
        {
            WaferMap.Entity = m as WaferMapClass;
            if (WaferMap.Entity == null) return;
            RefreshCanvas();
        }
        public delegate void TestDel();

        public void test(int x,int y)            
        {
            Console.WriteLine(x.ToString()+" ; "+y.ToString());
        }
     }
}
