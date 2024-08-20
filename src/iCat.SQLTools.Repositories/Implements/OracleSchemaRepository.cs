using iCat.DB.Client.Factory.Interfaces;
using iCat.SQLTools.Repositories.Enums;
using iCat.SQLTools.Repositories.Interfaces;
using iCat.SQLTools.Shareds.Enums;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Text;

namespace iCat.SQLTools.Repositories.Implements
{
    public class OracleSchemaRepository : ISchemaRepository
    {
        public ConnectionType ConnectionType => ConnectionType.Oracle;

        private readonly IConnectionFactory _factory;

        public OracleSchemaRepository(IConnectionFactory factory)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public DataSet GetDatasetFromSQL(string key)
        {
            var ds = new DataSet();
            try
            {
                var tables = GetTables(key);
                var columns = GetColumns(key);
                var fks = GetFks(key);
                var indexes = GetIndexes(key);
                var spsAndFuncs = GetSpsAndFuncs(key);
                var inputParams = GetInputParams(key);
                var outputParams = GetOutputParams(key, spsAndFuncs);
                ds.Tables.AddRange(new[] { tables, columns, fks, indexes, spsAndFuncs, inputParams, outputParams });

                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable GetTables(string key)
        {
            var sbSQL = new StringBuilder();
            sbSQL.Append("SELECT ");
            sbSQL.Append("    tbl.TABLE_NAME AS TableName, ");
            sbSQL.Append("    comments.COMMENTS AS TableDescription, ");
            sbSQL.Append("    'TABLE' AS TableType ");
            sbSQL.Append("FROM all_tables tbl ");
            sbSQL.Append("LEFT JOIN all_tab_comments comments ON tbl.OWNER = comments.OWNER AND tbl.TABLE_NAME = comments.TABLE_NAME ");
            sbSQL.Append("WHERE tbl.OWNER = USER ");
            sbSQL.Append("UNION ALL ");
            sbSQL.Append("SELECT ");
            sbSQL.Append("    vw.VIEW_NAME AS TableName, ");
            sbSQL.Append("    comments.COMMENTS AS TableDescription, ");
            sbSQL.Append("    'VIEW' AS TableType ");
            sbSQL.Append("FROM all_views vw ");
            sbSQL.Append("LEFT JOIN all_tab_comments comments ON vw.OWNER = comments.OWNER AND vw.VIEW_NAME = comments.TABLE_NAME ");
            sbSQL.Append("WHERE vw.OWNER = USER ");
            sbSQL.Append("ORDER BY TableName ");
            return ExecuteGetDataTable(key, sbSQL.ToString(), Consts.strTables);
        }

        public DataTable GetColumns(string key)
        {
            var sbSQL = new StringBuilder();
            sbSQL.Append("SELECT ");
            sbSQL.Append("    A.OWNER AS TableSchema, ");
            sbSQL.Append("    A.TABLE_NAME AS TableName, ");
            sbSQL.Append("    CASE WHEN ID.COLUMN_NAME IS NOT NULL THEN 1 ELSE 0 END AS IsIdentity, ");
            sbSQL.Append("    A.COLUMN_NAME AS ColName, ");
            sbSQL.Append("    A.DATA_TYPE AS ColType, ");
            sbSQL.Append("    A.DATA_LENGTH AS ColLength, ");
            sbSQL.Append("    A.DATA_DEFAULT AS DefaultValue, ");
            sbSQL.Append("    NULL AS CollationName, ");
            sbSQL.Append("    CASE WHEN A.NULLABLE = 'Y' THEN 1 ELSE 0 END AS IsNullable, ");
            sbSQL.Append("    CASE WHEN D.CONSTRAINT_TYPE = 'P' THEN 1 ELSE NULL END AS IsPK, ");
            sbSQL.Append("    C.COMMENTS AS ColDescription, ");
            sbSQL.Append("    A.COLUMN_ID AS ordinal_position ");
            sbSQL.Append("FROM ");
            sbSQL.Append("    ALL_TAB_COLUMNS A ");
            sbSQL.Append("LEFT JOIN ");
            sbSQL.Append("    ALL_COL_COMMENTS C ON A.OWNER = C.OWNER AND A.TABLE_NAME = C.TABLE_NAME AND A.COLUMN_NAME = C.COLUMN_NAME ");
            sbSQL.Append("LEFT JOIN ");
            sbSQL.Append("    (SELECT ");
            sbSQL.Append("         UCC.OWNER, ");
            sbSQL.Append("         UCC.TABLE_NAME, ");
            sbSQL.Append("         UCC.COLUMN_NAME, ");
            sbSQL.Append("         UC.CONSTRAINT_TYPE ");
            sbSQL.Append("     FROM ");
            sbSQL.Append("         ALL_CONS_COLUMNS UCC ");
            sbSQL.Append("     JOIN ");
            sbSQL.Append("         ALL_CONSTRAINTS UC ON UCC.CONSTRAINT_NAME = UC.CONSTRAINT_NAME ");
            sbSQL.Append("     WHERE ");
            sbSQL.Append("         UC.CONSTRAINT_TYPE = 'P') D ");
            sbSQL.Append("    ON A.OWNER = D.OWNER AND A.TABLE_NAME = D.TABLE_NAME AND A.COLUMN_NAME = D.COLUMN_NAME ");
            sbSQL.Append("LEFT JOIN ");
            sbSQL.Append("    ALL_TAB_IDENTITY_COLS ID ON A.OWNER = ID.OWNER AND A.TABLE_NAME = ID.TABLE_NAME AND A.COLUMN_NAME = ID.COLUMN_NAME ");
            sbSQL.Append("WHERE ");
            sbSQL.Append("    A.OWNER = USER ");
            return ExecuteGetDataTable(key, sbSQL.ToString(), Consts.strColumns);
        }

        public DataTable GetFks(string key)
        {
            var sbSQL = new StringBuilder();
            sbSQL.Append("SELECT ");
            sbSQL.Append("    cons.constraint_name AS NAME, ");
            sbSQL.Append("    cons.table_name AS ParentTable, ");
            sbSQL.Append("    cons_col.column_name AS ParentColumn, ");
            sbSQL.Append("    ref_cons.table_name AS ReferencedTable, ");
            sbSQL.Append("    ref_cons_col.column_name AS ReferencedColumn ");
            sbSQL.Append("FROM ");
            sbSQL.Append("    all_constraints cons ");
            sbSQL.Append("JOIN ");
            sbSQL.Append("    all_cons_columns cons_col ");
            sbSQL.Append("    ON cons.owner = cons_col.owner ");
            sbSQL.Append("    AND cons.constraint_name = cons_col.constraint_name ");
            sbSQL.Append("    AND cons.table_name = cons_col.table_name ");
            sbSQL.Append("JOIN ");
            sbSQL.Append("    all_constraints ref_cons ");
            sbSQL.Append("    ON cons.r_constraint_name = ref_cons.constraint_name ");
            sbSQL.Append("    AND cons.r_owner = ref_cons.owner ");
            sbSQL.Append("JOIN ");
            sbSQL.Append("    all_cons_columns ref_cons_col ");
            sbSQL.Append("    ON ref_cons.owner = ref_cons_col.owner ");
            sbSQL.Append("    AND ref_cons.constraint_name = ref_cons_col.constraint_name ");
            sbSQL.Append("    AND ref_cons.table_name = ref_cons_col.table_name ");
            sbSQL.Append("WHERE ");
            sbSQL.Append("    cons.constraint_type = 'R' ");
            sbSQL.Append("    AND cons.owner = USER ");
            return ExecuteGetDataTable(key, sbSQL.ToString(), Consts.strFKs);
        }

        public DataTable GetIndexes(string key)
        {
            var sbSQL = new StringBuilder();
            sbSQL.Append("SELECT ");
            sbSQL.Append("    idx.index_name AS IndexName, ");
            sbSQL.Append("    idx.table_name AS TableName, ");
            sbSQL.Append("    col.column_name AS ColName ");
            sbSQL.Append("FROM ");
            sbSQL.Append("    all_indexes idx ");
            sbSQL.Append("JOIN ");
            sbSQL.Append("    all_ind_columns col ");
            sbSQL.Append("    ON idx.index_name = col.index_name ");
            sbSQL.Append("    AND idx.table_name = col.table_name ");
            sbSQL.Append("    AND idx.owner = col.index_owner ");
            sbSQL.Append("WHERE ");
            sbSQL.Append("    idx.owner = USER ");
            return ExecuteGetDataTable(key, sbSQL.ToString(), Consts.strIndexes);
        }

        public DataTable GetSpsAndFuncs(string key)
        {
            //var sbSQL = new StringBuilder();
            //sbSQL.Append("");
            //return ExecuteGetDataTable(sbSQL.ToString(), Consts.strSpsAndFuncs);
            var result = new DataTable(Consts.strSpsAndFuncs);
            result.Columns.Add("SPECIFIC_NAME");
            result.Columns.Add("ROUTINE_DEFINITION");
            result.Columns.Add("ROUTINE_TYPE");
            result.Columns.Add("DATA_TYPE");
            return result;
        }

        public DataTable GetInputParams(string key)
        {
            //var sbSQL = new StringBuilder();
            //sbSQL.Append("");
            //return ExecuteGetDataTable(sbSQL.ToString(), Consts.strInputParams);
            var result = new DataTable(Consts.strInputParams);
            result.Columns.Add("SPECIFIC_NAME");
            result.Columns.Add("Parameter_Name");
            result.Columns.Add("Data_Type");
            result.Columns.Add("Character_Maximum_Length");
            result.Columns.Add("Parameter_Mode");
            return result;
        }

        public DataTable GetOutputParams(string key, DataTable spAndFuncTable)
        {
            //var sbSQL = new StringBuilder();
            //sbSQL.Append("");
            //return ExecuteGetDataTable(sbSQL.ToString(), Consts.strOutputParams);
            var result = new DataTable(Consts.strOutputParams);
            result.Columns.Add("SPECIFIC_NAME");
            result.Columns.Add("Name");
            result.Columns.Add("System_Type_Name");
            result.Columns.Add("Error_Message");
            return result;
        }

        public DataTable ExecuteGetDataTable(string key, string script, string dtName)
        {
            var dt = new DataTable(dtName);
            var conn = (OracleConnection)_factory.GetConnection(key).Connection;
            var da = new OracleDataAdapter(script, conn);
            da.SelectCommand.CommandTimeout = 999;
            da.Fill(dt);
            return dt;
        }

        public DataTable GetTableSchema(string key, string script, string dtName)
        {
            var dt = new DataTable(dtName);
            var conn = (OracleConnection)_factory.GetConnection(key).Connection;
            var da = new OracleDataAdapter(script, conn);
            da.SelectCommand.CommandTimeout = 999;
            da.FillSchema(dt, SchemaType.Source);
            return dt;
        }

        public bool UpdateDescription(string key, ref DataSet ds)
        {
            throw new NotImplementedException();
        }
    }
}
