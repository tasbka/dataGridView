using Ahatornn.TestGenerator;
using DataGridView.Entities2;
using DataGridView.Repository.Contracts;
using DataGridView.Services;
using DataGridView.Services.Contracts;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Xunit;

namespace DataGridView.Service.Tests
{
    /// <summary>
    /// Набор модульных тестов для проверки работы <see cref="CarService"/>.
    /// </summary>
    public class CarServiceTests
    {
        private readonly Mock<IStorage> storageMock;
        private readonly ICarService carService;

        public CarServiceTests()
        {
            storageMock = new Mock<IStorage>();

            //var loggerMock = new Mock<ILogger<CarService>>();
            //var loggerFactoryMock = new Mock<ILoggerFactory>();

            // loggerFactoryMock
            //.Setup(x => x.CreateLogger<CarService>())
            //.Returns(loggerMock.Object);
            ILoggerFactory loggerFactory = new NullLoggerFactory();
            carService = new CarService(storageMock.Object, loggerFactory);
        }
        /// <summary>
        /// Проверяет, что метод GetAllCarsAsync возвращает все автомобили
        /// </summary>
        [Fact]
        public async Task GetAllCarsAsyncShouldReturnValue()
        {
            var car1 = TestEntityProvider.Shared.Create<CarModel>();
            var car2 = TestEntityProvider.Shared.Create<CarModel>();

            storageMock.Setup(x => x.GetAllCarsAsync())
                .ReturnsAsync(new List<CarModel> { car1, car2 });

            var result = await carService.GetAllCarsAsync();

            result.Should().BeEquivalentTo([car1, car2]);
            storageMock.Verify(x => x.GetAllCarsAsync(), Times.Once);
            storageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Проверяет, что метод AddCarAsync вызывает хранилище для добавления автомобиля
        /// </summary>
        [Fact]
        public async Task AddCarAsyncShouldWork()
        {
            var car = TestEntityProvider.Shared.Create<CarModel>();

            storageMock.Setup(x => x.GetAllCarsAsync())
                .ReturnsAsync(new List<CarModel>());

            var act = () => carService.AddCarAsync(car);

            await act.Should().NotThrowAsync();

            storageMock.Verify(x => x.AddCarAsync(car), Times.Once);
            storageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Проверяет, что метод UpdateCarAsync вызывает хранилище для обновления автомобиля
        /// </summary>
        [Fact]
        public async Task UpdateCarAsyncShouldWork()
        {
            var car = TestEntityProvider.Shared.Create<CarModel>();

            var carFromStorage = TestEntityProvider.Shared.Create<CarModel>();
            carFromStorage.Id = car.Id;

            storageMock.Setup(x => x.GetCarByIdAsync(car.Id))
                .ReturnsAsync(carFromStorage);

            var act = () => carService.UpdateCarAsync(car);

            await act.Should().NotThrowAsync();

            storageMock.Verify(x => x.GetCarByIdAsync(car.Id), Times.Once);
            storageMock.Verify(x => x.UpdateCarAsync(carFromStorage), Times.Once);
            storageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Проверяет, что метод DeleteCarAsync вызывает хранилище для удаления автомобиля по Id
        /// </summary>
        [Fact]
        public async Task DeleteCarAsyncShouldWork()
        {
            var car = TestEntityProvider.Shared.Create<CarModel>();

            var act = () => carService.DeleteCarAsync(car.Id);

            await act.Should().NotThrowAsync();
 
            storageMock.Verify(x => x.DeleteCarAsync(car.Id), Times.Once);
            storageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Проверяет, что метод GetCarByIdAsync возвращает правильный автомобиль по Id
        /// </summary>
        [Fact]
        public async Task GetCarByIdAsyncShouldReturnValue()
        {
            var car = TestEntityProvider.Shared.Create<CarModel>();

            storageMock.Setup(x => x.GetCarByIdAsync(car.Id))
                .ReturnsAsync(car);

            var result = await carService.GetCarByIdAsync(car.Id);

            result.Should().NotBeNull();
            result.Id.Should().Be(car.Id);
            storageMock.Verify(x => x.GetCarByIdAsync(car.Id), Times.Once);
            storageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Проверяет, что метод GetStatisticsAsync вызывает хранилище для получения статистики
        /// </summary>
        [Fact]
        public async Task GetStatisticsAsyncTest()
        {
            var cars = new List<CarModel>
            {
                TestEntityProvider.Shared.Create<CarModel>(),
                TestEntityProvider.Shared.Create<CarModel>()
            };

            storageMock
                .Setup(s => s.GetAllCarsAsync())
                .ReturnsAsync(cars);

            var result = await carService.GetStatisticsAsync();

            result.Should().NotBeNull();
            result.TotalCars.Should().Be(2);
            storageMock.Verify(x => x.GetAllCarsAsync(), Times.Once);
            storageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Проверяет, что метод GetStatisticsAsync корректно рассчитывает статистику по автомобилям
        /// </summary>
        [Fact]
        public async Task GetStatisticsAsync_ShouldCalculateStatisticsCorrectly()
        {
            // Arrange
            var cars = new List<CarModel>
            {
                 new CarModel
                 {
                    Id = Guid.NewGuid(),
                    AutoNumber = "АБ123Ц",
                    CarMake = CarMake.Hyundai,
                    CurrentFuelVolume = 5,   // Низкий уровень (< 7)
                    RentCostPerMinute = 100,
                    Mileage = 150
                 },
                new CarModel
                 {
                    Id = Guid.NewGuid(),
                    AutoNumber = "ВГ456Д",
                    CarMake = CarMake.Lada,
                    CurrentFuelVolume = 20,  // Нормальный уровень
                    RentCostPerMinute = 120,
                    Mileage = 250
                 },
                 new CarModel
                 {
                    Id = Guid.NewGuid(),
                    AutoNumber = "ЕЖ789Ф",
                    CarMake = CarMake.Mitsubishi,
                    CurrentFuelVolume = 3,   // Низкий уровень (< 7)
                    RentCostPerMinute = 80,
                    Mileage = 200
                }
            };

            storageMock
                .Setup(s => s.GetAllCarsAsync())
                .ReturnsAsync(cars);

            var result = await carService.GetStatisticsAsync();

            result.Should().NotBeNull();
            result.TotalCars.Should().Be(3);
            result.LowFuelCars.Should().Be(2); // 2 автомобиля с топливом < 7 (первый и третий)
            result.TotalRentalValue.Should().Be(300); 
            result.AverageMileage.Should().Be(200); 

            storageMock.Verify(x => x.GetAllCarsAsync(), Times.Once);
            storageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        ///Проверяет, что метод GetStatisticsAsync возвращает нулевую статистику при отсутствии автомобилей
        /// </summary>
        [Fact]
        public async Task GetStatisticsAsynTest()
        {
            storageMock
                .Setup(s => s.GetAllCarsAsync())
                .ReturnsAsync(new List<CarModel>());

            var result = await carService.GetStatisticsAsync();

            result.Should().NotBeNull();
            result.TotalCars.Should().Be(0);
            result.LowFuelCars.Should().Be(0);
            result.TotalRentalValue.Should().Be(0);
            result.AverageMileage.Should().Be(0);
            storageMock.Verify(x => x.GetAllCarsAsync(), Times.Once);
            storageMock.VerifyNoOtherCalls();
        }
    }
}
