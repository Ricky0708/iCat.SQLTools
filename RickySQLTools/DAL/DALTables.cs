using RickySQLTools.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RickySQLTools.DAL
{
	class DALTables : DALBase
	{
		private const string dtTables = "Tables";
		private const string dtColumns = "Columns";
		private const string dtFKs = "FKs";
		private const string dtSpsAndFuncs = "SpsAndFuncs";
		private const string dtInputParams = "InputParams";
		private const string dtOutputParams = "OutputParams";
		private DALUtility objUti = new DALUtility();
		internal DataSet ds { get; set; }
		internal string ErrMsg { get; set; }
		internal bool GetDatasetFromSQL()
		{
			ds = new DataSet();
			try
			{
				using (SqlConnection conn = new SqlConnection(base.connString))
				{
					SqlDataAdapter da = new SqlDataAdapter(GeneratGetColScript(), conn);
					da.Fill(ds, dtColumns);
					da = new SqlDataAdapter(GeneratGetTableScript(), conn);
					da.Fill(ds, dtTables);
					da = new SqlDataAdapter(GeneratGetFKScript(), conn);
					da.Fill(ds, dtFKs);
					da = new SqlDataAdapter(GeneratGetSpAndFuncScript(), conn);
					da.Fill(ds, dtSpsAndFuncs);
					da = new SqlDataAdapter(GeneratGetInputParamScript(), conn);
					da.Fill(ds, dtInputParams);
					string script = "";
					foreach (DataRow dr in ds.Tables[dtSpsAndFuncs].Rows)
					{
						script += GeneratGetOutPutParamScript(dr["SPECIFIC_NAME"].ToString()) + " UNION ALL ";
					}
					script = script.Substring(0, script.Length - 11);
					da = new SqlDataAdapter(script, conn);
					da.Fill(ds, dtOutputParams);
				}
				DataRelation relCol = new DataRelation("MasterDetailCols", ds.Tables[dtTables].Columns["TableName"], ds.Tables[dtColumns].Columns["TableName"]);
				ds.Relations.Add(relCol);
				//DataRelation relFK = new DataRelation("MasterDetailFKs", ds.Tables[dtTables].Columns["TableName"], ds.Tables[dtFKs].Columns["ParentTable"]);
				//ds.Relations.Add(relFK);

				DataRelation relInputParam = new DataRelation("MasterDetailInputParams", ds.Tables[dtSpsAndFuncs].Columns["SPECIFIC_NAME"], ds.Tables[dtInputParams].Columns["SPECIFIC_NAME"]);
				ds.Relations.Add(relInputParam);
				DataRelation resOutputParam = new DataRelation("MasterDetailOutputParams", ds.Tables[dtSpsAndFuncs].Columns["SPECIFIC_NAME"], ds.Tables[dtOutputParams].Columns["SPECIFIC_NAME"]);
				ds.Relations.Add(resOutputParam);
				return true;
			}
			catch (Exception ex)
			{
				ErrMsg = ex.Message;
				return false;
			}

		}

		internal bool GetDatasetFromXml()
		{
			ds = new DataSet();

			string loadFromPath = Application.StartupPath + "\\Database\\" + objUti.GetDbName() + ".xml";
			FileInfo fi = new FileInfo(loadFromPath);
			if (fi.Exists)
			{
				ds.ReadXml(loadFromPath);
				ds.AcceptChanges();
				return true;
			}
			else
			{
				ErrMsg = "Can't find xml in \r\n " + loadFromPath;
				return false;
			}
		}

		internal bool SaveToXml(ref DataSet ds)
		{
			DirectoryInfo di = new DirectoryInfo(Application.StartupPath + "\\Database\\");
			if (!di.Exists)
			{
				di.Create();
			}
			string saveToPath = Application.StartupPath + "\\Database\\" + objUti.GetDbName() + ".xml";
			ds.WriteXml(saveToPath, XmlWriteMode.WriteSchema);
			return true;
		}

		internal bool UpdateDescription(ref DataSet ds)
		{
			DataTable dt;
			StringBuilder sbSQL = new StringBuilder();
			dt = ds.Tables[dtTables].GetChanges(DataRowState.Modified);
			if (dt != null)
			{
				sbSQL = GeneratUpdateScript(sbSQL, dt, "default");
			}
			dt = ds.Tables[dtColumns].GetChanges(DataRowState.Modified);
			if (dt != null)
			{
				sbSQL = GeneratUpdateScript(sbSQL, dt, "'column'");
			}

			SqlTransaction tran;
			using (SqlConnection conn = new SqlConnection(base.connString))
			{
				conn.Open();
				tran = conn.BeginTransaction();
				try
				{
					SqlCommand cmd = new SqlCommand(sbSQL.ToString(), conn);
					cmd.Transaction = tran;

					cmd.ExecuteNonQuery();
					tran.Commit();
					ds.AcceptChanges();
					return true;
				}
				catch (Exception ex)
				{
					ErrMsg = ex.Message;
					tran.Rollback();
					return false;
				}

			}
		}

		#region script generator
		private StringBuilder GeneratUpdateScript(StringBuilder sbSQL, DataTable dt, string target)
		{
			using (SqlConnection conn = new SqlConnection(base.connString))
			{
				SqlCommand cmd = new SqlCommand(@"SELECT * 
												  FROM fn_listextendedproperty (NULL, 'schema', 'dbo', 'table',@TableName, " + target + @", default)
												  WHERE
													name='MS_Description' AND 
													objtype = @objType AND
													objname = @objName", conn);

				for (int i = 0; i < dt.Rows.Count; i++)
				{
					cmd.Parameters.Clear();
					cmd.Parameters.AddWithValue("@TableName", dt.Rows[i]["TableName"].ToString());
					switch (target)
					{
						case "default":
							cmd.Parameters.AddWithValue("@objName", dt.Rows[i]["TableName"].ToString());
							cmd.Parameters.AddWithValue("@objType", "TABLE");
							break;
						case "'column'":
							cmd.Parameters.AddWithValue("@objName", dt.Rows[i]["ColName"].ToString());
							cmd.Parameters.AddWithValue("@objType", "COLUMN");
							break;
						default:
							break;
					}

					conn.Open();

					SqlDataReader sdr = cmd.ExecuteReader();
					switch (target)
					{
						case "default":
							if (sdr.Read())
							{
								sbSQL.Append("EXECUTE sp_updateextendedproperty N'MS_Description', N'" + dt.Rows[i]["TableDescription"].ToString().Replace("'", "") + "', N'SCHEMA', N'dbo', N'TABLE', N'" + dt.Rows[i]["TableName"].ToString().Replace("'", "") + "', NULL, NULL ;");
							}
							else
							{
								sbSQL.Append("EXECUTE sp_addextendedproperty N'MS_Description', N'" + dt.Rows[i]["TableDescription"].ToString().Replace("'", "") + "', N'SCHEMA', N'dbo', N'TABLE', N'" + dt.Rows[i]["TableName"].ToString().Replace("'", "") + "', NULL, NULL ;");
							}
							break;
						case "'column'":
							if (sdr.Read())
							{
								sbSQL.Append("EXECUTE sp_updateextendedproperty N'MS_Description', N'" + dt.Rows[i]["ColDescription"].ToString().Replace("'", "") + "', N'SCHEMA', N'dbo', N'TABLE', N'" + dt.Rows[i]["TableName"].ToString().Replace("'", "") + "', N'COLUMN', N'" + dt.Rows[i]["ColName"].ToString().Replace("'", "") + "' ;");
							}
							else
							{
								sbSQL.Append("EXECUTE sp_addextendedproperty    N'MS_Description', N'" + dt.Rows[i]["ColDescription"].ToString().Replace("'", "") + "', N'SCHEMA', N'dbo', N'TABLE', N'" + dt.Rows[i]["TableName"].ToString().Replace("'", "") + "', N'COLUMN', N'" + dt.Rows[i]["ColName"].ToString().Replace("'", "") + "' ;");
							}
							break;
						default:
							break;
					}
					conn.Close();
				}

			}
			return sbSQL;
		}
		private string GeneratGetTableScript()
		{
			string script = @"SELECT 
								TableName = tbl.table_name, 
								TableDescription = prop.value
							  FROM information_schema.tables tbl
							  LEFT JOIN sys.extended_properties prop 
								ON prop.major_id = object_id(tbl.table_schema + '.' + tbl.table_name) 
								AND prop.minor_id = 0
								AND prop.name = 'MS_Description' 
							  WHERE tbl.table_type = 'base table'";
			return script;
		}

		private string GeneratGetColScript()
		{
			string script = @"SELECT
								a.TABLE_NAME                as TableName,
								(SELECT 'true' FROM sys.identity_columns c WHERE OBJECT_ID(a.TABLE_NAME) = c.object_id AND b.COLUMN_NAME  = c.name) as IsIdentity,
								b.COLUMN_NAME               as ColName,
								b.DATA_TYPE                 as ColType,
								b.CHARACTER_MAXIMUM_LENGTH  as ColLength,
								b.COLUMN_DEFAULT            as DefaultValue,
								b.COLLATION_NAME            as 'CollationName',
								(CASE b.IS_NULLABLE WHEN 'YES' THEN 1 ELSE 0 END) as IsNullable,
								(
									SELECT 1 
									FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE
									WHERE 
										OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + CONSTRAINT_NAME), 'IsPrimaryKey') = 1
										AND TABLE_NAME = a.TABLE_NAME AND COLUMN_NAME=b.COLUMN_NAME 
								) AS IsPK,
								(
									SELECT
										value
									FROM
										fn_listextendedproperty (NULL, 'schema', 'dbo', 'table', 
																 a.TABLE_NAME, 'column', default)
									WHERE
										name='MS_Description' 
										and objtype='COLUMN' 
										and objname Collate Chinese_Taiwan_Stroke_CI_AS=b.COLUMN_NAME
								) as ColDescription
							  FROM
								INFORMATION_SCHEMA.TABLES  a
								LEFT JOIN INFORMATION_SCHEMA.COLUMNS b ON (a.TABLE_NAME=b.TABLE_NAME)
							  WHERE
								TABLE_TYPE='BASE TABLE'
							  ORDER BY
								a.TABLE_NAME, ordinal_position";
			return script;
		}

		private string GeneratGetFKScript()
		{
			string script = @"SELECT  
								fk.name,
								OBJECT_NAME(fk.parent_object_id) 'Parenttable',
								c1.name 'Parentcolumn',
								OBJECT_NAME(fk.referenced_object_id) 'Referencedtable',
								c2.name 'Referencedcolumn'
							  FROM 
								sys.foreign_keys fk
							  INNER JOIN 
								sys.foreign_key_columns fkc ON fkc.constraint_object_id = fk.object_id
							  INNER JOIN
								sys.columns c1 ON fkc.parent_column_id = c1.column_id AND fkc.parent_object_id = c1.object_id
							  INNER JOIN
								sys.columns c2 ON fkc.referenced_column_id = c2.column_id AND fkc.referenced_object_id = c2.object_id";
			return script;
		}
	
		private string GeneratGetSpAndFuncScript()
		{
			string script = @"SELECT SPECIFIC_NAME, ROUTINE_DEFINITION, ROUTINE_TYPE, DATA_TYPE 
											 FROM information_schema.routines 
											 ORDER BY SPECIFIC_NAME";
			return script;
		}
		private string GeneratGetInputParamScript()
		{
			string script = @"SELECT A.SPECIFIC_NAME, A.Parameter_Name, A.Data_Type, A.Character_Maximum_Length, A.Parameter_Mode 
										   FROM information_schema.PARAMETERS A
										   INNER JOIN information_schema.routines B ON A.SPECIFIC_NAME = B.SPECIFIC_NAME AND B.ROUTINE_TYPE = 'PROCEDURE'";
			return script;
		}
		private string GeneratGetOutPutParamScript(string name)
		{
			string script = string.Format("SELECT '{0}' AS SPECIFIC_NAME, Name, System_Type_Name, Error_Message FROM sys.dm_exec_describe_first_result_set('{0}',null,0)", name);
			return script;
		}
		#endregion
	}
}
