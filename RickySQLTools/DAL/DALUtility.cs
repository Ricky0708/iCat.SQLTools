using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickySQLTools.DAL
{
    internal class DALUtility: DALBase
    {
        internal string GetDbName()
        {
            using (SqlConnection conn = new SqlConnection(base.connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT DB_NAME() AS DBName", conn);
                string dbName = cmd.ExecuteScalar().ToString();
                conn.Close();
                return dbName;
            }
        }
    }
}
