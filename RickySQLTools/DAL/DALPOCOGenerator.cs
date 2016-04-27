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
                dalDataset = objDAL.dalDataset;
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

        #region private method
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
                if (defIncludeAttr)
                {
                    attr = GetAttrib(item) + "\r\n";
                }
                body += attr + string.Format("        public {0} {1} {{ get; set; }}\r\n", RenameType(item.DataType.Name), item.ColumnName);
            }
            body = body.Substring(0, body.Length - 2);
            result = defUsing + "\r\n" + defNamespace + "{\r\n    public class " + tableName + "\r\n    {\r\n" + body + "\r\n    }    \r\n}";

            return result;
        }

        private string GetAttrib(DataColumn col)
        {
            string result = "";
            DataTable dtColumnsTable = dalDataset.Tables[strColumns];
            var colInfo = (from p in dtColumnsTable.AsEnumerable()
                           where p.Field<string>("TableName") == col.Table.TableName &&
                               p.Field<string>("ColName") == col.ColumnName
                           select p).FirstOrDefault();

            if (colInfo != null)
            {
                if (col.DataType == typeof(string))
                {
                    result += "\r\n        [MaxLength(" + colInfo["ColLength"] + ")]";
                }
                if ((int)colInfo["IsNullable"] == 0)
                {
                    result += "\r\n        [required]";
                }
            }
            return result;
        }

        private string RenameType(string intName)
        {
            string result = "";
            switch (intName.ToUpper())
            {
                case "BOOLEAN":
                    result = "bool";
                    break;
                case "STRING":
                    result = "string";
                    break;
                case "DATETIME":
                    result = "DateTime";
                    break;
                case "INT32":
                    result = "int";
                    break;
                case "INT64":
                    result = "long";
                    break;
                default:
                    //the others not implement yet !
                    result = intName;
                    break;
            }
            return result;
        }
        #endregion

    }
}
