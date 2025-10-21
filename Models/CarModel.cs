using dataGridView.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataGridView.Models
{
    public class CarModel
    {
        public Guid Id {  get; set; }

        public CarMake CarMake { get; set; }

        public string AutoNumber { get; set; } = string.Empty;

        public double Mileage { get; set; }

        public double FuelConsumption { get; set; }

        public double CurrentFuelVolume { get; set; }

        public double RentCostPerMinute { get; set; }

        public double FuelReserveHours
        {
            get
            {
                if (FuelConsumption <= 0)
                    return 0;
                return CurrentFuelVolume / FuelConsumption;
            }
        }

        public double RentAmount
        {
            get
            {
                if (FuelConsumption <= 0)
                    return 0;
                return FuelReserveHours * RentCostPerMinute;
            }
        }
    }
}
