using iCat.DB.Client.Factory.Interfaces;
using iCat.SQLTools.Repositories.Interfaces;
using iCat.SQLTools.Shareds.Enums;
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCat.SQLTools.Repositories.Implements
{
    public class MySQLSchemaRepository : ISchemaRepository
    {
        public string Category => "MySQL";

        private readonly IConnectionFactory _factory;

        public MySQLSchemaRepository(IConnectionFactory factory)
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
            var sbSQL = new StringBuilder();
            sbSQL.Append("SELECT ");
            sbSQL.Append("	tbl.TABLE_NAME AS TableName, ");
            sbSQL.Append("	tbl.TABLE_COMMENT AS TableDescription, ");
            sbSQL.Append("	tbl.TABLE_TYPE AS TableType ");
            sbSQL.Append("FROM information_schema.tables tbl ");
            sbSQL.Append("WHERE tbl.TABLE_SCHEMA = DATABASE() AND (tbl.TABLE_TYPE = 'BASE TABLE' OR tbl.TABLE_TYPE = 'VIEW') ");
            sbSQL.Append("ORDER BY TableName ");
            return ExecuteGetDataTable(sbSQL.ToString(), Consts.strTables);
        }

        public DataTable GetColumns()
        {
            var sbSQL = new StringBuilder();
            sbSQL.Append("SELECT DISTINCT ");
            sbSQL.Append("	A.TABLE_NAME AS TableName, ");
            sbSQL.Append("	IF(A.EXTRA = 'auto_increment', TRUE, FALSE) AS IsIdentity, ");
            sbSQL.Append("	A.COLUMN_NAME AS ColName, ");
            sbSQL.Append("	A.DATA_TYPE AS ColType, ");
            sbSQL.Append("	A.CHARACTER_MAXIMUM_LENGTH AS ColLength, ");
            sbSQL.Append("	A.COLUMN_DEFAULT AS DefaultValue, ");
            sbSQL.Append("	A.COLLATION_NAME AS CollationName, ");
            sbSQL.Append("  IF(A.IS_NULLABLE = 'YES', TRUE, FALSE) AS IsNullable, ");
            sbSQL.Append("	IF(A.COLUMN_KEY = 'PRI', TRUE, NULL) AS IsPK, ");
            sbSQL.Append("	A.COLUMN_COMMENT AS ColDescription, ");
            sbSQL.Append("	A.ORDINAL_POSITION AS ordinal_position ");
            sbSQL.Append("FROM ");
            sbSQL.Append("	INFORMATION_SCHEMA.COLUMNS A ");
            sbSQL.Append("LEFT JOIN ");
            sbSQL.Append("	INFORMATION_SCHEMA.KEY_COLUMN_USAGE B ON A.TABLE_SCHEMA = B.TABLE_SCHEMA AND A.TABLE_NAME = B.TABLE_NAME AND A.COLUMN_NAME = B.COLUMN_NAME ");
            sbSQL.Append("WHERE ");
            sbSQL.Append("	A.TABLE_SCHEMA = DATABASE() ");
            sbSQL.Append("ORDER BY A.ORDINAL_POSITION ");
            return ExecuteGetDataTable(sbSQL.ToString(), Consts.strColumns);
        }

        public DataTable GetFks()
        {
            var sbSQL = new StringBuilder();
            sbSQL.Append("SELECT ");
            sbSQL.Append("	A.CONSTRAINT_NAME AS NAME, ");
            sbSQL.Append("	B.TABLE_NAME AS ParentTable, ");
            sbSQL.Append("	B.COLUMN_NAME AS ParentColumn, ");
            sbSQL.Append("	B.REFERENCED_TABLE_NAME AS ReferencedTable, ");
            sbSQL.Append("	B.REFERENCED_COLUMN_NAME AS ReferencedColumn ");
            sbSQL.Append("FROM ");
            sbSQL.Append("	information_schema.TABLE_CONSTRAINTS A ");
            sbSQL.Append("LEFT JOIN ");
            sbSQL.Append("	INFORMATION_SCHEMA.KEY_COLUMN_USAGE B ON A.TABLE_SCHEMA = B.TABLE_SCHEMA AND A.TABLE_NAME = B.TABLE_NAME AND A.CONSTRAINT_NAME = B.CONSTRAINT_NAME ");
            sbSQL.Append("WHERE ");
            sbSQL.Append("	A.TABLE_SCHEMA = DATABASE() AND A.CONSTRAINT_TYPE = 'FOREIGN KEY' ");
            return ExecuteGetDataTable(sbSQL.ToString(), Consts.strFKs);
        }

        public DataTable GetIndexes()
        {
            var sbSQL = new StringBuilder();
            sbSQL.Append("SELECT ");
            sbSQL.Append("    A.INDEX_NAME AS IndexName, ");
            sbSQL.Append("    A.TABLE_NAME AS TableName, ");
            sbSQL.Append("    A.COLUMN_NAME AS ColName ");
            sbSQL.Append("FROM ");
            sbSQL.Append("    INFORMATION_SCHEMA.STATISTICS A ");
            sbSQL.Append("WHERE ");
            sbSQL.Append("    TABLE_SCHEMA = DATABASE() ");
            return ExecuteGetDataTable(sbSQL.ToString(), Consts.strIndexes);
        }

        public DataTable GetSpsAndFuncs()
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

        public DataTable GetInputParams()
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

        public DataTable GetOutputParams(DataTable spAndFuncTable)
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

        public DataTable ExecuteGetDataTable(string script, string dtName)
        {
            var dt = new DataTable(dtName);
            var conn = (MySqlConnection)_factory.GetConnection(Category).Connection;
            var da = new MySqlDataAdapter(script, conn);
            da.SelectCommand.CommandTimeout = 999;
            da.Fill(dt);
            return dt;
        }

        public DataTable GetTableSchema(string script, string dtName)
        {
            var dt = new DataTable(dtName);
            var conn = (MySqlConnection)_factory.GetConnection(Category).Connection;
            var da = new MySqlDataAdapter(script, conn);
            da.SelectCommand.CommandTimeout = 999;
            da.FillSchema(dt, SchemaType.Source);
            return dt;
        }
    }
}
