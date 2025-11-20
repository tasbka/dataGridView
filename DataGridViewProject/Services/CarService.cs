using DataGridView.Entities.Models;
using DataGridView.Services.Contracts;
using Services.Contracts;

namespace DataGridView.Services
{
    /// <summary>
    /// Сервис для доступа к автомобилям, хранящимся в памяти
    /// </summary>
    public class CarService : ICarService
    {
        private readonly List<CarModel> cars;

        /// <summary>
        /// Инициализация экземпляра InMemoryStorage
        /// </summary>
        public CarService()
        {
            // Начальные данные
            cars =
            [
                new CarModel
                {
                    Id = Guid.NewGuid(),
                    CarMake = CarMake.Hyundai,
                    AutoNumber = "КЕ123К",
                    Mileage = 100,
                    FuelConsumption = 50,
                    CurrentFuelVolume = 100,
                    RentCostPerMinute = 100
                },
                new CarModel
                {
                    Id = Guid.NewGuid(),
                    CarMake = CarMake.Lada,
                    AutoNumber = "ЛО123Л",
                    Mileage = 300,
                    FuelConsumption = 50,
                    CurrentFuelVolume = 5,
                    RentCostPerMinute = 120
                },
                new CarModel
                {
                    Id = Guid.NewGuid(),
                    CarMake = CarMake.Mitsubishi,
                    AutoNumber = "ЛО123Х",
                    Mileage = 150,
                    FuelConsumption = 40,
                    CurrentFuelVolume = 100,
                    RentCostPerMinute = 90
                }
            ];
        }

        /// <inheritdoc/>
        public async Task<List<CarModel>> GetAllCarsAsync() => await Task.FromResult(cars);

        /// <inheritdoc/>
        async Task ICarService.AddCarAsync(CarModel car)
        {
            cars.Add(car);
            await Task.CompletedTask;
        }

        /// <inheritdoc/>
        async Task ICarService.UpdateCarAsync(CarModel car)
        {
            var existingCar = cars.FirstOrDefault(c => c.Id == car.Id);
            if (existingCar == null)
            {
                return;
            }

            existingCar.CarMake = car.CarMake;
            existingCar.AutoNumber = car.AutoNumber;
            existingCar.Mileage = car.Mileage;
            existingCar.FuelConsumption = car.FuelConsumption;
            existingCar.CurrentFuelVolume = car.CurrentFuelVolume;
            existingCar.RentCostPerMinute = car.RentCostPerMinute;

            await Task.CompletedTask;
        }

        /// <inheritdoc/>
        async Task ICarService.DeleteCarAsync(Guid id)
        {
            var existingCar = cars.FirstOrDefault(c => c.Id == id);
            if (existingCar == null)
            {
                return;
            }
            cars.Remove(existingCar);

            await Task.CompletedTask;
        }

        /// <inheritdoc/>
        async Task<CarModel?> ICarService.GetCarByIdAsync(Guid id) => await Task.FromResult(cars.FirstOrDefault(c => c.Id == id));

        /// <inheritdoc/>
        async Task<CarStatistics> ICarService.GetStatisticsAsync()
        {
            var cars = await GetAllCarsAsync();
            var statistics = new CarStatistics
            {
                TotalCars = cars.Count,
                LowFuelCars = cars.Count(c => c.CurrentFuelVolume < 7),
                TotalRentalValue = cars.Sum(c => (decimal)c.RentCostPerMinute),
                AverageMileage = cars.Any() ? cars.Average(c => c.Mileage) : 0
            };
            return statistics;
        }
    }
}
