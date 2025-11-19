using DataGridView.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridView.DataAccess.Repositories
{
    public interface ICarRepository
    {
        void AddCar(CarModel car);
        void UpdateCar(CarModel car);
        void DeleteCar(Guid id);
        List<CarModel> GetAllCars();
        CarModel? GetCarById(Guid id);
        int GetTotalCarsCount();
        int GetCarsWithLowFuelCount();
    }
}
