using iCat.SQLTools.CustomControlleres;
using iCat.SQLTools.Forms;
using iCat.SQLTools.Models;
using iCat.SQLTools.Services.Interfaces;
using iCat.SQLTools.Shareds;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Text.Json;
using System.Windows.Forms;

namespace iCat.SQLTools
{
    public partial class MainForm : Form
    {
        private readonly IFileService _fileService;
        private readonly IServiceProvider _provider;

        public MainForm(IFileService fileService, IServiceProvider provider)
        {
            InitializeComponent();
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
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
            }
            else
            {
                MessageBox.Show($"File {Path.Combine(_fileService.Folder, "programsConfig.json")} is not exist");
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
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
                Form item;
                //Assembly asm = Assembly.Load(assName);
                TabPage childTab = new TabPage();
                item = _provider.CreateScope().ServiceProvider.GetKeyedService<Form>(objectName)!;
                if (objectName.EndsWith("Dlg"))
                {
                    item.ShowDialog(tabControl1);
                    return;
                }
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
    }
}
