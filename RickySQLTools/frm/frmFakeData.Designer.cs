namespace RickySQLTools
{
    partial class frmFakeData
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvTables = new System.Windows.Forms.DataGridView();
            this.IsMake = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dTableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dTableDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dTableType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTableFilter = new RickySQLTools.CustomControll.PlaceholderTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInsert = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvTables);
            this.groupBox1.Controls.Add(this.txtTableFilter);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(552, 540);
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
            this.IsMake,
            this.dTableName,
            this.dTableDescription,
            this.dTableType});
            this.dgvTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTables.Location = new System.Drawing.Point(3, 58);
            this.dgvTables.Name = "dgvTables";
            this.dgvTables.RowTemplate.Height = 24;
            this.dgvTables.Size = new System.Drawing.Size(546, 479);
            this.dgvTables.TabIndex = 0;
            // 
            // IsMake
            // 
            this.IsMake.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.IsMake.DataPropertyName = "IsMakeFakeData";
            this.IsMake.FalseValue = "false";
            this.IsMake.HeaderText = "";
            this.IsMake.Name = "IsMake";
            this.IsMake.TrueValue = "true";
            this.IsMake.Width = 5;
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
            // dTableDescription
            // 
            this.dTableDescription.DataPropertyName = "TableDescription";
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dTableDescription.DefaultCellStyle = dataGridViewCellStyle1;
            this.dTableDescription.HeaderText = "TableDescription";
            this.dTableDescription.MinimumWidth = 200;
            this.dTableDescription.Name = "dTableDescription";
            this.dTableDescription.ReadOnly = true;
            this.dTableDescription.Width = 200;
            // 
            // dTableType
            // 
            this.dTableType.DataPropertyName = "TableType";
            this.dTableType.HeaderText = "TableTyle";
            this.dTableType.Name = "dTableType";
            this.dTableType.ReadOnly = true;
            // 
            // txtTableFilter
            // 
            this.txtTableFilter.BackColor = System.Drawing.SystemColors.Info;
            this.txtTableFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtTableFilter.Location = new System.Drawing.Point(3, 27);
            this.txtTableFilter.Name = "txtTableFilter";
            this.txtTableFilter.PlaceHolder = "Write something here to filter Table";
            this.txtTableFilter.Size = new System.Drawing.Size(546, 31);
            this.txtTableFilter.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 39);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.btnInsert);
            this.splitContainer1.Size = new System.Drawing.Size(851, 540);
            this.splitContainer1.SplitterDistance = 552;
            this.splitContainer1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(3, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(449, 210);
            this.label1.TabIndex = 1;
            this.label1.Text = "Coming soon.....\r\n\r\nPlease do not click the button \r\nabove this message!!\r\n\r\nIf y" +
    "ou click it.\r\nIt will.......................nothing happen~~\r\n";
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(57, 58);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(172, 37);
            this.btnInsert.TabIndex = 0;
            this.btnInsert.Text = "Insert Fake Data";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // frmFakeData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 579);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmFakeData";
            this.Text = "frmFakeData";
            this.Load += new System.EventHandler(this.frmFakeData_Load);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTables)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvTables;
        private CustomControll.PlaceholderTextBox txtTableFilter;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsMake;
        private System.Windows.Forms.DataGridViewTextBoxColumn dTableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dTableDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn dTableType;
        private System.Windows.Forms.Label label1;
    }
}