using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataGridView.Services
{
    internal class AppConstants
    {
        // Константы для CarModel
        public const int AutoNumberMinLength = 3;
        public const int AutoNumberMaxLength = 6;

        public const double MileageMin = 0;
        public const double MileageMax = 1000000;

        public const double FuelConsumptionMin = 0.1;
        public const double FuelConsumptionMax = 100;

        public const double CurrentFuelVolumeMin = 0;
        public const double CurrentFuelVolumeMax = 1000;

        public const double RentCostPerMinuteMin = 0.1;
        public const double RentCostPerMinuteMax = 1000;

        // Критический уровень топлива (для статистики)
        public const double CriticalFuelLevel = 7;
    }
}
