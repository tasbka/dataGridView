using dataGridView.Forms;
using DataGridView.Entities.Models;
using DataGridView.Services.Contracts;
using System.ComponentModel.DataAnnotations;

namespace dataGridView
{
    public partial class MainForm : Form
    {
        private readonly ICarService carService1;
        private readonly BindingSource _bindingSource = new();

        /// <summary>
        /// Инициализирует экземпляр 
        /// </summary>
        public MainForm(ICarService carService)
        {
            InitializeComponent();
            carService1 = carService;

            CarMakeCol1.DataPropertyName = nameof(CarModel.CarMake);
            AutoNumberCol1.DataPropertyName = nameof(CarModel.AutoNumber);
            MileageCol1.DataPropertyName = nameof(CarModel.Mileage);
            FuelConsumptionCol1.DataPropertyName = nameof(CarModel.FuelConsumption);
            CurrentFuelVolumeCol1.DataPropertyName = nameof(CarModel.CurrentFuelVolume);
            RentCostPerMinuteCol1.DataPropertyName = nameof(CarModel.RentCostPerMinute);

            dataGridViewCar.AutoGenerateColumns = false;
            CarMakeCol.DataSource = Enum.GetValues(typeof(CarMake));
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
        private async void toolStripButtonProperties_Click(object sender, EventArgs e)
        {
            var addForm = new AddCar();
            if (addForm.ShowDialog(this) == DialogResult.OK)
            {
                await carService1.AddCarAsync(addForm.CurrentCar);
                await OnUpdateAsync();
                MessageBox.Show("Автомобиль успешно добавлен!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки Редактировать товар
        /// </summary>
        private async void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewCar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите автомобиль для редактирования!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dataGridViewCar.SelectedRows[0];
            if (selectedRow?.DataBoundItem is not CarModel selectedCar)
            {
                MessageBox.Show("Не удалось получить данные автомобиля!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var editForm = new AddCar(selectedCar);

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    await carService1.UpdateCarAsync(editForm.CurrentCar);
                    await OnUpdateAsync();
                    MessageBox.Show("Автомобиль успешно обновлен!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (ValidationException ex)
                {
                    MessageBox.Show($"Ошибка валидации: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка обновления автомобиля: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки Удалить товар
        /// </summary>
        private async void toolStripButtonDel_Click(object sender, EventArgs e)
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
                await carService1.DeleteCarAsync(car.Id);
                await OnUpdateAsync();
                MessageBox.Show("Автомобиль успешно удален!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dataGridViewCar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            var cars = await carService1.GetAllCarsAsync();
            _bindingSource.DataSource = cars.ToList();
            dataGridViewCar.DataSource = _bindingSource;
            await SetStatisticAsync();
        }

        private async Task OnUpdateAsync()
        {
            var cars = await carService1.GetAllCarsAsync();
            _bindingSource.DataSource = cars.ToList();
            _bindingSource.ResetBindings(false);
            await SetStatisticAsync();
        }

        private async Task SetStatisticAsync()
        {
            var statistics = await carService1.GetStatisticsAsync();
            toolStripStatusLabelStatusCar.Text = $"Автомобили с критически низким уровнем запаса хода: {statistics.LowFuelCars}";
            toolStripStatusLabelCount.Text = $"Количество автомобилей: {statistics.TotalCars}";
        }
    }
}
