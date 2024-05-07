using RickySQLTools.Utilitys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickySQLTools.DAL
{
    public class DALSPGenerator : DALBase
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

        public string GenerateScript(DataSet ds, string tableName, SPType sptype, string author, string description)
        {
            string result = "";
            switch (sptype)
            {
                case SPType.Select:
                    result = GenerateSelect(ds, tableName, author, description);
                    break;
                case SPType.Insert:
                    result = GenerateInsert(ds, tableName, author, description);
                    break;
                case SPType.Update:
                    result = GenerateUpdate(ds, tableName, author, description);
                    break;
                case SPType.Delete:
                    result = GenerateDelete(ds, tableName, author, description);
                    break;
                default:
                    break;
            }
            return result;
        }

        private string GenerateSPHeader(string author, string description)
        {
            string result = "";
            StringBuilder sb = new StringBuilder();
            sb.Append("-- ===================================================================\r\n");
            sb.Append("-- Author      : " + author + "\r\n");
            sb.Append("-- Create date : " + DateTime.Today.ToShortDateString() + "\r\n");
            sb.Append("-- Revised date: \r\n");
            sb.Append("-- Description : /**" + description + "**/\r\n");
            sb.Append("-- ===================================================================\r\n");
            result = sb.ToString();
            return result;
        }
        private string GenerateSelect(DataSet ds, string tableName, string author, string description)
        {
            string result = "";
            StringBuilder sb = new StringBuilder();
            DataView dvCol = ds.Tables[strColumns].DefaultView;
            dvCol.RowFilter = "TableName='" + tableName + "'";
            string selectCols = "";
            string whereParams = "";

            sb.Append(GenerateSPHeader(author, description));
            sb.Append("CREATE PROCEDURE [dbo].[usp_" + tableName + "_sel]\r\n");
            for (int i = 0; i < dvCol.Count; i++)
            {
                if (i == dvCol.Count - 1)
                {
                    selectCols += dvCol[i]["ColName"];
                    whereParams += "         " + dvCol[i]["ColName"] + " = " + "@w_" + dvCol[i]["ColName"] + "\r\n";
                    sb.Append("@w_" + dvCol[i]["ColName"] + " " + dvCol[i]["ColType"] + (dvCol[i]["ColLength"].ToString() != "" ? "(" + dvCol[i]["ColLength"].ToString() + ")" : "") + "\r\n\r\n");
                }
                else
                {
                    selectCols += dvCol[i]["ColName"] + ", ";
                    whereParams += "         " + dvCol[i]["ColName"] + " = " + "@w_" + dvCol[i]["ColName"] + " AND \r\n";
                    sb.Append("@w_" + dvCol[i]["ColName"] + " " + dvCol[i]["ColType"] + (dvCol[i]["ColLength"].ToString() != "" ? "(" + dvCol[i]["ColLength"].ToString() + ")" : "") + ",\r\n");
                }
            }
            sb.Append("AS \r\n");
            sb.Append("BEGIN \r\n");
            sb.Append("    SELECT " + selectCols + " FROM " + tableName + "\r\n");
            sb.Append("    WHERE \r\n" + whereParams + "");
            sb.Append("END");
            result = sb.ToString();
            return result;
        }
        private string GenerateInsert(DataSet ds, string tableName, string author, string description)
        {
            string result = "";
            StringBuilder sb = new StringBuilder();
            DataView dvCol = ds.Tables[strColumns].DefaultView;
            dvCol.RowFilter = "TableName='" + tableName + "'";
            string insertCols = "";
            string insertParams = "";

            sb.Append(GenerateSPHeader(author, description));
            sb.Append("CREATE PROCEDURE [dbo].[usp_" + tableName + "_ins]\r\n");
            for (int i = 0; i < dvCol.Count; i++)
            {
                if (dvCol[i]["IsIdentity"].ToString() != "true")
                {
                    if (i == dvCol.Count - 1)
                    {
                        insertCols += dvCol[i]["ColName"];
                        insertParams += "@p_" + dvCol[i]["ColName"];
                        sb.Append("@p_" + dvCol[i]["ColName"] + " " + dvCol[i]["ColType"] + (dvCol[i]["ColLength"].ToString() != "" ? "(" + dvCol[i]["ColLength"].ToString() + ")" : "") + "\r\n\r\n");
                    }
                    else
                    {
                        insertCols += dvCol[i]["ColName"] + ", ";
                        insertParams += "@p_" + dvCol[i]["ColName"] + ", ";
                        sb.Append("@p_" + dvCol[i]["ColName"] + " " + dvCol[i]["ColType"] + (dvCol[i]["ColLength"].ToString() != "" ? "(" + dvCol[i]["ColLength"].ToString() + ")" : "") + ",\r\n");
                    }
                }
            }
            sb.Append("AS \r\n");
            sb.Append("BEGIN \r\n");
            sb.Append("    INSERT INTO " + tableName + " (" + insertCols + ")\r\n");
            sb.Append("    VALUES(" + insertParams + ")\r\n");
            sb.Append("END");
            result = sb.ToString();
            return result;
        }
        private string GenerateUpdate(DataSet ds, string tableName, string author, string description)
        {
            string result = "";
            StringBuilder sb = new StringBuilder();
            DataView dvCol = ds.Tables[strColumns].DefaultView;
            dvCol.RowFilter = "TableName='" + tableName + "'";
            string updateParams = "";
            string whereParams = "";
            string topWhereParams = "";
            string topUpdateParams = "";
            sb.Append(GenerateSPHeader(author, description));
            sb.Append("CREATE PROCEDURE [dbo].[usp_" + tableName + "_upd]\r\n");
            for (int i = 0; i < dvCol.Count; i++)
            {
                if (dvCol[i]["IsIdentity"].ToString() != "true")
                {
                    if (i == dvCol.Count - 1)
                    {
                        updateParams += dvCol[i]["ColName"] + " = " + "@p_" + dvCol[i]["ColName"] + " ";
                        topUpdateParams += "@p_" + dvCol[i]["ColName"] + " " + dvCol[i]["ColType"] + (dvCol[i]["ColLength"].ToString() != "" ? "(" + dvCol[i]["ColLength"].ToString() + ")" : "") + ",\r\n";
                    }
                    else
                    {
                        updateParams += dvCol[i]["ColName"] + " = " + "@p_" + dvCol[i]["ColName"] + ", ";
                        topUpdateParams += "@p_" + dvCol[i]["ColName"] + " " + dvCol[i]["ColType"] + (dvCol[i]["ColLength"].ToString() != "" ? "(" + dvCol[i]["ColLength"].ToString() + ")" : "") + ",\r\n";
                    }
                }
                if (i == dvCol.Count - 1)
                {
                    whereParams += "         " + dvCol[i]["ColName"] + " = " + "@w_" + dvCol[i]["ColName"] + "\r\n";
                    topWhereParams += "@w_" + dvCol[i]["ColName"] + " " + dvCol[i]["ColType"] + (dvCol[i]["ColLength"].ToString() != "" ? "(" + dvCol[i]["ColLength"].ToString() + ")" : "") + "\r\n\r\n";
                }
                else
                {
                    whereParams += "         " + dvCol[i]["ColName"] + " = " + "@w_" + dvCol[i]["ColName"] + " AND \r\n";
                    topWhereParams += "@w_" + dvCol[i]["ColName"] + " " + dvCol[i]["ColType"] + (dvCol[i]["ColLength"].ToString() != "" ? "(" + dvCol[i]["ColLength"].ToString() + ")" : "") + ",\r\n";
                }

            }
            sb.Append(topUpdateParams);
            sb.Append(topWhereParams);
            sb.Append("AS \r\n");
            sb.Append("BEGIN \r\n");
            sb.Append("    UPDATE " + tableName + " SET " + updateParams + "\r\n");
            sb.Append("    WHERE \r\n" + whereParams + "");
            sb.Append("END");
            result = sb.ToString();
            return result;
        }
        private string GenerateDelete(DataSet ds, string tableName, string author, string description)
        {
            string result = "";
            StringBuilder sb = new StringBuilder();
            DataView dvCol = ds.Tables[strColumns].DefaultView;
            dvCol.RowFilter = "TableName='" + tableName + "'";
            string whereParams = "";

            sb.Append(GenerateSPHeader(author, description));
            sb.Append("CREATE PROCEDURE [dbo].[usp_" + tableName + "_del]\r\n");
            for (int i = 0; i < dvCol.Count; i++)
            {
                if (i == dvCol.Count - 1)
                {
                    whereParams += "         " + dvCol[i]["ColName"] + " = " + "@w_" + dvCol[i]["ColName"] + "\r\n";
                    sb.Append("@w_" + dvCol[i]["ColName"] + " " + dvCol[i]["ColType"] + (dvCol[i]["ColLength"].ToString() != "" ? "(" + dvCol[i]["ColLength"].ToString() + ")" : "") + "\r\n\r\n");
                }
                else
                {
                    whereParams += "         " + dvCol[i]["ColName"] + " = " + "@w_" + dvCol[i]["ColName"] + " AND \r\n";
                    sb.Append("@w_" + dvCol[i]["ColName"] + " " + dvCol[i]["ColType"] + (dvCol[i]["ColLength"].ToString() != "" ? "(" + dvCol[i]["ColLength"].ToString() + ")" : "") + ",\r\n");
                }
            }
            sb.Append("AS \r\n");
            sb.Append("BEGIN \r\n");
            sb.Append("    DELETE " + tableName + "\r\n");
            sb.Append("    WHERE \r\n" + whereParams + "");
            sb.Append("END");
            result = sb.ToString();
            return result;
        }
    }
}
