using DataGridView.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace DataGridView.BussinessLogic.Services
{
    public interface ICarService
    {
        void AddCar(CarModel car);
        void UpdateCar(CarModel car);
        void DeleteCar(Guid id);
        List<CarModel> GetAllCars();
        CarModel? GetCarById(Guid id);
        (int totalCars, int lowFuelCars) GetStatistics();
        ChannelReader<CarModel> GetCarsStream();
        IAsyncEnumerable<CarModel> GetAllCarsAsync();
    }
}
