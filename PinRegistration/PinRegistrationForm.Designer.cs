namespace MainForm
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
            BtnLowMag = new Button();
            BtnHighMag = new Button();
            BtnNeedleTipFocus = new Button();
            BtnMovePinToTheCenter = new Button();
            groupBox1 = new GroupBox();
            TxtIndex = new TextBox();
            BtnGoToPin = new Button();
            button2 = new Button();
            BtnGoToRefPin = new Button();
            button1 = new Button();
            groupBox2 = new GroupBox();
            BtnDeletePinWPad = new Button();
            BtnUpdatePinWPad = new Button();
            BtnRefreshPinDataFromPadData = new Button();
            BtnReadyToApply = new Button();
            BtnRefPinRegistration = new Button();
            BtnAddPinWPad = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            LblPinOffsetX = new Label();
            LblPinOffsetY = new Label();
            LblPinOffsetZ = new Label();
            panel1 = new Panel();
            CBShowPins = new CheckBox();
            panel2 = new Panel();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // BtnLowMag
            // 
            BtnLowMag.BackColor = Color.Teal;
            BtnLowMag.Location = new Point(1335, 2);
            BtnLowMag.Name = "BtnLowMag";
            BtnLowMag.Size = new Size(100, 65);
            BtnLowMag.TabIndex = 23;
            BtnLowMag.Text = "LowMag";
            BtnLowMag.UseVisualStyleBackColor = false;
            BtnLowMag.Click += BtnLowMag_Click;
            // 
            // BtnHighMag
            // 
            BtnHighMag.BackColor = Color.Teal;
            BtnHighMag.Location = new Point(1223, 2);
            BtnHighMag.Name = "BtnHighMag";
            BtnHighMag.Size = new Size(106, 65);
            BtnHighMag.TabIndex = 24;
            BtnHighMag.Text = "HighMag";
            BtnHighMag.UseVisualStyleBackColor = false;
            BtnHighMag.Click += BtnHighMag_Click;
            // 
            // BtnNeedleTipFocus
            // 
            BtnNeedleTipFocus.Location = new Point(7, 146);
            BtnNeedleTipFocus.Name = "BtnNeedleTipFocus";
            BtnNeedleTipFocus.Size = new Size(99, 54);
            BtnNeedleTipFocus.TabIndex = 25;
            BtnNeedleTipFocus.Text = "Needle Tip Focus";
            BtnNeedleTipFocus.UseVisualStyleBackColor = true;
            BtnNeedleTipFocus.Click += BtnNeedleTipFocus_Click;
            // 
            // BtnMovePinToTheCenter
            // 
            BtnMovePinToTheCenter.Location = new Point(1335, 442);
            BtnMovePinToTheCenter.Name = "BtnMovePinToTheCenter";
            BtnMovePinToTheCenter.Size = new Size(94, 54);
            BtnMovePinToTheCenter.TabIndex = 25;
            BtnMovePinToTheCenter.Text = "Move Pin To The Center";
            BtnMovePinToTheCenter.UseVisualStyleBackColor = true;
            BtnMovePinToTheCenter.Click += BtnMovePinToTheCenter_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(TxtIndex);
            groupBox1.Controls.Add(BtnGoToPin);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(BtnGoToRefPin);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(BtnNeedleTipFocus);
            groupBox1.Location = new Point(1223, 296);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(212, 209);
            groupBox1.TabIndex = 26;
            groupBox1.TabStop = false;
            groupBox1.Text = "Pin Search";
            // 
            // TxtIndex
            // 
            TxtIndex.Location = new Point(76, 101);
            TxtIndex.Name = "TxtIndex";
            TxtIndex.Size = new Size(62, 23);
            TxtIndex.TabIndex = 27;
            TxtIndex.Text = "0";
            // 
            // BtnGoToPin
            // 
            BtnGoToPin.Location = new Point(6, 84);
            BtnGoToPin.Name = "BtnGoToPin";
            BtnGoToPin.Size = new Size(64, 56);
            BtnGoToPin.TabIndex = 26;
            BtnGoToPin.Text = "Go To Pin #";
            BtnGoToPin.UseVisualStyleBackColor = true;
            BtnGoToPin.Click += BtnGoToPin_Click;
            // 
            // button2
            // 
            button2.Location = new Point(142, 22);
            button2.Name = "button2";
            button2.Size = new Size(64, 56);
            button2.TabIndex = 26;
            button2.Text = "Next Pin";
            button2.UseVisualStyleBackColor = true;
            // 
            // BtnGoToRefPin
            // 
            BtnGoToRefPin.Location = new Point(74, 22);
            BtnGoToRefPin.Name = "BtnGoToRefPin";
            BtnGoToRefPin.Size = new Size(62, 56);
            BtnGoToRefPin.TabIndex = 26;
            BtnGoToRefPin.Text = "Ref Pin";
            BtnGoToRefPin.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(6, 22);
            button1.Name = "button1";
            button1.Size = new Size(62, 56);
            button1.TabIndex = 26;
            button1.Text = "Prev Pin";
            button1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(BtnDeletePinWPad);
            groupBox2.Controls.Add(BtnUpdatePinWPad);
            groupBox2.Controls.Add(BtnRefreshPinDataFromPadData);
            groupBox2.Controls.Add(BtnReadyToApply);
            groupBox2.Controls.Add(BtnRefPinRegistration);
            groupBox2.Controls.Add(BtnAddPinWPad);
            groupBox2.Location = new Point(1223, 73);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(212, 217);
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
            BtnDeletePinWPad.Text = "Delete Pin WPad";
            BtnDeletePinWPad.UseVisualStyleBackColor = true;
            BtnDeletePinWPad.Click += BtnDeletePinWPad_Click;
            // 
            // BtnUpdatePinWPad
            // 
            BtnUpdatePinWPad.Location = new Point(7, 97);
            BtnUpdatePinWPad.Name = "BtnUpdatePinWPad";
            BtnUpdatePinWPad.Size = new Size(80, 57);
            BtnUpdatePinWPad.TabIndex = 0;
            BtnUpdatePinWPad.Text = "Update Pin WPad";
            BtnUpdatePinWPad.UseVisualStyleBackColor = true;
            // 
            // BtnRefreshPinDataFromPadData
            // 
            BtnRefreshPinDataFromPadData.Location = new Point(93, 158);
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
            BtnReadyToApply.Location = new Point(93, 97);
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
            BtnAddPinWPad.Text = "Add Pin WPad";
            BtnAddPinWPad.UseVisualStyleBackColor = true;
            BtnAddPinWPad.Click += BtnAddPinWPad_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1089, 9);
            label1.Name = "label1";
            label1.Size = new Size(71, 17);
            label1.TabIndex = 28;
            label1.Text = "PinOffsetX:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1089, 48);
            label2.Name = "label2";
            label2.Size = new Size(70, 17);
            label2.TabIndex = 28;
            label2.Text = "PinOffsetY:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1089, 88);
            label3.Name = "label3";
            label3.Size = new Size(70, 17);
            label3.TabIndex = 28;
            label3.Text = "PinOffsetZ:";
            // 
            // LblPinOffsetX
            // 
            LblPinOffsetX.AutoSize = true;
            LblPinOffsetX.Location = new Point(1166, 9);
            LblPinOffsetX.Name = "LblPinOffsetX";
            LblPinOffsetX.Size = new Size(15, 17);
            LblPinOffsetX.TabIndex = 28;
            LblPinOffsetX.Text = "0";
            // 
            // LblPinOffsetY
            // 
            LblPinOffsetY.AutoSize = true;
            LblPinOffsetY.Location = new Point(1166, 48);
            LblPinOffsetY.Name = "LblPinOffsetY";
            LblPinOffsetY.Size = new Size(15, 17);
            LblPinOffsetY.TabIndex = 28;
            LblPinOffsetY.Text = "0";
            // 
            // LblPinOffsetZ
            // 
            LblPinOffsetZ.AutoSize = true;
            LblPinOffsetZ.Location = new Point(1166, 88);
            LblPinOffsetZ.Name = "LblPinOffsetZ";
            LblPinOffsetZ.Size = new Size(15, 17);
            LblPinOffsetZ.TabIndex = 28;
            LblPinOffsetZ.Text = "0";
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
            CBShowPins.Location = new Point(1089, 125);
            CBShowPins.Name = "CBShowPins";
            CBShowPins.Size = new Size(85, 21);
            CBShowPins.TabIndex = 65;
            CBShowPins.Text = "Show Pins";
            CBShowPins.UseVisualStyleBackColor = true;
            CBShowPins.CheckedChanged += CBShowPins_CheckedChanged;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Black;
            panel2.Location = new Point(1089, 511);
            panel2.Name = "panel2";
            panel2.Size = new Size(399, 387);
            panel2.TabIndex = 65;
            // 
            // PinRegistrationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1847, 1126);
            Controls.Add(panel2);
            Controls.Add(CBShowPins);
            Controls.Add(panel1);
            Controls.Add(LblPinOffsetZ);
            Controls.Add(LblPinOffsetY);
            Controls.Add(LblPinOffsetX);
            Controls.Add(label3);
            Controls.Add(BtnMovePinToTheCenter);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(BtnLowMag);
            Controls.Add(BtnHighMag);
            Name = "PinRegistrationForm";
            Text = "PinRegistrationForm";
            Load += PinRegistrationForm_Load;
            ParentChanged += PinRegistrationForm_ParentChanged;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnLowMag;
        private Button BtnHighMag;
        private Button BtnNeedleTipFocus;
        private Button BtnMovePinToTheCenter;
        private GroupBox groupBox1;
        private Button button2;
        private Button button1;
        private Button BtnGoToPin;
        private TextBox TxtIndex;
        private GroupBox groupBox2;
        private Button BtnDeletePinWPad;
        private Button BtnUpdatePinWPad;
        private Button BtnRefreshPinDataFromPadData;
        private Button BtnReadyToApply;
        private Button BtnRefPinRegistration;
        private Button BtnAddPinWPad;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label LblPinOffsetX;
        private Label LblPinOffsetY;
        private Label LblPinOffsetZ;
        private Panel panel1;
        private CheckBox CBShowPins;
        private Button BtnGoToRefPin;
        private Panel panel2;
    }
}