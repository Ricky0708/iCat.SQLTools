using RickySQLTools.Models;
using RickySQLTools.Utilitys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickySQLTools.DAL
{
    public class DALFakeData : DALBase
    {
        DAO dao;

        public bool CreateDataSet()
        {
            dao = new DAO(_strConn);
            DAL.DALTables objDAL = new DAL.DALTables();
            _strConn = base.connString; //save the current db connection

            if (objDAL.GetDatasetFromSQL())
            {
                _dalDataset = objDAL._dalDataset;
                _dalDataset.Tables[strTables].Columns.Add(
                    new DataColumn("IsMakeFakeData", typeof(bool)));

                foreach (DataRow dr in _dalDataset.Tables[strTables].Rows)
                {
                    dr["IsMakeFakeData"] = false;
                    if (dr["TableType"].ToString() == "VIEW")
                    {
                        dr.Delete();
                    }
                }
                _dalDataset.AcceptChanges();
                return true;
            }
            else
            {
                ErrMsg = objDAL.ErrMsg;
                return false;
            }
        }

        public bool MakeFakeData(DataSet ds)
        {
            bool result = true;
            IEnumerable<string> tables = GetAllCheckedTables(ds.Tables[strTables]);
            IEnumerable<string[]> fkTables = GetFkTables(ds.Tables[strFKs], tables);
            IEnumerable<DataRow> coltables = GetColTables(ds.Tables[strColumns], tables);
            Stack<string> stackTables;
            foreach (var item in coltables)
            {
                string a = item[0].ToString();
            }
            //Check all the master in detail has be checked 
            if (result)
            {
                if (!CheckMasterTableChecked(tables, fkTables))
                {
                    resultCode = ResultCode.CheckParentTableError;
                    //ErrMsg = "Not each parent table all be checked !";
                    result = false;
                }
            }

            if (result)
            {
                //Stack table make detail always before master
                stackTables = OrderTables(tables, fkTables);

                //Before insert to sql, empty all tables and enqueue for insert
                StringBuilder sbSQL = new StringBuilder();
                Queue<string> queTables = new Queue<string>();
                if (!EmptyTables(stackTables, out queTables))
                {
                    ErrMsg = dao.ErrMsg;
                    result = false;
                }

            }

            
            // Create dataset for insert
            if (result)
            {

            }
            return result;
        }

        #region make fake data process

        /// <summary>
        /// Get all the tables has be checked
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private IEnumerable<string> GetAllCheckedTables(DataTable dt)
        {
            var tables = (from row in dt.AsEnumerable()
                          where row.Field<bool>("IsMakeFakeData") == true
                          select row.Field<string>("TableName"));
            return tables;
        }

        /// <summary>
        /// Get all releation tables
        /// </summary>
        /// <param name="dt"></param>
        /// <param name=dtTables></param>
        /// <returns></returns>
        private IEnumerable<string[]> GetFkTables(DataTable dt, IEnumerable<string> tables)
        {
            //ReferencedTable is master table
            //ParentTable is detail table
            Stack<string> outContainer = new Stack<string>();


            //get releation
            var fks = (from row in dt.AsEnumerable()
                       from rowB in tables
                       where row.Field<string>("ReferencedTable").ToUpper() == rowB.ToUpper() ||
                        row.Field<string>("ParentTable").ToUpper() == rowB.ToUpper()
                       select new string[] {
                                           row.Field<string>("ReferencedTable"),
                                           row.Field<string>("ParentTable")
                                       }).Distinct(new CompareUtility.fksComparer());
            return fks;
        }

        /// <summary>
        /// Get all releation tables
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="fkTables"></param>
        /// <returns></returns>
        private IEnumerable<DataRow> GetColTables(DataTable dt, IEnumerable<string> tables)
        {
            var colTables = (from row in dt.AsEnumerable()
                       from rowB in tables
                       where row.Field<string>("TableName").ToUpper() == rowB.ToUpper()
                       select row);
            return colTables;
        }

        /// <summary>
        /// Make sure all master table checked
        /// </summary>
        /// <param name=dtTables></param>
        /// <param name="fkTables"></param>
        /// <returns></returns>
        private bool CheckMasterTableChecked(IEnumerable<string> tables, IEnumerable<string[]> fkTables)
        {
            var p = (from v in fkTables select v[0]).Except(tables);

            return p.FirstOrDefault() == null;
        }

        /// <summary>
        /// Stack tables make detail always before master
        /// </summary>
        /// <param name=dtTables></param>
        /// <param name="fkTables"></param>
        /// <returns></returns>
        private Stack<string> OrderTables(IEnumerable<string> tables, IEnumerable<string[]> fkTables)
        {
            Stack<string> tableContainer = new Stack<string>();
            fkTables = fkTables.OrderBy(p => p[0]);
            List<string[]> lst;

            //stack tables in fks
            lst = fkTables.ToList();
            StackParent(tableContainer, lst, lst);

            lst = fkTables.ToList();
            StackChild(tableContainer, lst, lst);


            //Stack all tables not in fks
            var n = tables.Except(tableContainer);
            foreach (var item in n)
            {
                tableContainer.Push(item);
            }
            return tableContainer;
        }

        private void StackParent(Stack<string> tableContainer, List<string[]> fkTables, List<string[]> fkTablesOriginal)
        {
            for (int i = 0; i < fkTables.Count; i = 0)
            {
                var item = fkTables[i];
                fkTables.Remove(item);
                fkTablesOriginal.Remove(item);

                var parents = from p in fkTablesOriginal where p[1] == item[0] select p;
                StackParent(tableContainer, parents.ToList(), fkTablesOriginal);
                if (!(from p in tableContainer where p == item[0] select p.Any()).FirstOrDefault())
                {
                    tableContainer.Push(item[0]);
                }

                //var childs = from p in fkTablesOriginal where p[0] == item[1] select p;
                //MakeTree(tableContainer, childs.ToList(), fkTablesOriginal);
                //tableContainer.Push(item[1]);
            }

        }

        private void StackChild(Stack<string> tableContainer, List<string[]> fkTables, List<string[]> fkTablesOriginal)
        {
            for (int i = 0; i < fkTables.Count; i = 0)
            {
                var item = fkTables[i];
                fkTables.Remove(item);
                fkTablesOriginal.Remove(item);

                var childs = from p in fkTablesOriginal where p[0] == item[1] select p;
                StackChild(tableContainer, childs.ToList(), fkTablesOriginal);
                if (!(from p in tableContainer where p == item[1] select p.Any()).FirstOrDefault())
                {
                    tableContainer.Push(item[1]);
                }
            }
        }

        /// <summary>
        /// Empty tables
        /// </summary>
        /// <param name="stackTables"></param>
        /// <param name="queTables"></param>
        /// <returns></returns>
        private bool EmptyTables(Stack<string> stackTables, out Queue<string> queTables)
        {
            StringBuilder sbSQL = new StringBuilder();
            Queue<string> que = new Queue<string>();
            while (stackTables.Count > 0)
            {
                string tableName = stackTables.Pop();
                sbSQL.Append(string.Format("DELETE FORM {0}", tableName));
                que.Enqueue(tableName);
            }
            queTables = que;
            if (!dao.ExecSQLTransation(sbSQL))
            { return false; }
            else
            { return true; }

        }

        private DataSet CreateDatasetSchema(IEnumerable<string> tables)
        {
            DataSet outDs = new DataSet();

            return outDs;
        }
        #endregion
    }
}
