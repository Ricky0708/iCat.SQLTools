using iCat.DB.Client.Factory.Interfaces;
using iCat.SQLTools.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iCat.SQLTools.Shareds.Enums;
using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.OpenXmlFormats;
using NPOI.SS.Formula.PTG;
using iCat.SQLTools.Repositories.Enums;

namespace iCat.SQLTools.Repositories.Implements
{
    public class MSSQLSchemaRepository : ISchemaRepository
    {

        public ConnectionType ConnectionType => ConnectionType.MSSQL;

        private readonly IConnectionFactory _factory;

        public MSSQLSchemaRepository(IConnectionFactory factory)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public DataSet GetDatasetFromSQL()
        {
            var ds = new DataSet();
            try
            {
                var tables = GetTables();
                var columns = GetColumns();
                var fks = GetFks();
                var indexes = GetIndexes();
                var spsAndFuncs = GetSpsAndFuncs();
                var inputParams = GetInputParams();
                var outputParams = GetOutputParams(spsAndFuncs);
                ds.Tables.AddRange(new[] { tables, columns, fks, indexes, spsAndFuncs, inputParams, outputParams });

                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable GetTables()
        {
            var script = @"
							   SELECT 
								tbl.table_name AS TableName, 
								prop.value AS TableDescription,
								tbl.table_type AS TableType
							  FROM information_schema.tables tbl
							  LEFT JOIN sys.extended_properties prop 
								ON prop.major_id = object_id(tbl.table_schema + '.' + tbl.table_name) 
								AND prop.minor_id = 0
								AND prop.name = 'MS_Description' 
							  WHERE tbl.table_type = 'base table' OR tbl.table_type = 'VIEW' 
							  ORDER BY TableName";
            return ExecuteGetDataTable(script, Consts.strTables);
        }

        public DataTable GetColumns()
        {
            var script = @"SELECT
								a.TABLE_NAME                as TableName,
								(SELECT 'true' FROM sys.identity_columns c WHERE OBJECT_ID(a.TABLE_NAME) = c.object_id AND b.COLUMN_NAME  = c.name) as IsIdentity,
								b.COLUMN_NAME               as ColName,
								b.DATA_TYPE                 as ColType,
								b.CHARACTER_MAXIMUM_LENGTH  as ColLength,
								b.COLUMN_DEFAULT            as DefaultValue,
								b.COLLATION_NAME            as 'CollationName',
								(CASE b.IS_NULLABLE WHEN 'YES' THEN 1 ELSE 0 END) as IsNullable,
								(
									SELECT 1 
									FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE
									WHERE 
										OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + CONSTRAINT_NAME), 'IsPrimaryKey') = 1
										AND TABLE_NAME = a.TABLE_NAME AND COLUMN_NAME=b.COLUMN_NAME 
								) AS IsPK,
								(
									SELECT
										value
									FROM
										fn_listextendedproperty (NULL, 'schema', 'dbo', 'table', 
																 a.TABLE_NAME, 'column', default)
									WHERE
										name='MS_Description' 
										and objtype='COLUMN' 
										and objname Collate Chinese_Taiwan_Stroke_CI_AS=b.COLUMN_NAME
								) as ColDescription,
								ordinal_position
							  FROM
								INFORMATION_SCHEMA.TABLES  a
								LEFT JOIN INFORMATION_SCHEMA.COLUMNS b ON (a.TABLE_NAME=b.TABLE_NAME)
							  WHERE
								TABLE_TYPE='BASE TABLE'
							   UNION ALL
							   SELECT
								a.TABLE_NAME                as TableName,
								(SELECT 'true' FROM sys.identity_columns c WHERE OBJECT_ID(a.TABLE_NAME) = c.object_id AND b.COLUMN_NAME  = c.name) as IsIdentity,
								b.COLUMN_NAME               as ColName,
								b.DATA_TYPE                 as ColType,
								b.CHARACTER_MAXIMUM_LENGTH  as ColLength,
								b.COLUMN_DEFAULT            as DefaultValue,
								b.COLLATION_NAME            as 'CollationName',
								(CASE b.IS_NULLABLE WHEN 'YES' THEN 1 ELSE 0 END) as IsNullable,
								0 AS IsPK,
								'not support' as ColDescription,
								ordinal_position
								 FROM
								INFORMATION_SCHEMA.VIEWS  a
								LEFT JOIN INFORMATION_SCHEMA.COLUMNS b ON (a.TABLE_NAME=b.TABLE_NAME)
								 ORDER BY
								a.TABLE_NAME, ordinal_position";
            return ExecuteGetDataTable(script, Consts.strColumns);
        }

