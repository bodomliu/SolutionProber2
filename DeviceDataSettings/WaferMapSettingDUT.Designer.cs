using WaferMapLibrary;

namespace DeviceDataSettings
{
    partial class WaferMapSettingDUT
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
            DUTData.OnIndexChange -= DUTData_OnIndexChange;
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
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            CardId = new TextBox();
            YSize = new TextBox();
            XSize = new TextBox();
            SiteNum = new TextBox();
            Location = new TextBox();
            ButtonUP = new Button();
            ButtonDown = new Button();
            ButtonLeft = new Button();
            ButtonRight = new Button();
            ButtonAdd = new Button();
            ButtonDelete = new Button();
            ButtonEdit = new Button();
            ButtonEnable = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 27);
            label1.Name = "label1";
            label1.Size = new Size(43, 17);
            label1.TabIndex = 0;
            label1.Text = "X Size";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 55);
            label2.Name = "label2";
            label2.Size = new Size(42, 17);
            label2.TabIndex = 1;
            label2.Text = "Y Size";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(150, 27);
            label3.Name = "label3";
            label3.Size = new Size(61, 17);
            label3.TabIndex = 2;
            label3.Text = "Site Num";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(150, 56);
            label4.Name = "label4";
            label4.Size = new Size(57, 17);
            label4.TabIndex = 3;
            label4.Text = "Location";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(21, 84);
            label5.Name = "label5";
            label5.Size = new Size(53, 17);
            label5.TabIndex = 4;
            label5.Text = "Card ID";
            // 
            // CardId
            // 
            CardId.Location = new Point(80, 79);
            CardId.Name = "CardId";
            CardId.Size = new Size(74, 23);
            CardId.TabIndex = 5;
            // 
            // YSize
            // 
            YSize.Location = new Point(80, 52);
            YSize.Name = "YSize";
            YSize.ReadOnly = true;
            YSize.Size = new Size(44, 23);
            YSize.TabIndex = 6;
            // 
            // XSize
            // 
            XSize.Location = new Point(80, 24);
            XSize.Name = "XSize";
            XSize.ReadOnly = true;
            XSize.Size = new Size(44, 23);
            XSize.TabIndex = 7;
            // 
            // SiteNum
            // 
            SiteNum.Location = new Point(217, 21);
            SiteNum.Name = "SiteNum";
            SiteNum.ReadOnly = true;
            SiteNum.Size = new Size(44, 23);
            SiteNum.TabIndex = 8;
            // 
            // Location
            // 
            Location.Location = new Point(217, 53);
            Location.Name = "Location";
            Location.Size = new Size(44, 23);
            Location.TabIndex = 9;
            // 
            // ButtonUP
            // 
            ButtonUP.Location = new Point(80, 134);
            ButtonUP.Name = "ButtonUP";
            ButtonUP.Size = new Size(38, 33);
            ButtonUP.TabIndex = 10;
            ButtonUP.Text = "UP";
            ButtonUP.UseVisualStyleBackColor = true;
            ButtonUP.Click += ButtonUP_Click;
            // 
            // ButtonDown
            // 
            ButtonDown.Location = new Point(80, 173);
            ButtonDown.Name = "ButtonDown";
            ButtonDown.Size = new Size(38, 33);
            ButtonDown.TabIndex = 11;
            ButtonDown.Text = "DN";
            ButtonDown.UseVisualStyleBackColor = true;
            ButtonDown.Click += ButtonDown_Click;
            // 
            // ButtonLeft
            // 
            ButtonLeft.Location = new Point(36, 173);
            ButtonLeft.Name = "ButtonLeft";
            ButtonLeft.Size = new Size(38, 33);
            ButtonLeft.TabIndex = 12;
            ButtonLeft.Text = "LF";
            ButtonLeft.UseVisualStyleBackColor = true;
            ButtonLeft.Click += ButtonLeft_Click;
            // 
            // ButtonRight
            // 
            ButtonRight.Location = new Point(124, 173);
            ButtonRight.Name = "ButtonRight";
            ButtonRight.Size = new Size(38, 33);
            ButtonRight.TabIndex = 13;
            ButtonRight.Text = "RT";
            ButtonRight.UseVisualStyleBackColor = true;
            ButtonRight.Click += ButtonRight_Click;
            // 
            // ButtonAdd
            // 
            ButtonAdd.Enabled = false;
            ButtonAdd.Location = new Point(186, 134);
            ButtonAdd.Name = "ButtonAdd";
            ButtonAdd.Size = new Size(75, 39);
            ButtonAdd.TabIndex = 14;
            ButtonAdd.Text = "Add";
            ButtonAdd.UseVisualStyleBackColor = true;
            ButtonAdd.Click += ButtonAdd_Click;
            // 
            // ButtonDelete
            // 
            ButtonDelete.Enabled = false;
            ButtonDelete.Location = new Point(186, 179);
            ButtonDelete.Name = "ButtonDelete";
            ButtonDelete.Size = new Size(75, 37);
            ButtonDelete.TabIndex = 15;
            ButtonDelete.Text = "Del";
            ButtonDelete.UseVisualStyleBackColor = true;
            ButtonDelete.Click += ButtonDelete_Click;
            // 
            // ButtonEdit
            // 
            ButtonEdit.Location = new Point(186, 91);
            ButtonEdit.Name = "ButtonEdit";
            ButtonEdit.Size = new Size(75, 37);
            ButtonEdit.TabIndex = 16;
            ButtonEdit.Text = "Edit";
            ButtonEdit.UseVisualStyleBackColor = true;
            ButtonEdit.Click += ButtonEdit_Click;
            // 
            // ButtonEnable
            // 
            ButtonEnable.Location = new Point(186, 234);
            ButtonEnable.Name = "ButtonEnable";
            ButtonEnable.Size = new Size(75, 37);
            ButtonEnable.TabIndex = 17;
            ButtonEnable.Text = "Enable";
            ButtonEnable.UseVisualStyleBackColor = true;
            ButtonEnable.Click += ButtonE_Click;
            // 
            // WaferMapSettingDUT
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ButtonEnable);
            Controls.Add(ButtonEdit);
            Controls.Add(ButtonDelete);
            Controls.Add(ButtonAdd);
            Controls.Add(ButtonRight);
            Controls.Add(ButtonLeft);
            Controls.Add(ButtonDown);
            Controls.Add(ButtonUP);
            Controls.Add(Location);
            Controls.Add(SiteNum);
            Controls.Add(XSize);
            Controls.Add(YSize);
            Controls.Add(CardId);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "WaferMapSettingDUT";
            Size = new Size(283, 350);
            Load += WaferMapSettingDUT_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox CardId;
        private TextBox YSize;
        private TextBox XSize;
        private TextBox SiteNum;
        private TextBox Location;
        private Button ButtonUP;
        private Button ButtonDown;
        private Button ButtonLeft;
        private Button ButtonRight;
        private Button ButtonAdd;
        private Button ButtonDelete;
        private Button ButtonEdit;
        private Button ButtonEnable;
    }
}
