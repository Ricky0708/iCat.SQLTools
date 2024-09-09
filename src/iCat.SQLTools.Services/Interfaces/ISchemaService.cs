using iCat.SQLTools.Repositories.Enums;
using iCat.SQLTools.Repositories.Implements;
using iCat.SQLTools.Services.Managers;
using iCat.SQLTools.Shareds.Enums;
using NPOI.OpenXmlFormats.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCat.SQLTools.Services.Interfaces
{
    public interface ISchemaService
    {
        string Category { get; }
        DataSet GetDatasetFromDB(string key, ConnectionType connectionType);
        DataTable GetTableSchema(string key, ConnectionType connectionType, string sqlScript, string tableName);
        DataSet GetDatasetFromXml(string xmlString);
        string GenerateClassWithSummary(DataTable dtColumns, string @namespace, string @using, string className, string sqlScript);
        string GenerateClassWithoutSummary(DataTable dtTables, string @namespace, string @using, string className);
        string GenerateClassAssign(DataTable dtTables);
        string GenerateDapperScript(DataTable dtColumns, string tableName, ScriptKind scriptKind, ParameterType parameterType, string parameterObjName);
        bool UpdateDescription(string key, ConnectionType connectionType, DataSet ds);
    }
}
