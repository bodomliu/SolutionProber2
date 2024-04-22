using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WaferMapLibrary;

namespace CommonComponentLibrary
{
    public partial class WaferMapCanvas : UserControl
    {
        public static WaferMapCanvas Canvas => new();
        private readonly PictureBox canvas = new();
        private WaferMapCanvas()
        {
            InitializeComponent();
            this.Controls.Add(canvas);
            canvas.Dock = DockStyle.Fill;
            canvas.BorderStyle = BorderStyle.FixedSingle;

            canvas.MouseDown += WaferMapCanvas_MouseDown;
        }

        /// <summary>
        /// 加载画布
        /// </summary>
        public void LoadCanvas()
        {
            RatioX = 1;
            RatioY = 1;
            _offsetX = 0;
            _offsetY = 0;
            RefreshCanvas();
        }

        private void WaferMapCanvas_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;
            BackColor = Color.LightGray;
            ParentForm.FormClosed += (sender, e) =>
            {
                Dispose(true);
            };
            WaferMap.OnIndexChange += test;//注册回调事件
        }

        /// <summary>
        /// map 图层
        /// </summary>
        private Bitmap? _backgroundBitmap;
        /// <summary>
        /// 放大后的简略图
        /// </summary>
        private Bitmap? _simplifiedBitmap;
        /// <summary>
        /// X 轴缩放比例
        /// </summary>
        public double RatioX { get; private set; } = 1;
        /// <summary>
        /// Y 轴缩放比例
        /// </summary>
        public double RatioY { get; private set; } = 1;

        /// <summary>
        /// 缩放后 x 轴偏移
        /// </summary>
        private int _offsetX = 0;

        /// <summary>
        /// 缩放后 Y 轴偏移
        /// </summary>
        private int _offsetY = 0;

        public int MarginTop { get; set; } = 0;

        public int MarginLeft { get; set; } = 0;

        public int MarginRight { get; set; } = 0;

        public int MarginBottom { get; set; } = 0;


        public void SetRatio(double ratioX, double ratioY)
        {
            // 保持中心位置不变
            // 计算中心点在缩放前的位置
            _offsetX = (int)((-canvas.Width / 2 + _offsetX) / RatioX * ratioX + canvas.Width / 2);
            _offsetY = (int)((-canvas.Height / 2 + _offsetY) / RatioY * ratioY + canvas.Height / 2);

            RatioX = ratioX;
            RatioY = ratioY;
            RefreshCanvas();
        }

        // 圆心坐标
        public static void CircleCentre(out double x, out double y)
        {
            x = WaferMap.Entity.OriginDieX * WaferMap.Entity.DieSizeX - WaferMap.Entity.Center2OriginDieCornerX;
            y = (WaferMap.Entity.OriginDieY + 1) * WaferMap.Entity.DieSizeY - WaferMap.Entity.Center2OriginDieCornerY;
        }
        private float UnitPerPixelX => (float)(WaferMap.Entity.DieSizeX * WaferMap.Entity.DieNumX) / _backgroundBitmap.Width;

        private float UnitPerPixelY => (float)(WaferMap.Entity.DieSizeY * WaferMap.Entity.DieNumY) / _backgroundBitmap.Height;

        private void DrawGrid(Graphics e)
        {
            using Pen p = new Pen(Color.Black);
            float ux = UnitPerPixelX;
            float uy = UnitPerPixelY;
            for (int i = 0; i < WaferMap.Entity.DieNumX + 1; i++)
            {
                e.DrawLine(p, i * (float)WaferMap.Entity.DieSizeX / ux, 0, i * (float)WaferMap.Entity.DieSizeX / ux, _backgroundBitmap.Height);
            }
            for (int i = 0; i < WaferMap.Entity.DieNumY + 1; i++)
            {
                e.DrawLine(p, 0, i * (float)WaferMap.Entity.DieSizeY / uy, _backgroundBitmap.Width, i * (float)WaferMap.Entity.DieSizeY / uy);
            }
        }
        private void DrawCircle(Graphics e, double unitPerPixelX, double unitPerPixelY, Boolean isDrawCenterOfCircle = false)
        {
            using Pen p = new Pen(Color.Black);
            CircleCentre(out double x, out double y);
            double centerX = x / unitPerPixelX;
            double centerY = y / unitPerPixelY;
            double Dx = WaferMap.Entity.WaferDiameter / unitPerPixelX;
            double Dy = WaferMap.Entity.WaferDiameter / unitPerPixelY;

            e.DrawArc(p, (float)(centerX - Dx / 2), (float)(centerY - Dy / 2), (float)Dx, (float)Dy, 0, 360);

            if (isDrawCenterOfCircle)
            {
                using SolidBrush sb = new SolidBrush(Color.White);
                // 画圆心
                e.FillEllipse(sb, (float)centerX - 2, (float)centerY - 2, 4, 4);
            }
        }

