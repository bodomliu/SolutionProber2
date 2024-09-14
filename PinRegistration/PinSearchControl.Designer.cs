namespace PinRegistration
{
    partial class PinSearchControl
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
            BtnGoToPin = new Button();
            BtnGoToNextPin = new Button();
            BtnGoToRefPin = new Button();
            BtnGoToPrevPin = new Button();
            BtnMovePinToTheCenter = new Button();
            LblDut = new Label();
            LblIndex = new Label();
            NumIndexTotal = new NumericUpDown();
            LblIndexTotal = new Label();
            BtnNeedleTipFocus = new Button();
            label2 = new Label();
            BtnPrevFail = new Button();
            BtnNextFail = new Button();
            BtnTeachPin = new Button();
            NumDut = new NumericUpDown();
            NumIndex = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)NumIndexTotal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumDut).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumIndex).BeginInit();
            SuspendLayout();
            // 
            // BtnGoToPin
            // 
            BtnGoToPin.Location = new Point(210, 77);
            BtnGoToPin.Name = "BtnGoToPin";
            BtnGoToPin.Size = new Size(64, 56);
            BtnGoToPin.TabIndex = 27;
            BtnGoToPin.Text = "Go To Pin #";
            BtnGoToPin.UseVisualStyleBackColor = true;
            BtnGoToPin.Click += BtnGoToPin_Click;
            // 
            // BtnGoToNextPin
            // 
            BtnGoToNextPin.Location = new Point(210, 139);
            BtnGoToNextPin.Name = "BtnGoToNextPin";
            BtnGoToNextPin.Size = new Size(64, 56);
            BtnGoToNextPin.TabIndex = 28;
            BtnGoToNextPin.Text = "Next";
            BtnGoToNextPin.UseVisualStyleBackColor = true;
            BtnGoToNextPin.Click += BtnGoToNextPin_Click;
            // 
            // BtnGoToRefPin
            // 
            BtnGoToRefPin.Location = new Point(7, 77);
            BtnGoToRefPin.Name = "BtnGoToRefPin";
            BtnGoToRefPin.Size = new Size(64, 56);
            BtnGoToRefPin.TabIndex = 29;
            BtnGoToRefPin.Text = "Ref Pin";
            BtnGoToRefPin.UseVisualStyleBackColor = true;
            BtnGoToRefPin.Click += BtnGoToRefPin_Click;
            // 
            // BtnGoToPrevPin
            // 
            BtnGoToPrevPin.Location = new Point(7, 139);
            BtnGoToPrevPin.Name = "BtnGoToPrevPin";
            BtnGoToPrevPin.Size = new Size(64, 56);
            BtnGoToPrevPin.TabIndex = 30;
            BtnGoToPrevPin.Text = "Prev";
            BtnGoToPrevPin.UseVisualStyleBackColor = true;
            BtnGoToPrevPin.Click += BtnGoToPrevPin_Click;
            // 
            // BtnMovePinToTheCenter
            // 
            BtnMovePinToTheCenter.Location = new Point(112, 201);
            BtnMovePinToTheCenter.Name = "BtnMovePinToTheCenter";
            BtnMovePinToTheCenter.Size = new Size(94, 54);
            BtnMovePinToTheCenter.TabIndex = 31;
            BtnMovePinToTheCenter.Text = "Move Pin To The Center";
            BtnMovePinToTheCenter.UseVisualStyleBackColor = true;
            BtnMovePinToTheCenter.Click += BtnMovePinToTheCenter_Click;
            // 
            // LblDut
            // 
            LblDut.AutoSize = true;
            LblDut.Location = new Point(77, 28);
            LblDut.Name = "LblDut";
            LblDut.Size = new Size(33, 17);
            LblDut.TabIndex = 36;
            LblDut.Text = "DUT";
            // 
            // LblIndex
            // 
            LblIndex.AutoSize = true;
            LblIndex.Location = new Point(7, 28);
            LblIndex.Name = "LblIndex";
            LblIndex.Size = new Size(40, 17);
            LblIndex.TabIndex = 37;
            LblIndex.Text = "Index";
            // 
            // NumIndexTotal
            // 
            NumIndexTotal.Location = new Point(151, 48);
            NumIndexTotal.Name = "NumIndexTotal";
            NumIndexTotal.ReadOnly = true;
            NumIndexTotal.Size = new Size(124, 23);
            NumIndexTotal.TabIndex = 38;
            NumIndexTotal.ValueChanged += NumIndex_ValueChanged;
            // 
            // LblIndexTotal
            // 
            LblIndexTotal.AutoSize = true;
            LblIndexTotal.Location = new Point(151, 28);
            LblIndexTotal.Name = "LblIndexTotal";
            LblIndexTotal.Size = new Size(73, 17);
            LblIndexTotal.TabIndex = 37;
            LblIndexTotal.Text = "Index Total";
            // 
            // BtnNeedleTipFocus
            // 
            BtnNeedleTipFocus.Location = new Point(7, 201);
            BtnNeedleTipFocus.Name = "BtnNeedleTipFocus";
            BtnNeedleTipFocus.Size = new Size(99, 54);
            BtnNeedleTipFocus.TabIndex = 39;
            BtnNeedleTipFocus.Text = "Needle Tip Focus";
            BtnNeedleTipFocus.UseVisualStyleBackColor = true;
            BtnNeedleTipFocus.Click += BtnNeedleTipFocus_Click;
            // 
            // label2
            // 
            label2.BackColor = Color.YellowGreen;
            label2.Location = new Point(7, 5);
            label2.Name = "label2";
            label2.Size = new Size(268, 20);
            label2.TabIndex = 40;
            label2.Text = "Pin Search";
            // 
            // BtnPrevFail
            // 
            BtnPrevFail.Location = new Point(75, 139);
            BtnPrevFail.Name = "BtnPrevFail";
            BtnPrevFail.Size = new Size(64, 56);
            BtnPrevFail.TabIndex = 30;
            BtnPrevFail.Text = "Prev Fail";
            BtnPrevFail.UseVisualStyleBackColor = true;
            BtnPrevFail.Click += BtnPrevFail_Click;
            // 
            // BtnNextFail
            // 
            BtnNextFail.Location = new Point(142, 139);
            BtnNextFail.Name = "BtnNextFail";
            BtnNextFail.Size = new Size(64, 56);
            BtnNextFail.TabIndex = 30;
            BtnNextFail.Text = "Next Fail";
            BtnNextFail.UseVisualStyleBackColor = true;
            BtnNextFail.Click += BtnNextFail_Click;
            // 
            // BtnTeachPin
            // 
            BtnTeachPin.BackColor = Color.Orange;
            BtnTeachPin.Location = new Point(210, 201);
            BtnTeachPin.Name = "BtnTeachPin";
            BtnTeachPin.Size = new Size(64, 56);
            BtnTeachPin.TabIndex = 30;
            BtnTeachPin.Text = "Teach Pin";
            BtnTeachPin.UseVisualStyleBackColor = false;
            BtnTeachPin.Click += BtnTeachPin_Click;
            // 
            // NumDut
            // 
            NumDut.Location = new Point(77, 48);
            NumDut.Name = "NumDut";
            NumDut.Size = new Size(68, 23);
            NumDut.TabIndex = 41;
            NumDut.ValueChanged += NumDut_ValueChanged;
            // 
            // NumIndex
            // 
            NumIndex.Location = new Point(7, 48);
            NumIndex.Name = "NumIndex";
            NumIndex.Size = new Size(64, 23);
            NumIndex.TabIndex = 42;
            // 
            // PinSearchControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            Controls.Add(NumIndex);
            Controls.Add(NumDut);
            Controls.Add(label2);
            Controls.Add(BtnNeedleTipFocus);
            Controls.Add(NumIndexTotal);
            Controls.Add(LblDut);
            Controls.Add(LblIndexTotal);
            Controls.Add(LblIndex);
            Controls.Add(BtnMovePinToTheCenter);
            Controls.Add(BtnGoToPin);
            Controls.Add(BtnGoToNextPin);
            Controls.Add(BtnGoToRefPin);
            Controls.Add(BtnTeachPin);
            Controls.Add(BtnNextFail);
            Controls.Add(BtnPrevFail);
            Controls.Add(BtnGoToPrevPin);
            Name = "PinSearchControl";
            Size = new Size(281, 263);
            Load += PinSearchControl_Load;
            VisibleChanged += PinSearchControl_VisibleChanged;
            ((System.ComponentModel.ISupportInitialize)NumIndexTotal).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumDut).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumIndex).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnGoToPin;
        private Button BtnGoToNextPin;
        private Button BtnGoToRefPin;
        private Button BtnGoToPrevPin;
        private Button BtnMovePinToTheCenter;
        private Label LblDut;
        private Label LblIndex;
        private TextBox TxtIndex;
        private NumericUpDown NumIndexTotal;
        private Label LblIndexTotal;
        private Button BtnNeedleTipFocus;
        private Label label2;
        private Button BtnPrevFail;
        private Button BtnNextFail;
        private Button BtnTeachPin;
        private NumericUpDown NumDut;
        private NumericUpDown NumIndex;
    }
}
