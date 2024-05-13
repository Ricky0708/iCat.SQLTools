namespace iCat.SQLTools.Forms
{
    partial class frmFeatureBase
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
            btnLoadData = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnLoadData);
            panel1.Size = new Size(800, 40);
            panel1.Controls.SetChildIndex(btnLoadData, 0);
            // 
            // btnLoadData
            // 
            btnLoadData.Dock = DockStyle.Right;
            btnLoadData.Location = new Point(600, 0);
            btnLoadData.Name = "btnLoadData";
            btnLoadData.Size = new Size(100, 40);
            btnLoadData.TabIndex = 2;
            btnLoadData.Text = "LoadData";
            btnLoadData.UseVisualStyleBackColor = true;
            // 
            // frmFeatureBase
            // 
            AutoScaleDimensions = new SizeF(9F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Name = "frmFeatureBase";
            Text = "frmFeatureBase";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnLoadData;
    }
}