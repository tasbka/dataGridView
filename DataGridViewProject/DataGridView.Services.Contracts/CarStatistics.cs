namespace DataGridView.Services.Contracts
{
    /// <summary>
    /// Статистика по автомобилям
    /// </summary>
    public class CarStatistics
    {
        /// <summary>
        /// Общее количество автомобилей
        /// </summary>
        public int TotalCars { get; set; }

        /// <summary>
        /// Количество автомобилей с критически низким уровнем топлива
        /// </summary>
        public int LowFuelCars { get; set; }

        /// <summary>
        /// Общая стоимость аренды всех автомобилей
        /// </summary>
        public decimal TotalRentalValue { get; set; }

        /// <summary>
        /// Средний пробег автомобилей
        /// </summary>
        public double AverageMileage { get; set; }
    }
}
