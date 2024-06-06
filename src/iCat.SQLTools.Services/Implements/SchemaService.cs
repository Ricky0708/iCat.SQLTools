using iCat.SQLTools.Repositories.Interfaces;
using iCat.SQLTools.Services.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iCat.SQLTools.Repositories.Implements;
using iCat.SQLTools.Shareds.Enums;
using iCat.SQLTools.Services.Managers;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NPOI.SS.Formula.PTG;
using NPOI.OpenXmlFormats.Wordprocessing;
using iCat.SQLTools.Services.Models;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using iCat.SQLTools.Shareds.Shareds;
using MySqlX.XDevAPI.Common;
using System.Xml.XPath;
using iCat.SQLTools.Repositories.Enums;

namespace iCat.SQLTools.Services.Implements
{
    public class SchemaService : ISchemaService
    {
        public string Category => _category;
        private string _category;
        private readonly IEnumerable<ISchemaRepository> _repositories;
        public SchemaService(IEnumerable<ISchemaRepository> schemaRepositories)
        {
            _category = "";
            _repositories = schemaRepositories;
        }

        public DataSet GetDatasetFromDB(string key, ConnectionType connectionType)
        {
            var ds = new DataSet();
            ds = _repositories.First(p => p.ConnectionType == connectionType).GetDatasetFromSQL(key);

            DataRelation relCol = new DataRelation("MasterDetailCols", ds.Tables[Consts.strTables]!.Columns["TableName"]!, ds.Tables[Consts.strColumns]!.Columns["TableName"]!);
            ds.Relations.Add(relCol);
            //DataRelation relFK = new DataRelation("MasterDetailFKs", ds.Tables[dtTables].Columns["TableName"], ds.Tables[dtFKs].Columns["ParentTable"]);
            //ds.Relations.Add(relFK);

            DataRelation resIndex = new DataRelation("MasterDetailIndexes", ds.Tables[Consts.strTables]!.Columns["TableName"]!, ds.Tables[Consts.strIndexes]!.Columns["TableName"]!);
            ds.Relations.Add(resIndex);

            DataRelation relInputParam = new DataRelation("MasterDetailInputParams", ds.Tables[Consts.strSpsAndFuncs]!.Columns["SPECIFIC_NAME"]!, ds.Tables[Consts.strInputParams]!.Columns["SPECIFIC_NAME"]!);
            ds.Relations.Add(relInputParam);

            DataRelation resOutputParam = new DataRelation("MasterDetailOutputParams", ds.Tables[Consts.strSpsAndFuncs]!.Columns["SPECIFIC_NAME"]!, ds.Tables[Consts.strOutputParams]!.Columns["SPECIFIC_NAME"]!);
            ds.Relations.Add(resOutputParam);
            return ds;

        }

        public DataTable GetTableSchema(string key, ConnectionType connectionType, string sqlScript, string tableName)
        {
            var dt = _repositories.First(p => p.ConnectionType == connectionType).GetTableSchema(key, sqlScript, tableName);
            return dt;
        }

        public DataSet GetDatasetFromXml(string xmlString)
        {
            var ds = new DataSet();
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(xmlString);
            writer.Flush();
            stream.Position = 0;

            ds.ReadXml(stream);
            ds.AcceptChanges();
            return ds;

        }

        public string GenerateClassWithSummary(DataTable dtColumns, string @namespace, string @using, string className, string sqlScript)
        {
            var parserResult = Microsoft.SqlServer.Management.SqlParser.Parser.Parser.Parse(sqlScript);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(parserResult.Script.Xml);
            string json = JsonConvert.SerializeXmlNode(doc);
            var obj = JObject.Parse(json.Replace("@", ""));
            var dtColumn = dtColumns;
            var cols = GeneratorModelFromJObject(dtColumn, obj);

            var defUsing = @using + "\r\n";
            var defNamespace = @namespace + "\r\n";
            var body = "";
            foreach (var col in cols)
            {
                var summary = "";
                var attr = "";
                var isNullable = false;
                var colInfo = col.Tables == null ? null : GetColumnInfo(dtColumn, col.Tables, col.SrcColumnName);
                if (colInfo != null)
                {
                    summary = GetSummary(colInfo) + "\r\n";
                    isNullable = (int)colInfo["IsNullable"] == 1;
                }
                body += summary + attr + string.Format("        public {0} {1} {{ get; set; }} {2}\r\n",
                    (Convertor.ConvertDBTypeToCSharpType(colInfo?.ItemArray[3]?.ToString()) ?? Convertor.ConvertDBTypeToCSharpType(col.ColumnType)) + (isNullable ? "?" : ""),
                    col.ColumnName,
                    (colInfo?.ItemArray[3]?.ToString() ?? col.ColumnType).ToLower() == "string" //item.DataType.Name.ToLower() == "string"
                    ? isNullable
                        ? ""
                        : " = \"\";"
                    : ""
                    );
            }

            body = body.Substring(0, body.Length - 2);
            var result = defUsing + "\r\n" + defNamespace + "{\r\n    public class " + className + "\r\n    {\r\n" + body + "\r\n    }    \r\n}";
            return result;
        }

