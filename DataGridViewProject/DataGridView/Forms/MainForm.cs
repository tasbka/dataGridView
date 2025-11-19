using dataGridView.Forms;
using System.Windows.Forms;
using DataGridView.DataAccess.Models;
using DataGridView.BussinessLogic.Services;
using DataGridView.DataAccess.Repositories;

namespace dataGridView
{
    public partial class MainForm : Form
    {
        private readonly ICarService carService;
        private readonly BindingSource bindingSource = new();
        private readonly CancellationTokenSource cts = new();
        private List<CarModel> items = new();

        public MainForm()
        {
            InitializeComponent();

            var repository = new CarRepository();
            carService = new CarService(repository);

            LoadInitialData();

            CarMakeCol1.DataPropertyName = nameof(CarModel.CarMake);
            AutoNumberCol1.DataPropertyName = nameof(CarModel.AutoNumber);
            MileageCol1.DataPropertyName = nameof(CarModel.Mileage);
            FuelConsumptionCol1.DataPropertyName = nameof(CarModel.FuelConsumption);
            CurrentFuelVolumeCol1.DataPropertyName = nameof(CarModel.CurrentFuelVolume);
            RentCostPerMinuteCol1.DataPropertyName = nameof(CarModel.RentCostPerMinute);

            dataGridViewCar.AutoGenerateColumns = false;
            CarMakeCol.DataSource = Enum.GetValues(typeof(CarMake));

            bindingSource.DataSource = items;
            dataGridViewCar.DataSource = bindingSource;
        }

        private void LoadInitialData()
        {
            var initialCars = new List<CarModel>
            {
                new CarModel
                {
                    Id = Guid.NewGuid(),
                    CarMake = CarMake.Hyundai,
                    AutoNumber = "КЕ123К",
                    Mileage = 100,
                    FuelConsumption = 50,
                    CurrentFuelVolume = 100,
                    RentCostPerMinute = 100
                },
                new CarModel
                {
                    Id = Guid.NewGuid(),
                    CarMake = CarMake.Lada,
                    AutoNumber = "ЛО123Л",
                    Mileage = 300,
                    FuelConsumption = 50,
                    CurrentFuelVolume = 5,
                    RentCostPerMinute = 120
                },
                new CarModel
                {
                    Id = Guid.NewGuid(),
                    CarMake = CarMake.Mitsubishi,
                    AutoNumber = "ЛО123Х",
                    Mileage = 150,
                    FuelConsumption = 40,
                    CurrentFuelVolume = 100,
                    RentCostPerMinute = 90
                }
            };

            foreach (var car in initialCars)
            {
                carService.AddCar(car);
            }

            RefreshData();
        }

        /// <summary>
        /// Метод обновления всех данных на форме
        /// </summary>
        private void RefreshData()
        {
            // Берем данные ИЗ СЕРВИСА, а не из локального списка
            items = carService.GetAllCars();
            bindingSource.DataSource = null;
            bindingSource.DataSource = items;
            bindingSource.ResetBindings(false);
            SetStatistic();
        }

        /// <summary>
        /// Обработчик события форматирования ячеек DataGridView
        /// </summary>
        private void dataGridViewCar_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var col = dataGridViewCar.Columns[e.ColumnIndex];
            var car = (CarModel)dataGridViewCar.Rows[e.RowIndex].DataBoundItem;

            if (car == null)
                return;

            // Отображение марки автомобиля
            if (col.DataPropertyName == nameof(CarModel.CarMake))
            {
                e.Value = car.CarMake switch
                {
                    CarMake.Lada => "Лада Веста",
                    CarMake.Mitsubishi => "Митсубиси Аутлендер",
                    CarMake.Hyundai => "Хёндай Крета",
                    CarMake.Unknow or _ => "Неизвестно"
                };
            }

            // Расчёт запаса хода по топливу (часы)
            else if (col.Name == "FuelReserveHoursCol")
            {
                if (car.FuelConsumption > 0)
                    e.Value = Math.Round(car.CurrentFuelVolume / car.FuelConsumption, 2);
                else
                {
                    e.Value = "—";
                }
            }

