namespace MainForm
{
    partial class LotProcessForm
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
            panelMenu = new Panel();
            BtnCassette = new Button();
            BtnSequenceControl = new Button();
            BtnVision = new Button();
            BtnOCR = new Button();
            BtnSetting = new Button();
            BtnMap = new Button();
            panelForm = new Panel();
            panelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.Controls.Add(BtnCassette);
            panelMenu.Controls.Add(BtnSequenceControl);
            panelMenu.Controls.Add(BtnVision);
            panelMenu.Controls.Add(BtnOCR);
            panelMenu.Controls.Add(BtnSetting);
            panelMenu.Controls.Add(BtnMap);
            panelMenu.Dock = DockStyle.Top;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(800, 100);
            panelMenu.TabIndex = 0;
            // 
            // BtnCassette
            // 
            BtnCassette.Location = new Point(12, 12);
            BtnCassette.Name = "BtnCassette";
            BtnCassette.Size = new Size(110, 56);
            BtnCassette.TabIndex = 0;
            BtnCassette.Text = "Cassette";
            BtnCassette.UseVisualStyleBackColor = true;
            // 
            // BtnSequenceControl
            // 
            BtnSequenceControl.Location = new Point(592, 12);
            BtnSequenceControl.Name = "BtnSequenceControl";
            BtnSequenceControl.Size = new Size(110, 56);
            BtnSequenceControl.TabIndex = 0;
            BtnSequenceControl.Text = "Sequence Control";
            BtnSequenceControl.UseVisualStyleBackColor = true;
            // 
            // BtnVision
            // 
            BtnVision.Location = new Point(476, 12);
            BtnVision.Name = "BtnVision";
            BtnVision.Size = new Size(110, 56);
            BtnVision.TabIndex = 0;
            BtnVision.Text = "Vision";
            BtnVision.UseVisualStyleBackColor = true;
            BtnVision.Click += BtnVision_Click;
            // 
            // BtnOCR
            // 
            BtnOCR.Location = new Point(360, 12);
            BtnOCR.Name = "BtnOCR";
            BtnOCR.Size = new Size(110, 56);
            BtnOCR.TabIndex = 0;
            BtnOCR.Text = "OCR";
            BtnOCR.UseVisualStyleBackColor = true;
            // 
            // BtnSetting
            // 
            BtnSetting.Location = new Point(244, 12);
            BtnSetting.Name = "BtnSetting";
            BtnSetting.Size = new Size(110, 56);
            BtnSetting.TabIndex = 0;
            BtnSetting.Text = "Setting";
            BtnSetting.UseVisualStyleBackColor = true;
            // 
            // BtnMap
            // 
            BtnMap.Location = new Point(128, 12);
            BtnMap.Name = "BtnMap";
            BtnMap.Size = new Size(110, 56);
            BtnMap.TabIndex = 0;
            BtnMap.Text = "Map";
            BtnMap.UseVisualStyleBackColor = true;
            // 
            // panelForm
            // 
            panelForm.BackColor = Color.Black;
            panelForm.Dock = DockStyle.Fill;
            panelForm.Location = new Point(0, 100);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(800, 350);
            panelForm.TabIndex = 1;
            // 
            // LotProcessForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelForm);
            Controls.Add(panelMenu);
            Name = "LotProcessForm";
            Text = "LotProcessForm";
            Load += LotProcessForm_Load;
            panelMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenu;
        private Button BtnMap;
        private Panel panelForm;
        private Button BtnCassette;
        private Button BtnSequenceControl;
        private Button BtnVision;
        private Button BtnOCR;
        private Button BtnSetting;
    }
}
