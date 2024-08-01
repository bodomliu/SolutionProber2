namespace MainForm
{
    partial class ErrorCompensationForm
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
            BtnMapScreen = new Button();
            groupBox1 = new GroupBox();
            RbtnJigCamera = new RadioButton();
            RbtnWaferCamera = new RadioButton();
            GboxIndexControl = new GroupBox();
            panelIndexControl = new Panel();
            BtnWaferAlignment = new Button();
            groupBox3 = new GroupBox();
            RbtnWriteData = new RadioButton();
            RbtnCheckOnly = new RadioButton();
            groupBox4 = new GroupBox();
            RbtnSelective = new RadioButton();
            RbtnCross = new RadioButton();
            RbtnAllMap = new RadioButton();
            groupBox5 = new GroupBox();
            BtnStop = new Button();
            BtnStart = new Button();
            groupBox6 = new GroupBox();
            BtnApply = new Button();
            BtnClear = new Button();
            BtnZ = new Button();
            BtnAdjustWaferHeight = new Button();
            panelMapMini = new Panel();
            BtnMatch = new Button();
            panel1 = new Panel();
            groupBox1.SuspendLayout();
            GboxIndexControl.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox6.SuspendLayout();
            SuspendLayout();
            // 
            // BtnMapScreen
            // 
            BtnMapScreen.BackColor = Color.Teal;
            BtnMapScreen.Location = new Point(1312, 7);
            BtnMapScreen.Name = "BtnMapScreen";
            BtnMapScreen.Size = new Size(159, 158);
            BtnMapScreen.TabIndex = 56;
            BtnMapScreen.Text = "Camera Screen";
            BtnMapScreen.UseVisualStyleBackColor = false;
            BtnMapScreen.Click += BtnMapScreen_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(RbtnJigCamera);
            groupBox1.Controls.Add(RbtnWaferCamera);
            groupBox1.Location = new Point(1312, 171);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(159, 103);
            groupBox1.TabIndex = 58;
            groupBox1.TabStop = false;
            groupBox1.Text = "Change Camera";
            // 
            // RbtnJigCamera
            // 
            RbtnJigCamera.AutoSize = true;
            RbtnJigCamera.Location = new Point(6, 49);
            RbtnJigCamera.Name = "RbtnJigCamera";
            RbtnJigCamera.Size = new Size(91, 21);
            RbtnJigCamera.TabIndex = 1;
            RbtnJigCamera.Text = "Jig Camera";
            RbtnJigCamera.UseVisualStyleBackColor = true;
            // 
            // RbtnWaferCamera
            // 
            RbtnWaferCamera.AutoSize = true;
            RbtnWaferCamera.Location = new Point(6, 22);
            RbtnWaferCamera.Name = "RbtnWaferCamera";
            RbtnWaferCamera.Size = new Size(110, 21);
            RbtnWaferCamera.TabIndex = 0;
            RbtnWaferCamera.Text = "Wafer Camera";
            RbtnWaferCamera.UseVisualStyleBackColor = true;
            RbtnWaferCamera.CheckedChanged += RbtnWaferCamera_CheckedChanged;
            // 
            // GboxIndexControl
            // 
            GboxIndexControl.Controls.Add(panelIndexControl);
            GboxIndexControl.Location = new Point(1099, 7);
            GboxIndexControl.Name = "GboxIndexControl";
            GboxIndexControl.Size = new Size(207, 158);
            GboxIndexControl.TabIndex = 59;
            GboxIndexControl.TabStop = false;
            GboxIndexControl.Text = "Single Die Compensation";
            // 
            // panelIndexControl
            // 
            panelIndexControl.BackColor = Color.Gray;
            panelIndexControl.Location = new Point(6, 22);
            panelIndexControl.Name = "panelIndexControl";
            panelIndexControl.Size = new Size(201, 130);
            panelIndexControl.TabIndex = 0;
            // 
            // BtnWaferAlignment
            // 
            BtnWaferAlignment.Location = new Point(1099, 447);
            BtnWaferAlignment.Name = "BtnWaferAlignment";
            BtnWaferAlignment.Size = new Size(105, 43);
            BtnWaferAlignment.TabIndex = 60;
            BtnWaferAlignment.Text = "Wafer Alignment";
            BtnWaferAlignment.UseVisualStyleBackColor = true;
            BtnWaferAlignment.Click += BtnWaferAlignment_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(RbtnWriteData);
            groupBox3.Controls.Add(RbtnCheckOnly);
            groupBox3.Location = new Point(1312, 287);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(159, 105);
            groupBox3.TabIndex = 61;
            groupBox3.TabStop = false;
            // 
            // RbtnWriteData
            // 
            RbtnWriteData.AutoSize = true;
            RbtnWriteData.Location = new Point(6, 43);
            RbtnWriteData.Name = "RbtnWriteData";
            RbtnWriteData.Size = new Size(88, 21);
            RbtnWriteData.TabIndex = 1;
            RbtnWriteData.TabStop = true;
            RbtnWriteData.Text = "Write Data";
            RbtnWriteData.UseVisualStyleBackColor = true;
            // 
            // RbtnCheckOnly
            // 
            RbtnCheckOnly.AutoSize = true;
            RbtnCheckOnly.Checked = true;
            RbtnCheckOnly.Location = new Point(6, 16);
            RbtnCheckOnly.Name = "RbtnCheckOnly";
            RbtnCheckOnly.Size = new Size(91, 21);
            RbtnCheckOnly.TabIndex = 0;
            RbtnCheckOnly.TabStop = true;
            RbtnCheckOnly.Text = "Check Only";
            RbtnCheckOnly.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(RbtnSelective);
            groupBox4.Controls.Add(RbtnCross);
            groupBox4.Controls.Add(RbtnAllMap);
            groupBox4.Location = new Point(1099, 171);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(207, 103);
            groupBox4.TabIndex = 62;
            groupBox4.TabStop = false;
            groupBox4.Text = "Measurement Mode";
            // 
            // RbtnSelective
            // 
            RbtnSelective.AutoSize = true;
            RbtnSelective.Location = new Point(6, 73);
            RbtnSelective.Name = "RbtnSelective";
            RbtnSelective.Size = new Size(76, 21);
            RbtnSelective.TabIndex = 0;
            RbtnSelective.Text = "Selective";
            RbtnSelective.UseVisualStyleBackColor = true;
            // 
            // RbtnCross
            // 
            RbtnCross.AutoSize = true;
            RbtnCross.Checked = true;
            RbtnCross.Location = new Point(6, 49);
            RbtnCross.Name = "RbtnCross";
            RbtnCross.Size = new Size(59, 21);
            RbtnCross.TabIndex = 0;
            RbtnCross.TabStop = true;
            RbtnCross.Text = "Cross";
            RbtnCross.UseVisualStyleBackColor = true;
            // 
            // RbtnAllMap
            // 
            RbtnAllMap.AutoSize = true;
            RbtnAllMap.Location = new Point(6, 22);
            RbtnAllMap.Name = "RbtnAllMap";
            RbtnAllMap.Size = new Size(71, 21);
            RbtnAllMap.TabIndex = 0;
            RbtnAllMap.Text = "All Map";
            RbtnAllMap.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(BtnStop);
            groupBox5.Controls.Add(BtnStart);
            groupBox5.Location = new Point(1313, 445);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(159, 138);
            groupBox5.TabIndex = 63;
            groupBox5.TabStop = false;
            groupBox5.Text = "Measurement";
            // 
            // BtnStop
            // 
            BtnStop.BackColor = SystemColors.Control;
            BtnStop.Location = new Point(6, 71);
            BtnStop.Name = "BtnStop";
            BtnStop.Size = new Size(147, 41);
            BtnStop.TabIndex = 0;
            BtnStop.Text = "Stop";
            BtnStop.UseVisualStyleBackColor = false;
            BtnStop.Click += BtnStop_Click;
            // 
            // BtnStart
            // 
            BtnStart.BackColor = Color.Orange;
            BtnStart.Location = new Point(6, 24);
            BtnStart.Name = "BtnStart";
            BtnStart.Size = new Size(147, 41);
            BtnStart.TabIndex = 0;
            BtnStart.Text = "Start";
            BtnStart.UseVisualStyleBackColor = false;
            BtnStart.Click += BtnStart_Click;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(BtnApply);
            groupBox6.Controls.Add(BtnClear);
            groupBox6.Location = new Point(1099, 277);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(207, 115);
            groupBox6.TabIndex = 68;
            groupBox6.TabStop = false;
            groupBox6.Text = "Parameters";
            // 
            // BtnApply
            // 
            BtnApply.Location = new Point(11, 70);
            BtnApply.Name = "BtnApply";
            BtnApply.Size = new Size(189, 35);
            BtnApply.TabIndex = 1;
            BtnApply.Text = "Apply";
            BtnApply.UseVisualStyleBackColor = true;
            BtnApply.Click += BtnApply_Click;
            // 
            // BtnClear
            // 
            BtnClear.BackColor = Color.Red;
            BtnClear.Location = new Point(8, 27);
            BtnClear.Name = "BtnClear";
            BtnClear.Size = new Size(192, 37);
            BtnClear.TabIndex = 0;
            BtnClear.Text = "Clear";
            BtnClear.UseVisualStyleBackColor = false;
            BtnClear.Click += BtnClear_Click;
            // 
            // BtnZ
            // 
            BtnZ.BackColor = Color.Red;
            BtnZ.Location = new Point(1313, 398);
            BtnZ.Name = "BtnZ";
            BtnZ.Size = new Size(158, 41);
            BtnZ.TabIndex = 69;
            BtnZ.Text = "Z up";
            BtnZ.UseVisualStyleBackColor = false;
            BtnZ.Click += BtnZ_Click;
            // 
            // BtnAdjustWaferHeight
            // 
            BtnAdjustWaferHeight.Location = new Point(1099, 398);
            BtnAdjustWaferHeight.Name = "BtnAdjustWaferHeight";
            BtnAdjustWaferHeight.Size = new Size(103, 43);
            BtnAdjustWaferHeight.TabIndex = 70;
            BtnAdjustWaferHeight.Text = "Adjust Wafer Height";
            BtnAdjustWaferHeight.UseVisualStyleBackColor = true;
            BtnAdjustWaferHeight.Click += BtnAdjustWaferHeight_Click;
            // 
            // panelMapMini
            // 
            panelMapMini.BackColor = Color.Black;
            panelMapMini.Location = new Point(1099, 589);
            panelMapMini.Name = "panelMapMini";
            panelMapMini.Size = new Size(373, 375);
            panelMapMini.TabIndex = 71;
            // 
            // BtnMatch
            // 
            BtnMatch.Location = new Point(1099, 496);
            BtnMatch.Name = "BtnMatch";
            BtnMatch.Size = new Size(105, 43);
            BtnMatch.TabIndex = 60;
            BtnMatch.Text = "Match_With_Move";
            BtnMatch.UseVisualStyleBackColor = true;
            BtnMatch.Click += BtnMatch_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1077, 960);
            panel1.TabIndex = 73;
            // 
            // ErrorCompensationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1764, 1026);
            Controls.Add(panel1);
            Controls.Add(panelMapMini);
            Controls.Add(BtnAdjustWaferHeight);
            Controls.Add(BtnZ);
            Controls.Add(groupBox6);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(BtnMatch);
            Controls.Add(BtnWaferAlignment);
            Controls.Add(GboxIndexControl);
            Controls.Add(groupBox1);
            Controls.Add(BtnMapScreen);
            Name = "ErrorCompensationForm";
            Text = "ErrorCompensationForm";
            Load += ErrorCompensationForm_Load;
            VisibleChanged += ErrorCompensationForm_VisibleChanged;
            ParentChanged += ErrorCompensationForm_ParentChanged;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            GboxIndexControl.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button BtnMapScreen;
        private GroupBox groupBox1;
        private RadioButton RbtnJigCamera;
        private RadioButton RbtnWaferCamera;
        private GroupBox GboxIndexControl;
        private Button BtnWaferAlignment;
        private GroupBox groupBox3;
        private RadioButton RbtnCheckOnly;
        private GroupBox groupBox4;
        private RadioButton RbtnSelective;
        private RadioButton RbtnCross;
        private RadioButton RbtnAllMap;
        private GroupBox groupBox5;
        private Button BtnStop;
        private Button BtnStart;
        private RadioButton RbtnWriteData;
        private GroupBox groupBox6;
        private Button BtnClear;
        private Button BtnApply;
        private Panel panelIndexControl;
        private Button BtnZ;
        private Button BtnAdjustWaferHeight;
        private Panel panelMapMini;
        private Button BtnMatch;
        private Panel panel1;
    }
}