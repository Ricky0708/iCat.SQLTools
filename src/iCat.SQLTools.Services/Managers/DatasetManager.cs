using iCat.SQLTools.Repositories.Interfaces;
using iCat.SQLTools.Services.Models;
using iCat.SQLTools.Shareds.Enums;
using iCat.SQLTools.Shareds.Shareds;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ZstdSharp.Unsafe;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;
using iCat.SQLTools.Repositories.Enums;

namespace iCat.SQLTools.Services.Managers
{
    public class DatasetManagerFactory
    {
        public List<DatasetManager> DatasetManagers { get; set; } = new List<DatasetManager>();

        public DatasetManagerFactory()
        {
        }

        public DatasetManager? GetDatasetManager(string category)
        {
            lock (DatasetManagers)
            {
                var dm = DatasetManagers.FirstOrDefault(p => p.Category == category);
                return dm;
            }

        }

        public DatasetManager? AddDatasetManager(string category, DataSource dataSource, DataSet ds, string @using, string @namespace, string classSuffix)
        {
            lock (DatasetManagers)
            {
                var dsManager = DatasetManagers.FirstOrDefault(p => p.Category == category);
                if (dsManager == null)
                {
                    DatasetManagers.Add(new DatasetManager
                    {
                        Category = category,
                        DataSource = dataSource,
                        Dataset = ds,
                        ClassSuffix = classSuffix,
                        Namespace = @namespace,
                        Using = @using,
                    });
                }
                else
                {
                    dsManager = new DatasetManager
                    {
                        Category = category,
                        DataSource = dataSource,
                        Dataset = ds,
                        ClassSuffix = classSuffix,
                        Namespace = @namespace,
                        Using = @using,
                    };
                }
            }
            var dm = DatasetManagers.FirstOrDefault(p => p.Category == category);
            return dm;
        }

        public void RemoveDatasetManager(string category)
        {
            lock (DatasetManagers)
            {
                var dm = DatasetManagers.Remove(DatasetManagers.First(p => p.Category == category));
            }
        }

    }

    public class DatasetManager
    {
        public string Category { get; set; } = "";
        public DataSet? Dataset { get; set; }
        public DataSource DataSource { get; set; }
        public ConnectionType? ConnectionType => DataSource switch
        {
            Shareds.Enums.DataSource.MSSQL => iCat.SQLTools.Repositories.Enums.ConnectionType.MSSQL,
            Shareds.Enums.DataSource.MySQL => iCat.SQLTools.Repositories.Enums.ConnectionType.MySQL,
            _ => null,
        };
        public string Using { get; set; } = "";
        public string Namespace { get; set; } = "";
        public string ClassSuffix { get; set; } = "";
        public bool SaveToXml(string fileName)
        {

            string saveToPath = fileName;
            if (Dataset != null)
            {
                Dataset.WriteXml(saveToPath, XmlWriteMode.WriteSchema);
                return true;
            }
            return false;

        }
    }
}
