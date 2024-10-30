using iCat.SQLTools.Services.Interfaces;
using iCat.SQLTools.Shareds.Enums;
using NPOI.OpenXmlFormats;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace iCat.SQLTools.Services.Implements
{
    public class DBDiagramService : IDBDiagramService
    {
        #region const
        private const string dtTables = "Tables";
        private const string dtColumns = "Columns";
        private const string dtFKs = "FKs";
        private const string dtSpsAndFuncs = "SpsAndFuncs";
        private const string dtInputParams = "InputParams";
        private const string dtOutputParams = "OutputParams";
        private const string dtIndexes = "Indexes";
        #endregion

        public string GenerateScript(DataSet ds, StringCase nameCase, bool isShowDescriptionAfterColName = false)
        {
            DataView dvTables = ds.Tables[dtTables].DefaultView;
            DataView dvColumns = ds.Tables[dtColumns].DefaultView;

            //lisk tables and views
            var result = new StringBuilder();
            foreach (DataRow dr in ds.Tables[dtTables].Rows)
            {
                if (dr["IsChecked"].ToString() == "1")
                {
                    string tableName = dr["TableName"].ToString();
                    string tableDescription = dr["TableDescription"].ToString();
                    string tableType = dr["TableType"].ToString();
                    dvTables.RowFilter = "TableName = '" + tableName + "'";
                    dvColumns.RowFilter = "TableName = '" + tableName + "'";
                    dvColumns.Sort = "IsPk DESC, ColName ASC";
                    result.Append($"Table {dr["TableName"].ToString()}{(isShowDescriptionAfterColName ? $"_{tableDescription}" : "")} [note: '{dr["TableDescription"].ToString()}'] {{ \r\n");
                    foreach (DataRowView col in dvColumns)
                    {
                        var colProperties = new List<string>();
                        if (col["IsPk"].ToString() == "1") colProperties.Add("pk");
                        if (col["IsNullable"].ToString() == "0") colProperties.Add("not null");
                        colProperties.Add($"note: '{col["ColDescription"].ToString()}'");

                        var colName = col["ColName"].ToString().PadRight(30); // col["ColName"].ToString();
                        var colType = col["ColType"].ToString().PadRight(15);
                        var colLength = col["ColLength"].ToString().StartsWith("(") ? col["ColLength"].ToString().PadRight(10) : $"({col["ColLength"].ToString()})".PadRight(10);
                        var colProperty = $"[{string.Join(", ", colProperties)}]";
                        result.Append($"    {colName}{colType}{colLength}{colProperty} \r\n");
                    }
                    result.Append($"}} \r\n");
                    result.Append($"\r\n");
                }
            }

            return result.ToString();
        }
    }
}
