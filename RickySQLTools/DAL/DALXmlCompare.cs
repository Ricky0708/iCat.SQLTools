using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RickySQLTools.DAL
{
    public class DALXmlCompare : DALBase
    {
        public event CompareCallBackHandler CompareCallBack;
        public delegate void CompareCallBackHandler(string workState, int progress);
        public event CompareFinishCallBackHandler CompareFinishCallBack;
        public delegate void CompareFinishCallBackHandler(DataSet ds);

        public void Compare(DataSet dsFirst, DataSet dsSecond)
        {
            CompareCallBack("Comparing Tables..", 0);
            AddDirectionColumn(dsFirst.Tables[strTables], "Xml_A");
            AddDirectionColumn(dsSecond.Tables[strTables], "Xml_B");

            AddDirectionColumn(dsFirst.Tables[strColumns], "Xml_A");
            AddDirectionColumn(dsSecond.Tables[strColumns], "Xml_B");

            AddDirectionColumn(dsFirst.Tables[strSpsAndFuncs], "Xml_A");
            AddDirectionColumn(dsSecond.Tables[strSpsAndFuncs], "Xml_B");

            DataTable dtUnionTable = UnionAndCompare(dsFirst.Tables[strTables], dsSecond.Tables[strTables]);
            dtUnionTable.TableName = strTables;
            CompareCallBack("Comparing Columns..", 33);

            DataTable dtUnionColumns = UnionAndCompare(dsFirst.Tables[strColumns], dsSecond.Tables[strColumns]);
            dtUnionColumns.TableName = strColumns;
            CompareCallBack("Comparing SPs and Funcs..", 66);

            DataTable dtUntionSpsAndFuncs = UnionAndCompare(dsFirst.Tables[strSpsAndFuncs], dsSecond.Tables[strSpsAndFuncs]);
            dtUntionSpsAndFuncs.TableName = strSpsAndFuncs;
            CompareCallBack("Compare finished", 100);

            DataSet dsResult = new DataSet();
            dsResult.Tables.Add(dtUnionTable);
            dsResult.Tables.Add(dtUnionColumns);
            dsResult.Tables.Add(dtUntionSpsAndFuncs);
            CompareFinishCallBack(dsResult);
        }
        private DataTable UnionAndCompare(DataTable dtA, DataTable dtB)
        {
            var comparer = new CompareUtility.XmlUnionComparer();
            DataTable dtResult =  dtA.AsEnumerable()
                  .Union(dtB.AsEnumerable(), comparer).OrderBy(p => p[0]).CopyToDataTable<DataRow>();
            return dtResult;
        }

        private DataTable AddDirectionColumn(DataTable dt, string setDefColumn)
        {
            dt.Columns.Add(new DataColumn("Xml_A", typeof(bool)));
            dt.Columns.Add(new DataColumn("Xml_B", typeof(bool)));
            dt.Columns.Add(new DataColumn("Type_Equal", typeof(string)));
            foreach (DataRow row in dt.Rows)
            {
                row[setDefColumn] = true;
            }
            return dt;
        }
    }

 
}
