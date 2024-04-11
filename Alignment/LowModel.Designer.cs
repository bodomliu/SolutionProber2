namespace MainForm
{
    partial class LowModel
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
            BtnIstantLowAlign = new Button();
            txtL = new TextBox();
            txtR = new TextBox();
            label3 = new Label();
            label4 = new Label();
            BtnMoveToRefDie = new Button();
            BtnSetRefDie = new Button();
            BtnTeachLowerLeftCorner = new Button();
            BtnMatchIndex = new Button();
            BtnAlignConfirm = new Button();
            BtnPat1Reg = new Button();
            BtnPat2Reg = new Button();
            BtnMatch = new Button();
            panelIndex = new Panel();
            SuspendLayout();
            // 
            // LblModel
            // 
            LblModel.AutoSize = true;
            LblModel.Font = new Font("Microsoft YaHei UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            LblModel.Location = new Point(9, 23);
            LblModel.Name = "LblModel";
            LblModel.Size = new Size(140, 31);
            LblModel.TabIndex = 0;
            LblModel.Text = "Low Model";
            // 
            // BtnIstantLowAlign
            // 
            BtnIstantLowAlign.Location = new Point(9, 64);
            BtnIstantLowAlign.Name = "BtnIstantLowAlign";
            BtnIstantLowAlign.Size = new Size(75, 56);
            BtnIstantLowAlign.TabIndex = 1;
            BtnIstantLowAlign.Text = "Istant Low Match";
            BtnIstantLowAlign.UseVisualStyleBackColor = true;
            BtnIstantLowAlign.Click += BtnIstantLowAlign_Click;
            // 
            // txtL
            // 
            txtL.Location = new Point(112, 64);
            txtL.Name = "txtL";
            txtL.Size = new Size(37, 23);
            txtL.TabIndex = 41;
            txtL.Text = "1";
            // 
            // txtR
            // 
            txtR.Location = new Point(112, 93);
            txtR.Name = "txtR";
            txtR.Size = new Size(37, 23);
            txtR.TabIndex = 41;
            txtR.Text = "1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(90, 70);
            label3.Name = "label3";
            label3.Size = new Size(14, 17);
            label3.TabIndex = 42;
            label3.Text = "L";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(91, 96);
            label4.Name = "label4";
            label4.Size = new Size(16, 17);
            label4.TabIndex = 43;
            label4.Text = "R";
            // 
            // BtnMoveToRefDie
            // 
            BtnMoveToRefDie.BackColor = Color.Green;
            BtnMoveToRefDie.Location = new Point(9, 139);
            BtnMoveToRefDie.Name = "BtnMoveToRefDie";
            BtnMoveToRefDie.Size = new Size(75, 59);
            BtnMoveToRefDie.TabIndex = 44;
            BtnMoveToRefDie.Text = "Move To Ref Die";
            BtnMoveToRefDie.UseVisualStyleBackColor = false;
            BtnMoveToRefDie.Click += BtnMoveToRefDie_Click;
            // 
            // BtnSetRefDie
            // 
            BtnSetRefDie.BackColor = Color.Green;
            BtnSetRefDie.Location = new Point(90, 139);
            BtnSetRefDie.Name = "BtnSetRefDie";
            BtnSetRefDie.Size = new Size(75, 59);
            BtnSetRefDie.TabIndex = 44;
            BtnSetRefDie.Text = "Set Ref Die";
            BtnSetRefDie.UseVisualStyleBackColor = false;
            BtnSetRefDie.Click += BtnSetRefDie_Click;
            // 
            // BtnTeachLowerLeftCorner
            // 
            BtnTeachLowerLeftCorner.BackColor = Color.Orange;
            BtnTeachLowerLeftCorner.Location = new Point(173, 15);
            BtnTeachLowerLeftCorner.Name = "BtnTeachLowerLeftCorner";
            BtnTeachLowerLeftCorner.Size = new Size(192, 48);
            BtnTeachLowerLeftCorner.TabIndex = 45;
            BtnTeachLowerLeftCorner.Text = "Teach Lower Left Corner";
            BtnTeachLowerLeftCorner.UseVisualStyleBackColor = false;
            BtnTeachLowerLeftCorner.Click += BtnTeachLowerLeftCorner_Click;
            // 
            // BtnMatchIndex
            // 
            BtnMatchIndex.BackColor = Color.Orange;
            BtnMatchIndex.Location = new Point(173, 204);
            BtnMatchIndex.Name = "BtnMatchIndex";
            BtnMatchIndex.Size = new Size(192, 50);
            BtnMatchIndex.TabIndex = 47;
            BtnMatchIndex.Text = "Match Index";
            BtnMatchIndex.UseVisualStyleBackColor = false;
            BtnMatchIndex.Click += BtnMatchIndex_Click;
            // 
            // BtnAlignConfirm
            // 
            BtnAlignConfirm.BackColor = Color.Orange;
            BtnAlignConfirm.Location = new Point(9, 204);
            BtnAlignConfirm.Name = "BtnAlignConfirm";
            BtnAlignConfirm.Size = new Size(156, 101);
            BtnAlignConfirm.TabIndex = 48;
            BtnAlignConfirm.Text = "Match Confirm";
            BtnAlignConfirm.UseVisualStyleBackColor = false;
            BtnAlignConfirm.Click += BtnAlignConfirm_Click;
            // 
            // BtnPat1Reg
            // 
            BtnPat1Reg.BackColor = Color.Orange;
            BtnPat1Reg.Location = new Point(173, 260);
            BtnPat1Reg.Name = "BtnPat1Reg";
            BtnPat1Reg.Size = new Size(98, 45);
            BtnPat1Reg.TabIndex = 49;
            BtnPat1Reg.Text = "Pat 1 Reg";
            BtnPat1Reg.UseVisualStyleBackColor = false;
            BtnPat1Reg.Click += BtnPat1Reg_Click;
            // 
            // BtnPat2Reg
            // 
            BtnPat2Reg.BackColor = Color.Orange;
            BtnPat2Reg.Location = new Point(176, 311);
            BtnPat2Reg.Name = "BtnPat2Reg";
            BtnPat2Reg.Size = new Size(95, 45);
            BtnPat2Reg.TabIndex = 49;
            BtnPat2Reg.Text = "Pat 2 Reg";
            BtnPat2Reg.UseVisualStyleBackColor = false;
            // 
            // BtnMatch
            // 
            BtnMatch.BackColor = Color.Orange;
            BtnMatch.Location = new Point(277, 260);
            BtnMatch.Name = "BtnMatch";
            BtnMatch.Size = new Size(88, 45);
            BtnMatch.TabIndex = 49;
            BtnMatch.Text = "Match";
            BtnMatch.UseVisualStyleBackColor = false;
            BtnMatch.Click += BtnMatch_Click;
            // 
            // panelIndex
            // 
            panelIndex.BackColor = Color.Black;
            panelIndex.Location = new Point(176, 66);
            panelIndex.Name = "panelIndex";
            panelIndex.Size = new Size(205, 132);
            panelIndex.TabIndex = 50;
            // 
            // LowModel
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelIndex);
            Controls.Add(BtnPat2Reg);
            Controls.Add(BtnMatch);
            Controls.Add(BtnPat1Reg);
            Controls.Add(BtnAlignConfirm);
            Controls.Add(BtnMatchIndex);
            Controls.Add(BtnTeachLowerLeftCorner);
            Controls.Add(BtnSetRefDie);
            Controls.Add(BtnMoveToRefDie);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(txtR);
            Controls.Add(txtL);
            Controls.Add(BtnIstantLowAlign);
            Controls.Add(LblModel);
            Name = "LowModel";
            Size = new Size(401, 380);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblModel;
        private Button BtnIstantLowAlign;
        private TextBox txtL;
        private TextBox txtR;
        private Label label3;
        private Label label4;
        private Button BtnMoveToRefDie;
        private Button BtnSetRefDie;
        private Button BtnTeachLowerLeftCorner;
        private Button BtnMatchIndex;
        private Button BtnAlignConfirm;
        private Button BtnPat1Reg;
        private Button BtnPat2Reg;
        private Button BtnMatch;
        private Panel panelIndex;
    }
}
