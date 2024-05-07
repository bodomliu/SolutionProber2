namespace DeviceDataSettings
{
    partial class WaferMapSettingMargin
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
            _right = new TextBox();
            _bottom = new TextBox();
            _left = new TextBox();
            _top = new TextBox();
            apply = new Button();
            label1 = new Label();
            textBox = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightGray;
            panel1.Controls.Add(_right);
            panel1.Controls.Add(_bottom);
            panel1.Controls.Add(_left);
            panel1.Controls.Add(_top);
            panel1.Location = new Point(37, 39);
            panel1.Name = "panel1";
            panel1.Size = new Size(150, 150);
            panel1.TabIndex = 0;
            // 
            // _right
            // 
            _right.Location = new Point(117, 63);
            _right.Name = "_right";
            _right.Size = new Size(30, 23);
            _right.TabIndex = 3;
            _right.TextAlign = HorizontalAlignment.Center;
            // 
            // _bottom
            // 
            _bottom.Location = new Point(60, 124);
            _bottom.Name = "_bottom";
            _bottom.Size = new Size(30, 23);
            _bottom.TabIndex = 2;
            _bottom.TextAlign = HorizontalAlignment.Center;
            // 
            // _left
            // 
            _left.Location = new Point(3, 63);
            _left.Name = "_left";
            _left.Size = new Size(30, 23);
            _left.TabIndex = 1;
            _left.TextAlign = HorizontalAlignment.Center;
            // 
            // _top
            // 
            _top.Location = new Point(60, 3);
            _top.Name = "_top";
            _top.Size = new Size(30, 23);
            _top.TabIndex = 0;
            _top.TextAlign = HorizontalAlignment.Center;
            // 
            // apply
            // 
            apply.Location = new Point(205, 39);
            apply.Name = "apply";
            apply.Size = new Size(75, 53);
            apply.TabIndex = 1;
            apply.Text = "Apply";
            apply.UseVisualStyleBackColor = true;
            apply.Click += Apply_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 201);
            label1.Name = "label1";
            label1.Size = new Size(110, 17);
            label1.TabIndex = 2;
            label1.Text = "Usage Map Size :";
            // 
            // textBox
            // 
            textBox.Location = new Point(154, 198);
            textBox.Name = "textBox";
            textBox.ReadOnly = true;
            textBox.Size = new Size(73, 23);
            textBox.TabIndex = 3;
            textBox.TextAlign = HorizontalAlignment.Center;
            // 
            // WaferMapSettingMargin
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(textBox);
            Controls.Add(label1);
            Controls.Add(apply);
            Controls.Add(panel1);
            Name = "WaferMapSettingMargin";
            Size = new Size(283, 350);
            Load += WaferMapSettingMargin_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private TextBox _right;
        private TextBox _bottom;
        private TextBox _left;
        private TextBox _top;
        private Button apply;
        private Label label1;
        private TextBox textBox;
    }
}
