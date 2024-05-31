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
        DataSet GetDatasetFromSQL();
        DataTable GetTables();
        DataTable GetColumns();
        DataTable GetFks();
        DataTable GetIndexes();
        DataTable GetSpsAndFuncs();
        DataTable GetInputParams();
        DataTable GetOutputParams(DataTable spAndFuncTable);
        DataTable ExecuteGetDataTable(string script, string dtName);
        DataTable GetTableSchema(string script, string dtName);
        bool UpdateDescription(ref DataSet ds);
    }
}
