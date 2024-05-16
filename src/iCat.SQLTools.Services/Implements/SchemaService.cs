using iCat.SQLTools.Repositories.Interfaces;
using iCat.SQLTools.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iCat.SQLTools.Repositories.Implements;
using iCat.SQLTools.Shareds.Enums;
using iCat.SQLTools.Services.Managers;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NPOI.SS.Formula.PTG;
using NPOI.OpenXmlFormats.Wordprocessing;
using iCat.SQLTools.Services.Models;

namespace iCat.SQLTools.Services.Implements
{
    public class SchemaService : ISchemaService
    {
        public string Category => _category;
        private string _category;
        private readonly ISchemaRepository _repository;
        public SchemaService(
            ConnectionType connectionType,
            IServiceProvider provider
            )
        {
            _category = connectionType.ToString();
            _repository = provider
                .GetRequiredService<IEnumerable<ISchemaRepository>>()
                .First(p => p.Category == connectionType.ToString()) ?? throw new ArgumentNullException(nameof(ISchemaRepository));
        }

        public DataSet GetDatasetFromDB()
        {
            var ds = new DataSet();
            ds = _repository.GetDatasetFromSQL();

            DataRelation relCol = new DataRelation("MasterDetailCols", ds.Tables[Consts.strTables]!.Columns["TableName"]!, ds.Tables[Consts.strColumns]!.Columns["TableName"]!);
            ds.Relations.Add(relCol);
            //DataRelation relFK = new DataRelation("MasterDetailFKs", ds.Tables[dtTables].Columns["TableName"], ds.Tables[dtFKs].Columns["ParentTable"]);
            //ds.Relations.Add(relFK);

            DataRelation resIndex = new DataRelation("MasterDetailIndexes", ds.Tables[Consts.strTables]!.Columns["TableName"]!, ds.Tables[Consts.strIndexes]!.Columns["TableName"]!);
            ds.Relations.Add(resIndex);

            DataRelation relInputParam = new DataRelation("MasterDetailInputParams", ds.Tables[Consts.strSpsAndFuncs]!.Columns["SPECIFIC_NAME"]!, ds.Tables[Consts.strInputParams]!.Columns["SPECIFIC_NAME"]!);
            ds.Relations.Add(relInputParam);

            DataRelation resOutputParam = new DataRelation("MasterDetailOutputParams", ds.Tables[Consts.strSpsAndFuncs]!.Columns["SPECIFIC_NAME"]!, ds.Tables[Consts.strOutputParams]!.Columns["SPECIFIC_NAME"]!);
            ds.Relations.Add(resOutputParam);
            return ds;

        }

        public DataSet GetDatasetFromXml(string xmlString)
        {
            var ds = new DataSet();
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(xmlString);
            writer.Flush();
            stream.Position = 0;

            ds.ReadXml(stream);
            ds.AcceptChanges();
            return ds;

        }

        public bool SaveToXml(DataSet ds, string fileName)
        {
            //DirectoryInfo di = new DirectoryInfo(fillePath);
            //if (!di.Exists)
            //{
            //	di.Create();
            //}
            string saveToPath = fileName;
            ds.WriteXml(saveToPath, XmlWriteMode.WriteSchema);
            return true;
        }

   
    }
}
