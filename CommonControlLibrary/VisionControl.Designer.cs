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
            BtnCreateModel = new Button();
            BtnMatch = new Button();
            BtnClearAll = new Button();
            button1 = new Button();
            BtnGenCalibration = new Button();
            dataGridView1 = new DataGridView();
            BtnReloadCalibration = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // BtnSaveImg
            // 
            BtnSaveImg.Location = new Point(130, 61);
            BtnSaveImg.Name = "BtnSaveImg";
            BtnSaveImg.Size = new Size(92, 49);
            BtnSaveImg.TabIndex = 33;
            BtnSaveImg.Text = "Save Image";
            BtnSaveImg.UseVisualStyleBackColor = true;
            BtnSaveImg.Click += BtnSaveImg_Click;
            // 
            // BtnSetExpo
            // 
            BtnSetExpo.Location = new Point(130, 32);
            BtnSetExpo.Name = "BtnSetExpo";
            BtnSetExpo.Size = new Size(92, 23);
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
            BtnSetPart.Size = new Size(92, 23);
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
            // BtnCreateModel
            // 
            BtnCreateModel.Location = new Point(130, 116);
            BtnCreateModel.Name = "BtnCreateModel";
            BtnCreateModel.Size = new Size(92, 50);
            BtnCreateModel.TabIndex = 34;
            BtnCreateModel.Text = "Create Model";
            BtnCreateModel.UseVisualStyleBackColor = true;
            BtnCreateModel.Click += BtnCreateModel_Click;
            // 
            // BtnMatch
            // 
            BtnMatch.Location = new Point(231, 176);
            BtnMatch.Name = "BtnMatch";
            BtnMatch.Size = new Size(92, 50);
            BtnMatch.TabIndex = 35;
            BtnMatch.Text = "Match";
            BtnMatch.UseVisualStyleBackColor = true;
            BtnMatch.Click += BtnMatch_Click;
            // 
            // BtnClearAll
            // 
            BtnClearAll.Location = new Point(231, 288);
            BtnClearAll.Name = "BtnClearAll";
            BtnClearAll.Size = new Size(92, 50);
            BtnClearAll.TabIndex = 35;
            BtnClearAll.Text = "Clear All";
            BtnClearAll.UseVisualStyleBackColor = true;
            BtnClearAll.Click += BtnClearAll_Click;
            // 
            // button1
            // 
            button1.Location = new Point(231, 232);
            button1.Name = "button1";
            button1.Size = new Size(92, 50);
            button1.TabIndex = 35;
            button1.Text = "Clear";
            button1.UseVisualStyleBackColor = true;
            button1.Click += BtnClear_Click;
            // 
            // BtnGenCalibration
            // 
            BtnGenCalibration.Location = new Point(231, 344);
            BtnGenCalibration.Name = "BtnGenCalibration";
            BtnGenCalibration.Size = new Size(92, 50);
            BtnGenCalibration.TabIndex = 35;
            BtnGenCalibration.Text = "Gen Calibration";
            BtnGenCalibration.UseVisualStyleBackColor = true;
            BtnGenCalibration.Click += BtnGenCalibration_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(4, 176);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(219, 218);
            dataGridView1.TabIndex = 37;
            // 
            // BtnReloadCalibration
            // 
            BtnReloadCalibration.Location = new Point(231, 400);
            BtnReloadCalibration.Name = "BtnReloadCalibration";
            BtnReloadCalibration.Size = new Size(92, 47);
            BtnReloadCalibration.TabIndex = 38;
            BtnReloadCalibration.Text = "Reload Calibration";
            BtnReloadCalibration.UseVisualStyleBackColor = true;
            BtnReloadCalibration.Click += BtnReloadCalibration_Click;
            // 
            // VisionControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            Controls.Add(BtnReloadCalibration);
            Controls.Add(dataGridView1);
            Controls.Add(BtnGenCalibration);
            Controls.Add(button1);
            Controls.Add(BtnClearAll);
            Controls.Add(BtnMatch);
            Controls.Add(BtnCreateModel);
            Controls.Add(BtnSaveImg);
            Controls.Add(BtnSetExpo);
            Controls.Add(TxtExpo);
            Controls.Add(BtnSetPart);
            Controls.Add(comboBox1);
            Name = "VisionControl";
            Size = new Size(330, 565);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnSaveImg;
        private Button BtnSetExpo;
        private TextBox TxtExpo;
        private Button BtnSetPart;
        private ComboBox comboBox1;
        private Button BtnCreateModel;
        private Button BtnMatch;
        private Button BtnClearAll;
        private Button button1;
        private Button BtnGenCalibration;
        private DataGridView dataGridView1;
        private Button BtnReloadCalibration;
    }
}
