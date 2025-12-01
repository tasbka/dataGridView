using DataGridView.Repository.Contracts;
using DataGridView.Services;
using dataGridView;
using DataGridView.Repository;
using DataGridView.Services.Contracts;
using Serilog;

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
        .WriteTo.Seq("http://localhost:5341",
          apiKey: "ilGJHIZ2Pb05nGLsAXkJ")
        .CreateLogger();

            try
            {
                Log.Information("Запуск приложения");

                ApplicationConfiguration.Initialize();

                IStorage storage = new InMemoryStorage();
                ICarService carService = new CarService(storage);

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