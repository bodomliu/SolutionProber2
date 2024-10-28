namespace CommonComponentLibrary
{
    partial class CommonPanel
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
            components = new System.ComponentModel.Container();
            canvas = new Panel();
            TxtIndex = new TextBox();
            txtEncodeR = new TextBox();
            txtEncodeZ = new TextBox();
            txtEncodeY = new TextBox();
            txtEncodeX = new TextBox();
            BtnSetZeroPosition = new Button();
            BtnTogglePosition = new Button();
            BtnDown = new Button();
            BtnRight = new Button();
            BtnLeft = new Button();
            BtnUp = new Button();
            JogFast = new Button();
            JogSlow = new Button();
            BtnJogZup = new Button();
            BtnJogZdown = new Button();
            JogMedium = new Button();
            BtnStep = new Button();
            BtnIndex = new Button();
            BtnScan = new Button();
            LblIsProbingArea = new Label();
            CbCompensation = new CheckBox();
            TimMotion = new System.Windows.Forms.Timer(components);
            BtnMinorAdjustment = new Button();
            canvas.SuspendLayout();
            SuspendLayout();
            // 
            // canvas
            // 
            canvas.BackColor = Color.Black;
            canvas.Controls.Add(TxtIndex);
            canvas.Controls.Add(txtEncodeR);
            canvas.Controls.Add(txtEncodeZ);
            canvas.Controls.Add(txtEncodeY);
            canvas.Controls.Add(txtEncodeX);
            canvas.Location = new Point(60, 50);
            canvas.Name = "canvas";
            canvas.Size = new Size(960, 768);
            canvas.TabIndex = 2;
            // 
            // TxtIndex
            // 
            TxtIndex.Location = new Point(27, 21);
            TxtIndex.Name = "TxtIndex";
            TxtIndex.Size = new Size(100, 23);
            TxtIndex.TabIndex = 1;
            // 
            // txtEncodeR
            // 
            txtEncodeR.Location = new Point(27, 705);
            txtEncodeR.Name = "txtEncodeR";
            txtEncodeR.RightToLeft = RightToLeft.No;
            txtEncodeR.Size = new Size(100, 23);
            txtEncodeR.TabIndex = 0;
            // 
            // txtEncodeZ
            // 
            txtEncodeZ.Location = new Point(27, 675);
            txtEncodeZ.Name = "txtEncodeZ";
            txtEncodeZ.RightToLeft = RightToLeft.No;
            txtEncodeZ.Size = new Size(100, 23);
            txtEncodeZ.TabIndex = 0;
            // 
            // txtEncodeY
            // 
            txtEncodeY.Location = new Point(27, 645);
            txtEncodeY.Name = "txtEncodeY";
            txtEncodeY.RightToLeft = RightToLeft.No;
            txtEncodeY.Size = new Size(100, 23);
            txtEncodeY.TabIndex = 0;
            // 
            // txtEncodeX
            // 
            txtEncodeX.Location = new Point(27, 615);
            txtEncodeX.Name = "txtEncodeX";
            txtEncodeX.RightToLeft = RightToLeft.No;
            txtEncodeX.Size = new Size(100, 23);
            txtEncodeX.TabIndex = 0;
            // 
            // BtnSetZeroPosition
            // 
            BtnSetZeroPosition.Location = new Point(892, 6);
            BtnSetZeroPosition.Name = "BtnSetZeroPosition";
            BtnSetZeroPosition.Size = new Size(125, 38);
            BtnSetZeroPosition.TabIndex = 23;
            BtnSetZeroPosition.Text = "Set Zero Position";
            BtnSetZeroPosition.UseVisualStyleBackColor = true;
            BtnSetZeroPosition.Click += BtnSetZeroPosition_Click;
            // 
            // BtnTogglePosition
            // 
            BtnTogglePosition.Location = new Point(60, 6);
            BtnTogglePosition.Name = "BtnTogglePosition";
            BtnTogglePosition.Size = new Size(157, 38);
            BtnTogglePosition.TabIndex = 22;
            BtnTogglePosition.Text = "Toggle Position (View)";
            BtnTogglePosition.UseVisualStyleBackColor = true;
            BtnTogglePosition.Click += BtnTogglePosition_Click;
            // 
            // BtnDown
            // 
            BtnDown.Location = new Point(472, 825);
            BtnDown.Name = "BtnDown";
            BtnDown.Size = new Size(109, 41);
            BtnDown.TabIndex = 21;
            BtnDown.Text = "Down";
            BtnDown.UseVisualStyleBackColor = true;
            BtnDown.Click += BtnDown_Click;
            BtnDown.MouseDown += BtnDown_MouseDown;
            BtnDown.MouseUp += BtnDown_MouseUp;
            // 
            // BtnRight
            // 
            BtnRight.Location = new Point(1026, 365);
            BtnRight.Name = "BtnRight";
            BtnRight.Size = new Size(47, 104);
            BtnRight.TabIndex = 19;
            BtnRight.Text = "Right";
            BtnRight.UseVisualStyleBackColor = true;
            BtnRight.Click += BtnRight_Click;
            BtnRight.MouseDown += BtnRight_MouseDown;
            BtnRight.MouseUp += BtnRight_MouseUp;
            // 
            // BtnLeft
            // 
            BtnLeft.Location = new Point(3, 365);
            BtnLeft.Name = "BtnLeft";
            BtnLeft.Size = new Size(51, 104);
            BtnLeft.TabIndex = 20;
            BtnLeft.Text = "Left";
            BtnLeft.UseVisualStyleBackColor = true;
            BtnLeft.Click += BtnLeft_Click;
            BtnLeft.MouseDown += BtnLeft_MouseDown;
            BtnLeft.MouseUp += BtnLeft_MouseUp;
            // 
            // BtnUp
            // 
            BtnUp.Location = new Point(479, 6);
            BtnUp.Name = "BtnUp";
            BtnUp.Size = new Size(102, 38);
            BtnUp.TabIndex = 18;
            BtnUp.Text = "Up";
            BtnUp.UseVisualStyleBackColor = true;
            BtnUp.Click += BtnUp_Click;
            BtnUp.MouseDown += BtnUp_MouseDown;
            BtnUp.MouseUp += BtnUp_MouseUp;
            // 
            // JogFast
            // 
            JogFast.Location = new Point(915, 874);
            JogFast.Name = "JogFast";
            JogFast.Size = new Size(80, 40);
            JogFast.TabIndex = 24;
            JogFast.Text = "Fast";
            JogFast.UseVisualStyleBackColor = true;
            JogFast.Click += JogFast_Click;
            // 
            // JogSlow
            // 
            JogSlow.Location = new Point(743, 873);
            JogSlow.Name = "JogSlow";
            JogSlow.Size = new Size(80, 40);
            JogSlow.TabIndex = 25;
            JogSlow.Text = "Slow";
            JogSlow.UseVisualStyleBackColor = true;
            JogSlow.Click += JogSlow_Click;
            // 
            // BtnJogZup
            // 
            BtnJogZup.Location = new Point(69, 829);
            BtnJogZup.Name = "BtnJogZup";
            BtnJogZup.Size = new Size(80, 40);
            BtnJogZup.TabIndex = 24;
            BtnJogZup.Text = "JogZup";
            BtnJogZup.UseVisualStyleBackColor = true;
            BtnJogZup.MouseDown += BtnJogZup_MouseDown;
            BtnJogZup.MouseUp += BtnJogZup_MouseUp;
            // 
            // BtnJogZdown
            // 
            BtnJogZdown.Location = new Point(158, 829);
            BtnJogZdown.Name = "BtnJogZdown";
            BtnJogZdown.Size = new Size(80, 40);
            BtnJogZdown.TabIndex = 24;
            BtnJogZdown.Text = "JogZdown";
            BtnJogZdown.UseVisualStyleBackColor = true;
            BtnJogZdown.MouseDown += BtnJogZdown_MouseDown;
            BtnJogZdown.MouseUp += BtnJogZdown_MouseUp;
            // 
            // JogMedium
            // 
            JogMedium.Location = new Point(829, 873);
            JogMedium.Name = "JogMedium";
            JogMedium.Size = new Size(80, 40);
            JogMedium.TabIndex = 25;
            JogMedium.Text = "Medium";
            JogMedium.UseVisualStyleBackColor = true;
            JogMedium.Click += JogMedium_Click;
            // 
            // BtnStep
            // 
            BtnStep.Location = new Point(69, 873);
            BtnStep.Name = "BtnStep";
            BtnStep.Size = new Size(80, 40);
            BtnStep.TabIndex = 26;
            BtnStep.Text = "Step";
            BtnStep.UseVisualStyleBackColor = true;
            BtnStep.Click += BtnStep_Click;
            // 
            // BtnIndex
            // 
            BtnIndex.Location = new Point(158, 873);
            BtnIndex.Name = "BtnIndex";
            BtnIndex.Size = new Size(80, 40);
            BtnIndex.TabIndex = 26;
            BtnIndex.Text = "Index";
            BtnIndex.UseVisualStyleBackColor = true;
            BtnIndex.Click += BtnIndex_Click;
            // 
            // BtnScan
            // 
            BtnScan.Location = new Point(247, 873);
            BtnScan.Name = "BtnScan";
            BtnScan.Size = new Size(80, 40);
            BtnScan.TabIndex = 26;
            BtnScan.Text = "Scan";
            BtnScan.UseVisualStyleBackColor = true;
            BtnScan.Click += BtnScan_Click;
            // 
            // LblIsProbingArea
            // 
            LblIsProbingArea.AutoSize = true;
            LblIsProbingArea.BackColor = Color.LimeGreen;
            LblIsProbingArea.BorderStyle = BorderStyle.FixedSingle;
            LblIsProbingArea.Location = new Point(247, 851);
            LblIsProbingArea.Name = "LblIsProbingArea";
            LblIsProbingArea.Size = new Size(37, 19);
            LblIsProbingArea.TabIndex = 28;
            LblIsProbingArea.Text = "Area";
            // 
            // CbCompensation
            // 
            CbCompensation.AutoSize = true;
            CbCompensation.Checked = true;
            CbCompensation.CheckState = CheckState.Checked;
            CbCompensation.Location = new Point(247, 827);
            CbCompensation.Name = "CbCompensation";
            CbCompensation.Size = new Size(111, 21);
            CbCompensation.TabIndex = 29;
            CbCompensation.Text = "Compensation";
            CbCompensation.UseVisualStyleBackColor = true;
            // 
            // TimMotion
            // 
            TimMotion.Tick += TimMotion_Tick;
            // 
            // BtnMinorAdjustment
            // 
            BtnMinorAdjustment.Location = new Point(743, 824);
            BtnMinorAdjustment.Name = "BtnMinorAdjustment";
            BtnMinorAdjustment.Size = new Size(252, 45);
            BtnMinorAdjustment.TabIndex = 25;
            BtnMinorAdjustment.Text = "Minor Adjustment";
            BtnMinorAdjustment.UseVisualStyleBackColor = true;
            BtnMinorAdjustment.Click += BtnMinorAdjustment_Click;
            // 
            // CommonPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            Controls.Add(CbCompensation);
            Controls.Add(LblIsProbingArea);
            Controls.Add(BtnScan);
            Controls.Add(BtnIndex);
            Controls.Add(BtnStep);
            Controls.Add(JogMedium);
            Controls.Add(BtnMinorAdjustment);
            Controls.Add(JogSlow);
            Controls.Add(BtnJogZdown);
            Controls.Add(BtnJogZup);
            Controls.Add(BtnSetZeroPosition);
            Controls.Add(BtnTogglePosition);
            Controls.Add(JogFast);
            Controls.Add(BtnDown);
            Controls.Add(BtnRight);
            Controls.Add(BtnLeft);
            Controls.Add(BtnUp);
            Controls.Add(canvas);
            Name = "CommonPanel";
            Size = new Size(1080, 1000);
            Load += UserControl_Load;
            ParentChanged += CommonPanel_ParentChanged;
            canvas.ResumeLayout(false);
            canvas.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel canvas;
        private TextBox txtEncodeR;
        private TextBox txtEncodeZ;
        private TextBox txtEncodeY;
        private TextBox txtEncodeX;
        private Button BtnSetZeroPosition;
        private Button BtnTogglePosition;
        private Button BtnDown;
        private Button BtnRight;
        private Button BtnLeft;
        private Button BtnUp;
        private Button JogFast;
        private Button JogSlow;
        private Button BtnJogZup;
        private Button BtnJogZdown;
        private Button JogMedium;
        private Button BtnStep;
        private Button BtnIndex;
        private Button BtnScan;
        private TextBox TxtIndex;
        private Label LblIsProbingArea;
        private CheckBox CbCompensation;
        private System.Windows.Forms.Timer TimMotion;
        private Button BtnMinorAdjustment;
    }
}
