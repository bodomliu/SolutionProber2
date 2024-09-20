namespace PinRegistration
{
    partial class VisionParaControl
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
            label2 = new Label();
            BtnClose = new Button();
            NumMinBlob = new NumericUpDown();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            NumMaxBlob = new NumericUpDown();
            groupBox3 = new GroupBox();
            NumSearchAreaY = new NumericUpDown();
            groupBox4 = new GroupBox();
            NumSearchAreaX = new NumericUpDown();
            groupBox5 = new GroupBox();
            NumThreshold = new NumericUpDown();
            BtnApply = new Button();
            BtnBlob = new Button();
            groupBox6 = new GroupBox();
            NumExposureTime = new NumericUpDown();
            LblArea = new Label();
            groupBox7 = new GroupBox();
            groupBox8 = new GroupBox();
            NumFilter = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)NumMinBlob).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumMaxBlob).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumSearchAreaY).BeginInit();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumSearchAreaX).BeginInit();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumThreshold).BeginInit();
            groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumExposureTime).BeginInit();
            groupBox7.SuspendLayout();
            groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumFilter).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.BackColor = Color.YellowGreen;
            label2.Location = new Point(7, 5);
            label2.Name = "label2";
            label2.Size = new Size(272, 20);
            label2.TabIndex = 41;
            label2.Text = "Vision Parameter Setting";
            // 
            // BtnClose
            // 
            BtnClose.Location = new Point(192, 323);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(87, 63);
            BtnClose.TabIndex = 42;
            BtnClose.Text = "Close";
            BtnClose.UseVisualStyleBackColor = true;
            BtnClose.Click += BtnClose_Click;
            // 
            // NumMinBlob
            // 
            NumMinBlob.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            NumMinBlob.Location = new Point(6, 22);
            NumMinBlob.Name = "NumMinBlob";
            NumMinBlob.Size = new Size(120, 23);
            NumMinBlob.TabIndex = 43;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(NumMinBlob);
            groupBox1.Location = new Point(7, 202);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(133, 55);
            groupBox1.TabIndex = 44;
            groupBox1.TabStop = false;
            groupBox1.Text = "Min Blob Size";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(NumMaxBlob);
            groupBox2.Location = new Point(146, 202);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(133, 55);
            groupBox2.TabIndex = 44;
            groupBox2.TabStop = false;
            groupBox2.Text = "Max Blob Size";
            // 
            // NumMaxBlob
            // 
            NumMaxBlob.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            NumMaxBlob.Location = new Point(6, 22);
            NumMaxBlob.Name = "NumMaxBlob";
            NumMaxBlob.Size = new Size(120, 23);
            NumMaxBlob.TabIndex = 43;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(NumSearchAreaY);
            groupBox3.Location = new Point(146, 141);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(133, 55);
            groupBox3.TabIndex = 44;
            groupBox3.TabStop = false;
            groupBox3.Text = "Search Area Y";
            // 
            // NumSearchAreaY
            // 
            NumSearchAreaY.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            NumSearchAreaY.Location = new Point(6, 22);
            NumSearchAreaY.Name = "NumSearchAreaY";
            NumSearchAreaY.Size = new Size(120, 23);
            NumSearchAreaY.TabIndex = 43;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(NumSearchAreaX);
            groupBox4.Location = new Point(7, 141);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(133, 55);
            groupBox4.TabIndex = 44;
            groupBox4.TabStop = false;
            groupBox4.Text = "Search Area X";
            // 
            // NumSearchAreaX
            // 
            NumSearchAreaX.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            NumSearchAreaX.Location = new Point(6, 22);
            NumSearchAreaX.Name = "NumSearchAreaX";
            NumSearchAreaX.Size = new Size(120, 23);
            NumSearchAreaX.TabIndex = 43;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(NumThreshold);
            groupBox5.Location = new Point(7, 80);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(133, 55);
            groupBox5.TabIndex = 44;
            groupBox5.TabStop = false;
            groupBox5.Text = "Threshold";
            // 
            // NumThreshold
            // 
            NumThreshold.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            NumThreshold.Location = new Point(6, 22);
            NumThreshold.Name = "NumThreshold";
            NumThreshold.Size = new Size(120, 23);
            NumThreshold.TabIndex = 43;
            // 
            // BtnApply
            // 
            BtnApply.Location = new Point(101, 323);
            BtnApply.Name = "BtnApply";
            BtnApply.Size = new Size(85, 63);
            BtnApply.TabIndex = 42;
            BtnApply.Text = "Apply";
            BtnApply.UseVisualStyleBackColor = true;
            BtnApply.Click += BtnApply_Click;
            // 
            // BtnBlob
            // 
            BtnBlob.Location = new Point(7, 323);
            BtnBlob.Name = "BtnBlob";
            BtnBlob.Size = new Size(88, 63);
            BtnBlob.TabIndex = 42;
            BtnBlob.Text = "Blob";
            BtnBlob.UseVisualStyleBackColor = true;
            BtnBlob.Click += BtnBlob_Click;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(NumExposureTime);
            groupBox6.Location = new Point(146, 80);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(133, 55);
            groupBox6.TabIndex = 44;
            groupBox6.TabStop = false;
            groupBox6.Text = "Exposure Time";
            // 
            // NumExposureTime
            // 
            NumExposureTime.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            NumExposureTime.Location = new Point(6, 22);
            NumExposureTime.Name = "NumExposureTime";
            NumExposureTime.Size = new Size(120, 23);
            NumExposureTime.TabIndex = 43;
            // 
            // LblArea
            // 
            LblArea.AutoSize = true;
            LblArea.Location = new Point(6, 19);
            LblArea.Name = "LblArea";
            LblArea.Size = new Size(35, 17);
            LblArea.TabIndex = 45;
            LblArea.Text = "Blob";
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(LblArea);
            groupBox7.Location = new Point(7, 28);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(272, 46);
            groupBox7.TabIndex = 46;
            groupBox7.TabStop = false;
            groupBox7.Text = "Blob Result";
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(NumFilter);
            groupBox8.Location = new Point(7, 262);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(133, 55);
            groupBox8.TabIndex = 44;
            groupBox8.TabStop = false;
            groupBox8.Text = "Filter";
            // 
            // NumFilter
            // 
            NumFilter.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            NumFilter.Location = new Point(6, 22);
            NumFilter.Name = "NumFilter";
            NumFilter.Size = new Size(120, 23);
            NumFilter.TabIndex = 43;
            // 
            // VisionParaControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            BorderStyle = BorderStyle.Fixed3D;
            Controls.Add(groupBox7);
            Controls.Add(groupBox2);
            Controls.Add(groupBox6);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox8);
            Controls.Add(groupBox1);
            Controls.Add(BtnBlob);
            Controls.Add(BtnApply);
            Controls.Add(BtnClose);
            Controls.Add(label2);
            Name = "VisionParaControl";
            Size = new Size(290, 398);
            Load += VisionParaControl_Load;
            ((System.ComponentModel.ISupportInitialize)NumMinBlob).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)NumMaxBlob).EndInit();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)NumSearchAreaY).EndInit();
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)NumSearchAreaX).EndInit();
            groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)NumThreshold).EndInit();
            groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)NumExposureTime).EndInit();
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)NumFilter).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label2;
        private Button BtnClose;
        private NumericUpDown NumMinBlob;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private NumericUpDown NumMaxBlob;
        private GroupBox groupBox3;
        private NumericUpDown NumSearchAreaY;
        private GroupBox groupBox4;
        private NumericUpDown NumSearchAreaX;
        private GroupBox groupBox5;
        private NumericUpDown NumThreshold;
        private Button BtnApply;
        private Button BtnBlob;
        private GroupBox groupBox6;
        private NumericUpDown NumExposureTime;
        private Label LblArea;
        private GroupBox groupBox7;
        private GroupBox groupBox8;
        private NumericUpDown NumFilter;
    }
}
