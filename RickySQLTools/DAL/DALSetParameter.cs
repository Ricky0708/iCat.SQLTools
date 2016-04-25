using RickySQLTools.Properties;
using RickySQLTools.Utilitys;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickySQLTools.DAL
{
    public class DALSetConfig : DALBase
    {

        public string defConnectionString { get; set; }
        public string defNamespace { get; set; }
        public string defUsing { get; set; }
        public bool defIncludeAttr { get; set; }

        public DALSetConfig()
        {
            defConnectionString = ShareUtility.GetSettings(SettingEnum.GetConnectionString).ToString();
            defNamespace = ShareUtility.GetSettings(SettingEnum.GetNamespace).ToString();
            defUsing = ShareUtility.GetSettings(SettingEnum.GetUsing).ToString();
            defIncludeAttr = (bool)ShareUtility.GetSettings(SettingEnum.GetIncludeAttr);
        }

        public bool SaveConfig()
        {
            Settings.Default.DefConnectionString = defConnectionString;
            Settings.Default.DefNamespace = defNamespace;
            Settings.Default.DefUsing = defUsing;
            Settings.Default.DefIncludeAttr = defIncludeAttr;
            Settings.Default.Save();

            //config.AppSettings.Settings["ConnectSQLString"].Value = strConn;
            //config.Save(ConfigurationSaveMode.Full);
            //ConfigurationManager.RefreshSection("appSettings");
            return true;
        }
    }
}
