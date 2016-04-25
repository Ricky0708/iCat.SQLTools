using RickySQLTools.Properties;
using RickySQLTools.Utilitys;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickySQLTools.DAL
{
    public class DALBase : ErrorClasss
    {
        protected const string dtTables = "Tables";
        protected const string dtColumns = "Columns";
        protected const string dtFKs = "FKs";
        protected const string dtIndexes = "Indexes";
        protected const string dtSpsAndFuncs = "SpsAndFuncs";
        protected const string dtInputParams = "InputParams";
        protected const string dtOutputParams = "OutputParams";
        public DataSet dalDataset;

        private string _connString;

        //for remember each form connection
        public string _strConn = "";

        //protected Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        public DALBase()
        {
        }
        protected string connString
        {
            get { return ShareUtility.GetSettings(SettingEnum.GetConnectionString).ToString(); }
            set { _connString = value; }
        }

    }
}
