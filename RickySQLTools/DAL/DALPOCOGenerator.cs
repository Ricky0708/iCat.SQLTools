using NPOI.OpenXmlFormats.Dml.Diagram;
using NPOI.SS.Formula.Functions;
using RickySQLTools.Utilitys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickySQLTools.DAL
{
    public class DALPOCOGenerator : DALBase
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

        public string GenerateFromScript(string className, string script)
        {
            DataTable dt = new DataTable();
            dt = dao.ReadSQLUseAdapter(script, "");
            if (dt == null)
            {
                ErrMsg = dao.ErrMsg;
                return "";
            }
            else
            {
                dt.TableName = className;
                return GeneratorModel(dt, className);
            }

        }

        public bool GenerateFromDB(DataSet ds, string path)
        {
            bool result = true;
            DataTable dtTables = ds.Tables[strTables];
            foreach (DataRow item in dtTables.Rows)
            {
                string script = GenerateScript(item["TableName"].ToString());
                string modelClass = GeneratorModel(dao.ReadSQLUseAdapter(script, ""), item["TableName"].ToString());
                if (!objUti.WriteToFile(path + "\\" + item["TableName"].ToString() + ".cs", modelClass))
                {
                    ErrMsg = objUti.ErrMsg;
                    return false;
                }
            }
            return result;
        }

        public string GenerateScript(string tableName)
        {
            return "SELECT TOP 1 * FROM " + tableName;
        }


        public bool CheckScriptNotError(string script)
        {
            DataTable dt = dao.ReadSQLSchemaUseAdapter(script, "test");
            if (dt != null)
            {
                return true;
            }
            else
            {
                ErrMsg = dao.ErrMsg;
                return false;
            }
        }

        public bool GenerateCRptXsd(DataTable dtScripts, string fileName)
        {
            DataSet ds = new DataSet();
            foreach (DataRow row in dtScripts.Rows)
            {
                DataTable dt = dao.ReadSQLSchemaUseAdapter(row["Script"].ToString(), row["ScriptName"].ToString());
                if (dt == null)
                {
                    ErrMsg = dao.ErrMsg;
                    return false;
                }
                else
                {
                    ds.Tables.Add(dt);
                }
            }
            ds.WriteXml(fileName, XmlWriteMode.WriteSchema);
            return true;
        }
        public string GeneratePOCOFromSP(string spName)
        {
            var script = @"SELECT A.SPECIFIC_NAME, A.Parameter_Name, A.Data_Type, A.Character_Maximum_Length, A.Parameter_Mode 
										   FROM information_schema.PARAMETERS A
										   INNER JOIN information_schema.routines B ON A.SPECIFIC_NAME = B.SPECIFIC_NAME AND (B.ROUTINE_TYPE = 'PROCEDURE' OR B.ROUTINE_TYPE = 'FUNCTION')
										   WHERE A.SPECIFIC_NAME = '" + spName + "'";

            string modelClass = GeneratorModelForSp(dao.ReadSQLUseAdapter(script, ""), spName);
            return modelClass;
        }

        #region private method
        private string GeneratorModelForSp(DataTable dt, string tableName)
        {
            string result = "";
            string defUsing = ShareUtility.GetSettings(SettingEnum.GetUsing).ToString() + "\r\n";
            string defNamespace = "namespace " + ShareUtility.GetSettings(SettingEnum.GetNamespace).ToString() + "\r\n";
            string body = "";
            bool defIncludeAttr = (bool)ShareUtility.GetSettings(SettingEnum.GetIncludeAttr);


            foreach (DataRow item in dt.Rows)
            {
                string attr = "";
                //TODO:model validate attr
                //if (defIncludeAttr)
                //{
                //    attr = GetAttrib(item) + "\r\n";
                //}
                body += attr + string.Format("        public {0} {1} {{ get; set; }}\r\n", ShareUtility.RenameDbType(item["Data_Type"].ToString()), item["Parameter_Name"].ToString().Replace("@", ""));
            }
            body = body.Substring(0, body.Length - 2);
            result = defUsing + "\r\n" + defNamespace + "{\r\n    public class " + tableName + "\r\n    {\r\n" + body + "\r\n    }    \r\n}";

            return result;
        }
        private string GeneratorModel(DataTable dt, string tableName)
        {
            string result = "";
            string defUsing = ShareUtility.GetSettings(SettingEnum.GetUsing).ToString() + "\r\n";
            string defNamespace = "namespace " + ShareUtility.GetSettings(SettingEnum.GetNamespace).ToString() + "\r\n";
            string body = "";
            bool defIncludeAttr = (bool)ShareUtility.GetSettings(SettingEnum.GetIncludeAttr);


            foreach (DataColumn item in dt.Columns)
            {
                string attr = "";
                var summary = GetSummary(item) + "\r\n";
                if (defIncludeAttr)
                {
                    attr = GetAttrib(item) + "\r\n";
                }
                var isNullable = (int)GetColumnInfo(item)["IsNullable"] == 1;
                body += summary + attr + string.Format("        public {0} {1} {{ get; set; }} {2}\r\n",
                    ShareUtility.RenameType(item.DataType.Name) + (isNullable ? "?" : ""),
                    item.ColumnName,
                    item.DataType.Name.ToLower() == "string"
                    ? isNullable
                        ? ""
                        : " = \"\";"
                    : ""
                    );
            }
            body = body.Substring(0, body.Length - 2);
            result = defUsing + "\r\n" + defNamespace + "{\r\n    public class " + tableName + "\r\n    {\r\n" + body + "\r\n    }    \r\n}";

            return result;
        }

        private string GetAttrib(DataColumn col)
        {
            string result = "";
            DataTable dtColumnsTable = _dalDataset.Tables[strColumns];
            var colInfo = GetColumnInfo(col);

            if (colInfo != null)
            {
                if (col.DataType == typeof(string))
                {
                    result += "\r\n        [MaxLength(" + colInfo["ColLength"] + ")]";
                }
                if ((int)colInfo["IsNullable"] == 0)
                {
                    result += "\r\n        [Required]";
                }
            }
            return result;
        }

        private string GetSummary(DataColumn col)
        {
            string result = "";
            DataTable dtColumnsTable = _dalDataset.Tables[strColumns];
            var colInfo = GetColumnInfo(col);

            if (colInfo != null)
            {
                result += $"\r\n        /// <summary>";
                result += $"\r\n        /// {colInfo["ColDescription"].ToString()}";
                result += $"\r\n        /// </summary>";
            }
            return result;
        }

        private DataRow GetColumnInfo(DataColumn col)
        {
            DataTable dtColumnsTable = _dalDataset.Tables[strColumns];
            var colInfo = (from p in dtColumnsTable.AsEnumerable()
                           where p.Field<string>("TableName") == col.Table.TableName &&
                               p.Field<string>("ColName") == col.ColumnName
                           select p).FirstOrDefault();
            return colInfo;
        }
        #endregion

    }
}
