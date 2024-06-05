namespace MainForm
{
    partial class DeviceDataSettingsForm
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
            BtnWaferMap = new Button();
            BtnDeviceData = new Button();
            panelForm = new Panel();
            panelFile = new Panel();
            label1 = new Label();
            CbxDeviceData = new ComboBox();
            BtnSave = new Button();
            BtnLoad = new Button();
            BtnSettings = new Button();
            panelMenu.SuspendLayout();
            panelFile.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.Controls.Add(BtnWaferMap);
            panelMenu.Controls.Add(BtnDeviceData);
            panelMenu.Dock = DockStyle.Top;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(1565, 100);
            panelMenu.TabIndex = 0;
            // 
            // BtnWaferMap
            // 
            BtnWaferMap.Location = new Point(148, 25);
            BtnWaferMap.Name = "BtnWaferMap";
            BtnWaferMap.Size = new Size(115, 54);
            BtnWaferMap.TabIndex = 0;
            BtnWaferMap.Text = "Wafer Map";
            BtnWaferMap.UseVisualStyleBackColor = true;
            BtnWaferMap.Click += BtnWaferMap_Click;
            // 
            // BtnDeviceData
            // 
            BtnDeviceData.Location = new Point(27, 25);
            BtnDeviceData.Name = "BtnDeviceData";
            BtnDeviceData.Size = new Size(115, 54);
            BtnDeviceData.TabIndex = 0;
            BtnDeviceData.Text = "Device Data";
            BtnDeviceData.UseVisualStyleBackColor = true;
            BtnDeviceData.Click += BtnDeviceData_Click;
            // 
            // panelForm
            // 
            panelForm.BackColor = Color.Black;
            panelForm.Dock = DockStyle.Fill;
            panelForm.Location = new Point(0, 100);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(1365, 746);
            panelForm.TabIndex = 1;
            // 
            // panelFile
            // 
            panelFile.BackColor = SystemColors.ActiveBorder;
            panelFile.Controls.Add(label1);
            panelFile.Controls.Add(CbxDeviceData);
            panelFile.Controls.Add(BtnSettings);
            panelFile.Controls.Add(BtnSave);
            panelFile.Controls.Add(BtnLoad);
            panelFile.Dock = DockStyle.Right;
            panelFile.Location = new Point(1365, 100);
            panelFile.Name = "panelFile";
            panelFile.Size = new Size(200, 746);
            panelFile.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 6);
            label1.Name = "label1";
            label1.Size = new Size(73, 17);
            label1.TabIndex = 3;
            label1.Text = "DeviceData";
            // 
            // CbxDeviceData
            // 
            CbxDeviceData.FormattingEnabled = true;
            CbxDeviceData.Location = new Point(3, 28);
            CbxDeviceData.Name = "CbxDeviceData";
            CbxDeviceData.Size = new Size(182, 25);
            CbxDeviceData.TabIndex = 2;
            // 
            // BtnSave
            // 
            BtnSave.BackColor = Color.Orange;
            BtnSave.Location = new Point(0, 191);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(188, 60);
            BtnSave.TabIndex = 0;
            BtnSave.Text = "Save";
            BtnSave.UseVisualStyleBackColor = false;
            BtnSave.Click += BtnSave_Click;
            // 
            // BtnLoad
            // 
            BtnLoad.BackColor = Color.Orange;
            BtnLoad.Location = new Point(0, 125);
            BtnLoad.Name = "BtnLoad";
            BtnLoad.Size = new Size(188, 60);
            BtnLoad.TabIndex = 0;
            BtnLoad.Text = "Read File";
            BtnLoad.UseVisualStyleBackColor = false;
            BtnLoad.Click += BtnLoad_Click;
            // 
            // BtnSettings
            // 
            BtnSettings.BackColor = Color.Orange;
            BtnSettings.Location = new Point(0, 257);
            BtnSettings.Name = "BtnSettings";
            BtnSettings.Size = new Size(188, 60);
            BtnSettings.TabIndex = 0;
            BtnSettings.Text = "Settings";
            BtnSettings.UseVisualStyleBackColor = false;
            BtnSettings.Click += BtnSettings_Click;
            // 
            // DeviceDataSettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1565, 846);
            Controls.Add(panelForm);
            Controls.Add(panelFile);
            Controls.Add(panelMenu);
            Name = "DeviceDataSettingsForm";
            Text = "Form1";
            Load += DeviceDataSettingsForm_Load;
            panelMenu.ResumeLayout(false);
            panelFile.ResumeLayout(false);
            panelFile.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenu;
        private Panel panelForm;
        private Button BtnWaferMap;
        private Button BtnDeviceData;
        private Panel panelFile;
        private Button BtnSave;
        private Button BtnLoad;
        private ComboBox CbxDeviceData;
        private Label label1;
        private Button BtnSettings;
    }
}
