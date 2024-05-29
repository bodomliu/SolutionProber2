namespace MainForm
{
    partial class ManualForm
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
            panelForm = new Panel();
            panelMenu = new Panel();
            BtnPolishWafer = new Button();
            BtnProbing = new Button();
            BtnAlignment = new Button();
            BtnManualLoading = new Button();
            panelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelForm
            // 
            panelForm.BackColor = Color.Black;
            panelForm.Dock = DockStyle.Fill;
            panelForm.Location = new Point(0, 67);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(1170, 602);
            panelForm.TabIndex = 0;
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.Gray;
            panelMenu.Controls.Add(BtnPolishWafer);
            panelMenu.Controls.Add(BtnProbing);
            panelMenu.Controls.Add(BtnAlignment);
            panelMenu.Controls.Add(BtnManualLoading);
            panelMenu.Dock = DockStyle.Top;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(1170, 67);
            panelMenu.TabIndex = 1;
            // 
            // BtnPolishWafer
            // 
            BtnPolishWafer.Location = new Point(368, 12);
            BtnPolishWafer.Name = "BtnPolishWafer";
            BtnPolishWafer.Size = new Size(101, 42);
            BtnPolishWafer.TabIndex = 0;
            BtnPolishWafer.Text = "Polish Wafer";
            BtnPolishWafer.UseVisualStyleBackColor = true;
            // 
            // BtnProbing
            // 
            BtnProbing.Location = new Point(246, 12);
            BtnProbing.Name = "BtnProbing";
            BtnProbing.Size = new Size(101, 42);
            BtnProbing.TabIndex = 0;
            BtnProbing.Text = "Probing";
            BtnProbing.UseVisualStyleBackColor = true;
            BtnProbing.Click += BtnProbing_Click;
            // 
            // BtnAlignment
            // 
            BtnAlignment.Location = new Point(129, 12);
            BtnAlignment.Name = "BtnAlignment";
            BtnAlignment.Size = new Size(101, 42);
            BtnAlignment.TabIndex = 0;
            BtnAlignment.Text = "Alignment";
            BtnAlignment.UseVisualStyleBackColor = true;
            // 
            // BtnManualLoading
            // 
            BtnManualLoading.Location = new Point(12, 12);
            BtnManualLoading.Name = "BtnManualLoading";
            BtnManualLoading.Size = new Size(101, 42);
            BtnManualLoading.TabIndex = 0;
            BtnManualLoading.Text = "Manual Loading";
            BtnManualLoading.UseVisualStyleBackColor = true;
            // 
            // ManualForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1170, 669);
            Controls.Add(panelForm);
            Controls.Add(panelMenu);
            Name = "ManualForm";
            Text = "Form1";
            panelMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelForm;
        private Panel panelMenu;
        private Button BtnPolishWafer;
        private Button BtnProbing;
        private Button BtnAlignment;
        private Button BtnManualLoading;
    }
}
