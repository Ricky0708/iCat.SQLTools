using RickySQLTools.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RickySQLTools
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            StringReader reader = new StringReader(Settings.Default.Progs);
            ds.ReadXml(reader);
            DataView dv;
            dv = ds.Tables["Progs"].DefaultView;
            dv.Sort = "SEQ DESC";
            for (int i = 0; i < dv.Count; i++)
            {
                AssemblyButton btn = new AssemblyButton();
                btn.ObjectName = dv[i]["ProgID"].ToString();
                btn.Text = dv[i]["ProgName"].ToString();
                btn.AssName = dv[i]["ModuleName"].ToString();
                Panel1.Controls.Add(btn);
                btn.Dock = DockStyle.Top;
            }
            foreach (Button btn in Panel1.Controls)
            {
                btn.Click += new System.EventHandler(btn_Click);
            }

        }

        #region LeftMenu
        private void btn_Click(object sender, EventArgs e)
        {
            string assName = ((AssemblyButton)sender).AssName;
            string objectName = ((AssemblyButton)sender).ObjectName;
            bool isChildExist = false;


            for (int n = 0; n < this.TabControl1.TabPages.Count; n++)
            {
                if (this.TabControl1.TabPages[n].Name == objectName)
                {
                    if (objectName!="Tables")
                    {
                        this.TabControl1.SelectTab(n);
                        isChildExist = true;
                    }
                }
            }
            if (!isChildExist)
            {
                Form item;
                Assembly asm = Assembly.Load(assName);
                TabPage childTab = new TabPage();
                item = asm.CreateInstance(assName + "." + objectName,false) as Form;
                if (objectName.EndsWith("Dlg"))
                {
                    item.ShowDialog(TabControl1);
                    return;
                }
                TabControl1.TabPages.Add(childTab);
                childTab.Name = objectName;
                childTab.Text = ((AssemblyButton)sender).Text;
                item.TopLevel = false;
                item.Anchor = AnchorStyles.Top;
                item.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                item.Dock = DockStyle.Fill;
                childTab.Controls.Add(item);
                TabControl1.SelectTab(childTab);
                item.Show();
                item.FormClosing += new FormClosingEventHandler(ChildFormClose);
            }
        }

        private void ChildFormClose(Object sender, FormClosingEventArgs e)
        {
            this.TabControl1.SelectedTab.Dispose();
        }
        #endregion
    }
}
