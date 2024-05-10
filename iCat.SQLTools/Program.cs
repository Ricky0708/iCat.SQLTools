using iCat.DB.Client.Extension.Web;
using iCat.DB.Client.Factory.Implements;
using iCat.DB.Client.Factory.Interfaces;
using iCat.SQLTools.Services.Implements;
using iCat.Worker.Implements;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

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

            var dbClientProvider = provider.GetRequiredService<iCat.SQLTools.Services.Interfaces.IDBClientProvider>();

            var task = new IntervalTask(dbClientProvider, 5000, new Worker.Models.IntervalTaskOption
            {
                IsExecuteWhenStart = true,
                RetryInterval = 1000,
                RetryTimes = 5
            });
            task.Start();
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
                    services.AddSingleton<IDBClientProvider>(s => s.GetRequiredService<iCat.SQLTools.Services.Interfaces.IDBClientProvider>());
                    services.AddSingleton<iCat.SQLTools.Services.Interfaces.IDBClientProvider, DBClientProvider>();
                    services.AddScoped<IDBClientFactory, DBClientFactory>();
                    services.AddSingleton<MainForm>();
                });
        }
    }
}