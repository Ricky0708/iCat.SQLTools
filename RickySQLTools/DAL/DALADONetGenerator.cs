using RickySQLTools.Utilitys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickySQLTools.DAL
{
    public class DALADONetGenerator : DALBase
    {
        DAO dao;
        ShareUtility objUti = new ShareUtility();
        public bool CreateDataSet()
        {
            DAL.DALTables objDAL = new DAL.DALTables();
            _strConn = base.connString; //save the current db connection
            dao = new DAO(_strConn);

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

        public string GenerateScript(DataSet ds, string tableName, SPType sptype)
        {
            string result = "";
            switch (sptype)
            {
                case SPType.Select:
                    result = GenerateSelect(ds, tableName);
                    break;
                case SPType.Insert:
                    result = GenerateInsert(ds, tableName);
                    break;
                case SPType.Update:
                    result = GenerateUpdate(ds, tableName);
                    break;
                case SPType.Delete:
                    break;
                default:
                    break;
            }
            return result;
        }


        private string GenerateSelect(DataSet ds, string tableName)
        {
            string result = "";
            StringBuilder sb = new StringBuilder();
            DataView dvCol = ds.Tables[strColumns].DefaultView;
            dvCol.RowFilter = "TableName='" + tableName + "'";
            string selectCols = "";
            string whereParams = "";
            string parameters = "var parameters = new List<SqlParameter>();\r\n";
            string dataAssigen = "";
            sb.Append("var sbSQL = new StringBuilder();\r\n");
            for (int i = 0; i < dvCol.Count; i++)
            {
                if (i == dvCol.Count - 1)
                {
                    selectCols += "A." + dvCol[i]["ColName"];
                    whereParams += $"sbSQL.Append(\"    A.{dvCol[i]["ColName"]} = @{dvCol[i]["ColName"]}\"); \r\n";
                    parameters += $"parameters.Add(new SqlParameter(\"@{dvCol[i]["ColName"]}\", {dvCol[i]["ColName"].ToString().ToLower()}));\r\n";
                    //dataAssigen += $" {dvCol[i]["ColName"]} = Convert.{ConvertType(dvCol[i]["ColType"].ToString())}(dr[nameof({tableName}Model.{dvCol[i]["ColName"]})]) \r\n";
                    dataAssigen += $"{dvCol[i]["ColName"]} = {ConvertType(dvCol[i], $"{tableName}")} \r\n";
                }
                else
                {
                    selectCols += "A." + dvCol[i]["ColName"] + ", ";
                    whereParams += $"sbSQL.Append(\"    A.{dvCol[i]["ColName"]} = @{dvCol[i]["ColName"]} AND \"); \r\n";
                    parameters += $"parameters.Add(new SqlParameter(\"@{dvCol[i]["ColName"]}\", {dvCol[i]["ColName"].ToString().ToLower()}));\r\n";
                    dataAssigen += $"{dvCol[i]["ColName"]} = {ConvertType(dvCol[i], $"{tableName}")}, \r\n";
                }
            }
            sb.Append($"    sbSQL.Append(\"SELECT {selectCols} \");\r\n");
            sb.Append($"    sbSQL.Append(\"FROM {tableName} A \");\r\n");
            sb.Append($"    sbSQL.Append(\"WHERE \");\r\n");
            sb.Append($"    {whereParams}\r\n");
            sb.Append(parameters + "\r\n");
            sb.Append(dataAssigen);
            result = sb.ToString();
            return result;
        }
        private string GenerateInsert(DataSet ds, string tableName)
        {
            throw new Exception();
        }
        private string GenerateUpdate(DataSet ds, string tableName)
        {
            throw new Exception();
        }
        private string ConvertType(DataRowView drv, string modelName)
        {
            //
            switch (drv["ColType"].ToString().ToLower())
            {
                case "bit":
                    return $"Convert.ToBoolean(dr[nameof({modelName}.{drv["ColName"]})])";
                case "int":
                    return $"Convert.ToInt32(dr[nameof({modelName}.{drv["ColName"]})])";
                case "varbinary":
                case "char":
                case "varchar":
                case "nvarchar":
                    var result = "";
                    if ((int)drv["IsNullable"] == 0)
                    {
                        result = $"dr.IsDBNull(nameof({modelName}.{drv["ColName"]})) ? \"\" : (string)dr[nameof({modelName}.{drv["ColName"]})]";
                    }
                    else
                    {
                        result = $"Convert.ToString(dr[nameof({modelName}.{drv["ColName"]})])";
                    }
                    return result;
                default:
                    throw new Exception($"unknow col type {drv["ColType"].ToString().ToLower()}");
            }
        }
    }
}
