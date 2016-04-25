using RickySQLTools.Utilitys;
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
		#region const  var & propery

		private ShareUtility objUti = new ShareUtility();
		private DAO dao;

		#endregion

		#region method
		public bool GetDatasetFromSQL()
		{
			_strConn = base.connString;
			dao = new DAO(_strConn);
			dalDataset = new DataSet();
			try
			{
				using (SqlConnection conn = new SqlConnection(_strConn))
				{
					SqlDataAdapter da = new SqlDataAdapter(GeneratScriptGetCol(), conn);
					da.Fill(dalDataset, dtColumns);
					da = new SqlDataAdapter(GeneratScriptGetTable(), conn);
					da.Fill(dalDataset, dtTables);
					da = new SqlDataAdapter(GeneratScriptGetFK(), conn);
					da.Fill(dalDataset, dtFKs);
					da = new SqlDataAdapter(GeneratScriptGetIndex(), conn);
					da.Fill(dalDataset, dtIndexes);
					da = new SqlDataAdapter(GeneratScriptGetSpAndFunc(), conn);
					da.Fill(dalDataset, dtSpsAndFuncs);
					da = new SqlDataAdapter(GeneratScriptGetInputParam(), conn);
					da.Fill(dalDataset, dtInputParams);

					string script = GeneratScriptGetOutPutParam("") + " UNION ALL ";
					foreach (DataRow dr in dalDataset.Tables[dtSpsAndFuncs].Rows)
					{
						script += GeneratScriptGetOutPutParam(dr["SPECIFIC_NAME"].ToString()) + " UNION ALL ";
					}

					script = script.Substring(0, script.Length - 11);
					da = new SqlDataAdapter(script, conn);
					da.Fill(dalDataset, dtOutputParams);
				}
				DataRelation relCol = new DataRelation("MasterDetailCols", dalDataset.Tables[dtTables].Columns["TableName"], dalDataset.Tables[dtColumns].Columns["TableName"]);
				dalDataset.Relations.Add(relCol);
				//DataRelation relFK = new DataRelation("MasterDetailFKs", ds.Tables[dtTables].Columns["TableName"], ds.Tables[dtFKs].Columns["ParentTable"]);
				//ds.Relations.Add(relFK);

				DataRelation resIndex = new DataRelation("MasterDetailIndexes", dalDataset.Tables[dtTables].Columns["TableName"], dalDataset.Tables[dtIndexes].Columns["TableName"]);
				dalDataset.Relations.Add(resIndex);

				DataRelation relInputParam = new DataRelation("MasterDetailInputParams", dalDataset.Tables[dtSpsAndFuncs].Columns["SPECIFIC_NAME"], dalDataset.Tables[dtInputParams].Columns["SPECIFIC_NAME"]);
				dalDataset.Relations.Add(relInputParam);

				DataRelation resOutputParam = new DataRelation("MasterDetailOutputParams", dalDataset.Tables[dtSpsAndFuncs].Columns["SPECIFIC_NAME"], dalDataset.Tables[dtOutputParams].Columns["SPECIFIC_NAME"]);
				dalDataset.Relations.Add(resOutputParam);


				return true;
			}
			catch (Exception ex)
			{
				//resultCode = ResultCode.FromCatch;
				ErrMsg = ex.Message;
				return false;
			}

		}

		public bool GetDatasetFromXml(string fileName)
		{
			dalDataset = new DataSet();

			FileInfo fi = new FileInfo(fileName);
			if (fi.Exists)
			{
				dalDataset.ReadXml(fileName);
				dalDataset.AcceptChanges();
				return true;
			}
			else
			{
				resultCode = ResultCode.XmlFileNotFound;
				//ErrMsg = "Can't find xml in \r\n " + fileName;
				return false;
			}
		}

		public bool SaveToXml(ref DataSet ds, string fileName)
		{
			//DirectoryInfo di = new DirectoryInfo(fillePath);
			//if (!di.Exists)
			//{
			//	di.Create();
			//}
			string saveToPath = fileName;
			ds.WriteXml(saveToPath, XmlWriteMode.WriteSchema);
			return true;
		}

		public bool UpdateDescription(ref DataSet ds)
		{
			bool result = false;

			if (dao != null)
			{

				DataView dv = null;
				StringBuilder sbSQL = new StringBuilder();
				if (ds.Tables[dtTables].GetChanges(DataRowState.Modified) != null)
				{
					dv = ds.Tables[dtTables].GetChanges(DataRowState.Modified).DefaultView;
					if (dv != null && dv.Count > 0)
					{
						dv.RowFilter = "TableType = '" + "VIEW" + "'";
						sbSQL.Append(GeneratScriptUpdate(dv, "VIEW"));
						dv.RowFilter = "TableType = '" + "BASE TABLE" + "'";
						sbSQL.Append(GeneratScriptUpdate(dv, "TABLE"));
					}
				}
				if (ds.Tables[dtColumns].GetChanges(DataRowState.Modified) != null)
				{
					dv = ds.Tables[dtColumns].GetChanges(DataRowState.Modified).DefaultView;
					if (dv != null && dv.Count > 0)
					{
						sbSQL.Append(GeneratScriptUpdate(dv, "COLUMN"));
					}
				}

				if (sbSQL.Length > 0)
				{
					if (dao.ExecSQLTransation(sbSQL))
					{
						ds.AcceptChanges();
						result = true;
					}
					else
					{
						ErrMsg = dao.ErrMsg;
						result = false;
					}
				}
				else
				{
					resultCode = ResultCode.NothinToUpdate;
					//ErrMsg = "Nothing could be update !";
					result = false;
				}
			}
			else
			{
				resultCode = ResultCode.RefrenceNullDAO;
				//ErrMsg = "Data access object is empty, please load data from SQL !";
				result = false;
			}
			return result;

		}
		#endregion

		#region script generator

		private string GeneratScriptUpdate(DataView dv, string target)
		{

			SqlCommand cmd = new SqlCommand();
			string script = "";
			switch (target)
			{
				case "VIEW":
					cmd = new SqlCommand(@"SELECT * 
												  FROM fn_listextendedproperty (NULL, 'schema', 'dbo', 'VIEW',@TableName, default, default)
												  WHERE
													name='MS_Description' AND 
													objtype = 'VIEW' AND
													objname = @objName");
					break;
				case "TABLE":
					cmd = new SqlCommand(@"SELECT * 
												  FROM fn_listextendedproperty (NULL, 'schema', 'dbo', 'TABLE',@TableName, default, default)
												  WHERE
													name='MS_Description' AND 
													objtype = 'TABLE' AND
													objname = @objName");
					break;
				case "COLUMN":
					cmd = new SqlCommand(@"SELECT * 
												  FROM fn_listextendedproperty (NULL, 'schema', 'dbo', 'TABLE',@TableName, 'COLUMN', default)
												  WHERE
													name='MS_Description' AND 
													objtype = 'COLUMN' AND
													objname = @objName");
					break;
				default:
					break;
			}


			for (int i = 0; i < dv.Count; i++)
			{
				cmd.Parameters.Clear();
				cmd.Parameters.AddWithValue("@TableName", dv[i]["TableName"].ToString());
				string execFunName = "";
				string description = "";
				string tableName = "";

				cmd.Parameters.AddWithValue("@objName", target == "COLUMN" ? dv[i]["ColName"].ToString() : dv[i]["TableName"].ToString());
				execFunName = dao.ReadSQL(cmd) != "" ? "EXECUTE sp_updateextendedproperty N'MS_Description', N'" : "EXECUTE sp_addextendedproperty N'MS_Description', N'";
				description = target == "COLUMN" ? dv[i]["ColDescription"].ToString().Replace("'", "") : dv[i]["TableDescription"].ToString().Replace("'", "");
				tableName = dv[i]["TableName"].ToString().Replace("'", "");

				switch (target)
				{
					case "VIEW":
					case "TABLE":
						script += execFunName + description + "', N'SCHEMA', N'dbo', N'" + target + "', N'" + tableName + "', NULL, NULL ;";
						break;
					case "COLUMN":
						script += execFunName + description + "', N'SCHEMA', N'dbo', N'TABLE', N'" + tableName + "', N'COLUMN', N'" + dv[i]["ColName"].ToString().Replace("'", "") + "' ;";
						break;
					default:
						break;
				}
			}

			return script;
		}

		private string GeneratScriptGetTable()
		{
			string script = @"
							   SELECT 
								tbl.table_name AS TableName, 
								prop.value AS TableDescription,
								tbl.table_type AS TableType
							  FROM information_schema.tables tbl
							  LEFT JOIN sys.extended_properties prop 
								ON prop.major_id = object_id(tbl.table_schema + '.' + tbl.table_name) 
								AND prop.minor_id = 0
								AND prop.name = 'MS_Description' 
							  WHERE tbl.table_type = 'base table' OR tbl.table_type = 'VIEW' 
							  ORDER BY TableName";
			return script;
		}

		private string GeneratScriptGetCol()
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
								) as ColDescription,
								ordinal_position
							  FROM
								INFORMATION_SCHEMA.TABLES  a
								LEFT JOIN INFORMATION_SCHEMA.COLUMNS b ON (a.TABLE_NAME=b.TABLE_NAME)
							  WHERE
								TABLE_TYPE='BASE TABLE'
							   UNION ALL
							   SELECT
								a.TABLE_NAME                as TableName,
								(SELECT 'true' FROM sys.identity_columns c WHERE OBJECT_ID(a.TABLE_NAME) = c.object_id AND b.COLUMN_NAME  = c.name) as IsIdentity,
								b.COLUMN_NAME               as ColName,
								b.DATA_TYPE                 as ColType,
								b.CHARACTER_MAXIMUM_LENGTH  as ColLength,
								b.COLUMN_DEFAULT            as DefaultValue,
								b.COLLATION_NAME            as 'CollationName',
								(CASE b.IS_NULLABLE WHEN 'YES' THEN 1 ELSE 0 END) as IsNullable,
								0 AS IsPK,
								'not support' as ColDescription,
								ordinal_position
								 FROM
								INFORMATION_SCHEMA.VIEWS  a
								LEFT JOIN INFORMATION_SCHEMA.COLUMNS b ON (a.TABLE_NAME=b.TABLE_NAME)
								 ORDER BY
								a.TABLE_NAME, ordinal_position";
			return script;
		}

		private string GeneratScriptGetFK()
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

		private string GeneratScriptGetIndex()
		{
			string script = @"SELECT  ix.name as IndexName, t.name AS TableName, c.name AS ColName
											FROM    sys.indexes ix
													INNER JOIN sys.tables t ON ix.object_id = t.object_id
													INNER JOIN sys.index_columns ic ON ic.index_id = ix.index_id AND ic.object_id = ix.object_id
													INNER JOIN sys.columns c ON c.object_id = ix.object_id AND c.column_id = ic.column_id";
			return script;
		}

		private string GeneratScriptGetSpAndFunc()
		{
			string script = @"   SELECT SPECIFIC_NAME, ROUTINE_DEFINITION, ROUTINE_TYPE, DATA_TYPE 
												FROM information_schema.routines 
												ORDER BY SPECIFIC_NAME";
			return script;
		}

		private string GeneratScriptGetInputParam()
		{
			string script = @"SELECT A.SPECIFIC_NAME, A.Parameter_Name, A.Data_Type, A.Character_Maximum_Length, A.Parameter_Mode 
										   FROM information_schema.PARAMETERS A
										   INNER JOIN information_schema.routines B ON A.SPECIFIC_NAME = B.SPECIFIC_NAME AND (B.ROUTINE_TYPE = 'PROCEDURE' OR B.ROUTINE_TYPE = 'FUNCTION')";
			return script;
		}

		private string GeneratScriptGetOutPutParam(string name)
		{
			string script = string.Format("SELECT '{0}' AS SPECIFIC_NAME, Name, System_Type_Name, Error_Message FROM sys.dm_exec_describe_first_result_set('{0}',null,0)", name);
			return script;
		}

		#endregion
	}
}
