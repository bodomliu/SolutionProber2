namespace Inspection
{
    partial class PmiControl
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
            BtnPmiOnSetDie = new Button();
            BtnPmiAll = new Button();
            BtnPmiSetup = new Button();
            label2 = new Label();
            BtnClearResult = new Button();
            BtnShowResult = new Button();
            TxtDeltaX = new TextBox();
            TxtDeltaY = new TextBox();
            label1 = new Label();
            label3 = new Label();
            BtnSave = new Button();
            BtnLoad = new Button();
            BtnSetToRefPmi = new Button();
            SuspendLayout();
            // 
            // BtnPmiOnSetDie
            // 
            BtnPmiOnSetDie.Location = new Point(3, 27);
            BtnPmiOnSetDie.Name = "BtnPmiOnSetDie";
            BtnPmiOnSetDie.Size = new Size(92, 50);
            BtnPmiOnSetDie.TabIndex = 0;
            BtnPmiOnSetDie.Text = "PMI On Set Die";
            BtnPmiOnSetDie.UseVisualStyleBackColor = true;
            BtnPmiOnSetDie.Click += BtnPmiOnSetDie_Click;
            // 
            // BtnPmiAll
            // 
            BtnPmiAll.Location = new Point(3, 83);
            BtnPmiAll.Name = "BtnPmiAll";
            BtnPmiAll.Size = new Size(92, 45);
            BtnPmiAll.TabIndex = 0;
            BtnPmiAll.Text = "PMI All";
            BtnPmiAll.UseVisualStyleBackColor = true;
            BtnPmiAll.Click += BtnPmiAll_Click;
            // 
            // BtnPmiSetup
            // 
            BtnPmiSetup.Location = new Point(3, 134);
            BtnPmiSetup.Name = "BtnPmiSetup";
            BtnPmiSetup.Size = new Size(92, 45);
            BtnPmiSetup.TabIndex = 0;
            BtnPmiSetup.Text = "PMI Setup";
            BtnPmiSetup.UseVisualStyleBackColor = true;
            BtnPmiSetup.Click += BtnPmiSetup_Click;
            // 
            // label2
            // 
            label2.BackColor = Color.YellowGreen;
            label2.Location = new Point(3, 4);
            label2.Name = "label2";
            label2.Size = new Size(193, 20);
            label2.TabIndex = 41;
            label2.Text = "Probe Mark Inspection";
            // 
            // BtnClearResult
            // 
            BtnClearResult.Location = new Point(101, 134);
            BtnClearResult.Name = "BtnClearResult";
            BtnClearResult.Size = new Size(95, 45);
            BtnClearResult.TabIndex = 0;
            BtnClearResult.Text = "Clear Result";
            BtnClearResult.UseVisualStyleBackColor = true;
            BtnClearResult.Click += BtnClearResult_Click;
            // 
            // BtnShowResult
            // 
            BtnShowResult.Location = new Point(101, 82);
            BtnShowResult.Name = "BtnShowResult";
            BtnShowResult.Size = new Size(95, 45);
            BtnShowResult.TabIndex = 42;
            BtnShowResult.Text = "Show Result";
            BtnShowResult.UseVisualStyleBackColor = true;
            BtnShowResult.Click += BtnShowResult_Click;
            // 
            // TxtDeltaX
            // 
            TxtDeltaX.Location = new Point(131, 27);
            TxtDeltaX.Name = "TxtDeltaX";
            TxtDeltaX.ReadOnly = true;
            TxtDeltaX.Size = new Size(65, 23);
            TxtDeltaX.TabIndex = 43;
            // 
            // TxtDeltaY
            // 
            TxtDeltaY.Location = new Point(131, 53);
            TxtDeltaY.Name = "TxtDeltaY";
            TxtDeltaY.ReadOnly = true;
            TxtDeltaY.Size = new Size(65, 23);
            TxtDeltaY.TabIndex = 43;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(103, 30);
            label1.Name = "label1";
            label1.Size = new Size(28, 17);
            label1.TabIndex = 44;
            label1.Text = "X：";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(103, 56);
            label3.Name = "label3";
            label3.Size = new Size(27, 17);
            label3.TabIndex = 44;
            label3.Text = "Y：";
            // 
            // BtnSave
            // 
            BtnSave.Location = new Point(101, 186);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(92, 44);
            BtnSave.TabIndex = 45;
            BtnSave.Text = "Save";
            BtnSave.UseVisualStyleBackColor = true;
            BtnSave.Click += BtnSave_Click;
            // 
            // BtnLoad
            // 
            BtnLoad.Location = new Point(101, 236);
            BtnLoad.Name = "BtnLoad";
            BtnLoad.Size = new Size(92, 44);
            BtnLoad.TabIndex = 45;
            BtnLoad.Text = "Load";
            BtnLoad.UseVisualStyleBackColor = true;
            BtnLoad.Click += BtnLoad_Click;
            // 
            // BtnSetToRefPmi
            // 
            BtnSetToRefPmi.Location = new Point(3, 186);
            BtnSetToRefPmi.Name = "BtnSetToRefPmi";
            BtnSetToRefPmi.Size = new Size(92, 44);
            BtnSetToRefPmi.TabIndex = 45;
            BtnSetToRefPmi.Text = "Set To Ref Pmi";
            BtnSetToRefPmi.UseVisualStyleBackColor = true;
            BtnSetToRefPmi.Click += BtnSetToRefPmi_Click;
            // 
            // PmiControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            Controls.Add(BtnLoad);
            Controls.Add(BtnSetToRefPmi);
            Controls.Add(BtnSave);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(TxtDeltaY);
            Controls.Add(TxtDeltaX);
            Controls.Add(BtnShowResult);
            Controls.Add(label2);
            Controls.Add(BtnClearResult);
            Controls.Add(BtnPmiOnSetDie);
            Controls.Add(BtnPmiAll);
            Controls.Add(BtnPmiSetup);
            Name = "PmiControl";
            Size = new Size(199, 288);
            Load += PmiControl_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnPmiOnSetDie;
        private Button BtnPmiAll;
        private Button BtnPmiSetup;
        private Label label2;
        private Button BtnClearResult;
        private Button BtnShowResult;
        private TextBox TxtDeltaX;
        private TextBox TxtDeltaY;
        private Label label1;
        private Label label3;
        private Button BtnSave;
        private Button BtnLoad;
        private Button BtnSetToRefPmi;
    }
}
