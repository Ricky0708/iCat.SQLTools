using RickySQLTools.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickySQLTools.DAL
{
    internal class DALBase
    {
        protected const string dtTables = "Tables";
        protected const string dtColumns = "Columns";
        protected const string dtFKs = "FKs";
        protected const string dtIndexes = "Indexes";
        protected const string dtSpsAndFuncs = "SpsAndFuncs";
        protected const string dtInputParams = "InputParams";
        protected const string dtOutputParams = "OutputParams";

        private string _connString;
        protected Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        public DALBase()
        {
            connString = Settings.Default.ConnectionString;
        }
        protected string connString
        {
            get { return _connString; }
            set { _connString = value; }
        }
        
    }
}
