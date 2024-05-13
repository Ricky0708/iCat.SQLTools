using iCat.DB.Client.Implements;
using iCat.SQLTools.enums;
using iCat.SQLTools.Services.Interfaces;
using iCat.Worker.Interfaces;
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCat.SQLTools.Services.Implements
{
    public class DBProvider : IDBProvider
    {
        private Dictionary<string, Func<DBClient>> _dbClients = new Dictionary<string, Func<DBClient>>();

        public string Category => "DBClientProvider";

        public async Task<object?> DoJob(object? obj)
        {
            return await Task.FromResult(111);
        }

        public Func<DBClient> GetDBClientCreator(string key)
        {
            lock (_dbClients)
            {
                return _dbClients.First().Value;
            }
        }

        public void SetNewDbClient(ConnectionType connectionType, string connectionString)
        {
            lock (_dbClients)
            {
                _dbClients.Clear();
                switch (connectionType)
                {
                    case ConnectionType.MSSQL:
                        _dbClients.Add(connectionType.ToString(), () => new DBClient(new SqlConnection(connectionString)));
                        break;
                    case ConnectionType.MySQL:
                        _dbClients.Add(connectionType.ToString(), () => new DBClient(new MySqlConnection(connectionString)));
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

    }
}
