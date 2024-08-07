﻿using WaferMapLibrary;

namespace CommonComponentLibrary
{
    partial class WaferMapIndexControl
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
            WaferMap.OnIndexChange -= onIndexChange;
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
            BtnUp = new Button();
            BtnDown = new Button();
            BtnLeft = new Button();
            BtnRight = new Button();
            BtnEnter = new Button();
            TxtIndexX = new TextBox();
            TxtIndexY = new TextBox();
            label1 = new Label();
            label2 = new Label();
            BtnPinPadMatch = new Button();
            SuspendLayout();
            // 
            // BtnUp
            // 
            BtnUp.Location = new Point(119, 3);
            BtnUp.Name = "BtnUp";
            BtnUp.Size = new Size(40, 40);
            BtnUp.TabIndex = 0;
            BtnUp.Text = "Up";
            BtnUp.UseVisualStyleBackColor = true;
            BtnUp.Click += BtnUp_Click;
            // 
            // BtnDown
            // 
            BtnDown.Location = new Point(119, 46);
            BtnDown.Name = "BtnDown";
            BtnDown.Size = new Size(40, 40);
            BtnDown.TabIndex = 0;
            BtnDown.Text = "Dn";
            BtnDown.UseVisualStyleBackColor = true;
            BtnDown.Click += BtnDown_Click;
            // 
            // BtnLeft
            // 
            BtnLeft.Location = new Point(76, 45);
            BtnLeft.Name = "BtnLeft";
            BtnLeft.Size = new Size(40, 40);
            BtnLeft.TabIndex = 0;
            BtnLeft.Text = "LF";
            BtnLeft.UseVisualStyleBackColor = true;
            BtnLeft.Click += BtnLeft_Click;
            // 
            // BtnRight
            // 
            BtnRight.Location = new Point(162, 46);
            BtnRight.Name = "BtnRight";
            BtnRight.Size = new Size(40, 40);
            BtnRight.TabIndex = 0;
            BtnRight.Text = "RT";
            BtnRight.UseVisualStyleBackColor = true;
            BtnRight.Click += BtnRight_Click;
            // 
            // BtnEnter
            // 
            BtnEnter.BackColor = Color.Orange;
            BtnEnter.Location = new Point(3, 87);
            BtnEnter.Name = "BtnEnter";
            BtnEnter.Size = new Size(95, 40);
            BtnEnter.TabIndex = 0;
            BtnEnter.Text = "Go To Die";
            BtnEnter.UseVisualStyleBackColor = false;
            BtnEnter.Click += BtnEnter_Click;
            // 
            // TxtIndexX
            // 
            TxtIndexX.Location = new Point(24, 12);
            TxtIndexX.Name = "TxtIndexX";
            TxtIndexX.Size = new Size(42, 23);
            TxtIndexX.TabIndex = 1;
            // 
            // TxtIndexY
            // 
            TxtIndexY.Location = new Point(24, 46);
            TxtIndexY.Name = "TxtIndexY";
            TxtIndexY.Size = new Size(42, 23);
            TxtIndexY.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(5, 18);
            label1.Name = "label1";
            label1.Size = new Size(16, 17);
            label1.TabIndex = 2;
            label1.Text = "X";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 49);
            label2.Name = "label2";
            label2.Size = new Size(15, 17);
            label2.TabIndex = 2;
            label2.Text = "Y";
            // 
            // BtnPinPadMatch
            // 
            BtnPinPadMatch.BackColor = Color.Orange;
            BtnPinPadMatch.Location = new Point(101, 87);
            BtnPinPadMatch.Name = "BtnPinPadMatch";
            BtnPinPadMatch.Size = new Size(101, 40);
            BtnPinPadMatch.TabIndex = 59;
            BtnPinPadMatch.Text = "Pin Pad Match_With_Move";
            BtnPinPadMatch.UseVisualStyleBackColor = false;
            BtnPinPadMatch.Click += BtnPinPadMatch_Click;
            // 
            // WaferMapIndexControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            Controls.Add(BtnPinPadMatch);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(TxtIndexY);
            Controls.Add(TxtIndexX);
            Controls.Add(BtnEnter);
            Controls.Add(BtnRight);
            Controls.Add(BtnLeft);
            Controls.Add(BtnDown);
            Controls.Add(BtnUp);
            Name = "WaferMapIndexControl";
            Size = new Size(207, 130);
            Load += WaferMapIndexControl_Load;
            Paint += WaferMapIndexControl_Paint;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnUp;
        private Button BtnDown;
        private Button BtnLeft;
        private Button BtnRight;
        private Button BtnEnter;
        private TextBox TxtIndexX;
        private TextBox TxtIndexY;
        private Label label1;
        private Label label2;
        private Button BtnPinPadMatch;
    }
}
