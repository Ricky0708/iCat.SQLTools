using iCat.SQLTools.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCat.SQLTools.Repositories.Implements
{
    public class MSSQLSchemaRepository : ISchemaRepository
    {
        public string Category => "MSSQL";
    }
}
