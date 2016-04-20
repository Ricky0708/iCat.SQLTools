using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RickySQLTools
{
    public partial class frmXmlCompare : frmBase
    {
        private DAL.DALUtility objUti = new DAL.DALUtility();
        DAL.DALXmlCompare objDal = new DAL.DALXmlCompare();

        private DataSet dsFirst;
        private DataSet dsSecond;

        public frmXmlCompare()
        {
            InitializeComponent();
            objDal.CompareCallBack += Comparing;
            objDal.CompareFinishCallBack += CompareFinish;

        }

        #region Button Click

        private void LoadXml_Click(object sender, EventArgs e)
        {
            string fileName = "";
            switch (((Button)sender).Name)
            {
                case "btnFirst":
                    fileName = objUti.GetFileName();
                    if (fileName != "")
                    {
                        txtFirstXml.Text = fileName;
                    }
                    break;
                case "btnSecond":
                    fileName = objUti.GetFileName();
                    if (fileName != "")
                    {
                        txtSecondXml.Text = fileName;
                    }
                    break;
                default:
                    return;
            }
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            if (txtFirstXml.Text != "" && txtSecondXml.Text != "")
            {
                FileInfo fiA = new FileInfo(txtFirstXml.Text);
                FileInfo fiB = new FileInfo(txtSecondXml.Text);
                if (fiA.Exists && fiB.Exists)
                {
                    dsFirst = new DataSet();
                    dsFirst.ReadXml(txtFirstXml.Text);

                    dsSecond = new DataSet();
                    dsSecond.ReadXml(txtSecondXml.Text);

                    Thread th = new Thread(() => objDal.Compare(dsFirst, dsSecond));
                    th.Start();
                }
                else
                {
                    MessageBox.Show("Xml file not exist！");
                }
            }
            else
            {
                MessageBox.Show("Please select xml file！");
            }
        }

        #endregion

        #region Method
        private void Comparing(string workState, int progress)
        {
            if (this.InvokeRequired)
            {
                DAL.DALXmlCompare.CompareCallBackHandler myUpdate =
                    new DAL.DALXmlCompare.CompareCallBackHandler(Comparing);

                this.Invoke(myUpdate, workState, progress);
            }
            else
            {
                lblState.Text = workState;
                progressBar1.Value = progress;
            }
        }

        private void CompareFinish(DataSet ds)
        {
            if (this.InvokeRequired)
            {
                DAL.DALXmlCompare.CompareFinishCallBackHandler myUpdate =
                    new DAL.DALXmlCompare.CompareFinishCallBackHandler(CompareFinish);

                this.Invoke(myUpdate, ds);
            }
            else
            {
                dgvTables.AutoGenerateColumns = false;
                dgvTables.DataSource = ds;
                dgvTables.DataMember = "Tables";

                dgvColumns.AutoGenerateColumns = false;
                dgvColumns.DataSource = ds;
                dgvColumns.DataMember = "Columns";

                dgvSpsAndFuncs.AutoGenerateColumns = false;
                dgvSpsAndFuncs.DataSource = ds;
                dgvSpsAndFuncs.DataMember = "SpsAndFuncs";
            }
        }
        #endregion


    }
}
