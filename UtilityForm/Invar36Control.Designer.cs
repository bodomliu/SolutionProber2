namespace UtilityForm
{
    partial class Invar36Control
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
            EncodeY = new TextBox();
            EncodeX = new TextBox();
            BtnMatchWithMove = new Button();
            BtnRegPattern = new Button();
            label3 = new Label();
            label2 = new Label();
            BtnMove = new Button();
            label1 = new Label();
            EncodeZ = new TextBox();
            PatternName = new TextBox();
            SuspendLayout();
            // 
            // EncodeY
            // 
            EncodeY.Location = new Point(103, 32);
            EncodeY.Name = "EncodeY";
            EncodeY.Size = new Size(100, 23);
            EncodeY.TabIndex = 7;
            // 
            // EncodeX
            // 
            EncodeX.Location = new Point(103, 3);
            EncodeX.Name = "EncodeX";
            EncodeX.Size = new Size(100, 23);
            EncodeX.TabIndex = 8;
            // 
            // BtnMatchWithMove
            // 
            BtnMatchWithMove.Location = new Point(3, 147);
            BtnMatchWithMove.Name = "BtnMatchWithMove";
            BtnMatchWithMove.Size = new Size(200, 52);
            BtnMatchWithMove.TabIndex = 3;
            BtnMatchWithMove.Text = "Match With Move";
            BtnMatchWithMove.UseVisualStyleBackColor = true;
            BtnMatchWithMove.Click += BtnMatchWithMove_Click;
            // 
            // BtnRegPattern
            // 
            BtnRegPattern.Location = new Point(3, 89);
            BtnRegPattern.Name = "BtnRegPattern";
            BtnRegPattern.Size = new Size(75, 52);
            BtnRegPattern.TabIndex = 4;
            BtnRegPattern.Text = "Reg Pattern";
            BtnRegPattern.UseVisualStyleBackColor = true;
            BtnRegPattern.Click += BtnRegPattern_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(84, 35);
            label3.Name = "label3";
            label3.Size = new Size(15, 17);
            label3.TabIndex = 9;
            label3.Text = "Y";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(84, 6);
            label2.Name = "label2";
            label2.Size = new Size(16, 17);
            label2.TabIndex = 10;
            label2.Text = "X";
            // 
            // BtnMove
            // 
            BtnMove.Location = new Point(3, 6);
            BtnMove.Name = "BtnMove";
            BtnMove.Size = new Size(75, 78);
            BtnMove.TabIndex = 6;
            BtnMove.Text = "Move";
            BtnMove.UseVisualStyleBackColor = true;
            BtnMove.Click += BtnMove_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(84, 64);
            label1.Name = "label1";
            label1.Size = new Size(15, 17);
            label1.TabIndex = 9;
            label1.Text = "Z";
            // 
            // EncodeZ
            // 
            EncodeZ.Location = new Point(103, 61);
            EncodeZ.Name = "EncodeZ";
            EncodeZ.Size = new Size(100, 23);
            EncodeZ.TabIndex = 7;
            // 
            // PatternName
            // 
            PatternName.Location = new Point(84, 104);
            PatternName.Name = "PatternName";
            PatternName.Size = new Size(119, 23);
            PatternName.TabIndex = 7;
            // 
            // Invar36Control
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(PatternName);
            Controls.Add(EncodeZ);
            Controls.Add(EncodeY);
            Controls.Add(EncodeX);
            Controls.Add(BtnMatchWithMove);
            Controls.Add(BtnRegPattern);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(BtnMove);
            Name = "Invar36Control";
            Size = new Size(213, 204);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox EncodeY;
        private TextBox EncodeX;
        private Button BtnMatchWithMove;
        private Button BtnRegPattern;
        private Label label3;
        private Label label2;
        private Button BtnMove;
        private Label label1;
        private TextBox EncodeZ;
        private TextBox PatternName;
    }
}
