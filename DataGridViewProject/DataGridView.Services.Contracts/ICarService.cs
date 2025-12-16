using DataGridView.Entities2;

namespace DataGridView.Services.Contracts
{
    /// <summary>
    /// Интерфейс сервиса для работы с автомобилями
    /// </summary>
    public interface ICarService
    {
        /// <summary>
        /// Получить все автомобили
        /// </summary>
        Task<List<CarModel>> GetAllCarsAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Добавить новый автомобиль
        /// </summary>
        Task AddCarAsync(CarModel car, CancellationToken cancellationToken);

        /// <summary>
        /// Обновить автомобиль
        /// </summary>
        Task UpdateCarAsync(CarModel car, CancellationToken cancellationToken);

        /// <summary>
        /// Удалить автомобиль по ID
        /// </summary>
        Task DeleteCarAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Найти автомобиль по ID
        /// </summary>
        Task<CarModel?> GetCarByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить статистику по автомобилям в прокате
        /// </summary>
        Task<CarStatistics> GetStatisticsAsync(CancellationToken cancellationToken);
    }
}
