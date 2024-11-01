﻿namespace UtilityForm
{
    partial class UtilityForm
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
            BtnChuckCenter = new Button();
            BtnChuckFlatness = new Button();
            panelForm = new Panel();
            panel2 = new Panel();
            panel1 = new Panel();
            BtnGT2 = new Button();
            panelMenu.SuspendLayout();
            panelForm.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = SystemColors.ActiveBorder;
            panelMenu.Controls.Add(BtnGT2);
            panelMenu.Controls.Add(BtnChuckCenter);
            panelMenu.Controls.Add(BtnChuckFlatness);
            panelMenu.Dock = DockStyle.Top;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(1792, 66);
            panelMenu.TabIndex = 0;
            // 
            // BtnChuckCenter
            // 
            BtnChuckCenter.Location = new Point(150, 14);
            BtnChuckCenter.Name = "BtnChuckCenter";
            BtnChuckCenter.Size = new Size(120, 36);
            BtnChuckCenter.TabIndex = 0;
            BtnChuckCenter.Text = "Chuck Center";
            BtnChuckCenter.UseVisualStyleBackColor = true;
            BtnChuckCenter.Click += BtnChuckCenter_Click;
            // 
            // BtnChuckFlatness
            // 
            BtnChuckFlatness.Location = new Point(24, 14);
            BtnChuckFlatness.Name = "BtnChuckFlatness";
            BtnChuckFlatness.Size = new Size(120, 36);
            BtnChuckFlatness.TabIndex = 0;
            BtnChuckFlatness.Text = "Chuck Flatness";
            BtnChuckFlatness.UseVisualStyleBackColor = true;
            BtnChuckFlatness.Click += BtnChuckFlatness_Click;
            // 
            // panelForm
            // 
            panelForm.BackColor = SystemColors.Control;
            panelForm.Controls.Add(panel2);
            panelForm.Controls.Add(panel1);
            panelForm.Dock = DockStyle.Fill;
            panelForm.Location = new Point(0, 66);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(1792, 1010);
            panelForm.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Location = new Point(1089, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(691, 1000);
            panel2.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1080, 1000);
            panel1.TabIndex = 0;
            // 
            // BtnGT2
            // 
            BtnGT2.Location = new Point(276, 14);
            BtnGT2.Name = "BtnGT2";
            BtnGT2.Size = new Size(132, 36);
            BtnGT2.TabIndex = 1;
            BtnGT2.Text = "GT2";
            BtnGT2.UseVisualStyleBackColor = true;
            BtnGT2.Click += BtnGT2_Click;
            // 
            // UtilityForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1792, 1076);
            Controls.Add(panelForm);
            Controls.Add(panelMenu);
            Name = "UtilityForm";
            Text = "Form1";
            VisibleChanged += UtilityForm_VisibleChanged;
            ParentChanged += UtilityForm_ParentChanged;
            panelMenu.ResumeLayout(false);
            panelForm.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenu;
        private Panel panelForm;
        private Button BtnChuckFlatness;
        private Panel panel1;
        private Panel panel2;
        private Button BtnChuckCenter;
        private Button BtnGT2;
    }
}
