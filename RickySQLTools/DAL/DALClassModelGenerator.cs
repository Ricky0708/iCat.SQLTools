using Newtonsoft.Json;
using RickySQLTools.Models;
using RickySQLTools.Utilitys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RickySQLTools.DAL
{
    public class DALClassModelGenerator : DALBase
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
            var parserResult = Microsoft.SqlServer.Management.SqlParser.Parser.Parser.Parse(script);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(parserResult.Script.Xml);
            string json = JsonConvert.SerializeXmlNode(doc);
            var sqlModel = JsonConvert.DeserializeObject<SQLStatementModel>(json.Replace("@", ""));




            return GeneratorModel(sqlModel, className);
        }

        private string GeneratorModel(SQLStatementModel sqlModel, string className)
        {
            string result = "";
            string defUsing = ShareUtility.GetSettings(SettingEnum.GetUsing).ToString() + "\r\n";
            string defNamespace = "namespace " + ShareUtility.GetSettings(SettingEnum.GetNamespace).ToString() + "\r\n";
            string body = "";
            bool defIncludeAttr = (bool)ShareUtility.GetSettings(SettingEnum.GetIncludeAttr);

            // 將 SqlTableRefExpression 拉平到join裡
            var selectClauses = sqlModel.SqlScript.SqlBatch.SqlSelectStatement.SqlSelectSpecification.SqlQuerySpecification.SqlSelectClause;
            var fromClauses = sqlModel.SqlScript.SqlBatch.SqlSelectStatement.SqlSelectSpecification.SqlQuerySpecification.SqlFromClause;
            if (fromClauses.SqlQualifiedJoinTableExpression?.SqlTableRefExpression == null)
                fromClauses.SqlQualifiedJoinTableExpression = new Sqlqualifiedjointableexpression { SqlTableRefExpression = new List<Sqltablerefexpression>() };
            if (fromClauses.SqlTableRefExpression != null) fromClauses.SqlQualifiedJoinTableExpression.SqlTableRefExpression.Add(fromClauses.SqlTableRefExpression);

            foreach (var selectCol in selectClauses.SqlSelectScalarExpression)
            {
                var srcColName = selectCol.SqlScalarRefExpression?.ColumnOrPropertyName ?? "";
                var colName = selectCol.Alias ?? selectCol.SqlScalarRefExpression.ColumnOrPropertyName;
                var colSchemaName = selectCol.SqlScalarRefExpression?.SqlObjectIdentifier?.SchemaName ?? "";
            }

            // TODO: 開發中

            foreach (var from in fromClauses.SqlQualifiedJoinTableExpression.SqlTableRefExpression)
            {
                var tableName = from.ObjectIdentifier;
                var aliasName = from.Alias;
                var selectColumns = selectClauses.SqlSelectScalarExpression.Where(p => p.SqlScalarRefExpression?.SqlObjectIdentifier.SchemaName == aliasName);
                foreach (var selectCol in selectColumns)
                {
                    var summary = "";
                    var attr = "";
                    var isNullable = false;
                    var srcColName = selectCol.SqlScalarRefExpression.ColumnOrPropertyName;
                    var colName = selectCol.Alias ?? selectCol.SqlScalarRefExpression.ColumnOrPropertyName;
                    var colInfo = GetColumnInfo(tableName, srcColName);
                    if (colInfo != null)
                    {
                        summary = GetSummary(colInfo) + "\r\n";
                        if (defIncludeAttr)
                        {
                            //attr = GetAttrib(item) + "\r\n";
                        }
                        isNullable = (int)colInfo["IsNullable"] == 1;
                    }
                    body += summary + attr + string.Format("        public {0} {1} {{ get; set; }} {2}\r\n",
                        ShareUtility.RenameDbType(ShareUtility.RenameType(colInfo.ItemArray[3].ToString())) + (isNullable ? "?" : ""),
                        colName,
                        colInfo.ItemArray[3].ToString().ToLower() == "string" //item.DataType.Name.ToLower() == "string"
                        ? isNullable
                            ? ""
                            : " = \"\";"
                        : ""
                        );


                }
            }


            //foreach (DataColumn item in dt.Columns)
            //{
            //    string attr = "";
            //    if (defIncludeAttr)
            //    {
            //        attr = GetAttrib(item) + "\r\n";
            //    }
            //    var isNullable = (int)GetColumnInfo(item)["IsNullable"] == 1;
            //    body += summary + attr + string.Format("        public {0} {1} {{ get; set; }} {2}\r\n",
            //        ShareUtility.RenameType(item.DataType.Name) + (isNullable ? "?" : ""),
            //        item.ColumnName,
            //        item.DataType.Name.ToLower() == "string"
            //        ? isNullable
            //            ? ""
            //            : " = \"\";"
            //        : ""
            //        );
            //}
            body = body.Substring(0, body.Length - 2);
            result = defUsing + "\r\n" + defNamespace + "{\r\n    public class " + className + "\r\n    {\r\n" + body + "\r\n    }    \r\n}";

            return result;
        }

        private string GetSummary(DataRow colInfo)
        {
            string result = "";

            if (colInfo != null)
            {
                result += $"\r\n        /// <summary>";
                result += $"\r\n        /// {colInfo["ColDescription"].ToString()}";
                result += $"\r\n        /// </summary>";
            }
            return result;
        }

        private DataRow GetColumnInfo(string tableName, string colName)
        {
            DataTable dtColumnsTable = _dalDataset.Tables[strColumns];
            var colInfo = (from p in dtColumnsTable.AsEnumerable()
                           where p.Field<string>("TableName") == tableName &&
                               p.Field<string>("ColName") == colName
                           select p).FirstOrDefault();
            return colInfo;
        }


    }
}
