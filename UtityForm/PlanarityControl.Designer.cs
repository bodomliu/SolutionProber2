namespace MainForm
{
    partial class PlanarityControl
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
            btn1 = new Button();
            btn2 = new Button();
            btn3 = new Button();
            btn4 = new Button();
            btn5 = new Button();
            btn6 = new Button();
            btn7 = new Button();
            btn8 = new Button();
            btn9 = new Button();
            btnCheckAllPos = new Button();
            btnSave = new Button();
            btnLoad = new Button();
            btnUpdatePos = new Button();
            groupBox1 = new GroupBox();
            RbtnJigCamera = new RadioButton();
            RbtnWaferCamera = new RadioButton();
            BtnAdjustWaferHeight = new Button();
            groupBox2 = new GroupBox();
            RbtnNoWafer = new RadioButton();
            RbtnWithWafer = new RadioButton();
            Diff1 = new Label();
            Diff2 = new Label();
            Diff3 = new Label();
            Diff4 = new Label();
            Diff5 = new Label();
            Diff6 = new Label();
            Diff7 = new Label();
            Diff8 = new Label();
            Diff9 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            CbWaferSize = new ComboBox();
            BtnResetAll = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // btn1
            // 
            btn1.Location = new Point(314, 193);
            btn1.Name = "btn1";
            btn1.Size = new Size(75, 23);
            btn1.TabIndex = 2;
            btn1.Tag = "1";
            btn1.Text = "0";
            btn1.UseVisualStyleBackColor = true;
            btn1.Click += btnMove_Click;
            // 
            // btn2
            // 
            btn2.Location = new Point(404, 218);
            btn2.Name = "btn2";
            btn2.Size = new Size(75, 23);
            btn2.TabIndex = 2;
            btn2.Tag = "2";
            btn2.Text = "0";
            btn2.UseVisualStyleBackColor = true;
            btn2.Click += btnMove_Click;
            // 
            // btn3
            // 
            btn3.Location = new Point(441, 294);
            btn3.Name = "btn3";
            btn3.Size = new Size(75, 23);
            btn3.TabIndex = 2;
            btn3.Tag = "3";
            btn3.Text = "0";
            btn3.UseVisualStyleBackColor = true;
            btn3.Click += btnMove_Click;
            // 
            // btn4
            // 
            btn4.Location = new Point(380, 350);
            btn4.Name = "btn4";
            btn4.Size = new Size(75, 23);
            btn4.TabIndex = 2;
            btn4.Tag = "4";
            btn4.Text = "0";
            btn4.UseVisualStyleBackColor = true;
            btn4.Click += btnMove_Click;
            // 
            // btn5
            // 
            btn5.Location = new Point(307, 384);
            btn5.Name = "btn5";
            btn5.Size = new Size(75, 23);
            btn5.TabIndex = 2;
            btn5.Tag = "5";
            btn5.Text = "0";
            btn5.UseVisualStyleBackColor = true;
            btn5.Click += btnMove_Click;
            // 
            // btn6
            // 
            btn6.Location = new Point(239, 345);
            btn6.Name = "btn6";
            btn6.Size = new Size(75, 23);
            btn6.TabIndex = 2;
            btn6.Tag = "6";
            btn6.Text = "0";
            btn6.UseVisualStyleBackColor = true;
            btn6.Click += btnMove_Click;
            // 
            // btn7
            // 
            btn7.Location = new Point(191, 294);
            btn7.Name = "btn7";
            btn7.Size = new Size(75, 23);
            btn7.TabIndex = 2;
            btn7.Tag = "7";
            btn7.Text = "0";
            btn7.UseVisualStyleBackColor = true;
            btn7.Click += btnMove_Click;
            // 
            // btn8
            // 
            btn8.Location = new Point(229, 218);
            btn8.Name = "btn8";
            btn8.Size = new Size(75, 23);
            btn8.TabIndex = 2;
            btn8.Tag = "8";
            btn8.Text = "0";
            btn8.UseVisualStyleBackColor = true;
            btn8.Click += btnMove_Click;
            // 
            // btn9
            // 
            btn9.Location = new Point(311, 294);
            btn9.Name = "btn9";
            btn9.Size = new Size(75, 23);
            btn9.TabIndex = 2;
            btn9.Tag = "9";
            btn9.Text = "0";
            btn9.UseVisualStyleBackColor = true;
            btn9.Click += btnMove_Click;
            // 
            // btnCheckAllPos
            // 
            btnCheckAllPos.BackColor = Color.Orange;
            btnCheckAllPos.Location = new Point(214, 864);
            btnCheckAllPos.Name = "btnCheckAllPos";
            btnCheckAllPos.Size = new Size(99, 56);
            btnCheckAllPos.TabIndex = 3;
            btnCheckAllPos.Text = "Check All Pos";
            btnCheckAllPos.UseVisualStyleBackColor = false;
            btnCheckAllPos.Click += btnCheckAllPos_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(385, 859);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(58, 61);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(449, 859);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(59, 61);
            btnLoad.TabIndex = 4;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnUpdatePos
            // 
            btnUpdatePos.BackColor = Color.YellowGreen;
            btnUpdatePos.Location = new Point(118, 864);
            btnUpdatePos.Name = "btnUpdatePos";
            btnUpdatePos.Size = new Size(90, 56);
            btnUpdatePos.TabIndex = 10;
            btnUpdatePos.Text = "Reg Postion";
            btnUpdatePos.UseVisualStyleBackColor = false;
            btnUpdatePos.Click += btnUpdatePos_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(RbtnJigCamera);
            groupBox1.Controls.Add(RbtnWaferCamera);
            groupBox1.Location = new Point(279, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(159, 77);
            groupBox1.TabIndex = 59;
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
            // BtnAdjustWaferHeight
            // 
            BtnAdjustWaferHeight.BackColor = Color.Orange;
            BtnAdjustWaferHeight.Location = new Point(15, 864);
            BtnAdjustWaferHeight.Name = "BtnAdjustWaferHeight";
            BtnAdjustWaferHeight.Size = new Size(97, 56);
            BtnAdjustWaferHeight.TabIndex = 60;
            BtnAdjustWaferHeight.Text = "Adjust Wafer Height";
            BtnAdjustWaferHeight.UseVisualStyleBackColor = false;
            BtnAdjustWaferHeight.Click += BtnAdjustWaferHeight_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(RbtnNoWafer);
            groupBox2.Controls.Add(RbtnWithWafer);
            groupBox2.Location = new Point(286, 95);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(158, 77);
            groupBox2.TabIndex = 61;
            groupBox2.TabStop = false;
            groupBox2.Text = "Mode";
            // 
            // RbtnNoWafer
            // 
            RbtnNoWafer.AutoSize = true;
            RbtnNoWafer.Location = new Point(6, 49);
            RbtnNoWafer.Name = "RbtnNoWafer";
            RbtnNoWafer.Size = new Size(83, 21);
            RbtnNoWafer.TabIndex = 0;
            RbtnNoWafer.TabStop = true;
            RbtnNoWafer.Text = "No Wafer";
            RbtnNoWafer.UseVisualStyleBackColor = true;
            // 
            // RbtnWithWafer
            // 
            RbtnWithWafer.AutoSize = true;
            RbtnWithWafer.Location = new Point(6, 22);
            RbtnWithWafer.Name = "RbtnWithWafer";
            RbtnWithWafer.Size = new Size(91, 21);
            RbtnWithWafer.TabIndex = 0;
            RbtnWithWafer.TabStop = true;
            RbtnWithWafer.Text = "With Wafer";
            RbtnWithWafer.UseVisualStyleBackColor = true;
            // 
            // Diff1
            // 
            Diff1.AutoSize = true;
            Diff1.Location = new Point(330, 219);
            Diff1.Name = "Diff1";
            Diff1.Size = new Size(43, 17);
            Diff1.TabIndex = 66;
            Diff1.Text = "label1";
            // 
            // Diff2
            // 
            Diff2.AutoSize = true;
            Diff2.Location = new Point(426, 244);
            Diff2.Name = "Diff2";
            Diff2.Size = new Size(43, 17);
            Diff2.TabIndex = 66;
            Diff2.Text = "label1";
            // 
            // Diff3
            // 
            Diff3.AutoSize = true;
            Diff3.Location = new Point(441, 320);
            Diff3.Name = "Diff3";
            Diff3.Size = new Size(43, 17);
            Diff3.TabIndex = 66;
            Diff3.Text = "label1";
            // 
            // Diff4
            // 
            Diff4.AutoSize = true;
            Diff4.Location = new Point(402, 373);
            Diff4.Name = "Diff4";
            Diff4.Size = new Size(43, 17);
            Diff4.TabIndex = 66;
            Diff4.Text = "label1";
            // 
            // Diff5
            // 
            Diff5.AutoSize = true;
            Diff5.Location = new Point(327, 410);
            Diff5.Name = "Diff5";
            Diff5.Size = new Size(43, 17);
            Diff5.TabIndex = 66;
            Diff5.Text = "label1";
            // 
            // Diff6
            // 
            Diff6.AutoSize = true;
            Diff6.Location = new Point(259, 371);
            Diff6.Name = "Diff6";
            Diff6.Size = new Size(43, 17);
            Diff6.TabIndex = 66;
            Diff6.Text = "label1";
            // 
            // Diff7
            // 
            Diff7.AutoSize = true;
            Diff7.Location = new Point(205, 320);
            Diff7.Name = "Diff7";
            Diff7.Size = new Size(43, 17);
            Diff7.TabIndex = 66;
            Diff7.Text = "label1";
            // 
            // Diff8
            // 
            Diff8.AutoSize = true;
            Diff8.Location = new Point(239, 244);
            Diff8.Name = "Diff8";
            Diff8.Size = new Size(43, 17);
            Diff8.TabIndex = 66;
            Diff8.Text = "label1";
            // 
            // Diff9
            // 
            Diff9.AutoSize = true;
            Diff9.Location = new Point(326, 320);
            Diff9.Name = "Diff9";
            Diff9.Size = new Size(43, 17);
            Diff9.TabIndex = 66;
            Diff9.Text = "label1";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Location = new Point(11, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(255, 85);
            panel1.TabIndex = 67;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Black;
            panel2.Location = new Point(11, 579);
            panel2.Name = "panel2";
            panel2.Size = new Size(492, 265);
            panel2.TabIndex = 68;
            // 
            // CbWaferSize
            // 
            CbWaferSize.FormattingEnabled = true;
            CbWaferSize.Items.AddRange(new object[] { "6", "8", "12" });
            CbWaferSize.Location = new Point(11, 103);
            CbWaferSize.Name = "CbWaferSize";
            CbWaferSize.Size = new Size(121, 25);
            CbWaferSize.TabIndex = 69;
            CbWaferSize.SelectedIndexChanged += CbWaferSize_SelectedIndexChanged;
            // 
            // BtnResetAll
            // 
            BtnResetAll.Location = new Point(314, 866);
            BtnResetAll.Name = "BtnResetAll";
            BtnResetAll.Size = new Size(65, 54);
            BtnResetAll.TabIndex = 70;
            BtnResetAll.Text = "Reset All";
            BtnResetAll.UseVisualStyleBackColor = true;
            BtnResetAll.Click += BtnResetAll_Click;
            // 
            // PlanarityControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(BtnResetAll);
            Controls.Add(CbWaferSize);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(Diff9);
            Controls.Add(Diff8);
            Controls.Add(Diff7);
            Controls.Add(Diff6);
            Controls.Add(Diff5);
            Controls.Add(Diff4);
            Controls.Add(Diff3);
            Controls.Add(Diff2);
            Controls.Add(Diff1);
            Controls.Add(groupBox2);
            Controls.Add(BtnAdjustWaferHeight);
            Controls.Add(groupBox1);
            Controls.Add(btnUpdatePos);
            Controls.Add(btnLoad);
            Controls.Add(btnSave);
            Controls.Add(btnCheckAllPos);
            Controls.Add(btn9);
            Controls.Add(btn8);
            Controls.Add(btn7);
            Controls.Add(btn6);
            Controls.Add(btn5);
            Controls.Add(btn4);
            Controls.Add(btn3);
            Controls.Add(btn2);
            Controls.Add(btn1);
            Name = "PlanarityControl";
            Size = new Size(530, 959);
            Load += PlanarityControl_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btn1;
        private Button btn2;
        private Button btn3;
        private Button btn4;
        private Button btn5;
        private Button btn6;
        private Button btn7;
        private Button btn8;
        private Button btn9;
        private Button btnCheckAllPos;
        private Button btnSave;
        private Button btnLoad;
        private Button btnUpdatePos;
        private GroupBox groupBox1;
        private RadioButton RbtnJigCamera;
        private RadioButton RbtnWaferCamera;
        private Button BtnAdjustWaferHeight;
        private GroupBox groupBox2;
        private RadioButton RbtnNoWafer;
        private RadioButton RbtnWithWafer;
        private Label Diff1;
        private Label Diff2;
        private Label Diff3;
        private Label Diff4;
        private Label Diff5;
        private Label Diff6;
        private Label Diff7;
        private Label Diff8;
        private Label Diff9;
        private Panel panel1;
        private Panel panel2;
        private ComboBox CbWaferSize;
        private Button BtnResetAll;
    }
}
