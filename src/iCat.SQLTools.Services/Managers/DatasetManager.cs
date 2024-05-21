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
    public class DatasetManager
    {

        public DataSet? Dataset { get; set; }
        public DataProvider DataProvider { get; set; }

        public DatasetManager()
        {
        }



        public bool SaveToXml(DataSet ds, string fileName)
        {
            string saveToPath = fileName;
            ds.WriteXml(saveToPath, XmlWriteMode.WriteSchema);
            return true;
        }


    }
}
