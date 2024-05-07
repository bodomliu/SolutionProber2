namespace MainForm
{
    partial class PadControl
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
            btnMoveToPad = new Button();
            btnRefDie = new Button();
            btnNextPad = new Button();
            btnPrevPad = new Button();
            btnRefPad = new Button();
            lblFromDieOrgY = new Label();
            lblFromDieOrgX = new Label();
            lblFromRefPadY = new Label();
            lblFromRefPadX = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            PicCanvas = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)PicCanvas).BeginInit();
            SuspendLayout();
            // 
            // btnMoveToPad
            // 
            btnMoveToPad.Location = new Point(228, 183);
            btnMoveToPad.Name = "btnMoveToPad";
            btnMoveToPad.Size = new Size(100, 50);
            btnMoveToPad.TabIndex = 58;
            btnMoveToPad.Text = "Move To Pad";
            btnMoveToPad.UseVisualStyleBackColor = true;
            btnMoveToPad.Click += btnMoveToPad_Click;
            // 
            // btnRefDie
            // 
            btnRefDie.Location = new Point(334, 183);
            btnRefDie.Name = "btnRefDie";
            btnRefDie.Size = new Size(100, 50);
            btnRefDie.TabIndex = 57;
            btnRefDie.Text = "Ref Die";
            btnRefDie.UseVisualStyleBackColor = true;
            btnRefDie.Click += btnRefDie_Click;
            // 
            // btnNextPad
            // 
            btnNextPad.Location = new Point(334, 127);
            btnNextPad.Name = "btnNextPad";
            btnNextPad.Size = new Size(100, 50);
            btnNextPad.TabIndex = 56;
            btnNextPad.Text = "Next Pad";
            btnNextPad.UseVisualStyleBackColor = true;
            btnNextPad.Click += btnNextPad_Click;
            // 
            // btnPrevPad
            // 
            btnPrevPad.Location = new Point(334, 71);
            btnPrevPad.Name = "btnPrevPad";
            btnPrevPad.Size = new Size(100, 50);
            btnPrevPad.TabIndex = 55;
            btnPrevPad.Text = "Prev Pad";
            btnPrevPad.UseVisualStyleBackColor = true;
            btnPrevPad.Click += btnPrevPad_Click;
            // 
            // btnRefPad
            // 
            btnRefPad.Location = new Point(334, 12);
            btnRefPad.Name = "btnRefPad";
            btnRefPad.Size = new Size(100, 50);
            btnRefPad.TabIndex = 54;
            btnRefPad.Text = "Ref Pad";
            btnRefPad.UseVisualStyleBackColor = true;
            btnRefPad.Click += btnRefPad_Click;
            // 
            // lblFromDieOrgY
            // 
            lblFromDieOrgY.AutoSize = true;
            lblFromDieOrgY.Location = new Point(250, 162);
            lblFromDieOrgY.Name = "lblFromDieOrgY";
            lblFromDieOrgY.Size = new Size(15, 17);
            lblFromDieOrgY.TabIndex = 53;
            lblFromDieOrgY.Text = "0";
            // 
            // lblFromDieOrgX
            // 
            lblFromDieOrgX.AutoSize = true;
            lblFromDieOrgX.Location = new Point(250, 135);
            lblFromDieOrgX.Name = "lblFromDieOrgX";
            lblFromDieOrgX.Size = new Size(15, 17);
            lblFromDieOrgX.TabIndex = 52;
            lblFromDieOrgX.Text = "0";
            // 
            // lblFromRefPadY
            // 
            lblFromRefPadY.AutoSize = true;
            lblFromRefPadY.Location = new Point(250, 74);
            lblFromRefPadY.Name = "lblFromRefPadY";
            lblFromRefPadY.Size = new Size(15, 17);
            lblFromRefPadY.TabIndex = 51;
            lblFromRefPadY.Text = "0";
            // 
            // lblFromRefPadX
            // 
            lblFromRefPadX.AutoSize = true;
            lblFromRefPadX.Location = new Point(250, 45);
            lblFromRefPadX.Name = "lblFromRefPadX";
            lblFromRefPadX.Size = new Size(15, 17);
            lblFromRefPadX.TabIndex = 50;
            lblFromRefPadX.Text = "0";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(228, 162);
            label6.Name = "label6";
            label6.Size = new Size(15, 17);
            label6.TabIndex = 48;
            label6.Text = "Y";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(228, 135);
            label5.Name = "label5";
            label5.Size = new Size(16, 17);
            label5.TabIndex = 47;
            label5.Text = "X";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(228, 106);
            label4.Name = "label4";
            label4.Size = new Size(88, 17);
            label4.TabIndex = 46;
            label4.Text = "From Die Org";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(228, 74);
            label3.Name = "label3";
            label3.Size = new Size(15, 17);
            label3.TabIndex = 45;
            label3.Text = "Y";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(228, 45);
            label2.Name = "label2";
            label2.Size = new Size(16, 17);
            label2.TabIndex = 49;
            label2.Text = "X";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(228, 16);
            label1.Name = "label1";
            label1.Size = new Size(87, 17);
            label1.TabIndex = 44;
            label1.Text = "From Ref Pad";
            // 
            // PicCanvas
            // 
            PicCanvas.BackColor = Color.LimeGreen;
            PicCanvas.Location = new Point(9, 7);
            PicCanvas.Name = "PicCanvas";
            PicCanvas.Size = new Size(213, 226);
            PicCanvas.TabIndex = 59;
            PicCanvas.TabStop = false;
            // 
            // PadControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            Controls.Add(PicCanvas);
            Controls.Add(btnMoveToPad);
            Controls.Add(btnRefDie);
            Controls.Add(btnNextPad);
            Controls.Add(btnPrevPad);
            Controls.Add(btnRefPad);
            Controls.Add(lblFromDieOrgY);
            Controls.Add(lblFromDieOrgX);
            Controls.Add(lblFromRefPadY);
            Controls.Add(lblFromRefPadX);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "PadControl";
            Size = new Size(442, 245);
            ((System.ComponentModel.ISupportInitialize)PicCanvas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnMoveToPad;
        private Button btnRefDie;
        private Button btnNextPad;
        private Button btnPrevPad;
        private Button btnRefPad;
        private Label lblFromDieOrgY;
        private Label lblFromDieOrgX;
        private Label lblFromRefPadY;
        private Label lblFromRefPadX;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private PictureBox PicCanvas;
    }
}
