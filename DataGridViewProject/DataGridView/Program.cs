using dataGridView;
using DataGridView.Services;
using DataGridView.Services.Contracts;

namespace DataGridView.WinForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            ICarService carService = new CarService();
            Application.Run(new MainForm(carService));
        }
    }
}