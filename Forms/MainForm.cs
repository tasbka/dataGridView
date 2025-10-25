using dataGridView.Models;
using dataGridView.Forms;
using System.Windows.Forms;

namespace dataGridView
{
    public partial class MainForm : Form
    {
        private readonly List<CarModel> items;
        private readonly BindingSource bindingSource = new();

        public MainForm()
        {
            InitializeComponent();

            items = new List<CarModel>();
            items.Add(new CarModel
            {
                Id = Guid.NewGuid(),
                CarMake = CarMake.Hyundai,
                AutoNumber = "КЕ123К",
                Mileage = 100,
                FuelConsumption = 50,
                CurrentFuelVolume = 100,
                RentCostPerMinute = 100

            });

            items.Add(new CarModel
            {
                Id = Guid.NewGuid(),
                CarMake = CarMake.Lada,
                AutoNumber = "ЛО123Л",
                Mileage = 300,
                FuelConsumption = 50,
                CurrentFuelVolume = 5,
                RentCostPerMinute = 120

            });

            items.Add(new CarModel
            {
                Id = Guid.NewGuid(),
                CarMake = CarMake.Mitsubishi,
                AutoNumber = "ЛО123Х",
                Mileage = 150,
                FuelConsumption = 40,
                CurrentFuelVolume = 100,
                RentCostPerMinute = 90

            });

            SetStatistic();

            CarMakeCol.DataPropertyName = nameof(CarModel.CarMake);
            AutoNumberCol.DataPropertyName = nameof(CarModel.AutoNumber);
            MileageCol.DataPropertyName = nameof(CarModel.Mileage);
            FuelConsumptionCol.DataPropertyName = nameof(CarModel.FuelConsumption);
            CurrentFuelVolumeCol.DataPropertyName = nameof(CarModel.CurrentFuelVolume);
            RentCostPerMinuteCol.DataPropertyName = nameof(CarModel.RentCostPerMinute);
            FuelReserveHoursCol.DataPropertyName = nameof(CarModel.FuelReserveHours);
            RentAmountCol.DataPropertyName = nameof(CarModel.RentAmount);

            dataGridViewCar.AutoGenerateColumns = false;
            CarMakeCol.DataSource = Enum.GetValues(typeof(CarMake));

            bindingSource.DataSource = items;
            dataGridViewCar.DataSource = bindingSource;
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
        }

        /// <summary>
        /// Обработчик нажатия кнопки Добавить товар
        /// </summary>
        private void toolStripButtonProperties_Click(object sender, EventArgs e)
        {
            var add = new AddCar();

            if (add.ShowDialog(this) == DialogResult.OK)
            {
                items.Add(add.CurrentCar);
                MessageBox.Show("Автомобиль успешно добавлен!");
                OnUpdate();
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
             if (dataGridViewCar.SelectedRows.Count == 0)
             {
                MessageBox.Show("Выберите автомобиль для редактирования!", "Внимание",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
             }

            var selectedCar = (CarModel)dataGridViewCar.CurrentRow.DataBoundItem;
            var selectedIndex = items.IndexOf(selectedCar);

            var editForm = new AddCar(selectedCar);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                    items[selectedIndex] = editForm.CurrentCar;
                    OnUpdate();
                    MessageBox.Show("Автомобиль успешно обновлен!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки Удалить товар
        /// </summary>
        private void toolStripButtonDel_Click(object sender, EventArgs e)
        {
            if (dataGridViewCar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите автомобиль для удаления!", "Внимание",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var car = (CarModel)dataGridViewCar.CurrentRow.DataBoundItem;

            if (car != null &&
                MessageBox.Show($"Вы действительно желаете удалить автомобиль с номером '{car.AutoNumber}'?",
                "Удаление автомобиля",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                items.Remove(car);
                OnUpdate();
                MessageBox.Show("Автомобиль успешно удален!", "Успех");
            }
        }

        /// <summary>
        /// Метод обновления всех данных на форме
        /// </summary>
        public void OnUpdate()
        {
            bindingSource.ResetBindings(false);
            SetStatistic();
        }
    }
}
