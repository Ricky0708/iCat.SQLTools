using iCat.DB.Client.Factory.Implements;
using iCat.DB.Client.Factory.Interfaces;
using iCat.SQLTools.Repositories.Implements;
using iCat.SQLTools.Repositories.Interfaces;
using iCat.SQLTools.Services.Implements;
using iCat.SQLTools.Services.Interfaces;
using iCat.SQLTools.Services.Managers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Text;
using System.Xml.Linq;

namespace iCat.SQLTools.ConsoleTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var host = CreateHostBuilder().Build();

            //string connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.99.2)(PORT=1521))(CONNECT_DATA=(SID=XE)));User Id=sys;Password=Aa123456;DBA Privilege=SYSDBA;";
            string connectionString = "";
            var service = host.Services.GetService<ISchemaService>();
            var ds = service.GetDatasetFromDB("Oracle", Repositories.Enums.ConnectionType.Oracle);
            var tableScheme = service.GetTableSchema("Oracle", Repositories.Enums.ConnectionType.Oracle, "SELECT * FROM TB_FIN_SALEEMPTYINV", "TB_FIN_SALEEMPTYINV");
            var resultClass = service.GenerateClassWithSummary(tableScheme, ds.Tables["Columns"], "", "", "Test", "SELECT * FROM TB_FIN_SALEEMPTYINV");
            var resultSelect = service.GenerateDapperScript(ds.Tables["Columns"], "TB_FIN_SALEEMPTYINV", Shareds.Enums.ScriptKind.Select, Shareds.Enums.ParameterType.Oracle);
        }
        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {

                    services.AddSingleton<ISettingConfigService, SettingConfigService>();

                    services.AddSingleton<IFileService>(s => new FileService("Config", Path.Combine("Configs")));
                    services.AddSingleton<IDBDiagramService, DBDiagramService>();


                    services.AddScoped<ISchemaService, SchemaService>();
                    services.AddScoped<ISchemaRepository, OracleSchemaRepository>();

                    services.AddSingleton<DatasetManagerFactory>();
                    services.AddScoped<IUnitOfWorkFactory, DBClientFactory>();
                    services.AddScoped<IConnectionFactory, DBClientFactory>(s => (DBClientFactory)s.GetRequiredService<IUnitOfWorkFactory>());
                    services.AddSingleton<IDBClientProvider>(s => s.GetRequiredService<IDBProvider>());
                    services.AddSingleton<IDBProvider>(s =>
                    {
                        var result = new DBProvider();
                        result.AddOrUpdateDbClient("Oracle", Repositories.Enums.ConnectionType.Oracle, "");
                        return result;
                    });
                });
        }
    }
}
