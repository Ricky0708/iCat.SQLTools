using RickySQLTools.Utilitys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickySQLTools.DAL
{
    public class DALDapperGenerator : DALBase
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
                _dalDataset = objDAL._dalDataset;
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
            string parameters = "var parameters = new DynamicParameters();\r\n";
            sb.Append("var sbSQL = new StringBuilder();\r\n");
            for (int i = 0; i < dvCol.Count; i++)
            {
                if (i == dvCol.Count - 1)
                {
                    selectCols += "A." + dvCol[i]["ColName"];
                    whereParams += $"sbSQL.Append(\"    A.{dvCol[i]["ColName"]} = @{dvCol[i]["ColName"]}\"); \r\n";
                    parameters += $"parameters.Add(\"@{dvCol[i]["ColName"]}\", {dvCol[i]["ColName"].ToString().ToLower()}, {ShareUtility.ConvertToCSharpDbType(dvCol[i]["ColType"].ToString())}, ParameterDirection.Input, {dvCol[i]["ColLength"].ToString()});\r\n";
                    //sb.Append("@w_" + dvCol[i]["ColName"] + " " + dvCol[i]["ColType"] + (dvCol[i]["ColLength"].ToString() != "" ? "(" + dvCol[i]["ColLength"].ToString() + ")" : "") + "\r\n\r\n");
                }
                else
                {
                    selectCols += "A." + dvCol[i]["ColName"] + ", ";
                    whereParams += $"sbSQL.Append(\"    A.{dvCol[i]["ColName"]} = @{dvCol[i]["ColName"]} AND \"); \r\n";
                    parameters += $"parameters.Add(\"@{dvCol[i]["ColName"]}\", {dvCol[i]["ColName"].ToString().ToLower()}, {ShareUtility.ConvertToCSharpDbType(dvCol[i]["ColType"].ToString())}, ParameterDirection.Input, {dvCol[i]["ColLength"].ToString()});\r\n";
                    //sb.Append("@w_" + dvCol[i]["ColName"] + " " + dvCol[i]["ColType"] + (dvCol[i]["ColLength"].ToString() != "" ? "(" + dvCol[i]["ColLength"].ToString() + ")" : "") + ",\r\n");
                }
            }
            sb.Append($"    sbSQL.Append(\"SELECT {selectCols} \");\r\n");
            sb.Append($"    sbSQL.Append(\"FROM {tableName} A \");\r\n");
            sb.Append($"    sbSQL.Append(\"WHERE \");\r\n");
            sb.Append($"    {whereParams}\r\n");

            sb.Append(parameters);
            result = sb.ToString();
            return result;
        }
        private string GenerateInsert(DataSet ds, string tableName)
        {
            string result = "";
            StringBuilder sb = new StringBuilder();
            DataView dvCol = ds.Tables[strColumns].DefaultView;
            dvCol.RowFilter = "TableName='" + tableName + "'";
            string selectCols = "";
            string valueParams = "";
            string parameters = "var parameters = new DynamicParameters();\r\n";
            sb.Append("var sbSQL = new StringBuilder();\r\n");
            for (int i = 0; i < dvCol.Count; i++)
            {
                if (i == dvCol.Count - 1)
                {
                    selectCols += dvCol[i]["ColName"];
                    valueParams += $"@{dvCol[i]["ColName"]}";
                    parameters += $"parameters.Add(\"@{dvCol[i]["ColName"]}\", {dvCol[i]["ColName"].ToString().ToLower()}, {ShareUtility.ConvertToCSharpDbType(dvCol[i]["ColType"].ToString())}, ParameterDirection.Input, {dvCol[i]["ColLength"].ToString()});\r\n";
                    //sb.Append("@w_" + dvCol[i]["ColName"] + " " + dvCol[i]["ColType"] + (dvCol[i]["ColLength"].ToString() != "" ? "(" + dvCol[i]["ColLength"].ToString() + ")" : "") + "\r\n\r\n");
                }
                else
                {
                    selectCols += dvCol[i]["ColName"] + ", ";
                    valueParams += $"@{dvCol[i]["ColName"]}, ";
                    parameters += $"parameters.Add(\"@{dvCol[i]["ColName"]}\", {dvCol[i]["ColName"].ToString().ToLower()}, {ShareUtility.ConvertToCSharpDbType(dvCol[i]["ColType"].ToString())}, ParameterDirection.Input, {dvCol[i]["ColLength"].ToString()});\r\n";
                    //sb.Append("@w_" + dvCol[i]["ColName"] + " " + dvCol[i]["ColType"] + (dvCol[i]["ColLength"].ToString() != "" ? "(" + dvCol[i]["ColLength"].ToString() + ")" : "") + ",\r\n");
                }
            }
            sb.Append($"    sbSQL.Append(\"INSERT INTO {tableName}({selectCols}) \");\r\n");
            sb.Append($"    sbSQL.Append(\"VALUES({valueParams}) \");\r\n");

            sb.Append(parameters);
            result = sb.ToString();
            return result;
        }
        private string GenerateUpdate(DataSet ds, string tableName)
        {
            string result = "";
            StringBuilder sb = new StringBuilder();
            DataView dvCol = ds.Tables[strColumns].DefaultView;
            dvCol.RowFilter = "TableName='" + tableName + "'";
            string updateParams = "";
            string whereParams = "";
            string topWhereParams = "";
            string topUpdateParams = "";
            string p_parameters = "var parameters = new DynamicParameters();\r\n";
            string w_parameters = "";
            sb.Append("var sbSQL = new StringBuilder();\r\n");
            for (int i = 0; i < dvCol.Count; i++)
            {
                if (dvCol[i]["IsIdentity"].ToString() != "true")
                {
                    if (i == dvCol.Count - 1)
                    {
                        updateParams += dvCol[i]["ColName"] + " = " + "@p_" + dvCol[i]["ColName"] + " ";
                        p_parameters += $"parameters.Add(\"@p_{dvCol[i]["ColName"]}\", {dvCol[i]["ColName"].ToString().ToLower()}, {ShareUtility.ConvertToCSharpDbType(dvCol[i]["ColType"].ToString())}, ParameterDirection.Input, {dvCol[i]["ColLength"].ToString()});\r\n";
                        //w_parameters += $"parameters.Add(\"@w_{dvCol[i]["ColName"]}\", {dvCol[i]["ColName"].ToString().ToLower()}, {ShareUtility.ConvertToCSharpDbType(dvCol[i]["ColType"].ToString())}, ParameterDirection.Input, {dvCol[i]["ColLength"].ToString()});\r\n";
                    }
                    else
                    {
                        updateParams += dvCol[i]["ColName"] + " = " + "@p_" + dvCol[i]["ColName"] + ", ";
                        p_parameters += $"parameters.Add(\"@p_{dvCol[i]["ColName"]}\", {dvCol[i]["ColName"].ToString().ToLower()}, {ShareUtility.ConvertToCSharpDbType(dvCol[i]["ColType"].ToString())}, ParameterDirection.Input, {dvCol[i]["ColLength"].ToString()});\r\n";
                        //w_parameters += $"parameters.Add(\"@w_{dvCol[i]["ColName"]}\", {dvCol[i]["ColName"].ToString().ToLower()}, {ShareUtility.ConvertToCSharpDbType(dvCol[i]["ColType"].ToString())}, ParameterDirection.Input, {dvCol[i]["ColLength"].ToString()});\r\n";
                    }
                }
                if (i == dvCol.Count - 1)
                {
                    whereParams += "         sbSQL.Append(\"    " + dvCol[i]["ColName"] + " = " + "@w_" + dvCol[i]["ColName"] + "\");\r\n";
                    //p_parameters += $"parameters.Add(\"@p_{dvCol[i]["ColName"]}\", {dvCol[i]["ColName"].ToString().ToLower()}, {ShareUtility.ConvertToCSharpDbType(dvCol[i]["ColType"].ToString())}, ParameterDirection.Input, {dvCol[i]["ColLength"].ToString()});\r\n";
                    w_parameters += $"parameters.Add(\"@w_{dvCol[i]["ColName"]}\", {dvCol[i]["ColName"].ToString().ToLower()}, {ShareUtility.ConvertToCSharpDbType(dvCol[i]["ColType"].ToString())}, ParameterDirection.Input, {dvCol[i]["ColLength"].ToString()});\r\n";
                }
                else
                {
                    whereParams += "         sbSQL.Append(\"    " + dvCol[i]["ColName"] + " = " + "@w_" + dvCol[i]["ColName"] + " AND \");\r\n";
                    //p_parameters += $"parameters.Add(\"@p_{dvCol[i]["ColName"]}\", {dvCol[i]["ColName"].ToString().ToLower()}, {ShareUtility.ConvertToCSharpDbType(dvCol[i]["ColType"].ToString())}, ParameterDirection.Input, {dvCol[i]["ColLength"].ToString()});\r\n";
                    w_parameters += $"parameters.Add(\"@w_{dvCol[i]["ColName"]}\", {dvCol[i]["ColName"].ToString().ToLower()}, {ShareUtility.ConvertToCSharpDbType(dvCol[i]["ColType"].ToString())}, ParameterDirection.Input, {dvCol[i]["ColLength"].ToString()});\r\n";
                }

            }
            sb.Append(topUpdateParams);
            sb.Append($"    sbSQL.Append(\"UPDATE {tableName} SET {updateParams} \");\r\n");
            sb.Append($"    sbSQL.Append(\"WHERE \");\r\n" + whereParams + "");
            sb.Append(p_parameters);
            sb.Append(w_parameters);
            result = sb.ToString();
            return result;
        }
    }
}
