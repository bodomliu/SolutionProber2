namespace UtilityForm
{
    partial class GT2Control
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
            btnStart = new Button();
            btnEnd = new Button();
            lblStatus = new Label();
            txtValue = new TextBox();
            timer1 = new System.Windows.Forms.Timer(components);
            txtInterval = new TextBox();
            label1 = new Label();
            btnTrigger = new Button();
            btnConnect = new Button();
            txtIP = new TextBox();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(9, 135);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnEnd
            // 
            btnEnd.Location = new Point(99, 135);
            btnEnd.Name = "btnEnd";
            btnEnd.Size = new Size(75, 23);
            btnEnd.TabIndex = 1;
            btnEnd.Text = "End";
            btnEnd.UseVisualStyleBackColor = true;
            btnEnd.Click += btnEnd_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(9, 175);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(43, 17);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "label1";
            // 
            // txtValue
            // 
            txtValue.Location = new Point(9, 51);
            txtValue.Name = "txtValue";
            txtValue.Size = new Size(150, 23);
            txtValue.TabIndex = 3;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // txtInterval
            // 
            txtInterval.Location = new Point(9, 106);
            txtInterval.Name = "txtInterval";
            txtInterval.Size = new Size(100, 23);
            txtInterval.TabIndex = 4;
            txtInterval.Text = "5000";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(116, 111);
            label1.Name = "label1";
            label1.Size = new Size(25, 17);
            label1.TabIndex = 5;
            label1.Text = "ms";
            // 
            // btnTrigger
            // 
            btnTrigger.Enabled = false;
            btnTrigger.Location = new Point(165, 51);
            btnTrigger.Name = "btnTrigger";
            btnTrigger.Size = new Size(75, 23);
            btnTrigger.TabIndex = 6;
            btnTrigger.Text = "Trigger";
            btnTrigger.UseVisualStyleBackColor = true;
            btnTrigger.Click += btnTrigger_Click;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(165, 22);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(75, 23);
            btnConnect.TabIndex = 7;
            btnConnect.Text = "connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // txtIP
            // 
            txtIP.Location = new Point(9, 22);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(150, 23);
            txtIP.TabIndex = 3;
            txtIP.Text = "192.168.1.4";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnConnect);
            groupBox1.Controls.Add(btnStart);
            groupBox1.Controls.Add(btnTrigger);
            groupBox1.Controls.Add(btnEnd);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(lblStatus);
            groupBox1.Controls.Add(txtInterval);
            groupBox1.Controls.Add(txtValue);
            groupBox1.Controls.Add(txtIP);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(314, 202);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "GT2";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(flowLayoutPanel1);
            groupBox2.Location = new Point(3, 212);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(456, 302);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Invar36";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(3, 19);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(450, 280);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // GT2Control
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "GT2Control";
            Size = new Size(468, 578);
            Load += GT2Control_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnStart;
        private Button btnEnd;
        private Label lblStatus;
        private TextBox txtValue;
        private System.Windows.Forms.Timer timer1;
        private TextBox txtInterval;
        private Label label1;
        private Button btnTrigger;
        private Button btnConnect;
        private TextBox txtIP;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button BtnToPos1;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}
