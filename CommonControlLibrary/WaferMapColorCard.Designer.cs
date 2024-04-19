namespace CommonComponentLibrary
{
    partial class WaferMapColorCard
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
            Card.Image?.Dispose();
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
            Card = new PictureBox();
            borderedLabel2 = new BorderedLabel();
            borderedLabel1 = new BorderedLabel();
            borderedLabel3 = new BorderedLabel();
            borderedLabel4 = new BorderedLabel();
            borderedLabel5 = new BorderedLabel();
            borderedLabel6 = new BorderedLabel();
            borderedLabel7 = new BorderedLabel();
            borderedLabel8 = new BorderedLabel();
            borderedLabel9 = new BorderedLabel();
            ((System.ComponentModel.ISupportInitialize)Card).BeginInit();
            SuspendLayout();
            // 
            // Card
            // 
            Card.Location = new Point(3, 2);
            Card.Name = "Card";
            Card.Size = new Size(84, 145);
            Card.TabIndex = 0;
            Card.TabStop = false;
            // 
            // borderedLabel2
            // 
            borderedLabel2.AutoSize = true;
            borderedLabel2.BackColor = SystemColors.Control;
            borderedLabel2.Location = new Point(93, 2);
            borderedLabel2.MaximumSize = new Size(87, 17);
            borderedLabel2.MinimumSize = new Size(87, 17);
            borderedLabel2.Name = "borderedLabel2";
            borderedLabel2.Size = new Size(87, 17);
            borderedLabel2.TabIndex = 3;
            borderedLabel2.Text = "NOT EXIST";
            // 
            // borderedLabel1
            // 
            borderedLabel1.AutoSize = true;
            borderedLabel1.BackColor = SystemColors.Control;
            borderedLabel1.Location = new Point(93, 18);
            borderedLabel1.MaximumSize = new Size(87, 17);
            borderedLabel1.MinimumSize = new Size(87, 17);
            borderedLabel1.Name = "borderedLabel1";
            borderedLabel1.Size = new Size(87, 17);
            borderedLabel1.TabIndex = 4;
            borderedLabel1.Text = "TEST DIE";
            // 
            // borderedLabel3
            // 
            borderedLabel3.AutoSize = true;
            borderedLabel3.BackColor = SystemColors.Control;
            borderedLabel3.Location = new Point(93, 34);
            borderedLabel3.MaximumSize = new Size(87, 17);
            borderedLabel3.MinimumSize = new Size(87, 17);
            borderedLabel3.Name = "borderedLabel3";
            borderedLabel3.Size = new Size(87, 17);
            borderedLabel3.TabIndex = 5;
            borderedLabel3.Text = "SKIP DIE";
            // 
            // borderedLabel4
            // 
            borderedLabel4.AutoSize = true;
            borderedLabel4.BackColor = SystemColors.Control;
            borderedLabel4.Location = new Point(93, 50);
            borderedLabel4.MaximumSize = new Size(87, 17);
            borderedLabel4.MinimumSize = new Size(87, 17);
            borderedLabel4.Name = "borderedLabel4";
            borderedLabel4.Size = new Size(87, 17);
            borderedLabel4.TabIndex = 6;
            borderedLabel4.Text = "MARK DIE";
            // 
            // borderedLabel5
            // 
            borderedLabel5.AutoSize = true;
            borderedLabel5.BackColor = SystemColors.Control;
            borderedLabel5.Location = new Point(93, 66);
            borderedLabel5.MaximumSize = new Size(87, 17);
            borderedLabel5.MinimumSize = new Size(87, 17);
            borderedLabel5.Name = "borderedLabel5";
            borderedLabel5.Size = new Size(87, 17);
            borderedLabel5.TabIndex = 7;
            borderedLabel5.Text = "PASS DIE";
            // 
            // borderedLabel6
            // 
            borderedLabel6.AutoSize = true;
            borderedLabel6.BackColor = SystemColors.Control;
            borderedLabel6.Location = new Point(93, 82);
            borderedLabel6.MaximumSize = new Size(87, 17);
            borderedLabel6.MinimumSize = new Size(87, 17);
            borderedLabel6.Name = "borderedLabel6";
            borderedLabel6.Size = new Size(87, 17);
            borderedLabel6.TabIndex = 8;
            borderedLabel6.Text = "FAIL DIE";
            // 
            // borderedLabel7
            // 
            borderedLabel7.AutoSize = true;
            borderedLabel7.BackColor = SystemColors.Control;
            borderedLabel7.Location = new Point(93, 98);
            borderedLabel7.MaximumSize = new Size(87, 17);
            borderedLabel7.MinimumSize = new Size(87, 17);
            borderedLabel7.Name = "borderedLabel7";
            borderedLabel7.Size = new Size(87, 17);
            borderedLabel7.TabIndex = 9;
            borderedLabel7.Text = "CUR DIE";
            // 
            // borderedLabel8
            // 
            borderedLabel8.AutoSize = true;
            borderedLabel8.BackColor = SystemColors.Control;
            borderedLabel8.Location = new Point(93, 114);
            borderedLabel8.MaximumSize = new Size(87, 17);
            borderedLabel8.MinimumSize = new Size(87, 17);
            borderedLabel8.Name = "borderedLabel8";
            borderedLabel8.Size = new Size(87, 17);
            borderedLabel8.TabIndex = 10;
            borderedLabel8.Text = "TEACH DIE";
            // 
            // borderedLabel9
            // 
            borderedLabel9.AutoSize = true;
            borderedLabel9.BackColor = SystemColors.Control;
            borderedLabel9.Location = new Point(93, 130);
            borderedLabel9.MaximumSize = new Size(87, 17);
            borderedLabel9.MinimumSize = new Size(87, 17);
            borderedLabel9.Name = "borderedLabel9";
            borderedLabel9.Size = new Size(87, 17);
            borderedLabel9.TabIndex = 11;
            borderedLabel9.Text = "SAMPLE DIE";
            // 
            // WaferMapColorCard
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(52, 52, 52);
            Controls.Add(borderedLabel9);
            Controls.Add(borderedLabel8);
            Controls.Add(borderedLabel7);
            Controls.Add(borderedLabel6);
            Controls.Add(borderedLabel5);
            Controls.Add(borderedLabel4);
            Controls.Add(borderedLabel3);
            Controls.Add(borderedLabel1);
            Controls.Add(borderedLabel2);
            Controls.Add(Card);
            Name = "WaferMapColorCard";
            Size = new Size(182, 149);
            Load += WaferMapColorCarControl_Load;
            ((System.ComponentModel.ISupportInitialize)Card).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox Card;
        private BorderedLabel borderedLabel2;
        private BorderedLabel borderedLabel1;
        private BorderedLabel borderedLabel3;
        private BorderedLabel borderedLabel4;
        private BorderedLabel borderedLabel5;
        private BorderedLabel borderedLabel6;
        private BorderedLabel borderedLabel7;
        private BorderedLabel borderedLabel8;
        private BorderedLabel borderedLabel9;
    }
}
