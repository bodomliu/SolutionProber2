namespace PinRegistration
{
    partial class PinMagControl
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
            BtnLowMag = new Button();
            BtnHighMag = new Button();
            SuspendLayout();
            // 
            // BtnLowMag
            // 
            BtnLowMag.BackColor = Color.Teal;
            BtnLowMag.ForeColor = Color.White;
            BtnLowMag.Location = new Point(128, 1);
            BtnLowMag.Name = "BtnLowMag";
            BtnLowMag.Size = new Size(120, 80);
            BtnLowMag.TabIndex = 23;
            BtnLowMag.Text = "LowMag";
            BtnLowMag.UseVisualStyleBackColor = false;
            BtnLowMag.VisibleChanged += BtnLowMag_VisibleChanged;
            BtnLowMag.Click += BtnLowMag_Click;
            // 
            // BtnHighMag
            // 
            BtnHighMag.BackColor = Color.Teal;
            BtnHighMag.ForeColor = Color.White;
            BtnHighMag.Location = new Point(2, 1);
            BtnHighMag.Name = "BtnHighMag";
            BtnHighMag.Size = new Size(120, 80);
            BtnHighMag.TabIndex = 24;
            BtnHighMag.Text = "HighMag";
            BtnHighMag.UseVisualStyleBackColor = false;
            BtnHighMag.Click += BtnHighMag_Click;
            // 
            // PinMagControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(BtnLowMag);
            Controls.Add(BtnHighMag);
            Name = "PinMagControl";
            Size = new Size(253, 83);
            Load += PinMagControl_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button BtnLowMag;
        private Button BtnHighMag;
    }
}
