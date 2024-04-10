namespace MainForm
{
    partial class EdgeDetectionControl
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
            groupBox1 = new GroupBox();
            NumThreshold = new NumericUpDown();
            groupBox2 = new GroupBox();
            NumLight = new NumericUpDown();
            groupBox3 = new GroupBox();
            NumAuxLight = new NumericUpDown();
            BtnToEdge = new Button();
            BtnAutoDetectWaferCenter = new Button();
            lblWaferCenterFlag = new Label();
            lblWaferCenterX = new TextBox();
            lblWaferCenterY = new TextBox();
            Blob = new Button();
            Apply = new Button();
            Close = new Button();
            Filter = new TextBox();
            label1 = new Label();
            BtnToCenter = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumThreshold).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumLight).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumAuxLight).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(NumThreshold);
            groupBox1.Location = new Point(10, 35);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(87, 130);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Threshold";
            // 
            // NumThreshold
            // 
            NumThreshold.Font = new Font("Microsoft YaHei UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            NumThreshold.Location = new Point(6, 31);
            NumThreshold.Name = "NumThreshold";
            NumThreshold.Size = new Size(61, 38);
            NumThreshold.TabIndex = 6;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(NumLight);
            groupBox2.Location = new Point(103, 35);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(81, 130);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Light";
            // 
            // NumLight
            // 
            NumLight.Font = new Font("Microsoft YaHei UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            NumLight.Location = new Point(7, 31);
            NumLight.Name = "NumLight";
            NumLight.Size = new Size(61, 38);
            NumLight.TabIndex = 6;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(NumAuxLight);
            groupBox3.Location = new Point(190, 35);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(80, 130);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "Aux Light";
            // 
            // NumAuxLight
            // 
            NumAuxLight.Font = new Font("Microsoft YaHei UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            NumAuxLight.Location = new Point(6, 31);
            NumAuxLight.Name = "NumAuxLight";
            NumAuxLight.Size = new Size(61, 38);
            NumAuxLight.TabIndex = 6;
            // 
            // BtnToEdge
            // 
            BtnToEdge.Location = new Point(276, 15);
            BtnToEdge.Name = "BtnToEdge";
            BtnToEdge.Size = new Size(75, 44);
            BtnToEdge.TabIndex = 1;
            BtnToEdge.Text = "To Edge";
            BtnToEdge.UseVisualStyleBackColor = true;
            BtnToEdge.Click += BtnToEdge_Click;
            // 
            // BtnAutoDetectWaferCenter
            // 
            BtnAutoDetectWaferCenter.Location = new Point(276, 66);
            BtnAutoDetectWaferCenter.Name = "BtnAutoDetectWaferCenter";
            BtnAutoDetectWaferCenter.Size = new Size(75, 83);
            BtnAutoDetectWaferCenter.TabIndex = 1;
            BtnAutoDetectWaferCenter.Text = "Auto Detect Wafer Center";
            BtnAutoDetectWaferCenter.UseVisualStyleBackColor = true;
            BtnAutoDetectWaferCenter.Click += BtnAutoDetectWaferCenter_Click;
            // 
            // lblWaferCenterFlag
            // 
            lblWaferCenterFlag.AutoSize = true;
            lblWaferCenterFlag.BackColor = Color.Green;
            lblWaferCenterFlag.Location = new Point(10, 15);
            lblWaferCenterFlag.Name = "lblWaferCenterFlag";
            lblWaferCenterFlag.Size = new Size(205, 17);
            lblWaferCenterFlag.TabIndex = 2;
            lblWaferCenterFlag.Text = "Edge Detection Parameter Setting";
            // 
            // lblWaferCenterX
            // 
            lblWaferCenterX.Location = new Point(260, 213);
            lblWaferCenterX.Name = "lblWaferCenterX";
            lblWaferCenterX.Size = new Size(100, 23);
            lblWaferCenterX.TabIndex = 3;
            // 
            // lblWaferCenterY
            // 
            lblWaferCenterY.Location = new Point(260, 242);
            lblWaferCenterY.Name = "lblWaferCenterY";
            lblWaferCenterY.Size = new Size(100, 23);
            lblWaferCenterY.TabIndex = 3;
            // 
            // Blob
            // 
            Blob.Location = new Point(51, 184);
            Blob.Name = "Blob";
            Blob.Size = new Size(62, 52);
            Blob.TabIndex = 0;
            Blob.Text = "Blob";
            Blob.UseVisualStyleBackColor = true;
            // 
            // Apply
            // 
            Apply.Location = new Point(119, 184);
            Apply.Name = "Apply";
            Apply.Size = new Size(52, 52);
            Apply.TabIndex = 0;
            Apply.Text = "Apply";
            Apply.UseVisualStyleBackColor = true;
            // 
            // Close
            // 
            Close.Location = new Point(179, 184);
            Close.Name = "Close";
            Close.Size = new Size(59, 52);
            Close.TabIndex = 0;
            Close.Text = "Close";
            Close.UseVisualStyleBackColor = true;
            Close.Click += Close_Click;
            // 
            // Filter
            // 
            Filter.Location = new Point(10, 213);
            Filter.Name = "Filter";
            Filter.Size = new Size(35, 23);
            Filter.TabIndex = 4;
            Filter.Text = "1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 187);
            label1.Name = "label1";
            label1.Size = new Size(36, 17);
            label1.TabIndex = 5;
            label1.Text = "Filter";
            // 
            // BtnToCenter
            // 
            BtnToCenter.Location = new Point(276, 155);
            BtnToCenter.Name = "BtnToCenter";
            BtnToCenter.Size = new Size(75, 44);
            BtnToCenter.TabIndex = 1;
            BtnToCenter.Text = "ToCenter";
            BtnToCenter.UseVisualStyleBackColor = true;
            BtnToCenter.Click += BtnToCenter_Click;
            // 
            // EdgeDetectionControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(label1);
            Controls.Add(Filter);
            Controls.Add(lblWaferCenterY);
            Controls.Add(lblWaferCenterX);
            Controls.Add(Close);
            Controls.Add(Apply);
            Controls.Add(Blob);
            Controls.Add(lblWaferCenterFlag);
            Controls.Add(BtnAutoDetectWaferCenter);
            Controls.Add(BtnToCenter);
            Controls.Add(BtnToEdge);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "EdgeDetectionControl";
            Size = new Size(363, 292);
            Load += EdgeDetectionControl_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)NumThreshold).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)NumLight).EndInit();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)NumAuxLight).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Button BtnToEdge;
        private Button BtnAutoDetectWaferCenter;
        private Label lblWaferCenterFlag;
        private TextBox lblWaferCenterX;
        private TextBox lblWaferCenterY;
        private Button Blob;
        private Button Apply;
        private Button Close;
        private TextBox Filter;
        private Label label1;
        private Button BtnToCenter;
        private NumericUpDown NumThreshold;
        private NumericUpDown NumLight;
        private NumericUpDown NumAuxLight;
    }
}
