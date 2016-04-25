using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickySQLTools.Models
{
    public class DBFks
    {

        public String name { get; set; }

        public String Parenttable { get; set; }

        public String Parentcolumn { get; set; }

        public String Referencedtable { get; set; }

        public String Referencedcolumn { get; set; }
    }
}