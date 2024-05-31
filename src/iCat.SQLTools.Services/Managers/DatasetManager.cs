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
        private List<DatasetManager> Datasets { get; set; } = new List<DatasetManager>();

        public DatasetManagerFactory()
        {
        }

        public DatasetManager? GetDatasetManager(string category)
        {
            lock (Datasets)
            {
                var dm = Datasets.FirstOrDefault(p => p.Category == category);
                return dm;
            }

        }

        public DatasetManager? AddDatasetManager(string category, DataSource dataSource, DataSet ds)
        {
            lock (Datasets)
            {
                var dsManager = Datasets.FirstOrDefault(p => p.Category == category);
                if (dsManager == null)
                {
                    Datasets.Add(new DatasetManager
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
            var dm = Datasets.FirstOrDefault(p => p.Category == category);
            return dm;
        }

        public bool SaveToXml(string key, string fileName)
        {
            lock (Datasets)
            {

                string saveToPath = fileName;
                var ds = Datasets.FirstOrDefault(p => p.Category == key)?.Dataset;
                if (ds != null)
                {
                    ds.WriteXml(saveToPath, XmlWriteMode.WriteSchema);
                    return true;
                }
                return false;
            }

        }
    }

    public class DatasetManager
    {
        public string? Category { get; set; }
        public DataSet? Dataset { get; set; }
        public DataSource DataSource { get; set; }
    }
}
