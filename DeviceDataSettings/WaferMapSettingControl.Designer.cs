namespace DeviceDataSettings
{
    partial class WaferMapSettingControl
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
            panel1 = new Panel();
            radioButton7 = new RadioButton();
            radioButton6 = new RadioButton();
            radioButton5 = new RadioButton();
            radioButton4 = new RadioButton();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(radioButton7);
            panel1.Controls.Add(radioButton6);
            panel1.Controls.Add(radioButton5);
            panel1.Controls.Add(radioButton4);
            panel1.Controls.Add(radioButton3);
            panel1.Controls.Add(radioButton2);
            panel1.Controls.Add(radioButton1);
            panel1.ForeColor = SystemColors.Control;
            panel1.Location = new Point(402, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(283, 218);
            panel1.TabIndex = 0;
            // 
            // radioButton7
            // 
            radioButton7.AutoSize = true;
            radioButton7.Location = new Point(3, 175);
            radioButton7.Name = "radioButton7";
            radioButton7.Size = new Size(98, 21);
            radioButton7.TabIndex = 6;
            radioButton7.TabStop = true;
            radioButton7.Text = "7. Die Status";
            radioButton7.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            radioButton6.AutoSize = true;
            radioButton6.Location = new Point(3, 148);
            radioButton6.Name = "radioButton6";
            radioButton6.Size = new Size(146, 21);
            radioButton6.TabIndex = 5;
            radioButton6.TabStop = true;
            radioButton6.Text = "6. Probing Sequence";
            radioButton6.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            radioButton5.AutoSize = true;
            radioButton5.Location = new Point(3, 121);
            radioButton5.Name = "radioButton5";
            radioButton5.Size = new Size(131, 21);
            radioButton5.TabIndex = 4;
            radioButton5.TabStop = true;
            radioButton5.Text = "5. Dut information";
            radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Location = new Point(3, 94);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(67, 21);
            radioButton4.TabIndex = 3;
            radioButton4.TabStop = true;
            radioButton4.Text = "4. Map";
            radioButton4.UseVisualStyleBackColor = true;
            radioButton4.CheckedChanged += radioButton4_CheckedChanged;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(3, 67);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(105, 21);
            radioButton3.TabIndex = 2;
            radioButton3.TabStop = true;
            radioButton3.Text = "3. Coordinate";
            radioButton3.UseVisualStyleBackColor = true;
            radioButton3.CheckedChanged += radioButton3_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.BackColor = SystemColors.ControlDark;
            radioButton2.Location = new Point(3, 40);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(113, 21);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "2. Map Margin";
            radioButton2.UseVisualStyleBackColor = false;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.ForeColor = SystemColors.Control;
            radioButton1.Location = new Point(3, 13);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(152, 21);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "1. Wafer && Index Size";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Location = new Point(402, 227);
            panel2.Name = "panel2";
            panel2.Size = new Size(283, 270);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
            // 
            // panel3
            // 
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(393, 393);
            panel3.TabIndex = 2;
            panel3.Paint += panel3_Paint;
            // 
            // panel4
            // 
            panel4.Location = new Point(191, 402);
            panel4.Name = "panel4";
            panel4.Size = new Size(205, 132);
            panel4.TabIndex = 3;
            panel4.Paint += panel4_Paint;
            // 
            // panel5
            // 
            panel5.Location = new Point(3, 402);
            panel5.Name = "panel5";
            panel5.Size = new Size(182, 157);
            panel5.TabIndex = 4;
            panel5.Paint += panel5_Paint;
            // 
            // WaferMapSettingControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "WaferMapSettingControl";
            Size = new Size(688, 562);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton7;
        private RadioButton radioButton6;
        private RadioButton radioButton5;
        private RadioButton radioButton4;
        private RadioButton radioButton3;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
    }
}
