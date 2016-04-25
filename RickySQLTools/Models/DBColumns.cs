using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickySQLTools.Models
{
    public class DBColumns
    {
        public String TableName { get; set; }

        public String IsIdentity { get; set; }

        public String ColName { get; set; }

        public String ColType { get; set; }

        public Int32 ColLength { get; set; }

        public String DefaultValue { get; set; }

        public String CollationName { get; set; }

        public Int32 IsNullable { get; set; }

        public Int32 IsPK { get; set; }

        public Object ColDescription { get; set; }

        public Int32 ordinal_position { get; set; }
    }
}