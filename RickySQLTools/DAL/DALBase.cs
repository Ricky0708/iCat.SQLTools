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
        private string _connString;
        protected Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        public DALBase()
        {
            connString = config.AppSettings.Settings["ConnectSQLString"].Value;
        }
        protected string connString
        {
            get { return _connString; }
            set { _connString = value; }
        }
        
    }
}
