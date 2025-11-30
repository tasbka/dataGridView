using DataGridView.Repository.Contracts;
using DataGridView.Services;
using dataGridView;
using DataGridView.Repository;
using DataGridView.Services.Contracts;

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
            ApplicationConfiguration.Initialize();

            IStorage storage = new InMemoryStorage();
            ICarService carService = new CarService(storage);
            
            Application.Run(new MainForm(carService));
        }
    }
}