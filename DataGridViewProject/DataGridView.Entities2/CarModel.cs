using System.ComponentModel.DataAnnotations;

namespace DataGridView.Entities.Models
{
    /// <summary>
    /// Модель авто
    /// </summary>
    public class CarModel : ICloneable
    {
        /// <summary>
        /// Идентификатор продукта
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Марка автомобиля
        /// </summary>
        [Display(Name = "Марка автомобиля")]
        [Required(ErrorMessage = "{0} обязательна для выбора")]
        [Range(1, 3, ErrorMessage = "{0} должна быть выбрана из списка")]
        public CarMake CarMake { get; set; }

        /// <summary>
        /// Государственный номер
        /// </summary>
        [Display(Name = "Государственный номер")]
        [Required(ErrorMessage = "Гос номер обязателен")]
        [StringLength(AppConstants.AutoNumberMaxLength, MinimumLength = AppConstants.AutoNumberMinLength,
            ErrorMessage = "Гос номер должен быть от {2} до {1} символов")]
        [RegularExpression(@"^[А-ЯЁ]{2}\d{3}[А-ЯЁ]{1}$",
        ErrorMessage = "{0} должен быть в формате: АЛ123В (2 буквы-3 цифры-1 буква)")]
        public string AutoNumber { get; set; } = string.Empty;


        /// <summary>
        /// Пробег (км)
        /// </summary>
        [Display(Name = "Пробег автомобиля")]
        [Range(AppConstants.MileageMin, AppConstants.MileageMax,
            ErrorMessage = "{0} должен быть в диапазоне от {1} до {2} км")]
        public double Mileage { get; set; }

        /// <summary>
        /// Средний расход топлива (л/час)
        /// </summary>
        [Display(Name = "Средний расход топлива")]
        [Range(AppConstants.FuelConsumptionMin, AppConstants.FuelConsumptionMax,
            ErrorMessage = "{0} должен быть в диапазоне от {1} до {2} л/час")]
        public double FuelConsumption { get; set; }

        /// <summary>
        /// Текущий объем топлива (л)
        /// </summary>
        [Display(Name = "Текущий объем топлива")]
        [Range(AppConstants.CurrentFuelVolumeMin, AppConstants.CurrentFuelVolumeMax,
            ErrorMessage = "{0} должен быть в диапазоне от {1} до {2} л")]
        public double CurrentFuelVolume { get; set; }

        /// <summary>
        /// Стоимость аренды (руб/мин)
        /// </summary>
        [Display(Name = "Стоимость аренды за минуту")]
        [Range(AppConstants.RentCostPerMinuteMin, AppConstants.RentCostPerMinuteMax,
            ErrorMessage = "{0} должна быть в диапазоне от {1} до {2} руб/мин")]
        public double RentCostPerMinute { get; set; }


        /// <summary>
        ///  реализация ICloneable
        /// </summary>
        public object Clone()
        {
            return new CarModel
            {
                Id = this.Id,
                CarMake = this.CarMake,
                AutoNumber = this.AutoNumber,
                Mileage = this.Mileage,
                FuelConsumption = this.FuelConsumption,
                CurrentFuelVolume = this.CurrentFuelVolume,
                RentCostPerMinute = this.RentCostPerMinute
            };
        }
    }

}
