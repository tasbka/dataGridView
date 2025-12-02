using DataGridView.Services;
using dataGridView;
using Serilog;
using DataGridView.Services.Contracts;
using DataGridView.Repository.Contracts;
using DataGridView.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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
           

            Log.Logger = new LoggerConfiguration()
             .MinimumLevel.Debug()
             .WriteTo.Debug()
             .WriteTo.File("logs/log-.txt",
             rollingInterval: RollingInterval.Day,
             outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
        .WriteTo.Seq(serverUrl: "http://localhost:5341",
          apiKey: "DPwmqCMR9DVrnK69JR0f",
          controlLevelSwitch: null)
        .CreateLogger();

            try
            {
                Log.Information("Сервис автомобилей инициализирован");

                // Создание фабрики логгеров Microsoft.Extensions.Logging
                var serviceCollection = new ServiceCollection()
                    .AddLogging(builder =>
                    {
                        builder.ClearProviders();
                        builder.AddSerilog(dispose: true); 
                    });

                var serviceProvider = serviceCollection.BuildServiceProvider();
                var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

                ApplicationConfiguration.Initialize();
                IStorage storage = new InMemoryStorage();
                ICarService carService = new CarService(storage, loggerFactory);

                Application.Run(new MainForm(carService));
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application terminated unexpectedly");
                MessageBox.Show($"Произошла критическая ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}