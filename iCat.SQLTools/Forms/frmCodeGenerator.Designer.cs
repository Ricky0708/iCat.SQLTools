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
            txtResult = new CustomControlleres.PlaceholderTextBox();
            txtTableFilter = new CustomControlleres.PlaceholderTextBox();
            dgvTables = new DataGridView();
            dTableName = new DataGridViewTextBoxColumn();
            groupBox2 = new GroupBox();
            tabControl1 = new TabControl();
            tabSQL = new TabPage();
            btnUpdate = new Button();
            btnInsert = new Button();
            btnSelect = new Button();
            tabParameterType = new TabPage();
            rdoODBC = new RadioButton();
            rdoMySQL = new RadioButton();
            rdoMSSSQL = new RadioButton();
            splitContainer1 = new SplitContainer();
            ((System.ComponentModel.ISupportInitialize)dgvTables).BeginInit();
            groupBox2.SuspendLayout();
            tabControl1.SuspendLayout();
            tabSQL.SuspendLayout();
            tabParameterType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Size = new Size(1057, 32);
            // 
            // txtResult
            // 
            txtResult.BackColor = SystemColors.GradientActiveCaption;
            txtResult.Dock = DockStyle.Fill;
            txtResult.Location = new Point(0, 0);
            txtResult.Margin = new Padding(3, 2, 3, 2);
            txtResult.Multiline = true;
            txtResult.Name = "txtResult";
            txtResult.PlaceHolder = "Generate result";
            txtResult.ReadOnly = true;
            txtResult.ScrollBars = ScrollBars.Both;
            txtResult.Size = new Size(675, 629);
            txtResult.TabIndex = 1;
            txtResult.TabStop = false;
            txtResult.KeyDown += txt_KeyDown;
            // 
            // txtTableFilter
            // 
            txtTableFilter.BackColor = SystemColors.Info;
            txtTableFilter.Dock = DockStyle.Top;
            txtTableFilter.Location = new Point(0, 146);
            txtTableFilter.Margin = new Padding(3, 2, 3, 2);
            txtTableFilter.Name = "txtTableFilter";
            txtTableFilter.PlaceHolder = "Write something here to filter Table";
            txtTableFilter.Size = new Size(378, 27);
            txtTableFilter.TabIndex = 1;
            txtTableFilter.TabStop = false;
            txtTableFilter.TextChanged += txtTableFilter_TextChanged;
            // 
            // dgvTables
            // 
            dgvTables.AllowUserToAddRows = false;
            dgvTables.AllowUserToDeleteRows = false;
            dgvTables.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvTables.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTables.Columns.AddRange(new DataGridViewColumn[] { dTableName });
            dgvTables.Dock = DockStyle.Fill;
            dgvTables.Location = new Point(0, 173);
            dgvTables.Margin = new Padding(3, 2, 3, 2);
            dgvTables.Name = "dgvTables";
            dgvTables.ReadOnly = true;
            dgvTables.RowHeadersWidth = 51;
            dgvTables.RowTemplate.Height = 24;
            dgvTables.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvTables.Size = new Size(378, 456);
            dgvTables.TabIndex = 0;
            dgvTables.TabStop = false;
            // 
            // dTableName
            // 
            dTableName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dTableName.DataPropertyName = "TableName";
            dTableName.HeaderText = "TableName";
            dTableName.MinimumWidth = 6;
            dTableName.Name = "dTableName";
            dTableName.ReadOnly = true;
            dTableName.ToolTipText = "Double click row to auto generate script";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(tabControl1);
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(378, 146);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Generate Command";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabSQL);
            tabControl1.Controls.Add(tabParameterType);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(3, 22);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(372, 122);
            tabControl1.TabIndex = 3;
            // 
            // tabSQL
            // 
            tabSQL.BackColor = Color.Lavender;
            tabSQL.Controls.Add(btnUpdate);
            tabSQL.Controls.Add(btnInsert);
            tabSQL.Controls.Add(btnSelect);
            tabSQL.Location = new Point(4, 26);
            tabSQL.Name = "tabSQL";
            tabSQL.Padding = new Padding(3);
            tabSQL.Size = new Size(364, 92);
            tabSQL.TabIndex = 0;
            tabSQL.Text = "SQL";
            // 
            // btnUpdate
            // 
            btnUpdate.Dock = DockStyle.Top;
            btnUpdate.Location = new Point(3, 61);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(358, 29);
            btnUpdate.TabIndex = 2;
            btnUpdate.TabStop = false;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btn_Click;
            // 
            // btnInsert
            // 
            btnInsert.Dock = DockStyle.Top;
            btnInsert.Location = new Point(3, 32);
            btnInsert.Margin = new Padding(3, 2, 3, 2);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(358, 29);
            btnInsert.TabIndex = 1;
            btnInsert.TabStop = false;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btn_Click;
            // 
            // btnSelect
            // 
            btnSelect.Dock = DockStyle.Top;
            btnSelect.Location = new Point(3, 3);
            btnSelect.Margin = new Padding(3, 2, 3, 2);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(358, 29);
            btnSelect.TabIndex = 0;
            btnSelect.TabStop = false;
            btnSelect.Text = "Select";
            btnSelect.UseVisualStyleBackColor = true;
            btnSelect.Click += btn_Click;
            // 
            // tabParameterType
            // 
            tabParameterType.BackColor = Color.Lavender;
            tabParameterType.Controls.Add(rdoODBC);
            tabParameterType.Controls.Add(rdoMySQL);
            tabParameterType.Controls.Add(rdoMSSSQL);
            tabParameterType.Location = new Point(4, 26);
            tabParameterType.Name = "tabParameterType";
            tabParameterType.Padding = new Padding(3);
            tabParameterType.Size = new Size(364, 92);
            tabParameterType.TabIndex = 1;
            tabParameterType.Text = "Parameter Type";
            // 
            // rdoODBC
            // 
            rdoODBC.AutoSize = true;
            rdoODBC.Location = new Point(22, 66);
            rdoODBC.Name = "rdoODBC";
            rdoODBC.Size = new Size(67, 20);
            rdoODBC.TabIndex = 2;
            rdoODBC.TabStop = true;
            rdoODBC.Text = "ODBC";
            rdoODBC.UseVisualStyleBackColor = true;
            // 
            // rdoMySQL
            // 
            rdoMySQL.AutoSize = true;
            rdoMySQL.Location = new Point(22, 40);
            rdoMySQL.Name = "rdoMySQL";
            rdoMySQL.Size = new Size(74, 20);
            rdoMySQL.TabIndex = 1;
            rdoMySQL.Text = "MySQL";
            rdoMySQL.UseVisualStyleBackColor = true;
            // 
            // rdoMSSSQL
            // 
            rdoMSSSQL.AutoSize = true;
            rdoMSSSQL.Checked = true;
            rdoMSSSQL.Location = new Point(22, 15);
            rdoMSSSQL.Name = "rdoMSSSQL";
            rdoMSSSQL.Size = new Size(74, 20);
            rdoMSSSQL.TabIndex = 0;
            rdoMSSSQL.TabStop = true;
            rdoMSSSQL.Text = "MSSQL";
            rdoMSSSQL.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 32);
            splitContainer1.Margin = new Padding(3, 2, 3, 2);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(txtResult);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dgvTables);
            splitContainer1.Panel2.Controls.Add(txtTableFilter);
            splitContainer1.Panel2.Controls.Add(groupBox2);
            splitContainer1.Size = new Size(1057, 629);
            splitContainer1.SplitterDistance = 675;
            splitContainer1.TabIndex = 5;
            // 
            // frmCodeGenerator
            // 
            AutoScaleDimensions = new SizeF(9F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1057, 661);
            Controls.Add(splitContainer1);
            Margin = new Padding(4, 2, 4, 2);
            Name = "frmCodeGenerator";
            Text = "frmADONetGenerator";
            Load += frmADONetGenerator_Load;
            Controls.SetChildIndex(panel1, 0);
            Controls.SetChildIndex(splitContainer1, 0);
            ((System.ComponentModel.ISupportInitialize)dgvTables).EndInit();
            groupBox2.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabSQL.ResumeLayout(false);
            tabParameterType.ResumeLayout(false);
            tabParameterType.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private iCat.SQLTools.CustomControlleres.PlaceholderTextBox txtResult;
        private iCat.SQLTools.CustomControlleres.PlaceholderTextBox txtTableFilter;
        private System.Windows.Forms.DataGridView dgvTables;
        private System.Windows.Forms.DataGridViewTextBoxColumn dTableName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private TabControl tabControl1;
        private TabPage tabSQL;
        private TabPage tabParameterType;
        private RadioButton rdoMSSSQL;
        private RadioButton rdoMySQL;
        private RadioButton rdoODBC;
    }
}