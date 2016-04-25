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
            AddDirectionColumn(dsFirst.Tables[dtTables], "Xml_A");
            AddDirectionColumn(dsSecond.Tables[dtTables], "Xml_B");

            AddDirectionColumn(dsFirst.Tables[dtColumns], "Xml_A");
            AddDirectionColumn(dsSecond.Tables[dtColumns], "Xml_B");

            AddDirectionColumn(dsFirst.Tables[dtSpsAndFuncs], "Xml_A");
            AddDirectionColumn(dsSecond.Tables[dtSpsAndFuncs], "Xml_B");

            DataTable dtUnionTable = UnionAndCompare(dsFirst.Tables[dtTables], dsSecond.Tables[dtTables]);
            dtUnionTable.TableName = dtTables;
            CompareCallBack("Comparing Columns..", 33);

            DataTable dtUnionColumns = UnionAndCompare(dsFirst.Tables[dtColumns], dsSecond.Tables[dtColumns]);
            dtUnionColumns.TableName = dtColumns;
            CompareCallBack("Comparing SPs and Funcs..", 66);

            DataTable dtUntionSpsAndFuncs = UnionAndCompare(dsFirst.Tables[dtSpsAndFuncs], dsSecond.Tables[dtSpsAndFuncs]);
            dtUntionSpsAndFuncs.TableName = dtSpsAndFuncs;
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
