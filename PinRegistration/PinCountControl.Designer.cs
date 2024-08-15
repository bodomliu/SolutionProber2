namespace PinRegistration
{
    partial class PinCountControl
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
            label1 = new Label();
            label2 = new Label();
            Total_PinCount = new Label();
            label4 = new Label();
            label5 = new Label();
            Passed_PinCount = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(0, 192, 0);
            label1.Location = new Point(6, 10);
            label1.Name = "label1";
            label1.Size = new Size(43, 20);
            label1.TabIndex = 0;
            label1.Text = "Total";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(0, 192, 0);
            label2.Location = new Point(6, 40);
            label2.Name = "label2";
            label2.Size = new Size(76, 20);
            label2.TabIndex = 1;
            label2.Text = "Pin Count";
            // 
            // Total_PinCount
            // 
            Total_PinCount.AutoSize = true;
            Total_PinCount.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Total_PinCount.ForeColor = Color.FromArgb(0, 192, 0);
            Total_PinCount.Location = new Point(6, 69);
            Total_PinCount.Name = "Total_PinCount";
            Total_PinCount.Size = new Size(17, 20);
            Total_PinCount.TabIndex = 2;
            Total_PinCount.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.FromArgb(0, 192, 0);
            label4.Location = new Point(6, 100);
            label4.Name = "label4";
            label4.Size = new Size(55, 20);
            label4.TabIndex = 3;
            label4.Text = "Passed";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.FromArgb(0, 192, 0);
            label5.Location = new Point(6, 133);
            label5.Name = "label5";
            label5.Size = new Size(76, 20);
            label5.TabIndex = 4;
            label5.Text = "Pin Count";
            // 
            // Passed_PinCount
            // 
            Passed_PinCount.AutoSize = true;
            Passed_PinCount.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Passed_PinCount.ForeColor = Color.FromArgb(0, 192, 0);
            Passed_PinCount.Location = new Point(6, 164);
            Passed_PinCount.Name = "Passed_PinCount";
            Passed_PinCount.Size = new Size(17, 20);
            Passed_PinCount.TabIndex = 5;
            Passed_PinCount.Text = "0";
            // 
            // PinCountControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(Passed_PinCount);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(Total_PinCount);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "PinCountControl";
            Size = new Size(97, 208);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label Total_PinCount;
        private Label label4;
        private Label label5;
        private Label Passed_PinCount;
    }
}
