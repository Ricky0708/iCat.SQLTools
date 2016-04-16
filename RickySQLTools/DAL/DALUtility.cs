using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RickySQLTools.DAL
{
    internal class DALUtility: DALBase
    {
        internal string GetDbName()
        {
            using (SqlConnection conn = new SqlConnection(base.connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT DB_NAME() AS DBName", conn);
                string dbName = cmd.ExecuteScalar().ToString();
                conn.Close();
                return dbName;
            }
        }
        internal void SetFolderExists(string filePath)
        {
            DirectoryInfo di = new DirectoryInfo(filePath);
            if (!di.Exists)
            {
                di.Create();
            }
        }

        #region Dialog
        internal string SetFileName()
        {
            string fileName = "";
            string filePath = Application.StartupPath + "\\database\\";
            SetFolderExists(filePath);
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.DefaultExt = "xml";
            saveDlg.InitialDirectory = filePath;
            saveDlg.FileName = GetDbName() + ".xml";
            saveDlg.Filter = "xml file|*.xml";

            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                fileName = saveDlg.FileName;
            }
            return fileName;
        }

        internal string GetFileName()
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
        #endregion
    }
}
