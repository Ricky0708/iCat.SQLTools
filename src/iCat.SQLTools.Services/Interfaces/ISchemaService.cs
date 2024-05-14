using iCat.SQLTools.Repositories.Implements;
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
        DatasetManager GetDatasetFromDB();
        DatasetManager GetDatasetFromXml(string xmlString);
        bool SaveToXml(DatasetManager manager, string fileName);
    }
}
