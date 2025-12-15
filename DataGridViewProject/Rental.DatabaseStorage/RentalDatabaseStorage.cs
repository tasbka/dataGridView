using Microsoft.EntityFrameworkCore;
using DataGridView.Entities2;
using DataGridView.Repository.Contracts;

namespace Rental.DatabaseStorage
{
    /// <summary>
    /// Хранилище автомобилей в базе данных
    /// </summary>
    public class RentalDatabaseStorage : IStorage
    {
        /// <summary>
        /// Получить все автомобили из базы данных
        /// </summary>
        public async Task<List<CarModel>> GetAllCarsAsync()
        {
            using var database = new RentalDatabaseContext();
            var cars = await database.Cars.AsNoTracking().ToListAsync();
            return cars;
        }

        /// <summary>
        /// Добавить новый автомобиль в базу данных
        /// </summary>
        public async Task AddCarAsync(CarModel car)
        {
            using var database = new RentalDatabaseContext();
            database.Cars.Add(car);
            await database.SaveChangesAsync();
        }

        /// <summary>
        /// Обновить автомобиль в бд
        /// </summary>
        public async Task UpdateCarAsync(CarModel car)
        {
            using var database = new RentalDatabaseContext();
            database.Cars.Update(car);
            await database.SaveChangesAsync();
        }

        /// <summary>
        /// Удалить Автоммобиль по id 
        /// </summary>
        public async Task DeleteCarAsync(Guid id)
        {
            using var database = new RentalDatabaseContext();
            var car = await database.Cars.FindAsync(id);
            if (car != null)
            {
                database.Cars.Remove(car);
                await database.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Найти по  id
        /// </summary>
        public async Task<CarModel?> GetCarByIdAsync(Guid id)
        {
            using var database = new RentalDatabaseContext();
            var car = await database.Cars.FindAsync(id);
            return car;
        }
    }
}
