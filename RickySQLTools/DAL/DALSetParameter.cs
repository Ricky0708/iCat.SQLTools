using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickySQLTools.DAL
{
    internal class DALSetParameter : DALBase
    {
        internal string GetConnectionString()
        {
            return base.connString;
        }
        internal bool SaveConnectionString(string strConn)
        {
            config.AppSettings.Settings["ConnectSQLString"].Value = strConn;
            config.Save(ConfigurationSaveMode.Full);
            ConfigurationManager.RefreshSection("appSettings");
            return true;
        }
    }
}
