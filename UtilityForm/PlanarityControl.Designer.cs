namespace UtilityForm
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
            panel1 = new Panel();
            panelMap = new Panel();
            CbWaferSize = new ComboBox();
            BtnResetAll = new Button();
            BtnAbort = new Button();
            label1 = new Label();
            panelHeight = new Panel();
            BtnRegHeight = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // btnCheckAllPos
            // 
            btnCheckAllPos.BackColor = Color.Orange;
            btnCheckAllPos.Location = new Point(11, 721);
            btnCheckAllPos.Name = "btnCheckAllPos";
            btnCheckAllPos.Size = new Size(100, 50);
            btnCheckAllPos.TabIndex = 3;
            btnCheckAllPos.Text = "Check All Pos";
            btnCheckAllPos.UseVisualStyleBackColor = false;
            btnCheckAllPos.Click += btnCheckAllPos_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(384, 721);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(54, 50);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(444, 721);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(49, 50);
            btnLoad.TabIndex = 4;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnUpdatePos
            // 
            btnUpdatePos.BackColor = Color.YellowGreen;
            btnUpdatePos.Location = new Point(114, 665);
            btnUpdatePos.Name = "btnUpdatePos";
            btnUpdatePos.Size = new Size(100, 50);
            btnUpdatePos.TabIndex = 10;
            btnUpdatePos.Text = "Reg Postion";
            btnUpdatePos.UseVisualStyleBackColor = false;
            btnUpdatePos.Click += btnUpdatePos_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(RbtnJigCamera);
            groupBox1.Controls.Add(RbtnWaferCamera);
            groupBox1.Location = new Point(272, 43);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(118, 77);
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
            BtnAdjustWaferHeight.Location = new Point(11, 665);
            BtnAdjustWaferHeight.Name = "BtnAdjustWaferHeight";
            BtnAdjustWaferHeight.Size = new Size(100, 50);
            BtnAdjustWaferHeight.TabIndex = 60;
            BtnAdjustWaferHeight.Text = "Adjust Wafer Height";
            BtnAdjustWaferHeight.UseVisualStyleBackColor = false;
            BtnAdjustWaferHeight.Click += BtnAdjustWaferHeight_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(RbtnNoWafer);
            groupBox2.Controls.Add(RbtnWithWafer);
            groupBox2.Location = new Point(395, 43);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(97, 77);
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
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Location = new Point(11, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(255, 85);
            panel1.TabIndex = 67;
            // 
            // panelMap
            // 
            panelMap.BackColor = Color.Black;
            panelMap.Location = new Point(11, 126);
            panelMap.Name = "panelMap";
            panelMap.Size = new Size(481, 211);
            panelMap.TabIndex = 68;
            // 
            // CbWaferSize
            // 
            CbWaferSize.FormattingEnabled = true;
            CbWaferSize.Items.AddRange(new object[] { "6", "8", "12" });
            CbWaferSize.Location = new Point(395, 14);
            CbWaferSize.Name = "CbWaferSize";
            CbWaferSize.Size = new Size(97, 25);
            CbWaferSize.TabIndex = 69;
            CbWaferSize.SelectedIndexChanged += CbWaferSize_SelectedIndexChanged;
            // 
            // BtnResetAll
            // 
            BtnResetAll.Location = new Point(384, 667);
            BtnResetAll.Name = "BtnResetAll";
            BtnResetAll.Size = new Size(109, 50);
            BtnResetAll.TabIndex = 70;
            BtnResetAll.Text = "Reset All";
            BtnResetAll.UseVisualStyleBackColor = true;
            BtnResetAll.Click += BtnResetAll_Click;
            // 
            // BtnAbort
            // 
            BtnAbort.Location = new Point(114, 721);
            BtnAbort.Name = "BtnAbort";
            BtnAbort.Size = new Size(100, 50);
            BtnAbort.TabIndex = 71;
            BtnAbort.Text = "Abort";
            BtnAbort.UseVisualStyleBackColor = true;
            BtnAbort.Click += BtnAbort_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(320, 17);
            label1.Name = "label1";
            label1.Size = new Size(70, 17);
            label1.TabIndex = 72;
            label1.Text = "Wafer Size";
            // 
            // panelHeight
            // 
            panelHeight.BackColor = Color.Black;
            panelHeight.Location = new Point(11, 342);
            panelHeight.Name = "panelHeight";
            panelHeight.Size = new Size(481, 299);
            panelHeight.TabIndex = 68;
            // 
            // BtnRegHeight
            // 
            BtnRegHeight.BackColor = Color.YellowGreen;
            BtnRegHeight.Location = new Point(220, 665);
            BtnRegHeight.Name = "BtnRegHeight";
            BtnRegHeight.Size = new Size(100, 50);
            BtnRegHeight.TabIndex = 10;
            BtnRegHeight.Text = "Reg Height";
            BtnRegHeight.UseVisualStyleBackColor = false;
            BtnRegHeight.Click += BtnRegHeight_Click;
            // 
            // PlanarityControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelHeight);
            Controls.Add(label1);
            Controls.Add(BtnAbort);
            Controls.Add(BtnResetAll);
            Controls.Add(CbWaferSize);
            Controls.Add(panelMap);
            Controls.Add(panel1);
            Controls.Add(groupBox2);
            Controls.Add(BtnAdjustWaferHeight);
            Controls.Add(groupBox1);
            Controls.Add(BtnRegHeight);
            Controls.Add(btnUpdatePos);
            Controls.Add(btnLoad);
            Controls.Add(btnSave);
            Controls.Add(btnCheckAllPos);
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
        private Panel panel1;
        private Panel panelMap;
        private ComboBox CbWaferSize;
        private Button BtnResetAll;
        private Button BtnAbort;
        private Label label1;
        private Panel panelHeight;
        private Button BtnRegHeight;
    }
}
