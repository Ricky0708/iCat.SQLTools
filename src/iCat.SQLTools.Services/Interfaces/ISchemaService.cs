using iCat.SQLTools.Repositories.Implements;
using iCat.SQLTools.Services.Managers;
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
        DataSet GetDatasetFromDB();
        DataSet GetDatasetFromXml(string xmlString);
        bool SaveToXml(DataSet manager, string fileName);
    }
}
