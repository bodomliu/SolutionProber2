namespace JsonDataShow
{
    partial class JsonDataForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            dataGridView_JsonShow = new DataGridView();
            Key = new DataGridViewTextBoxColumn();
            MainType = new DataGridViewTextBoxColumn();
            Count = new DataGridViewTextBoxColumn();
            Value = new DataGridViewTextBoxColumn();
            ValueType = new DataGridViewTextBoxColumn();
            label1 = new Label();
            textBox_JsonPath = new TextBox();
            tabPage2 = new TabPage();
            textBox_JsonText = new TextBox();
            btn_Refresh = new Button();
            btn_saveFile = new Button();
            checkBox_autoSave = new CheckBox();
            label_JsonFilePath = new Label();
            btn_UpdateFromFile = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_JsonShow).BeginInit();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(817, 422);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dataGridView_JsonShow);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(textBox_JsonPath);
            tabPage1.Location = new Point(4, 26);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(809, 392);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "配置";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView_JsonShow
            // 
            dataGridView_JsonShow.AllowUserToAddRows = false;
            dataGridView_JsonShow.AllowUserToDeleteRows = false;
            dataGridView_JsonShow.AllowUserToResizeRows = false;
            dataGridView_JsonShow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView_JsonShow.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_JsonShow.Columns.AddRange(new DataGridViewColumn[] { Key, MainType, Count, Value, ValueType });
            dataGridView_JsonShow.Location = new Point(6, 35);
            dataGridView_JsonShow.Name = "dataGridView_JsonShow";
            dataGridView_JsonShow.RowHeadersVisible = false;
            dataGridView_JsonShow.RowTemplate.Height = 25;
            dataGridView_JsonShow.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_JsonShow.Size = new Size(797, 351);
            dataGridView_JsonShow.TabIndex = 3;
            dataGridView_JsonShow.CellClick += dataGridView_JsonShow_CellClick;
            dataGridView_JsonShow.CellDoubleClick += dataGridView_JsonShow_CellDoubleClick;
            dataGridView_JsonShow.CellEndEdit += dataGridView_JsonShow_CellEndEdit;
            // 
            // Key
            // 
            Key.HeaderText = "名称";
            Key.Name = "Key";
            Key.ReadOnly = true;
            Key.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // MainType
            // 
            MainType.HeaderText = "类型";
            MainType.Name = "MainType";
            MainType.ReadOnly = true;
            MainType.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Count
            // 
            Count.HeaderText = "子项数量";
            Count.Name = "Count";
            Count.ReadOnly = true;
            Count.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Value
            // 
            Value.HeaderText = "值";
            Value.Name = "Value";
            Value.ReadOnly = true;
            Value.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ValueType
            // 
            ValueType.HeaderText = "值类型";
            ValueType.Name = "ValueType";
            ValueType.ReadOnly = true;
            ValueType.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 9);
            label1.Name = "label1";
            label1.Size = new Size(68, 17);
            label1.TabIndex = 2;
            label1.Text = "节点路径：";
            // 
            // textBox_JsonPath
            // 
            textBox_JsonPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_JsonPath.Location = new Point(80, 6);
            textBox_JsonPath.Name = "textBox_JsonPath";
            textBox_JsonPath.ReadOnly = true;
            textBox_JsonPath.Size = new Size(723, 23);
            textBox_JsonPath.TabIndex = 1;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(textBox_JsonText);
            tabPage2.Location = new Point(4, 26);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(809, 392);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Json文本";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox_JsonText
            // 
            textBox_JsonText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox_JsonText.Location = new Point(6, 6);
            textBox_JsonText.Multiline = true;
            textBox_JsonText.Name = "textBox_JsonText";
            textBox_JsonText.ReadOnly = true;
            textBox_JsonText.ScrollBars = ScrollBars.Both;
            textBox_JsonText.Size = new Size(768, 372);
            textBox_JsonText.TabIndex = 0;
            // 
            // btn_Refresh
            // 
            btn_Refresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btn_Refresh.Location = new Point(105, 440);
            btn_Refresh.Name = "btn_Refresh";
            btn_Refresh.Size = new Size(75, 23);
            btn_Refresh.TabIndex = 1;
            btn_Refresh.Text = "刷新此页";
            btn_Refresh.UseVisualStyleBackColor = true;
            btn_Refresh.Click += btn_Refresh_Click;
            // 
            // btn_saveFile
            // 
            btn_saveFile.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_saveFile.Location = new Point(754, 440);
            btn_saveFile.Name = "btn_saveFile";
            btn_saveFile.Size = new Size(75, 23);
            btn_saveFile.TabIndex = 2;
            btn_saveFile.Text = "保存";
            btn_saveFile.UseVisualStyleBackColor = true;
            btn_saveFile.Click += btn_saveFile_Click;
            // 
            // checkBox_autoSave
            // 
            checkBox_autoSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            checkBox_autoSave.AutoSize = true;
            checkBox_autoSave.Checked = true;
            checkBox_autoSave.CheckState = CheckState.Checked;
            checkBox_autoSave.Location = new Point(673, 442);
            checkBox_autoSave.Name = "checkBox_autoSave";
            checkBox_autoSave.Size = new Size(75, 21);
            checkBox_autoSave.TabIndex = 3;
            checkBox_autoSave.Text = "自动保存";
            checkBox_autoSave.UseVisualStyleBackColor = true;
            // 
            // label_JsonFilePath
            // 
            label_JsonFilePath.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label_JsonFilePath.AutoSize = true;
            label_JsonFilePath.Location = new Point(186, 443);
            label_JsonFilePath.Name = "label_JsonFilePath";
            label_JsonFilePath.Size = new Size(68, 17);
            label_JsonFilePath.TabIndex = 4;
            label_JsonFilePath.Text = "文件路径：";
            // 
            // btn_UpdateFromFile
            // 
            btn_UpdateFromFile.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btn_UpdateFromFile.Location = new Point(12, 440);
            btn_UpdateFromFile.Name = "btn_UpdateFromFile";
            btn_UpdateFromFile.Size = new Size(87, 23);
            btn_UpdateFromFile.TabIndex = 5;
            btn_UpdateFromFile.Text = "从文件更新";
            btn_UpdateFromFile.UseVisualStyleBackColor = true;
            btn_UpdateFromFile.Click += btn_UpdateFromFile_Click;
            // 
            // JsonDataForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(841, 475);
            Controls.Add(btn_saveFile);
            Controls.Add(checkBox_autoSave);
            Controls.Add(btn_UpdateFromFile);
            Controls.Add(label_JsonFilePath);
            Controls.Add(btn_Refresh);
            Controls.Add(tabControl1);
            Name = "JsonDataForm";
            Text = "JsonDataForm";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_JsonShow).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TextBox textBox_JsonText;
        private TabPage tabPage2;
        private Button btn_Refresh;
        private DataGridView dataGridView_JsonShow;
        private Label label1;
        private TextBox textBox_JsonPath;
        private DataGridViewTextBoxColumn Key;
        private DataGridViewTextBoxColumn MainType;
        private DataGridViewTextBoxColumn Count;
        private DataGridViewTextBoxColumn Value;
        private DataGridViewTextBoxColumn ValueType;
        private Button btn_saveFile;
        private CheckBox checkBox_autoSave;
        private Label label_JsonFilePath;
        private Button btn_UpdateFromFile;
    }
}