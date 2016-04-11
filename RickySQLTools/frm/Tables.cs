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
        BindingManagerBase bmMaster;
        DataSet ds;
        DataView dvFks;
        public Tables()
        {
            InitializeComponent();
            dgvColumns.AutoGenerateColumns = false;
            dgvTables.AutoGenerateColumns = false;
            dgvFK.AutoGenerateColumns = true;
            dgvIndexes.AutoGenerateColumns = false;
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

            bmMaster = (BindingManagerBase)this.BindingContext[ds, "Tables"];
            bmMaster.PositionChanged += (sender, e) =>
            {
                string tableName = ((DataRowView)bmMaster.Current)["TableName"].ToString();
                dvFks.RowFilter = "ParentTable = '" + tableName + "' OR ReferencedTable = '" + tableName + "'";
                dColDescription.ReadOnly = ((DataRowView)bmMaster.Current)["TableType"].ToString() == "VIEW";
            };
            dvFks.RowFilter = "ParentTable = '" + ((DataRowView)bmMaster.Current)["TableName"].ToString() + "' OR ReferencedTable = '" + ((DataRowView)bmMaster.Current)["TableName"].ToString() + "'";
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
            if (objDAL.SaveToXml(ref ds))
            {
                MessageBox.Show("Success save to  xml file!!");
            }
            else
            {
                MessageBox.Show("fail save to  xml file!!");
            }
        }

        #endregion

        #region Event Button XML
        private void btnLoadDataFromXML_Click(object sender, EventArgs e)
        {
            if (objDAL.GetDatasetFromXml())
            {
                ds = objDAL.ds;
                tabControl1.SelectedTab = tabTablesAndCols;
                BindFrm();
            }
            else
            {
                MessageBox.Show(objDAL.ErrMsg);
            }

        }

        #endregion

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (ds != null)
            {
                DAL.DALNpoiOperator objNpoi = new DAL.DALNpoiOperator(ds);
                objNpoi.WriteToExcel();
                MessageBox.Show("Success Export To Excel File !!");
            }

        }
    }
}
