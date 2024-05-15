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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvTables = new System.Windows.Forms.DataGridView();
            this.dTableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTableFilter = new CustomControlleres.PlaceholderTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnFromDB = new System.Windows.Forms.Button();
            this.btnFromScript = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.txtScript = new CustomControlleres.PlaceholderTextBox();
            this.txtClassName = new CustomControlleres.PlaceholderTextBox();
            this.txtResult = new CustomControlleres.PlaceholderTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvSpsAndFuncs = new System.Windows.Forms.DataGridView();
            this.dSPECIFIC_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dROUTINE_TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dDATA_TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSpFilter = new CustomControlleres.PlaceholderTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvScripts = new System.Windows.Forms.DataGridView();
            this.dCmd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dScriptName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dScript = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExportCRptXml = new System.Windows.Forms.Button();
            this.btnAddScript = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTables)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpsAndFuncs)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScripts)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTables
            // 
            this.dgvTables.AllowUserToAddRows = false;
            this.dgvTables.AllowUserToDeleteRows = false;
            this.dgvTables.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dTableName});
            this.dgvTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTables.Location = new System.Drawing.Point(3, 150);
            this.dgvTables.Name = "dgvTables";
            this.dgvTables.ReadOnly = true;
            this.dgvTables.RowTemplate.Height = 24;
            this.dgvTables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvTables.Size = new System.Drawing.Size(319, 393);
            this.dgvTables.TabIndex = 0;
            this.dgvTables.TabStop = false;
            this.dgvTables.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            // 
            // dTableName
            // 
            this.dTableName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dTableName.DataPropertyName = "TableName";
            this.dTableName.HeaderText = "TableName";
            this.dTableName.Name = "dTableName";
            this.dTableName.ReadOnly = true;
            this.dTableName.ToolTipText = "Double click row to auto generate script";
            // 
            // txtTableFilter
            // 
            this.txtTableFilter.BackColor = System.Drawing.SystemColors.Info;
            this.txtTableFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtTableFilter.Location = new System.Drawing.Point(3, 119);
            this.txtTableFilter.Name = "txtTableFilter";
            this.txtTableFilter.PlaceHolder = "Write something here to filter Table";
            this.txtTableFilter.Size = new System.Drawing.Size(319, 31);
            this.txtTableFilter.TabIndex = 1;
            this.txtTableFilter.TabStop = false;
            this.txtTableFilter.TextChanged += new System.EventHandler(this.txtTableFilter_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnFromDB);
            this.groupBox2.Controls.Add(this.btnFromScript);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(319, 116);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Generate Command";
            // 
            // btnFromDB
            // 
            this.btnFromDB.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFromDB.Location = new System.Drawing.Point(3, 63);
            this.btnFromDB.Name = "btnFromDB";
            this.btnFromDB.Size = new System.Drawing.Size(313, 36);
            this.btnFromDB.TabIndex = 1;
            this.btnFromDB.TabStop = false;
            this.btnFromDB.Text = "From DB all tables";
            this.btnFromDB.UseVisualStyleBackColor = true;
            this.btnFromDB.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnFromScript
            // 
            this.btnFromScript.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFromScript.Location = new System.Drawing.Point(3, 27);
            this.btnFromScript.Name = "btnFromScript";
            this.btnFromScript.Size = new System.Drawing.Size(313, 36);
            this.btnFromScript.TabIndex = 0;
            this.btnFromScript.TabStop = false;
            this.btnFromScript.Text = "Use script from DB (&x)";
            this.btnFromScript.UseVisualStyleBackColor = true;
            this.btnFromScript.Click += new System.EventHandler(this.btn_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 39);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(858, 584);
            this.splitContainer1.SplitterDistance = 517;
            this.splitContainer1.TabIndex = 2;
            this.splitContainer1.TabStop = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.txtScript);
            this.splitContainer2.Panel1.Controls.Add(this.txtClassName);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.txtResult);
            this.splitContainer2.Size = new System.Drawing.Size(517, 584);
            this.splitContainer2.SplitterDistance = 171;
            this.splitContainer2.TabIndex = 0;
            this.splitContainer2.TabStop = false;
            // 
            // txtScript
            // 
            this.txtScript.BackColor = System.Drawing.SystemColors.Control;
            this.txtScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtScript.Location = new System.Drawing.Point(0, 31);
            this.txtScript.Multiline = true;
            this.txtScript.Name = "txtScript";
            this.txtScript.PlaceHolder = "Script here";
            this.txtScript.Size = new System.Drawing.Size(513, 136);
            this.txtScript.TabIndex = 2;
            // 
            // txtClassName
            // 
            this.txtClassName.BackColor = System.Drawing.SystemColors.Info;
            this.txtClassName.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtClassName.Location = new System.Drawing.Point(0, 0);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.PlaceHolder = "Class Name";
            this.txtClassName.Size = new System.Drawing.Size(513, 31);
            this.txtClassName.TabIndex = 1;
            // 
            // txtResult
            // 
            this.txtResult.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResult.Location = new System.Drawing.Point(0, 0);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.PlaceHolder = "Generate result only for use script";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(513, 405);
            this.txtResult.TabIndex = 0;
            this.txtResult.TabStop = false;
            this.txtResult.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(333, 580);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvTables);
            this.tabPage1.Controls.Add(this.txtTableFilter);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(325, 546);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tables";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvSpsAndFuncs);
            this.tabPage3.Controls.Add(this.txtSpFilter);
            this.tabPage3.Location = new System.Drawing.Point(4, 30);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(325, 546);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Stored Procedures";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvSpsAndFuncs
            // 
            this.dgvSpsAndFuncs.AllowUserToAddRows = false;
            this.dgvSpsAndFuncs.AllowUserToDeleteRows = false;
            this.dgvSpsAndFuncs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSpsAndFuncs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSpsAndFuncs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dSPECIFIC_NAME,
            this.dROUTINE_TYPE,
            this.dDATA_TYPE});
            this.dgvSpsAndFuncs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSpsAndFuncs.Location = new System.Drawing.Point(3, 34);
            this.dgvSpsAndFuncs.Name = "dgvSpsAndFuncs";
            this.dgvSpsAndFuncs.ReadOnly = true;
            this.dgvSpsAndFuncs.RowTemplate.Height = 24;
            this.dgvSpsAndFuncs.Size = new System.Drawing.Size(319, 509);
            this.dgvSpsAndFuncs.TabIndex = 5;
            this.dgvSpsAndFuncs.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            // 
            // dSPECIFIC_NAME
            // 
            this.dSPECIFIC_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dSPECIFIC_NAME.DataPropertyName = "SPECIFIC_NAME";
            this.dSPECIFIC_NAME.HeaderText = "SPECIFIC_NAME";
            this.dSPECIFIC_NAME.Name = "dSPECIFIC_NAME";
            this.dSPECIFIC_NAME.ReadOnly = true;
            this.dSPECIFIC_NAME.Width = 182;
            // 
            // dROUTINE_TYPE
            // 
            this.dROUTINE_TYPE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dROUTINE_TYPE.DataPropertyName = "ROUTINE_TYPE";
            this.dROUTINE_TYPE.HeaderText = "ROUTINE_TYPE";
            this.dROUTINE_TYPE.Name = "dROUTINE_TYPE";
            this.dROUTINE_TYPE.ReadOnly = true;
            this.dROUTINE_TYPE.Width = 176;
            // 
            // dDATA_TYPE
            // 
            this.dDATA_TYPE.DataPropertyName = "DATA_TYPE";
            this.dDATA_TYPE.HeaderText = "TYPE";
            this.dDATA_TYPE.MinimumWidth = 100;
            this.dDATA_TYPE.Name = "dDATA_TYPE";
            this.dDATA_TYPE.ReadOnly = true;
            // 
            // txtSpFilter
            // 
            this.txtSpFilter.BackColor = System.Drawing.SystemColors.Info;
            this.txtSpFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSpFilter.Location = new System.Drawing.Point(3, 3);
            this.txtSpFilter.Name = "txtSpFilter";
            this.txtSpFilter.PlaceHolder = "Write something here to filter SP && Func";
            this.txtSpFilter.Size = new System.Drawing.Size(319, 31);
            this.txtSpFilter.TabIndex = 6;
            this.txtSpFilter.TextChanged += new System.EventHandler(this.txtSpFilter_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvScripts);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(325, 546);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Scripts";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvScripts
            // 
            this.dgvScripts.AllowUserToAddRows = false;
            this.dgvScripts.AllowUserToDeleteRows = false;
            this.dgvScripts.AllowUserToResizeRows = false;
            this.dgvScripts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvScripts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvScripts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dCmd,
            this.dScriptName,
            this.dScript});
            this.dgvScripts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvScripts.Location = new System.Drawing.Point(3, 112);
            this.dgvScripts.Name = "dgvScripts";
            this.dgvScripts.ReadOnly = true;
            this.dgvScripts.RowHeadersVisible = false;
            this.dgvScripts.RowTemplate.Height = 24;
            this.dgvScripts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvScripts.Size = new System.Drawing.Size(319, 431);
            this.dgvScripts.TabIndex = 1;
            this.dgvScripts.TabStop = false;
            this.dgvScripts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            // 
            // dCmd
            // 
            this.dCmd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dCmd.DataPropertyName = "Cmd";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.dCmd.DefaultCellStyle = dataGridViewCellStyle1;
            this.dCmd.HeaderText = "";
            this.dCmd.Name = "dCmd";
            this.dCmd.ReadOnly = true;
            this.dCmd.Width = 23;
            // 
            // dScriptName
            // 
            this.dScriptName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dScriptName.DataPropertyName = "ScriptName";
            this.dScriptName.HeaderText = "Script Name";
            this.dScriptName.Name = "dScriptName";
            this.dScriptName.ReadOnly = true;
            this.dScriptName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dScriptName.ToolTipText = "Double click row to auto generate script";
            // 
            // dScript
            // 
            this.dScript.DataPropertyName = "Script";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dScript.DefaultCellStyle = dataGridViewCellStyle2;
            this.dScript.HeaderText = "Script";
            this.dScript.Name = "dScript";
            this.dScript.ReadOnly = true;
            this.dScript.Visible = false;
            this.dScript.Width = 20;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExportCRptXml);
            this.groupBox1.Controls.Add(this.btnAddScript);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(319, 109);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generate Command";
            // 
            // btnExportCRptXml
            // 
            this.btnExportCRptXml.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExportCRptXml.Location = new System.Drawing.Point(3, 63);
            this.btnExportCRptXml.Name = "btnExportCRptXml";
            this.btnExportCRptXml.Size = new System.Drawing.Size(313, 36);
            this.btnExportCRptXml.TabIndex = 3;
            this.btnExportCRptXml.TabStop = false;
            this.btnExportCRptXml.Text = "Save to xsd file for Crystal Report use";
            this.btnExportCRptXml.UseVisualStyleBackColor = true;
            this.btnExportCRptXml.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnAddScript
            // 
            this.btnAddScript.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddScript.Location = new System.Drawing.Point(3, 27);
            this.btnAddScript.Name = "btnAddScript";
            this.btnAddScript.Size = new System.Drawing.Size(313, 36);
            this.btnAddScript.TabIndex = 4;
            this.btnAddScript.TabStop = false;
            this.btnAddScript.Text = "Add script to list(&A)";
            this.btnAddScript.UseVisualStyleBackColor = true;
            this.btnAddScript.Click += new System.EventHandler(this.btn_Click);
            // 
            // frmPOCOGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 623);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "frmPOCOGenerator";
            this.Text = "POCO_Genrator";
            this.Load += new System.EventHandler(this.frmPOCOGenrator_Load);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTables)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpsAndFuncs)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvScripts)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvTables;
        private CustomControlleres.PlaceholderTextBox txtTableFilter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private CustomControlleres.PlaceholderTextBox txtScript;
        private CustomControlleres.PlaceholderTextBox txtResult;
        private System.Windows.Forms.Button btnFromDB;
        private System.Windows.Forms.Button btnFromScript;
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
    }
}