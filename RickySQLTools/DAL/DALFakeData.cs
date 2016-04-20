using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickySQLTools.DAL
{
    internal class DALFakeData : DALBase
    {
        internal bool CreateDataSet()
        {
            DAL.DALTables objDAL = new DAL.DALTables();
            if (objDAL.GetDatasetFromSQL())
            {
                dalDataset = objDAL.dalDataset;
                return true;
            }
            else
            {
                ErrMsg = objDAL.ErrMsg;
                return false;
            }
        }

        internal bool MakeFakeData(DataSet ds)
        {
            IEnumerable<string> tables = (from row in ds.Tables["Tables"].AsEnumerable()
                                          where row.Field<bool>("IsMakeFakeData") == false
                                          select row.Field<string>("TableName"));


            return true;
        }
    }
}
