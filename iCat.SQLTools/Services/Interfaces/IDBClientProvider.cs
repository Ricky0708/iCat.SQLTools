using iCat.SQLTools.enums;
using iCat.Worker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCat.SQLTools.Services.Interfaces
{
    public interface IDBClientProvider : iCat.DB.Client.Factory.Interfaces.IDBClientProvider, IJob
    {
        void SetNewDbClient(ConnectionType connectionType, string connectionString);
    }
}
