using dataGridView.App.Infrostructure;
using dataGridView.Models;
using dataGridView.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        private readonly ErrorProvider errorProvider = new ErrorProvider();

        public AddCar(CarModel? sourceCar = null)
        {
            InitializeComponent();

            if (sourceCar != null)
            {
                targetCar = sourceCar.Clone();
                buttonSave.Text = "Сохранить";
                Text = "Редактирование автомобиля";
            }
            else
            {
                targetCar = new CarModel();
                buttonSave.Text = "Добавить";
                Text = "Добавить Авто";
            }

            comboBoxMakeCar.DataSource = Enum.GetValues(typeof(CarMake));

            comboBoxMakeCar.AddBinding(x => x.SelectedItem!, targetCar, x => x.CarMake);
            textBoxNumber.AddBinding(x => x.Text, targetCar, x => x.AutoNumber);
            numericUpDownMileage.AddBinding(x => x.Value, targetCar, x => x.Mileage);
            numericUpDownFuelConsumption.AddBinding(x => x.Value, targetCar, x => x.FuelConsumption);
            numericUpDownCurrentFuelVolume.AddBinding(x => x.Value, targetCar, x => x.CurrentFuelVolume);
            numericUpDownRentCostPerMinute.AddBinding(x => x.Value, targetCar, x => x.RentCostPerMinute);

            ConfigureErrorProvider();
        }

        private void ConfigureErrorProvider()
        {
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider.ContainerControl = this;
        }

        /// <summary>
        /// Текущий авто
        /// </summary>
        public CarModel CurrentCar => targetCar;


        /// <summary>
        /// Метод обработки клика кнопки "Добавить" или "Сохранить"
        /// </summary>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            errorProviderError.Clear();

            var context = new ValidationContext(targetCar);
            var results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(targetCar, context, results, true);

            if (isValid)
            {
                DialogResult = DialogResult.OK;
                Close();
            }

            else
            {
                foreach (var validationResult in results)
                {
                    foreach (var memberName in validationResult.MemberNames)
                    {
                        Control? control = memberName switch
                        {
                            nameof(CarModel.CarMake) => comboBoxMakeCar,
                            nameof(CarModel.AutoNumber) => textBoxNumber,
                            nameof(CarModel.Mileage) => numericUpDownMileage,
                            nameof(CarModel.FuelConsumption) => numericUpDownFuelConsumption,
                            nameof(CarModel.RentCostPerMinute) => numericUpDownRentCostPerMinute,
                            _ => null
                        };

                        if (control != null) // Разкомментируйте этот блок
                        {
                            errorProvider.SetError(control, validationResult.ErrorMessage);
                        }
                    }
                }
            }
        }
    }
}

