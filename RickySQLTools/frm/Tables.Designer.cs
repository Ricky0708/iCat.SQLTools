namespace RickySQLTools
{
    partial class Tables
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvTables = new System.Windows.Forms.DataGridView();
            this.dTableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dTableDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabCommand = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnLoadDataFromXML = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnSaveToXml = new System.Windows.Forms.Button();
            this.btnLoadDataFromSQL = new System.Windows.Forms.Button();
            this.btnUpdateDescription = new System.Windows.Forms.Button();
            this.tabTablesAndCols = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvColumns = new System.Windows.Forms.DataGridView();
            this.dColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dColType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dColLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dDefaultValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dIsNullable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dColDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dIsIdentity = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dIsPK = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dCollationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvFK = new System.Windows.Forms.DataGridView();
            this.dName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dMasterTable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dMasterCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dDetailCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabSpsAndFuncs = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.dgvSpsAndFuncs = new System.Windows.Forms.DataGridView();
            this.dSPECIFIC_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dROUTINE_TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dDATA_TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dROUTINE_DEFINITION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.dgvInputParams = new System.Windows.Forms.DataGridView();
            this.dISPECIFIC_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dParameter_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dIData_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dCharacter_Maximum_Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dParameter_Mode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOutPutParams = new System.Windows.Forms.DataGridView();
            this.dOSPECIFIC_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dOName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dSystem_Type_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dError_Message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTables)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabCommand.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabTablesAndCols.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFK)).BeginInit();
            this.tabSpsAndFuncs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpsAndFuncs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInputParams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutPutParams)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvTables);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 650);
            this.groupBox1.TabIndex = 1;
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
            this.dTableName,
            this.dTableDescription});
            this.dgvTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTables.Location = new System.Drawing.Point(3, 27);
            this.dgvTables.Name = "dgvTables";
            this.dgvTables.RowTemplate.Height = 24;
            this.dgvTables.Size = new System.Drawing.Size(303, 620);
            this.dgvTables.TabIndex = 0;
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
            this.dTableDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dTableDescription.DataPropertyName = "TableDescription";
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dTableDescription.DefaultCellStyle = dataGridViewCellStyle1;
            this.dTableDescription.HeaderText = "TableDescription";
            this.dTableDescription.Name = "dTableDescription";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabCommand);
            this.tabControl1.Controls.Add(this.tabTablesAndCols);
            this.tabControl1.Controls.Add(this.tabSpsAndFuncs);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 39);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(943, 690);
            this.tabControl1.TabIndex = 2;
            // 
            // tabCommand
            // 
            this.tabCommand.Controls.Add(this.groupBox6);
            this.tabCommand.Controls.Add(this.groupBox5);
            this.tabCommand.Controls.Add(this.groupBox4);
            this.tabCommand.Location = new System.Drawing.Point(4, 30);
            this.tabCommand.Name = "tabCommand";
            this.tabCommand.Padding = new System.Windows.Forms.Padding(3);
            this.tabCommand.Size = new System.Drawing.Size(935, 656);
            this.tabCommand.TabIndex = 1;
            this.tabCommand.Text = "Command";
            this.tabCommand.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Location = new System.Drawing.Point(41, 325);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(261, 323);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Gnerator";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnLoadDataFromXML);
            this.groupBox5.Location = new System.Drawing.Point(308, 44);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(313, 275);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "XML";
            // 
            // btnLoadDataFromXML
            // 
            this.btnLoadDataFromXML.Location = new System.Drawing.Point(6, 30);
            this.btnLoadDataFromXML.Name = "btnLoadDataFromXML";
            this.btnLoadDataFromXML.Size = new System.Drawing.Size(172, 40);
            this.btnLoadDataFromXML.TabIndex = 5;
            this.btnLoadDataFromXML.Text = "Load Data";
            this.btnLoadDataFromXML.UseVisualStyleBackColor = true;
            this.btnLoadDataFromXML.Click += new System.EventHandler(this.btnLoadDataFromXML_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnSaveToXml);
            this.groupBox4.Controls.Add(this.btnLoadDataFromSQL);
            this.groupBox4.Controls.Add(this.btnUpdateDescription);
            this.groupBox4.Location = new System.Drawing.Point(41, 44);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(261, 275);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "SQL Server";
            // 
            // btnSaveToXml
            // 
            this.btnSaveToXml.Location = new System.Drawing.Point(6, 76);
            this.btnSaveToXml.Name = "btnSaveToXml";
            this.btnSaveToXml.Size = new System.Drawing.Size(172, 40);
            this.btnSaveToXml.TabIndex = 5;
            this.btnSaveToXml.Text = "Save To Xml";
            this.btnSaveToXml.UseVisualStyleBackColor = true;
            this.btnSaveToXml.Click += new System.EventHandler(this.btnSaveToXml_Click);
            // 
            // btnLoadDataFromSQL
            // 
            this.btnLoadDataFromSQL.Location = new System.Drawing.Point(6, 30);
            this.btnLoadDataFromSQL.Name = "btnLoadDataFromSQL";
            this.btnLoadDataFromSQL.Size = new System.Drawing.Size(172, 40);
            this.btnLoadDataFromSQL.TabIndex = 4;
            this.btnLoadDataFromSQL.Text = "Load Data";
            this.btnLoadDataFromSQL.UseVisualStyleBackColor = true;
            this.btnLoadDataFromSQL.Click += new System.EventHandler(this.btnLoadDataFromSQL_Click);
            // 
            // btnUpdateDescription
            // 
            this.btnUpdateDescription.Location = new System.Drawing.Point(6, 172);
            this.btnUpdateDescription.Name = "btnUpdateDescription";
            this.btnUpdateDescription.Size = new System.Drawing.Size(172, 40);
            this.btnUpdateDescription.TabIndex = 3;
            this.btnUpdateDescription.Text = "Update_Description";
            this.btnUpdateDescription.UseVisualStyleBackColor = true;
            this.btnUpdateDescription.Click += new System.EventHandler(this.Update_Description_Click);
            // 
            // tabTablesAndCols
            // 
            this.tabTablesAndCols.Controls.Add(this.splitContainer1);
            this.tabTablesAndCols.Location = new System.Drawing.Point(4, 30);
            this.tabTablesAndCols.Name = "tabTablesAndCols";
            this.tabTablesAndCols.Padding = new System.Windows.Forms.Padding(3);
            this.tabTablesAndCols.Size = new System.Drawing.Size(935, 656);
            this.tabTablesAndCols.TabIndex = 0;
            this.tabTablesAndCols.Text = "Tables & Columns";
            this.tabTablesAndCols.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(929, 650);
            this.splitContainer1.SplitterDistance = 309;
            this.splitContainer1.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer2.Size = new System.Drawing.Size(616, 650);
            this.splitContainer2.SplitterDistance = 324;
            this.splitContainer2.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvColumns);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(616, 324);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Columns Info";
            // 
            // dgvColumns
            // 
            this.dgvColumns.AllowUserToAddRows = false;
            this.dgvColumns.AllowUserToDeleteRows = false;
            this.dgvColumns.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColumns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dColName,
            this.dColType,
            this.dColLength,
            this.dDefaultValue,
            this.dIsNullable,
            this.dColDescription,
            this.dIsIdentity,
            this.dIsPK,
            this.dCollationName});
            this.dgvColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvColumns.Location = new System.Drawing.Point(3, 27);
            this.dgvColumns.Name = "dgvColumns";
            this.dgvColumns.RowTemplate.Height = 24;
            this.dgvColumns.Size = new System.Drawing.Size(610, 294);
            this.dgvColumns.TabIndex = 1;
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
            // dColType
            // 
            this.dColType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dColType.DataPropertyName = "ColType";
            this.dColType.HeaderText = "ColType";
            this.dColType.Name = "dColType";
            this.dColType.ReadOnly = true;
            this.dColType.Width = 102;
            // 
            // dColLength
            // 
            this.dColLength.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dColLength.DataPropertyName = "ColLength";
            this.dColLength.HeaderText = "ColLength";
            this.dColLength.Name = "dColLength";
            this.dColLength.ReadOnly = true;
            this.dColLength.Width = 116;
            // 
            // dDefaultValue
            // 
            this.dDefaultValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dDefaultValue.DataPropertyName = "DefaultValue";
            this.dDefaultValue.HeaderText = "DefaultValue";
            this.dDefaultValue.Name = "dDefaultValue";
            this.dDefaultValue.ReadOnly = true;
            this.dDefaultValue.Width = 137;
            // 
            // dIsNullable
            // 
            this.dIsNullable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dIsNullable.DataPropertyName = "IsNullable";
            this.dIsNullable.HeaderText = "IsNullable";
            this.dIsNullable.Name = "dIsNullable";
            this.dIsNullable.ReadOnly = true;
            this.dIsNullable.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dIsNullable.Width = 91;
            // 
            // dColDescription
            // 
            this.dColDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dColDescription.DataPropertyName = "ColDescription";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dColDescription.DefaultCellStyle = dataGridViewCellStyle2;
            this.dColDescription.HeaderText = "ColDescription";
            this.dColDescription.Name = "dColDescription";
            this.dColDescription.Width = 150;
            // 
            // dIsIdentity
            // 
            this.dIsIdentity.DataPropertyName = "IsIdentity";
            this.dIsIdentity.HeaderText = "IsIdentity";
            this.dIsIdentity.Name = "dIsIdentity";
            this.dIsIdentity.ReadOnly = true;
            this.dIsIdentity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dIsPK
            // 
            this.dIsPK.DataPropertyName = "IsPK";
            this.dIsPK.HeaderText = "IsPK";
            this.dIsPK.Name = "dIsPK";
            this.dIsPK.ReadOnly = true;
            this.dIsPK.TrueValue = "";
            // 
            // dCollationName
            // 
            this.dCollationName.DataPropertyName = "CollationName";
            this.dCollationName.HeaderText = "CollationName";
            this.dCollationName.Name = "dCollationName";
            this.dCollationName.ReadOnly = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvFK);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(616, 322);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "FK";
            // 
            // dgvFK
            // 
            this.dgvFK.AllowUserToAddRows = false;
            this.dgvFK.AllowUserToDeleteRows = false;
            this.dgvFK.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFK.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dName,
            this.dMasterTable,
            this.dMasterCol,
            this.dDetail,
            this.dDetailCol});
            this.dgvFK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFK.Location = new System.Drawing.Point(3, 27);
            this.dgvFK.Name = "dgvFK";
            this.dgvFK.ReadOnly = true;
            this.dgvFK.RowTemplate.Height = 24;
            this.dgvFK.Size = new System.Drawing.Size(610, 292);
            this.dgvFK.TabIndex = 2;
            // 
            // dName
            // 
            this.dName.DataPropertyName = "name";
            this.dName.HeaderText = "Name";
            this.dName.Name = "dName";
            this.dName.ReadOnly = true;
            // 
            // dMasterTable
            // 
            this.dMasterTable.DataPropertyName = "ReferencedTable";
            this.dMasterTable.HeaderText = "MasterTable";
            this.dMasterTable.Name = "dMasterTable";
            this.dMasterTable.ReadOnly = true;
            // 
            // dMasterCol
            // 
            this.dMasterCol.DataPropertyName = "ReferencedColumn";
            this.dMasterCol.HeaderText = "MasterCol";
            this.dMasterCol.Name = "dMasterCol";
            this.dMasterCol.ReadOnly = true;
            // 
            // dDetail
            // 
            this.dDetail.DataPropertyName = "ParentTable";
            this.dDetail.HeaderText = "DetailTable";
            this.dDetail.Name = "dDetail";
            this.dDetail.ReadOnly = true;
            // 
            // dDetailCol
            // 
            this.dDetailCol.DataPropertyName = "ParentColumn";
            this.dDetailCol.HeaderText = "DetaliCol";
            this.dDetailCol.Name = "dDetailCol";
            this.dDetailCol.ReadOnly = true;
            // 
            // tabSpsAndFuncs
            // 
            this.tabSpsAndFuncs.Controls.Add(this.splitContainer3);
            this.tabSpsAndFuncs.Location = new System.Drawing.Point(4, 30);
            this.tabSpsAndFuncs.Name = "tabSpsAndFuncs";
            this.tabSpsAndFuncs.Padding = new System.Windows.Forms.Padding(3);
            this.tabSpsAndFuncs.Size = new System.Drawing.Size(935, 656);
            this.tabSpsAndFuncs.TabIndex = 2;
            this.tabSpsAndFuncs.Text = "SP & Func";
            this.tabSpsAndFuncs.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.dgvSpsAndFuncs);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(929, 650);
            this.splitContainer3.SplitterDistance = 548;
            this.splitContainer3.TabIndex = 0;
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
            this.dDATA_TYPE,
            this.dROUTINE_DEFINITION});
            this.dgvSpsAndFuncs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSpsAndFuncs.Location = new System.Drawing.Point(0, 0);
            this.dgvSpsAndFuncs.Name = "dgvSpsAndFuncs";
            this.dgvSpsAndFuncs.ReadOnly = true;
            this.dgvSpsAndFuncs.RowTemplate.Height = 24;
            this.dgvSpsAndFuncs.Size = new System.Drawing.Size(548, 650);
            this.dgvSpsAndFuncs.TabIndex = 3;
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
            // dROUTINE_DEFINITION
            // 
            this.dROUTINE_DEFINITION.DataPropertyName = "ROUTINE_DEFINITION";
            this.dROUTINE_DEFINITION.HeaderText = "Script";
            this.dROUTINE_DEFINITION.MinimumWidth = 100;
            this.dROUTINE_DEFINITION.Name = "dROUTINE_DEFINITION";
            this.dROUTINE_DEFINITION.ReadOnly = true;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.dgvInputParams);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.dgvOutPutParams);
            this.splitContainer4.Size = new System.Drawing.Size(377, 650);
            this.splitContainer4.SplitterDistance = 297;
            this.splitContainer4.TabIndex = 0;
            // 
            // dgvInputParams
            // 
            this.dgvInputParams.AllowUserToAddRows = false;
            this.dgvInputParams.AllowUserToDeleteRows = false;
            this.dgvInputParams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInputParams.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dISPECIFIC_NAME,
            this.dParameter_Name,
            this.dIData_Type,
            this.dCharacter_Maximum_Length,
            this.dParameter_Mode});
            this.dgvInputParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInputParams.Location = new System.Drawing.Point(0, 0);
            this.dgvInputParams.Name = "dgvInputParams";
            this.dgvInputParams.ReadOnly = true;
            this.dgvInputParams.RowTemplate.Height = 24;
            this.dgvInputParams.Size = new System.Drawing.Size(377, 297);
            this.dgvInputParams.TabIndex = 1;
            this.dgvInputParams.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInputParams_CellContentClick);
            // 
            // dISPECIFIC_NAME
            // 
            this.dISPECIFIC_NAME.DataPropertyName = "SPECIFIC_NAME";
            this.dISPECIFIC_NAME.HeaderText = "SPECIFIC_NAME";
            this.dISPECIFIC_NAME.Name = "dISPECIFIC_NAME";
            this.dISPECIFIC_NAME.ReadOnly = true;
            this.dISPECIFIC_NAME.Visible = false;
            // 
            // dParameter_Name
            // 
            this.dParameter_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dParameter_Name.DataPropertyName = "Parameter_Name";
            this.dParameter_Name.HeaderText = "Parameter_Name";
            this.dParameter_Name.Name = "dParameter_Name";
            this.dParameter_Name.ReadOnly = true;
            // 
            // dIData_Type
            // 
            this.dIData_Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dIData_Type.DataPropertyName = "Data_Type";
            this.dIData_Type.HeaderText = "Data_Type";
            this.dIData_Type.Name = "dIData_Type";
            this.dIData_Type.ReadOnly = true;
            this.dIData_Type.Width = 119;
            // 
            // dCharacter_Maximum_Length
            // 
            this.dCharacter_Maximum_Length.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dCharacter_Maximum_Length.DataPropertyName = "Character_Maximum_Length";
            this.dCharacter_Maximum_Length.HeaderText = "Col_Length";
            this.dCharacter_Maximum_Length.Name = "dCharacter_Maximum_Length";
            this.dCharacter_Maximum_Length.ReadOnly = true;
            this.dCharacter_Maximum_Length.Width = 125;
            // 
            // dParameter_Mode
            // 
            this.dParameter_Mode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dParameter_Mode.DataPropertyName = "Parameter_Mode";
            this.dParameter_Mode.HeaderText = "Parameter_Mode";
            this.dParameter_Mode.Name = "dParameter_Mode";
            this.dParameter_Mode.ReadOnly = true;
            this.dParameter_Mode.Width = 164;
            // 
            // dgvOutPutParams
            // 
            this.dgvOutPutParams.AllowUserToAddRows = false;
            this.dgvOutPutParams.AllowUserToDeleteRows = false;
            this.dgvOutPutParams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOutPutParams.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dOSPECIFIC_NAME,
            this.dOName,
            this.dSystem_Type_Name,
            this.dError_Message});
            this.dgvOutPutParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOutPutParams.Location = new System.Drawing.Point(0, 0);
            this.dgvOutPutParams.Name = "dgvOutPutParams";
            this.dgvOutPutParams.ReadOnly = true;
            this.dgvOutPutParams.RowTemplate.Height = 24;
            this.dgvOutPutParams.Size = new System.Drawing.Size(377, 349);
            this.dgvOutPutParams.TabIndex = 1;
            // 
            // dOSPECIFIC_NAME
            // 
            this.dOSPECIFIC_NAME.DataPropertyName = "SPECIFIC_NAME";
            this.dOSPECIFIC_NAME.HeaderText = "SPECIFIC_NAME";
            this.dOSPECIFIC_NAME.Name = "dOSPECIFIC_NAME";
            this.dOSPECIFIC_NAME.ReadOnly = true;
            this.dOSPECIFIC_NAME.Visible = false;
            // 
            // dOName
            // 
            this.dOName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dOName.DataPropertyName = "Name";
            this.dOName.HeaderText = "Name";
            this.dOName.Name = "dOName";
            this.dOName.ReadOnly = true;
            this.dOName.Width = 83;
            // 
            // dSystem_Type_Name
            // 
            this.dSystem_Type_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dSystem_Type_Name.DataPropertyName = "System_Type_Name";
            this.dSystem_Type_Name.HeaderText = "System_Type_Name";
            this.dSystem_Type_Name.Name = "dSystem_Type_Name";
            this.dSystem_Type_Name.ReadOnly = true;
            // 
            // dError_Message
            // 
            this.dError_Message.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dError_Message.DataPropertyName = "Error_Message";
            this.dError_Message.HeaderText = "Error";
            this.dError_Message.MinimumWidth = 100;
            this.dError_Message.Name = "dError_Message";
            this.dError_Message.ReadOnly = true;
            // 
            // Tables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 729);
            this.Controls.Add(this.tabControl1);
            this.Name = "Tables";
            this.Text = "Tables";
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTables)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabCommand.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.tabTablesAndCols.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFK)).EndInit();
            this.tabSpsAndFuncs.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpsAndFuncs)).EndInit();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInputParams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutPutParams)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.DataGridViewTextBoxColumn dTableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dTableDescription;
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
    }
}