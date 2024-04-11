namespace test
{
    partial class testErrorMapping
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            RbtnMotion = new RadioButton();
            RbtnProbing = new RadioButton();
            RbtnAlign = new RadioButton();
            TxtUserPosY = new TextBox();
            TxtUserPosX = new TextBox();
            label4 = new Label();
            userPosX = new Label();
            TbarY = new TrackBar();
            TbarX = new TrackBar();
            label2 = new Label();
            label1 = new Label();
            NumEncodeY = new NumericUpDown();
            NumEncodeX = new NumericUpDown();
            canvas = new PictureBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TbarY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TbarX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumEncodeY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumEncodeX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)canvas).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(RbtnMotion);
            groupBox1.Controls.Add(RbtnProbing);
            groupBox1.Controls.Add(RbtnAlign);
            groupBox1.Location = new Point(784, 69);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(87, 89);
            groupBox1.TabIndex = 39;
            groupBox1.TabStop = false;
            groupBox1.Text = "coordinate";
            // 
            // RbtnMotion
            // 
            RbtnMotion.AutoSize = true;
            RbtnMotion.Location = new Point(6, 61);
            RbtnMotion.Name = "RbtnMotion";
            RbtnMotion.Size = new Size(68, 21);
            RbtnMotion.TabIndex = 28;
            RbtnMotion.Text = "Motion";
            RbtnMotion.UseVisualStyleBackColor = true;
            // 
            // RbtnProbing
            // 
            RbtnProbing.AutoSize = true;
            RbtnProbing.Location = new Point(6, 41);
            RbtnProbing.Name = "RbtnProbing";
            RbtnProbing.Size = new Size(72, 21);
            RbtnProbing.TabIndex = 1;
            RbtnProbing.TabStop = true;
            RbtnProbing.Text = "Probing";
            RbtnProbing.UseVisualStyleBackColor = true;
            // 
            // RbtnAlign
            // 
            RbtnAlign.AutoSize = true;
            RbtnAlign.Checked = true;
            RbtnAlign.Location = new Point(6, 20);
            RbtnAlign.Name = "RbtnAlign";
            RbtnAlign.Size = new Size(55, 21);
            RbtnAlign.TabIndex = 0;
            RbtnAlign.TabStop = true;
            RbtnAlign.Text = "Align";
            RbtnAlign.UseVisualStyleBackColor = true;
            // 
            // TxtUserPosY
            // 
            TxtUserPosY.Location = new Point(847, 37);
            TxtUserPosY.Name = "TxtUserPosY";
            TxtUserPosY.Size = new Size(100, 23);
            TxtUserPosY.TabIndex = 37;
            // 
            // TxtUserPosX
            // 
            TxtUserPosX.Location = new Point(847, 3);
            TxtUserPosX.Name = "TxtUserPosX";
            TxtUserPosX.Size = new Size(100, 23);
            TxtUserPosX.TabIndex = 38;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(784, 43);
            label4.Name = "label4";
            label4.Size = new Size(61, 17);
            label4.TabIndex = 36;
            label4.Text = "userPosY";
            // 
            // userPosX
            // 
            userPosX.AutoSize = true;
            userPosX.Location = new Point(783, 9);
            userPosX.Name = "userPosX";
            userPosX.Size = new Size(62, 17);
            userPosX.TabIndex = 35;
            userPosX.Text = "userPosX";
            // 
            // TbarY
            // 
            TbarY.Location = new Point(100, 0);
            TbarY.Name = "TbarY";
            TbarY.Orientation = Orientation.Vertical;
            TbarY.Size = new Size(45, 1050);
            TbarY.TabIndex = 33;
            TbarY.Scroll += TbarY_Scroll;
            // 
            // TbarX
            // 
            TbarX.Location = new Point(140, 1056);
            TbarX.Name = "TbarX";
            TbarX.Size = new Size(608, 45);
            TbarX.TabIndex = 34;
            TbarX.Scroll += TbarX_Scroll;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 1033);
            label2.Name = "label2";
            label2.Size = new Size(59, 17);
            label2.TabIndex = 32;
            label2.Text = "EncodeX";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 310);
            label1.Name = "label1";
            label1.Size = new Size(58, 17);
            label1.TabIndex = 31;
            label1.Text = "EncodeY";
            // 
            // NumEncodeY
            // 
            NumEncodeY.Location = new Point(12, 330);
            NumEncodeY.Name = "NumEncodeY";
            NumEncodeY.Size = new Size(82, 23);
            NumEncodeY.TabIndex = 29;
            NumEncodeY.ValueChanged += NumEncodeY_ValueChanged;
            // 
            // NumEncodeX
            // 
            NumEncodeX.Location = new Point(12, 1056);
            NumEncodeX.Name = "NumEncodeX";
            NumEncodeX.Size = new Size(100, 23);
            NumEncodeX.TabIndex = 30;
            NumEncodeX.ValueChanged += NumEncodeX_ValueChanged;
            // 
            // canvas
            // 
            canvas.BackColor = Color.Silver;
            canvas.Location = new Point(140, 0);
            canvas.Name = "canvas";
            canvas.Size = new Size(608, 1050);
            canvas.TabIndex = 40;
            canvas.TabStop = false;
            // 
            // testErrorMapping
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1304, 1101);
            Controls.Add(canvas);
            Controls.Add(groupBox1);
            Controls.Add(TxtUserPosY);
            Controls.Add(TxtUserPosX);
            Controls.Add(label4);
            Controls.Add(userPosX);
            Controls.Add(TbarY);
            Controls.Add(TbarX);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(NumEncodeY);
            Controls.Add(NumEncodeX);
            Name = "testErrorMapping";
            Text = "testErrorMapping";
            Load += testErrorMapping_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TbarY).EndInit();
            ((System.ComponentModel.ISupportInitialize)TbarX).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumEncodeY).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumEncodeX).EndInit();
            ((System.ComponentModel.ISupportInitialize)canvas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private RadioButton RbtnMotion;
        private RadioButton RbtnProbing;
        private RadioButton RbtnAlign;
        private TextBox TxtUserPosY;
        private TextBox TxtUserPosX;
        private Label label4;
        private Label userPosX;
        private TrackBar TbarY;
        private TrackBar TbarX;
        private Label label2;
        private Label label1;
        private NumericUpDown NumEncodeY;
        private NumericUpDown NumEncodeX;
        private PictureBox canvas;
    }
}