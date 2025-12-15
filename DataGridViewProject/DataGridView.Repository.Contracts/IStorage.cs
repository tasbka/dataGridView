using DataGridView.Entities2;

namespace DataGridView.Repository.Contracts
{
    /// <summary>
    /// Интерфейс хранилища для работы с автомобилями
    /// </summary>
    public interface IStorage
    {
        /// <summary>
        /// Получить все автомобили
        /// </summary>
        Task<List<CarModel>> GetAllCarsAsync();

        /// <summary>
        /// Добавить новый автомобиль
        /// </summary>
        Task AddCarAsync(CarModel car);

        /// <summary>
        /// Обновить автомобиль
        /// </summary>
        Task UpdateCarAsync(CarModel car);

        /// <summary>
        /// Удалить автомобиль по ID
        /// </summary>
        Task DeleteCarAsync(Guid id);

        /// <summary>
        /// Найти автомобиль по ID
        /// </summary>
        Task<CarModel?> GetCarByIdAsync(Guid id);
    }
}
