namespace test
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            comboBox1 = new ComboBox();
            BtnSetPart = new Button();
            BtnZHome = new Button();
            BtnAdjustWaferHeight = new Button();
            TxtStart = new TextBox();
            TxtEnd = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            TxtStep = new TextBox();
            TxtExpo = new TextBox();
            BtnSetExpo = new Button();
            BtnSaveImg = new Button();
            button1 = new Button();
            panel2 = new Panel();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1080, 1003);
            panel1.TabIndex = 0;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "WaferLowMag = 0,", "WaferHighMag = 1,", "PinLowMag = 2,", "PinHighMag = 3,", "CassetteCamera = 4,", "PreAlignCamera6 = 5,", "PreAlignCamera12 = 6,", "OCRCamera = 7,", "JigCamera = 8," });
            comboBox1.Location = new Point(1089, 3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 25);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // BtnSetPart
            // 
            BtnSetPart.Location = new Point(1216, 3);
            BtnSetPart.Name = "BtnSetPart";
            BtnSetPart.Size = new Size(75, 23);
            BtnSetPart.TabIndex = 2;
            BtnSetPart.Text = "Set Part";
            BtnSetPart.UseVisualStyleBackColor = true;
            BtnSetPart.Click += BtnSetPart_Click;
            // 
            // BtnZHome
            // 
            BtnZHome.Location = new Point(1089, 275);
            BtnZHome.Name = "BtnZHome";
            BtnZHome.Size = new Size(112, 59);
            BtnZHome.TabIndex = 3;
            BtnZHome.Text = "Z Home";
            BtnZHome.UseVisualStyleBackColor = true;
            BtnZHome.Click += BtnZHome_Click;
            // 
            // BtnAdjustWaferHeight
            // 
            BtnAdjustWaferHeight.Location = new Point(1089, 133);
            BtnAdjustWaferHeight.Name = "BtnAdjustWaferHeight";
            BtnAdjustWaferHeight.Size = new Size(112, 60);
            BtnAdjustWaferHeight.TabIndex = 22;
            BtnAdjustWaferHeight.Text = "Adjust Wafer Height";
            BtnAdjustWaferHeight.UseVisualStyleBackColor = true;
            BtnAdjustWaferHeight.Click += BtnAdjustWaferHeight_Click;
            // 
            // TxtStart
            // 
            TxtStart.Location = new Point(1254, 133);
            TxtStart.Name = "TxtStart";
            TxtStart.Size = new Size(73, 23);
            TxtStart.TabIndex = 23;
            // 
            // TxtEnd
            // 
            TxtEnd.Location = new Point(1254, 162);
            TxtEnd.Name = "TxtEnd";
            TxtEnd.Size = new Size(73, 23);
            TxtEnd.TabIndex = 23;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1207, 136);
            label1.Name = "label1";
            label1.Size = new Size(35, 17);
            label1.TabIndex = 24;
            label1.Text = "Start";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1207, 165);
            label2.Name = "label2";
            label2.Size = new Size(30, 17);
            label2.TabIndex = 24;
            label2.Text = "End";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1207, 197);
            label3.Name = "label3";
            label3.Size = new Size(34, 17);
            label3.TabIndex = 24;
            label3.Text = "Step";
            // 
            // TxtStep
            // 
            TxtStep.Location = new Point(1256, 194);
            TxtStep.Name = "TxtStep";
            TxtStep.Size = new Size(71, 23);
            TxtStep.TabIndex = 25;
            // 
            // TxtExpo
            // 
            TxtExpo.Location = new Point(1089, 34);
            TxtExpo.Name = "TxtExpo";
            TxtExpo.Size = new Size(121, 23);
            TxtExpo.TabIndex = 26;
            // 
            // BtnSetExpo
            // 
            BtnSetExpo.Location = new Point(1216, 34);
            BtnSetExpo.Name = "BtnSetExpo";
            BtnSetExpo.Size = new Size(75, 23);
            BtnSetExpo.TabIndex = 27;
            BtnSetExpo.Text = "Set Expo";
            BtnSetExpo.UseVisualStyleBackColor = true;
            BtnSetExpo.Click += BtnSetExpo_Click;
            // 
            // BtnSaveImg
            // 
            BtnSaveImg.Location = new Point(1216, 63);
            BtnSaveImg.Name = "BtnSaveImg";
            BtnSaveImg.Size = new Size(75, 49);
            BtnSaveImg.TabIndex = 28;
            BtnSaveImg.Text = "Save Image";
            BtnSaveImg.UseVisualStyleBackColor = true;
            BtnSaveImg.Click += BtnSaveImg_Click;
            // 
            // button1
            // 
            button1.Location = new Point(1097, 388);
            button1.Name = "button1";
            button1.Size = new Size(104, 58);
            button1.TabIndex = 29;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel2
            // 
            panel2.Location = new Point(1098, 475);
            panel2.Name = "panel2";
            panel2.Size = new Size(229, 210);
            panel2.TabIndex = 30;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1339, 1035);
            Controls.Add(panel2);
            Controls.Add(button1);
            Controls.Add(BtnSaveImg);
            Controls.Add(BtnSetExpo);
            Controls.Add(TxtExpo);
            Controls.Add(TxtStep);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(TxtEnd);
            Controls.Add(TxtStart);
            Controls.Add(BtnAdjustWaferHeight);
            Controls.Add(BtnZHome);
            Controls.Add(BtnSetPart);
            Controls.Add(comboBox1);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            Activated += Form1_Activated;
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private ComboBox comboBox1;
        private Button BtnSetPart;
        private Button BtnZHome;
        private Button BtnAdjustWaferHeight;
        private TextBox TxtStart;
        private TextBox TxtEnd;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox TxtStep;
        private TextBox TxtExpo;
        private Button BtnSetExpo;
        private Button BtnSaveImg;
        private Button button1;
        private Panel panel2;
    }
}
