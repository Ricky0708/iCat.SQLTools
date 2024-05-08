using Microsoft.SqlServer.Management.SqlParser.Metadata;
using Microsoft.SqlServer.Management.SqlParser.Parser;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NPOI.OpenXmlFormats.Dml.Diagram;
using NPOI.SS.Formula.Functions;
using RickySQLTools.Models;
using RickySQLTools.Utilitys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
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
            //var sqlModel = JsonConvert.DeserializeObject<SQLStatementModel>(json.Replace("@", ""));

            var obj = JObject.Parse(json.Replace("@", ""));
            //var n = obj["SqlScript"]["SqlBatch"]["SqlSelectStatement"]["SqlSelectSpecification"]["SqlQuerySpecification"]["SqlSelectClause"];

            return GeneratorModelFromJObject(obj, className);
        }

        private string GeneratorModelFromJObject(JObject jObj, string className)
        {
            string result = "";
            try
            {
                string defUsing = ShareUtility.GetSettings(SettingEnum.GetUsing).ToString() + "\r\n";
                string defNamespace = "namespace " + ShareUtility.GetSettings(SettingEnum.GetNamespace).ToString() + "\r\n";
                string body = "";
                bool defIncludeAttr = (bool)ShareUtility.GetSettings(SettingEnum.GetIncludeAttr);

                var selectClauses = jObj["SqlScript"]["SqlBatch"]["SqlSelectStatement"]["SqlSelectSpecification"]["SqlQuerySpecification"]["SqlSelectClause"];
                var fromClauses = jObj["SqlScript"]["SqlBatch"]["SqlSelectStatement"]["SqlSelectSpecification"]["SqlQuerySpecification"]["SqlFromClause"];

                var columnWithTables = GetColumnsWithTable(selectClauses, fromClauses);

                foreach (var col in columnWithTables)
                {
                    var summary = "";
                    var attr = "";
                    var isNullable = false;
                    var colInfo = col.Tables == null ? null : GetColumnInfo(col.Tables, col.SrcColumnName);
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

        private List<StatementColumnWithTableModel> GetColumnsWithTable(JToken selectClauses, JToken fromClauses)
        {

            var tables = fromClauses["SqlQualifiedJoinTableExpression"]?["SqlTableRefExpression"]?.Select(p => new StatementTableModel
            {
                AliasName = p["Alias"].ToString(),
                TableName = p["ObjectIdentifier"].ToString()
            })?.ToList() ?? new List<StatementTableModel>();
            if (fromClauses["SqlTableRefExpression"] != null) tables.Add(new StatementTableModel
            {
                AliasName = fromClauses["SqlTableRefExpression"]["Alias"]?.ToString(),
                TableName = fromClauses["SqlTableRefExpression"]["ObjectIdentifier"]?.ToString()
            });

            var result = new List<StatementColumnWithTableModel>();
            if (selectClauses["SqlSelectStarExpression"] != null)
            {
                var expressions = selectClauses["SqlSelectStarExpression"];
                if (expressions.Type == JTokenType.Object)
                {
                    var schemaName = expressions["Qualifier"]?.ToString();
                    var columnTables = schemaName == null ? tables.Select(p => p.TableName).ToArray() : tables.Where(p => p.AliasName == schemaName).Select(p => p.TableName).ToArray();

                    DataTable dtColumnsTable = _dalDataset.Tables[strColumns];
                    var colInfos = (from p in dtColumnsTable.AsEnumerable()
                                    where columnTables.Any(x => x == p.Field<string>("TableName"))
                                    select p);
                    foreach (var col in colInfos)
                    {
                        result.Add(new StatementColumnWithTableModel
                        {
                            ColumnName = col.Field<string>("ColName"),
                            SrcColumnName = col.Field<string>("ColName"),
                            Tables = new[] { col.Field<string>("TableName") }
                        });
                    }
                }
                else
                {
                    foreach (var expression in expressions)
                    {
                        var schemaName = expression["Qualifier"]?.ToString();
                        var columnTables = schemaName == null ? tables.Select(p => p.TableName).ToArray() : tables.Where(p => p.AliasName == schemaName).Select(p => p.TableName).ToArray();

                        DataTable dtColumnsTable = _dalDataset.Tables[strColumns];
                        var colInfos = (from p in dtColumnsTable.AsEnumerable()
                                        where columnTables.Any(x => x == p.Field<string>("TableName"))
                                        select p);
                        foreach (var col in colInfos)
                        {
                            result.Add(new StatementColumnWithTableModel
                            {
                                ColumnName = col.Field<string>("ColName"),
                                SrcColumnName = col.Field<string>("ColName"),
                                Tables = new[] { col.Field<string>("TableName") }
                            });
                        }
                    }
                }
            }
            if (selectClauses["SqlSelectScalarExpression"] != null)
            {
                var expressions = selectClauses["SqlSelectScalarExpression"];
                if (expressions.Type == JTokenType.Object)
                {
                    result.Add(ProcessSqlSelectScalarExpression(expressions, tables.ToArray()));
                }
                else
                {
                    foreach (var expression in expressions)
                    {
                        result.Add(ProcessSqlSelectScalarExpression(expression, tables.ToArray()));
                    }
                }
            }
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

        private StatementColumnWithTableModel ProcessSqlSelectScalarExpression(JToken SqlSelectScalarExpression, StatementTableModel[] tables)
        {
            var result = default(StatementColumnWithTableModel);
            if (SqlSelectScalarExpression["SqlColumnRefExpression"] != null)
            {
                var columnName = SqlSelectScalarExpression["Alias"] == null ? SqlSelectScalarExpression["SqlColumnRefExpression"]["SqlObjectIdentifier"]["ObjectName"].ToString() : SqlSelectScalarExpression["Alias"].ToString();
                var srcColumnName = SqlSelectScalarExpression["SqlColumnRefExpression"]["SqlObjectIdentifier"]["ObjectName"].ToString();
                var columnTables = tables.Select(p => p.TableName).ToArray();
                result = new StatementColumnWithTableModel
                {
                    ColumnName = columnName,
                    SrcColumnName = srcColumnName,
                    Tables = columnTables
                };
            }
            else if (SqlSelectScalarExpression["SqlScalarRefExpression"] != null)
            {
                var columnName = SqlSelectScalarExpression["Alias"] == null ? SqlSelectScalarExpression["SqlScalarRefExpression"]["SqlObjectIdentifier"]["ObjectName"].ToString() : SqlSelectScalarExpression["Alias"].ToString();
                var schemaName = SqlSelectScalarExpression["SqlScalarRefExpression"]["SqlObjectIdentifier"]["SchemaName"].ToString();
                var srcColumnName = SqlSelectScalarExpression["SqlScalarRefExpression"]["SqlObjectIdentifier"]["ObjectName"].ToString();
                var columnTables = tables.Where(p => p.AliasName == schemaName).Select(p => p.TableName).ToArray();

                result = new StatementColumnWithTableModel
                {
                    ColumnName = columnName,
                    SrcColumnName = srcColumnName,
                    Tables = columnTables
                };
            }
            else if (SqlSelectScalarExpression["SqlAggregateFunctionCallExpression"] != null)
            {
                var columnName = SqlSelectScalarExpression["Alias"] == null ? SqlSelectScalarExpression["SqlAggregateFunctionCallExpression"]["SqlScalarRefExpression"]["SqlObjectIdentifier"]["ObjectName"].ToString() : SqlSelectScalarExpression["Alias"].ToString();
                var schemaName = SqlSelectScalarExpression["SqlAggregateFunctionCallExpression"]["SqlScalarRefExpression"]["SqlObjectIdentifier"]["SchemaName"].ToString();
                var srcColumnName = SqlSelectScalarExpression["SqlAggregateFunctionCallExpression"]["SqlScalarRefExpression"]["SqlObjectIdentifier"]["ObjectName"].ToString();
                var columnTables = tables.Where(p => p.AliasName == schemaName).Select(p => p.TableName).ToArray();

                result = new StatementColumnWithTableModel
                {
                    ColumnName = columnName,
                    SrcColumnName = srcColumnName,
                    Tables = columnTables
                };
            }
            else if (SqlSelectScalarExpression["SqlLiteralExpression"] != null)
            {
                var columnName = SqlSelectScalarExpression["Alias"] == null ? SqlSelectScalarExpression["SqlIdentifier"].ToString() : SqlSelectScalarExpression["Alias"].ToString();
                var columnType = SqlSelectScalarExpression["SqlLiteralExpression"]["Type"].ToString();
                result = new StatementColumnWithTableModel
                {
                    ColumnName = columnName,
                    ColumnType = columnType
                };
            }
            return result;
        }

        private DataRow GetColumnInfo(string[] tableNames, string colName)
        {
            DataTable dtColumnsTable = _dalDataset.Tables[strColumns];
            var colInfo = (from p in dtColumnsTable.AsEnumerable()
                           where p.Field<string>("ColName") == colName && tableNames.Any(x => x == p.Field<string>("TableName"))
                           select p).SingleOrDefault();
            return colInfo;
        }


    }
}
