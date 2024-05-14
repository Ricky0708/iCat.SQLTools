using iCat.SQLTools.enums;
using iCat.SQLTools.Repositories.Interfaces;
using iCat.SQLTools.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.OpenXmlFormats;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.HPSF;
using iCat.SQLTools.Enums;
using iCat.SQLTools.Repositories.Implements;

namespace iCat.SQLTools.Services.Implements
{
    public class SchemaService : ISchemaService
    {
        public string Category => _category;
        private string _category;
        private readonly ISchemaRepository _repository;
        private readonly DatasetManager _datasetManager;

        public SchemaService(
            ConnectionType connectionType,
            DatasetManager datasetManager,
            IServiceProvider provider
            )
        {
            _category = connectionType.ToString();
            _repository = provider
                .GetRequiredService<IEnumerable<ISchemaRepository>>()
                .First(p => p.Category == connectionType.ToString()) ?? throw new ArgumentNullException(nameof(ISchemaRepository));
            _datasetManager = datasetManager ?? throw new ArgumentNullException(nameof(datasetManager));
        }

        public DatasetManager GetDatasetFromDB()
        {
            _datasetManager.Dataset = new DataSet();
            _datasetManager.Dataset = _repository.GetDatasetFromSQL();

            DataRelation relCol = new DataRelation("MasterDetailCols", _datasetManager.Dataset.Tables[Consts.strTables]!.Columns["TableName"]!, _datasetManager.Dataset.Tables[Consts.strColumns]!.Columns["TableName"]!);
            _datasetManager.Dataset.Relations.Add(relCol);
            //DataRelation relFK = new DataRelation("MasterDetailFKs", ds.Tables[dtTables].Columns["TableName"], ds.Tables[dtFKs].Columns["ParentTable"]);
            //ds.Relations.Add(relFK);

            DataRelation resIndex = new DataRelation("MasterDetailIndexes", _datasetManager.Dataset.Tables[Consts.strTables]!.Columns["TableName"]!, _datasetManager.Dataset.Tables[Consts.strIndexes]!.Columns["TableName"]!);
            _datasetManager.Dataset.Relations.Add(resIndex);

            DataRelation relInputParam = new DataRelation("MasterDetailInputParams", _datasetManager.Dataset.Tables[Consts.strSpsAndFuncs]!.Columns["SPECIFIC_NAME"]!, _datasetManager.Dataset.Tables[Consts.strInputParams]!.Columns["SPECIFIC_NAME"]!);
            _datasetManager.Dataset.Relations.Add(relInputParam);

            DataRelation resOutputParam = new DataRelation("MasterDetailOutputParams", _datasetManager.Dataset.Tables[Consts.strSpsAndFuncs]!.Columns["SPECIFIC_NAME"]!, _datasetManager.Dataset.Tables[Consts.strOutputParams]!.Columns["SPECIFIC_NAME"]!);
            _datasetManager.Dataset.Relations.Add(resOutputParam);
            _datasetManager.DatasetFromType = DatasetFromType.DB;
            return _datasetManager;

        }

        public DatasetManager GetDatasetFromXml(string xmlString)
        {
            _datasetManager.Dataset = new DataSet();
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(xmlString);
            writer.Flush();
            stream.Position = 0;

            _datasetManager.Dataset.ReadXml(stream);
            _datasetManager.Dataset.AcceptChanges();

            _datasetManager.DatasetFromType = DatasetFromType.XML;
            return _datasetManager;

        }

        public bool SaveToXml(DatasetManager manager, string fileName)
        {
            //DirectoryInfo di = new DirectoryInfo(fillePath);
            //if (!di.Exists)
            //{
            //	di.Create();
            //}
            string saveToPath = fileName;
            manager.Dataset.WriteXml(saveToPath, XmlWriteMode.WriteSchema);
            return true;
        }
    }
}
