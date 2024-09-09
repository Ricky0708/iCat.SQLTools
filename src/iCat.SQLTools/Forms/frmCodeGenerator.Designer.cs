namespace iCat.SQLTools.Forms
{
    partial class frmCodeGenerator
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
            dgvTables = new DataGridView();
            dTableName = new DataGridViewTextBoxColumn();
            txtTableFilter = new CustomControlleres.PlaceholderTextBox();
            groupBox2 = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnClassAssign = new Button();
            btnWithComment = new Button();
            btnAllTables = new Button();
            btnWithoutComment = new Button();
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            txtScript = new CustomControlleres.PlaceholderTextBox();
            txtClassName = new CustomControlleres.PlaceholderTextBox();
            txtResult = new CustomControlleres.PlaceholderTextBox();
            panel2 = new Panel();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            groupBox1 = new GroupBox();
            txtParameterObjName = new TextBox();
            btnDelete = new Button();
            label1 = new Label();
            btnUpdate = new Button();
            cboParameterType = new ComboBox();
            btnInsert = new Button();
            btnSelect = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTables).BeginInit();
            groupBox2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            panel2.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Size = new Size(1055, 32);
            // 
            // dgvTables
            // 
            dgvTables.AllowUserToAddRows = false;
            dgvTables.AllowUserToDeleteRows = false;
            dgvTables.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTables.Columns.AddRange(new DataGridViewColumn[] { dTableName });
            dgvTables.Dock = DockStyle.Fill;
            dgvTables.Location = new Point(0, 299);
            dgvTables.Name = "dgvTables";
            dgvTables.ReadOnly = true;
            dgvTables.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvTables.Size = new Size(412, 348);
            dgvTables.TabIndex = 0;
            dgvTables.CellDoubleClick += dgv_CellDoubleClick;
            // 
            // dTableName
            // 
            dTableName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dTableName.DataPropertyName = "TableName";
            dTableName.HeaderText = "TableName";
            dTableName.Name = "dTableName";
            dTableName.ReadOnly = true;
            dTableName.ToolTipText = "Double click row to auto generate script";
            // 
            // txtTableFilter
            // 
            txtTableFilter.BackColor = SystemColors.Info;
            txtTableFilter.Dock = DockStyle.Top;
            txtTableFilter.Location = new Point(0, 272);
            txtTableFilter.Margin = new Padding(3, 2, 3, 2);
            txtTableFilter.Name = "txtTableFilter";
            txtTableFilter.PlaceHolder = "Write something here to filter Table";
            txtTableFilter.Size = new Size(412, 27);
            txtTableFilter.TabIndex = 1;
            txtTableFilter.TabStop = false;
            txtTableFilter.TextChanged += txtTableFilter_TextChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(tableLayoutPanel1);
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Location = new Point(3, 2);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(398, 93);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Generate Command";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(btnClassAssign, 1, 0);
            tableLayoutPanel1.Controls.Add(btnWithComment, 0, 0);
            tableLayoutPanel1.Controls.Add(btnAllTables, 1, 1);
            tableLayoutPanel1.Controls.Add(btnWithoutComment, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 22);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(392, 69);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // btnClassAssign
            // 
            btnClassAssign.Dock = DockStyle.Fill;
            btnClassAssign.Location = new Point(199, 2);
            btnClassAssign.Margin = new Padding(3, 2, 3, 2);
            btnClassAssign.Name = "btnClassAssign";
            btnClassAssign.Size = new Size(190, 30);
            btnClassAssign.TabIndex = 3;
            btnClassAssign.TabStop = false;
            btnClassAssign.Text = "Class Assign";
            btnClassAssign.UseVisualStyleBackColor = true;
            btnClassAssign.Click += btn_Click;
            // 
            // btnWithComment
            // 
            btnWithComment.Dock = DockStyle.Fill;
            btnWithComment.Location = new Point(3, 2);
            btnWithComment.Margin = new Padding(3, 2, 3, 2);
            btnWithComment.Name = "btnWithComment";
            btnWithComment.Size = new Size(190, 30);
            btnWithComment.TabIndex = 0;
            btnWithComment.TabStop = false;
            btnWithComment.Text = "With Comment";
            btnWithComment.UseVisualStyleBackColor = true;
            btnWithComment.Click += btn_Click;
            // 
            // btnAllTables
            // 
            btnAllTables.Dock = DockStyle.Fill;
            btnAllTables.Location = new Point(199, 36);
            btnAllTables.Margin = new Padding(3, 2, 3, 2);
            btnAllTables.Name = "btnAllTables";
            btnAllTables.Size = new Size(190, 31);
            btnAllTables.TabIndex = 1;
            btnAllTables.TabStop = false;
            btnAllTables.Text = "All Tables With Comment";
            btnAllTables.UseVisualStyleBackColor = true;
            btnAllTables.Click += btn_Click;
            // 
            // btnWithoutComment
            // 
            btnWithoutComment.Dock = DockStyle.Fill;
            btnWithoutComment.Location = new Point(3, 36);
            btnWithoutComment.Margin = new Padding(3, 2, 3, 2);
            btnWithoutComment.Name = "btnWithoutComment";
            btnWithoutComment.Size = new Size(190, 31);
            btnWithoutComment.TabIndex = 2;
            btnWithoutComment.TabStop = false;
            btnWithoutComment.Text = "Without Comment";
            btnWithoutComment.UseVisualStyleBackColor = true;
            btnWithoutComment.Click += btn_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.BorderStyle = BorderStyle.Fixed3D;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 32);
            splitContainer1.Margin = new Padding(3, 2, 3, 2);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dgvTables);
            splitContainer1.Panel2.Controls.Add(txtTableFilter);
            splitContainer1.Panel2.Controls.Add(panel2);
            splitContainer1.Size = new Size(1055, 651);
            splitContainer1.SplitterDistance = 635;
            splitContainer1.TabIndex = 2;
            splitContainer1.TabStop = false;
            // 
            // splitContainer2
            // 
            splitContainer2.BorderStyle = BorderStyle.Fixed3D;
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Margin = new Padding(3, 2, 3, 2);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(txtScript);
            splitContainer2.Panel1.Controls.Add(txtClassName);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(txtResult);
            splitContainer2.Size = new Size(635, 651);
            splitContainer2.SplitterDistance = 188;
            splitContainer2.SplitterWidth = 3;
            splitContainer2.TabIndex = 0;
            splitContainer2.TabStop = false;
            // 
            // txtScript
            // 
            txtScript.BackColor = SystemColors.Control;
            txtScript.Dock = DockStyle.Fill;
            txtScript.Location = new Point(0, 27);
            txtScript.Margin = new Padding(3, 2, 3, 2);
            txtScript.Multiline = true;
            txtScript.Name = "txtScript";
            txtScript.PlaceHolder = "Script here";
            txtScript.Size = new Size(631, 157);
            txtScript.TabIndex = 2;
            // 
            // txtClassName
            // 
            txtClassName.BackColor = SystemColors.Info;
            txtClassName.Dock = DockStyle.Top;
            txtClassName.Location = new Point(0, 0);
            txtClassName.Margin = new Padding(3, 2, 3, 2);
            txtClassName.Name = "txtClassName";
            txtClassName.PlaceHolder = "Class Name";
            txtClassName.Size = new Size(631, 27);
            txtClassName.TabIndex = 1;
            // 
            // txtResult
            // 
            txtResult.BackColor = SystemColors.GradientActiveCaption;
            txtResult.Dock = DockStyle.Fill;
            txtResult.Location = new Point(0, 0);
            txtResult.Margin = new Padding(3, 2, 3, 2);
            txtResult.Multiline = true;
            txtResult.Name = "txtResult";
            txtResult.PlaceHolder = "Generate result only for use script";
            txtResult.ReadOnly = true;
            txtResult.ScrollBars = ScrollBars.Both;
            txtResult.Size = new Size(631, 456);
            txtResult.TabIndex = 0;
            txtResult.TabStop = false;
            txtResult.KeyDown += txt_KeyDown;
            // 
            // panel2
            // 
            panel2.Controls.Add(tabControl1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(412, 272);
            panel2.TabIndex = 0;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Margin = new Padding(3, 2, 3, 2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(412, 272);
            tabControl1.TabIndex = 3;
            tabControl1.TabStop = false;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(groupBox2);
            tabPage1.Location = new Point(4, 26);
            tabPage1.Margin = new Padding(3, 2, 3, 2);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 2, 3, 2);
            tabPage1.Size = new Size(404, 242);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Class";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(groupBox1);
            tabPage2.Location = new Point(4, 26);
            tabPage2.Margin = new Padding(3, 2, 3, 2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 2, 3, 2);
            tabPage2.Size = new Size(404, 242);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "SQL";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Lavender;
            groupBox1.Controls.Add(txtParameterObjName);
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnUpdate);
            groupBox1.Controls.Add(cboParameterType);
            groupBox1.Controls.Add(btnInsert);
            groupBox1.Controls.Add(btnSelect);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(3, 2);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(398, 238);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Generate Command";
            // 
            // txtParameterObjName
            // 
            txtParameterObjName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtParameterObjName.Location = new Point(6, 199);
            txtParameterObjName.Name = "txtParameterObjName";
            txtParameterObjName.PlaceholderText = "Parameter Object Name";
            txtParameterObjName.Size = new Size(392, 27);
            txtParameterObjName.TabIndex = 7;
            txtParameterObjName.TextAlign = HorizontalAlignment.Right;
            // 
            // btnDelete
            // 
            btnDelete.Dock = DockStyle.Top;
            btnDelete.Location = new Point(3, 109);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(392, 29);
            btnDelete.TabIndex = 6;
            btnDelete.TabStop = false;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btn_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(290, 150);
            label1.Name = "label1";
            label1.Size = new Size(105, 16);
            label1.TabIndex = 5;
            label1.Text = "Parameter Type";
            // 
            // btnUpdate
            // 
            btnUpdate.Dock = DockStyle.Top;
            btnUpdate.Location = new Point(3, 80);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(392, 29);
            btnUpdate.TabIndex = 5;
            btnUpdate.TabStop = false;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btn_Click;
            // 
            // cboParameterType
            // 
            cboParameterType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboParameterType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboParameterType.FormattingEnabled = true;
            cboParameterType.Location = new Point(6, 169);
            cboParameterType.Name = "cboParameterType";
            cboParameterType.Size = new Size(392, 24);
            cboParameterType.TabIndex = 4;
            // 
            // btnInsert
            // 
            btnInsert.Dock = DockStyle.Top;
            btnInsert.Location = new Point(3, 51);
            btnInsert.Margin = new Padding(3, 2, 3, 2);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(392, 29);
            btnInsert.TabIndex = 4;
            btnInsert.TabStop = false;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btn_Click;
            // 
            // btnSelect
            // 
            btnSelect.Dock = DockStyle.Top;
            btnSelect.Location = new Point(3, 22);
            btnSelect.Margin = new Padding(3, 2, 3, 2);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(392, 29);
            btnSelect.TabIndex = 3;
            btnSelect.TabStop = false;
            btnSelect.Text = "Select";
            btnSelect.UseVisualStyleBackColor = true;
            btnSelect.Click += btn_Click;
            // 
            // frmCodeGenerator
            // 
            AutoScaleDimensions = new SizeF(9F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1055, 683);
            Controls.Add(splitContainer1);
            KeyPreview = true;
            Margin = new Padding(5, 6, 5, 6);
            Name = "frmCodeGenerator";
            Text = "POCO_Genrator";
            KeyDown += frmPOCO_KeyDown;
            Controls.SetChildIndex(panel1, 0);
            Controls.SetChildIndex(splitContainer1, 0);
            ((System.ComponentModel.ISupportInitialize)dgvTables).EndInit();
            groupBox2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            panel2.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.DataGridView dgvTables;
        private CustomControlleres.PlaceholderTextBox txtTableFilter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private CustomControlleres.PlaceholderTextBox txtScript;
        private CustomControlleres.PlaceholderTextBox txtResult;
        private System.Windows.Forms.Button btnAllTables;
        private System.Windows.Forms.Button btnWithComment;
        private CustomControlleres.PlaceholderTextBox txtClassName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dTableName;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnWithoutComment;
        private Button btnClassAssign;
        private Button btnUpdate;
        private Button btnInsert;
        private Button btnSelect;
        private ComboBox cboParameterType;
        private Label label1;
        private Panel panel2;
        private Button btnDelete;
        private TextBox txtParameterObjName;
    }
}