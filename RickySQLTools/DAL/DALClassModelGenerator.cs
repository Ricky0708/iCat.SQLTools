using Microsoft.SqlServer.Management.SqlParser.Parser;
using Newtonsoft.Json;
using NPOI.OpenXmlFormats.Dml.Diagram;
using RickySQLTools.Models;
using RickySQLTools.Utilitys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace RickySQLTools.DAL
{
    public class DALClassModelGenerator : DALBase
    {
        DAO dao;
        ShareUtility objUti = new ShareUtility();
        public bool CreateDataSet()
        {
            //DAL.DALTables objDAL = new DAL.DALTables();
            //_strConn = base.connString; //save the current db connection
            //dao = new DAO(_strConn);

            //if (objDAL.GetDatasetFromSQL())
            //{
            //    _dalDataset = objDAL._dalDataset;
            //    return true;
            //}
            //else
            //{
            //    ErrMsg = objDAL.ErrMsg;
            //    return false;
            //}
            if (DALBase._dalDataset == null) return false;
            return true;
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
            try
            {
                string defUsing = ShareUtility.GetSettings(SettingEnum.GetUsing).ToString() + "\r\n";
                string defNamespace = "namespace " + ShareUtility.GetSettings(SettingEnum.GetNamespace).ToString() + "\r\n";
                string body = "";
                bool defIncludeAttr = (bool)ShareUtility.GetSettings(SettingEnum.GetIncludeAttr);

                var selectClauses = sqlModel.SqlScript.SqlBatch.SqlSelectStatement.SqlSelectSpecification.SqlQuerySpecification.SqlSelectClause;
                var fromClauses = sqlModel.SqlScript.SqlBatch.SqlSelectStatement.SqlSelectSpecification.SqlQuerySpecification.SqlFromClause;

                var columns = GetColumns(selectClauses);
                var tables = GetTables(fromClauses);

                foreach (var col in columns)
                {
                    var summary = "";
                    var attr = "";
                    var isNullable = false;
                    var table = tables.FirstOrDefault(p => p.AliasName == col.SchemaName);
                    var colInfo = table == null ?
                        GetColumnInfo(tables.ToArray(), col.SrcColumnName) :
                        GetColumnInfo(table.TableName, col.SrcColumnName);
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
                        ShareUtility.RenameDbType(ShareUtility.RenameType(colInfo?.ItemArray[3]?.ToString() ?? col.ColumnType)) + (isNullable ? "?" : ""),
                        col.ColumnName,
                        (colInfo?.ItemArray[3]?.ToString() ?? col.ColumnType).ToLower() == "string" //item.DataType.Name.ToLower() == "string"
                        ? isNullable
                            ? ""
                            : " = \"\";"
                        : ""
                        );
                }

                body = body.Substring(0, body.Length - 2);
                result = defUsing + "\r\n" + defNamespace + "{\r\n    public class " + className + "\r\n    {\r\n" + body + "\r\n    }    \r\n}";
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
            }
            return result;
        }

        private List<StatementColumnModel> GetColumns(Sqlselectclause selectClauses)
        {
            var result = new List<StatementColumnModel>();
            foreach (var column in selectClauses.SqlSelectScalarExpression)
            {
                if (column.Sqlcolumnrefexpression != null)
                {
                    var col = new StatementColumnModel
                    {
                        ColumnName = string.IsNullOrEmpty(column.Alias) ? column.Sqlcolumnrefexpression.SqlObjectIdentifier.ObjectName : column.Alias,
                        SrcColumnName = column.Sqlcolumnrefexpression.SqlObjectIdentifier.ObjectName,
                    };
                    result.Add(col);
                }
                else if (column.SqlScalarRefExpression != null)
                {
                    var col = new StatementColumnModel
                    {
                        ColumnName = string.IsNullOrEmpty(column.Alias) ? column.SqlScalarRefExpression.SqlObjectIdentifier.ObjectName : column.Alias,
                        SchemaName = column.SqlScalarRefExpression.SqlObjectIdentifier.SchemaName,
                        SrcColumnName = column.SqlScalarRefExpression.SqlObjectIdentifier.ObjectName,
                    };
                    result.Add(col);
                }
                else if (column.SqlAggregateFunctionCallExpression != null)
                {
                    var col = new StatementColumnModel
                    {
                        ColumnName = string.IsNullOrEmpty(column.Alias) ? column.SqlAggregateFunctionCallExpression.SqlScalarRefExpression.SqlObjectIdentifier.ObjectName : column.Alias,
                        SchemaName = column.SqlAggregateFunctionCallExpression.SqlScalarRefExpression.SqlObjectIdentifier.SchemaName,
                        SrcColumnName = column.SqlAggregateFunctionCallExpression.SqlScalarRefExpression.SqlObjectIdentifier.ObjectName,
                    };
                    result.Add(col);
                }
                else if (column.SqlLiteralExpression != null)
                {
                    var col = new StatementColumnModel
                    {
                        ColumnName = string.IsNullOrEmpty(column.Alias) ? column.SqlIdentifier.Value : column.Alias,
                        ColumnType = column.SqlLiteralExpression.Type
                    };
                    result.Add(col);
                }
            }
            return result;
        }

        private List<StatementTableModel> GetTables(Sqlfromclause fromClauses)
        {
            var result = fromClauses.SqlQualifiedJoinTableExpression?.SqlTableRefExpression?.Select(p => new StatementTableModel
            {
                AliasName = p.Alias,
                TableName = p.ObjectIdentifier
            })?.ToList() ?? new List<StatementTableModel>();
            if (fromClauses.SqlTableRefExpression != null) result.Add(new StatementTableModel
            {
                AliasName = fromClauses.SqlTableRefExpression.Alias,
                TableName = fromClauses.SqlTableRefExpression.ObjectIdentifier
            });
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

        private DataRow GetColumnInfo(StatementTableModel[] tableNames, string colName)
        {
            DataTable dtColumnsTable = _dalDataset.Tables[strColumns];
            var colInfo = (from p in dtColumnsTable.AsEnumerable().Where(x => tableNames.Any(y => y.TableName == x.Field<string>("TableName")))
                           where p.Field<string>("ColName") == colName
                           select p).SingleOrDefault();
            return colInfo;
        }


    }
}
