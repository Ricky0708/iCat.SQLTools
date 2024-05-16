using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCat.SQLTools.Shareds.Shareds
{
    public static class Convertor
    {
        public static string? ConvertToCSharpType(string? name)
        {
            string? result;
            switch (name.ToLower())
            {
                case "bigint": result = "long"; break;
                case "bit": result = "bool"; break;
                case "char": result = "char"; break;
                case "date": result = "DateTime"; break;
                case "datetime": result = "DateTime"; break;
                case "decimal": result = "decimal"; break;
                case "float": result = "float"; break;
                case "int": result = "int"; break;
                case "longtext": result = "string"; break;
                case "mediumint": result = "int"; break;
                case "mediumtext": result = "string"; break;
                case "smallint": result = "short"; break;
                case "text": result = "string"; break;
                case "time": result = "DateTime"; break;
                case "timestamp": result = "DateTime"; break; // mysql
                //case "timestamp": result = "byte[]"; break; // mssql
                case "tinyint": result = "byte"; break;
                case "tinytext": result = "string"; break;
                case "varbinary": result = "byte[]"; break;
                case "varchar": result = "string"; break;

                case "datetime2": result = "DateTime"; break;
                case "money": result = "decimal"; break;
                case "nchar": result = "string"; break;
                case "ntext": result = "string"; break;
                case "numeric": result = "decimal"; break;
                case "nvarchar": result = "string"; break;
                case "smalldatetime": result = "DateTime"; break;
                case "smallmoney": result = "decimal"; break;
                case "uniqueidentifier": result = "Guid"; break;
                default:
                    result = name;
                    break;
            }
            return result;
        }

        public static string ConvertToCSharpDbType(string name)
        {
            string result = "";
            switch (name.ToUpper())
            {
                case "CHAR":
                case "NVARCHAR":
                case "VARCHAR":
                    result = "DbType.String";
                    break;
                case "DATETIME":
                    result = "DbType.DateTime";
                    break;
                case "BIT":
                    result = "DbType.Boolean";
                    break;
                case "INT":
                    result = "DbType.Int32";
                    break;
                case "BIGINT":
                    result = "DbType.Int64";
                    break;
                default:
                    //the others not implement yet !
                    result = name;
                    break;
            }
            return result;
        }
    }
}
