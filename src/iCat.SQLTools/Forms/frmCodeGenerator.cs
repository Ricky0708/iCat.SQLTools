using iCat.SQLTools.Models;
using iCat.SQLTools.Services.Interfaces;
using iCat.SQLTools.Services.Managers;
using iCat.SQLTools.Shareds.Enums;
using Microsoft.Extensions.DependencyInjection;
using NPOI.OpenXmlFormats.Spreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.SqlServer.Management.SqlParser.Metadata.MetadataInfoProvider;

namespace iCat.SQLTools.Forms
{
    public partial class frmCodeGenerator : frmBase
    {
        //DAL.DALPOCOGenerator objDAL = new DAL.DALPOCOGenerator();
        //DAL.DALClassModelGenerator objDAL2 = new DAL.DALClassModelGenerator();
        //ShareUtility objUti = new ShareUtility();
        DataTable dtScript;
        CurrencyManager cmTables;
        CurrencyManager cmScripts;
        CurrencyManager cmSPAndFuncs;
        private readonly SettingConfig _settingConfig;
        private readonly IFileService _fileService;
        private readonly ISchemaService _schemaService;

        DatasetManager? _datasetManager => (CurrencyManager?.Position ?? -1) > -1 ? (DatasetManager)CurrencyManager.Current : null;


        public frmCodeGenerator(
            IServiceProvider provider
            ) : base(provider)
        {
            InitializeComponent();
            dgvTables.AutoGenerateColumns = false;
            dtScript = new DataTable("Scripts");
            dtScript.Columns.Add("ScriptName");
            dtScript.Columns.Add("Script");
            dtScript.Columns.Add("cmd");
            cmScripts = (CurrencyManager)this.BindingContext[dtScript];
            _schemaService = provider.GetRequiredService<ISchemaService>();
            _fileService = provider.GetRequiredService<IFileService>();
            //tableLayoutPanel1.SetColumnSpan(btnAllTables, 2);
            //Button btnAddScript = new Button();
            //btnAddScript.Name = "btnAddScript";
            //btnAddScript.Text = "＋";
            //btnAddScript.Dock = DockStyle.Right;
            //btnAddScript.Size = new Size(30, 30);
            //btnAddScript.Cursor = Cursors.Default;
        }

        protected override void BindFrm()
        {
            if (_datasetManager?.Dataset != null && _datasetManager.DataSource != DataSource.None )
            {
                dgvTables.Focus();
                dgvTables.DataSource = _datasetManager.Dataset;
                dgvTables.DataMember = "Tables";
                cmTables = (CurrencyManager)this.BindingContext![_datasetManager.Dataset, "Tables"];
                cmSPAndFuncs = (CurrencyManager)this.BindingContext[_datasetManager.Dataset, "SpsAndFuncs"];
                ((DataView)cmTables.List).RowFilter = "TableName LIKE '%" + txtTableFilter.Text + "%'";

                var parameterTypes = ((ParameterType[])Enum.GetValues(typeof(ParameterType)))
                    .Select(p => new
                    {
                        Name = p.ToString(),
                        Value = p
                    }).ToList();

                cboParameterType.DataSource = parameterTypes;
                cboParameterType.DisplayMember = "Name";
                cboParameterType.ValueMember = "Value";
                cboParameterType.SelectedValue = ParameterType.MSSQL;
            }
            else
            {
                MessageBox.Show("Please load data first.");
            }
        }

