namespace CommonComponentLibrary
{
    partial class MainForm
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
            BtnMotionControl = new Button();
            BtnErrorCompensation = new Button();
            BtnLotProcess = new Button();
            panelForm = new Panel();
            panelStatus = new Panel();
            panelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.Controls.Add(BtnMotionControl);
            panelMenu.Controls.Add(BtnErrorCompensation);
            panelMenu.Controls.Add(BtnLotProcess);
            panelMenu.Dock = DockStyle.Right;
            panelMenu.Location = new Point(1552, 100);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(352, 885);
            panelMenu.TabIndex = 3;
            // 
            // BtnMotionControl
            // 
            BtnMotionControl.BackColor = Color.YellowGreen;
            BtnMotionControl.Location = new Point(21, 147);
            BtnMotionControl.Name = "BtnMotionControl";
            BtnMotionControl.Size = new Size(100, 60);
            BtnMotionControl.TabIndex = 1;
            BtnMotionControl.Text = "Motion Control";
            BtnMotionControl.UseVisualStyleBackColor = false;
            BtnMotionControl.Click += BtnMotionControl_Click;
            // 
            // BtnErrorCompensation
            // 
            BtnErrorCompensation.BackColor = Color.Orange;
            BtnErrorCompensation.Location = new Point(21, 81);
            BtnErrorCompensation.Name = "BtnErrorCompensation";
            BtnErrorCompensation.Size = new Size(100, 60);
            BtnErrorCompensation.TabIndex = 1;
            BtnErrorCompensation.Text = "Error Compensation";
            BtnErrorCompensation.UseVisualStyleBackColor = false;
            BtnErrorCompensation.Click += BtnErrorCompensation_Click;
            // 
            // BtnLotProcess
            // 
            BtnLotProcess.BackColor = Color.MediumPurple;
            BtnLotProcess.Location = new Point(21, 15);
            BtnLotProcess.Name = "BtnLotProcess";
            BtnLotProcess.Size = new Size(100, 60);
            BtnLotProcess.TabIndex = 0;
            BtnLotProcess.Text = "Lot Process";
            BtnLotProcess.UseVisualStyleBackColor = false;
            BtnLotProcess.Click += BtnLotProcess_Click;
            // 
            // panelForm
            // 
            panelForm.BackColor = Color.Gray;
            panelForm.BorderStyle = BorderStyle.Fixed3D;
            panelForm.Dock = DockStyle.Fill;
            panelForm.Location = new Point(0, 100);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(1552, 885);
            panelForm.TabIndex = 4;
            // 
            // panelStatus
            // 
            panelStatus.AccessibleName = "";
            panelStatus.Dock = DockStyle.Top;
            panelStatus.Location = new Point(0, 0);
            panelStatus.Name = "panelStatus";
            panelStatus.Size = new Size(1904, 100);
            panelStatus.TabIndex = 0;
            // 
            // CommonComponentLibrary
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 985);
            Controls.Add(panelForm);
            Controls.Add(panelMenu);
            Controls.Add(panelStatus);
            Name = "CommonComponentLibrary";
            Text = "Form1";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            panelMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panelMenu;
        private Panel panelForm;
        private Panel panelStatus;
        private Button BtnLotProcess;
        private Button BtnErrorCompensation;
        private Button BtnMotionControl;
    }
}
