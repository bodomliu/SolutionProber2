namespace CommonComponentLibrary
{
    partial class VisionControl
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
            BtnSaveImg = new Button();
            BtnSetExpo = new Button();
            TxtExpo = new TextBox();
            BtnSetPart = new Button();
            comboBox1 = new ComboBox();
            SuspendLayout();
            // 
            // BtnSaveImg
            // 
            BtnSaveImg.Location = new Point(130, 63);
            BtnSaveImg.Name = "BtnSaveImg";
            BtnSaveImg.Size = new Size(75, 49);
            BtnSaveImg.TabIndex = 33;
            BtnSaveImg.Text = "Save Image";
            BtnSaveImg.UseVisualStyleBackColor = true;
            BtnSaveImg.Click += BtnSaveImg_Click;
            // 
            // BtnSetExpo
            // 
            BtnSetExpo.Location = new Point(130, 34);
            BtnSetExpo.Name = "BtnSetExpo";
            BtnSetExpo.Size = new Size(75, 23);
            BtnSetExpo.TabIndex = 32;
            BtnSetExpo.Text = "Set Expo";
            BtnSetExpo.UseVisualStyleBackColor = true;
            BtnSetExpo.Click += BtnSetExpo_Click;
            // 
            // TxtExpo
            // 
            TxtExpo.Location = new Point(3, 34);
            TxtExpo.Name = "TxtExpo";
            TxtExpo.Size = new Size(121, 23);
            TxtExpo.TabIndex = 31;
            // 
            // BtnSetPart
            // 
            BtnSetPart.Location = new Point(130, 3);
            BtnSetPart.Name = "BtnSetPart";
            BtnSetPart.Size = new Size(75, 23);
            BtnSetPart.TabIndex = 30;
            BtnSetPart.Text = "Set Part";
            BtnSetPart.UseVisualStyleBackColor = true;
            BtnSetPart.Click += BtnSetPart_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "WaferLowMag = 0,", "WaferHighMag = 1,", "PinLowMag = 2,", "PinHighMag = 3,", "CassetteCamera = 4,", "PreAlignCamera6 = 5,", "PreAlignCamera12 = 6,", "OCRCamera = 7,", "JigCamera = 8," });
            comboBox1.Location = new Point(3, 3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 25);
            comboBox1.TabIndex = 29;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // VisionControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(BtnSaveImg);
            Controls.Add(BtnSetExpo);
            Controls.Add(TxtExpo);
            Controls.Add(BtnSetPart);
            Controls.Add(comboBox1);
            Name = "VisionControl";
            Size = new Size(212, 453);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnSaveImg;
        private Button BtnSetExpo;
        private TextBox TxtExpo;
        private Button BtnSetPart;
        private ComboBox comboBox1;
    }
}