            // Расчёт суммы аренды до полного расхода топлива
            else if (col.Name == "RentAmountCol")
            {
                if (car.FuelConsumption > 0)
                {
                    double fuelReserveHours = car.CurrentFuelVolume / car.FuelConsumption;
                    double rentAmount = fuelReserveHours * 60 * car.RentCostPerMinute;
                    e.Value = Math.Round(rentAmount, 2);
                }
                else
                {
                    e.Value = "—";
                }

            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки Добавить товар
        /// </summary>
        private void toolStripButtonProperties_Click(object sender, EventArgs e)
        {
            var addForm = new AddCar();
            if (addForm.ShowDialog(this) == DialogResult.OK)
            {
                carService.AddCar(addForm.CurrentCar);
                MessageBox.Show("Автомобиль успешно добавлен!");
            }
        }

        /// <summary>
        /// Метод обновоения общих данных о товарах
        /// </summary>
        private void SetStatistic()
        {
            var lowFuelCars = items.Count(car => car.CurrentFuelVolume < 7);
            toolStripStatusLabelStatusCar.Text = $"Автомобили с критически низким уровнем запаса хода: {lowFuelCars}";
            toolStripStatusLabelCount.Text = $"Количество автомобилей: {items.Count}";
        }

        /// <summary>
        /// Обработчик нажатия кнопки Редактировать товар
        /// </summary>
        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewCar.CurrentCell == null)
            {
                MessageBox.Show("Выберите автомобиль для редактирования!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedCar = (CarModel)dataGridViewCar.CurrentRow.DataBoundItem;
            var editForm = new AddCar(selectedCar);

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                carService.UpdateCar(editForm.CurrentCar);
                MessageBox.Show("Автомобиль успешно обновлен!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки Удалить товар
        /// </summary>
        private void toolStripButtonDel_Click(object sender, EventArgs e)
        {
            if (dataGridViewCar.CurrentCell == null)
            {
                MessageBox.Show("Выберите автомобиль для удаления!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var car = (CarModel)dataGridViewCar.CurrentRow.DataBoundItem;
            if (MessageBox.Show($"Вы действительно желаете удалить автомобиль с номером '{car.AutoNumber}'?",
                "Удаление автомобиля", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                carService.DeleteCar(car.Id);
                MessageBox.Show("Автомобиль успешно удален!", "Успех");
            }
        }

        private void dataGridViewCar_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var col = dataGridViewCar.Columns[e.ColumnIndex];
            var car = (CarModel)dataGridViewCar.Rows[e.RowIndex].DataBoundItem;

            if (car == null)
                return;

            // Отображение марки автомобиля
            if (col.DataPropertyName == nameof(CarModel.CarMake))
            {
                e.Value = car.CarMake switch
                {
                    CarMake.Lada => "Лада Веста",
                    CarMake.Mitsubishi => "Митсубиси Аутлендер",
                    CarMake.Hyundai => "Хёндай Крета",
                    CarMake.Unknow or _ => "Неизвестно"
                };
            }

            // Расчёт запаса хода по топливу (часы)
            else if (col.Name == "FuelReserveHoursCol")
            {
                if (car.FuelConsumption > 0)
                    e.Value = Math.Round(car.CurrentFuelVolume / car.FuelConsumption, 2);
                else
                {
                    e.Value = "—";
                }
            }

            // Расчёт суммы аренды до полного расхода топлива
            else if (col.Name == "RentAmountCol")
            {
                if (car.FuelConsumption > 0)
                {
                    double fuelReserveHours = car.CurrentFuelVolume / car.FuelConsumption;
                    double rentAmount = fuelReserveHours * 60 * car.RentCostPerMinute;
                    e.Value = Math.Round(rentAmount, 2);
                }
                else
                {
                    e.Value = "—";
                }

            }
        }
    }
}
