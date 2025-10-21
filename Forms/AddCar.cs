using dataGridView.App.Infrostructure;
using dataGridView.Models;
using dataGridView.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dataGridView.Forms
{
    public partial class AddCar : Form
    {
        private readonly CarModel targetCar;
        public AddCar(CarModel? sourceCar = null)
        {
            InitializeComponent();

            if (sourceCar != null)
            {
                targetCar = new CarModel
                {
                    Id = sourceCar.Id,
                    CarMake = sourceCar.CarMake,
                    AutoNumber = sourceCar.AutoNumber,
                    Mileage = sourceCar.Mileage,
                    FuelConsumption = sourceCar.FuelConsumption,
                    CurrentFuelVolume = sourceCar.CurrentFuelVolume,
                    RentCostPerMinute = sourceCar.RentCostPerMinute,
                };

                buttonSave.Text = "Сохранить";
            }
            else
            {
                targetCar = new CarModel
                {
                    Id = Guid.NewGuid(),
                    CarMake = CarMake.Unknow,
                    AutoNumber = "0",
                    Mileage = 0,
                    FuelConsumption = 0,
                    CurrentFuelVolume = 0,
                    RentCostPerMinute = 0,
                };
            }

            comboBoxMakeCar.DataSource = Enum.GetValues(typeof(CarMake));
            comboBoxMakeCar.AddBinding(x => x.SelectedItem!, targetCar, x => x.CarMake);
            textBoxNumber.AddBinding(x => x.Text, targetCar, x => x.AutoNumber);
            numericUpDownMileage.AddBinding(x => x.Value, targetCar, x => x.Mileage);
            numericUpDownFuelConsumption.AddBinding(x => x.Value, targetCar, x => x.FuelConsumption);
            numericUpDownCurrentFuelVolume.AddBinding(x => x.Value, targetCar, x => x.CurrentFuelVolume);
            numericUpDownRentCostPerMinute.AddBinding(x => x.Value, targetCar, x => x.RentCostPerMinute);
        }
            public CarModel CurrentCar => targetCar;

    }
}
