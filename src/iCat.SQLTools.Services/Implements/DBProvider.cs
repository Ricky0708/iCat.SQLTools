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
                return _dbClients.First(p => p.Key == key).Value;
            }
        }

        public void AddOrUpdateDbClient(string key, ConnectionType connectionType, string connectionString)
        {
            lock (_dbClients)
            {
                if (_dbClients.TryGetValue(key, out var dbClient))
                {

                    dbClient = connectionType switch
                    {
                        ConnectionType.MSSQL => () => new DBClient(new SqlConnection(connectionString)),
                        ConnectionType.MySQL => () => new DBClient(new MySqlConnection(connectionString)),
                        _ => throw new NotImplementedException(),
                    };
                }
                else
                {
                    _dbClients.Add(key, connectionType switch
                    {
                        ConnectionType.MSSQL => () => new DBClient(new SqlConnection(connectionString)),
                        ConnectionType.MySQL => () => new DBClient(new MySqlConnection(connectionString)),
                        _ => throw new NotImplementedException(),
                    });
                }
            }
        }

    }
}
