using iCat.SQLTools.Models;
using iCat.SQLTools.Repositories.Enums;
using iCat.SQLTools.Services.Implements;
using iCat.SQLTools.Services.Interfaces;
using iCat.SQLTools.Shareds;
using iCat.SQLTools.Shareds.Enums;
using iCat.SQLTools.Shareds.Shareds;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static iCat.SQLTools.Forms.frmConfigSettingDlg;
using static Org.BouncyCastle.Math.EC.ECCurve;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace iCat.SQLTools.Forms
{
    public partial class frmConfigSettingDlg : Form
    {
        public delegate bool LoadData(ConnectionSetting setting);
        public event LoadData OnLoadData;
        public delegate void DataLoaded(int count);
        public event DataLoaded OnDataLoaded;
        public delegate bool SaveSettings(string configJson);
        public event SaveSettings OnSaveSettings;


        private readonly SettingConfig _config;
        private CurrencyManager _bmSetting;
        private bool _isLoadingData = false;

        public frmConfigSettingDlg(SettingConfig config)
        {
            InitializeComponent();
            _config = config ?? throw new ArgumentNullException(nameof(config));
            config.ConnectionSettings = config.ConnectionSettings.OrderBy(p => p.SEQ).ToList();
            dgvSettings.AutoGenerateColumns = false;
            dgvSettings.RowHeadersVisible = false;
            dgvSettings.DataSource = config.ConnectionSettings;
            _bmSetting = (CurrencyManager)this.BindingContext[config.ConnectionSettings];

            this.txtKey.DataBindings.Add(new Binding("Text", config.ConnectionSettings, "Key"));
            this.txtClassSuffix.DataBindings.Add(new Binding("Text", config.ConnectionSettings, "ClassSuffix"));
            this.txtConnectionString.DataBindings.Add(new Binding("Text", config.ConnectionSettings, "ConnectionString"));
            this.txtNamespace.DataBindings.Add(new Binding("Text", config.ConnectionSettings, "Namespace"));
            this.txtUsing.DataBindings.Add(new Binding("Text", config.ConnectionSettings, "Using"));
            this.txtSeq.DataBindings.Add(new Binding("Text", config.ConnectionSettings, "SEQ"));
            //txtConnectionString.Text = config.ConnectionSetting.ConnectionString;
            //txtUsing.Text = config.Using;
            //txtNamespace.Text = config.Namespace;
            //txtClassSuffix.Text = config.ClassSuffix;

            var connectionTypes = ((ConnectionType[])Enum.GetValues(typeof(ConnectionType)))
                .Select(p => new
                {
                    Name = p.ToString(),
                    Value = p
                }).ToList();

            cboConnectionType.DataSource = connectionTypes;
            cboConnectionType.DisplayMember = "Name";
            cboConnectionType.ValueMember = "Value";

            cboConnectionType.DataBindings.Add("SelectedValue", config.ConnectionSettings, "ConnectionType");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to save it ?", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                var data = JsonUtil.Serialize(_config);
                if (OnSaveSettings?.Invoke(data) ?? false)
                {
                    MessageBox.Show("Success!");
                    this.Close();
                };
                //_fileService.SaveStringFileAsync("settingConfig.json", data);
                //_provider.SetNewDbClient(_config.ConnectionSetting.ConnectionType, _config.ConnectionSetting.ConnectionString);

            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            _config.ConnectionSettings.Add(new ConnectionSetting
            {
                ClassSuffix = "",
                ConnectionString = "",
                ConnectionType = ConnectionType.MSSQL,
                Key = "",
                Namespace = "",
                Using = "",
                SEQ = _config.ConnectionSettings.OrderBy(p => p.SEQ).Last().SEQ + 1
            });
            _bmSetting.Refresh();
            _bmSetting.Position = _config.ConnectionSettings.Count() - 1;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _config.ConnectionSettings.RemoveAt(_bmSetting.Position);
            _bmSetting.Refresh();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            var processedCount = 0;
            var processingCount = 0;
            var total = 0;
            var locker = new object();
            var tasks = new List<Task>();
            Parallel.For(0, dgvSettings.Rows.Count, i =>
            {
                var row = dgvSettings.Rows[i];
                var cell = row.Cells[nameof(dSelected)]!;
                var isChecked = cell.Value?.ToString() == "1";
                if (isChecked)
                {
                    lock (locker)
                    {
                        ++total;
                    }
                };
            });

            if (total > 0)
            {
                _isLoadingData = true;
                btnAddNew.Enabled = !_isLoadingData;
                btnDelete.Enabled = !_isLoadingData;
                btnLoadData.Enabled = !_isLoadingData;
                btnSave.Enabled = !_isLoadingData;
                lblLoadingResult.Visible = _isLoadingData;
            }

            var exceptions = new List<Exception>();
            for (int i = 0; i < dgvSettings.Rows.Count; i++)
            {
                var row = dgvSettings.Rows[i];
                var cell = row.Cells[nameof(dSelected)]!;
                var isChecked = cell.Value?.ToString() == "1";
                if (isChecked)
                {
                    LoadingProcess(++processingCount, processedCount, total, exceptions);

                    var task = Task.Run(() =>
                    {
                        try
                        {
                            OnLoadData?.Invoke((ConnectionSetting)row.DataBoundItem);
                        }
                        catch (Exception ex)
                        {
                            exceptions.Add(ex);
                        }
                        finally
                        {
                            lock (locker)
                            {
                                LoadingProcess(--processingCount, ++processedCount, total, exceptions);
                            }
                        }


                    });
                    tasks.Add(task);
                }
            }


            //Task.WhenAll(tasks).Wait();
            //Parallel.For(0, dgvSettings.Rows.Count, i =>
            //{
            //    var row = dgvSettings.Rows[i];
            //    var cell = row.Cells[nameof(dSelected)]!;
            //    var isChecked = cell.Value?.ToString() == "1";
            //    lock (locker)
            //    {
            //        LoadingProcess(++processingCount, processedCount, total);
            //    }
            //    if (isChecked && (OnLoadData?.Invoke((ConnectionSetting)row.DataBoundItem) ?? false))
            //    {
            //        lock (locker)
            //        {
            //            LoadingProcess(--processingCount, ++processedCount, total);
            //        }
            //    };
            //});
            //lblLoadingResult.Visible = false;
        }

        private void LoadingProcess(int processingCount, int processedCount, int total, List<Exception> exceptions)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(LoadingProcess, processingCount, processedCount, total, exceptions);
            }
            else
            {
                lblLoadingResult.Text = $"{processingCount}/{processedCount}/{total}";
                if (processedCount == total)
                {
                    OnDataLoaded?.Invoke(processedCount - exceptions.Count);
                    _isLoadingData = false;
                    btnAddNew.Enabled = !_isLoadingData;
                    btnDelete.Enabled = !_isLoadingData;
                    btnLoadData.Enabled = !_isLoadingData;
                    btnSave.Enabled = !_isLoadingData;
                    lblLoadingResult.Visible = _isLoadingData;
                    if (exceptions.Count > 0)
                    {
                        MessageBox.Show(string.Join("\r\n", exceptions.Select(p => p.Message)));
                    }
                }
            }
        }

        private void frmConfigSettingDlg_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = _isLoadingData;
        }
    }
}
