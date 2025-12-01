using DataGridView.Entities2;
using DataGridView.Repository.Contracts;
using DataGridView.Services.Contracts;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using System.Diagnostics;
using System.Runtime.CompilerServices;


namespace DataGridView.Services
{
    /// <summary>
    /// Сервис для работы с автомобилями (бизнес-логика)
    /// </summary>
    public class CarService : ICarService
    {
        private readonly IStorage storage;
        private readonly ILogger<CarService> logger;

        /// <summary>
        /// Инициализация сервиса с хранилищем
        /// </summary>
        public CarService(IStorage storageCar, ILogger<CarService> loggerCar = null)
        {
            storage = storageCar;
            logger = loggerCar;


        }

        public async Task<List<CarModel>> GetAllCarsAsync()
        {
            var sw = Stopwatch.StartNew();
            try
            {
                var result = await storage.GetAllCarsAsync();
                return result;
            }
            finally
            {
                sw.Stop();
                var ms = sw.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
                Log.Debug("ICarService.GetAllCarsAsync выполнен за {ms:F6} мс", ms);
            }
        }

        public async Task AddCarAsync(CarModel car)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                await storage.AddCarAsync(car);
            }
            finally
            {
                sw.Stop();
                var ms = sw.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
                Log.Debug("ICarService.AddCarAsync выполнен за {ms:F6} мс", ms);
            }
        }

        public async Task UpdateCarAsync(CarModel car)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                var existingCar = await storage.GetCarByIdAsync(car.Id);

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

                await storage.UpdateCarAsync(existingCar);
            }
            finally
            {
                sw.Stop();
                var ms = sw.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
                Log.Debug("ICarService.UpdateCarAsync выполнен за {ms:F6} мс", ms);
            }
        }

        public async Task DeleteCarAsync(Guid id)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                await storage.DeleteCarAsync(id);
            }
            finally
            {
                sw.Stop();
                var ms = sw.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
                Log.Debug("ICarService.DeleteCarAsync выполнен за {ms:F6} мс", ms);
            }
        }

        public async Task<CarModel?> GetCarByIdAsync(Guid id)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                var result = await storage.GetCarByIdAsync(id);
                return result;
            }
            finally
            {
                sw.Stop();
                var ms = sw.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
                Log.Debug("ICarService.GetCarByIdAsync выполнен за {ms:F6} мс", ms);
            }
        }

        public async Task<CarStatistics> GetStatisticsAsync()
        {
            var sw = Stopwatch.StartNew();
            try
            {
                var cars = await storage.GetAllCarsAsync();

                var statistics = new CarStatistics
                {
                    TotalCars = cars.Count,
                    LowFuelCars = cars.Count(c => c.CurrentFuelVolume < AppConstants.CriticalFuelLevel),
                    TotalRentalValue = cars.Sum(c => (decimal)c.RentCostPerMinute),
                    AverageMileage = cars.Any() ? cars.Average(c => c.Mileage) : 0
                };

                return statistics;
            }
            finally
            {
                sw.Stop();
                var ms = sw.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
                Log.Debug("ICarService.GetStatisticsAsync выполнен за {ms:F6} мс", ms);
            }
        }
    }
}
