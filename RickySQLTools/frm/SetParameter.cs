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
    public partial class SetParameter : frmBase
    {
        DALSetParameter utiObj = new DALSetParameter();
        public SetParameter()
        {
            InitializeComponent();
        }

        private void SetParameter_Load(object sender, EventArgs e)
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