        public DataTable GetFks()
        {
            string script = @"SELECT  
								fk.name,
								OBJECT_NAME(fk.parent_object_id) 'Parenttable',
								c1.name 'Parentcolumn',
								OBJECT_NAME(fk.referenced_object_id) 'Referencedtable',
								c2.name 'Referencedcolumn'
							  FROM 
								sys.foreign_keys fk
							  INNER JOIN 
								sys.foreign_key_columns fkc ON fkc.constraint_object_id = fk.object_id
							  INNER JOIN
								sys.columns c1 ON fkc.parent_column_id = c1.column_id AND fkc.parent_object_id = c1.object_id
							  INNER JOIN
								sys.columns c2 ON fkc.referenced_column_id = c2.column_id AND fkc.referenced_object_id = c2.object_id";
            return ExecuteGetDataTable(script, Consts.strFKs);
        }

        public DataTable GetIndexes()
        {
            var script = @"SELECT  ix.name as IndexName, t.name AS TableName, c.name AS ColName
											FROM    sys.indexes ix
													INNER JOIN sys.tables t ON ix.object_id = t.object_id
													INNER JOIN sys.index_columns ic ON ic.index_id = ix.index_id AND ic.object_id = ix.object_id
													INNER JOIN sys.columns c ON c.object_id = ix.object_id AND c.column_id = ic.column_id";
            return ExecuteGetDataTable(script, Consts.strIndexes);
        }

        public DataTable GetSpsAndFuncs()
        {
            var script = @"   SELECT SPECIFIC_NAME, ROUTINE_DEFINITION, ROUTINE_TYPE, DATA_TYPE 
												FROM information_schema.routines 
												ORDER BY SPECIFIC_NAME";
            return ExecuteGetDataTable(script, Consts.strSpsAndFuncs);
        }

        public DataTable GetInputParams()
        {
            string script = @"SELECT A.SPECIFIC_NAME, A.Parameter_Name, A.Data_Type, A.Character_Maximum_Length, A.Parameter_Mode 
										   FROM information_schema.PARAMETERS A
										   INNER JOIN information_schema.routines B ON A.SPECIFIC_NAME = B.SPECIFIC_NAME AND (B.ROUTINE_TYPE = 'PROCEDURE' OR B.ROUTINE_TYPE = 'FUNCTION')";
            return ExecuteGetDataTable(script, Consts.strInputParams);
        }

        public DataTable GetOutputParams(DataTable spAndFuncTable)
        {
            string script = GeneratScriptGetOutPutParam("") + " UNION ALL ";
            foreach (DataRow dr in spAndFuncTable.Rows)
            {
                script += GeneratScriptGetOutPutParam(dr["SPECIFIC_NAME"].ToString()!) + " UNION ALL ";
            }
            script = script.Substring(0, script.Length - 11);
            return ExecuteGetDataTable(script, Consts.strOutputParams);
        }

        public bool UpdateDescription(ref DataSet ds)
        {
            bool result = false;


            DataView dv = default;
            StringBuilder sbSQL = new StringBuilder();
            if (ds.Tables[Consts.strTables].GetChanges(DataRowState.Modified) != null)
            {
                dv = ds.Tables[Consts.strTables].GetChanges(DataRowState.Modified).DefaultView;
                if (dv != null && dv.Count > 0)
                {
                    dv.RowFilter = "TableType = '" + "VIEW" + "'";
                    sbSQL.Append(GeneratScriptUpdate(dv, "VIEW"));
                    dv.RowFilter = "TableType = '" + "BASE TABLE" + "'";
                    sbSQL.Append(GeneratScriptUpdate(dv, "TABLE"));
                }
            }
            if (ds.Tables[Consts.strColumns].GetChanges(DataRowState.Modified) != null)
            {
                dv = ds.Tables[Consts.strColumns].GetChanges(DataRowState.Modified).DefaultView;
                if (dv != null && dv.Count > 0)
                {
                    sbSQL.Append(GeneratScriptUpdate(dv, "COLUMN"));
                }
            }

            if (sbSQL.Length > 0)
            {
                _factory.GetConnection(ConnectionType.ToString()).ExecuteNonQuery(sbSQL.ToString(), null);
                ds.AcceptChanges();
                result = true;
            }

            return result;

        }

