using iCat.SQLTools.Services.Interfaces;
using iCat.SQLTools.Services.Managers;
using iCat.SQLTools.Shareds.Enums;
using Microsoft.IdentityModel.Tokens;
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
    public partial class frmCodeGenerator : frmBase
    {
        //DAL.DALADONetGenerator objDAL = new DAL.DALADONetGenerator();
        //ShareUtility objUti = new ShareUtility();
        CurrencyManager? cmTables = default(CurrencyManager);
        private readonly ISchemaService _schemaService;
        private readonly DatasetManager _datasetManager;

        public frmCodeGenerator(
            ISchemaService schemaService,
            DatasetManager datasetManager)
        {
            InitializeComponent();
            dgvTables.AutoGenerateColumns = false;
            _schemaService = schemaService ?? throw new ArgumentNullException(nameof(schemaService));
            _datasetManager = datasetManager ?? throw new ArgumentNullException(nameof(datasetManager));
        }

        private void frmADONetGenerator_Load(object sender, EventArgs e)
        {
            if (_datasetManager.Dataset != null)
            {
                dgvTables.Focus();
                dgvTables.DataSource = _datasetManager.Dataset;
                dgvTables.DataMember = "Tables";
                cmTables = (CurrencyManager)this.BindingContext![_datasetManager.Dataset, Consts.strTables];
                ((DataView)cmTables.List).RowFilter = "TableName LIKE '%" + txtTableFilter.Text + "%'";
            }
            else
            {
                MessageBox.Show("Please load data first.");
            }
        }


        private void frmCodeGenerator_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F)
            {
                txtTableFilter.Focus();
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


        private void txtTableFilter_TextChanged(object sender, EventArgs e)
        {
            if (cmTables != null)
            {
                var filters = txtTableFilter.Text.Split(',');
                var resultString = "";
                var i = 0;
                foreach (var filter in filters)
                {
                    if (!string.IsNullOrEmpty(filter))
                    {
                        resultString += i == 0 ? "TableName LIKE '%" + filter + "%'" : " OR TableName LIKE '%" + filter + "%'";
                        i++;
                    }
                }
                ((DataView)cmTables.List).RowFilter = resultString;
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (_datasetManager.Dataset != null && _datasetManager.Dataset.Tables[Consts.strColumns] != null)
                {
                    string tableName = ((DataRowView)cmTables!.Current)["TableName"].ToString()!;
                    string btnName = ((Button)sender).Name;
                    ParameterType paramType =
                        rdoMSSSQL.Checked ? ParameterType.MSSQL :
                        rdoMySQL.Checked ? ParameterType.MySQL :
                        rdoODBC.Checked ? ParameterType.ODBC :
                        throw new ArgumentException("Unknow parameter type.");
                    switch (btnName)
                    {
                        case "btnSelect": txtResult.Text = _schemaService.GenerateDapperScript(_datasetManager.Dataset!.Tables[Consts.strColumns]!, tableName, ScriptKind.Select, paramType); break;
                        case "btnInsert": txtResult.Text = _schemaService.GenerateDapperScript(_datasetManager.Dataset!.Tables[Consts.strColumns]!, tableName, ScriptKind.Insert, paramType); break;
                        case "btnUpdate": txtResult.Text = _schemaService.GenerateDapperScript(_datasetManager.Dataset!.Tables[Consts.strColumns]!, tableName, ScriptKind.Update, paramType); break;
                        case "btnDelete": txtResult.Text = _schemaService.GenerateDapperScript(_datasetManager.Dataset!.Tables[Consts.strColumns]!, tableName, ScriptKind.Delete, paramType); break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}