        private void DrawRect(int idxX, int idxY, Graphics e, Color color)
        {

            float width = (float)WaferMap.Entity.DieSizeX / UnitPerPixelX;
            float height = (float)WaferMap.Entity.DieSizeY / UnitPerPixelY;
            using var sb = new SolidBrush(color);
            e.FillRectangle(sb, idxX * width, idxY * height, width, height);
        }
        private void DrawIndex(Graphics e)
        {

            using Pen p = new Pen((Color.White), 3);
            float width = (float)WaferMap.Entity.DieSizeX / UnitPerPixelX;
            float height = (float)WaferMap.Entity.DieSizeY / UnitPerPixelY;
            e.DrawRectangle(p, WaferMap.CurrentIndexX * width, WaferMap.CurrentIndexY * height, width, height);

        }

        /// <summary>
        /// 画简略图
        /// </summary>
        private void DrawSimplified()
        {
            _simplifiedBitmap?.Dispose();
            _simplifiedBitmap = new Bitmap(canvas.Width / 4, canvas.Height / 4);
            using Graphics e = Graphics.FromImage(_simplifiedBitmap);
            // 填充背景色
            e.Clear(Color.LightBlue);
            // 抗锯齿
            e.SmoothingMode = SmoothingMode.AntiAlias;

            double ux = (float)(WaferMap.Entity.DieSizeX * WaferMap.Entity.DieNumX) / _simplifiedBitmap.Width;
            double uy = (float)(WaferMap.Entity.DieSizeY * WaferMap.Entity.DieNumY) / _simplifiedBitmap.Height;
            DrawCircle(e, ux, uy, true);

            // 在简略图上画当前位置
            // 计算偏移后左上角在简略图上的位置
            int x = (int)(-_offsetX / RatioX / 4);
            int y = (int)(-_offsetY / RatioY / 4);
            e.DrawRectangle(Pens.Red, x, y, (int)(_simplifiedBitmap.Width / RatioX), (int)(_simplifiedBitmap.Height / RatioY));
        }

        public void RefreshCanvas()
        {
            //m_picture = canvas.CreateGraphics();
            _backgroundBitmap?.Dispose();
            _backgroundBitmap = new Bitmap((int)(canvas.Width * RatioX), (int)(canvas.Height * RatioY));
            using Graphics gp = Graphics.FromImage(_backgroundBitmap);
            // 抗锯齿
            gp.SmoothingMode = SmoothingMode.AntiAlias;

            if (WaferMap.Entity.MappingPoints != null)
            {
                foreach (MappingPoint pt in WaferMap.Entity.MappingPoints)
                {

                    DrawRect(pt.IndexX, pt.IndexY, gp, WaferMapColorCard.colors[pt.BIN]);
                }
            }

            DrawRect(WaferMap.Entity.RefDieX, WaferMap.Entity.RefDieY, gp, Color.Purple);//画参考die
            DrawGrid(gp);//方格
            DrawCircle(gp, UnitPerPixelX, UnitPerPixelY);//
            DrawIndex(gp);
            canvas.Image?.Dispose();
            canvas.Image = MergeBitmap();

            // canvas.Image = backgroundBitmap;
            //canvas.Refresh();
        }
        /// <summary>
        /// 合并图层
        /// </summary>
        private Bitmap MergeBitmap()
        {
            Bitmap result = new(canvas.Width, canvas.Height);
            using Graphics g = Graphics.FromImage(result);
            if (RatioX == 1.0 || RatioX == 1.0)
            {
                _offsetX = 0;
                _offsetY = 0;
                g.DrawImage(_backgroundBitmap, 0, 0);
                return result;
            }

            if (_offsetX > 0) _offsetX = 0;
            if (_offsetY > 0) _offsetY = 0;
            if (_offsetX < canvas.Width - _backgroundBitmap.Width) _offsetX = canvas.Width - _backgroundBitmap.Width;
            if (_offsetY < canvas.Height - _backgroundBitmap.Height) _offsetY = canvas.Height - _backgroundBitmap.Height;

            g.DrawImage(_backgroundBitmap, _offsetX, _offsetY);
            DrawSimplified();
            g.DrawImage(_simplifiedBitmap, 0, 0);

            return result;
        }


        public void test(int x, int y)
        {
            //Console.WriteLine(x.ToString()+" ; "+y.ToString());
            RefreshCanvas();
        }


        private void WaferMapCanvas_MouseDown(object? sender, MouseEventArgs e)
        {
            // 获得焦点
            Focus();

            // 点击简略图
            if ((RatioX != 1 || RatioX != 1.0) && e.X < _simplifiedBitmap.Width && e.Y < _simplifiedBitmap.Height)
            {
                SimplifiedBitmap_MouseDown(sender, e);
                return;
            }
        }

        private void SimplifiedBitmap_MouseDown(object? sender, MouseEventArgs e)
        {

            int x = (int)(e.X * RatioX * 4);
            int y = (int)(e.Y * RatioY * 4);
            if (x < 0) x = 0;
            if (y < 0) y = 0;
            if (x >= _backgroundBitmap.Width) x = _backgroundBitmap.Width - 1;
            if (y >= _backgroundBitmap.Height) y = _backgroundBitmap.Height - 1;

            int offsetX = x - canvas.Width / 2;
            int offsetY = y - canvas.Height / 2;
            

            _offsetX = -offsetX;
            _offsetY = -offsetY;

            RefreshCanvas();

        }

    }
}
