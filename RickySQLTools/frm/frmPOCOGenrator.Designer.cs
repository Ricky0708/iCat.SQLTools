namespace RickySQLTools
{
    partial class frmPOCOGenrator
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvTables = new System.Windows.Forms.DataGridView();
            this.dTableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTableFilter = new RickySQLTools.CustomControll.PlaceholderTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnFromDB = new System.Windows.Forms.Button();
            this.btnFromScript = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.txtScript = new RickySQLTools.CustomControll.PlaceholderTextBox();
            this.txtClassName = new RickySQLTools.CustomControll.PlaceholderTextBox();
            this.txtResult = new RickySQLTools.CustomControll.PlaceholderTextBox();
            this.groupBox1.SuspendLayout();
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
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvTables);
            this.groupBox1.Controls.Add(this.txtTableFilter);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 168);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(333, 412);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tables";
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
            this.dgvTables.Location = new System.Drawing.Point(3, 58);
            this.dgvTables.Name = "dgvTables";
            this.dgvTables.ReadOnly = true;
            this.dgvTables.RowTemplate.Height = 24;
            this.dgvTables.Size = new System.Drawing.Size(327, 351);
            this.dgvTables.TabIndex = 0;
            this.dgvTables.TabStop = false;
            this.dgvTables.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTables_CellDoubleClick);
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
            this.txtTableFilter.Location = new System.Drawing.Point(3, 27);
            this.txtTableFilter.Name = "txtTableFilter";
            this.txtTableFilter.PlaceHolder = "Write something here to filter Table";
            this.txtTableFilter.Size = new System.Drawing.Size(327, 31);
            this.txtTableFilter.TabIndex = 1;
            this.txtTableFilter.TabStop = false;
            this.txtTableFilter.TextChanged += new System.EventHandler(this.txtTableFilter_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnFromDB);
            this.groupBox2.Controls.Add(this.btnFromScript);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(333, 168);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Generate Command";
            // 
            // btnFromDB
            // 
            this.btnFromDB.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFromDB.Location = new System.Drawing.Point(3, 63);
            this.btnFromDB.Name = "btnFromDB";
            this.btnFromDB.Size = new System.Drawing.Size(327, 36);
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
            this.btnFromScript.Size = new System.Drawing.Size(327, 36);
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
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
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
            this.splitContainer2.SplitterDistance = 172;
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
            this.txtScript.Size = new System.Drawing.Size(513, 137);
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
            this.txtResult.Size = new System.Drawing.Size(513, 404);
            this.txtResult.TabIndex = 0;
            this.txtResult.TabStop = false;
            this.txtResult.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // frmPOCOGenrator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 623);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "frmPOCOGenrator";
            this.Text = "POCO_Genrator";
            this.Load += new System.EventHandler(this.frmPOCOGenrator_Load);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvTables;
        private CustomControll.PlaceholderTextBox txtTableFilter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private CustomControll.PlaceholderTextBox txtScript;
        private CustomControll.PlaceholderTextBox txtResult;
        private System.Windows.Forms.Button btnFromDB;
        private System.Windows.Forms.Button btnFromScript;
        private CustomControll.PlaceholderTextBox txtClassName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dTableName;
    }
}