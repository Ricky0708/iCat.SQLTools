namespace iCat.SQLTools.Forms
{
    partial class frmTables
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            groupBox1 = new GroupBox();
            dgvTables = new DataGridView();
            dTableName = new DataGridViewTextBoxColumn();
            dTableDescription = new DataGridViewTextBoxColumn();
            dTableType = new DataGridViewTextBoxColumn();
            txtTableFilter = new CustomControlleres.PlaceholderTextBox();
            tabControl1 = new TabControl();
            tabCommand = new TabPage();
            groupBox6 = new GroupBox();
            btnExportExcel = new Button();
            groupBox5 = new GroupBox();
            btnLoadDataFromXML = new Button();
            btnSaveToXml = new Button();
            groupBox4 = new GroupBox();
            btnUpdateAllDescription = new Button();
            btnLoadDataFromSQL = new Button();
            btnUpdateDescription = new Button();
            tabTablesAndCols = new TabPage();
            splitContainer1 = new SplitContainer();
            splitContainer5 = new SplitContainer();
            groupBox2 = new GroupBox();
            dgvColumns = new DataGridView();
            dColName = new DataGridViewTextBoxColumn();
            dColType = new DataGridViewTextBoxColumn();
            dColLength = new DataGridViewTextBoxColumn();
            dDefaultValue = new DataGridViewTextBoxColumn();
            dIsNullable = new DataGridViewCheckBoxColumn();
            dColDescription = new DataGridViewTextBoxColumn();
            dIsIdentity = new DataGridViewCheckBoxColumn();
            dIsPK = new DataGridViewCheckBoxColumn();
            dCollationName = new DataGridViewTextBoxColumn();
            splitContainer2 = new SplitContainer();
            groupBox7 = new GroupBox();
            dgvIndexes = new DataGridView();
            dIndexName = new DataGridViewTextBoxColumn();
            dIxColName = new DataGridViewTextBoxColumn();
            groupBox3 = new GroupBox();
            dgvFK = new DataGridView();
            dName = new DataGridViewTextBoxColumn();
            dMasterTable = new DataGridViewTextBoxColumn();
            dMasterCol = new DataGridViewTextBoxColumn();
            dDetail = new DataGridViewTextBoxColumn();
            dDetailCol = new DataGridViewTextBoxColumn();
            tabSpsAndFuncs = new TabPage();
            splitContainer3 = new SplitContainer();
            dgvSpsAndFuncs = new DataGridView();
            dSPECIFIC_NAME = new DataGridViewTextBoxColumn();
            dROUTINE_TYPE = new DataGridViewTextBoxColumn();
            dDATA_TYPE = new DataGridViewTextBoxColumn();
            dROUTINE_DEFINITION = new DataGridViewTextBoxColumn();
            txtSpFilter = new CustomControlleres.PlaceholderTextBox();
            splitContainer4 = new SplitContainer();
            dgvInputParams = new DataGridView();
            dISPECIFIC_NAME = new DataGridViewTextBoxColumn();
            dParameter_Name = new DataGridViewTextBoxColumn();
            dIData_Type = new DataGridViewTextBoxColumn();
            dCharacter_Maximum_Length = new DataGridViewTextBoxColumn();
            dParameter_Mode = new DataGridViewTextBoxColumn();
            dgvOutPutParams = new DataGridView();
            dOSPECIFIC_NAME = new DataGridViewTextBoxColumn();
            dOName = new DataGridViewTextBoxColumn();
            dSystem_Type_Name = new DataGridViewTextBoxColumn();
            dError_Message = new DataGridViewTextBoxColumn();
            cboSettingKey = new ComboBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTables).BeginInit();
            tabControl1.SuspendLayout();
            tabCommand.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox4.SuspendLayout();
            tabTablesAndCols.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer5).BeginInit();
            splitContainer5.Panel1.SuspendLayout();
            splitContainer5.Panel2.SuspendLayout();
            splitContainer5.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvColumns).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIndexes).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFK).BeginInit();
            tabSpsAndFuncs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSpsAndFuncs).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer4).BeginInit();
            splitContainer4.Panel1.SuspendLayout();
            splitContainer4.Panel2.SuspendLayout();
            splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInputParams).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvOutPutParams).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Size = new Size(1076, 32);
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvTables);
            groupBox1.Controls.Add(txtTableFilter);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(348, 520);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tables";
            // 
            // dgvTables
            // 
            dgvTables.AllowUserToAddRows = false;
            dgvTables.AllowUserToDeleteRows = false;
            dgvTables.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTables.Columns.AddRange(new DataGridViewColumn[] { dTableName, dTableDescription, dTableType });
            dgvTables.Dock = DockStyle.Fill;
            dgvTables.Location = new Point(3, 49);
            dgvTables.Margin = new Padding(3, 2, 3, 2);
            dgvTables.Name = "dgvTables";
            dgvTables.RowTemplate.Height = 24;
            dgvTables.Size = new Size(342, 469);
            dgvTables.TabIndex = 0;
            // 
            // dTableName
            // 
            dTableName.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dTableName.DataPropertyName = "TableName";
            dTableName.HeaderText = "TableName";
            dTableName.Name = "dTableName";
            dTableName.ReadOnly = true;
            dTableName.Width = 104;
            // 
            // dTableDescription
            // 
            dTableDescription.DataPropertyName = "TableDescription";
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dTableDescription.DefaultCellStyle = dataGridViewCellStyle3;
            dTableDescription.HeaderText = "TableDescription";
            dTableDescription.MinimumWidth = 100;
            dTableDescription.Name = "dTableDescription";
            // 
            // dTableType
            // 
            dTableType.DataPropertyName = "TableType";
            dTableType.HeaderText = "TableTyle";
            dTableType.Name = "dTableType";
            dTableType.ReadOnly = true;
            // 
            // txtTableFilter
            // 
            txtTableFilter.BackColor = SystemColors.Info;
            txtTableFilter.Dock = DockStyle.Top;
            txtTableFilter.Location = new Point(3, 22);
            txtTableFilter.Margin = new Padding(3, 2, 3, 2);
            txtTableFilter.Name = "txtTableFilter";
            txtTableFilter.PlaceHolder = "Write something here to filter Table";
            txtTableFilter.Size = new Size(342, 27);
            txtTableFilter.TabIndex = 1;
            txtTableFilter.TextChanged += Filter;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabCommand);
            tabControl1.Controls.Add(tabTablesAndCols);
            tabControl1.Controls.Add(tabSpsAndFuncs);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 32);
            tabControl1.Margin = new Padding(3, 2, 3, 2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1076, 558);
            tabControl1.TabIndex = 2;
            tabControl1.TabStop = false;
            // 
            // tabCommand
            // 
            tabCommand.Controls.Add(groupBox6);
            tabCommand.Controls.Add(groupBox5);
            tabCommand.Controls.Add(groupBox4);
            tabCommand.Location = new Point(4, 26);
            tabCommand.Margin = new Padding(3, 2, 3, 2);
            tabCommand.Name = "tabCommand";
            tabCommand.Padding = new Padding(3, 2, 3, 2);
            tabCommand.Size = new Size(1068, 528);
            tabCommand.TabIndex = 1;
            tabCommand.Text = "Command";
            tabCommand.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(btnExportExcel);
            groupBox6.Location = new Point(37, 260);
            groupBox6.Margin = new Padding(3, 2, 3, 2);
            groupBox6.Name = "groupBox6";
            groupBox6.Padding = new Padding(3, 2, 3, 2);
            groupBox6.Size = new Size(235, 258);
            groupBox6.TabIndex = 6;
            groupBox6.TabStop = false;
            groupBox6.Text = "Generator";
            // 
            // btnExportExcel
            // 
            btnExportExcel.Location = new Point(5, 24);
            btnExportExcel.Margin = new Padding(3, 2, 3, 2);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(155, 32);
            btnExportExcel.TabIndex = 4;
            btnExportExcel.Text = "Export to Excel";
            btnExportExcel.UseVisualStyleBackColor = true;
            btnExportExcel.Click += btnExportExcel_Click;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(btnLoadDataFromXML);
            groupBox5.Controls.Add(btnSaveToXml);
            groupBox5.Location = new Point(277, 35);
            groupBox5.Margin = new Padding(3, 2, 3, 2);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new Padding(3, 2, 3, 2);
            groupBox5.Size = new Size(282, 220);
            groupBox5.TabIndex = 5;
            groupBox5.TabStop = false;
            groupBox5.Text = "XML";
            // 
            // btnLoadDataFromXML
            // 
            btnLoadDataFromXML.Location = new Point(5, 24);
            btnLoadDataFromXML.Margin = new Padding(3, 2, 3, 2);
            btnLoadDataFromXML.Name = "btnLoadDataFromXML";
            btnLoadDataFromXML.Size = new Size(155, 32);
            btnLoadDataFromXML.TabIndex = 5;
            btnLoadDataFromXML.Text = "Load Data";
            btnLoadDataFromXML.UseVisualStyleBackColor = true;
            btnLoadDataFromXML.Click += btnLoadDataFromXML_Click;
            // 
            // btnSaveToXml
            // 
            btnSaveToXml.Location = new Point(5, 183);
            btnSaveToXml.Margin = new Padding(3, 2, 3, 2);
            btnSaveToXml.Name = "btnSaveToXml";
            btnSaveToXml.Size = new Size(155, 32);
            btnSaveToXml.TabIndex = 5;
            btnSaveToXml.Text = "Save To Xml";
            btnSaveToXml.UseVisualStyleBackColor = true;
            btnSaveToXml.Click += btnSaveToXml_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(cboSettingKey);
            groupBox4.Controls.Add(btnUpdateAllDescription);
            groupBox4.Controls.Add(btnLoadDataFromSQL);
            groupBox4.Controls.Add(btnUpdateDescription);
            groupBox4.Location = new Point(37, 35);
            groupBox4.Margin = new Padding(3, 2, 3, 2);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(3, 2, 3, 2);
            groupBox4.Size = new Size(235, 220);
            groupBox4.TabIndex = 4;
            groupBox4.TabStop = false;
            groupBox4.Text = "SQL Server";
            // 
            // btnUpdateAllDescription
            // 
            btnUpdateAllDescription.Location = new Point(5, 98);
            btnUpdateAllDescription.Margin = new Padding(3, 2, 3, 2);
            btnUpdateAllDescription.Name = "btnUpdateAllDescription";
            btnUpdateAllDescription.Size = new Size(224, 32);
            btnUpdateAllDescription.TabIndex = 6;
            btnUpdateAllDescription.Text = "Update All Description";
            btnUpdateAllDescription.UseVisualStyleBackColor = true;
            btnUpdateAllDescription.Click += btnUpdateAllDescription_Click;
            // 
            // btnLoadDataFromSQL
            // 
            btnLoadDataFromSQL.Location = new Point(147, 24);
            btnLoadDataFromSQL.Margin = new Padding(3, 2, 3, 2);
            btnLoadDataFromSQL.Name = "btnLoadDataFromSQL";
            btnLoadDataFromSQL.Size = new Size(82, 32);
            btnLoadDataFromSQL.TabIndex = 4;
            btnLoadDataFromSQL.Text = "Load Data";
            btnLoadDataFromSQL.UseVisualStyleBackColor = true;
            btnLoadDataFromSQL.Click += btnLoadDataFromSQL_Click;
            // 
            // btnUpdateDescription
            // 
            btnUpdateDescription.Location = new Point(5, 61);
            btnUpdateDescription.Margin = new Padding(3, 2, 3, 2);
            btnUpdateDescription.Name = "btnUpdateDescription";
            btnUpdateDescription.Size = new Size(224, 32);
            btnUpdateDescription.TabIndex = 3;
            btnUpdateDescription.Text = "Update Modified Description";
            btnUpdateDescription.UseVisualStyleBackColor = true;
            btnUpdateDescription.Click += Update_Description_Click;
            // 
            // tabTablesAndCols
            // 
            tabTablesAndCols.Controls.Add(splitContainer1);
            tabTablesAndCols.Location = new Point(4, 26);
            tabTablesAndCols.Margin = new Padding(3, 2, 3, 2);
            tabTablesAndCols.Name = "tabTablesAndCols";
            tabTablesAndCols.Padding = new Padding(3, 2, 3, 2);
            tabTablesAndCols.Size = new Size(1068, 528);
            tabTablesAndCols.TabIndex = 0;
            tabTablesAndCols.Text = "Tables & Columns";
            tabTablesAndCols.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.BackColor = Color.Transparent;
            splitContainer1.BorderStyle = BorderStyle.Fixed3D;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 2);
            splitContainer1.Margin = new Padding(3, 2, 3, 2);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer5);
            splitContainer1.Size = new Size(1062, 524);
            splitContainer1.SplitterDistance = 352;
            splitContainer1.TabIndex = 2;
            splitContainer1.TabStop = false;
            // 
            // splitContainer5
            // 
            splitContainer5.BorderStyle = BorderStyle.Fixed3D;
            splitContainer5.Dock = DockStyle.Fill;
            splitContainer5.Location = new Point(0, 0);
            splitContainer5.Margin = new Padding(3, 2, 3, 2);
            splitContainer5.Name = "splitContainer5";
            splitContainer5.Orientation = Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            splitContainer5.Panel1.Controls.Add(groupBox2);
            // 
            // splitContainer5.Panel2
            // 
            splitContainer5.Panel2.Controls.Add(splitContainer2);
            splitContainer5.Size = new Size(706, 524);
            splitContainer5.SplitterDistance = 148;
            splitContainer5.SplitterWidth = 2;
            splitContainer5.TabIndex = 2;
            splitContainer5.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvColumns);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(702, 144);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Columns Info";
            // 
            // dgvColumns
            // 
            dgvColumns.AllowUserToAddRows = false;
            dgvColumns.AllowUserToDeleteRows = false;
            dgvColumns.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvColumns.Columns.AddRange(new DataGridViewColumn[] { dColName, dColType, dColLength, dDefaultValue, dIsNullable, dColDescription, dIsIdentity, dIsPK, dCollationName });
            dgvColumns.Dock = DockStyle.Fill;
            dgvColumns.Location = new Point(3, 22);
            dgvColumns.Margin = new Padding(3, 2, 3, 2);
            dgvColumns.Name = "dgvColumns";
            dgvColumns.RowTemplate.Height = 24;
            dgvColumns.Size = new Size(696, 120);
            dgvColumns.TabIndex = 1;
            dgvColumns.TabStop = false;
            // 
            // dColName
            // 
            dColName.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dColName.DataPropertyName = "ColName";
            dColName.HeaderText = "ColName";
            dColName.MinimumWidth = 100;
            dColName.Name = "dColName";
            dColName.ReadOnly = true;
            // 
            // dColType
            // 
            dColType.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dColType.DataPropertyName = "ColType";
            dColType.HeaderText = "ColType";
            dColType.Name = "dColType";
            dColType.ReadOnly = true;
            dColType.Width = 86;
            // 
            // dColLength
            // 
            dColLength.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dColLength.DataPropertyName = "ColLength";
            dColLength.HeaderText = "ColLength";
            dColLength.Name = "dColLength";
            dColLength.ReadOnly = true;
            dColLength.Width = 98;
            // 
            // dDefaultValue
            // 
            dDefaultValue.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dDefaultValue.DataPropertyName = "DefaultValue";
            dDefaultValue.HeaderText = "DefaultValue";
            dDefaultValue.Name = "dDefaultValue";
            dDefaultValue.ReadOnly = true;
            dDefaultValue.Width = 115;
            // 
            // dIsNullable
            // 
            dIsNullable.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dIsNullable.DataPropertyName = "IsNullable";
            dIsNullable.HeaderText = "IsNullable";
            dIsNullable.Name = "dIsNullable";
            dIsNullable.ReadOnly = true;
            dIsNullable.Resizable = DataGridViewTriState.True;
            dIsNullable.Width = 77;
            // 
            // dColDescription
            // 
            dColDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dColDescription.DataPropertyName = "ColDescription";
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dColDescription.DefaultCellStyle = dataGridViewCellStyle4;
            dColDescription.HeaderText = "ColDescription";
            dColDescription.Name = "dColDescription";
            dColDescription.Width = 126;
            // 
            // dIsIdentity
            // 
            dIsIdentity.DataPropertyName = "IsIdentity";
            dIsIdentity.HeaderText = "IsIdentity";
            dIsIdentity.Name = "dIsIdentity";
            dIsIdentity.ReadOnly = true;
            dIsIdentity.Resizable = DataGridViewTriState.True;
            // 
            // dIsPK
            // 
            dIsPK.DataPropertyName = "IsPK";
            dIsPK.HeaderText = "IsPK";
            dIsPK.Name = "dIsPK";
            dIsPK.ReadOnly = true;
            dIsPK.TrueValue = "";
            // 
            // dCollationName
            // 
            dCollationName.DataPropertyName = "CollationName";
            dCollationName.HeaderText = "CollationName";
            dCollationName.Name = "dCollationName";
            dCollationName.ReadOnly = true;
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
            splitContainer2.Panel1.Controls.Add(groupBox7);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(groupBox3);
            splitContainer2.Size = new Size(706, 374);
            splitContainer2.SplitterDistance = 75;
            splitContainer2.SplitterWidth = 2;
            splitContainer2.TabIndex = 1;
            splitContainer2.TabStop = false;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(dgvIndexes);
            groupBox7.Dock = DockStyle.Fill;
            groupBox7.Location = new Point(0, 0);
            groupBox7.Margin = new Padding(3, 2, 3, 2);
            groupBox7.Name = "groupBox7";
            groupBox7.Padding = new Padding(3, 2, 3, 2);
            groupBox7.Size = new Size(702, 71);
            groupBox7.TabIndex = 0;
            groupBox7.TabStop = false;
            groupBox7.Text = "PK && IX";
            // 
            // dgvIndexes
            // 
            dgvIndexes.AllowUserToAddRows = false;
            dgvIndexes.AllowUserToDeleteRows = false;
            dgvIndexes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIndexes.Columns.AddRange(new DataGridViewColumn[] { dIndexName, dIxColName });
            dgvIndexes.Dock = DockStyle.Fill;
            dgvIndexes.Location = new Point(3, 22);
            dgvIndexes.Margin = new Padding(3, 2, 3, 2);
            dgvIndexes.Name = "dgvIndexes";
            dgvIndexes.RowTemplate.Height = 24;
            dgvIndexes.Size = new Size(696, 47);
            dgvIndexes.TabIndex = 2;
            dgvIndexes.TabStop = false;
            // 
            // dIndexName
            // 
            dIndexName.DataPropertyName = "IndexName";
            dIndexName.HeaderText = "IndexName";
            dIndexName.MinimumWidth = 200;
            dIndexName.Name = "dIndexName";
            dIndexName.ReadOnly = true;
            dIndexName.Width = 200;
            // 
            // dIxColName
            // 
            dIxColName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dIxColName.DataPropertyName = "ColName";
            dIxColName.HeaderText = "ColName";
            dIxColName.Name = "dIxColName";
            dIxColName.ReadOnly = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dgvFK);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Location = new Point(0, 0);
            groupBox3.Margin = new Padding(3, 2, 3, 2);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 2, 3, 2);
            groupBox3.Size = new Size(702, 293);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            groupBox3.Text = "FK";
            // 
            // dgvFK
            // 
            dgvFK.AllowUserToAddRows = false;
            dgvFK.AllowUserToDeleteRows = false;
            dgvFK.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFK.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFK.Columns.AddRange(new DataGridViewColumn[] { dName, dMasterTable, dMasterCol, dDetail, dDetailCol });
            dgvFK.Dock = DockStyle.Fill;
            dgvFK.Location = new Point(3, 22);
            dgvFK.Margin = new Padding(3, 2, 3, 2);
            dgvFK.Name = "dgvFK";
            dgvFK.ReadOnly = true;
            dgvFK.RowTemplate.Height = 24;
            dgvFK.Size = new Size(696, 269);
            dgvFK.TabIndex = 2;
            dgvFK.TabStop = false;
            // 
            // dName
            // 
            dName.DataPropertyName = "name";
            dName.HeaderText = "Name";
            dName.Name = "dName";
            dName.ReadOnly = true;
            // 
            // dMasterTable
            // 
            dMasterTable.DataPropertyName = "ReferencedTable";
            dMasterTable.HeaderText = "MasterTable";
            dMasterTable.Name = "dMasterTable";
            dMasterTable.ReadOnly = true;
            // 
            // dMasterCol
            // 
            dMasterCol.DataPropertyName = "ReferencedColumn";
            dMasterCol.HeaderText = "MasterCol";
            dMasterCol.Name = "dMasterCol";
            dMasterCol.ReadOnly = true;
            // 
            // dDetail
            // 
            dDetail.DataPropertyName = "ParentTable";
            dDetail.HeaderText = "DetailTable";
            dDetail.Name = "dDetail";
            dDetail.ReadOnly = true;
            // 
            // dDetailCol
            // 
            dDetailCol.DataPropertyName = "ParentColumn";
            dDetailCol.HeaderText = "DetaliCol";
            dDetailCol.Name = "dDetailCol";
            dDetailCol.ReadOnly = true;
            // 
            // tabSpsAndFuncs
            // 
            tabSpsAndFuncs.Controls.Add(splitContainer3);
            tabSpsAndFuncs.Location = new Point(4, 26);
            tabSpsAndFuncs.Margin = new Padding(3, 2, 3, 2);
            tabSpsAndFuncs.Name = "tabSpsAndFuncs";
            tabSpsAndFuncs.Padding = new Padding(3, 2, 3, 2);
            tabSpsAndFuncs.Size = new Size(1068, 528);
            tabSpsAndFuncs.TabIndex = 2;
            tabSpsAndFuncs.Text = "SP & Func";
            tabSpsAndFuncs.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.Location = new Point(3, 2);
            splitContainer3.Margin = new Padding(3, 2, 3, 2);
            splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(dgvSpsAndFuncs);
            splitContainer3.Panel1.Controls.Add(txtSpFilter);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(splitContainer4);
            splitContainer3.Size = new Size(1062, 524);
            splitContainer3.SplitterDistance = 625;
            splitContainer3.TabIndex = 0;
            splitContainer3.TabStop = false;
            // 
            // dgvSpsAndFuncs
            // 
            dgvSpsAndFuncs.AllowUserToAddRows = false;
            dgvSpsAndFuncs.AllowUserToDeleteRows = false;
            dgvSpsAndFuncs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSpsAndFuncs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSpsAndFuncs.Columns.AddRange(new DataGridViewColumn[] { dSPECIFIC_NAME, dROUTINE_TYPE, dDATA_TYPE, dROUTINE_DEFINITION });
            dgvSpsAndFuncs.Dock = DockStyle.Fill;
            dgvSpsAndFuncs.Location = new Point(0, 27);
            dgvSpsAndFuncs.Margin = new Padding(3, 2, 3, 2);
            dgvSpsAndFuncs.Name = "dgvSpsAndFuncs";
            dgvSpsAndFuncs.ReadOnly = true;
            dgvSpsAndFuncs.RowTemplate.Height = 24;
            dgvSpsAndFuncs.Size = new Size(625, 497);
            dgvSpsAndFuncs.TabIndex = 3;
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
            // dROUTINE_DEFINITION
            // 
            dROUTINE_DEFINITION.DataPropertyName = "ROUTINE_DEFINITION";
            dROUTINE_DEFINITION.HeaderText = "Script";
            dROUTINE_DEFINITION.MinimumWidth = 100;
            dROUTINE_DEFINITION.Name = "dROUTINE_DEFINITION";
            dROUTINE_DEFINITION.ReadOnly = true;
            // 
            // txtSpFilter
            // 
            txtSpFilter.BackColor = SystemColors.Info;
            txtSpFilter.Dock = DockStyle.Top;
            txtSpFilter.Location = new Point(0, 0);
            txtSpFilter.Margin = new Padding(3, 2, 3, 2);
            txtSpFilter.Name = "txtSpFilter";
            txtSpFilter.PlaceHolder = "Write something here to filter SP && Func";
            txtSpFilter.Size = new Size(625, 27);
            txtSpFilter.TabIndex = 4;
            txtSpFilter.TextChanged += Filter;
            // 
            // splitContainer4
            // 
            splitContainer4.Dock = DockStyle.Fill;
            splitContainer4.Location = new Point(0, 0);
            splitContainer4.Margin = new Padding(3, 2, 3, 2);
            splitContainer4.Name = "splitContainer4";
            splitContainer4.Orientation = Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            splitContainer4.Panel1.Controls.Add(dgvInputParams);
            // 
            // splitContainer4.Panel2
            // 
            splitContainer4.Panel2.Controls.Add(dgvOutPutParams);
            splitContainer4.Size = new Size(433, 524);
            splitContainer4.SplitterDistance = 238;
            splitContainer4.SplitterWidth = 2;
            splitContainer4.TabIndex = 0;
            splitContainer4.TabStop = false;
            // 
            // dgvInputParams
            // 
            dgvInputParams.AllowUserToAddRows = false;
            dgvInputParams.AllowUserToDeleteRows = false;
            dgvInputParams.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInputParams.Columns.AddRange(new DataGridViewColumn[] { dISPECIFIC_NAME, dParameter_Name, dIData_Type, dCharacter_Maximum_Length, dParameter_Mode });
            dgvInputParams.Dock = DockStyle.Fill;
            dgvInputParams.Location = new Point(0, 0);
            dgvInputParams.Margin = new Padding(3, 2, 3, 2);
            dgvInputParams.Name = "dgvInputParams";
            dgvInputParams.ReadOnly = true;
            dgvInputParams.RowTemplate.Height = 24;
            dgvInputParams.Size = new Size(433, 238);
            dgvInputParams.TabIndex = 1;
            dgvInputParams.TabStop = false;
            // 
            // dISPECIFIC_NAME
            // 
            dISPECIFIC_NAME.DataPropertyName = "SPECIFIC_NAME";
            dISPECIFIC_NAME.HeaderText = "SPECIFIC_NAME";
            dISPECIFIC_NAME.Name = "dISPECIFIC_NAME";
            dISPECIFIC_NAME.ReadOnly = true;
            dISPECIFIC_NAME.Visible = false;
            // 
            // dParameter_Name
            // 
            dParameter_Name.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dParameter_Name.DataPropertyName = "Parameter_Name";
            dParameter_Name.HeaderText = "Parameter_Name";
            dParameter_Name.Name = "dParameter_Name";
            dParameter_Name.ReadOnly = true;
            // 
            // dIData_Type
            // 
            dIData_Type.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dIData_Type.DataPropertyName = "Data_Type";
            dIData_Type.HeaderText = "Data_Type";
            dIData_Type.Name = "dIData_Type";
            dIData_Type.ReadOnly = true;
            dIData_Type.Width = 101;
            // 
            // dCharacter_Maximum_Length
            // 
            dCharacter_Maximum_Length.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dCharacter_Maximum_Length.DataPropertyName = "Character_Maximum_Length";
            dCharacter_Maximum_Length.HeaderText = "Col_Length";
            dCharacter_Maximum_Length.Name = "dCharacter_Maximum_Length";
            dCharacter_Maximum_Length.ReadOnly = true;
            dCharacter_Maximum_Length.Width = 106;
            // 
            // dParameter_Mode
            // 
            dParameter_Mode.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dParameter_Mode.DataPropertyName = "Parameter_Mode";
            dParameter_Mode.HeaderText = "Parameter_Mode";
            dParameter_Mode.Name = "dParameter_Mode";
            dParameter_Mode.ReadOnly = true;
            dParameter_Mode.Width = 138;
            // 
            // dgvOutPutParams
            // 
            dgvOutPutParams.AllowUserToAddRows = false;
            dgvOutPutParams.AllowUserToDeleteRows = false;
            dgvOutPutParams.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOutPutParams.Columns.AddRange(new DataGridViewColumn[] { dOSPECIFIC_NAME, dOName, dSystem_Type_Name, dError_Message });
            dgvOutPutParams.Dock = DockStyle.Fill;
            dgvOutPutParams.Location = new Point(0, 0);
            dgvOutPutParams.Margin = new Padding(3, 2, 3, 2);
            dgvOutPutParams.Name = "dgvOutPutParams";
            dgvOutPutParams.ReadOnly = true;
            dgvOutPutParams.RowTemplate.Height = 24;
            dgvOutPutParams.Size = new Size(433, 284);
            dgvOutPutParams.TabIndex = 1;
            dgvOutPutParams.TabStop = false;
            // 
            // dOSPECIFIC_NAME
            // 
            dOSPECIFIC_NAME.DataPropertyName = "SPECIFIC_NAME";
            dOSPECIFIC_NAME.HeaderText = "SPECIFIC_NAME";
            dOSPECIFIC_NAME.Name = "dOSPECIFIC_NAME";
            dOSPECIFIC_NAME.ReadOnly = true;
            dOSPECIFIC_NAME.Visible = false;
            // 
            // dOName
            // 
            dOName.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dOName.DataPropertyName = "Name";
            dOName.HeaderText = "Name";
            dOName.Name = "dOName";
            dOName.ReadOnly = true;
            dOName.Width = 69;
            // 
            // dSystem_Type_Name
            // 
            dSystem_Type_Name.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dSystem_Type_Name.DataPropertyName = "System_Type_Name";
            dSystem_Type_Name.HeaderText = "System_Type_Name";
            dSystem_Type_Name.Name = "dSystem_Type_Name";
            dSystem_Type_Name.ReadOnly = true;
            // 
            // dError_Message
            // 
            dError_Message.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dError_Message.DataPropertyName = "Error_Message";
            dError_Message.HeaderText = "Error";
            dError_Message.MinimumWidth = 100;
            dError_Message.Name = "dError_Message";
            dError_Message.ReadOnly = true;
            // 
            // cboSettingKey
            // 
            cboSettingKey.FormattingEnabled = true;
            cboSettingKey.Location = new Point(6, 29);
            cboSettingKey.Name = "cboSettingKey";
            cboSettingKey.Size = new Size(135, 24);
            cboSettingKey.TabIndex = 7;
            // 
            // frmTables
            // 
            AutoScaleDimensions = new SizeF(9F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1076, 590);
            Controls.Add(tabControl1);
            Margin = new Padding(4, 2, 4, 2);
            Name = "frmTables";
            Text = "Tables";
            Controls.SetChildIndex(panel1, 0);
            Controls.SetChildIndex(tabControl1, 0);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTables).EndInit();
            tabControl1.ResumeLayout(false);
            tabCommand.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            tabTablesAndCols.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer5.Panel1.ResumeLayout(false);
            splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer5).EndInit();
            splitContainer5.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvColumns).EndInit();
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvIndexes).EndInit();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvFK).EndInit();
            tabSpsAndFuncs.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel1.PerformLayout();
            splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSpsAndFuncs).EndInit();
            splitContainer4.Panel1.ResumeLayout(false);
            splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer4).EndInit();
            splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvInputParams).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvOutPutParams).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvTables;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabTablesAndCols;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvColumns;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TabPage tabCommand;
        private System.Windows.Forms.DataGridView dgvFK;
        private System.Windows.Forms.Button btnUpdateDescription;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnLoadDataFromSQL;
        private System.Windows.Forms.Button btnLoadDataFromXML;
        private System.Windows.Forms.Button btnSaveToXml;
        private System.Windows.Forms.DataGridViewTextBoxColumn dColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dColType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dColLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn dDefaultValue;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dIsNullable;
        private System.Windows.Forms.DataGridViewTextBoxColumn dColDescription;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dIsIdentity;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dIsPK;
        private System.Windows.Forms.DataGridViewTextBoxColumn dCollationName;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TabPage tabSpsAndFuncs;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.DataGridView dgvSpsAndFuncs;
        private System.Windows.Forms.DataGridView dgvInputParams;
        private System.Windows.Forms.DataGridView dgvOutPutParams;
        private System.Windows.Forms.DataGridViewTextBoxColumn dName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dMasterTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn dMasterCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn dDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn dDetailCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn dISPECIFIC_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn dParameter_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn dIData_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn dCharacter_Maximum_Length;
        private System.Windows.Forms.DataGridViewTextBoxColumn dParameter_Mode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSPECIFIC_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn dROUTINE_TYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn dDATA_TYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn dROUTINE_DEFINITION;
        private System.Windows.Forms.DataGridViewTextBoxColumn dOSPECIFIC_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn dOName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSystem_Type_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn dError_Message;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dTableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dTableDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn dTableType;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.DataGridView dgvIndexes;
        private System.Windows.Forms.DataGridViewTextBoxColumn dIndexName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dIxColName;
        private iCat.SQLTools.CustomControlleres.PlaceholderTextBox txtTableFilter;
        private iCat.SQLTools.CustomControlleres.PlaceholderTextBox txtSpFilter;
        private System.Windows.Forms.Button btnUpdateAllDescription;
        private ComboBox cboSettingKey;
    }
}