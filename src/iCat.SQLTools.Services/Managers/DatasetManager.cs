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

        public DatasetManager? AddDatasetManager(string category, DataSource dataSource, DataSet ds)
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
                        Dataset = ds
                    });
                }
                else
                {
                    dsManager = new DatasetManager
                    {
                        Category = category,
                        DataSource = dataSource,
                        Dataset = ds
                    };
                }

            }
            var dm = DatasetManagers.FirstOrDefault(p => p.Category == category);
            return dm;
        }


    }

    public class DatasetManager
    {
        public string? Category { get; set; }
        public DataSet? Dataset { get; set; }
        public DataSource DataSource { get; set; }
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
