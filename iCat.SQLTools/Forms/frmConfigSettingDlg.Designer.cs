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
            SuspendLayout();
            // 
            // txtConnectionString
            // 
            txtConnectionString.Location = new Point(85, 56);
            txtConnectionString.Margin = new Padding(2, 3, 2, 3);
            txtConnectionString.Multiline = true;
            txtConnectionString.Name = "txtConnectionString";
            txtConnectionString.Size = new Size(413, 54);
            txtConnectionString.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 59);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 2;
            label1.Text = "Connection";
            // 
            // cboConnectionType
            // 
            cboConnectionType.FormattingEnabled = true;
            cboConnectionType.Location = new Point(85, 116);
            cboConnectionType.Margin = new Padding(2, 3, 2, 3);
            cboConnectionType.Name = "cboConnectionType";
            cboConnectionType.Size = new Size(143, 23);
            cboConnectionType.TabIndex = 3;
            // 
            // txtUsing
            // 
            txtUsing.BackColor = SystemColors.Info;
            txtUsing.Location = new Point(85, 175);
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
            txtNamespace.Location = new Point(85, 144);
            txtNamespace.Margin = new Padding(2, 3, 2, 3);
            txtNamespace.Name = "txtNamespace";
            txtNamespace.PlaceHolder = "Namespace";
            txtNamespace.Size = new Size(271, 23);
            txtNamespace.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(439, 383);
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
            txtClassSuffix.Location = new Point(360, 144);
            txtClassSuffix.Margin = new Padding(2, 3, 2, 3);
            txtClassSuffix.Name = "txtClassSuffix";
            txtClassSuffix.PlaceHolder = "Class Suffix";
            txtClassSuffix.Size = new Size(137, 23);
            txtClassSuffix.TabIndex = 7;
            // 
            // frmConfigSettingDlg
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(530, 423);
            Controls.Add(txtClassSuffix);
            Controls.Add(btnSave);
            Controls.Add(txtNamespace);
            Controls.Add(txtUsing);
            Controls.Add(cboConnectionType);
            Controls.Add(label1);
            Controls.Add(txtConnectionString);
            Margin = new Padding(2, 3, 2, 3);
            Name = "frmConfigSettingDlg";
            Text = "Config Setting";
            ResumeLayout(false);
            PerformLayout();
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
    }
}