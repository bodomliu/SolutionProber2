namespace MainForm
{
    partial class InspectionForm
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
            components = new System.ComponentModel.Container();
            panelMap = new Panel();
            btnNextPad = new Button();
            btnPrevPad = new Button();
            btnMoveToPad = new Button();
            TxtIndex = new TextBox();
            paneIndexControl = new Panel();
            BtnMoveToDie = new Button();
            groupBox1 = new GroupBox();
            BtnClear = new Button();
            BtnApply = new Button();
            BtnSetFrom = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            TxtShiftY = new TextBox();
            TxtShiftX = new TextBox();
            timer1 = new System.Windows.Forms.Timer(components);
            panel1 = new Panel();
            panelCamera = new Panel();
            groupBox2 = new GroupBox();
            label4 = new Label();
            TxtAngle = new TextBox();
            BtnRotate = new Button();
            BtnMoveWithAngle = new Button();
            BtnCheckPads = new Button();
            groupBoxPMI = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // panelMap
            // 
            panelMap.BackColor = Color.Gray;
            panelMap.Location = new Point(1217, 705);
            panelMap.Name = "panelMap";
            panelMap.Size = new Size(300, 300);
            panelMap.TabIndex = 26;
            // 
            // btnNextPad
            // 
            btnNextPad.Location = new Point(105, 74);
            btnNextPad.Name = "btnNextPad";
            btnNextPad.Size = new Size(90, 40);
            btnNextPad.TabIndex = 44;
            btnNextPad.Text = "Next Pad";
            btnNextPad.UseVisualStyleBackColor = true;
            btnNextPad.Click += btnNextPad_Click;
            // 
            // btnPrevPad
            // 
            btnPrevPad.Location = new Point(11, 74);
            btnPrevPad.Name = "btnPrevPad";
            btnPrevPad.Size = new Size(88, 40);
            btnPrevPad.TabIndex = 43;
            btnPrevPad.Text = "Prev Pad";
            btnPrevPad.UseVisualStyleBackColor = true;
            btnPrevPad.Click += btnPrevPad_Click;
            // 
            // btnMoveToPad
            // 
            btnMoveToPad.BackColor = Color.Orange;
            btnMoveToPad.Location = new Point(105, 22);
            btnMoveToPad.Name = "btnMoveToPad";
            btnMoveToPad.Size = new Size(90, 46);
            btnMoveToPad.TabIndex = 45;
            btnMoveToPad.Text = "Move To Pad";
            btnMoveToPad.UseVisualStyleBackColor = false;
            btnMoveToPad.Click += btnMoveToPad_Click;
            // 
            // TxtIndex
            // 
            TxtIndex.Location = new Point(11, 45);
            TxtIndex.Name = "TxtIndex";
            TxtIndex.Size = new Size(88, 23);
            TxtIndex.TabIndex = 46;
            TxtIndex.Text = "0";
            // 
            // paneIndexControl
            // 
            paneIndexControl.BackColor = Color.Gray;
            paneIndexControl.Location = new Point(1296, 568);
            paneIndexControl.Name = "paneIndexControl";
            paneIndexControl.Size = new Size(221, 131);
            paneIndexControl.TabIndex = 47;
            // 
            // BtnMoveToDie
            // 
            BtnMoveToDie.Location = new Point(1296, 529);
            BtnMoveToDie.Name = "BtnMoveToDie";
            BtnMoveToDie.Size = new Size(221, 33);
            BtnMoveToDie.TabIndex = 48;
            BtnMoveToDie.Text = "Move To Die";
            BtnMoveToDie.UseVisualStyleBackColor = true;
            BtnMoveToDie.Click += BtnMoveToDie_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(BtnClear);
            groupBox1.Controls.Add(BtnApply);
            groupBox1.Controls.Add(BtnSetFrom);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(TxtShiftY);
            groupBox1.Controls.Add(TxtShiftX);
            groupBox1.Location = new Point(1108, 161);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(202, 180);
            groupBox1.TabIndex = 49;
            groupBox1.TabStop = false;
            groupBox1.Text = "Set Probing Shift";
            // 
            // BtnClear
            // 
            BtnClear.BackColor = Color.Orange;
            BtnClear.Location = new Point(106, 61);
            BtnClear.Name = "BtnClear";
            BtnClear.Size = new Size(90, 38);
            BtnClear.TabIndex = 2;
            BtnClear.Text = "Clear";
            BtnClear.UseVisualStyleBackColor = false;
            BtnClear.Click += BtnClear_Click;
            // 
            // BtnApply
            // 
            BtnApply.Location = new Point(106, 105);
            BtnApply.Name = "BtnApply";
            BtnApply.Size = new Size(90, 70);
            BtnApply.TabIndex = 2;
            BtnApply.Text = "Apply";
            BtnApply.UseVisualStyleBackColor = true;
            BtnApply.Click += BtnApply_Click;
            // 
            // BtnSetFrom
            // 
            BtnSetFrom.Location = new Point(6, 104);
            BtnSetFrom.Name = "BtnSetFrom";
            BtnSetFrom.Size = new Size(94, 70);
            BtnSetFrom.TabIndex = 2;
            BtnSetFrom.Text = "Set From";
            BtnSetFrom.UseVisualStyleBackColor = true;
            BtnSetFrom.Click += BtnSetFrom_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(37, 20);
            label3.Name = "label3";
            label3.Size = new Size(36, 17);
            label3.TabIndex = 1;
            label3.Text = "Base";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 72);
            label2.Name = "label2";
            label2.Size = new Size(18, 17);
            label2.TabIndex = 1;
            label2.Text = "Y:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 45);
            label1.Name = "label1";
            label1.Size = new Size(19, 17);
            label1.TabIndex = 1;
            label1.Text = "X:";
            // 
            // TxtShiftY
            // 
            TxtShiftY.Location = new Point(40, 69);
            TxtShiftY.Name = "TxtShiftY";
            TxtShiftY.Size = new Size(60, 23);
            TxtShiftY.TabIndex = 0;
            TxtShiftY.Text = "0";
            // 
            // TxtShiftX
            // 
            TxtShiftX.Location = new Point(41, 39);
            TxtShiftX.Name = "TxtShiftX";
            TxtShiftX.Size = new Size(59, 23);
            TxtShiftX.TabIndex = 0;
            TxtShiftX.Text = "0";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Location = new Point(2, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1080, 1003);
            panel1.TabIndex = 64;
            // 
            // panelCamera
            // 
            panelCamera.BackColor = Color.Black;
            panelCamera.Location = new Point(1240, 21);
            panelCamera.Name = "panelCamera";
            panelCamera.Size = new Size(253, 83);
            panelCamera.TabIndex = 65;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnMoveToPad);
            groupBox2.Controls.Add(btnPrevPad);
            groupBox2.Controls.Add(btnNextPad);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(TxtIndex);
            groupBox2.Location = new Point(1089, 568);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(201, 125);
            groupBox2.TabIndex = 66;
            groupBox2.TabStop = false;
            groupBox2.Text = "Pad Move";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 25);
            label4.Name = "label4";
            label4.Size = new Size(40, 17);
            label4.TabIndex = 1;
            label4.Text = "Index";
            // 
            // TxtAngle
            // 
            TxtAngle.Location = new Point(1114, 398);
            TxtAngle.Name = "TxtAngle";
            TxtAngle.Size = new Size(92, 23);
            TxtAngle.TabIndex = 67;
            TxtAngle.Text = "0";
            // 
            // BtnRotate
            // 
            BtnRotate.Location = new Point(1114, 349);
            BtnRotate.Name = "BtnRotate";
            BtnRotate.Size = new Size(92, 43);
            BtnRotate.TabIndex = 68;
            BtnRotate.Text = "Rotate";
            BtnRotate.UseVisualStyleBackColor = true;
            BtnRotate.Click += BtnRotate_Click;
            // 
            // BtnMoveWithAngle
            // 
            BtnMoveWithAngle.Location = new Point(1114, 427);
            BtnMoveWithAngle.Name = "BtnMoveWithAngle";
            BtnMoveWithAngle.Size = new Size(92, 43);
            BtnMoveWithAngle.TabIndex = 68;
            BtnMoveWithAngle.Text = "Move With Angle";
            BtnMoveWithAngle.UseVisualStyleBackColor = true;
            BtnMoveWithAngle.Click += BtnMoveWithAngle_Click;
            // 
            // BtnCheckPads
            // 
            BtnCheckPads.Location = new Point(1215, 349);
            BtnCheckPads.Name = "BtnCheckPads";
            BtnCheckPads.Size = new Size(95, 40);
            BtnCheckPads.TabIndex = 69;
            BtnCheckPads.Text = "Check Pads";
            BtnCheckPads.UseVisualStyleBackColor = true;
            BtnCheckPads.Click += BtnCheckPads_Click;
            // 
            // groupBoxPMI
            // 
            groupBoxPMI.Location = new Point(1316, 161);
            groupBoxPMI.Name = "groupBoxPMI";
            groupBoxPMI.Size = new Size(201, 331);
            groupBoxPMI.TabIndex = 70;
            groupBoxPMI.TabStop = false;
            groupBoxPMI.Text = "PMI";
            // 
            // InspectionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1847, 1126);
            Controls.Add(groupBoxPMI);
            Controls.Add(BtnCheckPads);
            Controls.Add(BtnMoveWithAngle);
            Controls.Add(BtnRotate);
            Controls.Add(TxtAngle);
            Controls.Add(groupBox2);
            Controls.Add(panelCamera);
            Controls.Add(panel1);
            Controls.Add(groupBox1);
            Controls.Add(BtnMoveToDie);
            Controls.Add(paneIndexControl);
            Controls.Add(panelMap);
            Name = "InspectionForm";
            Text = "InspectionForm";
            Load += InspectionForm_Load;
            ParentChanged += InspectionForm_ParentChanged;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panelMap;
        private Button btnNextPad;
        private Button btnPrevPad;
        private Button btnMoveToPad;
        private TextBox TxtIndex;
        private Panel paneIndexControl;
        private Button BtnMoveToDie;
        private GroupBox groupBox1;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox TxtShiftY;
        private TextBox TxtShiftX;
        private Button BtnClear;
        private Button BtnApply;
        private Button BtnSetFrom;
        private System.Windows.Forms.Timer timer1;
        private Panel panel1;
        private Panel panelCamera;
        private GroupBox groupBox2;
        private Label label4;
        private TextBox TxtAngle;
        private Button BtnRotate;
        private Button BtnMoveWithAngle;
        private Button BtnCheckPads;
        private GroupBox groupBoxPMI;
    }
}