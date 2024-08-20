using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Text;
using System.Xml.Linq;

namespace iCat.SQLTools.ConsoleTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.99.2)(PORT=1521))(CONNECT_DATA=(SID=XE)));User Id=sys;Password=Aa123456;DBA Privilege=SYSDBA;";
            string connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.99.2)(PORT=1521))(CONNECT_DATA=(SID=XE)));User Id=TESTDB;Password=Aa123456";
            using (var conn = new OracleConnection(connectionString))
            {
                conn.Open();
                var sbSQL = new StringBuilder("SELECT * FROM TESTTABLE");
                var cmd = new OracleCommand(sbSQL.ToString(), conn);

                var dt = new DataTable("AA");
                var da = new OracleDataAdapter(sbSQL.ToString(), conn);
                da.SelectCommand.CommandTimeout = 999;
                da.FillSchema(dt, SchemaType.Source);

                conn.Close();
            }
        }
    }
}
