using RickySQLTools.DAL;
using RickySQLTools.Properties;
using RickySQLTools.Utilitys;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RickySQLTools.Utilitys
{

    public class ShareUtility : ErrorClasss
    {
        public static string RenameDbType(string name)
        {
            string result = "";
            switch (name.ToUpper())
            {
                case "CHAR":
                case "NVARCHAR":
                case "VARCHAR":
                    result = "string";
                    break;
                case "DATETIME":
                    result = "DateTime";
                    break;
                case "BIT":
                    result = "bool";
                    break;
                case "INT":
                    result = "int";
                    break;
                case "BIGINIT":
                    result = "long";
                    break;
                default:
                    //the others not implement yet !
                    result = name;
                    break;
            }
            return result;
        }

        public static string RenameType(string name)
        {
            string result = "";
            switch (name.ToUpper())
            {
                case "BOOLEAN":
                    result = "bool";
                    break;
                case "STRING":
                    result = "string";
                    break;
                case "DATETIME":
                    result = "DateTime";
                    break;
                case "INT32":
                    result = "int";
                    break;
                case "INT64":
                    result = "long";
                    break;
                default:
                    //the others not implement yet !
                    result = name;
                    break;
            }
            return result;
        }

        public static string ConvertToCSharpDbType(string name)
        {
            string result = "";
            switch (name.ToUpper())
            {
                case "CHAR":
                case "NVARCHAR":
                case "VARCHAR":
                    result = "DbType.String";
                    break;
                case "DATETIME":
                    result = "DbType.DateTime";
                    break;
                case "BIT":
                    result = "DbType.Boolean";
                    break;
                case "INT":
                    result = "DbType.Int32";
                    break;
                case "BIGINT":
                    result = "DbType.Int64";
                    break;
                default:
                    //the others not implement yet !
                    result = name;
                    break;
            }
            return result;
        }

        public string GetDbName(string connectionString)
        {
            if (connectionString == "")
            {
                return "";
            }
            else
            {
                connectionString = Regex.Replace(connectionString, @"\s+", "");
                int startIndex = connectionString.ToUpper().IndexOf("DATABASE=") + 9;
                connectionString = connectionString.ToUpper().Substring(
                    startIndex,
                    connectionString.ToUpper().IndexOf(";", startIndex + 1) - startIndex);
                return connectionString;
            }
            //return dao.ReadSQL("SELECT DB_NAME() AS DBName");
        }

        public static object GetSettings(SettingEnum setting)
        {
            object result = "";
            switch (setting)
            {
                case SettingEnum.GetUsing:
                    result = Settings.Default.DefUsing;
                    break;
                case SettingEnum.GetConnectionString:
                    result = Settings.Default.DefConnectionString;
                    break;
                case SettingEnum.GetIncludeAttr:
                    result = Settings.Default.DefIncludeAttr;
                    break;
                case SettingEnum.GetNamespace:
                    result = Settings.Default.DefNamespace;
                    break;
                default:
                    break;
            }
            return result;
        }

        public void SetFolderExists(string filePath)
        {
            DirectoryInfo di = new DirectoryInfo(filePath);
            if (!di.Exists)
            {
                di.Create();
            }
        }

        public bool WriteToFile(string fileName, string doc)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8))
                {
                    writer.Write(doc);
                }
                return true;
            }catch(Exception ex)
            {
                ErrMsg = ex.Message;
                return false;
            }
        }

        #region Dialog
        public string SetFileName(string defRoot, string defName, string extensionName)
        {
            string fileName = "";
            string filePath = defRoot;
            SetFolderExists(filePath);
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.DefaultExt = extensionName;
            saveDlg.InitialDirectory = filePath;
            saveDlg.FileName = defName + "." + extensionName;
            saveDlg.Filter = extensionName + " file|*." + extensionName;

            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                fileName = saveDlg.FileName;
            }
            return fileName;
        }

        public string GetFileName()
        {
            string filePath = Application.StartupPath + "\\database\\";
            SetFolderExists(filePath);
            string fileName = "";
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = "xml";
            dlg.Filter = "xml file|*.xml";
            dlg.InitialDirectory = Application.StartupPath + "\\database\\";
            if (dlg.ShowDialog() == DialogResult.OK)
            {

                fileName = dlg.FileName;
            }
            return fileName;
        }

        public string OpenFolder()
        {
            string result = "";
            string filePath = Application.StartupPath + "\\ModelFiles\\";
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            SetFolderExists(filePath);
            dlg.Reset();
            dlg.RootFolder = Environment.SpecialFolder.MyComputer;
            dlg.SelectedPath = filePath;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                result = dlg.SelectedPath;
            }
            return result;
        }
        #endregion


    }

}
