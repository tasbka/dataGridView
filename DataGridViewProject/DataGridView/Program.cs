using DataGridView.Repository.Contracts;
using DataGridView.Services.Contracts;
using dataGridView;
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
            ApplicationConfiguration.Initialize();

            IStorage storage = new InMemoryStorage();
            ICarService carService = new ICarService(storage);
            
            Application.Run(new MainForm(carService));
        }
    }
}