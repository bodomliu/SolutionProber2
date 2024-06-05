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
            label5 = new Label();
            label4 = new Label();
            TxtDUT = new TextBox();
            TxtIndex = new TextBox();
            NumIndex = new NumericUpDown();
            label1 = new Label();
            BtnNeedleTipFocus = new Button();
            label2 = new Label();
            BtnPrevFail = new Button();
            BtnNextFail = new Button();
            BtnTeachPin = new Button();
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
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(112, 28);
            label5.Name = "label5";
            label5.Size = new Size(33, 17);
            label5.TabIndex = 36;
            label5.Text = "DUT";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(7, 28);
            label4.Name = "label4";
            label4.Size = new Size(40, 17);
            label4.TabIndex = 37;
            label4.Text = "Index";
            // 
            // TxtDUT
            // 
            TxtDUT.Location = new Point(112, 48);
            TxtDUT.Name = "TxtDUT";
            TxtDUT.ReadOnly = true;
            TxtDUT.Size = new Size(92, 23);
            TxtDUT.TabIndex = 34;
            TxtDUT.Text = "0";
            // 
            // TxtIndex
            // 
            TxtIndex.Location = new Point(7, 48);
            TxtIndex.Name = "TxtIndex";
            TxtIndex.Size = new Size(97, 23);
            TxtIndex.TabIndex = 35;
            TxtIndex.Text = "0";
            // 
            // NumIndex
            // 
            NumIndex.Location = new Point(210, 48);
            NumIndex.Name = "NumIndex";
            NumIndex.Size = new Size(65, 23);
            NumIndex.TabIndex = 38;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(202, 28);
            label1.Name = "label1";
            label1.Size = new Size(73, 17);
            label1.TabIndex = 37;
            label1.Text = "Index Total";
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
            // PinSearchControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            Controls.Add(label2);
            Controls.Add(BtnNeedleTipFocus);
            Controls.Add(NumIndex);
            Controls.Add(label5);
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(TxtDUT);
            Controls.Add(TxtIndex);
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
        private Label label5;
        private Label label4;
        private TextBox TxtDUT;
        private TextBox TxtIndex;
        private NumericUpDown NumIndex;
        private Label label1;
        private Button BtnNeedleTipFocus;
        private Label label2;
        private Button BtnPrevFail;
        private Button BtnNextFail;
        private Button BtnTeachPin;
    }
}
