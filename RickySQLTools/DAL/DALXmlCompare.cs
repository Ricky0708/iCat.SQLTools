using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RickySQLTools.DAL
{
    internal class DALXmlCompare : DALBase
    {
        internal event CompareCallBackHandler CompareCallBack;
        internal delegate void CompareCallBackHandler(string workState, int progress);
        internal event CompareFinishCallBackHandler CompareFinishCallBack;
        internal delegate void CompareFinishCallBackHandler(DataSet ds);

        internal void Compare(DataSet dsFirst, DataSet dsSecond)
        {
            CompareCallBack("Comparing Tables..", 0);
            AddDirectionColumn(dsFirst.Tables[dtTables], "Xml_A");
            AddDirectionColumn(dsSecond.Tables[dtTables], "Xml_B");

            AddDirectionColumn(dsFirst.Tables[dtColumns], "Xml_A");
            AddDirectionColumn(dsSecond.Tables[dtColumns], "Xml_B");

            AddDirectionColumn(dsFirst.Tables[dtSpsAndFuncs], "Xml_A");
            AddDirectionColumn(dsSecond.Tables[dtSpsAndFuncs], "Xml_B");

            var comparer = new CustomComparer();
            DataTable dtUnionTable = dsFirst.Tables[dtTables].AsEnumerable()
                  .Union(dsSecond.Tables[dtTables].AsEnumerable(), comparer).OrderBy(p => p[0]).CopyToDataTable<DataRow>();
            dtUnionTable.TableName = dtTables;
            CompareCallBack("Comparing Columns..", 33);

            DataTable dtUnionColumns = dsFirst.Tables[dtColumns].AsEnumerable()
                  .Union(dsSecond.Tables[dtColumns].AsEnumerable(), comparer).OrderBy(p => p[0]).CopyToDataTable<DataRow>();
            dtUnionColumns.TableName = dtColumns;
            CompareCallBack("Comparing SPs and Funcs..", 66);

            DataTable dtUntionSpsAndFuncs = dsFirst.Tables[dtSpsAndFuncs].AsEnumerable()
                  .Union(dsSecond.Tables[dtSpsAndFuncs].AsEnumerable(), comparer).OrderBy(p => p[0]).CopyToDataTable<DataRow>();
            dtUntionSpsAndFuncs.TableName = dtSpsAndFuncs;
            CompareCallBack("Compare finished", 100);

            DataSet dsResult = new DataSet();
            dsResult.Tables.Add(dtUnionTable);
            dsResult.Tables.Add(dtUnionColumns);
            dsResult.Tables.Add(dtUntionSpsAndFuncs);
            CompareFinishCallBack(dsResult);
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

    class CustomComparer : IEqualityComparer<DataRow>
    {

        public bool Equals(DataRow x, DataRow y)
        {
            x["Xml_A"] = true;
            x["Xml_B"] = true;
            if (x.Table.Columns.Contains("ColType"))
            {
                for (int i = 0; i < x.ItemArray.Length - 3; i++)
                {
                    if (!x[i].Equals(y[i]))
                    {
                        x["Type_Equal"] = "X";
                    }
                }
            }
            else
            {
            }

            return true;
        }

        public int GetHashCode(DataRow obj)
        {
            if (obj.Table.Columns.Contains("ColType"))
            {
                return ((string)obj[0]).GetHashCode() + ((string)obj[2]).GetHashCode();
            }
            else
            {
                return ((string)obj[0]).GetHashCode();
            }
        }

    }
}