        #region script generator


        private string GeneratScriptGetOutPutParam(string name)
        {
            string script = string.Format("SELECT '{0}' AS SPECIFIC_NAME, Name, System_Type_Name, Error_Message FROM sys.dm_exec_describe_first_result_set('{0}',null,0)", name);
            return script;
        }

        private string GeneratScriptUpdate(DataView dv, string target)
        {

            SqlCommand cmd = new SqlCommand();
            string script = "";
            switch (target)
            {
                case "VIEW":
                    cmd = new SqlCommand(@"SELECT * 
												  FROM fn_listextendedproperty (NULL, 'schema', 'dbo', 'VIEW',@TableName, default, default)
												  WHERE
													name='MS_Description' AND 
													objtype = 'VIEW' AND
													objname = @objName");
                    break;
                case "TABLE":
                    cmd = new SqlCommand(@"SELECT * 
												  FROM fn_listextendedproperty (NULL, 'schema', 'dbo', 'TABLE',@TableName, default, default)
												  WHERE
													name='MS_Description' AND 
													objtype = 'TABLE' AND
													objname = @objName");
                    break;
                case "COLUMN":
                    cmd = new SqlCommand(@"SELECT * 
												  FROM fn_listextendedproperty (NULL, 'schema', 'dbo', 'TABLE',@TableName, 'COLUMN', default)
												  WHERE
													name='MS_Description' AND 
													objtype = 'COLUMN' AND
													objname = @objName");
                    break;
                default:
                    break;
            }

            var sqlParameters = new List<SqlParameter>();
            for (int i = 0; i < dv.Count; i++)
            {
                sqlParameters.Clear();
                cmd.Parameters.Clear();
                sqlParameters.Add(new SqlParameter("@TableName", dv[i]["TableName"].ToString()));
                string execFunName = "";
                string description = "";
                string tableName = "";

                sqlParameters.Add(new SqlParameter("@objName", target == "COLUMN" ? dv[i]["ColName"].ToString() : dv[i]["TableName"].ToString()));
                execFunName = _factory.GetConnection(ConnectionType.ToString()).ExecuteScalar(cmd.CommandText, sqlParameters.ToArray()) != null ? "EXECUTE sp_updateextendedproperty N'MS_Description', N'" : "EXECUTE sp_addextendedproperty N'MS_Description', N'";
                description = target == "COLUMN" ? dv[i]["ColDescription"].ToString().Replace("'", "") : dv[i]["TableDescription"].ToString().Replace("'", "");
                tableName = dv[i]["TableName"].ToString().Replace("'", "");

                switch (target)
                {
                    case "VIEW":
                    case "TABLE":
                        script += execFunName + description + "', N'SCHEMA', N'dbo', N'" + target + "', N'" + tableName + "', NULL, NULL ;";
                        break;
                    case "COLUMN":
                        script += execFunName + description + "', N'SCHEMA', N'dbo', N'TABLE', N'" + tableName + "', N'COLUMN', N'" + dv[i]["ColName"].ToString().Replace("'", "") + "' ;";
                        break;
                    default:
                        break;
                }
            }

            return script;
        }


        #endregion

        public DataTable ExecuteGetDataTable(string script, string dtName)
        {
            var dt = new DataTable(dtName);
            var conn = (SqlConnection)_factory.GetConnection(ConnectionType.ToString()).Connection;
            var da = new SqlDataAdapter(script, conn);
            da.SelectCommand.CommandTimeout = 999;
            da.Fill(dt);
            return dt;
        }

        public DataTable GetTableSchema(string script, string dtName)
        {
            var dt = new DataTable(dtName);
            var conn = (SqlConnection)_factory.GetConnection(ConnectionType.ToString()).Connection;
            var da = new SqlDataAdapter(script, conn);
            da.SelectCommand.CommandTimeout = 999;
            da.FillSchema(dt, SchemaType.Source);
            return dt;
        }
    }
}
