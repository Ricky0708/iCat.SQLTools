using iCat.SQLTools.enums;
using iCat.SQLTools.Models;
using iCat.SQLTools.Services.Interfaces;
using iCat.SQLTools.Shareds;
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
using static Org.BouncyCastle.Math.EC.ECCurve;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace iCat.SQLTools.Forms
{
    public partial class frmConfigSettingDlg : Form
    {
        private readonly IFileService _fileService;
        private readonly SettingConfig _config;

        public frmConfigSettingDlg(IFileService fileService, SettingConfig config)
        {
            InitializeComponent();
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
            _config = config ?? throw new ArgumentNullException(nameof(config));


            txtConnectionString.Text = config.ConnectionSetting.ConnectionString;
            txtUsing.Text = config.Using;
            txtNamespace.Text = config.Namespace;

            var connectionTypes = ((ConnectionType[])Enum.GetValues(typeof(ConnectionType)))
                .Select(p => new
                {
                    Name = p.ToString(),
                    Value = p
                }).ToList();

            cboConnectionType.DataSource = connectionTypes;
            cboConnectionType.DisplayMember = "Name";
            cboConnectionType.ValueMember = "Value";

            cboConnectionType.SelectedValue = config.ConnectionSetting.ConnectionType;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to save it ?", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                _config.ConnectionSetting.ConnectionString = txtConnectionString.Text;
                _config.ConnectionSetting.ConnectionType = (ConnectionType)cboConnectionType.SelectedValue!;
                _config.Using = txtUsing.Text;
                _config.Namespace = txtNamespace.Text;
                var data = JsonUtil.Serialize(_config);
                _fileService.SaveStringFileAsync("settingConfig.json", data);
                MessageBox.Show("Success!");
                this.Close();
            }
        }
    }
}
