﻿namespace DeviceDataSettings
{
    partial class WaferMapSettingBase
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
            SetRatio = new Button();
            ratioY = new ComboBox();
            ratioX = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            WaferSize = new ComboBox();
            label1 = new Label();
            Apply = new Button();
            panel1 = new Panel();
            SizeY = new TextBox();
            SizeX = new TextBox();
            label5 = new Label();
            label4 = new Label();
            NumX = new TextBox();
            NumY = new TextBox();
            panel2 = new Panel();
            offsetY = new TextBox();
            offsetX = new TextBox();
            label7 = new Label();
            label6 = new Label();
            panel3 = new Panel();
            label8 = new Label();
            label9 = new Label();
            Org2PatIIX = new TextBox();
            Org2PatIIY = new TextBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // SetRatio
            // 
            SetRatio.Location = new Point(239, 9);
            SetRatio.Name = "SetRatio";
            SetRatio.Size = new Size(37, 56);
            SetRatio.TabIndex = 7;
            SetRatio.Text = "Set";
            SetRatio.UseVisualStyleBackColor = true;
            SetRatio.Click += SetRatio_Click;
            // 
            // ratioY
            // 
            ratioY.DropDownStyle = ComboBoxStyle.DropDownList;
            ratioY.FormattingEnabled = true;
            ratioY.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" });
            ratioY.Location = new Point(195, 40);
            ratioY.Name = "ratioY";
            ratioY.Size = new Size(38, 25);
            ratioY.TabIndex = 6;
            // 
            // ratioX
            // 
            ratioX.DropDownStyle = ComboBoxStyle.DropDownList;
            ratioX.FormattingEnabled = true;
            ratioX.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" });
            ratioX.Location = new Point(195, 9);
            ratioX.Name = "ratioX";
            ratioX.Size = new Size(38, 25);
            ratioX.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(144, 41);
            label3.Name = "label3";
            label3.Size = new Size(49, 17);
            label3.TabIndex = 4;
            label3.Text = "Y Ratio";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(143, 12);
            label2.Name = "label2";
            label2.Size = new Size(50, 17);
            label2.TabIndex = 3;
            label2.Text = "X Ratio";
            // 
            // WaferSize
            // 
            WaferSize.DropDownStyle = ComboBoxStyle.DropDownList;
            WaferSize.FormattingEnabled = true;
            WaferSize.Items.AddRange(new object[] { "6", "8", "12" });
            WaferSize.Location = new Point(94, 28);
            WaferSize.Name = "WaferSize";
            WaferSize.Size = new Size(44, 25);
            WaferSize.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 31);
            label1.Name = "label1";
            label1.Size = new Size(73, 17);
            label1.TabIndex = 0;
            label1.Text = "Wafer Size:";
            // 
            // Apply
            // 
            Apply.Location = new Point(165, 87);
            Apply.Name = "Apply";
            Apply.Size = new Size(111, 44);
            Apply.TabIndex = 8;
            Apply.Text = "Apply";
            Apply.UseVisualStyleBackColor = true;
            Apply.Click += Apply_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(SizeY);
            panel1.Controls.Add(SizeX);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(15, 105);
            panel1.Name = "panel1";
            panel1.Size = new Size(113, 62);
            panel1.TabIndex = 11;
            // 
            // SizeY
            // 
            SizeY.Location = new Point(46, 32);
            SizeY.Name = "SizeY";
            SizeY.Size = new Size(52, 23);
            SizeY.TabIndex = 3;
            // 
            // SizeX
            // 
            SizeX.Location = new Point(46, 3);
            SizeX.Name = "SizeX";
            SizeX.Size = new Size(52, 23);
            SizeX.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(2, 35);
            label5.Name = "label5";
            label5.Size = new Size(42, 17);
            label5.TabIndex = 1;
            label5.Text = "Y Size";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1, 6);
            label4.Name = "label4";
            label4.Size = new Size(43, 17);
            label4.TabIndex = 0;
            label4.Text = "X Size";
            // 
            // NumX
            // 
            NumX.BackColor = SystemColors.ScrollBar;
            NumX.Enabled = false;
            NumX.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            NumX.ForeColor = SystemColors.Window;
            NumX.Location = new Point(15, 77);
            NumX.Name = "NumX";
            NumX.ReadOnly = true;
            NumX.Size = new Size(46, 28);
            NumX.TabIndex = 12;
            NumX.Text = "50";
            NumX.TextAlign = HorizontalAlignment.Center;
            // 
            // NumY
            // 
            NumY.BackColor = SystemColors.ScrollBar;
            NumY.Enabled = false;
            NumY.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            NumY.ForeColor = SystemColors.Window;
            NumY.Location = new Point(77, 77);
            NumY.Name = "NumY";
            NumY.ReadOnly = true;
            NumY.Size = new Size(46, 28);
            NumY.TabIndex = 13;
            NumY.Text = "50";
            NumY.TextAlign = HorizontalAlignment.Center;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(offsetY);
            panel2.Controls.Add(offsetX);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label6);
            panel2.Location = new Point(15, 173);
            panel2.Name = "panel2";
            panel2.Size = new Size(261, 82);
            panel2.TabIndex = 14;
            // 
            // offsetY
            // 
            offsetY.Location = new Point(163, 48);
            offsetY.Name = "offsetY";
            offsetY.Size = new Size(91, 23);
            offsetY.TabIndex = 3;
            // 
            // offsetX
            // 
            offsetX.Location = new Point(163, 15);
            offsetX.Name = "offsetX";
            offsetX.Size = new Size(91, 23);
            offsetX.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(3, 51);
            label7.Name = "label7";
            label7.Size = new Size(138, 17);
            label7.TabIndex = 1;
            label7.Text = "Center2RefDieCornerY";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(3, 18);
            label6.Name = "label6";
            label6.Size = new Size(139, 17);
            label6.TabIndex = 0;
            label6.Text = "Center2RefDieCornerX";
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.Fixed3D;
            panel3.Controls.Add(Org2PatIIY);
            panel3.Controls.Add(Org2PatIIX);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(label8);
            panel3.Location = new Point(15, 261);
            panel3.Name = "panel3";
            panel3.Size = new Size(261, 80);
            panel3.TabIndex = 4;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(70, 15);
            label8.Name = "label8";
            label8.Size = new Size(72, 17);
            label8.TabIndex = 0;
            label8.Text = "Org2PatIIX";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(69, 48);
            label9.Name = "label9";
            label9.Size = new Size(71, 17);
            label9.TabIndex = 1;
            label9.Text = "Org2PatIIY";
            // 
            // Org2PatIIX
            // 
            Org2PatIIX.Location = new Point(163, 12);
            Org2PatIIX.Name = "Org2PatIIX";
            Org2PatIIX.Size = new Size(91, 23);
            Org2PatIIX.TabIndex = 2;
            // 
            // Org2PatIIY
            // 
            Org2PatIIY.Location = new Point(163, 45);
            Org2PatIIY.Name = "Org2PatIIY";
            Org2PatIIY.Size = new Size(91, 23);
            Org2PatIIY.TabIndex = 3;
            // 
            // WaferMapSettingBase
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(NumY);
            Controls.Add(NumX);
            Controls.Add(panel1);
            Controls.Add(Apply);
            Controls.Add(SetRatio);
            Controls.Add(ratioY);
            Controls.Add(ratioX);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(WaferSize);
            Controls.Add(label1);
            Name = "WaferMapSettingBase";
            Size = new Size(283, 350);
            Load += WaferMapSettingBaseLoad;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private ComboBox WaferSize;
        private Label label2;
        private Label label3;
        private ComboBox ratioY;
        private ComboBox ratioX;
        private Button SetRatio;

        #endregion

        private Button Apply;
        private Panel panel1;
        private Label label4;
        private Label label5;
        private TextBox SizeY;
        private TextBox SizeX;
        private TextBox NumX;
        private TextBox NumY;
        private Panel panel2;
        private Label label6;
        private Label label7;
        private TextBox offsetY;
        private TextBox offsetX;
        private Panel panel3;
        private Label label9;
        private Label label8;
        private TextBox Org2PatIIY;
        private TextBox Org2PatIIX;
    }
}
