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
            dt = dao.ReadSQLUseAdapter(script);
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
                body += attr + string.Format("        public {0} {1} {{ get; set; }}\r\n", item.DataType.Name, item.ColumnName);
            }
            body = body.Substring(0, body.Length - 4);
            result = defUsing + "\r\n" + defNamespace + "{\r\n    public class " + tableName + "\r\n    {\r\n" + body + "\r\n    }    \r\n}";

            return result;
        }

        private string GetAttrib(DataColumn col)
        {
            string result = "";
            DataTable dtColumns = dalDataset.Tables["Columns"];
            var colInfo = (from p in dtColumns.AsEnumerable()
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
    }
}
