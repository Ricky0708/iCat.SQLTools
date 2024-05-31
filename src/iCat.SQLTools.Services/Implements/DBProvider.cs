using iCat.DB.Client.Implements;
using iCat.SQLTools.Repositories.Enums;
using iCat.SQLTools.Services.Interfaces;
using iCat.SQLTools.Shareds.Enums;
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

        public void AddOrUpdateDbClient(ConnectionType connectionType, string connectionString)
        {
            lock (_dbClients)
            {
                if (_dbClients.TryGetValue(connectionType.ToString(), out var dbClient))
                {

                    switch (connectionType)
                    {
                        case ConnectionType.MSSQL:
                            dbClient = () => new DBClient(new SqlConnection(connectionString));
                            break;
                        case ConnectionType.MySQL:
                            dbClient = () => new DBClient(new MySqlConnection(connectionString));
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                }
                else
                {
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
}
