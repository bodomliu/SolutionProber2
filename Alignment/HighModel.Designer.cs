namespace MainForm
{
    partial class HighModel
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
            LblModel = new Label();
            label3 = new Label();
            label4 = new Label();
            txtR = new TextBox();
            txtL = new TextBox();
            BtnIstantHighAlign = new Button();
            BtnMoveToRefDie = new Button();
            BtnPat2Reg = new Button();
            BtnPat1Reg = new Button();
            BtnAlignConfirm = new Button();
            BtnLowMagAlign = new Button();
            BtnMatch1 = new Button();
            panel1 = new Panel();
            BtnMatch2 = new Button();
            SuspendLayout();
            // 
            // LblModel
            // 
            LblModel.AutoSize = true;
            LblModel.Font = new Font("Microsoft YaHei UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            LblModel.Location = new Point(25, 20);
            LblModel.Name = "LblModel";
            LblModel.Size = new Size(149, 31);
            LblModel.TabIndex = 1;
            LblModel.Text = "High Model";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(98, 80);
            label3.Name = "label3";
            label3.Size = new Size(14, 17);
            label3.TabIndex = 47;
            label3.Text = "L";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(99, 106);
            label4.Name = "label4";
            label4.Size = new Size(16, 17);
            label4.TabIndex = 48;
            label4.Text = "R";
            // 
            // txtR
            // 
            txtR.Location = new Point(120, 103);
            txtR.Name = "txtR";
            txtR.Size = new Size(37, 23);
            txtR.TabIndex = 45;
            txtR.Text = "10";
            // 
            // txtL
            // 
            txtL.Location = new Point(120, 74);
            txtL.Name = "txtL";
            txtL.Size = new Size(37, 23);
            txtL.TabIndex = 46;
            txtL.Text = "10";
            // 
            // BtnIstantHighAlign
            // 
            BtnIstantHighAlign.Location = new Point(8, 70);
            BtnIstantHighAlign.Name = "BtnIstantHighAlign";
            BtnIstantHighAlign.Size = new Size(85, 56);
            BtnIstantHighAlign.TabIndex = 44;
            BtnIstantHighAlign.Text = "Istant High Match";
            BtnIstantHighAlign.UseVisualStyleBackColor = true;
            BtnIstantHighAlign.Click += BtnIstantHighAlign_Click;
            // 
            // BtnMoveToRefDie
            // 
            BtnMoveToRefDie.BackColor = Color.YellowGreen;
            BtnMoveToRefDie.Location = new Point(8, 136);
            BtnMoveToRefDie.Name = "BtnMoveToRefDie";
            BtnMoveToRefDie.Size = new Size(156, 65);
            BtnMoveToRefDie.TabIndex = 49;
            BtnMoveToRefDie.Text = "Move To Ref Die";
            BtnMoveToRefDie.UseVisualStyleBackColor = false;
            BtnMoveToRefDie.Click += BtnMoveToRefDie_Click;
            // 
            // BtnPat2Reg
            // 
            BtnPat2Reg.BackColor = Color.Teal;
            BtnPat2Reg.Location = new Point(169, 155);
            BtnPat2Reg.Name = "BtnPat2Reg";
            BtnPat2Reg.Size = new Size(134, 45);
            BtnPat2Reg.TabIndex = 50;
            BtnPat2Reg.Text = "Pat 2 Reg";
            BtnPat2Reg.UseVisualStyleBackColor = false;
            BtnPat2Reg.Click += BtnPat2Reg_Click;
            // 
            // BtnPat1Reg
            // 
            BtnPat1Reg.BackColor = Color.Orange;
            BtnPat1Reg.Location = new Point(169, 103);
            BtnPat1Reg.Name = "BtnPat1Reg";
            BtnPat1Reg.Size = new Size(134, 46);
            BtnPat1Reg.TabIndex = 51;
            BtnPat1Reg.Text = "Pat 1 Reg";
            BtnPat1Reg.UseVisualStyleBackColor = false;
            BtnPat1Reg.Click += BtnPat1Reg_Click;
            // 
            // BtnAlignConfirm
            // 
            BtnAlignConfirm.BackColor = Color.Orange;
            BtnAlignConfirm.Location = new Point(8, 207);
            BtnAlignConfirm.Name = "BtnAlignConfirm";
            BtnAlignConfirm.Size = new Size(156, 101);
            BtnAlignConfirm.TabIndex = 52;
            BtnAlignConfirm.Text = "Match Confirm";
            BtnAlignConfirm.UseVisualStyleBackColor = false;
            BtnAlignConfirm.Click += BtnAlignConfirm_Click;
            // 
            // BtnLowMagAlign
            // 
            BtnLowMagAlign.BackColor = Color.Orange;
            BtnLowMagAlign.Location = new Point(169, 20);
            BtnLowMagAlign.Name = "BtnLowMagAlign";
            BtnLowMagAlign.Size = new Size(214, 79);
            BtnLowMagAlign.TabIndex = 51;
            BtnLowMagAlign.Text = "Low Mag Match";
            BtnLowMagAlign.UseVisualStyleBackColor = false;
            BtnLowMagAlign.Click += BtnLowMagAlign_Click;
            // 
            // BtnMatch1
            // 
            BtnMatch1.BackColor = Color.Orange;
            BtnMatch1.Location = new Point(309, 103);
            BtnMatch1.Name = "BtnMatch1";
            BtnMatch1.Size = new Size(70, 46);
            BtnMatch1.TabIndex = 51;
            BtnMatch1.Text = "Match";
            BtnMatch1.UseVisualStyleBackColor = false;
            BtnMatch1.Click += BtnMatch1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Location = new Point(173, 205);
            panel1.Name = "panel1";
            panel1.Size = new Size(206, 132);
            panel1.TabIndex = 53;
            // 
            // BtnMatch2
            // 
            BtnMatch2.BackColor = Color.Orange;
            BtnMatch2.Location = new Point(309, 155);
            BtnMatch2.Name = "BtnMatch2";
            BtnMatch2.Size = new Size(70, 45);
            BtnMatch2.TabIndex = 51;
            BtnMatch2.Text = "Match";
            BtnMatch2.UseVisualStyleBackColor = false;
            BtnMatch2.Click += BtnMatch2_Click;
            // 
            // HighModel
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(BtnAlignConfirm);
            Controls.Add(BtnPat2Reg);
            Controls.Add(BtnLowMagAlign);
            Controls.Add(BtnMatch2);
            Controls.Add(BtnMatch1);
            Controls.Add(BtnPat1Reg);
            Controls.Add(BtnMoveToRefDie);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(txtR);
            Controls.Add(txtL);
            Controls.Add(BtnIstantHighAlign);
            Controls.Add(LblModel);
            Name = "HighModel";
            Size = new Size(400, 380);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblModel;
        private Label label3;
        private Label label4;
        private TextBox txtR;
        private TextBox txtL;
        private Button BtnIstantHighAlign;
        private Button BtnMoveToRefDie;
        private Button BtnPat2Reg;
        private Button BtnPat1Reg;
        private Button BtnAlignConfirm;
        private Button BtnLowMagAlign;
        private Button BtnMatch1;
        private Panel panel1;
        private Button BtnMatch2;
    }
}
