using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommonComponentLibrary
{
    public partial class WaferMapColorCard : UserControl
    {



        public static readonly Color[] colors = new Color[]
        {
            Color.FromArgb(129, 129, 129),
            Color.FromArgb(255, 255, 0),
            Color.FromArgb(255, 0, 255),
            Color.FromArgb(0, 255, 255),
            Color.FromArgb(129, 0, 0),
            Color.FromArgb(0, 0, 255),
            Color.FromArgb(0, 129, 0),
            Color.FromArgb(129, 129, 0),
            Color.FromArgb(0, 0, 129)
        };

        public WaferMapColorCard()
        {
            InitializeComponent();
        }



        private void WaferMapColorCarControl_Load(object sender, EventArgs e)
        {
            this.ParentForm.FormClosed += (sender, e) =>
            {
                Dispose(true);
            };

            // 生成颜色卡
            Bitmap bitmap = new(Card.Width, Card.Height);
            using Graphics graphics = Graphics.FromImage(bitmap);
            for (int i = 0; i < colors.Length; i++)
            {
                graphics.FillRectangle(new SolidBrush(colors[i]), 0, i * 16, 84, 16);
            }
            Card.Image = bitmap;
        }

    }

    public class BorderedLabel : Label
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.Black, 1), 0, 0, MaximumSize.Width - 1, MaximumSize.Height - 1);
            base.OnPaint(e);
        }
    }
}
