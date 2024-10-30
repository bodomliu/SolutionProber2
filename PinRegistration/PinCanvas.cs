using WaferMapLibrary;

namespace PinRegistration
{
    public partial class PinCanvas : UserControl
    {
        #region 变量
        public PictureBox PinPictureBox { get; set; }
        private double ratio = 1;    // 图片的起始显示比例
        private double ratioStep = 0.1;    //图片的放缩比例
        private Size pic_size;  //画布大小

        private bool isDragging = false; // 用于跟踪是否正在拖拽图片
        private Point lastDragPoint; // 用于跟踪最后一次拖拽的位置

        //数据内最大最小值
        private double minX = 0;
        private double maxX = 0;
        private double minY = 0;
        private double maxY = 0;
        public static PinCanvas Entity { get => entity; set => entity = value; }
        private static PinCanvas entity = new();

        #endregion

        #region 初始化
        /// <summary>
        /// 构造
        /// </summary>
        public PinCanvas()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            PinPictureBox = new()
            {
                Height = 415,
                Width = 399,
            };

            Init();
            //changeTimer = new System.Threading.Timer(TimerCallback, null, 0, 3000);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            PinData.OnIndexChange += PinData_OnIndexChange;
            this.Controls.Add(PinPictureBox);
            //PictureBox 调整好大小（不要用dock属性）sizemode 用 zoom
            this.PinPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            this.PinPictureBox.Paint += new PaintEventHandler(PinPictureBox_Paint);
            this.PinPictureBox.MouseWheel += new MouseEventHandler(PinPictureBox_MouseWheel);
            this.PinPictureBox.MouseClick += new MouseEventHandler(PinPictureBox_MouseClick);
            this.PinPictureBox.MouseDown += new MouseEventHandler(PinPictureBox_MouseDown);
            this.PinPictureBox.MouseMove += new MouseEventHandler(PinPictureBox_MouseMove);
            this.PinPictureBox.MouseUp += new MouseEventHandler(PinPictureBox_MouseUp);
            this.ActiveControl = this.PinPictureBox; // 设置焦点
        }
        #endregion

        #region PictureBox事件

        /// <summary>
        /// load事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PinCanvas_Load(object sender, EventArgs e)
        {
            pic_size = PinPictureBox.Size;
            PinPictureBox.Invalidate();
        }

