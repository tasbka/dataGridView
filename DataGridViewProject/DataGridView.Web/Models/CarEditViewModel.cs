using DataGridView.Entities2;
using System.ComponentModel.DataAnnotations;

namespace DataGridView.Web.Models
{
    /// <summary>
    /// Модель автомобиля для добавления/редактирования
    /// </summary>
    public class CarEditViewModel
    {
        /// <summary>
        /// Идентификатор автомобиля
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Марка автомобиля
        /// </summary>
        [Display(Name = "Марка автомобиля")]
        [Required(ErrorMessage = "Выберите марку автомобиля")]
        public CarMake CarMake { get; set; }

        /// <summary>
        /// Государственный номер
        /// </summary>
        [Display(Name = "Государственный номер")]
        [Required(ErrorMessage = "Госномер обязателен")]
        [RegularExpression(@"^[А-ЯЁ]{1}\d{3}[А-ЯЁ]{2}$",
            ErrorMessage = "Формат: А123АА (одна буква, три цифры, две буквы)")]
        [StringLength(6, ErrorMessage = "Госномер должен быть ровно 6 символов")]
        public string AutoNumber { get; set; } = string.Empty;

        /// <summary>
        /// Пробег (км)
        /// </summary>
        [Display(Name = "Пробег, км")]
        [Required(ErrorMessage = "Пробег обязателен")]
        [Range(0, 1000000, ErrorMessage = "Пробег должен быть от 1 до 1 000 000 км")]
        public int Mileage { get; set; }

        /// <summary>
        /// Средний расход топлива (л/час)
        /// </summary>
        [Display(Name = "Расход топлива, л/час")]
        [Required(ErrorMessage = "Расход топлива обязателен")]
        [Range(0.1, 100, ErrorMessage = "Расход должен быть от 1 до 100 л/час")]
        public int FuelConsumption { get; set; }

        /// <summary>
        /// Текущий объем топлива (л)
        /// </summary>
        [Display(Name = "Текущий объем топлива, л")]
        [Required(ErrorMessage = "Объем топлива обязателен")]
        [Range(0, 200, ErrorMessage = "Объем должен быть от 1 до 200 л")]
        public int CurrentFuelVolume { get; set; }

        /// <summary>
        /// Стоимость аренды (руб/мин)
        /// </summary>
        [Display(Name = "Стоимость аренды, руб/мин")]
        [Required(ErrorMessage = "Стоимость аренды обязательна")]
        [Range(1, 1000, ErrorMessage = "Стоимость должна быть от 1 до 1000 руб/мин")]
        public int RentCostPerMinute { get; set; }
    }
}
