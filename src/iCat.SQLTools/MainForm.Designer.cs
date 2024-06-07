namespace iCat.SQLTools
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            panel1 = new Panel();
            dgvDatasets = new DataGridView();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnLoadFromSQL = new Button();
            btnLoadFromXML = new Button();
            tabControl1 = new TabControl();
            dCategory = new DataGridViewTextBoxColumn();
            dDelete = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatasets).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(2, 3, 2, 3);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tabControl1);
            splitContainer1.Size = new Size(922, 450);
            splitContainer1.SplitterDistance = 184;
            splitContainer1.SplitterWidth = 3;
            splitContainer1.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvDatasets);
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(184, 450);
            panel1.TabIndex = 0;
            // 
            // dgvDatasets
            // 
            dgvDatasets.AllowUserToAddRows = false;
            dgvDatasets.AllowUserToDeleteRows = false;
            dgvDatasets.AllowUserToResizeColumns = false;
            dgvDatasets.AllowUserToResizeRows = false;
            dgvDatasets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatasets.Columns.AddRange(new DataGridViewColumn[] { dCategory, dDelete });
            dgvDatasets.Dock = DockStyle.Fill;
            dgvDatasets.Location = new Point(0, 29);
            dgvDatasets.Name = "dgvDatasets";
            dgvDatasets.ReadOnly = true;
            dgvDatasets.Size = new Size(184, 421);
            dgvDatasets.TabIndex = 0;
            dgvDatasets.CellContentClick += dgvDatasets_CellContentClick;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(btnLoadFromSQL, 0, 0);
            tableLayoutPanel1.Controls.Add(btnLoadFromXML, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(184, 29);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // btnLoadFromSQL
            // 
            btnLoadFromSQL.Dock = DockStyle.Fill;
            btnLoadFromSQL.Location = new Point(3, 3);
            btnLoadFromSQL.Name = "btnLoadFromSQL";
            btnLoadFromSQL.Size = new Size(86, 23);
            btnLoadFromSQL.TabIndex = 0;
            btnLoadFromSQL.Text = "SQL";
            btnLoadFromSQL.UseVisualStyleBackColor = true;
            btnLoadFromSQL.Click += btnLoadFromSQL_Click;
            // 
            // btnLoadFromXML
            // 
            btnLoadFromXML.Dock = DockStyle.Fill;
            btnLoadFromXML.Location = new Point(95, 3);
            btnLoadFromXML.Name = "btnLoadFromXML";
            btnLoadFromXML.Size = new Size(86, 23);
            btnLoadFromXML.TabIndex = 1;
            btnLoadFromXML.Text = "XML";
            btnLoadFromXML.UseVisualStyleBackColor = true;
            btnLoadFromXML.Click += btnLoadFromXML_Click;
            // 
            // tabControl1
            // 
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(735, 450);
            tabControl1.TabIndex = 0;
            // 
            // dCategory
            // 
            dCategory.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dCategory.DataPropertyName = "Category";
            dCategory.HeaderText = "Category";
            dCategory.Name = "dCategory";
            dCategory.ReadOnly = true;
            // 
            // dDelete
            // 
            dDelete.FillWeight = 50F;
            dDelete.HeaderText = "";
            dDelete.Name = "dDelete";
            dDelete.ReadOnly = true;
            dDelete.Resizable = DataGridViewTriState.False;
            dDelete.SortMode = DataGridViewColumnSortMode.Automatic;
            dDelete.Text = "-";
            dDelete.UseColumnTextForButtonValue = true;
            dDelete.Width = 50;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(922, 450);
            Controls.Add(splitContainer1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            WindowState = FormWindowState.Maximized;
            Load += MainForm_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDatasets).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Panel panel1;
        private TabControl tabControl1;
        private DataGridView dgvDatasets;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnLoadFromSQL;
        private Button btnLoadFromXML;
        private DataGridViewTextBoxColumn dCategory;
        private DataGridViewButtonColumn dDelete;
    }
}
