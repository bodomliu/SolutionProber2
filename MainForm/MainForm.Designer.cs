namespace MainForm
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
            BtnPinRegistration = new Button();
            BtnPadRegistration = new Button();
            BtnDeviceSettings = new Button();
            BtnManual = new Button();
            BtnInspection = new Button();
            BtnAlignment = new Button();
            BtnMotionControl = new Button();
            BtnSetupUtility = new Button();
            BtnErrorCompensation = new Button();
            BtnLotProcess = new Button();
            panelForm = new Panel();
            panelStatus = new Panel();
            panelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.DimGray;
            panelMenu.Controls.Add(BtnPinRegistration);
            panelMenu.Controls.Add(BtnPadRegistration);
            panelMenu.Controls.Add(BtnDeviceSettings);
            panelMenu.Controls.Add(BtnManual);
            panelMenu.Controls.Add(BtnInspection);
            panelMenu.Controls.Add(BtnAlignment);
            panelMenu.Controls.Add(BtnMotionControl);
            panelMenu.Controls.Add(BtnSetupUtility);
            panelMenu.Controls.Add(BtnErrorCompensation);
            panelMenu.Controls.Add(BtnLotProcess);
            panelMenu.Dock = DockStyle.Right;
            panelMenu.Location = new Point(1581, 63);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(323, 922);
            panelMenu.TabIndex = 3;
            // 
            // BtnPinRegistration
            // 
            BtnPinRegistration.BackColor = Color.Teal;
            BtnPinRegistration.Location = new Point(3, 204);
            BtnPinRegistration.Name = "BtnPinRegistration";
            BtnPinRegistration.Size = new Size(100, 60);
            BtnPinRegistration.TabIndex = 3;
            BtnPinRegistration.Text = "Pin Registration";
            BtnPinRegistration.UseVisualStyleBackColor = false;
            BtnPinRegistration.Click += BtnPinRegistration_Click;
            // 
            // BtnPadRegistration
            // 
            BtnPadRegistration.BackColor = Color.Teal;
            BtnPadRegistration.Location = new Point(3, 138);
            BtnPadRegistration.Name = "BtnPadRegistration";
            BtnPadRegistration.Size = new Size(100, 60);
            BtnPadRegistration.TabIndex = 2;
            BtnPadRegistration.Text = "Pad Registration";
            BtnPadRegistration.UseVisualStyleBackColor = false;
            BtnPadRegistration.Click += BtnPadRegistration_Click;
            // 
            // BtnDeviceSettings
            // 
            BtnDeviceSettings.BackColor = Color.Teal;
            BtnDeviceSettings.Location = new Point(3, 6);
            BtnDeviceSettings.Name = "BtnDeviceSettings";
            BtnDeviceSettings.Size = new Size(100, 60);
            BtnDeviceSettings.TabIndex = 1;
            BtnDeviceSettings.Text = "Device Settings";
            BtnDeviceSettings.UseVisualStyleBackColor = false;
            BtnDeviceSettings.Click += BtnDeviceSettings_Click;
            // 
            // BtnManual
            // 
            BtnManual.BackColor = Color.YellowGreen;
            BtnManual.Location = new Point(107, 72);
            BtnManual.Name = "BtnManual";
            BtnManual.Size = new Size(100, 60);
            BtnManual.TabIndex = 1;
            BtnManual.Text = "Manual";
            BtnManual.UseVisualStyleBackColor = false;
            BtnManual.Click += BtnManual_Click;
            // 
            // BtnInspection
            // 
            BtnInspection.BackColor = Color.YellowGreen;
            BtnInspection.Location = new Point(107, 138);
            BtnInspection.Name = "BtnInspection";
            BtnInspection.Size = new Size(100, 60);
            BtnInspection.TabIndex = 1;
            BtnInspection.Text = "Inspection";
            BtnInspection.UseVisualStyleBackColor = false;
            BtnInspection.Click += BtnInspection_Click;
            // 
            // BtnAlignment
            // 
            BtnAlignment.BackColor = Color.Teal;
            BtnAlignment.Location = new Point(3, 72);
            BtnAlignment.Name = "BtnAlignment";
            BtnAlignment.Size = new Size(100, 60);
            BtnAlignment.TabIndex = 1;
            BtnAlignment.Text = "Alignment Settings";
            BtnAlignment.UseVisualStyleBackColor = false;
            BtnAlignment.Click += BtnAlignment_Click;
            // 
            // BtnMotionControl
            // 
            BtnMotionControl.BackColor = Color.YellowGreen;
            BtnMotionControl.Location = new Point(107, 6);
            BtnMotionControl.Name = "BtnMotionControl";
            BtnMotionControl.Size = new Size(100, 60);
            BtnMotionControl.TabIndex = 1;
            BtnMotionControl.Text = "Motion Control";
            BtnMotionControl.UseVisualStyleBackColor = false;
            BtnMotionControl.Click += BtnMotionControl_Click;
            // 
            // BtnSetupUtility
            // 
            BtnSetupUtility.BackColor = Color.Orange;
            BtnSetupUtility.Location = new Point(211, 138);
            BtnSetupUtility.Name = "BtnSetupUtility";
            BtnSetupUtility.Size = new Size(100, 60);
            BtnSetupUtility.TabIndex = 1;
            BtnSetupUtility.Text = "Setup Utility";
            BtnSetupUtility.UseVisualStyleBackColor = false;
            BtnSetupUtility.Click += BtnSetupUtility_Click;
            // 
            // BtnErrorCompensation
            // 
            BtnErrorCompensation.BackColor = Color.Orange;
            BtnErrorCompensation.Location = new Point(211, 72);
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
            BtnLotProcess.Location = new Point(211, 6);
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
            panelForm.Location = new Point(0, 63);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(1581, 922);
            panelForm.TabIndex = 4;
            // 
            // panelStatus
            // 
            panelStatus.AccessibleName = "";
            panelStatus.BackColor = Color.DarkGray;
            panelStatus.Dock = DockStyle.Top;
            panelStatus.Location = new Point(0, 0);
            panelStatus.Name = "panelStatus";
            panelStatus.Size = new Size(1904, 63);
            panelStatus.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 985);
            Controls.Add(panelForm);
            Controls.Add(panelMenu);
            Controls.Add(panelStatus);
            Name = "MainForm";
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
        private Button BtnAlignment;
        private Button BtnDeviceSettings;
        private Button BtnSetupUtility;
        private Button BtnPinRegistration;
        private Button BtnPadRegistration;
        private Button BtnInspection;
        private Button BtnManual;
    }
}
