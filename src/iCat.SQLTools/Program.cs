using iCat.DB.Client.Factory.Implements;
using iCat.DB.Client.Factory.Interfaces;
using iCat.SQLTools.Forms;
using iCat.SQLTools.Models;
using iCat.SQLTools.Repositories.Implements;
using iCat.SQLTools.Repositories.Interfaces;
using iCat.SQLTools.Services.Implements;
using iCat.SQLTools.Services.Interfaces;
using iCat.SQLTools.Services.Managers;
using iCat.SQLTools.Shareds;
using iCat.SQLTools.Shareds.Shareds;
using iCat.Worker.Implements;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.ComponentModel;

namespace iCat.SQLTools
{
    internal static class Program
    {
        public static IServiceProvider? provider { get; private set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var host = CreateHostBuilder().Build();
            provider = host.Services;
            Application.Run(provider.GetRequiredService<MainForm>());
        }

        /// <summary>
        /// Create a host builder to build the service provider
        /// </summary>
        /// <returns></returns>
        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {

                    services.AddSingleton<ISettingConfigService, SettingConfigService>();
                    services.AddSingleton<SettingConfig>(s =>
                    {
                        var data = Task.Run(async () => await s.GetRequiredService<IFileService>().ReadStringFileAsync("settingConfig.json")).Result;
                        return JsonUtil.Deserialize<SettingConfig>(data)!;
                    });
                    services.AddSingleton<IFileService>(s => new FileService("Config", Path.Combine(Application.StartupPath, "Configs")));
                    services.AddSingleton<MainForm>();
                    services.AddKeyedScoped<Form, frmConfigSettingDlg>(nameof(frmConfigSettingDlg));
                    services.AddKeyedScoped<frmBase, frmTables>(nameof(frmTables));
                    //services.AddKeyedScoped<Form, frmPOCO>(nameof(frmPOCO));
                    services.AddKeyedScoped<frmBase, frmCodeGenerator_xx>(nameof(frmCodeGenerator_xx));
                    services.AddKeyedScoped<frmBase, frmCodeGenerator>(nameof(frmCodeGenerator));

                    services.AddScoped<ISchemaService, SchemaService>();
                    services.AddScoped<ISchemaRepository, MSSQLSchemaRepository>();
                    services.AddScoped<ISchemaRepository, MySQLSchemaRepository>();
                    services.AddScoped<ISchemaRepository, OracleSchemaRepository>();

                    services.AddSingleton<DatasetManagerFactory>();
                    services.AddScoped<IUnitOfWorkFactory, DBClientFactory>();
                    services.AddScoped<IConnectionFactory, DBClientFactory>(s => (DBClientFactory)s.GetRequiredService<IUnitOfWorkFactory>());
                    services.AddSingleton<IDBClientProvider>(s => s.GetRequiredService<IDBProvider>());
                    services.AddSingleton<IDBProvider>(s =>
                    {
                        var config = s.GetRequiredService<SettingConfig>();
                        var result = new DBProvider();
                        foreach (var setting in config.ConnectionSettings)
                        {
                            result.AddOrUpdateDbClient(setting.Key, setting.ConnectionType, setting.ConnectionString);
                        }
                        return result;
                    });
                });
        }
    }
}
