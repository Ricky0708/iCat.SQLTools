using iCat.SQLTools.Models;
using iCat.SQLTools.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iCat.SQLTools.Forms
{
    public partial class frmTables : frmBase
    {
        CurrencyManager bmTables;
        CurrencyManager bmSps;

        DataSet ds;
        DataView dvFks;
        private readonly ISchemaService _schemaService;

        public frmTables(
            SettingConfig config,
            ISchemaService schemaService
            )
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
            _schemaService = schemaService ?? throw new ArgumentNullException(nameof(schemaService));
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
            
        }

        private void Update_Description_Click(object sender, EventArgs e)
        {
           


        }

        private void btnUpdateAllDescription_Click(object sender, EventArgs e)
        {
         
        }

        #endregion

        #region Event Button XML
        private void btnLoadDataFromXML_Click(object sender, EventArgs e)
        {

  
        }

        private void btnSaveToXml_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Event Button Generator
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
           
        }



        #endregion
    }
}
