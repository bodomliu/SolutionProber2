namespace MainForm
{
    partial class StatusBar
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
            panelTime = new Panel();
            lblStage = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelTime
            // 
            panelTime.BorderStyle = BorderStyle.FixedSingle;
            panelTime.Location = new Point(3, 3);
            panelTime.Name = "panelTime";
            panelTime.Size = new Size(200, 54);
            panelTime.TabIndex = 1;
            // 
            // lblStage
            // 
            lblStage.AutoSize = true;
            lblStage.BorderStyle = BorderStyle.FixedSingle;
            lblStage.Font = new Font("微软雅黑", 24F, FontStyle.Bold, GraphicsUnit.Point);
            lblStage.Location = new Point(3, 3);
            lblStage.Name = "lblStage";
            lblStage.Size = new Size(125, 44);
            lblStage.TabIndex = 1;
            lblStage.Text = "STAGE";
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblStage);
            panel1.Location = new Point(206, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(382, 54);
            panel1.TabIndex = 3;
            // 
            // StatusBar
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGray;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(panel1);
            Controls.Add(panelTime);
            Name = "StatusBar";
            Size = new Size(890, 60);
            Load += StatusBar_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTime;
        private System.Windows.Forms.Timer timer1;
        private Label lblStage;
        private Panel panel1;
    }
}
