namespace RickySQLTools
{
    partial class XmlCompare
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtSecondXml = new RickySQLTools.CustomControll.PlaceholderTextBox();
            this.txtFirstXml = new RickySQLTools.CustomControll.PlaceholderTextBox();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnSecond = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvTables = new System.Windows.Forms.DataGridView();
            this.dTableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d1XmlA = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.d1XmlB = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvColumns = new System.Windows.Forms.DataGridView();
            this.d2TableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d2XmlA = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.d2XmlB = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dType_Equal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvSpsAndFuncs = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblState = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnCompare = new System.Windows.Forms.Button();
            this.dSPECIFIC_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d3XmlA = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.d3XmlB = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTables)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpsAndFuncs)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSecondXml
            // 
            this.txtSecondXml.BackColor = System.Drawing.SystemColors.Info;
            this.txtSecondXml.Location = new System.Drawing.Point(88, 76);
            this.txtSecondXml.Name = "txtSecondXml";
            this.txtSecondXml.PlaceHolder = "Second xml file here";
            this.txtSecondXml.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSecondXml.Size = new System.Drawing.Size(662, 31);
            this.txtSecondXml.TabIndex = 1;
            // 
            // txtFirstXml
            // 
            this.txtFirstXml.BackColor = System.Drawing.SystemColors.Info;
            this.txtFirstXml.Location = new System.Drawing.Point(88, 39);
            this.txtFirstXml.Name = "txtFirstXml";
            this.txtFirstXml.PlaceHolder = "First xml file here";
            this.txtFirstXml.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFirstXml.Size = new System.Drawing.Size(662, 31);
            this.txtFirstXml.TabIndex = 2;
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(51, 40);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(31, 30);
            this.btnFirst.TabIndex = 3;
            this.btnFirst.Text = "...";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.LoadXml_Click);
            // 
            // btnSecond
            // 
            this.btnSecond.Location = new System.Drawing.Point(51, 77);
            this.btnSecond.Name = "btnSecond";
            this.btnSecond.Size = new System.Drawing.Size(31, 30);
            this.btnSecond.TabIndex = 4;
            this.btnSecond.Text = "...";
            this.btnSecond.UseVisualStyleBackColor = true;
            this.btnSecond.Click += new System.EventHandler(this.LoadXml_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 220);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(783, 397);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvTables);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(775, 363);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tables";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvTables
            // 
            this.dgvTables.AllowUserToAddRows = false;
            this.dgvTables.AllowUserToDeleteRows = false;
            this.dgvTables.AllowUserToOrderColumns = true;
            this.dgvTables.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dTableName,
            this.d1XmlA,
            this.d1XmlB});
            this.dgvTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTables.Location = new System.Drawing.Point(3, 3);
            this.dgvTables.Name = "dgvTables";
            this.dgvTables.RowTemplate.Height = 24;
            this.dgvTables.Size = new System.Drawing.Size(769, 357);
            this.dgvTables.TabIndex = 1;
            // 
            // dTableName
            // 
            this.dTableName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dTableName.DataPropertyName = "TableName";
            this.dTableName.HeaderText = "TableName";
            this.dTableName.Name = "dTableName";
            this.dTableName.ReadOnly = true;
            this.dTableName.Width = 124;
            // 
            // d1XmlA
            // 
            this.d1XmlA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.d1XmlA.DataPropertyName = "Xml_A";
            this.d1XmlA.HeaderText = "Xml A";
            this.d1XmlA.Name = "d1XmlA";
            this.d1XmlA.ReadOnly = true;
            this.d1XmlA.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.d1XmlA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.d1XmlA.Width = 91;
            // 
            // d1XmlB
            // 
            this.d1XmlB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.d1XmlB.DataPropertyName = "Xml_B";
            this.d1XmlB.HeaderText = "Xml B";
            this.d1XmlB.Name = "d1XmlB";
            this.d1XmlB.ReadOnly = true;
            this.d1XmlB.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.d1XmlB.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.d1XmlB.Width = 90;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvColumns);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(775, 363);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Columns";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvColumns
            // 
            this.dgvColumns.AllowUserToAddRows = false;
            this.dgvColumns.AllowUserToDeleteRows = false;
            this.dgvColumns.AllowUserToOrderColumns = true;
            this.dgvColumns.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColumns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.d2TableName,
            this.dColName,
            this.d2XmlA,
            this.d2XmlB,
            this.dType_Equal});
            this.dgvColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvColumns.Location = new System.Drawing.Point(3, 3);
            this.dgvColumns.Name = "dgvColumns";
            this.dgvColumns.RowTemplate.Height = 24;
            this.dgvColumns.Size = new System.Drawing.Size(769, 357);
            this.dgvColumns.TabIndex = 2;
            // 
            // d2TableName
            // 
            this.d2TableName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.d2TableName.DataPropertyName = "TableName";
            this.d2TableName.HeaderText = "Table Name";
            this.d2TableName.Name = "d2TableName";
            this.d2TableName.ReadOnly = true;
            this.d2TableName.Width = 129;
            // 
            // dColName
            // 
            this.dColName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dColName.DataPropertyName = "ColName";
            this.dColName.HeaderText = "ColName";
            this.dColName.MinimumWidth = 100;
            this.dColName.Name = "dColName";
            this.dColName.ReadOnly = true;
            this.dColName.Width = 110;
            // 
            // d2XmlA
            // 
            this.d2XmlA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.d2XmlA.DataPropertyName = "Xml_A";
            this.d2XmlA.HeaderText = "Xml A";
            this.d2XmlA.Name = "d2XmlA";
            this.d2XmlA.ReadOnly = true;
            this.d2XmlA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.d2XmlA.Width = 91;
            // 
            // d2XmlB
            // 
            this.d2XmlB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.d2XmlB.DataPropertyName = "Xml_B";
            this.d2XmlB.HeaderText = "Xml B";
            this.d2XmlB.Name = "d2XmlB";
            this.d2XmlB.ReadOnly = true;
            this.d2XmlB.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.d2XmlB.Width = 90;
            // 
            // dType_Equal
            // 
            this.dType_Equal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dType_Equal.DataPropertyName = "Type_Equal";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dType_Equal.DefaultCellStyle = dataGridViewCellStyle2;
            this.dType_Equal.HeaderText = "Type Equal";
            this.dType_Equal.Name = "dType_Equal";
            this.dType_Equal.ReadOnly = true;
            this.dType_Equal.Width = 122;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvSpsAndFuncs);
            this.tabPage3.Location = new System.Drawing.Point(4, 30);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(775, 363);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "SPs & Funcs";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvSpsAndFuncs
            // 
            this.dgvSpsAndFuncs.AllowUserToAddRows = false;
            this.dgvSpsAndFuncs.AllowUserToDeleteRows = false;
            this.dgvSpsAndFuncs.AllowUserToOrderColumns = true;
            this.dgvSpsAndFuncs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSpsAndFuncs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dSPECIFIC_NAME,
            this.d3XmlA,
            this.d3XmlB});
            this.dgvSpsAndFuncs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSpsAndFuncs.Location = new System.Drawing.Point(3, 3);
            this.dgvSpsAndFuncs.Name = "dgvSpsAndFuncs";
            this.dgvSpsAndFuncs.ReadOnly = true;
            this.dgvSpsAndFuncs.RowTemplate.Height = 24;
            this.dgvSpsAndFuncs.Size = new System.Drawing.Size(769, 357);
            this.dgvSpsAndFuncs.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblState);
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Controls.Add(this.btnCompare);
            this.panel2.Controls.Add(this.txtFirstXml);
            this.panel2.Controls.Add(this.txtSecondXml);
            this.panel2.Controls.Add(this.btnSecond);
            this.panel2.Controls.Add(this.btnFirst);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(783, 181);
            this.panel2.TabIndex = 6;
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(12, 135);
            this.lblState.Name = "lblState";
            this.lblState.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblState.Size = new System.Drawing.Size(19, 20);
            this.lblState.TabIndex = 7;
            this.lblState.Text = "..";
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 158);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(783, 23);
            this.progressBar1.TabIndex = 6;
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(612, 114);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(137, 33);
            this.btnCompare.TabIndex = 5;
            this.btnCompare.Text = "Start Compare";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
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
            // d3XmlA
            // 
            this.d3XmlA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.d3XmlA.DataPropertyName = "Xml_A";
            this.d3XmlA.HeaderText = "Xml A";
            this.d3XmlA.Name = "d3XmlA";
            this.d3XmlA.ReadOnly = true;
            this.d3XmlA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.d3XmlA.Width = 91;
            // 
            // d3XmlB
            // 
            this.d3XmlB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.d3XmlB.DataPropertyName = "Xml_B";
            this.d3XmlB.HeaderText = "Xml B";
            this.d3XmlB.Name = "d3XmlB";
            this.d3XmlB.ReadOnly = true;
            this.d3XmlB.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.d3XmlB.Width = 90;
            // 
            // XmlCompare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 617);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Name = "XmlCompare";
            this.Text = "XmlCompare";
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTables)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpsAndFuncs)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControll.PlaceholderTextBox txtSecondXml;
        private CustomControll.PlaceholderTextBox txtFirstXml;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnSecond;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgvTables;
        private System.Windows.Forms.DataGridView dgvColumns;
        private System.Windows.Forms.DataGridView dgvSpsAndFuncs;
        private System.Windows.Forms.DataGridViewTextBoxColumn dTableName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn d1XmlA;
        private System.Windows.Forms.DataGridViewCheckBoxColumn d1XmlB;
        private System.Windows.Forms.DataGridViewTextBoxColumn d2TableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dColName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn d2XmlA;
        private System.Windows.Forms.DataGridViewCheckBoxColumn d2XmlB;
        private System.Windows.Forms.DataGridViewTextBoxColumn dType_Equal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSPECIFIC_NAME;
        private System.Windows.Forms.DataGridViewCheckBoxColumn d3XmlA;
        private System.Windows.Forms.DataGridViewCheckBoxColumn d3XmlB;
    }
}