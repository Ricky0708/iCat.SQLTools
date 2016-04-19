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
    public partial class Tables : frmBase
    {
        DAL.DALTables objDAL = new DAL.DALTables();
        DAL.DALUtility objUti = new DAL.DALUtility();
        CurrencyManager bmTables;
        CurrencyManager bmSps;

        DataSet ds;
        DataView dvFks;
        public Tables()
        {
            InitializeComponent();
            dgvColumns.AutoGenerateColumns = false;
            dgvTables.AutoGenerateColumns = false;
            dgvFK.AutoGenerateColumns = true;
            dgvIndexes.AutoGenerateColumns = false;

            txtTableFilter.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    dgvTables.Focus();
                }
            };

            txtSpFilter.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    dgvSpsAndFuncs.Focus();
                }
            };
        }

        #region method

        private void BindFrm()
        {
            dgvTables.DataSource = ds;
            dgvTables.DataMember = "Tables";

            dgvColumns.DataSource = ds;
            dgvColumns.DataMember = "Tables.MasterDetailCols";

            dvFks = ds.Tables["FKs"].DefaultView;
            dgvFK.DataSource = dvFks;

            dgvIndexes.DataSource = ds;
            dgvIndexes.DataMember = "Tables.MasterDetailIndexes";

            dgvSpsAndFuncs.DataSource = ds;
            dgvSpsAndFuncs.DataMember = "SpsAndFuncs";

            dgvInputParams.DataSource = ds;
            dgvInputParams.DataMember = "SpsAndFuncs.MasterDetailInputParams";

            dgvOutPutParams.DataSource = ds;
            dgvOutPutParams.DataMember = "SpsAndFuncs.MasterDetailOutputParams";

            bmTables = (CurrencyManager)this.BindingContext[ds, "Tables"];
            bmSps = (CurrencyManager)this.BindingContext[ds, "SpsAndFuncs"];

            bmTables.PositionChanged += (sender, e) =>
            {
                if (bmTables.Position != -1)
                {
                    string tableName = ((DataRowView)bmTables.Current)["TableName"].ToString();
                    dvFks.RowFilter = "ParentTable = '" + tableName + "' OR ReferencedTable = '" + tableName + "'";
                    dColDescription.ReadOnly = ((DataRowView)bmTables.Current)["TableType"].ToString() == "VIEW";
                }
            };
            dvFks.RowFilter = "ParentTable = '" + ((DataRowView)bmTables.Current)["TableName"].ToString() + "' OR ReferencedTable = '" + ((DataRowView)bmTables.Current)["TableName"].ToString() + "'";
        }
        #endregion

        #region Event Button SQL
        private void btnLoadDataFromSQL_Click(object sender, EventArgs e)
        {
            if (objDAL.GetDatasetFromSQL())
            {
                ds = objDAL.ds;
                BindFrm();
                tabControl1.SelectedTab = tabTablesAndCols;
                this.Parent.Text = "Tables-『SQL』";
            }
            else
            {
                MessageBox.Show(objDAL.ErrMsg);
            }
        }

        private void Update_Description_Click(object sender, EventArgs e)
        {

            if (!objDAL.UpdateDescription(ref ds))
            {
                MessageBox.Show(objDAL.ErrMsg);
            }
            else
            {
                MessageBox.Show("Success！");
            }
        }

        private void btnSaveToXml_Click(object sender, EventArgs e)
        {
            string fileName = objUti.SetFileName();
            if (fileName != "")
            {
                if (objDAL.SaveToXml(ref ds, fileName))
                {
                    MessageBox.Show("Success save to  xml file!!");
                }
                else
                {
                    MessageBox.Show("fail save to  xml file!!");
                }
            }
        }

        #endregion

        #region Event Button XML
        private void btnLoadDataFromXML_Click(object sender, EventArgs e)
        {

            string fileName = objUti.GetFileName();
            if (fileName != "")
            {
                if (objDAL.GetDatasetFromXml(fileName))
                {
                    ds = objDAL.ds;
                    tabControl1.SelectedTab = tabTablesAndCols;
                    BindFrm();
                    this.Parent.Text = "Tables-『" + fileName.Substring(fileName.LastIndexOf("\\") + 1) + "』";
                }
                else
                {
                    MessageBox.Show(objDAL.ErrMsg);
                }
            }
        }


        #endregion

        #region event Generator
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (ds != null)
            {
                DAL.DALNpoiOperator objNpoi = new DAL.DALNpoiOperator(ds);
                objNpoi.WriteToExcel();
                MessageBox.Show("Success Export To Excel File !!");
            }

        }

        #endregion


        private void Filter(object sender, EventArgs e)
        {
            if (bmTables != null)
            {
                ((DataView)bmTables.List).RowFilter = "TableName LIKE '%" + txtTableFilter.Text + "%'";
            }
            if (bmSps != null)
            {
                ((DataView)bmSps.List).RowFilter = "SPECIFIC_NAME LIKE '%" + txtSpFilter.Text + "%'";
            }

        }

        private void btnConnString_Click(object sender, EventArgs e)
        {
            frmSetConfigDialog frm = new frmSetConfigDialog();
            frm.ShowDialog();
        }
    }
}
