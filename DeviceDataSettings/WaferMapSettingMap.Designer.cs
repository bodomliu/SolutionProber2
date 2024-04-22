namespace DeviceDataSettings
{
    partial class WaferMapSettingMap
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
            radioButton4 = new RadioButton();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            generationButton = new Button();
            label1 = new Label();
            testDieNum = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(radioButton4);
            panel1.Controls.Add(radioButton3);
            panel1.Controls.Add(radioButton2);
            panel1.Controls.Add(radioButton1);
            panel1.Location = new Point(25, 43);
            panel1.Name = "panel1";
            panel1.Size = new Size(116, 128);
            panel1.TabIndex = 0;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Location = new Point(7, 92);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(86, 21);
            radioButton4.TabIndex = 3;
            radioButton4.TabStop = true;
            radioButton4.Text = "MARK DIE";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(7, 65);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(76, 21);
            radioButton3.TabIndex = 2;
            radioButton3.TabStop = true;
            radioButton3.Text = "SKIP DIE";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(7, 38);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(78, 21);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "TEST DIE";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(7, 11);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(90, 21);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "NOT EXIST";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // generationButton
            // 
            generationButton.Location = new Point(147, 43);
            generationButton.Name = "generationButton";
            generationButton.Size = new Size(118, 51);
            generationButton.TabIndex = 1;
            generationButton.Text = "Auto Map Generation";
            generationButton.UseVisualStyleBackColor = true;
            generationButton.Click += generationButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 206);
            label1.Name = "label1";
            label1.Size = new Size(127, 17);
            label1.TabIndex = 2;
            label1.Text = "Total Test Die Num :";
            // 
            // testDieNum
            // 
            testDieNum.Location = new Point(160, 203);
            testDieNum.Name = "testDieNum";
            testDieNum.ReadOnly = true;
            testDieNum.Size = new Size(76, 23);
            testDieNum.TabIndex = 3;
            testDieNum.Text = "0";
            testDieNum.TextAlign = HorizontalAlignment.Center;
            // 
            // WaferMapSettingMap
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(testDieNum);
            Controls.Add(label1);
            Controls.Add(generationButton);
            Controls.Add(panel1);
            Name = "WaferMapSettingMap";
            Size = new Size(283, 270);
            Load += WaferMapSettingMap_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private RadioButton radioButton4;
        private Button generationButton;
        private Label label1;
        private TextBox testDieNum;
    }
}
