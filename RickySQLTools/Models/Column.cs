using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickySQLTools.Models
{
    internal class Column
    {
        public string TableName { get; set; }
        public string ColName { get; set; }
        public string ColType { get; set; }
        public string ColLength { get; set; }
        public string IsNullable { get; set; }
        public bool IsPK { get; set; }
        public string ColDescription { get; set; }
    }
}
