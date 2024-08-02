using CommonComponentLibrary;
using WaferMapLibrary;
using MotionLibrary;
using System.Reflection;

namespace MainForm
{
    public partial class PadCanvas : UserControl
    {
        private PictureBox PictureBox { get; set; }
        public PadCanvas()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            PictureBox = new();
            Init();
        }
        private void Init()
        {          
            this.panel2.Controls.Add(PictureBox);
            PictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            PadData.OnIndexChange += PadData_OnIndexChange;

            PictureBox.MouseDown += PictureBox_MouseDown;
            PictureBox.MouseMove += PictureBox_MouseMove;
            PictureBox.MouseUp += PictureBox_MouseUp;
            PictureBox.MouseWheel += PictureBox_MouseWheel;
            PictureBox.MouseClick += PictureBox_MouseClick;
        }

        private void PadData_OnIndexChange(int index)
        {
            DrawPad();
            label_index.Text = index.ToString();
        }
        private void PadCanvas_Load(object sender, EventArgs e)
        {
            DrawPad();
            label_index.Text = PadData.CurrentIndex.ToString();
            pic_size = PictureBox.Size;          
        }
        #region 图片缩放
        private double ratio = 1;        // 图片的起始显示比例
        private double ratioStep = 0.5;  //放大减小的增大倍数
        private Size pic_size;  // 显示大小

        private bool isDragging = false; // 用于跟踪是否正在拖拽图片
        private Point MousePoint; // 用于跟踪最后一次拖拽的位置
         
        private void PictureBox_MouseClick(object? sender, MouseEventArgs e)
        {
            if (e.Button== MouseButtons.Right)
            {
                ResetPicturebox();
            }
        }

        private void ResetPicturebox()
        {
            // 设置PictureBox的大小为原始图片大小
            PictureBox.Size = pic_size;

            // 将PictureBox居中显示
            int newX = (this.Parent.Width - pic_size.Width) / 2;
            int newY = (this.Parent.Height - pic_size.Height) / 2;
            PictureBox.Location = new Point(newX, newY);

            // 重置缩放比例
            ratio = 1;
        }

        private void PictureBox_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                MousePoint = e.Location;
            }
        }
        private void PictureBox_MouseUp(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void PictureBox_MouseMove(object? sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                // 计算拖拽的距离
                int deltaX = e.Location.X - MousePoint.X;
                int deltaY = e.Location.Y - MousePoint.Y;

                // 更新PictureBox的位置
                PictureBox.Left += deltaX;
                PictureBox.Top += deltaY;

                // 更新最后一次拖拽的位置
                MousePoint = e.Location;
            }
        }
        private void PictureBox_MouseWheel(object? sender, MouseEventArgs e)
        {
            int relativeX=e.Location.X-PictureBox.Location.X;
            int relativeY=e.Location.Y-PictureBox.Location.Y;

            // 计算新的缩放比例
            double newRatio = ratio;
            if (e.Delta > 0)
            {
                newRatio += ratioStep;
                if (newRatio > 20) // 放大上限
                    newRatio = 20;
            }
            else
            {
                newRatio -= ratioStep;
                if (newRatio < 1)  // 缩小下限，保持至少占满容器
                    newRatio = 1;
            }

            // 只有在缩放比例改变时才调整PictureBox的大小和位置
            if (newRatio != ratio)
            {
                this.changePictureBoxSizeAndLocation(relativeX, relativeY, newRatio);
            }
        }
        private void changePictureBoxSizeAndLocation(int relativeX, int relativeY, double newRatio)
        {
            // 计算新的PictureBox大小
            int newWidth = Convert.ToInt32(pic_size.Width * newRatio);
            int newHeight = Convert.ToInt32(pic_size.Height * newRatio);

            // 计算新的PictureBox位置，使鼠标焦点位于图片上相同相对位置
            int newX = (int)(PictureBox.Location.X - (relativeX * newRatio / ratio - relativeX));
            int newY = (int)(PictureBox.Location.Y - (relativeY * newRatio / ratio - relativeY));

            // 边界检查，确保PictureBox不会超出容器的边界
            int containerWidth = this.Parent.Width; // 如果不是窗体，请替换为父容器的宽度
            int containerHeight = this.Parent.Height; // 如果不是窗体，请替换为父容器的高度

            // 确保PictureBox在缩放后仍然占满整个容器
            if (newWidth < containerWidth || newHeight < containerHeight)
            {
                // 如果缩小到小于容器大小，则居中显示
                newX = (containerWidth - newWidth) / 2;
                newY = (containerHeight - newHeight) / 2;
            }
            else
            {
                // 限制PictureBox在容器内
                if (newX > 0) newX = 0;
                if (newX + newWidth < containerWidth) newX = containerWidth - newWidth;
                if (newY > 0) newY = 0;
                if (newY + newHeight < containerHeight) newY = containerHeight - newHeight;
            }

            // 更新PictureBox的大小和位置
            PictureBox.Size = new Size(newWidth, newHeight);
            PictureBox.Location = new Point(newX, newY);
            
            // 更新当前位置信息
            ratio = newRatio;
        }
        #endregion

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

            hu = Math.Max(hu, 6);
            hv = Math.Max(hv, 6);

            for (int i = 0; i < PadData.Entity.Pads.Count; i++)
            {
                var pad = PadData.Entity.Pads[i];
                int x = (int)((deltaX + pad.PosX) / unitPerPixel);
                int y = (int)((deltaY + pad.PosY) / unitPerPixel);
                Pen pen = new Pen(Color.Yellow);
                if (0 == i)
                    pen.Color = Color.Red;
                if (PadData.CurrentIndex == i)
                { 
                    pen.Color = Color.Green;
                    g.DrawLine(pen, x, 0, x,PictureBox.Size.Height);
                    g.DrawLine(pen, 0, y+h , PictureBox.Size.Width, y+h);

                }
                g.DrawRectangle(pen, x - 3, h + y - 3, hu, hv);
            }

            PictureBox.Image?.Dispose();
            Bitmap b = new(Width, Height);
            using Graphics g2 = Graphics.FromImage(b);
            g2.DrawImage(bitmap, (Width - bitmap.Width) / 2, (Height - bitmap.Height) / 2, bitmap.Width, bitmap.Height);
            PictureBox.Size= new Size(Width, Height);
            PictureBox.Image= b;
        }
        #endregion


    }


}
