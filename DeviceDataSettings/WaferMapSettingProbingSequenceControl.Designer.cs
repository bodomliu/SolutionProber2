namespace DeviceDataSettings
{
    partial class WaferMapSettingProbingSequenceControl
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
            Insert = new Button();
            Automatic = new Button();
            DeleteCurrent = new Button();
            DeleteAll = new Button();
            label1 = new Label();
            TotalNum = new TextBox();
            CurrentNum = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // Insert
            // 
            Insert.Location = new Point(19, 128);
            Insert.Name = "Insert";
            Insert.Size = new Size(114, 47);
            Insert.TabIndex = 1;
            Insert.Text = "      Insert       Probe Seq";
            Insert.UseVisualStyleBackColor = true;
            Insert.Click += Insert_Click;
            // 
            // Automatic
            // 
            Automatic.Location = new Point(19, 181);
            Automatic.Name = "Automatic";
            Automatic.Size = new Size(114, 51);
            Automatic.TabIndex = 2;
            Automatic.Text = "Automatic Sequence Maker";
            Automatic.UseVisualStyleBackColor = true;
            Automatic.Click += Automatic_Click;
            // 
            // DeleteCurrent
            // 
            DeleteCurrent.Location = new Point(156, 128);
            DeleteCurrent.Name = "DeleteCurrent";
            DeleteCurrent.Size = new Size(103, 47);
            DeleteCurrent.TabIndex = 3;
            DeleteCurrent.Text = "Delecte Current Seq";
            DeleteCurrent.UseVisualStyleBackColor = true;
            DeleteCurrent.Click += DeleteCurrent_Click;
            // 
            // DeleteAll
            // 
            DeleteAll.Location = new Point(156, 181);
            DeleteAll.Name = "DeleteAll";
            DeleteAll.Size = new Size(103, 51);
            DeleteAll.TabIndex = 4;
            DeleteAll.Text = "Delete All Probe Seq";
            DeleteAll.UseVisualStyleBackColor = true;
            DeleteAll.Click += DeleteAll_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(101, 269);
            label1.Name = "label1";
            label1.Size = new Size(105, 17);
            label1.TabIndex = 5;
            label1.Text = "Total Seq. Num :";
            // 
            // TotalNum
            // 
            TotalNum.Location = new Point(212, 266);
            TotalNum.Name = "TotalNum";
            TotalNum.ReadOnly = true;
            TotalNum.Size = new Size(56, 23);
            TotalNum.TabIndex = 6;
            // 
            // CurrentNum
            // 
            CurrentNum.Location = new Point(142, 43);
            CurrentNum.Name = "CurrentNum";
            CurrentNum.ReadOnly = true;
            CurrentNum.Size = new Size(56, 23);
            CurrentNum.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 46);
            label2.Name = "label2";
            label2.Size = new Size(119, 17);
            label2.TabIndex = 8;
            label2.Text = "Current Seq. Num :";
            // 
            // WaferMapSettingProbingSequenceControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label2);
            Controls.Add(CurrentNum);
            Controls.Add(TotalNum);
            Controls.Add(label1);
            Controls.Add(DeleteAll);
            Controls.Add(DeleteCurrent);
            Controls.Add(Automatic);
            Controls.Add(Insert);
            Name = "WaferMapSettingProbingSequenceControl";
            Size = new Size(283, 350);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button Insert;
        private Button Automatic;
        private Button DeleteCurrent;
        private Button DeleteAll;
        private Label label1;
        private TextBox TotalNum;
        private TextBox CurrentNum;
        private Label label2;
    }
}
