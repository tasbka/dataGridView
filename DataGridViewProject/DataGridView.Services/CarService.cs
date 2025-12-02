using DataGridView.Entities2;
using DataGridView.Repository.Contracts;
using DataGridView.Services.Contracts;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using System.Diagnostics;


namespace DataGridView.Services
{
    /// <summary>
    /// Сервис для работы с автомобилями (бизнес-логика)
    /// </summary>
    public class CarService : ICarService
    {
        private readonly IStorage storage;
        private readonly ILogger<CarService>? logger;

        /// <summary>
        /// Инициализация сервиса с хранилищем
        /// </summary>
        public CarService(IStorage storageCar, ILoggerFactory loggerFactory)
        {
            storage = storageCar;
            logger = loggerFactory?.CreateLogger<CarService>();
        }

        /// <summary>
        /// Получает все автомобили из системы проката
        /// </summary>
        public async Task<List<CarModel>> GetAllCarsAsync()
        {
            var sw = Stopwatch.StartNew();
            try
            {
                logger?.LogDebug("Начало получения всех автомобилей");
                var result = await storage.GetAllCarsAsync();
                logger?.LogDebug("Получено {Count} автомобилей", result.Count);
                return result;
            }
            finally
            {
                sw.Stop();
                var ms = sw.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
                logger?.LogDebug("ICarService.GetAllCarsAsync выполнен за {ms:F6} мс", ms);
            }
        }

        /// <summary>
        /// Добавляет новый автомобиль в систему проката
        /// </summary>
        public async Task AddCarAsync(CarModel car)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                logger?.LogInformation("Добавление автомобиля с номером {AutoNumber}", car.AutoNumber);
                await storage.AddCarAsync(car);
                logger?.LogInformation("Автомобиль {AutoNumber} успешно добавлен", car.AutoNumber);
            }
            finally
            {
                sw.Stop();
                var ms = sw.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
                logger?.LogDebug("ICarService.AddCarAsync выполнен за {ms:F6} мс", ms);
            }
        }

        /// <summary>
        /// обновляет информацию об автомобиле в системе
        /// </summary>
        public async Task UpdateCarAsync(CarModel car)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                logger?.LogDebug("Обновление автомобиля ID: {CarId}", car.Id);
                var existingCar = await storage.GetCarByIdAsync(car.Id);

                if (existingCar == null)
                {
                    logger?.LogWarning("Автомобиль с ID {CarId} не найден для обновления", car.Id);
                    return;
                }

                existingCar.CarMake = car.CarMake;
                existingCar.AutoNumber = car.AutoNumber;
                existingCar.Mileage = car.Mileage;
                existingCar.FuelConsumption = car.FuelConsumption;
                existingCar.CurrentFuelVolume = car.CurrentFuelVolume;
                existingCar.RentCostPerMinute = car.RentCostPerMinute;

                await storage.UpdateCarAsync(existingCar);
                logger?.LogInformation("Автомобиль {AutoNumber} успешно обновлен", car.AutoNumber);
            }
            finally
            {
                sw.Stop();
                var ms = sw.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
                logger?.LogDebug("ICarService.UpdateCarAsync выполнен за {ms:F6} мс", ms);
            }
        }

        /// <summary>
        /// Удаляет автомобиль из системы по его ид
        /// </summary>
        public async Task DeleteCarAsync(Guid id)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                logger?.LogDebug("Удаление автомобиля ID: {CarId}", id);
                await storage.DeleteCarAsync(id);
                logger?.LogInformation("Автомобиль с ID {CarId} успешно удален", id);
            }
            finally
            {
                sw.Stop();
                var ms = sw.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
                logger?.LogDebug("ICarService.DeleteCarAsync выполнен за {ms:F6} мс", ms);
            }
        }

        /// <summary>
        /// Получает автомобиль по его уникальному ид
        /// </summary>
        public async Task<CarModel?> GetCarByIdAsync(Guid id)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                logger?.LogDebug("Поиск автомобиля по ID: {CarId}", id);
                var result = await storage.GetCarByIdAsync(id);
                logger?.LogDebug("Автомобиль с ID {CarId} найден: {AutoNumber}", id, result.AutoNumber);
                return result;
            }
            finally
            {
                sw.Stop();
                var ms = sw.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
                logger?.LogDebug("ICarService.GetCarByIdAsync выполнен за {ms:F6} мс", ms);
            }
        }

        /// <summary>
        /// Рассчитывает статистику по всем автомобилям в системе проката
        /// </summary>
        public async Task<CarStatistics> GetStatisticsAsync()
        {
            var sw = Stopwatch.StartNew();
            try
            {
                logger?.LogDebug("Расчет статистики по автомобилям");
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
                logger?.LogDebug("ICarService.GetStatisticsAsync выполнен за {ms:F6} мс", ms);
            }
        }
    }
}
