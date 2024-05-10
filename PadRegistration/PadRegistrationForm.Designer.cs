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
            label1 = new Label();
            TxtCurrentPad = new TextBox();
            btnMoveToPad = new Button();
            btnRefDie = new Button();
            btnNextPad = new Button();
            btnPrevPad = new Button();
            btnRefPad = new Button();
            lblFromDieOrgY = new Label();
            lblFromDieOrgX = new Label();
            lblFromRefPadY = new Label();
            lblFromRefPadX = new Label();
            label4 = new Label();
            label2 = new Label();
            btnAddPad = new Button();
            panelMag = new Panel();
            SuspendLayout();
            // 
            // btnAngN
            // 
            btnAngN.Location = new Point(1183, 249);
            btnAngN.Name = "btnAngN";
            btnAngN.Size = new Size(75, 40);
            btnAngN.TabIndex = 27;
            btnAngN.Text = "Ang-";
            btnAngN.UseVisualStyleBackColor = true;
            // 
            // btnAngP
            // 
            btnAngP.Location = new Point(1102, 249);
            btnAngP.Name = "btnAngP";
            btnAngP.Size = new Size(75, 40);
            btnAngP.TabIndex = 28;
            btnAngP.Text = "Ang+";
            btnAngP.UseVisualStyleBackColor = true;
            // 
            // btnPadNarrow
            // 
            btnPadNarrow.Location = new Point(1183, 203);
            btnPadNarrow.Name = "btnPadNarrow";
            btnPadNarrow.Size = new Size(75, 40);
            btnPadNarrow.TabIndex = 26;
            btnPadNarrow.Text = "Pad2-";
            btnPadNarrow.UseVisualStyleBackColor = true;
            // 
            // btnPadEnlarge
            // 
            btnPadEnlarge.Location = new Point(1102, 203);
            btnPadEnlarge.Name = "btnPadEnlarge";
            btnPadEnlarge.Size = new Size(75, 40);
            btnPadEnlarge.TabIndex = 25;
            btnPadEnlarge.Text = "Pad2+";
            btnPadEnlarge.UseVisualStyleBackColor = true;
            // 
            // btnPadN
            // 
            btnPadN.Location = new Point(1183, 157);
            btnPadN.Name = "btnPadN";
            btnPadN.Size = new Size(75, 40);
            btnPadN.TabIndex = 24;
            btnPadN.Text = "Pad-";
            btnPadN.UseVisualStyleBackColor = true;
            btnPadN.Click += btnPadN_Click;
            // 
            // btnPadP
            // 
            btnPadP.Location = new Point(1102, 157);
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
            label7.Location = new Point(1114, 322);
            label7.Name = "label7";
            label7.Size = new Size(63, 17);
            label7.TabIndex = 48;
            label7.Text = "Total Pad";
            // 
            // btnDeleteAllPad
            // 
            btnDeleteAllPad.Location = new Point(1385, 262);
            btnDeleteAllPad.Name = "btnDeleteAllPad";
            btnDeleteAllPad.Size = new Size(100, 50);
            btnDeleteAllPad.TabIndex = 47;
            btnDeleteAllPad.Text = "Delete All Pad";
            btnDeleteAllPad.UseVisualStyleBackColor = true;
            btnDeleteAllPad.Click += btnDeleteAllPad_Click;
            // 
            // btnDeletePad
            // 
            btnDeletePad.Location = new Point(1279, 262);
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
            btnUpdatePad.Location = new Point(1276, 206);
            btnUpdatePad.Name = "btnUpdatePad";
            btnUpdatePad.Size = new Size(100, 50);
            btnUpdatePad.TabIndex = 44;
            btnUpdatePad.Text = "Update Pad";
            btnUpdatePad.UseVisualStyleBackColor = true;
            btnUpdatePad.Click += btnUpdatePad_Click;
            // 
            // TxtTotalPad
            // 
            TxtTotalPad.Location = new Point(1183, 315);
            TxtTotalPad.Name = "TxtTotalPad";
            TxtTotalPad.ReadOnly = true;
            TxtTotalPad.Size = new Size(75, 23);
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
            panel2.Location = new Point(1089, 542);
            panel2.Name = "panel2";
            panel2.Size = new Size(399, 387);
            panel2.TabIndex = 64;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1100, 351);
            label1.Name = "label1";
            label1.Size = new Size(77, 17);
            label1.TabIndex = 48;
            label1.Text = "Current Pad";
            // 
            // TxtCurrentPad
            // 
            TxtCurrentPad.Location = new Point(1183, 348);
            TxtCurrentPad.Name = "TxtCurrentPad";
            TxtCurrentPad.ReadOnly = true;
            TxtCurrentPad.Size = new Size(75, 23);
            TxtCurrentPad.TabIndex = 51;
            TxtCurrentPad.Text = "0";
            // 
            // btnMoveToPad
            // 
            btnMoveToPad.Location = new Point(1281, 486);
            btnMoveToPad.Name = "btnMoveToPad";
            btnMoveToPad.Size = new Size(100, 50);
            btnMoveToPad.TabIndex = 75;
            btnMoveToPad.Text = "Move To Pad";
            btnMoveToPad.UseVisualStyleBackColor = true;
            btnMoveToPad.Click += btnMoveToPad_Click;
            // 
            // btnRefDie
            // 
            btnRefDie.Location = new Point(1387, 486);
            btnRefDie.Name = "btnRefDie";
            btnRefDie.Size = new Size(100, 50);
            btnRefDie.TabIndex = 74;
            btnRefDie.Text = "Ref Die";
            btnRefDie.UseVisualStyleBackColor = true;
            btnRefDie.Click += btnRefDie_Click;
            // 
            // btnNextPad
            // 
            btnNextPad.Location = new Point(1387, 430);
            btnNextPad.Name = "btnNextPad";
            btnNextPad.Size = new Size(100, 50);
            btnNextPad.TabIndex = 73;
            btnNextPad.Text = "Next Pad";
            btnNextPad.UseVisualStyleBackColor = true;
            btnNextPad.Click += btnNextPad_Click;
            // 
            // btnPrevPad
            // 
            btnPrevPad.Location = new Point(1387, 374);
            btnPrevPad.Name = "btnPrevPad";
            btnPrevPad.Size = new Size(100, 50);
            btnPrevPad.TabIndex = 72;
            btnPrevPad.Text = "Prev Pad";
            btnPrevPad.UseVisualStyleBackColor = true;
            btnPrevPad.Click += btnPrevPad_Click;
            // 
            // btnRefPad
            // 
            btnRefPad.Location = new Point(1385, 322);
            btnRefPad.Name = "btnRefPad";
            btnRefPad.Size = new Size(100, 50);
            btnRefPad.TabIndex = 71;
            btnRefPad.Text = "Ref Pad";
            btnRefPad.UseVisualStyleBackColor = true;
            btnRefPad.Click += btnRefPad_Click;
            // 
            // lblFromDieOrgY
            // 
            lblFromDieOrgY.AutoSize = true;
            lblFromDieOrgY.Location = new Point(1303, 467);
            lblFromDieOrgY.Name = "lblFromDieOrgY";
            lblFromDieOrgY.Size = new Size(15, 17);
            lblFromDieOrgY.TabIndex = 70;
            lblFromDieOrgY.Text = "0";
            // 
            // lblFromDieOrgX
            // 
            lblFromDieOrgX.AutoSize = true;
            lblFromDieOrgX.Location = new Point(1303, 440);
            lblFromDieOrgX.Name = "lblFromDieOrgX";
            lblFromDieOrgX.Size = new Size(15, 17);
            lblFromDieOrgX.TabIndex = 69;
            lblFromDieOrgX.Text = "0";
            // 
            // lblFromRefPadY
            // 
            lblFromRefPadY.AutoSize = true;
            lblFromRefPadY.Location = new Point(1303, 379);
            lblFromRefPadY.Name = "lblFromRefPadY";
            lblFromRefPadY.Size = new Size(15, 17);
            lblFromRefPadY.TabIndex = 68;
            lblFromRefPadY.Text = "0";
            // 
            // lblFromRefPadX
            // 
            lblFromRefPadX.AutoSize = true;
            lblFromRefPadX.Location = new Point(1303, 350);
            lblFromRefPadX.Name = "lblFromRefPadX";
            lblFromRefPadX.Size = new Size(15, 17);
            lblFromRefPadX.TabIndex = 67;
            lblFromRefPadX.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1281, 411);
            label4.Name = "label4";
            label4.Size = new Size(88, 17);
            label4.TabIndex = 66;
            label4.Text = "From Die Org";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1281, 321);
            label2.Name = "label2";
            label2.Size = new Size(87, 17);
            label2.TabIndex = 65;
            label2.Text = "From Ref Pad";
            // 
            // btnAddPad
            // 
            btnAddPad.Location = new Point(1276, 147);
            btnAddPad.Name = "btnAddPad";
            btnAddPad.Size = new Size(100, 50);
            btnAddPad.TabIndex = 44;
            btnAddPad.Text = "Add Pad";
            btnAddPad.UseVisualStyleBackColor = true;
            btnAddPad.Click += btnAddPad_Click;
            // 
            // panelMag
            // 
            panelMag.BackColor = Color.Black;
            panelMag.Location = new Point(1266, 2);
            panelMag.Name = "panelMag";
            panelMag.Size = new Size(235, 83);
            panelMag.TabIndex = 76;
            // 
            // PadRegistrationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1574, 1126);
            Controls.Add(panelMag);
            Controls.Add(btnMoveToPad);
            Controls.Add(btnRefDie);
            Controls.Add(btnNextPad);
            Controls.Add(btnPrevPad);
            Controls.Add(btnRefPad);
            Controls.Add(lblFromDieOrgY);
            Controls.Add(lblFromDieOrgX);
            Controls.Add(lblFromRefPadY);
            Controls.Add(lblFromRefPadX);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(BtnInsertPad);
            Controls.Add(TxtCurrentPad);
            Controls.Add(TxtTotalPad);
            Controls.Add(btnReadyToApply);
            Controls.Add(label1);
            Controls.Add(label7);
            Controls.Add(btnDeleteAllPad);
            Controls.Add(btnDeletePad);
            Controls.Add(btnRefPadReg);
            Controls.Add(btnAddPad);
            Controls.Add(btnUpdatePad);
            Controls.Add(btnAngN);
            Controls.Add(btnAngP);
            Controls.Add(btnPadNarrow);
            Controls.Add(btnPadEnlarge);
            Controls.Add(btnPadN);
            Controls.Add(btnPadP);
            Name = "PadRegistrationForm";
            Text = "PadForm";
            Load += PadRegistrationForm_Load;
            VisibleChanged += PadRegistrationForm_VisibleChanged;
            ParentChanged += PadRegistrationForm_ParentChanged;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
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
        private Label label1;
        private TextBox TxtCurrentPad;
        private Button btnMoveToPad;
        private Button btnRefDie;
        private Button btnNextPad;
        private Button btnPrevPad;
        private Button btnRefPad;
        private Label lblFromDieOrgY;
        private Label lblFromDieOrgX;
        private Label lblFromRefPadY;
        private Label lblFromRefPadX;
        private Label label4;
        private Label label2;
        private Button btnAddPad;
        private Panel panelMag;
    }
}