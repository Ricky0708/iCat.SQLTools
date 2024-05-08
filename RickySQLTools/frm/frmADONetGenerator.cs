using RickySQLTools.DAL;
using RickySQLTools.Utilitys;
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
    public partial class frmADONetGenerator : frmBase
    {
        DAL.DALADONetGenerator objDAL = new DAL.DALADONetGenerator();
        ShareUtility objUti = new ShareUtility();
        DataSet ds;
        CurrencyManager cmTables;

        public frmADONetGenerator()
        {
            InitializeComponent();
            dgvTables.AutoGenerateColumns = false;
        }

        private void frmADONetGenerator_Load(object sender, EventArgs e)
        {
            if (objDAL.CreateDataSet())
            {
                dgvTables.Focus();
                ds = DALBase._dalDataset;
                dgvTables.DataSource = ds;
                dgvTables.DataMember = "Tables";
                cmTables = (CurrencyManager)this.BindingContext[ds, "Tables"];
                ((DataView)cmTables.List).RowFilter = "TableName LIKE '%" + txtTableFilter.Text + "%'";
            }
            else
            {
                MessageBox.Show(objDAL.ErrMsg);
            }
        }

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                if (sender != null)
                    ((TextBox)sender).SelectAll();

            }
        }

        protected override void AfterSetConfig(object sender, object e)
        {
            if (objDAL._strConn != Utilitys.ShareUtility.GetSettings(SettingEnum.GetConnectionString).ToString())
            {
                frmADONetGenerator_Load(null, null);
            }
            else
            {
                string ErrMsg = objDAL.ErrMsg;
                if (ErrMsg != "")
                {
                    MessageBox.Show(objDAL.ErrMsg);
                }
            }
        }
        private void txtTableFilter_TextChanged(object sender, EventArgs e)
        {
            if (cmTables != null)
            {
                ((DataView)cmTables.List).RowFilter = "TableName LIKE '%" + txtTableFilter.Text + "%'";
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            string tableName = ((DataRowView)cmTables.Current)["TableName"].ToString();
            string btnName = ((Button)sender).Name;
            SPType sptype;
            switch (btnName)
            {
                case "btnSelect":
                    sptype = SPType.Select;
                    break;
                case "btnInsert":
                    sptype = SPType.Insert;
                    break;
                case "btnUpdate":
                    sptype = SPType.Update;
                    break;
                case "btnDelete":
                    sptype = SPType.Delete;
                    break;
                default:
                    sptype = SPType.def;
                    break;
            }

            txtResult.Text = objDAL.GenerateScript(ds, tableName, sptype);

        }
    }
}
