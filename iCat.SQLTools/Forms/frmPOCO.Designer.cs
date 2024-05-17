namespace iCat.SQLTools.Forms
{
    partial class frmPOCO
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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            dgvTables = new DataGridView();
            dTableName = new DataGridViewTextBoxColumn();
            txtTableFilter = new CustomControlleres.PlaceholderTextBox();
            groupBox2 = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnWithComment = new Button();
            btnAllTables = new Button();
            btnWithoutComment = new Button();
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            txtScript = new CustomControlleres.PlaceholderTextBox();
            txtClassName = new CustomControlleres.PlaceholderTextBox();
            txtResult = new CustomControlleres.PlaceholderTextBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage3 = new TabPage();
            dgvSpsAndFuncs = new DataGridView();
            dSPECIFIC_NAME = new DataGridViewTextBoxColumn();
            dROUTINE_TYPE = new DataGridViewTextBoxColumn();
            dDATA_TYPE = new DataGridViewTextBoxColumn();
            txtSpFilter = new CustomControlleres.PlaceholderTextBox();
            tabPage2 = new TabPage();
            dgvScripts = new DataGridView();
            dCmd = new DataGridViewTextBoxColumn();
            dScriptName = new DataGridViewTextBoxColumn();
            dScript = new DataGridViewTextBoxColumn();
            groupBox1 = new GroupBox();
            btnExportCRptXml = new Button();
            btnAddScript = new Button();
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
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSpsAndFuncs).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvScripts).BeginInit();
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
            dgvTables.Location = new Point(3, 122);
            dgvTables.Name = "dgvTables";
            dgvTables.ReadOnly = true;
            dgvTables.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvTables.Size = new Size(398, 493);
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
            txtTableFilter.Location = new Point(3, 95);
            txtTableFilter.Margin = new Padding(3, 2, 3, 2);
            txtTableFilter.Name = "txtTableFilter";
            txtTableFilter.PlaceHolder = "Write something here to filter Table";
            txtTableFilter.Size = new Size(398, 27);
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
            tableLayoutPanel1.Controls.Add(btnWithComment, 0, 0);
            tableLayoutPanel1.Controls.Add(btnAllTables, 0, 1);
            tableLayoutPanel1.Controls.Add(btnWithoutComment, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 22);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(392, 69);
            tableLayoutPanel1.TabIndex = 2;
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
            btnAllTables.Location = new Point(3, 36);
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
            btnWithoutComment.Location = new Point(199, 2);
            btnWithoutComment.Margin = new Padding(3, 2, 3, 2);
            btnWithoutComment.Name = "btnWithoutComment";
            btnWithoutComment.Size = new Size(190, 30);
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
            splitContainer1.Panel2.Controls.Add(tabControl1);
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
            splitContainer2.SplitterDistance = 189;
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
            txtScript.Size = new Size(631, 158);
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
            txtResult.Size = new Size(631, 455);
            txtResult.TabIndex = 0;
            txtResult.TabStop = false;
            txtResult.KeyDown += txt_KeyDown;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Margin = new Padding(3, 2, 3, 2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(412, 647);
            tabControl1.TabIndex = 3;
            tabControl1.TabStop = false;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dgvTables);
            tabPage1.Controls.Add(txtTableFilter);
            tabPage1.Controls.Add(groupBox2);
            tabPage1.Location = new Point(4, 26);
            tabPage1.Margin = new Padding(3, 2, 3, 2);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 2, 3, 2);
            tabPage1.Size = new Size(404, 617);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Tables";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(dgvSpsAndFuncs);
            tabPage3.Controls.Add(txtSpFilter);
            tabPage3.Location = new Point(4, 26);
            tabPage3.Margin = new Padding(3, 2, 3, 2);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3, 2, 3, 2);
            tabPage3.Size = new Size(404, 617);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Stored Procedures";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvSpsAndFuncs
            // 
            dgvSpsAndFuncs.AllowUserToAddRows = false;
            dgvSpsAndFuncs.AllowUserToDeleteRows = false;
            dgvSpsAndFuncs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSpsAndFuncs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSpsAndFuncs.Columns.AddRange(new DataGridViewColumn[] { dSPECIFIC_NAME, dROUTINE_TYPE, dDATA_TYPE });
            dgvSpsAndFuncs.Dock = DockStyle.Fill;
            dgvSpsAndFuncs.Location = new Point(3, 29);
            dgvSpsAndFuncs.Margin = new Padding(3, 2, 3, 2);
            dgvSpsAndFuncs.Name = "dgvSpsAndFuncs";
            dgvSpsAndFuncs.ReadOnly = true;
            dgvSpsAndFuncs.RowTemplate.Height = 24;
            dgvSpsAndFuncs.Size = new Size(398, 586);
            dgvSpsAndFuncs.TabIndex = 5;
            dgvSpsAndFuncs.CellDoubleClick += dgv_CellDoubleClick;
            // 
            // dSPECIFIC_NAME
            // 
            dSPECIFIC_NAME.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dSPECIFIC_NAME.DataPropertyName = "SPECIFIC_NAME";
            dSPECIFIC_NAME.HeaderText = "SPECIFIC_NAME";
            dSPECIFIC_NAME.Name = "dSPECIFIC_NAME";
            dSPECIFIC_NAME.ReadOnly = true;
            dSPECIFIC_NAME.Width = 147;
            // 
            // dROUTINE_TYPE
            // 
            dROUTINE_TYPE.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dROUTINE_TYPE.DataPropertyName = "ROUTINE_TYPE";
            dROUTINE_TYPE.HeaderText = "ROUTINE_TYPE";
            dROUTINE_TYPE.Name = "dROUTINE_TYPE";
            dROUTINE_TYPE.ReadOnly = true;
            dROUTINE_TYPE.Width = 143;
            // 
            // dDATA_TYPE
            // 
            dDATA_TYPE.DataPropertyName = "DATA_TYPE";
            dDATA_TYPE.HeaderText = "TYPE";
            dDATA_TYPE.MinimumWidth = 100;
            dDATA_TYPE.Name = "dDATA_TYPE";
            dDATA_TYPE.ReadOnly = true;
            // 
            // txtSpFilter
            // 
            txtSpFilter.BackColor = SystemColors.Info;
            txtSpFilter.Dock = DockStyle.Top;
            txtSpFilter.Location = new Point(3, 2);
            txtSpFilter.Margin = new Padding(3, 2, 3, 2);
            txtSpFilter.Name = "txtSpFilter";
            txtSpFilter.PlaceHolder = "Write something here to filter SP && Func";
            txtSpFilter.Size = new Size(398, 27);
            txtSpFilter.TabIndex = 6;
            txtSpFilter.TextChanged += txtSpFilter_TextChanged;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dgvScripts);
            tabPage2.Controls.Add(groupBox1);
            tabPage2.Location = new Point(4, 26);
            tabPage2.Margin = new Padding(3, 2, 3, 2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 2, 3, 2);
            tabPage2.Size = new Size(404, 617);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Scripts";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvScripts
            // 
            dgvScripts.AllowUserToAddRows = false;
            dgvScripts.AllowUserToDeleteRows = false;
            dgvScripts.AllowUserToResizeRows = false;
            dgvScripts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvScripts.Columns.AddRange(new DataGridViewColumn[] { dCmd, dScriptName, dScript });
            dgvScripts.Dock = DockStyle.Fill;
            dgvScripts.Location = new Point(3, 89);
            dgvScripts.Margin = new Padding(3, 2, 3, 2);
            dgvScripts.Name = "dgvScripts";
            dgvScripts.ReadOnly = true;
            dgvScripts.RowHeadersVisible = false;
            dgvScripts.RowTemplate.Height = 24;
            dgvScripts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvScripts.Size = new Size(398, 526);
            dgvScripts.TabIndex = 1;
            dgvScripts.TabStop = false;
            dgvScripts.CellDoubleClick += dgv_CellDoubleClick;
            // 
            // dCmd
            // 
            dCmd.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dCmd.DataPropertyName = "Cmd";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = Color.Lavender;
            dCmd.DefaultCellStyle = dataGridViewCellStyle5;
            dCmd.HeaderText = "";
            dCmd.Name = "dCmd";
            dCmd.ReadOnly = true;
            dCmd.Width = 19;
            // 
            // dScriptName
            // 
            dScriptName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dScriptName.DataPropertyName = "ScriptName";
            dScriptName.HeaderText = "Script Name";
            dScriptName.Name = "dScriptName";
            dScriptName.ReadOnly = true;
            dScriptName.SortMode = DataGridViewColumnSortMode.NotSortable;
            dScriptName.ToolTipText = "Double click row to auto generate script";
            // 
            // dScript
            // 
            dScript.DataPropertyName = "Script";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dScript.DefaultCellStyle = dataGridViewCellStyle6;
            dScript.HeaderText = "Script";
            dScript.Name = "dScript";
            dScript.ReadOnly = true;
            dScript.Visible = false;
            dScript.Width = 20;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnExportCRptXml);
            groupBox1.Controls.Add(btnAddScript);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(3, 2);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(398, 87);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Generate Command";
            // 
            // btnExportCRptXml
            // 
            btnExportCRptXml.Dock = DockStyle.Top;
            btnExportCRptXml.Location = new Point(3, 51);
            btnExportCRptXml.Margin = new Padding(3, 2, 3, 2);
            btnExportCRptXml.Name = "btnExportCRptXml";
            btnExportCRptXml.Size = new Size(392, 29);
            btnExportCRptXml.TabIndex = 3;
            btnExportCRptXml.TabStop = false;
            btnExportCRptXml.Text = "Save to xsd file for Crystal Report use";
            btnExportCRptXml.UseVisualStyleBackColor = true;
            btnExportCRptXml.Click += btn_Click;
            // 
            // btnAddScript
            // 
            btnAddScript.Dock = DockStyle.Top;
            btnAddScript.Location = new Point(3, 22);
            btnAddScript.Margin = new Padding(3, 2, 3, 2);
            btnAddScript.Name = "btnAddScript";
            btnAddScript.Size = new Size(392, 29);
            btnAddScript.TabIndex = 4;
            btnAddScript.TabStop = false;
            btnAddScript.Text = "Add script to list(&A)";
            btnAddScript.UseVisualStyleBackColor = true;
            btnAddScript.Click += btn_Click;
            // 
            // frmPOCO
            // 
            AutoScaleDimensions = new SizeF(9F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1055, 683);
            Controls.Add(splitContainer1);
            Margin = new Padding(5, 6, 5, 6);
            Name = "frmPOCO";
            Text = "POCO_Genrator";
            Load += frmPOCOGenrator_Load;
            Controls.SetChildIndex(panel1, 0);
            Controls.SetChildIndex(splitContainer1, 0);
            ((System.ComponentModel.ISupportInitialize)dgvTables).EndInit();
            groupBox2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSpsAndFuncs).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvScripts).EndInit();
            groupBox1.ResumeLayout(false);
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
        private System.Windows.Forms.DataGridView dgvScripts;
        private System.Windows.Forms.DataGridViewTextBoxColumn dCmd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dScriptName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dScript;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExportCRptXml;
        private System.Windows.Forms.Button btnAddScript;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgvSpsAndFuncs;
        private CustomControlleres.PlaceholderTextBox txtSpFilter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSPECIFIC_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn dROUTINE_TYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn dDATA_TYPE;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnWithoutComment;
    }
}