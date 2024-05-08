using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickySQLTools.Models
{
    public class StatementColumnWithTableModel
    {
        public string ColumnName { get; set; }
        public string SrcColumnName { get; set; }
        public string[] Tables { get; set; }
        public string ColumnType { get; set; }
    }
}
