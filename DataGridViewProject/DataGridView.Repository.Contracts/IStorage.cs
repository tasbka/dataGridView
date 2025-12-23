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
    }
}
