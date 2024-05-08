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
    public partial class frmTables : frmBase
    {


        DAL.DALTables objDAL = new DAL.DALTables();
        ShareUtility objUti = new ShareUtility();
        CurrencyManager bmTables;
        CurrencyManager bmSps;
        DataFrom flag;

        DataSet ds;
        DataView dvFks;
        public frmTables()
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
        #endregion

        #region Event Button SQL
        private void btnLoadDataFromSQL_Click(object sender, EventArgs e)
        {
            if (objDAL.GetDatasetFromSQL())
            {
                ds = DALBase._dalDataset;
                BindFrm();
                tabControl1.SelectedTab = tabTablesAndCols;
                this.Parent.Text = "Tables-『SQL』";
                flag = DataFrom.SQL;
            }
            else
            {
                MessageBox.Show(objDAL.ErrMsg);
            }
        }

        private void Update_Description_Click(object sender, EventArgs e)
        {
            if (flag == DataFrom.Xml)
            {
                MessageBox.Show("This command only for load data from SQL !");
                return;
            }
            if (ds != null)
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
            else
            {
                MessageBox.Show("Please load data from SQL and modify it, befor you update to SQL !");
            }


        }

        private void btnUpdateAllDescription_Click(object sender, EventArgs e)
        {
            if (ds != null)
            {
                if (MessageBox.Show(this, "It will update and cover all current description to SQL ! \r\r Are you sure to do it ?", "Info", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach (DataTable dt in ds.Tables)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            if (dt.TableName != "Columns" || (dt.TableName == "Columns" && row["ColDescription"].ToString() != "not support"))
                            {
                                if (row.RowState == DataRowState.Unchanged)
                                {
                                    row.SetModified();
                                }
                                else
                                {
                                }
                            }
                        }
                    }
                    if (!objDAL.UpdateDescription(ref ds))
                    {
                        string msg = objDAL.ErrMsg + "\r\n\r\n";
                        msg += "If data access obj is empty,  try to follow these step :\r\n\r\n";
                        msg += "1. Save to xml file\r\n\r\n";
                        msg += "2. Make sure connection string is correct in [Set Config]\r\n\r\n";
                        msg += "3. Load data from SQL\r\n\r\n";
                        msg += "4. Load data from xml file\r\n\r\n";
                        msg += "5. update it again";
                        MessageBox.Show(msg);
                    }
                    else
                    {
                        MessageBox.Show("Success！");
                    }
                }

            }
            else
            {
                MessageBox.Show("Please load data and modify befor you update !");
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
                    ds = DALBase._dalDataset;
                    tabControl1.SelectedTab = tabTablesAndCols;
                    BindFrm();
                    this.Parent.Text = "Tables-『" + fileName.Substring(fileName.LastIndexOf("\\") + 1) + "』";
                    flag = DataFrom.Xml;
                }
                else
                {
                    MessageBox.Show(objDAL.ErrMsg);
                }
            }
        }

        private void btnSaveToXml_Click(object sender, EventArgs e)
        {
            if (ds != null)
            {
                string dbName = objUti.GetDbName(objDAL._strConn);
                string fileName = objUti.SetFileName(Application.StartupPath + "\\database\\", dbName, "Xml");
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
            else
            {
                MessageBox.Show("No data could be save !!");
            }

        }

        #endregion

        #region Event Button Generator
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (ds != null)
            {
                DAL.NpoiOperator objNpoi = new DAL.NpoiOperator(ds);
                string fileName = objUti.SetFileName(Application.StartupPath + "\\database\\", objUti.GetDbName(objDAL._strConn) + "_Schema", "xlsx");
                if (fileName != "")
                {
                    objNpoi.WriteToExcel(fileName);
                    MessageBox.Show("Success Export To Excel File !!");
                }
            }
            else
            {
                MessageBox.Show("No data could be export !!");
            }
        }



        #endregion

    }
}
