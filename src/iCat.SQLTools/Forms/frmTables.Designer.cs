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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            groupBox1 = new GroupBox();
            dgvTables = new DataGridView();
            dIsChecked = new DataGridViewCheckBoxColumn();
            dTableName = new DataGridViewTextBoxColumn();
            dTableDescription = new DataGridViewTextBoxColumn();
            dTableType = new DataGridViewTextBoxColumn();
            txtTableFilter = new CustomControlleres.PlaceholderTextBox();
            tabControl1 = new TabControl();
            tabCommand = new TabPage();
            txDbDiagramResult = new RichTextBox();
            panel2 = new Panel();
            groupBox6 = new GroupBox();
            chkNoteInName = new CheckBox();
            chkToUpperCase = new CheckBox();
            btnExportDBDiagramIO = new Button();
            btnExportExcel = new Button();
            groupBox4 = new GroupBox();
            btnUpdateAllDescription = new Button();
            btnUpdateDescription = new Button();
            groupBox5 = new GroupBox();
            btnSaveToXml = new Button();
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
            chkSortByColName = new CheckBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTables).BeginInit();
            tabControl1.SuspendLayout();
            tabCommand.SuspendLayout();
            panel2.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
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
            panel1.Margin = new Padding(8, 6, 8, 6);
            panel1.Size = new Size(2442, 86);
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvTables);
            groupBox1.Controls.Add(txtTableFilter);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Margin = new Padding(6, 4, 6, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(6, 4, 6, 4);
            groupBox1.Size = new Size(789, 1207);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tables";
            // 
            // dgvTables
            // 
            dgvTables.AllowUserToAddRows = false;
            dgvTables.AllowUserToDeleteRows = false;
            dgvTables.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTables.Columns.AddRange(new DataGridViewColumn[] { dIsChecked, dTableName, dTableDescription, dTableType });
            dgvTables.Dock = DockStyle.Fill;
            dgvTables.Location = new Point(6, 89);
            dgvTables.Margin = new Padding(6, 4, 6, 4);
            dgvTables.Name = "dgvTables";
            dgvTables.RowHeadersWidth = 82;
            dgvTables.RowTemplate.Height = 50;
            dgvTables.Size = new Size(777, 1114);
            dgvTables.TabIndex = 0;
            // 
            // dIsChecked
            // 
            dIsChecked.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dIsChecked.DataPropertyName = "IsChecked";
            dIsChecked.FalseValue = "0";
            dIsChecked.HeaderText = "";
            dIsChecked.MinimumWidth = 50;
            dIsChecked.Name = "dIsChecked";
            dIsChecked.TrueValue = "1";
            dIsChecked.Width = 50;
            // 
            // dTableName
            // 
            dTableName.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dTableName.DataPropertyName = "TableName";
            dTableName.HeaderText = "TableName";
            dTableName.MinimumWidth = 10;
            dTableName.Name = "dTableName";
            dTableName.ReadOnly = true;
            dTableName.Width = 197;
            // 
            // dTableDescription
            // 
            dTableDescription.DataPropertyName = "TableDescription";
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dTableDescription.DefaultCellStyle = dataGridViewCellStyle1;
            dTableDescription.HeaderText = "TableDescription";
            dTableDescription.MinimumWidth = 100;
            dTableDescription.Name = "dTableDescription";
            dTableDescription.Width = 200;
            // 
            // dTableType
            // 
            dTableType.DataPropertyName = "TableType";
            dTableType.HeaderText = "TableTyle";
            dTableType.MinimumWidth = 10;
            dTableType.Name = "dTableType";
            dTableType.ReadOnly = true;
            dTableType.Width = 200;
            // 
            // txtTableFilter
            // 
            txtTableFilter.BackColor = SystemColors.Info;
            txtTableFilter.Dock = DockStyle.Top;
            txtTableFilter.Location = new Point(6, 43);
            txtTableFilter.Margin = new Padding(17, 8, 17, 8);
            txtTableFilter.Name = "txtTableFilter";
            txtTableFilter.PlaceHolder = "Write something here to filter Table";
            txtTableFilter.Size = new Size(777, 46);
            txtTableFilter.TabIndex = 1;
            txtTableFilter.TextChanged += Filter;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabCommand);
            tabControl1.Controls.Add(tabTablesAndCols);
            tabControl1.Controls.Add(tabSpsAndFuncs);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 86);
            tabControl1.Margin = new Padding(6, 4, 6, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(2442, 1274);
            tabControl1.TabIndex = 2;
            tabControl1.TabStop = false;
            // 
            // tabCommand
            // 
            tabCommand.Controls.Add(txDbDiagramResult);
            tabCommand.Controls.Add(panel2);
            tabCommand.Location = new Point(8, 47);
            tabCommand.Margin = new Padding(6, 4, 6, 4);
            tabCommand.Name = "tabCommand";
            tabCommand.Padding = new Padding(6, 4, 6, 4);
            tabCommand.Size = new Size(2426, 1219);
            tabCommand.TabIndex = 1;
            tabCommand.Text = "Command";
            tabCommand.UseVisualStyleBackColor = true;
            // 
            // txDbDiagramResult
            // 
            txDbDiagramResult.Dock = DockStyle.Fill;
            txDbDiagramResult.Location = new Point(896, 4);
            txDbDiagramResult.Name = "txDbDiagramResult";
            txDbDiagramResult.Size = new Size(1524, 1211);
            txDbDiagramResult.TabIndex = 7;
            txDbDiagramResult.Text = "";
            // 
            // panel2
            // 
            panel2.Controls.Add(groupBox6);
            panel2.Controls.Add(groupBox4);
            panel2.Controls.Add(groupBox5);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(6, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(890, 1211);
            panel2.TabIndex = 8;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(chkSortByColName);
            groupBox6.Controls.Add(chkNoteInName);
            groupBox6.Controls.Add(chkToUpperCase);
            groupBox6.Controls.Add(btnExportDBDiagramIO);
            groupBox6.Controls.Add(btnExportExcel);
            groupBox6.Location = new Point(28, 495);
            groupBox6.Margin = new Padding(6, 4, 6, 4);
            groupBox6.Name = "groupBox6";
            groupBox6.Padding = new Padding(6, 4, 6, 4);
            groupBox6.Size = new Size(444, 516);
            groupBox6.TabIndex = 6;
            groupBox6.TabStop = false;
            groupBox6.Text = "Generator";
            // 
            // chkNoteInName
            // 
            chkNoteInName.AutoSize = true;
            chkNoteInName.Location = new Point(21, 261);
            chkNoteInName.Name = "chkNoteInName";
            chkNoteInName.Size = new Size(321, 36);
            chkNoteInName.TabIndex = 7;
            chkNoteInName.Text = "Bring Note after Name";
            chkNoteInName.UseVisualStyleBackColor = true;
            // 
            // chkToUpperCase
            // 
            chkToUpperCase.AutoSize = true;
            chkToUpperCase.Location = new Point(21, 208);
            chkToUpperCase.Name = "chkToUpperCase";
            chkToUpperCase.Size = new Size(228, 36);
            chkToUpperCase.TabIndex = 7;
            chkToUpperCase.Text = "To Upper Case";
            chkToUpperCase.UseVisualStyleBackColor = true;
            // 
            // btnExportDBDiagramIO
            // 
            btnExportDBDiagramIO.AllowDrop = true;
            btnExportDBDiagramIO.Location = new Point(9, 118);
            btnExportDBDiagramIO.Margin = new Padding(6, 4, 6, 4);
            btnExportDBDiagramIO.Name = "btnExportDBDiagramIO";
            btnExportDBDiagramIO.Size = new Size(414, 64);
            btnExportDBDiagramIO.TabIndex = 5;
            btnExportDBDiagramIO.Text = "Export to dbdiagram.io";
            btnExportDBDiagramIO.UseVisualStyleBackColor = true;
            btnExportDBDiagramIO.Click += btnExportDBDiagramIO_Click;
            // 
            // btnExportExcel
            // 
            btnExportExcel.Location = new Point(9, 46);
            btnExportExcel.Margin = new Padding(6, 4, 6, 4);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(414, 64);
            btnExportExcel.TabIndex = 4;
            btnExportExcel.Text = "Export to Excel";
            btnExportExcel.UseVisualStyleBackColor = true;
            btnExportExcel.Click += btnExportExcel_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(btnUpdateAllDescription);
            groupBox4.Controls.Add(btnUpdateDescription);
            groupBox4.Location = new Point(28, 17);
            groupBox4.Margin = new Padding(6, 4, 6, 4);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(6, 4, 6, 4);
            groupBox4.Size = new Size(444, 440);
            groupBox4.TabIndex = 4;
            groupBox4.TabStop = false;
            groupBox4.Text = "SQL Server";
            // 
            // btnUpdateAllDescription
            // 
            btnUpdateAllDescription.Location = new Point(0, 122);
            btnUpdateAllDescription.Margin = new Padding(6, 4, 6, 4);
            btnUpdateAllDescription.Name = "btnUpdateAllDescription";
            btnUpdateAllDescription.Size = new Size(423, 64);
            btnUpdateAllDescription.TabIndex = 6;
            btnUpdateAllDescription.Text = "Update All Description";
            btnUpdateAllDescription.UseVisualStyleBackColor = true;
            btnUpdateAllDescription.Click += btnUpdateAllDescription_Click;
            // 
            // btnUpdateDescription
            // 
            btnUpdateDescription.Location = new Point(0, 46);
            btnUpdateDescription.Margin = new Padding(6, 4, 6, 4);
            btnUpdateDescription.Name = "btnUpdateDescription";
            btnUpdateDescription.Size = new Size(423, 64);
            btnUpdateDescription.TabIndex = 3;
            btnUpdateDescription.Text = "Update Modified Description";
            btnUpdateDescription.UseVisualStyleBackColor = true;
            btnUpdateDescription.Click += Update_Description_Click;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(btnSaveToXml);
            groupBox5.Location = new Point(506, 17);
            groupBox5.Margin = new Padding(6, 4, 6, 4);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new Padding(6, 4, 6, 4);
            groupBox5.Size = new Size(340, 440);
            groupBox5.TabIndex = 5;
            groupBox5.TabStop = false;
            groupBox5.Text = "XML";
            // 
            // btnSaveToXml
            // 
            btnSaveToXml.Location = new Point(9, 46);
            btnSaveToXml.Margin = new Padding(6, 4, 6, 4);
            btnSaveToXml.Name = "btnSaveToXml";
            btnSaveToXml.Size = new Size(295, 64);
            btnSaveToXml.TabIndex = 5;
            btnSaveToXml.Text = "Save To Xml";
            btnSaveToXml.UseVisualStyleBackColor = true;
            btnSaveToXml.Click += btnSaveToXml_Click;
            // 
            // tabTablesAndCols
            // 
            tabTablesAndCols.Controls.Add(splitContainer1);
            tabTablesAndCols.Location = new Point(8, 47);
            tabTablesAndCols.Margin = new Padding(6, 4, 6, 4);
            tabTablesAndCols.Name = "tabTablesAndCols";
            tabTablesAndCols.Padding = new Padding(6, 4, 6, 4);
            tabTablesAndCols.Size = new Size(2426, 1219);
            tabTablesAndCols.TabIndex = 0;
            tabTablesAndCols.Text = "Tables & Columns";
            tabTablesAndCols.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.BackColor = Color.Transparent;
            splitContainer1.BorderStyle = BorderStyle.Fixed3D;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(6, 4);
            splitContainer1.Margin = new Padding(6, 4, 6, 4);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer5);
            splitContainer1.Size = new Size(2414, 1211);
            splitContainer1.SplitterDistance = 793;
            splitContainer1.SplitterWidth = 8;
            splitContainer1.TabIndex = 2;
            splitContainer1.TabStop = false;
            // 
            // splitContainer5
            // 
            splitContainer5.BorderStyle = BorderStyle.Fixed3D;
            splitContainer5.Dock = DockStyle.Fill;
            splitContainer5.Location = new Point(0, 0);
            splitContainer5.Margin = new Padding(53, 16, 53, 16);
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
            splitContainer5.Size = new Size(1613, 1211);
            splitContainer5.SplitterDistance = 336;
            splitContainer5.SplitterWidth = 16;
            splitContainer5.TabIndex = 2;
            splitContainer5.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvColumns);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Margin = new Padding(53, 16, 53, 16);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(53, 16, 53, 16);
            groupBox2.Size = new Size(1609, 332);
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
            dgvColumns.Location = new Point(53, 55);
            dgvColumns.Margin = new Padding(53, 16, 53, 16);
            dgvColumns.Name = "dgvColumns";
            dgvColumns.RowHeadersWidth = 82;
            dgvColumns.RowTemplate.Height = 24;
            dgvColumns.Size = new Size(1503, 261);
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
            dColName.Width = 173;
            // 
            // dColType
            // 
            dColType.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dColType.DataPropertyName = "ColType";
            dColType.HeaderText = "ColType";
            dColType.MinimumWidth = 10;
            dColType.Name = "dColType";
            dColType.ReadOnly = true;
            dColType.Width = 163;
            // 
            // dColLength
            // 
            dColLength.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dColLength.DataPropertyName = "ColLength";
            dColLength.HeaderText = "ColLength";
            dColLength.MinimumWidth = 10;
            dColLength.Name = "dColLength";
            dColLength.ReadOnly = true;
            dColLength.Width = 186;
            // 
            // dDefaultValue
            // 
            dDefaultValue.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dDefaultValue.DataPropertyName = "DefaultValue";
            dDefaultValue.HeaderText = "DefaultValue";
            dDefaultValue.MinimumWidth = 10;
            dDefaultValue.Name = "dDefaultValue";
            dDefaultValue.ReadOnly = true;
            dDefaultValue.Width = 219;
            // 
            // dIsNullable
            // 
            dIsNullable.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dIsNullable.DataPropertyName = "IsNullable";
            dIsNullable.HeaderText = "IsNullable";
            dIsNullable.MinimumWidth = 10;
            dIsNullable.Name = "dIsNullable";
            dIsNullable.ReadOnly = true;
            dIsNullable.Resizable = DataGridViewTriState.True;
            dIsNullable.Width = 144;
            // 
            // dColDescription
            // 
            dColDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dColDescription.DataPropertyName = "ColDescription";
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dColDescription.DefaultCellStyle = dataGridViewCellStyle2;
            dColDescription.HeaderText = "ColDescription";
            dColDescription.MinimumWidth = 10;
            dColDescription.Name = "dColDescription";
            dColDescription.Width = 241;
            // 
            // dIsIdentity
            // 
            dIsIdentity.DataPropertyName = "IsIdentity";
            dIsIdentity.HeaderText = "IsIdentity";
            dIsIdentity.MinimumWidth = 10;
            dIsIdentity.Name = "dIsIdentity";
            dIsIdentity.ReadOnly = true;
            dIsIdentity.Resizable = DataGridViewTriState.True;
            dIsIdentity.Width = 200;
            // 
            // dIsPK
            // 
            dIsPK.DataPropertyName = "IsPK";
            dIsPK.HeaderText = "IsPK";
            dIsPK.MinimumWidth = 10;
            dIsPK.Name = "dIsPK";
            dIsPK.ReadOnly = true;
            dIsPK.TrueValue = "";
            dIsPK.Width = 200;
            // 
            // dCollationName
            // 
            dCollationName.DataPropertyName = "CollationName";
            dCollationName.HeaderText = "CollationName";
            dCollationName.MinimumWidth = 10;
            dCollationName.Name = "dCollationName";
            dCollationName.ReadOnly = true;
            dCollationName.Width = 200;
            // 
            // splitContainer2
            // 
            splitContainer2.BorderStyle = BorderStyle.Fixed3D;
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Margin = new Padding(53, 16, 53, 16);
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
            splitContainer2.Size = new Size(1613, 859);
            splitContainer2.SplitterDistance = 169;
            splitContainer2.SplitterWidth = 16;
            splitContainer2.TabIndex = 1;
            splitContainer2.TabStop = false;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(dgvIndexes);
            groupBox7.Dock = DockStyle.Fill;
            groupBox7.Location = new Point(0, 0);
            groupBox7.Margin = new Padding(53, 16, 53, 16);
            groupBox7.Name = "groupBox7";
            groupBox7.Padding = new Padding(53, 16, 53, 16);
            groupBox7.Size = new Size(1609, 165);
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
            dgvIndexes.Location = new Point(53, 55);
            dgvIndexes.Margin = new Padding(53, 16, 53, 16);
            dgvIndexes.Name = "dgvIndexes";
            dgvIndexes.RowHeadersWidth = 82;
            dgvIndexes.RowTemplate.Height = 24;
            dgvIndexes.Size = new Size(1503, 94);
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
            dIxColName.MinimumWidth = 10;
            dIxColName.Name = "dIxColName";
            dIxColName.ReadOnly = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dgvFK);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Location = new Point(0, 0);
            groupBox3.Margin = new Padding(53, 16, 53, 16);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(53, 16, 53, 16);
            groupBox3.Size = new Size(1609, 670);
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
            dgvFK.Location = new Point(53, 55);
            dgvFK.Margin = new Padding(53, 16, 53, 16);
            dgvFK.Name = "dgvFK";
            dgvFK.ReadOnly = true;
            dgvFK.RowHeadersWidth = 82;
            dgvFK.RowTemplate.Height = 24;
            dgvFK.Size = new Size(1503, 599);
            dgvFK.TabIndex = 2;
            dgvFK.TabStop = false;
            // 
            // dName
            // 
            dName.DataPropertyName = "name";
            dName.HeaderText = "Name";
            dName.MinimumWidth = 10;
            dName.Name = "dName";
            dName.ReadOnly = true;
            // 
            // dMasterTable
            // 
            dMasterTable.DataPropertyName = "ReferencedTable";
            dMasterTable.HeaderText = "MasterTable";
            dMasterTable.MinimumWidth = 10;
            dMasterTable.Name = "dMasterTable";
            dMasterTable.ReadOnly = true;
            // 
            // dMasterCol
            // 
            dMasterCol.DataPropertyName = "ReferencedColumn";
            dMasterCol.HeaderText = "MasterCol";
            dMasterCol.MinimumWidth = 10;
            dMasterCol.Name = "dMasterCol";
            dMasterCol.ReadOnly = true;
            // 
            // dDetail
            // 
            dDetail.DataPropertyName = "ParentTable";
            dDetail.HeaderText = "DetailTable";
            dDetail.MinimumWidth = 10;
            dDetail.Name = "dDetail";
            dDetail.ReadOnly = true;
            // 
            // dDetailCol
            // 
            dDetailCol.DataPropertyName = "ParentColumn";
            dDetailCol.HeaderText = "DetaliCol";
            dDetailCol.MinimumWidth = 10;
            dDetailCol.Name = "dDetailCol";
            dDetailCol.ReadOnly = true;
            // 
            // tabSpsAndFuncs
            // 
            tabSpsAndFuncs.Controls.Add(splitContainer3);
            tabSpsAndFuncs.Location = new Point(8, 47);
            tabSpsAndFuncs.Margin = new Padding(6, 4, 6, 4);
            tabSpsAndFuncs.Name = "tabSpsAndFuncs";
            tabSpsAndFuncs.Padding = new Padding(6, 4, 6, 4);
            tabSpsAndFuncs.Size = new Size(2426, 1219);
            tabSpsAndFuncs.TabIndex = 2;
            tabSpsAndFuncs.Text = "SP & Func";
            tabSpsAndFuncs.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.Location = new Point(6, 4);
            splitContainer3.Margin = new Padding(6, 4, 6, 4);
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
            splitContainer3.Size = new Size(2414, 1211);
            splitContainer3.SplitterDistance = 1411;
            splitContainer3.SplitterWidth = 8;
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
            dgvSpsAndFuncs.Location = new Point(0, 46);
            dgvSpsAndFuncs.Margin = new Padding(6, 4, 6, 4);
            dgvSpsAndFuncs.Name = "dgvSpsAndFuncs";
            dgvSpsAndFuncs.ReadOnly = true;
            dgvSpsAndFuncs.RowHeadersWidth = 82;
            dgvSpsAndFuncs.RowTemplate.Height = 24;
            dgvSpsAndFuncs.Size = new Size(1411, 1165);
            dgvSpsAndFuncs.TabIndex = 3;
            // 
            // dSPECIFIC_NAME
            // 
            dSPECIFIC_NAME.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dSPECIFIC_NAME.DataPropertyName = "SPECIFIC_NAME";
            dSPECIFIC_NAME.HeaderText = "SPECIFIC_NAME";
            dSPECIFIC_NAME.MinimumWidth = 10;
            dSPECIFIC_NAME.Name = "dSPECIFIC_NAME";
            dSPECIFIC_NAME.ReadOnly = true;
            dSPECIFIC_NAME.Width = 292;
            // 
            // dROUTINE_TYPE
            // 
            dROUTINE_TYPE.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dROUTINE_TYPE.DataPropertyName = "ROUTINE_TYPE";
            dROUTINE_TYPE.HeaderText = "ROUTINE_TYPE";
            dROUTINE_TYPE.MinimumWidth = 10;
            dROUTINE_TYPE.Name = "dROUTINE_TYPE";
            dROUTINE_TYPE.ReadOnly = true;
            dROUTINE_TYPE.Width = 281;
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
            txtSpFilter.Margin = new Padding(17, 8, 17, 8);
            txtSpFilter.Name = "txtSpFilter";
            txtSpFilter.PlaceHolder = "Write something here to filter SP && Func";
            txtSpFilter.Size = new Size(1411, 46);
            txtSpFilter.TabIndex = 4;
            txtSpFilter.TextChanged += Filter;
            // 
            // splitContainer4
            // 
            splitContainer4.Dock = DockStyle.Fill;
            splitContainer4.Location = new Point(0, 0);
            splitContainer4.Margin = new Padding(53, 16, 53, 16);
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
            splitContainer4.Size = new Size(995, 1211);
            splitContainer4.SplitterDistance = 544;
            splitContainer4.SplitterWidth = 16;
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
            dgvInputParams.Margin = new Padding(53, 16, 53, 16);
            dgvInputParams.Name = "dgvInputParams";
            dgvInputParams.ReadOnly = true;
            dgvInputParams.RowHeadersWidth = 82;
            dgvInputParams.RowTemplate.Height = 24;
            dgvInputParams.Size = new Size(995, 544);
            dgvInputParams.TabIndex = 1;
            dgvInputParams.TabStop = false;
            // 
            // dISPECIFIC_NAME
            // 
            dISPECIFIC_NAME.DataPropertyName = "SPECIFIC_NAME";
            dISPECIFIC_NAME.HeaderText = "SPECIFIC_NAME";
            dISPECIFIC_NAME.MinimumWidth = 10;
            dISPECIFIC_NAME.Name = "dISPECIFIC_NAME";
            dISPECIFIC_NAME.ReadOnly = true;
            dISPECIFIC_NAME.Visible = false;
            dISPECIFIC_NAME.Width = 200;
            // 
            // dParameter_Name
            // 
            dParameter_Name.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dParameter_Name.DataPropertyName = "Parameter_Name";
            dParameter_Name.HeaderText = "Parameter_Name";
            dParameter_Name.MinimumWidth = 10;
            dParameter_Name.Name = "dParameter_Name";
            dParameter_Name.ReadOnly = true;
            // 
            // dIData_Type
            // 
            dIData_Type.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dIData_Type.DataPropertyName = "Data_Type";
            dIData_Type.HeaderText = "Data_Type";
            dIData_Type.MinimumWidth = 10;
            dIData_Type.Name = "dIData_Type";
            dIData_Type.ReadOnly = true;
            dIData_Type.Width = 191;
            // 
            // dCharacter_Maximum_Length
            // 
            dCharacter_Maximum_Length.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dCharacter_Maximum_Length.DataPropertyName = "Character_Maximum_Length";
            dCharacter_Maximum_Length.HeaderText = "Col_Length";
            dCharacter_Maximum_Length.MinimumWidth = 10;
            dCharacter_Maximum_Length.Name = "dCharacter_Maximum_Length";
            dCharacter_Maximum_Length.ReadOnly = true;
            dCharacter_Maximum_Length.Width = 201;
            // 
            // dParameter_Mode
            // 
            dParameter_Mode.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dParameter_Mode.DataPropertyName = "Parameter_Mode";
            dParameter_Mode.HeaderText = "Parameter_Mode";
            dParameter_Mode.MinimumWidth = 10;
            dParameter_Mode.Name = "dParameter_Mode";
            dParameter_Mode.ReadOnly = true;
            dParameter_Mode.Width = 264;
            // 
            // dgvOutPutParams
            // 
            dgvOutPutParams.AllowUserToAddRows = false;
            dgvOutPutParams.AllowUserToDeleteRows = false;
            dgvOutPutParams.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOutPutParams.Columns.AddRange(new DataGridViewColumn[] { dOSPECIFIC_NAME, dOName, dSystem_Type_Name, dError_Message });
            dgvOutPutParams.Dock = DockStyle.Fill;
            dgvOutPutParams.Location = new Point(0, 0);
            dgvOutPutParams.Margin = new Padding(53, 16, 53, 16);
            dgvOutPutParams.Name = "dgvOutPutParams";
            dgvOutPutParams.ReadOnly = true;
            dgvOutPutParams.RowHeadersWidth = 82;
            dgvOutPutParams.RowTemplate.Height = 24;
            dgvOutPutParams.Size = new Size(995, 651);
            dgvOutPutParams.TabIndex = 1;
            dgvOutPutParams.TabStop = false;
            // 
            // dOSPECIFIC_NAME
            // 
            dOSPECIFIC_NAME.DataPropertyName = "SPECIFIC_NAME";
            dOSPECIFIC_NAME.HeaderText = "SPECIFIC_NAME";
            dOSPECIFIC_NAME.MinimumWidth = 10;
            dOSPECIFIC_NAME.Name = "dOSPECIFIC_NAME";
            dOSPECIFIC_NAME.ReadOnly = true;
            dOSPECIFIC_NAME.Visible = false;
            dOSPECIFIC_NAME.Width = 200;
            // 
            // dOName
            // 
            dOName.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dOName.DataPropertyName = "Name";
            dOName.HeaderText = "Name";
            dOName.MinimumWidth = 10;
            dOName.Name = "dOName";
            dOName.ReadOnly = true;
            dOName.Width = 130;
            // 
            // dSystem_Type_Name
            // 
            dSystem_Type_Name.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dSystem_Type_Name.DataPropertyName = "System_Type_Name";
            dSystem_Type_Name.HeaderText = "System_Type_Name";
            dSystem_Type_Name.MinimumWidth = 10;
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
            dError_Message.Width = 122;
            // 
            // chkSortByColName
            // 
            chkSortByColName.AutoSize = true;
            chkSortByColName.Location = new Point(21, 316);
            chkSortByColName.Name = "chkSortByColName";
            chkSortByColName.Size = new Size(269, 36);
            chkSortByColName.TabIndex = 8;
            chkSortByColName.Text = "Sort By Col Name";
            chkSortByColName.UseVisualStyleBackColor = true;
            // 
            // frmTables
            // 
            AutoScaleDimensions = new SizeF(17F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2442, 1360);
            Controls.Add(tabControl1);
            Margin = new Padding(8, 4, 8, 4);
            Name = "frmTables";
            Text = "Tables";
            Controls.SetChildIndex(panel1, 0);
            Controls.SetChildIndex(tabControl1, 0);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTables).EndInit();
            tabControl1.ResumeLayout(false);
            tabCommand.ResumeLayout(false);
            panel2.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
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
        private Button btnExportDBDiagramIO;
        private DataGridViewCheckBoxColumn dIsChecked;
        private RichTextBox txDbDiagramResult;
        private Panel panel2;
        private CheckBox chkNoteInName;
        private CheckBox chkToUpperCase;
        private CheckBox chkSortByColName;
    }
}