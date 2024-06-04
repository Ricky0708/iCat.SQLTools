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
        public delegate bool SaveSettings(string configJson);
        public event SaveSettings OnSaveSettings;


        private readonly SettingConfig _config;
        private CurrencyManager _bmSetting;

        public frmConfigSettingDlg(SettingConfig config)
        {
            InitializeComponent();
            _config = config ?? throw new ArgumentNullException(nameof(config));

            dgvSettings.AutoGenerateColumns = false;
            dgvSettings.DataSource = config.ConnectionSettings;
            _bmSetting = (CurrencyManager)this.BindingContext[config.ConnectionSettings];

            this.txtKey.DataBindings.Add(new Binding("Text", config.ConnectionSettings, "Key"));
            this.txtClassSuffix.DataBindings.Add(new Binding("Text", config.ConnectionSettings, "ClassSuffix"));
            this.txtConnectionString.DataBindings.Add(new Binding("Text", config.ConnectionSettings, "ConnectionString"));
            this.txtNamespace.DataBindings.Add(new Binding("Text", config.ConnectionSettings, "Namespace"));
            this.txtUsing.DataBindings.Add(new Binding("Text", config.ConnectionSettings, "Using"));
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
                ClassSuffix = "Suffix",
                ConnectionString = "Connection",
                ConnectionType = ConnectionType.MSSQL,
                Key = "Key",
                Namespace = "Namespace",
                Using = "Using"
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
            if (OnLoadData?.Invoke((ConnectionSetting)_bmSetting.Current) ?? false)
            {
                MessageBox.Show("Success!");
                this.Close();
            };
        }
    }
}
