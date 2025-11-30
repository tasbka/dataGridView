using DataGridView.Entities.Contracts;

namespace DataGridView.Services.Contracts
{
    /// <summary>
    /// Интерфейс сервиса для работы с автомобилями
    /// </summary>
    public class ICarService
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

        /// <summary>
        /// Получить статистику по автомобилям в прокате
        /// </summary>
        Task<CarStatistics> GetStatisticsAsync();
    }
}
