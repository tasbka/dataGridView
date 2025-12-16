using DataGridView.Entities2;
using DataGridView.Services.Contracts;
using DataGridView.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DataGridView.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarService _carService;

        public HomeController(ICarService carService)
        {
            _carService = carService;
        }


        /// <summary>
        /// Отображает главную страницу со списком автомобилей и статистикой
        /// </summary>
        public async Task <IActionResult> Index(CancellationToken cancellationToken = default)
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

        /// <summary>
        /// Отображает страницу подтверждения удаления автомобиля
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken = default)
        {
            var car = await _carService.GetCarByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }


        /// <summary>
        /// Выполняет удаление автомобиля после подтверждения
        /// </summary>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, CancellationToken cancellationToken = default)
        {
            await _carService.DeleteCarAsync(id);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Отображает форму редактирования автомобиля
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id, CancellationToken cancellationToken = default)
        {
            var car = await _carService.GetCarByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            var editModel = new CarEditViewModel
            {
                Id = car.Id,
                CarMake = car.CarMake,
                AutoNumber = car.AutoNumber,
                Mileage = (int)car.Mileage,
                FuelConsumption = (int)car.FuelConsumption,
                CurrentFuelVolume = (int)car.CurrentFuelVolume,
                RentCostPerMinute = (int)car.RentCostPerMinute
            };

            return View(editModel);
        }

        /// <summary>
        /// Принимает изменения автомобиля из формы
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CarEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var car = new CarModel
            {
                Id = model.Id,
                CarMake = model.CarMake,
                AutoNumber = model.AutoNumber.ToUpper(),
                Mileage = model.Mileage,
                FuelConsumption = model.FuelConsumption,
                CurrentFuelVolume = model.CurrentFuelVolume,
                RentCostPerMinute = model.RentCostPerMinute
            };

            await _carService.UpdateCarAsync(car);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Отображает форму для добавления нового автомобиля
        /// </summary>
        [HttpGet]
        public IActionResult Create()
        {
            var model = new CarEditViewModel();
            return View(model);
        }

        /// <summary>
        /// Принимает данные нового автомобиля из формы
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CarEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            var car = new CarModel
            {
                Id = Guid.NewGuid(),
                CarMake = model.CarMake,
                AutoNumber = model.AutoNumber.ToUpper(),
                Mileage = model.Mileage,
                FuelConsumption = model.FuelConsumption,
                CurrentFuelVolume = model.CurrentFuelVolume,
                RentCostPerMinute = model.RentCostPerMinute
            };

            await _carService.AddCarAsync(car);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Страница ошибки
        /// </summary>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
