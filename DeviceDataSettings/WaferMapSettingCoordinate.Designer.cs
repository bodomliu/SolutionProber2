namespace DeviceDataSettings
{
    partial class WaferMapSettingCoordinate
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            button1 = new Button();
            originY = new TextBox();
            originX = new TextBox();
            borderedLabel2 = new CommonComponentLibrary.BorderedLabel();
            borderedLabel1 = new CommonComponentLibrary.BorderedLabel();
            label1 = new Label();
            panel2 = new Panel();
            upOrDown = new Button();
            leftOrRight = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(originY);
            panel1.Controls.Add(originX);
            panel1.Controls.Add(borderedLabel2);
            panel1.Controls.Add(borderedLabel1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(28, 34);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 82);
            panel1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(111, 23);
            button1.Name = "button1";
            button1.Size = new Size(70, 47);
            button1.TabIndex = 5;
            button1.Text = "Set Cur Die as ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // originY
            // 
            originY.Location = new Point(53, 50);
            originY.Name = "originY";
            originY.Size = new Size(50, 23);
            originY.TabIndex = 4;
            originY.TextAlign = HorizontalAlignment.Right;
            // 
            // originX
            // 
            originX.Location = new Point(53, 24);
            originX.Name = "originX";
            originX.Size = new Size(50, 23);
            originX.TabIndex = 3;
            originX.TextAlign = HorizontalAlignment.Right;
            // 
            // borderedLabel2
            // 
            borderedLabel2.AutoSize = true;
            borderedLabel2.Location = new Point(23, 53);
            borderedLabel2.MaximumSize = new Size(24, 17);
            borderedLabel2.MinimumSize = new Size(24, 17);
            borderedLabel2.Name = "borderedLabel2";
            borderedLabel2.Size = new Size(24, 17);
            borderedLabel2.TabIndex = 2;
            borderedLabel2.Text = " Y";
            // 
            // borderedLabel1
            // 
            borderedLabel1.AutoSize = true;
            borderedLabel1.Location = new Point(23, 27);
            borderedLabel1.MaximumSize = new Size(24, 17);
            borderedLabel1.MinimumSize = new Size(24, 17);
            borderedLabel1.Name = "borderedLabel1";
            borderedLabel1.Size = new Size(24, 17);
            borderedLabel1.TabIndex = 1;
            borderedLabel1.Text = " X";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 3);
            label1.Name = "label1";
            label1.Size = new Size(150, 17);
            label1.TabIndex = 0;
            label1.Text = "Offset From Origin (0, 0)";
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(upOrDown);
            panel2.Controls.Add(leftOrRight);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(28, 142);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 100);
            panel2.TabIndex = 1;
            // 
            // upOrDown
            // 
            upOrDown.Location = new Point(133, 66);
            upOrDown.Name = "upOrDown";
            upOrDown.Size = new Size(60, 23);
            upOrDown.TabIndex = 4;
            upOrDown.Text = "UP";
            upOrDown.UseVisualStyleBackColor = true;
            upOrDown.Click += upOrDown_Click;
            // 
            // leftOrRight
            // 
            leftOrRight.Location = new Point(134, 32);
            leftOrRight.Name = "leftOrRight";
            leftOrRight.Size = new Size(59, 23);
            leftOrRight.TabIndex = 3;
            leftOrRight.Text = "RIGHT";
            leftOrRight.UseVisualStyleBackColor = true;
            leftOrRight.Click += leftOrRight_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(5, 68);
            label4.Name = "label4";
            label4.Size = new Size(122, 17);
            label4.TabIndex = 2;
            label4.Text = "Y Positive Direction:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(4, 35);
            label3.Name = "label3";
            label3.Size = new Size(123, 17);
            label3.TabIndex = 1;
            label3.Text = "X Positive Direction:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 3);
            label2.Name = "label2";
            label2.Size = new Size(118, 17);
            label2.TabIndex = 0;
            label2.Text = "Index Direction Set";
            // 
            // WaferMapSettingCoordinate
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "WaferMapSettingCoordinate";
            Size = new Size(283, 270);
            Load += WaferMapSettingCoordinate_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private CommonComponentLibrary.BorderedLabel borderedLabel1;
        private CommonComponentLibrary.BorderedLabel borderedLabel2;
        private Button button1;
        private TextBox originY;
        private TextBox originX;
        private Panel panel2;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button leftOrRight;
        private Button upOrDown;
    }
}
