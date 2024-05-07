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
        protected const string strTables = "Tables";
        protected const string strColumns = "Columns";
        protected const string strFKs = "FKs";
        protected const string strIndexes = "Indexes";
        protected const string strSpsAndFuncs = "SpsAndFuncs";
        protected const string strInputParams = "InputParams";
        protected const string strOutputParams = "OutputParams";
        public DataSet _dalDataset;

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
