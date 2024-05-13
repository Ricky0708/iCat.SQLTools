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
            SuspendLayout();
            // 
            // txtConnectionString
            // 
            txtConnectionString.Location = new Point(100, 60);
            txtConnectionString.Name = "txtConnectionString";
            txtConnectionString.Size = new Size(530, 27);
            txtConnectionString.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 63);
            label1.Name = "label1";
            label1.Size = new Size(79, 16);
            label1.TabIndex = 2;
            label1.Text = "Connection";
            // 
            // cboConnectionType
            // 
            cboConnectionType.FormattingEnabled = true;
            cboConnectionType.Location = new Point(100, 93);
            cboConnectionType.Name = "cboConnectionType";
            cboConnectionType.Size = new Size(183, 24);
            cboConnectionType.TabIndex = 3;
            // 
            // txtUsing
            // 
            txtUsing.BackColor = SystemColors.Info;
            txtUsing.Location = new Point(100, 156);
            txtUsing.Multiline = true;
            txtUsing.Name = "txtUsing";
            txtUsing.PlaceHolder = "Using";
            txtUsing.ScrollBars = ScrollBars.Both;
            txtUsing.Size = new Size(530, 216);
            txtUsing.TabIndex = 4;
            // 
            // txtNamespace
            // 
            txtNamespace.BackColor = SystemColors.Info;
            txtNamespace.Location = new Point(100, 123);
            txtNamespace.Name = "txtNamespace";
            txtNamespace.PlaceHolder = "Namespace";
            txtNamespace.Size = new Size(530, 27);
            txtNamespace.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(555, 378);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // frmConfigSetting
            // 
            AutoScaleDimensions = new SizeF(9F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(682, 444);
            Controls.Add(btnSave);
            Controls.Add(txtNamespace);
            Controls.Add(txtUsing);
            Controls.Add(cboConnectionType);
            Controls.Add(label1);
            Controls.Add(txtConnectionString);
            Name = "frmConfigSetting";
            Text = "Config Setting";
            Controls.SetChildIndex(txtConnectionString, 0);
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(cboConnectionType, 0);
            Controls.SetChildIndex(txtUsing, 0);
            Controls.SetChildIndex(txtNamespace, 0);
            Controls.SetChildIndex(btnSave, 0);
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
    }
}