        public string GenerateClassWithoutSummary(DataTable dtTables, string @namespace, string @using, string className)
        {
            var sb = new StringBuilder();
            sb.AppendLine(@using);
            sb.AppendLine("");
            sb.AppendLine(@namespace);
            sb.AppendLine($"{{");
            sb.AppendLine($"     public class {className}");
            sb.AppendLine($"     {{");
            foreach (DataColumn col in dtTables.Columns)
            {
                sb.AppendLine($"        /// <summary>");
                sb.AppendLine($"        /// ");
                sb.AppendLine($"        /// </summary>");
                sb.AppendLine($"        public {Convertor.GetAlias(col.DataType)}{(col.AllowDBNull ? "?" : "")} {col.ColumnName} {{ get; set; }}");
                sb.AppendLine("");
            }
            sb.AppendLine($"    }}");
            sb.AppendLine($"}}");
            var result = sb.ToString();
            return result;
        }

        public string GenerateClassAssign(DataTable dtTables)
        {
            var sb = new StringBuilder();
            foreach (DataColumn col in dtTables.Columns)
            {
                var a = typeof(int);
                sb.AppendLine($"{dtTables.TableName}.{col.ColumnName} = p.{col.ColumnName};");
                sb.AppendLine($"");
            }
            return sb.ToString();
        }

        public string GenerateDapperScript(DataTable dtColumns, string tableName, ScriptKind scriptKind, ParameterType parameterType)
        {

            var result = "";
            switch (scriptKind)
            {
                case ScriptKind.Select: result = GenerateSelect(dtColumns, tableName, parameterType); break;
                case ScriptKind.Insert: result = GenerateInsert(dtColumns, tableName, parameterType); break;
                case ScriptKind.Update: result = GenerateUpdate(dtColumns, tableName, parameterType); break;
                case ScriptKind.Delete: result = GenerateDelete(dtColumns, tableName, parameterType); break;
            }

            return result;
        }

        public bool UpdateDescription(string key, ConnectionType connectionType, DataSet ds)
        {
            return _repositories.First(p => p.ConnectionType == connectionType).UpdateDescription(key, ref ds);
        }

        #region from dataset

