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
            comboBox1.Items.AddRange(new object[] { "WaferLowMag = 0,", "WaferHighMag = 1,", "PinLowMag = 2,", "PinHighMag = 3,", "CassetteCamera = 4,", "PreAlignCamera6 = 5,", "PreAlignCamera12 = 6,", "OCRCamera = 7," });
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1339, 1035);
            Controls.Add(BtnSetPart);
            Controls.Add(comboBox1);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private ComboBox comboBox1;
        private Button BtnSetPart;
    }
}