        /// <summary>
        /// 处理PinData_OnIndexChange事件
        /// </summary>
        /// <param name="index">参数</param>
        private void PinData_OnIndexChange(int index)
        {
            // 当 CurrentIndex 发生变化时,调用事件
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    UpdateUI();
                }));
            }
            else
            {
                UpdateUI();
            }
        }

        //private System.Threading.Timer? changeTimer;
        ///// <summary>
        ///// 后台更新CurrentIndex
        ///// </summary>
        ///// <param name="state"></param>
        //private void TimerCallback(object? state)
        //{
        //    //后台一直更新 CurrentIndex                                                                                           
        //    //if (PinData.CurrentIndex < Data!.Pins.Count - 1)
        //    if (PinData.CurrentIndex < PinData.Entity.Pins.Count - 1)
        //        PinData.CurrentIndex++;
        //    else
        //        PinData.CurrentIndex = 0;
        //}

        /// <summary>
        /// 画图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PinPictureBox_Paint(object? sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Black);
            // 获取PictureBox的尺寸
            int PictureBoxWidth = PinPictureBox.Size.Width;
            int PictureBoxHeight = PinPictureBox.Size.Height;
            //没有pin则退出
            if (PinData.Entity.Pins.Count == 0) return;
            CalculateMinMax();

            // 计算缩放因子和平移量
            double scale = Math.Min(PictureBoxWidth / (maxX - minX), PictureBoxHeight / (maxY - minY)) * 0.9;
            double offsetX = -minX * scale;
            double offsetY = -minY * scale;

            // 绘制每个点
            foreach (var pin in PinData.Entity!.Pins)
            {
                // 计算在PictureBox中的位置
                int x = (int)((pin.PosX * scale) + offsetX + 20);
                int y = (int)((pin.PosY * scale) + offsetY + 10);

                int x1 = (int)(((int)PinData.Entity.Pins[0].PosX * scale) + offsetX + 20);
                int y1 = (int)(((int)PinData.Entity.Pins[0].PosY * scale) + offsetY + 10);

                // 确保点不会超出画布的边界
                x = Math.Max(0, Math.Min(PictureBoxWidth - 4, x));
                y = Math.Max(0, Math.Min(PictureBoxHeight - 4, y));
                x1 = Math.Max(0, Math.Min(PictureBoxWidth - 4, x1));
                y1 = Math.Max(0, Math.Min(PictureBoxWidth - 4, y1));

                // 绘制实心小圆点
                using Brush brush = new SolidBrush(Color.Red); // 定义画刷颜色
                e.Graphics.FillEllipse(brush, x, y, 7, 7); // 

                e.Graphics.FillEllipse(Brushes.Blue, x1, y1, 7, 7);
            }

            // 绘制当前索引的点为红色
            if (PinData.Entity != null && PinData.Entity.Pins != null && PinData.CurrentIndex >= 0 && PinData.CurrentIndex < PinData.Entity.Pins.Count)
            {
                var pin = PinData.Entity.Pins[PinData.CurrentIndex];
                // 计算在PictureBox中的位置
                int x = (int)((pin.PosX * scale) + offsetX + 20);
                int y = (int)((pin.PosY * scale) + offsetY + 10);
                // 确保点不会超出画布的边界
                x = Math.Max(0, Math.Min(PictureBoxWidth - 4, x)); // 减去半径4，确保不会超出边界
                y = Math.Max(0, Math.Min(PictureBoxHeight - 4, y)); // 减去半径4，确保不会超出边界

                // 绘制实心小圆点覆盖原来的点
                using Brush brush = new SolidBrush(Color.White); // 使用白色画刷绘制一个半径更大的实心圆来覆盖原来的点
                e.Graphics.FillEllipse(brush, x, y, 6, 6); // 增大半径，确保覆盖
            }
        }

        /// <summary>
        /// 触发鼠标点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PinPictureBox_MouseDown(object? sender, MouseEventArgs e)
        {
            // 检查是否点击了鼠标左键
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastDragPoint = e.Location;
            }
        }

        /// <summary>
        /// 触发鼠标拖拽事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PinPictureBox_MouseMove(object? sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                // 计算拖拽的距离
                int deltaX = e.Location.X - lastDragPoint.X;
                int deltaY = e.Location.Y - lastDragPoint.Y;

                // 更新PictureBox的位置
                PinPictureBox.Left += deltaX;
                PinPictureBox.Top += deltaY;

                // 更新最后一次拖拽的位置
                lastDragPoint = e.Location;
            }
        }

        /// <summary>
        /// 触发鼠标抬起事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PinPictureBox_MouseUp(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        /// <summary>
        /// 鼠标滚轮事件，放大缩小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PinPictureBox_MouseWheel(object? sender, MouseEventArgs e)
        {
            // 计算鼠标相对于PictureBox的位置
            int relativeX = e.Location.X - PinPictureBox.Location.X;
            int relativeY = e.Location.Y - PinPictureBox.Location.Y;

            // 计算新的缩放比例
            double newRatio = ratio;
            if (e.Delta > 0)
            {
                newRatio += ratioStep;
                if (newRatio > 5) // 放大上限
                    newRatio = 5;
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
                this.ChangePictureBoxSizeAndLocation(relativeX, relativeY, newRatio);
                ratio = newRatio;
            }
        }

        /// <summary>
        /// 鼠标右键单击事件，回原
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PinPictureBox_MouseClick(object? sender, MouseEventArgs e)
        {
            // 检查是否点击了鼠标右键
            if (e.Button == MouseButtons.Right)
            {
                // 恢复图片到原始大小
                this.ResetPictureBoxSize();
            }
        }

        #endregion

        #region 私有方法
        /// <summary>
        /// 当CurrentIndex发生变化时，调用此方法更新界面
        /// </summary>
        public void UpdateUI()
        {
            // 重绘当前索引的点
            PinPictureBox.Invalidate(); // 触发 PinPictureBox_Paint 事件
        }

        /// <summary>
        /// 计算Pin针的最大位置和最小位置
        /// </summary>
        private void CalculateMinMax()
        {
            maxX = PinData.Entity.Pins.Max(x => x.PosX);
            maxY = PinData.Entity.Pins.Max(y => y.PosY);
            minX = PinData.Entity.Pins.Min(x => x.PosX);
            minY = PinData.Entity.Pins.Min(y => y.PosY);
        }

        /// <summary>
        /// 对图片进行放大缩小
        /// </summary>
        /// <param name="relativeX"></param>
        /// <param name="relativeY"></param>
        /// <param name="newRatio"></param>
        private void ChangePictureBoxSizeAndLocation(int relativeX, int relativeY, double newRatio)
        {
            // 计算新的PictureBox大小
            int newWidth = Convert.ToInt32(pic_size.Width * newRatio);
            int newHeight = Convert.ToInt32(pic_size.Height * newRatio);

            // 计算新的PictureBox位置，使鼠标焦点位于图片上相同相对位置
            int newX = (int)(PinPictureBox.Location.X - (relativeX * newRatio / ratio - relativeX));
            int newY = (int)(PinPictureBox.Location.Y - (relativeY * newRatio / ratio - relativeY));

            // 边界检查，确保PictureBox不会超出容器的边界
            int containerWidth = this.ClientSize.Width; // 如果不是窗体，请替换为父容器的宽度
            int containerHeight = this.ClientSize.Height; // 如果不是窗体，请替换为父容器的高度

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
            PinPictureBox.Size = new Size(newWidth, newHeight);
            PinPictureBox.Location = new Point(newX, newY);

            // 更新当前位置信息
            ratio = newRatio;
        }

        /// <summary>
        /// 将图片恢复本来大小
        /// </summary>
        private void ResetPictureBoxSize()
        {
            // 设置PictureBox的大小为原始图片大小
            PinPictureBox.Size = pic_size;

            // 将PictureBox居中显示
            int newX = (this.ClientSize.Width - pic_size.Width) / 2;
            int newY = (this.ClientSize.Height - pic_size.Height) / 2;
            PinPictureBox.Location = new Point(newX, newY);

            // 重置缩放比例
            ratio = 1;
        }

        #endregion
    }
}
