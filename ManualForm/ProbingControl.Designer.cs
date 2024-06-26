namespace ManualForm
{
    partial class ProbingControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            BtnWaferPinAlign = new Button();
            BtnInspection = new Button();
            groupBox2 = new GroupBox();
            Rbtn5um = new RadioButton();
            Rbtn1um = new RadioButton();
            BtnJogDown = new Button();
            BtnJogUp = new Button();
            TxtAllContact = new TextBox();
            groupBox1 = new GroupBox();
            BtnSetOverDrive = new Button();
            BtnZToggle = new Button();
            TxtOverDrive = new TextBox();
            BtnDown = new Button();
            BtnUp = new Button();
            TxtFirstContact = new TextBox();
            BtnApply = new Button();
            BtnReset = new Button();
            BtnFirstContact = new Button();
            BtnAllContact = new Button();
            groupBox3 = new GroupBox();
            CbCompensation = new CheckBox();
            txtPad2PinY = new TextBox();
            label4 = new Label();
            TxtZDownPosition = new TextBox();
            label3 = new Label();
            txtPad2PinX = new TextBox();
            label2 = new Label();
            TxtZUpPosition = new TextBox();
            label8 = new Label();
            label1 = new Label();
            label6 = new Label();
            txtEncodeX = new TextBox();
            label7 = new Label();
            txtEncodeR = new TextBox();
            label5 = new Label();
            txtEncodeY = new TextBox();
            txtEncodeZ = new TextBox();
            groupBox4 = new GroupBox();
            timer1 = new System.Windows.Forms.Timer(components);
            groupBox5 = new GroupBox();
            panel2 = new Panel();
            BtnShowZRepeatUtility = new Button();
            CbWithPmi = new CheckBox();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 800);
            panel1.TabIndex = 0;
            // 
            // BtnWaferPinAlign
            // 
            BtnWaferPinAlign.BackColor = SystemColors.Control;
            BtnWaferPinAlign.Location = new Point(993, 740);
            BtnWaferPinAlign.Name = "BtnWaferPinAlign";
            BtnWaferPinAlign.Size = new Size(118, 62);
            BtnWaferPinAlign.TabIndex = 61;
            BtnWaferPinAlign.Text = "Wafer And Pin Align";
            BtnWaferPinAlign.UseVisualStyleBackColor = false;
            BtnWaferPinAlign.Click += BtnWaferPinAlign_Click;
            // 
            // BtnInspection
            // 
            BtnInspection.BackColor = Color.YellowGreen;
            BtnInspection.Location = new Point(1117, 740);
            BtnInspection.Name = "BtnInspection";
            BtnInspection.Size = new Size(118, 62);
            BtnInspection.TabIndex = 62;
            BtnInspection.Text = "Inspection";
            BtnInspection.UseVisualStyleBackColor = false;
            BtnInspection.Click += BtnInspection_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(Rbtn5um);
            groupBox2.Controls.Add(Rbtn1um);
            groupBox2.Controls.Add(BtnJogDown);
            groupBox2.Controls.Add(BtnJogUp);
            groupBox2.Location = new Point(1101, 364);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(134, 179);
            groupBox2.TabIndex = 60;
            groupBox2.TabStop = false;
            groupBox2.Text = "Jog on Z up Status";
            // 
            // Rbtn5um
            // 
            Rbtn5um.AutoSize = true;
            Rbtn5um.Location = new Point(33, 98);
            Rbtn5um.Name = "Rbtn5um";
            Rbtn5um.Size = new Size(60, 21);
            Rbtn5um.TabIndex = 1;
            Rbtn5um.Text = "+5um";
            Rbtn5um.UseVisualStyleBackColor = true;
            // 
            // Rbtn1um
            // 
            Rbtn1um.AutoSize = true;
            Rbtn1um.Checked = true;
            Rbtn1um.Location = new Point(33, 71);
            Rbtn1um.Name = "Rbtn1um";
            Rbtn1um.Size = new Size(60, 21);
            Rbtn1um.TabIndex = 1;
            Rbtn1um.TabStop = true;
            Rbtn1um.Text = "+1um";
            Rbtn1um.UseVisualStyleBackColor = true;
            // 
            // BtnJogDown
            // 
            BtnJogDown.Location = new Point(6, 125);
            BtnJogDown.Name = "BtnJogDown";
            BtnJogDown.Size = new Size(122, 40);
            BtnJogDown.TabIndex = 0;
            BtnJogDown.Text = "Down";
            BtnJogDown.UseVisualStyleBackColor = true;
            // 
            // BtnJogUp
            // 
            BtnJogUp.Location = new Point(6, 23);
            BtnJogUp.Name = "BtnJogUp";
            BtnJogUp.Size = new Size(122, 41);
            BtnJogUp.TabIndex = 0;
            BtnJogUp.Text = "Up";
            BtnJogUp.UseVisualStyleBackColor = true;
            // 
            // TxtAllContact
            // 
            TxtAllContact.Location = new Point(112, 22);
            TxtAllContact.Name = "TxtAllContact";
            TxtAllContact.Size = new Size(100, 23);
            TxtAllContact.TabIndex = 57;
            TxtAllContact.Text = "0";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(BtnSetOverDrive);
            groupBox1.Controls.Add(BtnZToggle);
            groupBox1.Controls.Add(TxtOverDrive);
            groupBox1.Controls.Add(BtnDown);
            groupBox1.Controls.Add(BtnUp);
            groupBox1.Location = new Point(814, 364);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(277, 179);
            groupBox1.TabIndex = 59;
            groupBox1.TabStop = false;
            groupBox1.Text = "Z Up Utility";
            // 
            // BtnSetOverDrive
            // 
            BtnSetOverDrive.BackColor = Color.Orange;
            BtnSetOverDrive.Location = new Point(115, 115);
            BtnSetOverDrive.Name = "BtnSetOverDrive";
            BtnSetOverDrive.Size = new Size(149, 50);
            BtnSetOverDrive.TabIndex = 4;
            BtnSetOverDrive.Text = "Set Over Drive";
            BtnSetOverDrive.UseVisualStyleBackColor = false;
            BtnSetOverDrive.Click += BtnSetOverDrive_Click;
            // 
            // BtnZToggle
            // 
            BtnZToggle.BackColor = Color.YellowGreen;
            BtnZToggle.Location = new Point(112, 22);
            BtnZToggle.Name = "BtnZToggle";
            BtnZToggle.Size = new Size(152, 89);
            BtnZToggle.TabIndex = 2;
            BtnZToggle.Text = "Z Up";
            BtnZToggle.UseVisualStyleBackColor = false;
            BtnZToggle.Click += BtnZToggle_Click;
            // 
            // TxtOverDrive
            // 
            TxtOverDrive.Location = new Point(6, 82);
            TxtOverDrive.Name = "TxtOverDrive";
            TxtOverDrive.Size = new Size(100, 23);
            TxtOverDrive.TabIndex = 1;
            TxtOverDrive.Text = "0";
            // 
            // BtnDown
            // 
            BtnDown.Location = new Point(6, 111);
            BtnDown.Name = "BtnDown";
            BtnDown.Size = new Size(100, 54);
            BtnDown.TabIndex = 0;
            BtnDown.Text = "Down";
            BtnDown.UseVisualStyleBackColor = true;
            BtnDown.Click += BtnDown_Click;
            // 
            // BtnUp
            // 
            BtnUp.Location = new Point(6, 22);
            BtnUp.Name = "BtnUp";
            BtnUp.Size = new Size(100, 54);
            BtnUp.TabIndex = 0;
            BtnUp.Text = "Up";
            BtnUp.UseVisualStyleBackColor = true;
            BtnUp.Click += BtnUp_Click;
            // 
            // TxtFirstContact
            // 
            TxtFirstContact.Location = new Point(6, 22);
            TxtFirstContact.Name = "TxtFirstContact";
            TxtFirstContact.Size = new Size(100, 23);
            TxtFirstContact.TabIndex = 58;
            TxtFirstContact.Text = "0";
            // 
            // BtnApply
            // 
            BtnApply.BackColor = Color.Orange;
            BtnApply.Location = new Point(1041, 549);
            BtnApply.Name = "BtnApply";
            BtnApply.Size = new Size(95, 109);
            BtnApply.TabIndex = 56;
            BtnApply.Text = "Apply";
            BtnApply.UseVisualStyleBackColor = false;
            BtnApply.Click += BtnApply_Click;
            // 
            // BtnReset
            // 
            BtnReset.Location = new Point(1140, 549);
            BtnReset.Name = "BtnReset";
            BtnReset.Size = new Size(89, 109);
            BtnReset.TabIndex = 53;
            BtnReset.Text = "Reset";
            BtnReset.UseVisualStyleBackColor = true;
            // 
            // BtnFirstContact
            // 
            BtnFirstContact.Location = new Point(6, 51);
            BtnFirstContact.Name = "BtnFirstContact";
            BtnFirstContact.Size = new Size(100, 47);
            BtnFirstContact.TabIndex = 54;
            BtnFirstContact.Text = "First Contact";
            BtnFirstContact.UseVisualStyleBackColor = true;
            BtnFirstContact.Click += BtnFirstContact_Click;
            // 
            // BtnAllContact
            // 
            BtnAllContact.Location = new Point(112, 51);
            BtnAllContact.Name = "BtnAllContact";
            BtnAllContact.Size = new Size(100, 47);
            BtnAllContact.TabIndex = 55;
            BtnAllContact.Text = "All Contact";
            BtnAllContact.UseVisualStyleBackColor = true;
            BtnAllContact.Click += BtnAllContact_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(CbCompensation);
            groupBox3.Controls.Add(txtPad2PinY);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(TxtZDownPosition);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(txtPad2PinX);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(TxtZUpPosition);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(txtEncodeX);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(txtEncodeR);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(txtEncodeY);
            groupBox3.Controls.Add(txtEncodeZ);
            groupBox3.Location = new Point(814, 188);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(421, 170);
            groupBox3.TabIndex = 64;
            groupBox3.TabStop = false;
            groupBox3.Text = "Current Machine Position";
            // 
            // CbCompensation
            // 
            CbCompensation.AutoSize = true;
            CbCompensation.Checked = true;
            CbCompensation.CheckState = CheckState.Checked;
            CbCompensation.Location = new Point(49, 17);
            CbCompensation.Name = "CbCompensation";
            CbCompensation.Size = new Size(111, 21);
            CbCompensation.TabIndex = 68;
            CbCompensation.Text = "Compensation";
            CbCompensation.UseVisualStyleBackColor = true;
            // 
            // txtPad2PinY
            // 
            txtPad2PinY.Location = new Point(242, 131);
            txtPad2PinY.Name = "txtPad2PinY";
            txtPad2PinY.ReadOnly = true;
            txtPad2PinY.Size = new Size(81, 23);
            txtPad2PinY.TabIndex = 67;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 134);
            label4.Name = "label4";
            label4.Size = new Size(19, 17);
            label4.TabIndex = 57;
            label4.Text = "R:";
            // 
            // TxtZDownPosition
            // 
            TxtZDownPosition.Location = new Point(242, 71);
            TxtZDownPosition.Name = "TxtZDownPosition";
            TxtZDownPosition.ReadOnly = true;
            TxtZDownPosition.Size = new Size(81, 23);
            TxtZDownPosition.TabIndex = 67;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 104);
            label3.Name = "label3";
            label3.Size = new Size(18, 17);
            label3.TabIndex = 57;
            label3.Text = "Z:";
            // 
            // txtPad2PinX
            // 
            txtPad2PinX.Location = new Point(242, 101);
            txtPad2PinX.Name = "txtPad2PinX";
            txtPad2PinX.ReadOnly = true;
            txtPad2PinX.Size = new Size(81, 23);
            txtPad2PinX.TabIndex = 67;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 74);
            label2.Name = "label2";
            label2.Size = new Size(18, 17);
            label2.TabIndex = 57;
            label2.Text = "Y:";
            // 
            // TxtZUpPosition
            // 
            TxtZUpPosition.Location = new Point(242, 42);
            TxtZUpPosition.Name = "TxtZUpPosition";
            TxtZUpPosition.ReadOnly = true;
            TxtZUpPosition.Size = new Size(81, 23);
            TxtZUpPosition.TabIndex = 67;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(180, 134);
            label8.Name = "label8";
            label8.Size = new Size(63, 17);
            label8.TabIndex = 66;
            label8.Text = "pad2pinY";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 44);
            label1.Name = "label1";
            label1.Size = new Size(19, 17);
            label1.TabIndex = 57;
            label1.Text = "X:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(186, 77);
            label6.Name = "label6";
            label6.Size = new Size(52, 17);
            label6.TabIndex = 66;
            label6.Text = "Z Down";
            // 
            // txtEncodeX
            // 
            txtEncodeX.Location = new Point(49, 41);
            txtEncodeX.Name = "txtEncodeX";
            txtEncodeX.RightToLeft = RightToLeft.No;
            txtEncodeX.Size = new Size(100, 23);
            txtEncodeX.TabIndex = 56;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(179, 107);
            label7.Name = "label7";
            label7.Size = new Size(64, 17);
            label7.TabIndex = 66;
            label7.Text = "pad2pinX";
            // 
            // txtEncodeR
            // 
            txtEncodeR.Location = new Point(49, 131);
            txtEncodeR.Name = "txtEncodeR";
            txtEncodeR.RightToLeft = RightToLeft.No;
            txtEncodeR.Size = new Size(100, 23);
            txtEncodeR.TabIndex = 53;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(200, 48);
            label5.Name = "label5";
            label5.Size = new Size(36, 17);
            label5.TabIndex = 66;
            label5.Text = "Z Up";
            // 
            // txtEncodeY
            // 
            txtEncodeY.Location = new Point(49, 71);
            txtEncodeY.Name = "txtEncodeY";
            txtEncodeY.RightToLeft = RightToLeft.No;
            txtEncodeY.Size = new Size(100, 23);
            txtEncodeY.TabIndex = 55;
            // 
            // txtEncodeZ
            // 
            txtEncodeZ.Location = new Point(49, 101);
            txtEncodeZ.Name = "txtEncodeZ";
            txtEncodeZ.RightToLeft = RightToLeft.No;
            txtEncodeZ.Size = new Size(100, 23);
            txtEncodeZ.TabIndex = 54;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(TxtFirstContact);
            groupBox4.Controls.Add(BtnAllContact);
            groupBox4.Controls.Add(BtnFirstContact);
            groupBox4.Controls.Add(TxtAllContact);
            groupBox4.Location = new Point(814, 549);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(221, 109);
            groupBox4.TabIndex = 65;
            groupBox4.TabStop = false;
            groupBox4.Text = "Setup Contact Height";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(panel2);
            groupBox5.Location = new Point(814, 5);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(418, 177);
            groupBox5.TabIndex = 68;
            groupBox5.TabStop = false;
            groupBox5.Text = "Current Index Coordinate";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Black;
            panel2.Location = new Point(4, 21);
            panel2.Name = "panel2";
            panel2.Size = new Size(208, 121);
            panel2.TabIndex = 0;
            // 
            // BtnShowZRepeatUtility
            // 
            BtnShowZRepeatUtility.BackColor = Color.Orange;
            BtnShowZRepeatUtility.Location = new Point(814, 740);
            BtnShowZRepeatUtility.Name = "BtnShowZRepeatUtility";
            BtnShowZRepeatUtility.Size = new Size(129, 62);
            BtnShowZRepeatUtility.TabIndex = 69;
            BtnShowZRepeatUtility.Text = "Show Z Repeat Utility";
            BtnShowZRepeatUtility.UseVisualStyleBackColor = false;
            BtnShowZRepeatUtility.Click += BtnShowZRepeatUtility_Click;
            // 
            // CbWithPmi
            // 
            CbWithPmi.AutoSize = true;
            CbWithPmi.Location = new Point(814, 713);
            CbWithPmi.Name = "CbWithPmi";
            CbWithPmi.Size = new Size(80, 21);
            CbWithPmi.TabIndex = 70;
            CbWithPmi.Text = "With PMI";
            CbWithPmi.UseVisualStyleBackColor = true;
            // 
            // ProbingControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            Controls.Add(CbWithPmi);
            Controls.Add(BtnShowZRepeatUtility);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(BtnReset);
            Controls.Add(BtnWaferPinAlign);
            Controls.Add(BtnApply);
            Controls.Add(BtnInspection);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            Name = "ProbingControl";
            Size = new Size(1348, 805);
            Load += ProbingControl_Load;
            ParentChanged += ProbingControl_ParentChanged;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button BtnWaferPinAlign;
        private Button BtnInspection;
        private GroupBox groupBox2;
        private RadioButton Rbtn5um;
        private RadioButton Rbtn1um;
        private Button BtnJogDown;
        private Button BtnJogUp;
        private TextBox TxtAllContact;
        private GroupBox groupBox1;
        private Button BtnSetOverDrive;
        private Button BtnZToggle;
        private TextBox TxtOverDrive;
        private Button BtnDown;
        private Button BtnUp;
        private TextBox TxtFirstContact;
        private Button BtnApply;
        private Button BtnReset;
        private Button BtnFirstContact;
        private Button BtnAllContact;
        private GroupBox groupBox3;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtEncodeX;
        private TextBox txtEncodeR;
        private TextBox txtEncodeY;
        private TextBox txtEncodeZ;
        private GroupBox groupBox4;
        private Label label5;
        private Label label6;
        private TextBox TxtZUpPosition;
        private TextBox TxtZDownPosition;
        private System.Windows.Forms.Timer timer1;
        private CheckBox CbCompensation;
        private Label label7;
        private Label label8;
        private TextBox txtPad2PinX;
        private TextBox txtPad2PinY;
        private GroupBox groupBox5;
        private Panel panel2;
        private Button BtnShowZRepeatUtility;
        private CheckBox CbWithPmi;
    }
}
