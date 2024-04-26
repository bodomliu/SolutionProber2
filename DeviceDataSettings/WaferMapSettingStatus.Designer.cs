namespace DeviceDataSettings
{
    partial class WaferMapSettingStatus
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
            statusText = new RichTextBox();
            SuspendLayout();
            // 
            // statusText
            // 
            statusText.Location = new Point(3, 3);
            statusText.Name = "statusText";
            statusText.Size = new Size(280, 264);
            statusText.TabIndex = 1;
            statusText.Text = "";
            // 
            // WaferMapSettingStatus
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(statusText);
            Name = "WaferMapSettingStatus";
            Size = new Size(283, 270);
            Load += WaferMapSettingStatus_Load;
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox statusText;
    }
}
