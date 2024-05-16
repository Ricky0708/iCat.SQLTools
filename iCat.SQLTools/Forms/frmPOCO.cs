using iCat.SQLTools.Repositories.Implements;
using iCat.SQLTools.Services.Managers;
using Microsoft.IdentityModel.Tokens;
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
        //DAL.DALPOCOGenerator objDAL = new DAL.DALPOCOGenerator();
        //DAL.DALClassModelGenerator objDAL2 = new DAL.DALClassModelGenerator();
        //ShareUtility objUti = new ShareUtility();
        DataTable dtScript;
        CurrencyManager cmTables;
        CurrencyManager cmScripts;
        CurrencyManager cmSPAndFuncs;
        private readonly DatasetManager _datasetManager;

        public frmPOCO(DatasetManager datasetManager)
        {
            InitializeComponent();
            dgvTables.AutoGenerateColumns = false;
            dgvSpsAndFuncs.AutoGenerateColumns = false;
            dtScript = new DataTable("Scripts");
            dtScript.Columns.Add("ScriptName");
            dtScript.Columns.Add("Script");
            dtScript.Columns.Add("cmd");
            dgvScripts.DataSource = dtScript;
            cmScripts = (CurrencyManager)this.BindingContext[dtScript];
            _datasetManager = datasetManager ?? throw new ArgumentNullException(nameof(datasetManager));
            tableLayoutPanel1.SetColumnSpan(btnAllTables, 2);
            //Button btnAddScript = new Button();
            //btnAddScript.Name = "btnAddScript";
            //btnAddScript.Text = "＋";
            //btnAddScript.Dock = DockStyle.Right;
            //btnAddScript.Size = new Size(30, 30);
            //btnAddScript.Cursor = Cursors.Default;
        }

        private void frmPOCOGenrator_Load(object sender, EventArgs e)
        {

            if (_datasetManager.DatasetFromType != Shareds.Enums.DatasetFromType.None && _datasetManager.Dataset != null)
            {
                dgvTables.Focus();
                dgvTables.DataSource = _datasetManager.Dataset;
                dgvTables.DataMember = "Tables";
                dgvSpsAndFuncs.DataSource = _datasetManager.Dataset;
                dgvSpsAndFuncs.DataMember = "SpsAndFuncs";
                cmTables = (CurrencyManager)this.BindingContext![_datasetManager.Dataset, "Tables"];
                cmSPAndFuncs = (CurrencyManager)this.BindingContext[_datasetManager.Dataset, "SpsAndFuncs"];
                ((DataView)cmTables.List).RowFilter = "TableName LIKE '%" + txtTableFilter.Text + "%'";
                ((DataView)cmSPAndFuncs.List).RowFilter = "SPECIFIC_NAME LIKE '%" + txtSpFilter.Text + "%'";
            }
            else
            {
                MessageBox.Show("Please load data first.");
            }

        }

        private void btn_Click(object sender, EventArgs e)
        {
            try
            {


                switch (((Button)sender).Name)
                {
                    case nameof(btnWithComment):
                        if (txtClassName.Text == "")
                        {
                            txtClassName.Focus();
                            MessageBox.Show("Please type in a class name..");
                        }
                        txtResult.Text = _datasetManager.GenerateClassWithSummary("namespace", "using system.io", txtClassName.Text, txtScript.Text);
                        break;
                    case nameof(btnWithoutComment):
                        if (txtClassName.Text == "")
                        {
                            txtClassName.Focus();
                            MessageBox.Show("Please type in a class name..");
                        }
                        txtResult.Text = _datasetManager.GenerateClassWithoutSummary("namespace", "using system.io", txtClassName.Text, txtScript.Text);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //switch (((Button)sender).Name)
            //{
            //    case "btnFromScript":
            //        if (txtClassName.Text == "")
            //        {
            //            txtClassName.Focus();
            //            MessageBox.Show("Please type in a class name..");
            //        }
            //        var b = objDAL2.GenerateFromScript(txtClassName.Text, txtScript.Text);
            //        txtResult.Text = b;// objDAL.GenerateFromScript(txtClassName.Text, txtScript.Text);
            //        if (txtResult.Text == "")
            //        {
            //            MessageBox.Show(objDAL2.ErrMsg);
            //        }
            //        break;
            //    case "btnFromDB":
            //        string folder = objUti.OpenFolder();
            //        if (folder != "")
            //        {
            //            if (!objDAL.GenerateFromDB(ds, folder))
            //            {
            //                MessageBox.Show(objDAL.ErrMsg);
            //            }
            //            else
            //            {
            //                MessageBox.Show($"Files has write to \r\n\r\n {folder}\\");
            //                string file = folder;
            //                System.Diagnostics.Process.Start(file);
            //            }
            //        }
            //        break;
            //    case "btnExportCRptXml":
            //        if (dtScript.Rows.Count == 0)
            //        {
            //            MessageBox.Show("There is not any scripts could be generate xsd for export !\r\n\r\n 1. Please type in TSQL in [script] and click 『+』 to add !");
            //        }
            //        else
            //        {
            //            string fileName = objUti.SetFileName(Application.StartupPath + "\\CrystalReportXsd\\", "", "xsd");
            //            if (fileName != "")
            //            {
            //                if (objDAL.GenerateCRptXsd(dtScript, fileName))
            //                {
            //                    MessageBox.Show("Success !");
            //                    dtScript.Clear();
            //                    dtScript.AcceptChanges();
            //                    string file = @"C:\Windows\explorer.exe";
            //                    string argument = @"/select, " + fileName;
            //                    System.Diagnostics.Process.Start(file, argument);
            //                }
            //                else
            //                {
            //                    MessageBox.Show(objDAL.ErrMsg);
            //                }
            //            }
            //        }
            //        break;
            //    case "btnAddScript":
            //        bool isExist = false;
            //        foreach (DataRow row in dtScript.Rows)
            //        {
            //            if (row["ScriptName"].ToString() == txtClassName.Text)
            //            {
            //                isExist = true;
            //            }
            //        }
            //        if (!isExist && !(txtClassName.Text == string.Empty))
            //        {
            //            if (objDAL.CheckScriptNotError(txtScript.Text))
            //            {
            //                DataRow dr = dtScript.NewRow();
            //                dr["ScriptName"] = txtClassName.Text;
            //                dr["Script"] = txtScript.Text;
            //                dr["cmd"] = "X";
            //                dtScript.Rows.Add(dr);
            //                dtScript.AcceptChanges();
            //            }
            //            else
            //            {
            //                MessageBox.Show(objDAL.ErrMsg);
            //            }

            //        }
            //        else
            //        {
            //            MessageBox.Show("Please check these rules : \r\n\r\n 1. Can't use a empty name for a table.\r\n\r\n 2. this name in scripts already exist.");
            //        }
            //        break;
            //    default:
            //        break;
            //}
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
                ((DataView)cmTables.List).RowFilter = "TableName LIKE '%" + txtTableFilter.Text + "%'";
            }
        }

        private void txtSpFilter_TextChanged(object sender, EventArgs e)
        {
            if (cmSPAndFuncs != null)
            {
                ((DataView)cmSPAndFuncs.List).RowFilter = "SPECIFIC_NAME LIKE '%" + txtSpFilter.Text + "%'";
            }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (((DataGridView)sender).Name)
            {
                case "dgvTables":
                    if (cmTables.Position != -1)
                    {
                        string tableName = ((DataRowView)cmTables.Current)["TableName"].ToString();
                        txtClassName.Text = tableName;
                        //txtScript.Text = objDAL.GenerateScript(tableName);
                    }
                    break;
                case "dgvSpsAndFuncs":
                    if (cmTables.Position != -1)
                    {
                        string spName = ((DataRowView)cmSPAndFuncs.Current)["SPECIFIC_NAME"].ToString();
                        txtClassName.Text = spName;
                        //txtResult.Text = objDAL.GeneratePOCOFromSP(spName);
                    }
                    break;
                case "dgvScripts":
                    if (cmScripts.Position != -1)
                    {
                        if (dgvScripts.Columns[e.ColumnIndex].Name == "dScriptName")
                        {
                            txtClassName.Text = ((DataRowView)cmScripts.Current)["ScriptName"].ToString();
                            txtScript.Text = ((DataRowView)cmScripts.Current)["Script"].ToString();
                        }
                        else if (dgvScripts.Columns[e.ColumnIndex].Name == "dCmd")
                        {
                            ((DataRowView)cmScripts.Current).Delete();
                            cmScripts.EndCurrentEdit();
                            dtScript.AcceptChanges();
                        }

                    }
                    break;
                default:
                    break;
            }

        }
    }
}
