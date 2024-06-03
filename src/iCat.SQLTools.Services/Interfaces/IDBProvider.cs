using iCat.SQLTools.Repositories.Enums;
using iCat.SQLTools.Shareds.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCat.SQLTools.Services.Interfaces
{
    public interface IDBProvider : iCat.DB.Client.Factory.Interfaces.IDBClientProvider
    {
        void AddOrUpdateDbClient(string key, ConnectionType connectionType, string connectionString);
    }
}
