namespace MainForm
{
    partial class PadRegistrationForm
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
            BtnLowMag = new Button();
            BtnHighMag = new Button();
            btnAngN = new Button();
            btnAngP = new Button();
            btnPadNarrow = new Button();
            btnPadEnlarge = new Button();
            btnPadN = new Button();
            btnPadP = new Button();
            btnReadyToApply = new Button();
            label7 = new Label();
            btnDeleteAllPad = new Button();
            btnDeletePad = new Button();
            btnRefPadReg = new Button();
            btnUpdatePad = new Button();
            TxtTotalPad = new TextBox();
            BtnInsertPad = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            SuspendLayout();
            // 
            // BtnLowMag
            // 
            BtnLowMag.BackColor = Color.Teal;
            BtnLowMag.Location = new Point(1385, 12);
            BtnLowMag.Name = "BtnLowMag";
            BtnLowMag.Size = new Size(102, 73);
            BtnLowMag.TabIndex = 21;
            BtnLowMag.Text = "Low Mag";
            BtnLowMag.UseVisualStyleBackColor = false;
            BtnLowMag.Click += BtnLowMag_Click;
            // 
            // BtnHighMag
            // 
            BtnHighMag.BackColor = Color.Teal;
            BtnHighMag.Location = new Point(1276, 12);
            BtnHighMag.Name = "BtnHighMag";
            BtnHighMag.Size = new Size(103, 73);
            BtnHighMag.TabIndex = 22;
            BtnHighMag.Text = "High Mag";
            BtnHighMag.UseVisualStyleBackColor = false;
            BtnHighMag.Click += BtnHighMag_Click;
            // 
            // btnAngN
            // 
            btnAngN.Location = new Point(1183, 270);
            btnAngN.Name = "btnAngN";
            btnAngN.Size = new Size(75, 40);
            btnAngN.TabIndex = 27;
            btnAngN.Text = "Ang-";
            btnAngN.UseVisualStyleBackColor = true;
            // 
            // btnAngP
            // 
            btnAngP.Location = new Point(1102, 270);
            btnAngP.Name = "btnAngP";
            btnAngP.Size = new Size(75, 40);
            btnAngP.TabIndex = 28;
            btnAngP.Text = "Ang+";
            btnAngP.UseVisualStyleBackColor = true;
            // 
            // btnPadNarrow
            // 
            btnPadNarrow.Location = new Point(1183, 224);
            btnPadNarrow.Name = "btnPadNarrow";
            btnPadNarrow.Size = new Size(75, 40);
            btnPadNarrow.TabIndex = 26;
            btnPadNarrow.Text = "Pad2-";
            btnPadNarrow.UseVisualStyleBackColor = true;
            // 
            // btnPadEnlarge
            // 
            btnPadEnlarge.Location = new Point(1102, 224);
            btnPadEnlarge.Name = "btnPadEnlarge";
            btnPadEnlarge.Size = new Size(75, 40);
            btnPadEnlarge.TabIndex = 25;
            btnPadEnlarge.Text = "Pad2+";
            btnPadEnlarge.UseVisualStyleBackColor = true;
            // 
            // btnPadN
            // 
            btnPadN.Location = new Point(1183, 178);
            btnPadN.Name = "btnPadN";
            btnPadN.Size = new Size(75, 40);
            btnPadN.TabIndex = 24;
            btnPadN.Text = "Pad-";
            btnPadN.UseVisualStyleBackColor = true;
            // 
            // btnPadP
            // 
            btnPadP.Location = new Point(1102, 178);
            btnPadP.Name = "btnPadP";
            btnPadP.Size = new Size(75, 40);
            btnPadP.TabIndex = 23;
            btnPadP.Text = "Pad+";
            btnPadP.UseVisualStyleBackColor = true;
            // 
            // btnReadyToApply
            // 
            btnReadyToApply.BackColor = Color.Red;
            btnReadyToApply.Location = new Point(1385, 91);
            btnReadyToApply.Name = "btnReadyToApply";
            btnReadyToApply.Size = new Size(100, 100);
            btnReadyToApply.TabIndex = 50;
            btnReadyToApply.Text = "Ready To Apply";
            btnReadyToApply.UseVisualStyleBackColor = false;
            btnReadyToApply.Click += btnReadyToApply_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(1387, 266);
            label7.Name = "label7";
            label7.Size = new Size(63, 17);
            label7.TabIndex = 48;
            label7.Text = "Total Pad";
            // 
            // btnDeleteAllPad
            // 
            btnDeleteAllPad.Location = new Point(1276, 259);
            btnDeleteAllPad.Name = "btnDeleteAllPad";
            btnDeleteAllPad.Size = new Size(100, 50);
            btnDeleteAllPad.TabIndex = 47;
            btnDeleteAllPad.Text = "Delete All Pad";
            btnDeleteAllPad.UseVisualStyleBackColor = true;
            btnDeleteAllPad.Click += btnDeleteAllPad_Click;
            // 
            // btnDeletePad
            // 
            btnDeletePad.Location = new Point(1276, 203);
            btnDeletePad.Name = "btnDeletePad";
            btnDeletePad.Size = new Size(100, 50);
            btnDeletePad.TabIndex = 46;
            btnDeletePad.Text = "Delete Pad";
            btnDeletePad.UseVisualStyleBackColor = true;
            btnDeletePad.Click += btnDeletePad_Click;
            // 
            // btnRefPadReg
            // 
            btnRefPadReg.Location = new Point(1276, 91);
            btnRefPadReg.Name = "btnRefPadReg";
            btnRefPadReg.Size = new Size(100, 50);
            btnRefPadReg.TabIndex = 45;
            btnRefPadReg.Text = "Reference Pad Registration";
            btnRefPadReg.UseVisualStyleBackColor = true;
            btnRefPadReg.Click += btnRefPadReg_Click;
            // 
            // btnUpdatePad
            // 
            btnUpdatePad.Location = new Point(1276, 147);
            btnUpdatePad.Name = "btnUpdatePad";
            btnUpdatePad.Size = new Size(100, 50);
            btnUpdatePad.TabIndex = 44;
            btnUpdatePad.Text = "Update Pad";
            btnUpdatePad.UseVisualStyleBackColor = true;
            btnUpdatePad.Click += btnUpdatePad_Click;
            // 
            // TxtTotalPad
            // 
            TxtTotalPad.Location = new Point(1387, 286);
            TxtTotalPad.Name = "TxtTotalPad";
            TxtTotalPad.Size = new Size(100, 23);
            TxtTotalPad.TabIndex = 51;
            TxtTotalPad.Text = "0";
            // 
            // BtnInsertPad
            // 
            BtnInsertPad.Location = new Point(1385, 206);
            BtnInsertPad.Name = "BtnInsertPad";
            BtnInsertPad.Size = new Size(100, 50);
            BtnInsertPad.TabIndex = 52;
            BtnInsertPad.Text = "Insert Pad";
            BtnInsertPad.UseVisualStyleBackColor = true;
            BtnInsertPad.Click += BtnInsertPad_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Location = new Point(3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1080, 1003);
            panel1.TabIndex = 63;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Black;
            panel2.Location = new Point(1102, 429);
            panel2.Name = "panel2";
            panel2.Size = new Size(450, 252);
            panel2.TabIndex = 64;
            // 
            // PadRegistrationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1574, 1126);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(BtnInsertPad);
            Controls.Add(TxtTotalPad);
            Controls.Add(btnReadyToApply);
            Controls.Add(label7);
            Controls.Add(btnDeleteAllPad);
            Controls.Add(btnDeletePad);
            Controls.Add(btnRefPadReg);
            Controls.Add(btnUpdatePad);
            Controls.Add(btnAngN);
            Controls.Add(btnAngP);
            Controls.Add(btnPadNarrow);
            Controls.Add(btnPadEnlarge);
            Controls.Add(btnPadN);
            Controls.Add(btnPadP);
            Controls.Add(BtnLowMag);
            Controls.Add(BtnHighMag);
            Name = "PadRegistrationForm";
            Text = "PadForm";
            Load += PadRegistrationForm_Load;
            VisibleChanged += PadRegistrationForm_VisibleChanged;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnLowMag;
        private Button BtnHighMag;
        private Button btnAngN;
        private Button btnAngP;
        private Button btnPadNarrow;
        private Button btnPadEnlarge;
        private Button btnPadN;
        private Button btnPadP;
        private Button btnReadyToApply;
        private Label label7;
        private Button btnDeleteAllPad;
        private Button btnDeletePad;
        private Button btnRefPadReg;
        private Button btnUpdatePad;
        private TextBox TxtTotalPad;
        private Button BtnInsertPad;
        private Panel panel1;
        private Panel panel2;
    }
}