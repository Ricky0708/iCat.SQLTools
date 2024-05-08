using RickySQLTools.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RickySQLTools
{
    public partial class frmFakeData : frmBase
    {
        DAL.DALFakeData objDAL = new DAL.DALFakeData();
        DataSet ds;
        //DataView dvTables;
        //DataView dvColumns;
        //DataView dvIndexes;
        //DataView dvFks;
        public frmFakeData()
        {
            InitializeComponent();
        }

        private void frmFakeData_Load(object sender, EventArgs e)
        {
            if (objDAL.CreateDataSet())
            {
                ds = DALBase._dalDataset;

                //dvTables = ds.Tables["Tables"].DefaultView;
                //dvColumns = ds.Tables["Columns"].DefaultView;
                //dvIndexes = ds.Tables["Indexes"].DefaultView;
                //dvFks = ds.Tables["Fks"].DefaultView;
                dgvTables.DataSource = ds;
                dgvTables.DataMember = "Tables";
            }
            else
            {
                MessageBox.Show("Please make sure connection is correct in 『Tables』\r\n\r\n" + objDAL.ErrMsg);
                base.closeFlag = true;
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            objDAL.MakeFakeData(ds);
        }

        protected override void AfterSetConfig(object sender, object e)
        {
            if (objDAL._strConn != Utilitys.ShareUtility.GetSettings(SettingEnum.GetConnectionString).ToString())
            {
                frmFakeData_Load(null, null);
            }
        }
    }
}
