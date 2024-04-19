﻿namespace DeviceDataSettings
{
    partial class WaferMapSetting_1
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
            Margin = new Button();
            Generation = new Button();
            panel1 = new Panel();
            SizeY = new TextBox();
            SizeX = new TextBox();
            label5 = new Label();
            label4 = new Label();
            NumX = new TextBox();
            NumY = new TextBox();
            panel1.SuspendLayout();
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
            // Margin
            // 
            Margin.Location = new Point(165, 137);
            Margin.Name = "Margin";
            Margin.Size = new Size(111, 44);
            Margin.TabIndex = 9;
            Margin.Text = "Symmetric Offset && Margin";
            Margin.UseVisualStyleBackColor = true;
            Margin.Click += Margin_Click;
            // 
            // Generation
            // 
            Generation.Location = new Point(165, 187);
            Generation.Name = "Generation";
            Generation.Size = new Size(111, 44);
            Generation.TabIndex = 10;
            Generation.Text = "Auto Map Generation";
            Generation.UseVisualStyleBackColor = true;
            Generation.Click += Generation_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(SizeY);
            panel1.Controls.Add(SizeX);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(15, 137);
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
            NumX.Location = new Point(15, 109);
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
            NumY.Location = new Point(77, 109);
            NumY.Name = "NumY";
            NumY.ReadOnly = true;
            NumY.Size = new Size(46, 28);
            NumY.TabIndex = 13;
            NumY.Text = "50";
            NumY.TextAlign = HorizontalAlignment.Center;
            // 
            // WaferMapSetting_1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(NumY);
            Controls.Add(NumX);
            Controls.Add(panel1);
            Controls.Add(Generation);
            Controls.Add(Margin);
            Controls.Add(Apply);
            Controls.Add(SetRatio);
            Controls.Add(ratioY);
            Controls.Add(ratioX);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(WaferSize);
            Controls.Add(label1);
            Name = "WaferMapSetting_1";
            Size = new Size(283, 270);
            Load += WaferMapSetting_1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
        private Button Margin;
        private Button Generation;
        private Panel panel1;
        private Label label4;
        private Label label5;
        private TextBox SizeY;
        private TextBox SizeX;
        private TextBox NumX;
        private TextBox NumY;
    }
}
