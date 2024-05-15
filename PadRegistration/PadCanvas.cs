using CommonComponentLibrary;
using WaferMapLibrary;
using MotionLibrary;
namespace MainForm
{
    public partial class PadCanvas : UserControl
    {
        public PadCanvas()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            PictureBox = new();
            this.Controls.Add(PictureBox);
            PictureBox.Dock = DockStyle.Fill;
        }

        private void PadCanvas_Load(object sender, EventArgs e)
        {
            DrawPad();
        }

        private PictureBox PictureBox { get; set; }

        #region 画图

        public void DrawPad()
        {
            int w = Width;
            int h = Height;
            if (WaferMap.Entity.DieSizeY < WaferMap.Entity.DieSizeX)
                // 根据 die 的比例计算 h
                h = (int)(w * 1.0 * WaferMap.Entity.DieSizeY / WaferMap.Entity.DieSizeX);
            else if (WaferMap.Entity.DieSizeY > WaferMap.Entity.DieSizeX)
                // 根据 die 的比例计算 w
                w = (int)(h * 1.0 * WaferMap.Entity.DieSizeX / WaferMap.Entity.DieSizeY);

            using Bitmap bitmap = new(w, h);
            using Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.Black);

            double unitPerPixel = WaferMap.Entity.DieSizeX / w;

            double deltaX = WaferMap.Entity.Corner2OrgX + PadData.Entity.DieOrg2RefPadX - PadData.Entity.PadWidth / 2;
            double deltaY = WaferMap.Entity.Corner2OrgY + PadData.Entity.DieOrg2RefPadY - PadData.Entity.PadHeight / 2;

            int hu = (int)(PadData.Entity.PadWidth / unitPerPixel);
            int hv = (int)(PadData.Entity.PadHeight / unitPerPixel);

            hu = Math.Max(hu, 1);
            hv = Math.Max(hv, 1);

            for (int i = 0; i < PadData.Entity.Pads.Count; i++)
            {
                var pad = PadData.Entity.Pads[i];
                int x = (int)((deltaX + pad.PosX) / unitPerPixel);
                int y = (int)((deltaY + pad.PosY) / unitPerPixel);
                var br = Brushes.White;
                if (0 == i)
                    br = Brushes.Red;
                if (PadData.CurrentIndex == i)
                    br = Brushes.Yellow;

                g.FillRectangle(br, x, h + y, hu, hv);
            }

            PictureBox.Image?.Dispose();
            Bitmap b = new(Width, Height);
            using Graphics g2 = Graphics.FromImage(b);
            g2.DrawImage(bitmap, (Width - bitmap.Width) / 2, (Height - bitmap.Height) / 2,
                bitmap.Width, bitmap.Height);
            PictureBox.Image = b;

        }
        #endregion

    }


}
