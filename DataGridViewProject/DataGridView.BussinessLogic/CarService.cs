using DataGridView.DataAccess.Models;
using DataGridView.BussinessLogic.Services;
using DataGridView.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Channels;

namespace DataGridView.BussinessLogic
{
    public class CarService : ICarService
    {
        private readonly ICarRepository iRepository;
        private readonly Channel<CarModel> carsChannel;

        public CarService(ICarRepository repository)
        {
            iRepository = repository!;
            carsChannel = Channel.CreateUnbounded<CarModel>();
        }

        public void AddCar(CarModel car)
        {
            iRepository.AddCar(car);
            carsChannel.Writer.TryWrite(car);
        }

        public void UpdateCar(CarModel car)
        {
            iRepository.UpdateCar(car);
            carsChannel.Writer.TryWrite(car);
        }

        public void DeleteCar(Guid id)
        {
            iRepository.DeleteCar(id);
        }

        public List<CarModel> GetAllCars() => iRepository.GetAllCars();

        public CarModel? GetCarById(Guid id) => iRepository.GetCarById(id);

        public (int totalCars, int lowFuelCars) GetStatistics()
        {
            return (iRepository.GetTotalCarsCount(), iRepository.GetCarsWithLowFuelCount());
        }

        public ChannelReader<CarModel> GetCarsStream() => carsChannel.Reader;

        public async IAsyncEnumerable<CarModel> GetAllCarsAsync()
        {
            var cars = iRepository.GetAllCars();
            foreach (var car in cars)
            {
                await Task.Delay(10);
                yield return car;
            }
        }
    }
}
