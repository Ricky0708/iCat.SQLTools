using iCat.DB.Client.Factory.Interfaces;
using iCat.SQLTools.Models;
using iCat.SQLTools.Repositories.Enums;
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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZstdSharp.Unsafe;
using static ICSharpCode.SharpZipLib.Zip.ExtendedUnixData;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace iCat.SQLTools.Forms
{
    public partial class frmTables : frmBase
    {
        CurrencyManager bmTables;
        CurrencyManager bmSps;
        CurrencyManager bmSetting;
        ConnectionSetting? _connectionSetting => bmSetting?.Current != null ? (ConnectionSetting)bmSetting.Current : null;

        DataView _dvFks;
        private readonly SettingConfig _config;
        private readonly IServiceProvider _provider;
        private readonly IFileService _fileService;
        private DatasetManagerFactory _datasetManagerFactory;


        public frmTables(
            SettingConfig config,
            IServiceProvider provider,
            IFileService fileService,
            DatasetManagerFactory datasetManagerFactory
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
            _datasetManagerFactory = datasetManagerFactory ?? throw new ArgumentNullException(nameof(datasetManagerFactory));

            //var a = new BindingSource() { DataSource = _config.ConnectionSettings };
            bmSetting = (CurrencyManager)this.BindingContext[_config.ConnectionSettings];

            cboSettingKey.DataSource = _config.ConnectionSettings;
            cboSettingKey.DisplayMember = "Key";
            cboSettingKey.ValueMember = "Key";

        }

        #region Event Button SQL

        private void btnLoadDataFromSQL_Click(object sender, EventArgs e)
        {
            try
            {
                var service = _provider.GetRequiredService<ISchemaService>();
                var datasetManager = new DatasetManager();
                var key = _connectionSetting!.Key;
                switch (_connectionSetting!.ConnectionType)
                {
                    case ConnectionType.MSSQL: datasetManager.DataSource = Shareds.Enums.DataSource.MSSQL; break;
                    case ConnectionType.MySQL: datasetManager.DataSource = Shareds.Enums.DataSource.MySQL; break;
                    default: throw new Exception("Unknow dbType");
                }
                datasetManager.Dataset = service.GetDatasetFromDB(_connectionSetting.Key, _connectionSetting.ConnectionType);
                _datasetManagerFactory.AddDatasetManager(_connectionSetting.Key, datasetManager.DataSource, datasetManager.Dataset);
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
            var datasetManager = _datasetManagerFactory.GetDatasetManager(_connectionSetting!.Key)!;
            if (datasetManager.DataSource == Shareds.Enums.DataSource.XML)
            {
                MessageBox.Show("This command only for load data from SQL !");
                return;
            }
            if (datasetManager.Dataset != null)
            {
                var service = _provider.GetRequiredService<ISchemaService>();
                var conn = _provider.GetRequiredService<IUnitOfWorkFactory>().GetUnitOfWork(_connectionSetting.Key);
                try
                {
                    conn.Open();
                    conn.BeginTransaction();
                    if (!service.UpdateDescription(_connectionSetting.Key, _connectionSetting.ConnectionType, datasetManager.Dataset))
                    {
                        MessageBox.Show("Fail!");
                    }
                    else
                    {
                        MessageBox.Show("Success！");
                        conn.Commit();
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    conn.Rollback();
                    conn.Close();
                }
            }
            else
            {
                MessageBox.Show("Please load data from SQL and modify it, befor you update to SQL !");
            }


        }

        private void btnUpdateAllDescription_Click(object sender, EventArgs e)
        {

            var datasetManager = _datasetManagerFactory.GetDatasetManager(_connectionSetting!.Key)!;
            var service = _provider.GetRequiredService<ISchemaService>();
            if (datasetManager.Dataset != null)
            {
                if (MessageBox.Show(this, "It will update and cover all current description to SQL ! \r\r Are you sure to do it ?", "Info", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach (DataTable dt in datasetManager.Dataset.Tables)
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
                    var conn = _provider.GetRequiredService<IUnitOfWorkFactory>().GetUnitOfWork(_connectionSetting.Key);
                    try
                    {
                        conn.Open();
                        conn.BeginTransaction();
                        if (!service.UpdateDescription(_connectionSetting.Key, _connectionSetting.ConnectionType, datasetManager.Dataset))
                        {
                            string msg = "\r\n\r\n";
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
                            conn.Commit();
                            conn.Close();
                            MessageBox.Show("Success！");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        conn.Rollback();
                        conn.Close();
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
            var datasetManager = _datasetManagerFactory.GetDatasetManager(_connectionSetting!.Key)!;
            var fileName = GetFileName();
            if (fileName != "")
            {
                using (var sr = new StreamReader(fileName))
                {
                    var xml = sr.ReadToEnd();
                    var service = _provider.GetRequiredService<ISchemaService>();
                    datasetManager.Dataset = service.GetDatasetFromXml(xml);
                    datasetManager.DataSource = Shareds.Enums.DataSource.XML;
                    BindFrm();
                    tabControl1.SelectedTab = tabTablesAndCols;
                    this.Parent!.Text = "Tables-『" + fileName.Substring(fileName.LastIndexOf("\\") + 1) + "』";
                }
            }
        }

        private void btnSaveToXml_Click(object sender, EventArgs e)
        {
            var datasetManager = _datasetManagerFactory.GetDatasetManager(_connectionSetting!.Key);
            if (datasetManager?.Dataset != null)
            {
                var defRoot = Path.Combine(Application.StartupPath, "database");
                var extensionName = "Xml";
                var fileName = SetFileName(defRoot, "Db", extensionName);

                if (fileName != "")
                {
                    var service = _provider.GetRequiredService<ISchemaService>();
                    if (_datasetManagerFactory.SaveToXml(_connectionSetting.Key, fileName))
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
            var datasetManager = _datasetManagerFactory.GetDatasetManager(_connectionSetting!.Key);
            if (datasetManager?.Dataset != null)
            {
                NpoiOperator objNpoi = new NpoiOperator(datasetManager.Dataset);
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

        #region method

        private void BindFrm()
        {
            var datasetManager = _datasetManagerFactory.GetDatasetManager(_connectionSetting!.Key)!;
            dgvTables.DataSource = datasetManager.Dataset;
            dgvTables.DataMember = "Tables";

            dgvColumns.DataSource = datasetManager.Dataset;
            dgvColumns.DataMember = "Tables.MasterDetailCols";

            _dvFks = datasetManager.Dataset.Tables["FKs"].DefaultView;
            dgvFK.DataSource = _dvFks;

            dgvIndexes.DataSource = datasetManager.Dataset;
            dgvIndexes.DataMember = "Tables.MasterDetailIndexes";

            dgvSpsAndFuncs.DataSource = datasetManager.Dataset;
            dgvSpsAndFuncs.DataMember = "SpsAndFuncs";

            dgvInputParams.DataSource = datasetManager.Dataset;
            dgvInputParams.DataMember = "SpsAndFuncs.MasterDetailInputParams";

            dgvOutPutParams.DataSource = datasetManager.Dataset;
            dgvOutPutParams.DataMember = "SpsAndFuncs.MasterDetailOutputParams";

            bmTables = (CurrencyManager)this.BindingContext[datasetManager.Dataset, "Tables"];
            bmSps = (CurrencyManager)this.BindingContext[datasetManager.Dataset, "SpsAndFuncs"];

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
                ((DataView)bmTables.List).RowFilter = filterString;
            }

            if (bmSps != null)
            {
                var filters = txtTableFilter.Text.Split(',');
                var filterString = "";
                var i = 0;
                foreach (var filter in filters)
                {
                    if (!string.IsNullOrEmpty(filter))
                    {
                        filterString += i == 0 ? "SPECIFIC_NAME LIKE '%" + filter + "%'" : " OR SPECIFIC_NAME LIKE '%" + filter + "%'";
                        i++;
                    }
                };
                //((DataView)bmSps.List).RowFilter = "SPECIFIC_NAME LIKE '%" + txtSpFilter.Text + "%'";
                ((DataView)bmSps.List).RowFilter = filterString;
            }

        }

        #endregion
    }
}
