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
            Button_DeleteAll = new Button();
            label1 = new Label();
            TotalNum = new TextBox();
            CurrentNum = new TextBox();
            label2 = new Label();
            panel1 = new Panel();
            ButtonReorder = new Button();
            SuspendLayout();
            // 
            // Insert
            // 
            Insert.Location = new Point(14, 75);
            Insert.Name = "Insert";
            Insert.Size = new Size(114, 47);
            Insert.TabIndex = 1;
            Insert.Text = "      Insert       Probe Seq";
            Insert.UseVisualStyleBackColor = true;
            Insert.Click += Insert_Click;
            // 
            // Automatic
            // 
            Automatic.Location = new Point(14, 128);
            Automatic.Name = "Automatic";
            Automatic.Size = new Size(114, 51);
            Automatic.TabIndex = 2;
            Automatic.Text = "Automatic Sequence Maker";
            Automatic.UseVisualStyleBackColor = true;
            Automatic.Click += Automatic_Click;
            // 
            // DeleteCurrent
            // 
            DeleteCurrent.Location = new Point(14, 184);
            DeleteCurrent.Name = "DeleteCurrent";
            DeleteCurrent.Size = new Size(114, 43);
            DeleteCurrent.TabIndex = 3;
            DeleteCurrent.Text = "  Delecte   Current Seq";
            DeleteCurrent.UseVisualStyleBackColor = true;
            DeleteCurrent.Click += DeleteCurrent_Click;
            // 
            // Button_DeleteAll
            // 
            Button_DeleteAll.Location = new Point(14, 234);
            Button_DeleteAll.Name = "Button_DeleteAll";
            Button_DeleteAll.Size = new Size(114, 53);
            Button_DeleteAll.TabIndex = 4;
            Button_DeleteAll.Text = "Delete \nAll Probe Seq";
            Button_DeleteAll.UseVisualStyleBackColor = true;
            Button_DeleteAll.Click += DeleteAll_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 10);
            label1.Name = "label1";
            label1.Size = new Size(105, 17);
            label1.TabIndex = 5;
            label1.Text = "Total Seq. Num :";
            // 
            // TotalNum
            // 
            TotalNum.Location = new Point(139, 10);
            TotalNum.Name = "TotalNum";
            TotalNum.ReadOnly = true;
            TotalNum.Size = new Size(56, 23);
            TotalNum.TabIndex = 6;
            // 
            // CurrentNum
            // 
            CurrentNum.Location = new Point(139, 39);
            CurrentNum.Name = "CurrentNum";
            CurrentNum.ReadOnly = true;
            CurrentNum.Size = new Size(56, 23);
            CurrentNum.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 43);
            label2.Name = "label2";
            label2.Size = new Size(119, 17);
            label2.TabIndex = 8;
            label2.Text = "Current Seq. Num :";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Location = new Point(139, 75);
            panel1.Name = "panel1";
            panel1.Size = new Size(141, 272);
            panel1.TabIndex = 9;
            panel1.Paint += panel1_Paint;
            // 
            // ButtonReorder
            // 
            ButtonReorder.Location = new Point(14, 293);
            ButtonReorder.Name = "ButtonReorder";
            ButtonReorder.Size = new Size(114, 53);
            ButtonReorder.TabIndex = 10;
            ButtonReorder.Text = "Reorder";
            ButtonReorder.UseVisualStyleBackColor = true;
            ButtonReorder.Click += ButtonReorder_Click;
            // 
            // WaferMapSettingProbingSequenceControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ButtonReorder);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(CurrentNum);
            Controls.Add(TotalNum);
            Controls.Add(label1);
            Controls.Add(Button_DeleteAll);
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
        private Button Button_DeleteAll;
        private Label label1;
        private TextBox TotalNum;
        private TextBox CurrentNum;
        private Label label2;
        private Panel panel1;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private Button ButtonReorder;
    }
}
