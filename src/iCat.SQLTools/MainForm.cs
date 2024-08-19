using iCat.SQLTools.CustomControlleres;
using iCat.SQLTools.Forms;
using iCat.SQLTools.Models;
using iCat.SQLTools.Services.Interfaces;
using iCat.SQLTools.Services.Managers;
using iCat.SQLTools.Shareds;
using iCat.SQLTools.Shareds.Shareds;
using Microsoft.Extensions.DependencyInjection;
using NPOI.SS.Util;
using System.ComponentModel;
using System.Reflection;
using System.Text.Json;
using System.Windows.Forms;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace iCat.SQLTools
{
    public partial class MainForm : Form
    {
        private readonly IFileService _fileService;
        private readonly SettingConfig _config;
        private readonly DatasetManagerFactory _datasetManagerFactory;
        private readonly IServiceProvider _provider;
        private CurrencyManager _bmDatasetManager;
        private BindingSource _bindingSource = new BindingSource();
        public MainForm(IFileService fileService, SettingConfig config, DatasetManagerFactory datasetManagerFactory, IServiceProvider provider)
        {
            InitializeComponent();
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _datasetManagerFactory = datasetManagerFactory ?? throw new ArgumentNullException(nameof(datasetManagerFactory));
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (_fileService.CheckFileExist("programsConfig.json"))
            {
                //var data = _fileService.ReadStringFileAsync("programsConfig.json").ConfigureAwait(false).GetAwaiter().GetResult();
                var data = Task.Run(async () => await _fileService.ReadStringFileAsync("programsConfig.json")).Result;
                var programConfig = JsonUtil.Deserialize<ProgramsConfig>(data)!;

                foreach (var program in programConfig.Programs.OrderByDescending(p => p.Seq))
                {
                    AssemblyButton btn = new AssemblyButton();
                    btn.ObjectName = program.ProgId;
                    btn.Text = program.ProgName;
                    btn.AssName = program.ModuleName;
                    this.panel1.Controls.Add(btn);
                    btn.Dock = DockStyle.Top;
                    btn.Click += new System.EventHandler(btn_Click!);
                }

                this.dgvDatasets.RowHeadersVisible = false;
                this.dgvDatasets.AutoGenerateColumns = false;
                BindFrm();
            }
            else
            {
                MessageBox.Show($"File {Path.Combine(_fileService.Folder, "programsConfig.json")} is not exist");
            }
        }

        private void BindFrm()
        {
            var bindingList = new BindingList<DatasetManager>(_datasetManagerFactory.DatasetManagers.OrderBy(p => p.Seq).ToList());
            _bindingSource.DataSource = bindingList;
            _bmDatasetManager = _bindingSource.CurrencyManager;
            this.dgvDatasets.DataSource = _bindingSource;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            _bmDatasetManager?.Refresh();

            string assName = ((AssemblyButton)sender).AssName;
            string objectName = ((AssemblyButton)sender).ObjectName;
            bool isChildExist = false;


            for (int n = 0; n < this.tabControl1.TabPages.Count; n++)
            {
                if (this.tabControl1.TabPages[n].Name == objectName)
                {
                    this.tabControl1.SelectTab(n);
                    isChildExist = true;
                }
            }
            if (!isChildExist)
            {
                frmBase item;
                //Assembly asm = Assembly.Load(assName);
                TabPage childTab = new TabPage();
                item = _provider.CreateScope().ServiceProvider.GetKeyedService<frmBase>(objectName)!;
                //if (objectName.EndsWith("Dlg"))
                //{
                //    item.ShowDialog(tabControl1);
                //    return;
                //}
                item.CurrencyManager = _bmDatasetManager;
                tabControl1.TabPages.Add(childTab);
                childTab.Name = objectName;
                childTab.Text = ((AssemblyButton)sender).Text;
                item.TopLevel = false;
                item.Anchor = AnchorStyles.Top;
                item.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                item.Dock = DockStyle.Fill;
                childTab.Controls.Add(item);
                tabControl1.SelectTab(childTab);
                item.Show();
                item.FormClosing += new FormClosingEventHandler(ChildFormClose!);
                if ((item as frmBase)?.closeFlag ?? false)
                {
                    item.Close();
                }
            }
        }

        private void ChildFormClose(Object sender, FormClosingEventArgs e)
        {
            this.tabControl1.SelectedTab!.Dispose();
        }

        private void btnLoadFromSQL_Click(object sender, EventArgs e)
        {
            var dlg = new frmConfigSettingDlg(_config);
            dlg.OnLoadData += (setting) =>
            {
                var service = _provider.GetRequiredService<ISchemaService>();

                try
                {
                    _datasetManagerFactory.AddDatasetManager(
                        setting.Key,
                        setting!.ConnectionType switch
                        {
                            Repositories.Enums.ConnectionType.MSSQL => Shareds.Enums.DataSource.MSSQL,
                            Repositories.Enums.ConnectionType.MySQL => Shareds.Enums.DataSource.MySQL,
                            _ => throw new ArgumentException("Unkno Connection Type.")
                        },
                        service.GetDatasetFromDB(setting.Key, setting.ConnectionType),
                        setting.Using, setting.Namespace, setting.ClassSuffix, setting.SEQ);
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            };
            dlg.OnDataLoaded += (count) =>
            {
                BindFrm();
                _bmDatasetManager.Refresh();
                MessageBox.Show(this, $"{count} databases are connected!");
            };
            dlg.OnSaveSettings += (jsonSettings) =>
            {
                _fileService.SaveStringFileAsync("settingConfig.json", jsonSettings);
                return true;
            };
            dlg.ShowDialog();
            dlg.Dispose();
        }

        private void btnLoadFromXML_Click(object sender, EventArgs e)
        {
            var fileFullName = GetFileName();
            if (fileFullName != "")
            {
                var fileName = Path.GetFileName(fileFullName);

                using (var sr = new StreamReader(fileFullName))
                {
                    var xml = sr.ReadToEnd();
                    var service = _provider.GetRequiredService<ISchemaService>();

                    var databaseManager = _datasetManagerFactory.GetDatasetManager(fileName);
                    if (databaseManager == null)
                    {
                        _datasetManagerFactory.AddDatasetManager(
                            fileName,
                            Shareds.Enums.DataSource.XML,
                            service.GetDatasetFromXml(xml),
                            "", "", "", 999);
                    }
                    else
                    {
                        databaseManager.Dataset = service.GetDatasetFromXml(xml);
                    }

                    BindFrm();
                    _bmDatasetManager.Refresh();
                }
            }
        }

        private void dgvDatasets_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                var current = _bmDatasetManager.Current as DatasetManager;
                _bindingSource.Remove(current);
                _datasetManagerFactory.RemoveDatasetManager(current?.Category ?? throw new Exception($"_bmDatasetManager.Current is null"));
                _bmDatasetManager.Refresh();
            }
        }

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

        public void SetFolderExists(string filePath)
        {
            DirectoryInfo di = new DirectoryInfo(filePath);
            if (!di.Exists)
            {
                di.Create();
            }
        }


    }
}
