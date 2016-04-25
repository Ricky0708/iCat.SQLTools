using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using RickySQLTools.DAL;

namespace RickySQLTools
{
    public partial class frmSetConfigDialog : frmBase
    {
        public event ConfigSetHandler SetConfig;
        public delegate void ConfigSetHandler(object sender,object e);

        DALSetConfig utiObj = new DALSetConfig();
        public frmSetConfigDialog()
        {
            InitializeComponent();
            base.SetHideButton(HideButton.SetConfig);
        }

        private void SetConfigDialog_Load(object sender, EventArgs e)
        {
            txtConn.Text = utiObj.defConnectionString;
            txtNamespace.Text = utiObj.defNamespace;
            txtUsing.Text = utiObj.defUsing;
            chkIncludeAttr.Checked = utiObj.defIncludeAttr;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            utiObj.defUsing = txtUsing.Text;
            utiObj.defConnectionString = txtConn.Text;
            utiObj.defNamespace = txtNamespace.Text;
            utiObj.defIncludeAttr = chkIncludeAttr.Checked;
            if (utiObj.SaveConfig())
            {
                MessageBox.Show("Success！");
                SetConfig(this, null);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Fail！");
            }

        }

    }
}
