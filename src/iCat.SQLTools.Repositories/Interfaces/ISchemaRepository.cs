using iCat.SQLTools.Repositories.Enums;
using iCat.SQLTools.Shareds.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCat.SQLTools.Repositories.Interfaces
{
    public interface ISchemaRepository
    {
        ConnectionType ConnectionType { get; }
        DataSet GetDatasetFromSQL(string key);
        DataTable GetTables(string key);
        DataTable GetColumns(string key);
        DataTable GetFks(string key);
        DataTable GetIndexes(string key);
        DataTable GetSpsAndFuncs(string key);
        DataTable GetInputParams(string key);
        DataTable GetOutputParams(string key, DataTable spAndFuncTable);
        DataTable ExecuteGetDataTable(string key, string script, string dtName);
        DataTable GetTableSchema(string key, string script, string dtName);
        bool UpdateDescription(string key, ref DataSet ds);
    }
}
