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
        string Category { get; }
        DataSet GetDatasetFromSQL();
        DataTable GetTables();
        DataTable GetColumns();
        DataTable GetFks();
        DataTable GetIndexes();
        DataTable GetSpsAndFuncs();
        DataTable GetInputParams();
        DataTable GetOutputParams(DataTable spAndFuncTable);
    }
}