        protected override void SetControlEnabled(DataSource dataSource)
        {
            base.SetControlEnabled(dataSource);
            btnWithoutComment.Enabled = dataSource == DataSource.MSSQL || dataSource == DataSource.MySQL || dataSource == DataSource.Oracle;
            btnAllTables.Enabled = dataSource == DataSource.MSSQL || dataSource == DataSource.MySQL || dataSource == DataSource.Oracle;
            btnClassAssign.Enabled = dataSource == DataSource.MSSQL || dataSource == DataSource.MySQL || dataSource == DataSource.Oracle;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (_datasetManager?.Dataset?.Tables[Consts.strTables] != null)
                {
                    string tableName = ((DataRowView)cmTables!.Current)["TableName"].ToString()!;
                    switch (((Button)sender).Name)
                    {
                        case nameof(btnWithComment):
                            if (txtClassName.Text == "")
                            {
                                txtClassName.Focus();
                                MessageBox.Show("Please type in a class name..");
                            }
                            txtResult.Text = _schemaService.GenerateClassWithSummary(_datasetManager.Dataset.Tables[Consts.strColumns]!, _datasetManager.Namespace, _datasetManager.Using, $"{txtClassName.Text}{_datasetManager.ClassSuffix}", txtScript.Text);
                            break;
                        case nameof(btnWithoutComment):
                            if (txtClassName.Text == "")
                            {
                                txtClassName.Focus();
                                MessageBox.Show("Please type in a class name..");
                                return;
                            }
                            if (_datasetManager.DataSource != DataSource.MySQL &&
                                _datasetManager.DataSource != DataSource.MSSQL &&
                                _datasetManager.DataSource != DataSource.Oracle)
                            {
                                MessageBox.Show("Data of the action have to come from database.");
                                return;
                            }

                            txtResult.Text = _schemaService.GenerateClassWithoutSummary(_schemaService.GetTableSchema(_datasetManager.Category, _datasetManager.ConnectionType ?? throw new ArgumentException("ConnectionType can't be null"), txtScript.Text, txtClassName.Text), _datasetManager.Namespace, _datasetManager.Using, $"{txtClassName.Text}{_datasetManager.ClassSuffix}");
                            break;
                        case nameof(btnAllTables):

                            FolderBrowserDialog dlg = new FolderBrowserDialog();
                            dlg.Reset();
                            dlg.RootFolder = Environment.SpecialFolder.MyComputer;
                            dlg.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                            if (dlg.ShowDialog() == DialogResult.OK)
                            {
                                var filePath = dlg.SelectedPath;
                                Parallel.For(0, _datasetManager!.Dataset!.Tables[Consts.strTables]!.Rows.Count, (i) =>
                                {
                                    var item = _datasetManager!.Dataset!.Tables[Consts.strTables]!.Rows[i];
                                    var tableName = item["TableName"].ToString();
                                    var script = $"SELECT * FROM {tableName}";
                                    var classBody = _schemaService.GenerateClassWithSummary(_datasetManager.Dataset.Tables[Consts.strColumns]!, _datasetManager.Namespace, _datasetManager.Using, $"{tableName}{_datasetManager.ClassSuffix}", script);
                                    _fileService.SaveStringFileAsync($"{Path.Combine(filePath, tableName + _datasetManager.ClassSuffix + ".cs")}", classBody);
                                });

                                MessageBox.Show("Files saved.");
                            }
                            break;
                        case nameof(btnClassAssign):
                            if (txtClassName.Text == "")
                            {
                                txtClassName.Focus();
                                MessageBox.Show("Please type in a class name..");
                                return;
                            }
                            if (_datasetManager.DataSource != DataSource.MySQL &&
                                _datasetManager.DataSource != DataSource.MSSQL &&
                                _datasetManager.DataSource != DataSource.Oracle)
                            {
                                MessageBox.Show("Data of the action have to come from database.");
                                return;
                            }
                            var dtTables = _schemaService.GetTableSchema(_datasetManager.Category, _datasetManager.ConnectionType ?? throw new ArgumentException("ConnectionType can't be null"), txtScript.Text, $"{txtClassName.Text}{_datasetManager.ClassSuffix}");
                            txtResult.Text = _schemaService.GenerateClassAssign(dtTables);
                            break;
                        case nameof(btnSelect): txtResult.Text = _schemaService.GenerateDapperScript(_datasetManager.Dataset!.Tables[Consts.strColumns]!, tableName, ScriptKind.Select, (ParameterType)cboParameterType.SelectedValue!, txtParameterObjName.Text); break;
                        case nameof(btnInsert): txtResult.Text = _schemaService.GenerateDapperScript(_datasetManager.Dataset!.Tables[Consts.strColumns]!, tableName, ScriptKind.Insert, (ParameterType)cboParameterType.SelectedValue!, txtParameterObjName.Text); break;
                        case nameof(btnUpdate): txtResult.Text = _schemaService.GenerateDapperScript(_datasetManager.Dataset!.Tables[Consts.strColumns]!, tableName, ScriptKind.Update, (ParameterType)cboParameterType.SelectedValue!, txtParameterObjName.Text); break;
                        case nameof(btnDelete): txtResult.Text = _schemaService.GenerateDapperScript(_datasetManager.Dataset!.Tables[Consts.strColumns]!, tableName, ScriptKind.Delete, (ParameterType)cboParameterType.SelectedValue!, txtParameterObjName.Text); break;
                        default:
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Please load data first.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmPOCO_KeyDown(object sender, KeyEventArgs e)
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
                var filterString = "";
                var i = 0;
                foreach (var filter in filters)
                {
                    if (!string.IsNullOrEmpty(filter))
                    {
                        filterString += i == 0 ? "TableName LIKE '%" + filter + "%'" : " OR TableName LIKE '%" + filter + "%'";
                        i++;
                    }
                };
                ((DataView)cmTables.List).RowFilter = filterString;
            }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (((DataGridView)sender).Name)
            {
                case "dgvTables":
                    if (cmTables.Position != -1)
                    {
                        string tableName = ((DataRowView)cmTables.Current)["TableName"].ToString()!;
                        txtClassName.Text = tableName!;
                        txtScript.Text = $"SELECT * FROM {tableName}";
                    }
                    break;
                default:
                    MessageBox.Show("Not implement yet.");
                    break;
            }

        }
    }
}
