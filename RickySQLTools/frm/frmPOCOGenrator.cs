using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RickySQLTools
{
    public partial class frmPOCOGenrator : frmBase
    {
        DAL.DALPOCOGenerator objDAL = new DAL.DALPOCOGenerator();
        DataSet ds;
        CurrencyManager bmTables;
        public frmPOCOGenrator()
        {
            InitializeComponent();
            dgvTables.AutoGenerateColumns = false;

        }

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                if (sender != null)
                    ((TextBox)sender).SelectAll();
            }
        }

        private void frmPOCOGenrator_Load(object sender, EventArgs e)
        {

            if (objDAL.CreateDataSet())
            {
                txtClassName.Focus();
                ds = objDAL.dalDataset;
                dgvTables.DataSource = ds;
                dgvTables.DataMember = "Tables";
                bmTables = (CurrencyManager)this.BindingContext[ds, "Tables"];
                ((DataView)bmTables.List).RowFilter = "TableName LIKE '%" + txtTableFilter.Text + "%'";
            }

        }
        private void btn_Click(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case "btnFromScript":
                    if (txtClassName.Text == "")
                    {
                        txtClassName.Focus();
                        MessageBox.Show("Please type in a class name..");
                    }
                    txtResult.Text = objDAL.GenerateFromScript(txtClassName.Text, txtScript.Text);
                    if (txtResult.Text == "")
                    {
                        MessageBox.Show(objDAL.ErrMsg);
                    }
                    break;
                case "btnFromDB":
                    break;
                case "btnFromXml":
                    break;
                default:
                    break;
            }
        }

        protected override void AfterSetConfig(object sender, object e)
        {
            if (objDAL._strConn != Utilitys.ShareUtility.GetSettings(SettingEnum.GetConnectionString).ToString())
            {
                frmPOCOGenrator_Load(null, null);
            }
        }

        private void txtTableFilter_TextChanged(object sender, EventArgs e)
        {
            if (bmTables != null)
            {
                ((DataView)bmTables.List).RowFilter = "TableName LIKE '%" + txtTableFilter.Text + "%'";
            }
        }

        private void dgvTables_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bmTables.Position != -1)
            {
                string tableName = ((DataRowView)bmTables.Current)["TableName"].ToString();
                txtClassName.Text = tableName;
                txtScript.Text = "SELECT * FROM " + tableName;
            }
        }
    }
}
