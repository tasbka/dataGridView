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
            items = new List<CarModel>();
            items.Add(new CarModel
            {
                Id = Guid.NewGuid(),
                CarMake = CarMake.Lada,
                AutoNumber = "LO123L",
                Mileage = 12.1,
                FuelConsumption = 1212.1,
                CurrentFuelVolume = 12,
                RentCostPerMinute = 1,
            });

            InitializeComponent();
            dataGridViewCar.AutoGenerateColumns = false;

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
            //if (e.ColumnIndex < 0 || e.RowIndex < 0)
            //{
            //    return;
            //}

            //var col = dataGridViewCar.Columns[e.ColumnIndex];
            //var colName = col.Name;
            //if (colName != nameof(AvgRateColumn))

            //    var car = (CarModel)dataGridViewCar.Rows[e.RowIndex].DataBoundItem;
            //var graphics = e.Graphics;

            //var rect = e.CellBounds;
            //e.PaintBackground(rect, false);

            //var width = rect.Width * (car.AvgRate);
        }

        private void toolStripButtonProperties_Click(object sender, EventArgs e)
        {
            var add = new AddCar();

            if (add.ShowDialog(this) == DialogResult.OK)
            {
                items.Add(add.CurrentCar);
                bindingSource.ResetBindings(false);
            }
        }
    }
}
