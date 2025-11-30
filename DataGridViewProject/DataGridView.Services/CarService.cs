using DataGridView.Entities2;
using DataGridView.Repository.Contracts;
using DataGridView.Services.Contracts;


namespace DataGridView.Services
{
    /// <summary>
    /// Сервис для работы с автомобилями (бизнес-логика)
    /// </summary>
    public class CarService : ICarService
    {
        private readonly IStorage storage;

        /// <summary>
        /// Инициализация сервиса с хранилищем
        /// </summary>
        public CarService(IStorage storageCar)
        {
            storage = storageCar;
        }

        public async Task<List<CarModel>> GetAllCarsAsync()
        {
            return await storage.GetAllCarsAsync();
        }

        public async Task AddCarAsync(CarModel car)
        {
            // Бизнес-логика: проверка уникальности гос номера
            var existingCars = await storage.GetAllCarsAsync();
            if (existingCars.Any(c => c.AutoNumber.Equals(car.AutoNumber, StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException($"Автомобиль с номером '{car.AutoNumber}' уже существует");
            }

            await storage.AddCarAsync(car);
        }

        public async Task UpdateCarAsync(CarModel car)
        {
            // Бизнес-логика: проверка существования автомобиля
            var existingCar = await storage.GetCarByIdAsync(car.Id);
            if (existingCar == null)
            {
                throw new ArgumentException($"Автомобиль с ID '{car.Id}' не найден");
            }

            await storage.UpdateCarAsync(car);
        }

        public async Task DeleteCarAsync(Guid id)
        {
            // Бизнес-логика: проверка существования автомобиля
            var existingCar = await storage.GetCarByIdAsync(id);
            if (existingCar == null)
            {
                throw new ArgumentException($"Автомобиль с ID '{id}' не найден");
            }

            await storage.DeleteCarAsync(id);
        }

        public async Task<CarModel?> GetCarByIdAsync(Guid id)
        {
            return await storage.GetCarByIdAsync(id);
        }

        public async Task<CarStatistics> GetStatisticsAsync()
        {
            var cars = await storage.GetAllCarsAsync();

            // Бизнес-логика расчета статистики
            var statistics = new CarStatistics
            {
                TotalCars = cars.Count,
                LowFuelCars = cars.Count(c => c.CurrentFuelVolume < AppConstants.CriticalFuelLevel),
                TotalRentalValue = cars.Sum(c => (decimal)c.RentCostPerMinute),
                AverageMileage = cars.Any() ? cars.Average(c => c.Mileage) : 0
            };

            return statistics;
        }
    }
}
