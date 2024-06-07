using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCat.SQLTools.Models
{
    public class ProgramsConfig
    {
        public required Program[] Programs { get; set; }
    }

    public class Program
    {
        public required string ProgId { get; set; }
        public required string ProgName { get; set; }
        public required string ModuleName { get; set; }
        public required int Seq { get; set; }
    }

}
