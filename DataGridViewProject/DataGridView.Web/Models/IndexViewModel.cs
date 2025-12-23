using DataGridView.Entities2;
using DataGridView.Services.Contracts;

namespace DataGridView.Web.Models
{
    /// <summary>
    /// Модель для главной страницы
    /// </summary>
    public class IndexViewModel
    {
        /// <summary>
        /// Список автомобилей
        /// </summary>
        public List<CarModel> Cars { get; set; } = new();

        /// <summary>
        /// Статистика по автомобилям
        /// </summary>
        public CarStatistics Statistics { get; set; } = new();
    }
}
