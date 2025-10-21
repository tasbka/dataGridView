using dataGridView.Models;
using dataGridView.Forms;
using dataGridView.Services;

namespace dataGridView
{
    public partial class MainForm : Form
    {
        private readonly List<CarModel> items;
        private readonly BindingSource bindingSource = new();

        public MainForm()
        {
            InitializeComponent();

            items = new List<CarModel>
    {
            new CarModel
            {
                CarMake = CarMake.Lada,
                AutoNumber = "LO123L",
                Mileage = 12.1,
                FuelConsumption = 12.1,
                CurrentFuelVolume = 12,
                RentCostPerMinute = 1

            }
            };

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

        private void dataGridViewCar_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var col = dataGridViewCar.Columns[e.ColumnIndex];
            var car = (CarModel)dataGridViewCar.Rows[e.RowIndex].DataBoundItem;

            if (car == null)
                return;

            if (col.DataPropertyName == nameof(CarModel.CarMake))
            {
                switch (car.CarMake)
                {
                    case CarMake.Lada:
                        e.Value = "Лада Гранда";
                        break;
                    case CarMake.Mitsubishi:
                        e.Value = "Митсубиси";
                        break;
                    case CarMake.Hyundai:
                        e.Value = "Хёндай Сорялис";
                        break;
                    default:
                        e.Value = CarMake.Unknow;
                        break;
                }
            }
        }

        private void dataGridViewCar_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

        }

        private void toolStripButtonProperties_Click(object sender, EventArgs e)
        {
            var add = new AddCar();

            if (add.ShowDialog(this) == DialogResult.OK)
            {
                items.Add(add.CurrentCar);
                bindingSource.ResetBindings(false);
                MessageBox.Show("Автомобиль успешно добавлен!");
            }
        }

        private void SetStatistic()
        {

        }
    }
}
