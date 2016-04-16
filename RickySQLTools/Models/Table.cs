using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickySQLTools.Models
{
   internal class Table
    {
        public Table()
        {
            Columns = new Column[] { };
            FKs = new FK[] { };
        }
        public string TableName { get; set; }
        public string TableDescription { get; set; }

        public IEnumerable<Column> Columns { get; set; }
        public IEnumerable<FK> FKs { get; set; }
    }
}
