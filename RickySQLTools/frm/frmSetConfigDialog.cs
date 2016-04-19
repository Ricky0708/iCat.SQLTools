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
        DALSetConfig utiObj = new DALSetConfig();
        public frmSetConfigDialog()
        {
            InitializeComponent();
        }

        private void SetConfigDialog_Load(object sender, EventArgs e)
        {

            txtConn.Text = utiObj.GetConnectionString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (utiObj.SaveConnectionString(txtConn.Text))
            {
                MessageBox.Show("Success！");
            }
            else
            {
                MessageBox.Show("Fail！");
            }

        }

    }
}
