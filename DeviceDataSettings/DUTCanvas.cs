using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeviceDataSettings
{
    public partial class DUTCanvas : UserControl
    {
        PictureBox pictureBox;
        public DUTCanvas()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            pictureBox = new();
            this.Controls.Add(pictureBox);
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.MouseClick += PictureBox_Click;
        }

        private void DUTCanvas_Load(object sender, EventArgs e)
        {
            DUTData.OnIndexChange += RefreshCanvas;
        }

        #region 画图

        private int _cellWidth { get { return pictureBox.Width / 11; } }

        private int _cellHeight { get { return pictureBox.Height / 11; } }

        private void DrawGrid(Graphics g)
        {
            // 计算每个单元格的大小
            int cellWidth = _cellWidth;
            int cellHeight = _cellHeight;
            for (int i = 0; i <= 11; i++)
            {
                // 画横线
                g.DrawLine(Pens.Black, 0, i * cellHeight, pictureBox.Width, i * cellHeight);
                // 画竖线
                g.DrawLine(Pens.Black, i * cellWidth, 0, i * cellWidth, pictureBox.Height);
            }
        }

        private void DrawDUT(Graphics g)
        {
            // 计算每个单元格的大小
            int cellWidth = _cellWidth;
            int cellHeight = _cellHeight;
            for (int i = 0; i < DUTData.Entity.DUTs.Count; i++)
            {
                var dut = DUTData.Entity.DUTs[i];
                var brush = Brushes.Red;
                if (dut.Enable)
                {
                    brush = Brushes.Green;
                }
                // 画矩形
                g.FillRectangle(brush, (dut.X + 5) * cellWidth, (dut.Y + 5) * cellHeight, cellWidth, cellHeight);
                // label
                g.DrawString(i.ToString(), new Font("Arial", 10), Brushes.Black, (dut.X + 5) * cellWidth, (dut.Y + 5) * cellHeight);
            }
        }

        private void DrawCurrentIndex(Graphics g)
        {
            // 计算每个单元格的大小
            int cellWidth = _cellWidth;
            int cellHeight = _cellHeight;
            using Pen pen = new(Color.Blue, 3);
            // 画矩形
            g.DrawRectangle(pen, cellWidth * (DUTData.CurrentIndexX + 5), cellHeight * (DUTData.CurrentIndexY + 5), cellWidth, cellHeight);
        }

        public void RefreshCanvas()
        {
            Bitmap bitmap = new(pictureBox.Width, pictureBox.Height);
            using Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
            DrawDUT(g);
            DrawGrid(g);
            DrawCurrentIndex(g);
            pictureBox.Image?.Dispose();
            pictureBox.Image = bitmap;
        }

        #endregion


        #region 鼠标点击
        private void PictureBox_Click(object? sender, MouseEventArgs e)
        {
            // 计算点击的位置
            int cellWidth = _cellWidth;
            int cellHeight = _cellHeight;
            int x = e.X;
            int y = e.Y;
            int indexX = x / cellWidth - 5;
            int indexY = y / cellHeight - 5;

            DUTData.setCurrentIndex(indexX, indexY);
        }

        #endregion
    }

    public class DUT
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Boolean Enable { get; set; } = true;
    }

    public class DUTClass
    {
        public List<DUT> DUTs { get; set; }

        public string CardId { get; set; }

        public string Location { get; set; }

        public DUTClass()
        {
            DUTs = new List<DUT>();
            DUTs.Add(new DUT() { X = 0, Y = 0, Enable = true });
            CardId = "1-0";
            Location = "FF";
        }
    }

    public class DUTData
    {
        public static DUTClass Entity = new DUTClass();

        private static int currentIndex = 0;
        public static int CurrentIndexX
        {
            get
            {
                return currentIndex;
            }
            set
            {
                currentIndex = value;
                if (OnIndexChange != null) OnIndexChange();
            }
        }

        private static int currentIndexY = 0;
        public static int CurrentIndexY
        {
            get
            {
                return currentIndexY;
            }

            set
            {
                currentIndexY = value;
                OnIndexChange?.Invoke();
            }
        }

        public static void setCurrentIndex(int x, int y)
        {
            CurrentIndexX = x;
            CurrentIndexY = y;
            OnIndexChange?.Invoke();
        }

        public delegate void OnIndexChangeHander();
        public static event OnIndexChangeHander? OnIndexChange;


    }
}