        private List<StatementColumnWithTableModel> GeneratorModelFromJObject(DataTable dtColumn, JObject jObj)
        {
            try
            {
                var selectClauses = jObj["SqlScript"]!["SqlBatch"]!["SqlSelectStatement"]!["SqlSelectSpecification"]!["SqlQuerySpecification"]!["SqlSelectClause"]!;
                var fromClauses = jObj["SqlScript"]!["SqlBatch"]!["SqlSelectStatement"]!["SqlSelectSpecification"]!["SqlQuerySpecification"]!["SqlFromClause"]!;

                var columnWithTables = GetColumnsWithTable(dtColumn, selectClauses, fromClauses);

                return columnWithTables;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private List<StatementColumnWithTableModel> GetColumnsWithTable(DataTable dtColumn, JToken selectClauses, JToken fromClauses)
        {

            var tables = GetTables(fromClauses);

            var result = new List<StatementColumnWithTableModel>();
            if (selectClauses["SqlSelectStarExpression"] != null)
            {
                var expressions = selectClauses["SqlSelectStarExpression"]!;
                if (expressions.Type == JTokenType.Object)
                {
                    result.AddRange(ProcessSqlSelectStarExpression(expressions, dtColumn, tables.ToArray()));
                }
                else
                {
                    foreach (var expression in expressions)
                    {
                        result.AddRange(ProcessSqlSelectStarExpression(expression, dtColumn, tables.ToArray()));
                    }
                }
            }
            if (selectClauses["SqlSelectScalarExpression"] != null)
            {
                var expressions = selectClauses["SqlSelectScalarExpression"]!;
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

        private List<StatementTableModel> GetTables(JToken fromClauses)
        {
            var tables = new List<StatementTableModel>();
            var token = fromClauses;

            foreach (JProperty element in token.Children().Cast<JProperty>())
            {
                if (element.Name == "SqlQualifiedJoinTableExpression")
                {
                    tables.AddRange(GetTables(element.Value));
                }
                else if (element.Name == "SqlTableRefExpression")
                {
                    var tableRefExpressions = element.Value;
                    if (tableRefExpressions.Type == JTokenType.Object)
                    {
                        tables.Add(new StatementTableModel
                        {
                            AliasName = tableRefExpressions["Alias"]?.ToString(),
                            TableName = tableRefExpressions["ObjectIdentifier"]?.ToString()
                        });
                    }
                    else
                    {
                        tables.AddRange(tableRefExpressions.Select(p => new StatementTableModel
                        {
                            AliasName = p["Alias"]?.ToString(),
                            TableName = p["ObjectIdentifier"]?.ToString()
                        }));
                    }
                }
                else if (element.Name == "SqlDerivedTableExpression")
                {
                    var aliasName = element.Value["Alias"]?.ToString();
                    var ts = GetTables(element.Value["SqlQuerySpecification"]["SqlFromClause"]);
                    ts.ForEach(p => p.AliasName = aliasName);
                    tables.AddRange(ts);
                }
            }
            return tables;
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
                var columnTables = tables.Where(p => p.AliasName.ToLower() == schemaName.ToLower()).Select(p => p.TableName).ToArray();

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
                var columnTables = tables.Where(p => p.AliasName.ToLower() == schemaName.ToLower()).Select(p => p.TableName).ToArray();

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

        private StatementColumnWithTableModel[] ProcessSqlSelectStarExpression(JToken SqlSelectStarExpression, DataTable dtColumn, StatementTableModel[] tables)
        {
            var result = new List<StatementColumnWithTableModel>();
            var schemaName = SqlSelectStarExpression["Qualifier"]?.ToString();
            var columnTables = schemaName == null ? tables.Select(p => p.TableName).ToArray() : tables.Where(p => p.AliasName.ToLower() == schemaName.ToLower()).Select(p => p.TableName).ToArray();

            DataTable dtColumnsTable = dtColumn;
            var colInfos = (from p in dtColumnsTable.AsEnumerable()
                            where columnTables.Any(x => x.ToLower() == p.Field<string>("TableName").ToLower())
                            select p);
            foreach (var col in colInfos)
            {
                result.Add(new StatementColumnWithTableModel
                {
                    ColumnName = col.Field<string>("ColName")!,
                    SrcColumnName = col.Field<string>("ColName")!,
                    Tables = new[] { col.Field<string>("TableName")! }
                });
            }
            return result.ToArray();
        }

        private DataRow GetColumnInfo(DataTable dt, string[] tableNames, string colName)
        {

            DataTable dtColumnsTable = dt;
            var colInfo2 = (from p in dtColumnsTable.AsEnumerable()
                            where p.Field<string>("ColName").ToLower() == colName.ToLower() && tableNames.Any(x => x.ToLower() == p.Field<string>("TableName").ToLower())
                            select p).ToList();
            var colInfo = (from p in dtColumnsTable.AsEnumerable()
                           where p.Field<string>("ColName").ToLower() == colName.ToLower() && tableNames.Any(x => x.ToLower() == p.Field<string>("TableName").ToLower())
                           select p).Single();
            return colInfo;

        }

        #endregion

        #region Select, Insert, Update, Delete script

        private string GenerateSelect(DataTable dtColumns, string tableName, ParameterType parameterType)
        {
            string result = "";
            StringBuilder sb = new StringBuilder();
            DataView dvCol = dtColumns.DefaultView;
            dvCol.RowFilter = "TableName='" + tableName + "'";
            string selectCols = "";
            string whereParams = "";
            string parameters = "var parameters = new DynamicParameters();\r\n";
            sb.Append("var sbSQL = new StringBuilder();\r\n");
            for (int i = 0; i < dvCol.Count; i++)
            {
                var colName = dvCol[i]["ColName"].ToString()!;
                var colType = dvCol[i]["ColType"].ToString()!;
                var colLength = dvCol[i]["ColLength"].ToString();

                if (i == dvCol.Count - 1)
                {
                    selectCols += "A." + colName;
                    whereParams += $"sbSQL.Append(\"    A.{colName} = {ConvertParameterString(colName, parameterType)}\"); \r\n";
                    parameters += $"parameters.Add(\"{colName}\", {colName}, {Convertor.ConvertToCSharpDbType(colType)}, ParameterDirection.Input{(string.IsNullOrEmpty(colLength) ? "" : $", {colLength}")});\r\n";
                }
                else
                {
                    selectCols += "A." + colName + ", ";
                    whereParams += $"sbSQL.Append(\"    A.{colName} = {ConvertParameterString(colName.ToString()!, parameterType)} AND \"); \r\n";
                    parameters += $"parameters.Add(\"{colName}\", {colName}, {Convertor.ConvertToCSharpDbType(colType)}, ParameterDirection.Input{(string.IsNullOrEmpty(colLength) ? "" : $", {colLength}")});\r\n";
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

        public string GenerateInsert(DataTable dtColumns, string tableName, ParameterType parameterType)
        {
            string result = "";
            StringBuilder sb = new StringBuilder();
            DataView dvCol = dtColumns.DefaultView;
            dvCol.RowFilter = "TableName='" + tableName + "'";
            string selectCols = "";
            string valueParams = "";
            string parameters = "var parameters = new DynamicParameters();\r\n";
            sb.Append("var sbSQL = new StringBuilder();\r\n");
            for (int i = 0; i < dvCol.Count; i++)
            {
                var colName = dvCol[i]["ColName"].ToString()!;
                var colType = dvCol[i]["ColType"].ToString()!;
                var colLength = dvCol[i]["ColLength"].ToString();

                if (i == dvCol.Count - 1)
                {
                    selectCols += colName;
                    valueParams += $"{ConvertParameterString(colName, parameterType)}";
                    parameters += $"parameters.Add(\"{colName}\", {colName}, {Convertor.ConvertToCSharpDbType(colType)}, ParameterDirection.Input{(string.IsNullOrEmpty(colLength) ? "" : $", {colLength}")});\r\n";
                }
                else
                {
                    selectCols += colName + ", ";
                    valueParams += $"{ConvertParameterString(colName, parameterType)}, ";
                    parameters += $"parameters.Add(\"{colName}\", {colName}, {Convertor.ConvertToCSharpDbType(colType)}, ParameterDirection.Input{(string.IsNullOrEmpty(colLength) ? "" : $", {colLength}")});\r\n";
                }
            }
            sb.Append($"    sbSQL.Append(\"INSERT INTO {tableName}({selectCols}) \");\r\n");
            sb.Append($"    sbSQL.Append(\"VALUES({valueParams}) \");\r\n");

            sb.Append(parameters);
            result = sb.ToString();
            return result;
        }

        public string GenerateUpdate(DataTable dtColumns, string tableName, ParameterType parameterType)
        {
            string result = "";
            StringBuilder sb = new StringBuilder();
            DataView dvCol = dtColumns.DefaultView;
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
                var colName = dvCol[i]["ColName"].ToString()!;
                var colType = dvCol[i]["ColType"].ToString()!;
                var colLength = dvCol[i]["ColLength"].ToString();
                if (dvCol[i]["IsIdentity"].ToString() != "true")
                {
                    if (i == dvCol.Count - 1)
                    {
                        updateParams += colName + " = " + $"{ConvertParameterString($"p_{colName}", parameterType)}" + " ";
                        p_parameters += $"parameters.Add(\"{$"p_{colName}"}\", {colName}, {Convertor.ConvertToCSharpDbType(colType)}, ParameterDirection.Input{(string.IsNullOrEmpty(colLength) ? "" : $", {colLength}")});\r\n";
                    }
                    else
                    {
                        updateParams += colName + " = " + $"{ConvertParameterString($"p_{colName}", parameterType)}" + ", ";
                        p_parameters += $"parameters.Add(\"{$"p_{colName}"}\", {colName}, {Convertor.ConvertToCSharpDbType(colType)}, ParameterDirection.Input{(string.IsNullOrEmpty(colLength) ? "" : $", {colLength}")});\r\n";
                    }
                }
                if (i == dvCol.Count - 1)
                {
                    whereParams += "         sbSQL.Append(\"    " + colName + " = " + $"{ConvertParameterString($"w_{colName}", parameterType)}" + "\");\r\n";
                    w_parameters += $"parameters.Add(\"{$"w_{colName}"}\", {colName}, {Convertor.ConvertToCSharpDbType(colType)}, ParameterDirection.Input{(string.IsNullOrEmpty(colLength) ? "" : $", {colLength}")});\r\n";
                }
                else
                {
                    whereParams += "         sbSQL.Append(\"    " + colName + " = " + $"{ConvertParameterString($"w_{colName}", parameterType)}" + " AND \");\r\n";
                    w_parameters += $"parameters.Add(\"{$"w_{colName}"}\", {colName}, {Convertor.ConvertToCSharpDbType(colType)}, ParameterDirection.Input{(string.IsNullOrEmpty(colLength) ? "" : $", {colLength}")});\r\n";
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

        public string GenerateDelete(DataTable dtColumns, string tableName, ParameterType parameterType)
        {
            return "";
        }

        private string ConvertParameterString(string parameter, ParameterType parameterType)
        {
            switch (parameterType)
            {
                case ParameterType.MSSQL: return $"@{parameter}";
                case ParameterType.MySQL: return $"?{parameter}";
                case ParameterType.ODBC: return $"?{parameter}?";
            }
            return "";
        }

        #endregion

    }
}
