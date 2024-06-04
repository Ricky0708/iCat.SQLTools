using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickySQLTools.Models
{
    public class StatementColumnModel
    {
        public string SchemaName { get; set; }
        public string SrcColumnName { get; set; }
        public string ColumnName { get; set; }
        public string ColumnType { get; set; }
    }


}
