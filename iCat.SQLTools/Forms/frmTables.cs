﻿using iCat.SQLTools.Models;
using iCat.SQLTools.Repositories.Implements;
using iCat.SQLTools.Services.Interfaces;
using iCat.SQLTools.Services.Managers;
using iCat.SQLTools.Shareds;
using iCat.SQLTools.Shareds.Shareds;
using Microsoft.Extensions.DependencyInjection;
using Org.BouncyCastle.Utilities.Zlib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ICSharpCode.SharpZipLib.Zip.ExtendedUnixData;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace iCat.SQLTools.Forms
{
    public partial class frmTables : frmBase
    {
        CurrencyManager bmTables;
        CurrencyManager bmSps;

        DataView _dvFks;
        private readonly SettingConfig _config;
        private readonly IServiceProvider _provider;
        private readonly IFileService _fileService;
        private DatasetManager _datasetManager;

        public frmTables(
            SettingConfig config,
            IServiceProvider provider,
            IFileService fileService,
            DatasetManager datasetManager
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
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
            _datasetManager = datasetManager ?? throw new ArgumentNullException(nameof(datasetManager));
        }

        #region method

        private void BindFrm()
        {
            dgvTables.DataSource = _datasetManager.Dataset;
            dgvTables.DataMember = "Tables";

            dgvColumns.DataSource = _datasetManager.Dataset;
            dgvColumns.DataMember = "Tables.MasterDetailCols";

            _dvFks = _datasetManager.Dataset.Tables["FKs"].DefaultView;
            dgvFK.DataSource = _dvFks;

            dgvIndexes.DataSource = _datasetManager.Dataset;
            dgvIndexes.DataMember = "Tables.MasterDetailIndexes";

            dgvSpsAndFuncs.DataSource = _datasetManager.Dataset;
            dgvSpsAndFuncs.DataMember = "SpsAndFuncs";

            dgvInputParams.DataSource = _datasetManager.Dataset;
            dgvInputParams.DataMember = "SpsAndFuncs.MasterDetailInputParams";

            dgvOutPutParams.DataSource = _datasetManager.Dataset;
            dgvOutPutParams.DataMember = "SpsAndFuncs.MasterDetailOutputParams";

            bmTables = (CurrencyManager)this.BindingContext[_datasetManager.Dataset, "Tables"];
            bmSps = (CurrencyManager)this.BindingContext[_datasetManager.Dataset, "SpsAndFuncs"];

            bmTables.PositionChanged += (sender, e) =>
            {
                if (bmTables.Position != -1)
                {
                    string tableName = ((DataRowView)bmTables.Current)["TableName"].ToString();
                    _dvFks.RowFilter = "ParentTable = '" + tableName + "' OR ReferencedTable = '" + tableName + "'";
                    dColDescription.ReadOnly = ((DataRowView)bmTables.Current)["TableType"].ToString() == "VIEW";
                }
            };
            _dvFks.RowFilter = "ParentTable = '" + ((DataRowView)bmTables.Current)["TableName"].ToString() + "' OR ReferencedTable = '" + ((DataRowView)bmTables.Current)["TableName"].ToString() + "'";
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
            try
            {
                var service = _provider.GetRequiredService<ISchemaService>();
                switch (_config.ConnectionSetting.ConnectionType)
                {
                    case Shareds.Enums.ConnectionType.MSSQL: _datasetManager.DatasetFromType = Shareds.Enums.DatasetFromType.MSSQL; break;
                    case Shareds.Enums.ConnectionType.MySQL: _datasetManager.DatasetFromType = Shareds.Enums.DatasetFromType.MySQL; break;
                    default: throw new Exception("Unknow dbType");
                }
                _datasetManager.Dataset = service.GetDatasetFromDB();
                BindFrm();
                tabControl1.SelectedTab = tabTablesAndCols;
                this.Parent!.Text = "Tables-『SQL』";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            var fileName = GetFileName();
            if (fileName != "")
            {
                using (var sr = new StreamReader(fileName))
                {
                    var xml = sr.ReadToEnd();
                    var service = _provider.GetRequiredService<ISchemaService>();
                    _datasetManager.Dataset = service.GetDatasetFromXml(xml);
                    _datasetManager.DatasetFromType = Shareds.Enums.DatasetFromType.XML;
                    BindFrm();
                    tabControl1.SelectedTab = tabTablesAndCols;
                    this.Parent!.Text = "Tables-『" + fileName.Substring(fileName.LastIndexOf("\\") + 1) + "』";
                }
            }
        }

        private void btnSaveToXml_Click(object sender, EventArgs e)
        {
            if (_datasetManager.Dataset != null)
            {
                var defRoot = Path.Combine(Application.StartupPath, "database");
                var extensionName = "Xml";
                var fileName = SetFileName(defRoot, "Db", extensionName);

                if (fileName != "")
                {
                    var service = _provider.GetRequiredService<ISchemaService>();
                    if (service.SaveToXml(_datasetManager.Dataset, fileName))
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
            if (_datasetManager.Dataset != null)
            {
                NpoiOperator objNpoi = new NpoiOperator(_datasetManager.Dataset);
                string fileName = SetFileName(Application.StartupPath + "\\database\\", "Db_Schema", "xlsx");
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

        #region private method

        public string GetFileName()
        {
            string filePath = Path.Combine(Application.StartupPath, "database");
            SetFolderExists(filePath);
            string fileName = "";
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = "xml";
            dlg.Filter = "xml file|*.xml";
            dlg.InitialDirectory = filePath;
            if (dlg.ShowDialog() == DialogResult.OK)
            {

                fileName = dlg.FileName;
            }
            return fileName;
        }

        public string SetFileName(string defRoot, string defName, string extensionName)
        {
            string fileName = "";
            string filePath = defRoot;
            SetFolderExists(filePath);
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.DefaultExt = extensionName;
            saveDlg.InitialDirectory = filePath;
            saveDlg.FileName = defName + "." + extensionName;
            saveDlg.Filter = extensionName + " file|*." + extensionName;

            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                fileName = saveDlg.FileName;
            }
            return fileName;
        }

        public void SetFolderExists(string filePath)
        {
            DirectoryInfo di = new DirectoryInfo(filePath);
            if (!di.Exists)
            {
                di.Create();
            }
        }

        #endregion
    }
}