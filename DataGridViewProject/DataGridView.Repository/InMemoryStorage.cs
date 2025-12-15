using DataGridView.Entities2;
using DataGridView.Repository.Contracts;


namespace DataGridView.Repository
{
    /// <summary>
    /// In-memory реализация хранилища автомобилей
    /// </summary>
    public class InMemoryStorage : IStorage
    {
        private readonly List<CarModel> cars;

        /// <summary>
        /// Инициализация экземпляра InMemoryStorage
        /// </summary>
        public InMemoryStorage()
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

        /// <summary>
        /// Получает все автомобили из хранилища
        /// </summary>
        public async Task<List<CarModel>> GetAllCarsAsync()
        {
            return await Task.FromResult(cars);
        }

        /// <summary>
        /// Добавляет новый автомобиль в хранилище
        /// </summary>
        public async Task AddCarAsync(CarModel car)
        {
            cars.Add(car);
            await Task.CompletedTask;
        }

        /// <summary>
        /// Обновляет существующий автомобиль в хранилище
        /// </summary>
        public async Task UpdateCarAsync(CarModel car)
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

        /// <summary>
        /// Удаляет автомобиль из хранилища по его ид
        /// </summary>
        public async Task DeleteCarAsync(Guid id)
        {
            var existingCar = cars.FirstOrDefault(c => c.Id == id);
            if (existingCar == null)
            {
                return;
            }
            cars.Remove(existingCar);

            await Task.CompletedTask;
        }

        /// <summary>
        /// Находит автомобиль в хранилище по его ид
        /// </summary>
        public async Task<CarModel?> GetCarByIdAsync(Guid id)
        {
            return await Task.FromResult(cars.FirstOrDefault(c => c.Id == id));
        }
    }
}
