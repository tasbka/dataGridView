using DataGridView.Services;
using dataGridView;
using Serilog;
using DataGridView.Services.Contracts;
using DataGridView.Repository.Contracts;
using DataGridView.Repository;

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
                ApplicationConfiguration.Initialize();
                IStorage storage = new InMemoryStorage();
                ICarService carService = new CarService(storage);
                var mainForm = new MainForm(carService);

                Application.Run(mainForm);
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