using iCat.SQLTools.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCat.SQLTools.Repositories.Implements
{
    public class DatasetManager
    {
        public DataSet Dataset { get; set; } = new DataSet();
        public DatasetFromType DatasetFromType { get; set; }
    }
}
