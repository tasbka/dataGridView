using DataGridView.Services;
using dataGridView;
using Serilog;
using DataGridView.Repository;
using Microsoft.Extensions.Logging;
using DataGridView.Repository.Contracts;
using Rental.DatabaseStorage;

namespace DataGridView.WinForms
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
           

              using var log = new LoggerConfiguration()
             .MinimumLevel.Debug()
             .WriteTo.Debug()
             .WriteTo.File("logs/log-.txt",
             rollingInterval: RollingInterval.Day,
             outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
        .WriteTo.Seq(serverUrl: "http://localhost:5341",
          apiKey: "mU3uCMlptCg9Av0xt2ZX")
        .CreateLogger();

            // Создание фабрики логгеров Microsoft.Extensions.Logging
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddSerilog(log);
            });

            var storage = new RentalDatabaseStorage();
            var carService = new CarService(storage, loggerFactory);

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(carService));
        
        }
    }
}