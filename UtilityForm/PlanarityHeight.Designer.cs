namespace UtilityForm
{
    partial class PlanarityHeight
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlanarityHeight));
            pictureBox1 = new PictureBox();
            groupBox1 = new GroupBox();
            btn_Refresh = new Button();
            label_index = new Label();
            label2 = new Label();
            checkBox1 = new CheckBox();
            Z8_diff = new Label();
            Z7_diff = new Label();
            Z2_diff = new Label();
            Z0_diff = new Label();
            Z3_diff = new Label();
            Z1_diff = new Label();
            Z4_diff = new Label();
            Z6_diff = new Label();
            Z5_diff = new Label();
            tb_DiffZ = new TextBox();
            label1 = new Label();
            Z7 = new Button();
            Z0 = new Button();
            Z8 = new Button();
            Z6 = new Button();
            Z5 = new Button();
            Z4 = new Button();
            Z3 = new Button();
            Z2 = new Button();
            Z1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(143, 80);
            pictureBox1.Margin = new Padding(2, 3, 2, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(150, 150);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.AppWorkspace;
            groupBox1.Controls.Add(btn_Refresh);
            groupBox1.Controls.Add(label_index);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Controls.Add(Z8_diff);
            groupBox1.Controls.Add(Z7_diff);
            groupBox1.Controls.Add(Z2_diff);
            groupBox1.Controls.Add(Z0_diff);
            groupBox1.Controls.Add(Z3_diff);
            groupBox1.Controls.Add(Z1_diff);
            groupBox1.Controls.Add(Z4_diff);
            groupBox1.Controls.Add(Z6_diff);
            groupBox1.Controls.Add(Z5_diff);
            groupBox1.Controls.Add(tb_DiffZ);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(Z7);
            groupBox1.Controls.Add(Z0);
            groupBox1.Controls.Add(Z8);
            groupBox1.Controls.Add(Z6);
            groupBox1.Controls.Add(Z5);
            groupBox1.Controls.Add(Z4);
            groupBox1.Controls.Add(Z3);
            groupBox1.Controls.Add(Z2);
            groupBox1.Controls.Add(Z1);
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Location = new Point(2, 3);
            groupBox1.Margin = new Padding(2, 3, 2, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2, 3, 2, 3);
            groupBox1.Size = new Size(446, 294);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "JOG";
            // 
            // btn_Refresh
            // 
            btn_Refresh.Location = new Point(369, 12);
            btn_Refresh.Margin = new Padding(2, 3, 2, 3);
            btn_Refresh.Name = "btn_Refresh";
            btn_Refresh.Size = new Size(73, 25);
            btn_Refresh.TabIndex = 8;
            btn_Refresh.Text = "Refresh\n";
            btn_Refresh.UseVisualStyleBackColor = true;
            btn_Refresh.Click += btn_Refresh_Click;
            // 
            // label_index
            // 
            label_index.AutoSize = true;
            label_index.Location = new Point(51, 20);
            label_index.Margin = new Padding(2, 0, 2, 0);
            label_index.Name = "label_index";
            label_index.Size = new Size(15, 17);
            label_index.TabIndex = 7;
            label_index.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(4, 20);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(43, 17);
            label2.TabIndex = 6;
            label2.Text = "Index:";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(290, 271);
            checkBox1.Margin = new Padding(2, 3, 2, 3);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(152, 21);
            checkBox1.TabIndex = 4;
            checkBox1.Text = "From Rotation Center";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += btn_Refresh_Click;
            // 
            // Z8_diff
            // 
            Z8_diff.BackColor = SystemColors.WindowFrame;
            Z8_diff.BorderStyle = BorderStyle.FixedSingle;
            Z8_diff.ForeColor = SystemColors.ButtonHighlight;
            Z8_diff.Location = new Point(73, 92);
            Z8_diff.Margin = new Padding(2, 0, 2, 0);
            Z8_diff.Name = "Z8_diff";
            Z8_diff.Size = new Size(52, 22);
            Z8_diff.TabIndex = 3;
            Z8_diff.Text = "0";
            Z8_diff.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Z7_diff
            // 
            Z7_diff.BackColor = SystemColors.WindowFrame;
            Z7_diff.BorderStyle = BorderStyle.FixedSingle;
            Z7_diff.ForeColor = SystemColors.ButtonHighlight;
            Z7_diff.Location = new Point(51, 155);
            Z7_diff.Margin = new Padding(2, 0, 2, 0);
            Z7_diff.Name = "Z7_diff";
            Z7_diff.Size = new Size(52, 22);
            Z7_diff.TabIndex = 3;
            Z7_diff.Text = "0";
            Z7_diff.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Z2_diff
            // 
            Z2_diff.BackColor = SystemColors.WindowFrame;
            Z2_diff.BorderStyle = BorderStyle.FixedSingle;
            Z2_diff.ForeColor = SystemColors.ButtonHighlight;
            Z2_diff.Location = new Point(304, 92);
            Z2_diff.Margin = new Padding(2, 0, 2, 0);
            Z2_diff.Name = "Z2_diff";
            Z2_diff.Size = new Size(52, 22);
            Z2_diff.TabIndex = 3;
            Z2_diff.Text = "0";
            Z2_diff.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Z0_diff
            // 
            Z0_diff.BorderStyle = BorderStyle.FixedSingle;
            Z0_diff.Location = new Point(194, 155);
            Z0_diff.Margin = new Padding(2, 0, 2, 0);
            Z0_diff.Name = "Z0_diff";
            Z0_diff.Size = new Size(52, 22);
            Z0_diff.TabIndex = 3;
            Z0_diff.Text = "0";
            Z0_diff.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Z3_diff
            // 
            Z3_diff.BackColor = SystemColors.WindowFrame;
            Z3_diff.BorderStyle = BorderStyle.FixedSingle;
            Z3_diff.ForeColor = SystemColors.ButtonHighlight;
            Z3_diff.Location = new Point(326, 155);
            Z3_diff.Margin = new Padding(2, 0, 2, 0);
            Z3_diff.Name = "Z3_diff";
            Z3_diff.Size = new Size(52, 22);
            Z3_diff.TabIndex = 3;
            Z3_diff.Text = "0";
            Z3_diff.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Z1_diff
            // 
            Z1_diff.BackColor = SystemColors.WindowFrame;
            Z1_diff.BorderStyle = BorderStyle.FixedSingle;
            Z1_diff.ForeColor = SystemColors.ButtonHighlight;
            Z1_diff.Location = new Point(194, 55);
            Z1_diff.Margin = new Padding(2, 0, 2, 0);
            Z1_diff.Name = "Z1_diff";
            Z1_diff.Size = new Size(52, 22);
            Z1_diff.TabIndex = 3;
            Z1_diff.Text = "0";
            Z1_diff.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Z4_diff
            // 
            Z4_diff.BackColor = SystemColors.WindowFrame;
            Z4_diff.BorderStyle = BorderStyle.FixedSingle;
            Z4_diff.ForeColor = SystemColors.ButtonHighlight;
            Z4_diff.Location = new Point(304, 217);
            Z4_diff.Margin = new Padding(2, 0, 2, 0);
            Z4_diff.Name = "Z4_diff";
            Z4_diff.Size = new Size(52, 22);
            Z4_diff.TabIndex = 3;
            Z4_diff.Text = "0";
            Z4_diff.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Z6_diff
            // 
            Z6_diff.BackColor = SystemColors.WindowFrame;
            Z6_diff.BorderStyle = BorderStyle.FixedSingle;
            Z6_diff.ForeColor = SystemColors.ButtonHighlight;
            Z6_diff.Location = new Point(73, 217);
            Z6_diff.Margin = new Padding(2, 0, 2, 0);
            Z6_diff.Name = "Z6_diff";
            Z6_diff.Size = new Size(52, 22);
            Z6_diff.TabIndex = 3;
            Z6_diff.Text = "0";
            Z6_diff.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Z5_diff
            // 
            Z5_diff.BackColor = SystemColors.WindowFrame;
            Z5_diff.BorderStyle = BorderStyle.FixedSingle;
            Z5_diff.ForeColor = SystemColors.ButtonHighlight;
            Z5_diff.Location = new Point(194, 256);
            Z5_diff.Margin = new Padding(2, 0, 2, 0);
            Z5_diff.Name = "Z5_diff";
            Z5_diff.Size = new Size(52, 22);
            Z5_diff.TabIndex = 3;
            Z5_diff.Text = "0";
            Z5_diff.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tb_DiffZ
            // 
            tb_DiffZ.BackColor = SystemColors.WindowFrame;
            tb_DiffZ.ForeColor = SystemColors.Window;
            tb_DiffZ.Location = new Point(40, 269);
            tb_DiffZ.Margin = new Padding(2, 3, 2, 3);
            tb_DiffZ.Name = "tb_DiffZ";
            tb_DiffZ.Size = new Size(59, 23);
            tb_DiffZ.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(5, 272);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(31, 17);
            label1.TabIndex = 1;
            label1.Text = "Diff:";
            // 
            // Z7
            // 
            Z7.BackColor = SystemColors.ActiveCaption;
            Z7.Location = new Point(40, 127);
            Z7.Margin = new Padding(2, 3, 2, 3);
            Z7.Name = "Z7";
            Z7.Size = new Size(73, 25);
            Z7.TabIndex = 0;
            Z7.Text = "0";
            Z7.UseVisualStyleBackColor = false;
            Z7.Click += JOG_CLick;
            // 
            // Z0
            // 
            Z0.BackColor = SystemColors.Highlight;
            Z0.Location = new Point(182, 127);
            Z0.Margin = new Padding(2, 3, 2, 3);
            Z0.Name = "Z0";
            Z0.Size = new Size(73, 25);
            Z0.TabIndex = 0;
            Z0.Text = "0";
            Z0.UseVisualStyleBackColor = false;
            Z0.Click += JOG_CLick;
            // 
            // Z8
            // 
            Z8.BackColor = SystemColors.ActiveCaption;
            Z8.Location = new Point(63, 64);
            Z8.Margin = new Padding(2, 3, 2, 3);
            Z8.Name = "Z8";
            Z8.Size = new Size(73, 25);
            Z8.TabIndex = 0;
            Z8.Text = "0";
            Z8.UseVisualStyleBackColor = false;
            Z8.Click += JOG_CLick;
            // 
            // Z6
            // 
            Z6.BackColor = SystemColors.ActiveCaption;
            Z6.Location = new Point(63, 189);
            Z6.Margin = new Padding(2, 3, 2, 3);
            Z6.Name = "Z6";
            Z6.Size = new Size(73, 25);
            Z6.TabIndex = 0;
            Z6.Text = "0";
            Z6.UseVisualStyleBackColor = false;
            Z6.Click += JOG_CLick;
            // 
            // Z5
            // 
            Z5.BackColor = SystemColors.ActiveCaption;
            Z5.Location = new Point(182, 228);
            Z5.Margin = new Padding(2, 3, 2, 3);
            Z5.Name = "Z5";
            Z5.Size = new Size(73, 25);
            Z5.TabIndex = 0;
            Z5.Text = "0";
            Z5.UseVisualStyleBackColor = false;
            Z5.Click += JOG_CLick;
            // 
            // Z4
            // 
            Z4.BackColor = SystemColors.ActiveCaption;
            Z4.Location = new Point(294, 189);
            Z4.Margin = new Padding(2, 3, 2, 3);
            Z4.Name = "Z4";
            Z4.Size = new Size(73, 25);
            Z4.TabIndex = 0;
            Z4.Text = "0";
            Z4.UseVisualStyleBackColor = false;
            Z4.Click += JOG_CLick;
            // 
            // Z3
            // 
            Z3.BackColor = SystemColors.ActiveCaption;
            Z3.Location = new Point(326, 127);
            Z3.Margin = new Padding(2, 3, 2, 3);
            Z3.Name = "Z3";
            Z3.Size = new Size(73, 25);
            Z3.TabIndex = 0;
            Z3.Text = "0";
            Z3.UseVisualStyleBackColor = false;
            Z3.Click += JOG_CLick;
            // 
            // Z2
            // 
            Z2.BackColor = SystemColors.ActiveCaption;
            Z2.Location = new Point(294, 64);
            Z2.Margin = new Padding(2, 3, 2, 3);
            Z2.Name = "Z2";
            Z2.Size = new Size(73, 25);
            Z2.TabIndex = 0;
            Z2.Text = "0";
            Z2.UseVisualStyleBackColor = false;
            Z2.Click += JOG_CLick;
            // 
            // Z1
            // 
            Z1.BackColor = SystemColors.ActiveCaption;
            Z1.Location = new Point(182, 27);
            Z1.Margin = new Padding(2, 3, 2, 3);
            Z1.Name = "Z1";
            Z1.Size = new Size(73, 25);
            Z1.TabIndex = 0;
            Z1.Text = "0";
            Z1.UseVisualStyleBackColor = false;
            Z1.Click += JOG_CLick;
            // 
            // PlanarityHeight
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox1);
            Name = "PlanarityHeight";
            Size = new Size(450, 300);
            Load += PlanarityHeight_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button Z1;
        private CheckBox checkBox1;
        private Label Z8_diff;
        private Label Z7_diff;
        private Label Z2_diff;
        private Label Z0_diff;
        private Label Z3_diff;
        private Label Z1_diff;
        private Label Z4_diff;
        private Label Z6_diff;
        private Label Z5_diff;
        private TextBox tb_DiffZ;
        private Label label1;
        private Button Z7;
        private Button Z0;
        private Button Z8;
        private Button Z6;
        private Button Z5;
        private Button Z4;
        private Button Z3;
        private Button Z2;
        private PictureBox pictureBox1;
        private Label label_index;
        private Label label2;
        private Button btn_Refresh;
    }
}
