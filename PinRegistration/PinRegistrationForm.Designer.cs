﻿namespace PinRegistration
{
    partial class PinRegistrationForm
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
            groupBox2 = new GroupBox();
            BtnDeletePinWPad = new Button();
            BtnUpdatePinWPad = new Button();
            BtnRefreshPinDataFromPadData = new Button();
            BtnReadyToApply = new Button();
            BtnRefPinRegistration = new Button();
            BtnAddPinWPad = new Button();
            panel1 = new Panel();
            CBShowPins = new CheckBox();
            panelPinMap = new Panel();
            NumRefPinOffsetR = new NumericUpDown();
            label6 = new Label();
            BtnUpdateDegree = new Button();
            BtnFocusInitial = new Button();
            BtnOrgPinInitial = new Button();
            BtnPinData = new Button();
            panelMag = new Panel();
            BtnAdjustAngle = new Button();
            groupBox3 = new GroupBox();
            Rbtn4Pins = new RadioButton();
            RbtnAllPins = new RadioButton();
            BtnM_Pin = new Button();
            BtnVisionPara = new Button();
            BtnAutoFocusAll = new Button();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumRefPinOffsetR).BeginInit();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Location = new Point(1187, 321);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(284, 263);
            groupBox1.TabIndex = 26;
            groupBox1.TabStop = false;
            groupBox1.Text = "Pin Search";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(BtnDeletePinWPad);
            groupBox2.Controls.Add(BtnUpdatePinWPad);
            groupBox2.Controls.Add(BtnRefreshPinDataFromPadData);
            groupBox2.Controls.Add(BtnReadyToApply);
            groupBox2.Controls.Add(BtnRefPinRegistration);
            groupBox2.Controls.Add(BtnAddPinWPad);
            groupBox2.Location = new Point(1187, 98);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(214, 217);
            groupBox2.TabIndex = 27;
            groupBox2.TabStop = false;
            groupBox2.Text = "Registration";
            // 
            // BtnDeletePinWPad
            // 
            BtnDeletePinWPad.Location = new Point(7, 160);
            BtnDeletePinWPad.Name = "BtnDeletePinWPad";
            BtnDeletePinWPad.Size = new Size(80, 53);
            BtnDeletePinWPad.TabIndex = 0;
            BtnDeletePinWPad.Text = "Delete Pin/Pad";
            BtnDeletePinWPad.UseVisualStyleBackColor = true;
            BtnDeletePinWPad.Click += BtnDeletePinWPad_Click;
            // 
            // BtnUpdatePinWPad
            // 
            BtnUpdatePinWPad.Location = new Point(7, 97);
            BtnUpdatePinWPad.Name = "BtnUpdatePinWPad";
            BtnUpdatePinWPad.Size = new Size(80, 57);
            BtnUpdatePinWPad.TabIndex = 0;
            BtnUpdatePinWPad.Text = "Update Pin/Pad";
            BtnUpdatePinWPad.UseVisualStyleBackColor = true;
            BtnUpdatePinWPad.Click += BtnUpdatePinWPad_Click;
            // 
            // BtnRefreshPinDataFromPadData
            // 
            BtnRefreshPinDataFromPadData.Location = new Point(93, 99);
            BtnRefreshPinDataFromPadData.Name = "BtnRefreshPinDataFromPadData";
            BtnRefreshPinDataFromPadData.Size = new Size(113, 57);
            BtnRefreshPinDataFromPadData.TabIndex = 0;
            BtnRefreshPinDataFromPadData.Text = "Refresh Pin Data From Pad Data";
            BtnRefreshPinDataFromPadData.UseVisualStyleBackColor = true;
            BtnRefreshPinDataFromPadData.Click += BtnRefreshPinDataFromPadData_Click;
            // 
            // BtnReadyToApply
            // 
            BtnReadyToApply.BackColor = Color.Red;
            BtnReadyToApply.Location = new Point(93, 158);
            BtnReadyToApply.Name = "BtnReadyToApply";
            BtnReadyToApply.Size = new Size(113, 57);
            BtnReadyToApply.TabIndex = 0;
            BtnReadyToApply.Text = "Ready To Apply";
            BtnReadyToApply.UseVisualStyleBackColor = false;
            BtnReadyToApply.Click += BtnReadyToApply_Click;
            // 
            // BtnRefPinRegistration
            // 
            BtnRefPinRegistration.Location = new Point(93, 34);
            BtnRefPinRegistration.Name = "BtnRefPinRegistration";
            BtnRefPinRegistration.Size = new Size(113, 57);
            BtnRefPinRegistration.TabIndex = 0;
            BtnRefPinRegistration.Text = "Ref Pin Registration";
            BtnRefPinRegistration.UseVisualStyleBackColor = true;
            BtnRefPinRegistration.Click += BtnRefPinRegistration_Click;
            // 
            // BtnAddPinWPad
            // 
            BtnAddPinWPad.Location = new Point(6, 33);
            BtnAddPinWPad.Name = "BtnAddPinWPad";
            BtnAddPinWPad.Size = new Size(81, 57);
            BtnAddPinWPad.TabIndex = 0;
            BtnAddPinWPad.Text = "Add Pin/Pad";
            BtnAddPinWPad.UseVisualStyleBackColor = true;
            BtnAddPinWPad.Click += BtnAddPinWPad_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Location = new Point(3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1080, 1003);
            panel1.TabIndex = 64;
            // 
            // CBShowPins
            // 
            CBShowPins.AutoSize = true;
            CBShowPins.Location = new Point(1089, 143);
            CBShowPins.Name = "CBShowPins";
            CBShowPins.Size = new Size(85, 21);
            CBShowPins.TabIndex = 65;
            CBShowPins.Text = "Show Pins";
            CBShowPins.UseVisualStyleBackColor = true;
            CBShowPins.CheckedChanged += CBShowPins_CheckedChanged;
            // 
            // panelPinMap
            // 
            panelPinMap.BackColor = Color.Black;
            panelPinMap.Location = new Point(1089, 618);
            panelPinMap.Name = "panelPinMap";
            panelPinMap.Size = new Size(399, 387);
            panelPinMap.TabIndex = 65;
            // 
            // NumRefPinOffsetR
            // 
            NumRefPinOffsetR.Location = new Point(1092, 190);
            NumRefPinOffsetR.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            NumRefPinOffsetR.Minimum = new decimal(new int[] { 100000, 0, 0, int.MinValue });
            NumRefPinOffsetR.Name = "NumRefPinOffsetR";
            NumRefPinOffsetR.Size = new Size(89, 23);
            NumRefPinOffsetR.TabIndex = 66;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1089, 170);
            label6.Name = "label6";
            label6.Size = new Size(58, 17);
            label6.TabIndex = 28;
            label6.Text = "PinAngle";
            // 
            // BtnUpdateDegree
            // 
            BtnUpdateDegree.BackColor = Color.Orange;
            BtnUpdateDegree.Location = new Point(1093, 221);
            BtnUpdateDegree.Name = "BtnUpdateDegree";
            BtnUpdateDegree.Size = new Size(88, 48);
            BtnUpdateDegree.TabIndex = 67;
            BtnUpdateDegree.Text = "Update Degree";
            BtnUpdateDegree.UseVisualStyleBackColor = false;
            BtnUpdateDegree.Click += BtnUpdateDegree_Click;
            // 
            // BtnFocusInitial
            // 
            BtnFocusInitial.Location = new Point(1093, 439);
            BtnFocusInitial.Name = "BtnFocusInitial";
            BtnFocusInitial.Size = new Size(88, 54);
            BtnFocusInitial.TabIndex = 25;
            BtnFocusInitial.Text = "Focus Initial";
            BtnFocusInitial.UseVisualStyleBackColor = true;
            BtnFocusInitial.Click += BtnFocusInitial_Click;
            // 
            // BtnOrgPinInitial
            // 
            BtnOrgPinInitial.Enabled = false;
            BtnOrgPinInitial.Location = new Point(1407, 98);
            BtnOrgPinInitial.Name = "BtnOrgPinInitial";
            BtnOrgPinInitial.Size = new Size(99, 54);
            BtnOrgPinInitial.TabIndex = 25;
            BtnOrgPinInitial.Text = "Org Pin Initial";
            BtnOrgPinInitial.UseVisualStyleBackColor = true;
            BtnOrgPinInitial.Click += BtnOrgPinInitial_Click;
            // 
            // BtnPinData
            // 
            BtnPinData.BackColor = Color.Teal;
            BtnPinData.ForeColor = Color.White;
            BtnPinData.Location = new Point(1092, 379);
            BtnPinData.Name = "BtnPinData";
            BtnPinData.Size = new Size(88, 54);
            BtnPinData.TabIndex = 25;
            BtnPinData.Text = "Pin Data";
            BtnPinData.UseVisualStyleBackColor = false;
            BtnPinData.Click += BtnPinData_Click;
            // 
            // panelMag
            // 
            panelMag.BackColor = Color.Black;
            panelMag.Location = new Point(1187, 9);
            panelMag.Name = "panelMag";
            panelMag.Size = new Size(253, 83);
            panelMag.TabIndex = 68;
            // 
            // BtnAdjustAngle
            // 
            BtnAdjustAngle.BackColor = Color.Orange;
            BtnAdjustAngle.Location = new Point(6, 203);
            BtnAdjustAngle.Name = "BtnAdjustAngle";
            BtnAdjustAngle.Size = new Size(99, 54);
            BtnAdjustAngle.TabIndex = 25;
            BtnAdjustAngle.Text = "Adjust Angle";
            BtnAdjustAngle.UseVisualStyleBackColor = false;
            BtnAdjustAngle.Click += BtnAdjustAngle_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(BtnAutoFocusAll);
            groupBox3.Controls.Add(Rbtn4Pins);
            groupBox3.Controls.Add(RbtnAllPins);
            groupBox3.Controls.Add(BtnAdjustAngle);
            groupBox3.Location = new Point(1477, 321);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(111, 263);
            groupBox3.TabIndex = 69;
            groupBox3.TabStop = false;
            groupBox3.Text = "AdjustAngle";
            // 
            // Rbtn4Pins
            // 
            Rbtn4Pins.AutoSize = true;
            Rbtn4Pins.Location = new Point(14, 52);
            Rbtn4Pins.Name = "Rbtn4Pins";
            Rbtn4Pins.Size = new Size(60, 21);
            Rbtn4Pins.TabIndex = 26;
            Rbtn4Pins.TabStop = true;
            Rbtn4Pins.Text = "4 Pins";
            Rbtn4Pins.UseVisualStyleBackColor = true;
            // 
            // RbtnAllPins
            // 
            RbtnAllPins.AutoSize = true;
            RbtnAllPins.Checked = true;
            RbtnAllPins.Location = new Point(14, 25);
            RbtnAllPins.Name = "RbtnAllPins";
            RbtnAllPins.Size = new Size(67, 21);
            RbtnAllPins.TabIndex = 26;
            RbtnAllPins.TabStop = true;
            RbtnAllPins.Text = "All Pins";
            RbtnAllPins.UseVisualStyleBackColor = true;
            // 
            // BtnM_Pin
            // 
            BtnM_Pin.BackColor = Color.Teal;
            BtnM_Pin.ForeColor = Color.White;
            BtnM_Pin.Location = new Point(1093, 321);
            BtnM_Pin.Name = "BtnM_Pin";
            BtnM_Pin.Size = new Size(88, 54);
            BtnM_Pin.TabIndex = 25;
            BtnM_Pin.Text = "m_Pin";
            BtnM_Pin.UseVisualStyleBackColor = false;
            BtnM_Pin.Click += BtnM_Pin_Click;
            // 
            // BtnVisionPara
            // 
            BtnVisionPara.BackColor = Color.Orange;
            BtnVisionPara.Location = new Point(1093, 9);
            BtnVisionPara.Name = "BtnVisionPara";
            BtnVisionPara.Size = new Size(88, 46);
            BtnVisionPara.TabIndex = 70;
            BtnVisionPara.Text = "Vision Para";
            BtnVisionPara.UseVisualStyleBackColor = false;
            BtnVisionPara.Click += BtnVisionPara_Click;
            // 
            // BtnAutoFocusAll
            // 
            BtnAutoFocusAll.Location = new Point(6, 143);
            BtnAutoFocusAll.Name = "BtnAutoFocusAll";
            BtnAutoFocusAll.Size = new Size(99, 54);
            BtnAutoFocusAll.TabIndex = 27;
            BtnAutoFocusAll.Text = "Auto Focus All";
            BtnAutoFocusAll.UseVisualStyleBackColor = true;
            BtnAutoFocusAll.Click += BtnAutoFocusAll_Click;
            // 
            // PinRegistrationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1847, 1126);
            Controls.Add(BtnVisionPara);
            Controls.Add(groupBox3);
            Controls.Add(panelMag);
            Controls.Add(BtnUpdateDegree);
            Controls.Add(NumRefPinOffsetR);
            Controls.Add(panelPinMap);
            Controls.Add(CBShowPins);
            Controls.Add(panel1);
            Controls.Add(BtnOrgPinInitial);
            Controls.Add(BtnM_Pin);
            Controls.Add(BtnPinData);
            Controls.Add(BtnFocusInitial);
            Controls.Add(label6);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "PinRegistrationForm";
            Text = "PinRegistrationForm";
            Load += PinRegistrationForm_Load;
            VisibleChanged += PinRegistrationForm_VisibleChanged;
            ParentChanged += PinRegistrationForm_ParentChanged;
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)NumRefPinOffsetR).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button BtnDeletePinWPad;
        private Button BtnUpdatePinWPad;
        private Button BtnRefreshPinDataFromPadData;
        private Button BtnReadyToApply;
        private Button BtnRefPinRegistration;
        private Button BtnAddPinWPad;
        private Panel panel1;
        private CheckBox CBShowPins;
        private Panel panelPinMap;
        private NumericUpDown NumRefPinOffsetR;
        private Label label6;
        private Button BtnUpdateDegree;
        private Button BtnFocusInitial;
        private Button BtnOrgPinInitial;
        private Button BtnPinData;
        private Panel panelMag;
        private Button BtnAdjustAngle;
        private GroupBox groupBox3;
        private RadioButton Rbtn4Pins;
        private RadioButton RbtnAllPins;
        private Button BtnM_Pin;
        private Button BtnVisionPara;
        private Button BtnAutoFocusAll;
    }
}