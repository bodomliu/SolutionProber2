namespace MainForm
{
    partial class AlignmentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox4 = new GroupBox();
            txtIndexSizeY = new TextBox();
            txtIndexSizeX = new TextBox();
            label3 = new Label();
            label4 = new Label();
            panelModel = new Panel();
            BtnAdjustWaferHeight = new Button();
            BtnLowMag = new Button();
            BtnGoForModel = new Button();
            BtnHighMag = new Button();
            BtnVisionPara = new Button();
            lblWaferCenterFlag = new Label();
            lblLowAlignFlag = new Label();
            lblHighAlignFlag = new Label();
            BtnWaferAlignment = new Button();
            panelMap = new Panel();
            BtnAutoHeight = new Button();
            label9 = new Label();
            label6 = new Label();
            lblDiffZ = new Label();
            lblAvgZ = new Label();
            panel1 = new Panel();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(txtIndexSizeY);
            groupBox4.Controls.Add(txtIndexSizeX);
            groupBox4.Controls.Add(label3);
            groupBox4.Controls.Add(label4);
            groupBox4.Location = new Point(1189, 500);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(112, 77);
            groupBox4.TabIndex = 23;
            groupBox4.TabStop = false;
            groupBox4.Text = "Index Size";
            // 
            // txtIndexSizeY
            // 
            txtIndexSizeY.Location = new Point(32, 48);
            txtIndexSizeY.Name = "txtIndexSizeY";
            txtIndexSizeY.Size = new Size(71, 23);
            txtIndexSizeY.TabIndex = 3;
            txtIndexSizeY.Text = "0";
            txtIndexSizeY.TextChanged += txtIndexSizeY_TextChanged;
            // 
            // txtIndexSizeX
            // 
            txtIndexSizeX.Location = new Point(33, 22);
            txtIndexSizeX.Name = "txtIndexSizeX";
            txtIndexSizeX.Size = new Size(70, 23);
            txtIndexSizeX.TabIndex = 0;
            txtIndexSizeX.Text = "0";
            txtIndexSizeX.TextChanged += txtIndexSizeX_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 28);
            label3.Name = "label3";
            label3.Size = new Size(16, 17);
            label3.TabIndex = 1;
            label3.Text = "X";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 51);
            label4.Name = "label4";
            label4.Size = new Size(15, 17);
            label4.TabIndex = 1;
            label4.Text = "Y";
            // 
            // panelModel
            // 
            panelModel.BackColor = Color.Silver;
            panelModel.Location = new Point(1190, 122);
            panelModel.Name = "panelModel";
            panelModel.Size = new Size(384, 367);
            panelModel.TabIndex = 22;
            // 
            // BtnAdjustWaferHeight
            // 
            BtnAdjustWaferHeight.Location = new Point(1189, 583);
            BtnAdjustWaferHeight.Name = "BtnAdjustWaferHeight";
            BtnAdjustWaferHeight.Size = new Size(112, 60);
            BtnAdjustWaferHeight.TabIndex = 21;
            BtnAdjustWaferHeight.Text = "Adjust Wafer Height";
            BtnAdjustWaferHeight.UseVisualStyleBackColor = true;
            BtnAdjustWaferHeight.Click += BtnAdjustWaferHeight_Click;
            // 
            // BtnLowMag
            // 
            BtnLowMag.BackColor = Color.Teal;
            BtnLowMag.Location = new Point(1499, 53);
            BtnLowMag.Name = "BtnLowMag";
            BtnLowMag.Size = new Size(75, 50);
            BtnLowMag.TabIndex = 18;
            BtnLowMag.Text = "LowMag";
            BtnLowMag.UseVisualStyleBackColor = false;
            BtnLowMag.Click += BtnLowMag_Click;
            // 
            // BtnGoForModel
            // 
            BtnGoForModel.BackColor = Color.Orange;
            BtnGoForModel.Location = new Point(1190, 53);
            BtnGoForModel.Name = "BtnGoForModel";
            BtnGoForModel.Size = new Size(116, 50);
            BtnGoForModel.TabIndex = 19;
            BtnGoForModel.Text = "Go For High Model";
            BtnGoForModel.UseVisualStyleBackColor = false;
            BtnGoForModel.Click += BtnGoForModel_Click;
            // 
            // BtnHighMag
            // 
            BtnHighMag.BackColor = Color.Teal;
            BtnHighMag.Location = new Point(1414, 53);
            BtnHighMag.Name = "BtnHighMag";
            BtnHighMag.Size = new Size(75, 50);
            BtnHighMag.TabIndex = 20;
            BtnHighMag.Text = "HighMag";
            BtnHighMag.UseVisualStyleBackColor = false;
            BtnHighMag.Click += BtnHighMag_Click;
            // 
            // BtnVisionPara
            // 
            BtnVisionPara.BackColor = Color.Orange;
            BtnVisionPara.Location = new Point(1191, 9);
            BtnVisionPara.Name = "BtnVisionPara";
            BtnVisionPara.Size = new Size(115, 44);
            BtnVisionPara.TabIndex = 24;
            BtnVisionPara.Text = "Vision Para";
            BtnVisionPara.UseVisualStyleBackColor = false;
            BtnVisionPara.Click += BtnVisionPara_Click;
            // 
            // lblWaferCenterFlag
            // 
            lblWaferCenterFlag.AutoSize = true;
            lblWaferCenterFlag.BackColor = Color.Red;
            lblWaferCenterFlag.BorderStyle = BorderStyle.FixedSingle;
            lblWaferCenterFlag.Location = new Point(1088, 9);
            lblWaferCenterFlag.Name = "lblWaferCenterFlag";
            lblWaferCenterFlag.Size = new Size(83, 19);
            lblWaferCenterFlag.TabIndex = 51;
            lblWaferCenterFlag.Text = "WaferCenter";
            // 
            // lblLowAlignFlag
            // 
            lblLowAlignFlag.AutoSize = true;
            lblLowAlignFlag.BackColor = Color.Red;
            lblLowAlignFlag.BorderStyle = BorderStyle.FixedSingle;
            lblLowAlignFlag.Location = new Point(1088, 38);
            lblLowAlignFlag.Name = "lblLowAlignFlag";
            lblLowAlignFlag.Size = new Size(62, 19);
            lblLowAlignFlag.TabIndex = 52;
            lblLowAlignFlag.Text = "LowAlign";
            // 
            // lblHighAlignFlag
            // 
            lblHighAlignFlag.AutoSize = true;
            lblHighAlignFlag.BackColor = Color.Red;
            lblHighAlignFlag.BorderStyle = BorderStyle.FixedSingle;
            lblHighAlignFlag.Location = new Point(1088, 67);
            lblHighAlignFlag.Name = "lblHighAlignFlag";
            lblHighAlignFlag.Size = new Size(66, 19);
            lblHighAlignFlag.TabIndex = 52;
            lblHighAlignFlag.Text = "HighAlign";
            // 
            // BtnWaferAlignment
            // 
            BtnWaferAlignment.Location = new Point(1307, 583);
            BtnWaferAlignment.Name = "BtnWaferAlignment";
            BtnWaferAlignment.Size = new Size(110, 60);
            BtnWaferAlignment.TabIndex = 53;
            BtnWaferAlignment.Text = "Wafer Alignment";
            BtnWaferAlignment.UseVisualStyleBackColor = true;
            BtnWaferAlignment.Click += BtnWaferAlignment_Click;
            // 
            // panelMap
            // 
            panelMap.Location = new Point(1190, 649);
            panelMap.Name = "panelMap";
            panelMap.Size = new Size(384, 357);
            panelMap.TabIndex = 54;
            // 
            // BtnAutoHeight
            // 
            BtnAutoHeight.Location = new Point(1464, 500);
            BtnAutoHeight.Name = "BtnAutoHeight";
            BtnAutoHeight.Size = new Size(110, 59);
            BtnAutoHeight.TabIndex = 55;
            BtnAutoHeight.Text = "Auto Height";
            BtnAutoHeight.UseVisualStyleBackColor = true;
            BtnAutoHeight.Click += BtnAutoHeight_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(1464, 614);
            label9.Name = "label9";
            label9.Size = new Size(52, 17);
            label9.TabIndex = 60;
            label9.Text = "DiffZ = ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1464, 583);
            label6.Name = "label6";
            label6.Size = new Size(54, 17);
            label6.TabIndex = 61;
            label6.Text = "AvgZ = ";
            // 
            // lblDiffZ
            // 
            lblDiffZ.AutoSize = true;
            lblDiffZ.Location = new Point(1524, 614);
            lblDiffZ.Name = "lblDiffZ";
            lblDiffZ.Size = new Size(35, 17);
            lblDiffZ.TabIndex = 59;
            lblDiffZ.Text = "DiffZ";
            // 
            // lblAvgZ
            // 
            lblAvgZ.AutoSize = true;
            lblAvgZ.Location = new Point(1524, 583);
            lblAvgZ.Name = "lblAvgZ";
            lblAvgZ.Size = new Size(37, 17);
            lblAvgZ.TabIndex = 58;
            lblAvgZ.Text = "AvgZ";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Location = new Point(2, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1080, 1003);
            panel1.TabIndex = 62;
            // 
            // AlignmentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1847, 1126);
            Controls.Add(panel1);
            Controls.Add(label9);
            Controls.Add(label6);
            Controls.Add(lblDiffZ);
            Controls.Add(lblAvgZ);
            Controls.Add(BtnAutoHeight);
            Controls.Add(panelMap);
            Controls.Add(BtnWaferAlignment);
            Controls.Add(lblHighAlignFlag);
            Controls.Add(lblLowAlignFlag);
            Controls.Add(lblWaferCenterFlag);
            Controls.Add(BtnVisionPara);
            Controls.Add(groupBox4);
            Controls.Add(panelModel);
            Controls.Add(BtnAdjustWaferHeight);
            Controls.Add(BtnLowMag);
            Controls.Add(BtnGoForModel);
            Controls.Add(BtnHighMag);
            Name = "AlignmentForm";
            Text = "AlignmentForm";
            Load += AlignmentForm_Load;
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox groupBox4;
        private TextBox txtIndexSizeY;
        private TextBox txtIndexSizeX;
        private Label label3;
        private Label label4;
        private Panel panelModel;
        private Button BtnAdjustWaferHeight;
        private Button BtnLowMag;
        private Button BtnGoForModel;
        private Button BtnHighMag;
        private Button BtnVisionPara;
        private Label lblWaferCenterFlag;
        private Label lblLowAlignFlag;
        private Label lblHighAlignFlag;
        private Button BtnWaferAlignment;
        private Panel panelMap;
        private Button BtnAutoHeight;
        private Label label9;
        private Label label6;
        private Label lblDiffZ;
        private Label lblAvgZ;
        private Panel panel1;
    }
}