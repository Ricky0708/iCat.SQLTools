namespace iCat.SQLTools.Forms
{
    partial class frmConfigSettingDlg
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
            txtConnectionString = new TextBox();
            label1 = new Label();
            cboConnectionType = new ComboBox();
            txtUsing = new CustomControlleres.PlaceholderTextBox();
            txtNamespace = new CustomControlleres.PlaceholderTextBox();
            btnSave = new Button();
            txtClassSuffix = new CustomControlleres.PlaceholderTextBox();
            groupBox1 = new GroupBox();
            panel1 = new Panel();
            dgvSettings = new DataGridView();
            dKey = new DataGridViewTextBoxColumn();
            txtKey = new TextBox();
            lblKey = new Label();
            btnAddNew = new Button();
            btnDelete = new Button();
            btnLoadData = new Button();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSettings).BeginInit();
            SuspendLayout();
            // 
            // txtConnectionString
            // 
            txtConnectionString.Location = new Point(95, 56);
            txtConnectionString.Margin = new Padding(2, 3, 2, 3);
            txtConnectionString.Multiline = true;
            txtConnectionString.Name = "txtConnectionString";
            txtConnectionString.Size = new Size(413, 54);
            txtConnectionString.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 59);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 2;
            label1.Text = "Connection";
            // 
            // cboConnectionType
            // 
            cboConnectionType.FormattingEnabled = true;
            cboConnectionType.Location = new Point(95, 116);
            cboConnectionType.Margin = new Padding(2, 3, 2, 3);
            cboConnectionType.Name = "cboConnectionType";
            cboConnectionType.Size = new Size(143, 23);
            cboConnectionType.TabIndex = 3;
            // 
            // txtUsing
            // 
            txtUsing.BackColor = SystemColors.Info;
            txtUsing.Location = new Point(95, 175);
            txtUsing.Margin = new Padding(2, 3, 2, 3);
            txtUsing.Multiline = true;
            txtUsing.Name = "txtUsing";
            txtUsing.PlaceHolder = "Using";
            txtUsing.ScrollBars = ScrollBars.Both;
            txtUsing.Size = new Size(413, 203);
            txtUsing.TabIndex = 4;
            // 
            // txtNamespace
            // 
            txtNamespace.BackColor = SystemColors.Info;
            txtNamespace.Location = new Point(95, 144);
            txtNamespace.Margin = new Padding(2, 3, 2, 3);
            txtNamespace.Name = "txtNamespace";
            txtNamespace.PlaceHolder = "Namespace";
            txtNamespace.Size = new Size(271, 23);
            txtNamespace.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(449, 383);
            btnSave.Margin = new Padding(2, 3, 2, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(58, 22);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtClassSuffix
            // 
            txtClassSuffix.BackColor = SystemColors.Info;
            txtClassSuffix.Location = new Point(370, 144);
            txtClassSuffix.Margin = new Padding(2, 3, 2, 3);
            txtClassSuffix.Name = "txtClassSuffix";
            txtClassSuffix.PlaceHolder = "Class Suffix";
            txtClassSuffix.Size = new Size(137, 23);
            txtClassSuffix.TabIndex = 7;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnLoadData);
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnAddNew);
            groupBox1.Controls.Add(lblKey);
            groupBox1.Controls.Add(txtKey);
            groupBox1.Controls.Add(txtConnectionString);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtClassSuffix);
            groupBox1.Controls.Add(cboConnectionType);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(txtUsing);
            groupBox1.Controls.Add(txtNamespace);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(200, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(537, 426);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvSettings);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 426);
            panel1.TabIndex = 9;
            // 
            // dgvSettings
            // 
            dgvSettings.AllowUserToAddRows = false;
            dgvSettings.AllowUserToDeleteRows = false;
            dgvSettings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSettings.Columns.AddRange(new DataGridViewColumn[] { dKey });
            dgvSettings.Dock = DockStyle.Fill;
            dgvSettings.Location = new Point(0, 0);
            dgvSettings.Name = "dgvSettings";
            dgvSettings.ReadOnly = true;
            dgvSettings.Size = new Size(200, 426);
            dgvSettings.TabIndex = 0;
            // 
            // dKey
            // 
            dKey.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dKey.DataPropertyName = "Key";
            dKey.HeaderText = "Key";
            dKey.Name = "dKey";
            dKey.ReadOnly = true;
            // 
            // txtKey
            // 
            txtKey.Location = new Point(95, 27);
            txtKey.Name = "txtKey";
            txtKey.Size = new Size(413, 23);
            txtKey.TabIndex = 8;
            // 
            // lblKey
            // 
            lblKey.AutoSize = true;
            lblKey.Location = new Point(64, 30);
            lblKey.Margin = new Padding(2, 0, 2, 0);
            lblKey.Name = "lblKey";
            lblKey.Size = new Size(26, 15);
            lblKey.TabIndex = 9;
            lblKey.Text = "Key";
            // 
            // btnAddNew
            // 
            btnAddNew.Location = new Point(95, 384);
            btnAddNew.Margin = new Padding(2, 3, 2, 3);
            btnAddNew.Name = "btnAddNew";
            btnAddNew.Size = new Size(58, 22);
            btnAddNew.TabIndex = 10;
            btnAddNew.Text = "Add";
            btnAddNew.UseVisualStyleBackColor = true;
            btnAddNew.Click += btnAddNew_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(157, 384);
            btnDelete.Margin = new Padding(2, 3, 2, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(58, 22);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnLoadData
            // 
            btnLoadData.Location = new Point(369, 382);
            btnLoadData.Name = "btnLoadData";
            btnLoadData.Size = new Size(75, 23);
            btnLoadData.TabIndex = 12;
            btnLoadData.Text = "Load Data";
            btnLoadData.UseVisualStyleBackColor = true;
            // 
            // frmConfigSettingDlg
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(737, 426);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            Margin = new Padding(2, 3, 2, 3);
            Name = "frmConfigSettingDlg";
            Text = "Config Setting";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSettings).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtConnectionString;
        private Label label1;
        private RadioButton rdoMSSQL;
        private RadioButton rdoMySQL;
        private ComboBox cboConnectionType;
        private CustomControlleres.PlaceholderTextBox txtUsing;
        private CustomControlleres.PlaceholderTextBox txtNamespace;
        private Button btnSave;
        private CustomControlleres.PlaceholderTextBox txtClassSuffix;
        private GroupBox groupBox1;
        private Panel panel1;
        private DataGridView dgvSettings;
        private DataGridViewTextBoxColumn dKey;
        private Label lblKey;
        private TextBox txtKey;
        private Button btnAddNew;
        private Button btnDelete;
        private Button btnLoadData;
    }
}