using DataGridView.Services;
using DataGridView.Services.Contracts;
using DataGridView.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DataGridView.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarService _carService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ICarService carService, ILogger<HomeController> logger)
        {
            _carService = carService;
            _logger = logger;
        }


        /// <summary>
        /// Отображает главную страницу со списком автомобилей и статистикой
        /// </summary>
        public async Task <IActionResult> Index()
        {
            var cars = await _carService.GetAllCarsAsync();
            var statistics = await _carService.GetStatisticsAsync();

            var model = new IndexViewModel
            {
                Cars = cars,
                Statistics = statistics
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
