namespace ErrorCompensation
{
    partial class ErrorCanvas
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
            pbX = new PictureBox();
            panelMap = new Panel();
            pbY = new PictureBox();
            BtnResetErrorTable = new Button();
            BtnClearPicturebox = new Button();
            BtnSim = new Button();
            ((System.ComponentModel.ISupportInitialize)pbX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbY).BeginInit();
            SuspendLayout();
            // 
            // pbX
            // 
            pbX.BorderStyle = BorderStyle.FixedSingle;
            pbX.Location = new Point(93, 7);
            pbX.Name = "pbX";
            pbX.Size = new Size(750, 200);
            pbX.TabIndex = 67;
            pbX.TabStop = false;
            // 
            // panelMap
            // 
            panelMap.BackColor = Color.Black;
            panelMap.Location = new Point(93, 213);
            panelMap.Name = "panelMap";
            panelMap.Size = new Size(750, 750);
            panelMap.TabIndex = 66;
            // 
            // pbY
            // 
            pbY.BorderStyle = BorderStyle.FixedSingle;
            pbY.Location = new Point(864, 213);
            pbY.Name = "pbY";
            pbY.Size = new Size(200, 750);
            pbY.TabIndex = 68;
            pbY.TabStop = false;
            // 
            // BtnResetErrorTable
            // 
            BtnResetErrorTable.BackColor = Color.Red;
            BtnResetErrorTable.Location = new Point(864, 92);
            BtnResetErrorTable.Name = "BtnResetErrorTable";
            BtnResetErrorTable.Size = new Size(95, 53);
            BtnResetErrorTable.TabIndex = 75;
            BtnResetErrorTable.Text = "Reset Error Table";
            BtnResetErrorTable.UseVisualStyleBackColor = false;
            // 
            // BtnClearPicturebox
            // 
            BtnClearPicturebox.Location = new Point(864, 151);
            BtnClearPicturebox.Name = "BtnClearPicturebox";
            BtnClearPicturebox.Size = new Size(99, 56);
            BtnClearPicturebox.TabIndex = 73;
            BtnClearPicturebox.Text = "Refresh";
            BtnClearPicturebox.UseVisualStyleBackColor = true;
            BtnClearPicturebox.Click += BtnClearPicturebox_Click;
            // 
            // BtnSim
            // 
            BtnSim.Location = new Point(969, 151);
            BtnSim.Name = "BtnSim";
            BtnSim.Size = new Size(95, 56);
            BtnSim.TabIndex = 74;
            BtnSim.Text = "Simulation";
            BtnSim.UseVisualStyleBackColor = true;
            // 
            // ErrorCanvas
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            Controls.Add(BtnResetErrorTable);
            Controls.Add(BtnClearPicturebox);
            Controls.Add(BtnSim);
            Controls.Add(pbX);
            Controls.Add(panelMap);
            Controls.Add(pbY);
            Name = "ErrorCanvas";
            Size = new Size(1078, 960);
            Load += ErrorCanvas_Load;
            ((System.ComponentModel.ISupportInitialize)pbX).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbY).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbX;
        private Panel panelMap;
        private PictureBox pbY;
        private Button BtnResetErrorTable;
        private Button BtnClearPicturebox;
        private Button BtnSim;
    }
}
