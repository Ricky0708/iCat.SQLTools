﻿using iCat.SQLTools.Models;
using iCat.SQLTools.Repositories.Implements;
using iCat.SQLTools.Services.Interfaces;
using iCat.SQLTools.Services.Managers;
using iCat.SQLTools.Shareds.Enums;
using Microsoft.IdentityModel.Tokens;
using NPOI.OpenXmlFormats.Spreadsheet;
using Org.BouncyCastle.Tls.Crypto.Impl.BC;
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
    public partial class frmPOCO : frmBase
    {
        ////DAL.DALPOCOGenerator objDAL = new DAL.DALPOCOGenerator();
        ////DAL.DALClassModelGenerator objDAL2 = new DAL.DALClassModelGenerator();
        ////ShareUtility objUti = new ShareUtility();
        //DataTable dtScript;
        //CurrencyManager cmTables;
        //CurrencyManager cmScripts;
        //CurrencyManager cmSPAndFuncs;
        //private readonly DatasetManager _datasetManager;
        //private readonly SettingConfig _settingConfig;
        //private readonly IFileService _fileService;
        //private readonly ISchemaService _schemaService;

        //public frmPOCO(
        //    DatasetManager datasetManager,
        //    SettingConfig settingConfig,
        //    IFileService fileService,
        //    ISchemaService schemaService
        //    )
        //{
        //    InitializeComponent();
        //    dgvTables.AutoGenerateColumns = false;
        //    dgvSpsAndFuncs.AutoGenerateColumns = false;
        //    dtScript = new DataTable("Scripts");
        //    dtScript.Columns.Add("ScriptName");
        //    dtScript.Columns.Add("Script");
        //    dtScript.Columns.Add("cmd");
        //    dgvScripts.DataSource = dtScript;
        //    cmScripts = (CurrencyManager)this.BindingContext[dtScript];
        //    _datasetManager = datasetManager ?? throw new ArgumentNullException(nameof(datasetManager));
        //    _settingConfig = settingConfig ?? throw new ArgumentNullException(nameof(settingConfig));
        //    _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
        //    _schemaService = schemaService ?? throw new ArgumentNullException(nameof(schemaService));
        //    //tableLayoutPanel1.SetColumnSpan(btnAllTables, 2);
        //    //Button btnAddScript = new Button();
        //    //btnAddScript.Name = "btnAddScript";
        //    //btnAddScript.Text = "＋";
        //    //btnAddScript.Dock = DockStyle.Right;
        //    //btnAddScript.Size = new Size(30, 30);
        //    //btnAddScript.Cursor = Cursors.Default;
        //}

        //private void frmPOCOGenrator_Load(object sender, EventArgs e)
        //{

        //    if (_datasetManager.DataSource != DataSource.None && _datasetManager.Dataset != null)
        //    {
        //        dgvTables.Focus();
        //        dgvTables.DataSource = _datasetManager.Dataset;
        //        dgvTables.DataMember = "Tables";
        //        dgvSpsAndFuncs.DataSource = _datasetManager.Dataset;
        //        dgvSpsAndFuncs.DataMember = "SpsAndFuncs";
        //        cmTables = (CurrencyManager)this.BindingContext![_datasetManager.Dataset, "Tables"];
        //        cmSPAndFuncs = (CurrencyManager)this.BindingContext[_datasetManager.Dataset, "SpsAndFuncs"];
        //        ((DataView)cmTables.List).RowFilter = "TableName LIKE '%" + txtTableFilter.Text + "%'";
        //        ((DataView)cmSPAndFuncs.List).RowFilter = "SPECIFIC_NAME LIKE '%" + txtSpFilter.Text + "%'";
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please load data first.");
        //    }

        //}

        //private void btn_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (_datasetManager?.Dataset?.Tables[Consts.strTables] != null)
        //        {
        //            switch (((Button)sender).Name)
        //            {
        //                case nameof(btnWithComment):
        //                    if (txtClassName.Text == "")
        //                    {
        //                        txtClassName.Focus();
        //                        MessageBox.Show("Please type in a class name..");
        //                    }
        //                    txtResult.Text = _schemaService.GenerateClassWithSummary(_datasetManager.Dataset.Tables[Consts.strColumns]!, _settingConfig.Namespace, _settingConfig.Using, $"{txtClassName.Text}{_settingConfig.ClassSuffix}", txtScript.Text);
        //                    break;
        //                case nameof(btnWithoutComment):
        //                    if (txtClassName.Text == "")
        //                    {
        //                        txtClassName.Focus();
        //                        MessageBox.Show("Please type in a class name..");
        //                        return;
        //                    }
        //                    if (_datasetManager.DataSource != DataSource.MySQL &&
        //                        _datasetManager.DataSource != DataSource.MSSQL)
        //                    {
        //                        MessageBox.Show("Data of the action have to come from database.");
        //                        return;
        //                    }

        //                    txtResult.Text = _schemaService.GenerateClassWithoutSummary(_schemaService.GetTableSchema(txtScript.Text, txtClassName.Text), _settingConfig.Namespace, _settingConfig.Using, $"{txtClassName.Text}{_settingConfig.ClassSuffix}");
        //                    break;
        //                case nameof(btnAllTables):

        //                    FolderBrowserDialog dlg = new FolderBrowserDialog();
        //                    dlg.Reset();
        //                    dlg.RootFolder = Environment.SpecialFolder.MyComputer;
        //                    dlg.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        //                    if (dlg.ShowDialog() == DialogResult.OK)
        //                    {
        //                        var filePath = dlg.SelectedPath;
        //                        Parallel.For(0, _datasetManager!.Dataset!.Tables[Consts.strTables]!.Rows.Count, (i) =>
        //                        {
        //                            var item = _datasetManager!.Dataset!.Tables[Consts.strTables]!.Rows[i];
        //                            var tableName = item["TableName"].ToString();
        //                            var script = $"SELECT * FROM {tableName}";
        //                            var classBody = _schemaService.GenerateClassWithSummary(_datasetManager.Dataset.Tables[Consts.strColumns]!, _settingConfig.Namespace, _settingConfig.Using, $"{tableName}{_settingConfig.ClassSuffix}", script);
        //                            _fileService.SaveStringFileAsync($"{Path.Combine(filePath, tableName + _settingConfig.ClassSuffix + ".cs")}", classBody);
        //                        });

        //                        MessageBox.Show("Files saved.");
        //                    }
        //                    break;
        //                case nameof(btnClassAssign):
        //                    if (txtClassName.Text == "")
        //                    {
        //                        txtClassName.Focus();
        //                        MessageBox.Show("Please type in a class name..");
        //                        return;
        //                    }
        //                    if (_datasetManager.DataSource != DataSource.MySQL &&
        //                        _datasetManager.DataSource != DataSource.MSSQL)
        //                    {
        //                        MessageBox.Show("Data of the action have to come from database.");
        //                        return;
        //                    }
        //                    var dtTables = _schemaService.GetTableSchema(txtScript.Text, $"{txtClassName.Text}{_settingConfig.ClassSuffix}");
        //                    txtResult.Text = _schemaService.GenerateClassAssign(dtTables);
        //                    break;
        //                default:
        //                    break;
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Please load data first.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void frmPOCO_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Control && e.KeyCode == Keys.F)
        //    {
        //        txtTableFilter.Focus();
        //    }
        //}

        //private void txt_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Control && e.KeyCode == Keys.A)
        //    {
        //        if (sender != null)
        //            ((TextBox)sender).SelectAll();
        //    }
        //}

        //private void txtTableFilter_TextChanged(object sender, EventArgs e)
        //{
        //    if (cmTables != null)
        //    {
        //        var filters = txtTableFilter.Text.Split(',');
        //        var filterString = "";
        //        var i = 0;
        //        foreach (var filter in filters)
        //        {
        //            if (!string.IsNullOrEmpty(filter))
        //            {
        //                filterString += i == 0 ? "TableName LIKE '%" + filter + "%'" : " OR TableName LIKE '%" + filter + "%'";
        //                i++;
        //            }
        //        };
        //        ((DataView)cmTables.List).RowFilter = filterString;
        //    }
        //}

        //private void txtSpFilter_TextChanged(object sender, EventArgs e)
        //{
        //    if (cmSPAndFuncs != null)
        //    {
        //        ((DataView)cmSPAndFuncs.List).RowFilter = "SPECIFIC_NAME LIKE '%" + txtSpFilter.Text + "%'";
        //    }
        //}

        //private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    switch (((DataGridView)sender).Name)
        //    {
        //        case "dgvTables":
        //            if (cmTables.Position != -1)
        //            {
        //                string tableName = ((DataRowView)cmTables.Current)["TableName"].ToString()!;
        //                txtClassName.Text = tableName!;
        //                txtScript.Text = $"SELECT * FROM {tableName}";
        //            }
        //            break;
        //        case "dgvSpsAndFuncs":
        //        //if (cmTables.Position != -1)
        //        //{
        //        //    string spName = ((DataRowView)cmSPAndFuncs.Current)["SPECIFIC_NAME"].ToString();
        //        //    txtClassName.Text = spName;
        //        //    //txtResult.Text = objDAL.GeneratePOCOFromSP(spName);
        //        //}
        //        //break;
        //        case "dgvScripts":
        //        //if (cmScripts.Position != -1)
        //        //{
        //        //    if (dgvScripts.Columns[e.ColumnIndex].Name == "dScriptName")
        //        //    {
        //        //        txtClassName.Text = ((DataRowView)cmScripts.Current)["ScriptName"].ToString();
        //        //        txtScript.Text = ((DataRowView)cmScripts.Current)["Script"].ToString();
        //        //    }
        //        //    else if (dgvScripts.Columns[e.ColumnIndex].Name == "dCmd")
        //        //    {
        //        //        ((DataRowView)cmScripts.Current).Delete();
        //        //        cmScripts.EndCurrentEdit();
        //        //        dtScript.AcceptChanges();
        //        //    }

        //        //}
        //        //break;
        //        default:
        //            MessageBox.Show("Not implement yet.");
        //            break;
        //    }

        //}
    }
}
