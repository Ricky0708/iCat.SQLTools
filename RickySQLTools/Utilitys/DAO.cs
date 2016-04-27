using RickySQLTools.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickySQLTools.Utilitys
{
    public class DAO : ErrorClasss
    {
        public string _connectionString { get; set; }

        public DAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public string ReadSQL(string script)
        {
            if (_connectionString == "")
            {
                resultCode = ResultCode.ConnectoinEmpty;
                return "";
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(script, conn);
                    object s = cmd.ExecuteScalar();
                    string result = s == null ? "" : s.ToString();
                    conn.Close();
                    return result;
                }
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
                return "";
            }

        }

        public string ReadSQL(SqlCommand cmd)
        {
            if (_connectionString == "")
            {
                resultCode = ResultCode.ConnectoinEmpty;
                return "";
            }
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                cmd.Connection = conn;
                object s = cmd.ExecuteScalar();
                string result = s == null ? "" : s.ToString();
                conn.Close();
                return result;
            }
        }

        public DataTable ReadSQLSchemaUseAdapter(string script, string tableName)
        {
            if (_connectionString == "")
            {
                resultCode = ResultCode.ConnectoinEmpty;
                return null;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter(script, conn);
                    DataTable dt = new DataTable(tableName);
                    da.FillSchema(dt, SchemaType.Source);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
                return null;
            }

        }

        public DataTable ReadSQLUseAdapter(string script, string tableName)
        {
            if (_connectionString == "")
            {
                resultCode = ResultCode.ConnectoinEmpty;
                return null;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter(script, conn);
                    DataTable dt = new DataTable(tableName);
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
                return null;
            }

        }

        public bool ExecSQLTransation(StringBuilder sbSQL)
        {
            if (_connectionString == "")
            {
                resultCode = ResultCode.ConnectoinEmpty;
                //ErrMsg = "Connection string is not set yet !";
                return false;
            }
            else
            {
                SqlTransaction tran;
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    tran = conn.BeginTransaction();
                    try
                    {
                        SqlCommand cmd = new SqlCommand(sbSQL.ToString(), conn);
                        cmd.Transaction = tran;

                        cmd.ExecuteNonQuery();
                        tran.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        ErrMsg = ex.Message;
                        tran.Rollback();
                        return false;
                    }
                }
            }

        }
    }
}
