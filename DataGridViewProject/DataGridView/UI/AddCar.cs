using dataGridView.App.Infrastructure;
using DataGridView.Entities2;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

namespace dataGridView.Forms
{
    /// <summary>
    /// Форма редактирования/добавления авто
    /// </summary>
    public partial class AddCar : Form
    {
        private readonly CarModel targetCar;

        /// <summary>
        /// Конструктор формы добавления авто
        /// </summary>
        /// <param name="sourceCar"></param>
        public AddCar(CarModel? sourceCar = null)
        {
            InitializeComponent();

            if (sourceCar != null)
            {
                targetCar = (CarModel)sourceCar.Clone();
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
            this.AutoValidate = AutoValidate.EnableAllowFocusChange;

            comboBoxMakeCar.AddBinding(x => x.SelectedItem!, targetCar, x => x.CarMake, errorProvider);
            textBoxNumber.AddBinding(x => x.Text, targetCar, x => x.AutoNumber, errorProvider);
            numericUpDownMileage.AddBinding(x => x.Value, targetCar, x => x.Mileage, errorProvider);
            numericUpDownFuelConsumption.AddBinding(x => x.Value, targetCar, x => x.FuelConsumption, errorProvider);
            numericUpDownCurrentFuelVolume.AddBinding(x => x.Value, targetCar, x => x.CurrentFuelVolume, errorProvider);
            numericUpDownRentCostPerMinute.AddBinding(x => x.Value, targetCar, x => x.RentCostPerMinute, errorProvider);
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
            errorProvider.Clear();

            var context = new ValidationContext(targetCar);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(targetCar, context, results, true);

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

                        if (control != null)
                        {
                            errorProvider.SetError(control, validationResult.ErrorMessage);
                        }
                    }
                }
                MessageBox.Show("Пожалуйста, исправьте ошибки в форме перед сохранением.",
               "Ошибки валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

