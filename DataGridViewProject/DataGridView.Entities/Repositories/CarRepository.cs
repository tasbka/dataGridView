using DataGridView.DataAccess.Models;

namespace DataGridView.DataAccess.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly List<CarModel> cars = new();

        public void AddCar(CarModel car) => cars.Add(car);

        public void UpdateCar(CarModel car)
        {
            var existing = cars.FirstOrDefault(c => c.Id == car.Id);
            if (existing != null)
            {
                cars.Remove(existing);
                cars.Add(car);
            }
        }

        public void DeleteCar(Guid id) => cars.RemoveAll(c => c.Id == id);

        public List<CarModel> GetAllCars() => cars.ToList();

        public CarModel? GetCarById(Guid id) => cars.FirstOrDefault(c => c.Id == id);

        public int GetTotalCarsCount() => cars.Count;

        public int GetCarsWithLowFuelCount() => cars.Count(c => c.CurrentFuelVolume < AppConstants.CriticalFuelLevel);
    }
}
