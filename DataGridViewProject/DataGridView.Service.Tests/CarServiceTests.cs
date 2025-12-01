using Ahatornn.TestGenerator;
using DataGridView.Entities2;
using DataGridView.Repository.Contracts;
using DataGridView.Services;
using DataGridView.Services.Contracts;
using FluentAssertions;
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
            carService = new CarService(storageMock.Object);
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

            result.Should().NotBeEmpty()
                .And.HaveCount(2)
                .And.ContainSingle(x => x.Id == car1.Id)
                .And.ContainSingle(x => x.Id == car2.Id);
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

            // Настраиваем, чтобы проверка уникальности прошла
            storageMock.Setup(x => x.GetAllCarsAsync())
                .ReturnsAsync(new List<CarModel>());

            var act = () => carService.AddCarAsync(car);

            await act.Should().NotThrowAsync();
            storageMock.Verify(x => x.GetAllCarsAsync(), Times.Once);
            storageMock.Verify(x => x.AddCarAsync(car), Times.Once);
            storageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Проверяет, что метод AddCarAsync выбрасывает исключение при дублировании гос номера
        /// </summary>
        [Fact]
        public async Task AddCarAsync_WithDuplicateAutoNumber_ShouldThrowException()
        {
            var existingCar = TestEntityProvider.Shared.Create<CarModel>();
            var newCar = TestEntityProvider.Shared.Create<CarModel>();
            newCar.AutoNumber = existingCar.AutoNumber;

            storageMock
                .Setup(s => s.GetAllCarsAsync())
                .ReturnsAsync(new List<CarModel> { existingCar });

            var act = () => carService.AddCarAsync(newCar);

            await act.Should().ThrowAsync<InvalidOperationException>();
            storageMock.Verify(x => x.GetAllCarsAsync(), Times.Once);
            storageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Проверяет, что метод UpdateCarAsync вызывает хранилище для обновления автомобиля
        /// </summary>
        [Fact]
        public async Task UpdateCarAsyncShouldWork()
        {
            var car = TestEntityProvider.Shared.Create<CarModel>();

            storageMock.Setup(x => x.GetCarByIdAsync(car.Id))
                .ReturnsAsync(car);

            var act = () => carService.UpdateCarAsync(car);

            await act.Should().NotThrowAsync();
            storageMock.Verify(x => x.GetCarByIdAsync(car.Id), Times.Once);
            storageMock.Verify(x => x.UpdateCarAsync(It.IsAny<CarModel>()), Times.Once);
            storageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Проверяет, что метод DeleteCarAsync вызывает хранилище для удаления автомобиля по Id
        /// </summary>
        [Fact]
        public async Task DeleteCarAsyncShouldWork()
        {
            var car = TestEntityProvider.Shared.Create<CarModel>();

            storageMock.Setup(x => x.GetCarByIdAsync(car.Id))
                .ReturnsAsync(car);

            var act = () => carService.DeleteCarAsync(car.Id);

            await act.Should().NotThrowAsync();
            storageMock.Verify(x => x.GetCarByIdAsync(car.Id), Times.Once);
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
        public async Task GetStatisticsAsync_ShouldCallStorageGetAll()
        {
            var cars = new List<CarModel>
    {
        TestEntityProvider.Shared.Create<CarModel>(),
        TestEntityProvider.Shared.Create<CarModel>()
    };

            storageMock
                .Setup(s => s.GetAllCarsAsync())
                .ReturnsAsync(cars);

            // Act: вызываем метод НАПРЯМУЮ (без act лямбды!)
            var result = await carService.GetStatisticsAsync();

            // Assert
            result.Should().NotBeNull();
            result.TotalCars.Should().Be(2);
            storageMock.Verify(x => x.GetAllCarsAsync(), Times.Once);
            storageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Проверяет, что метод GetStatisticsAsync корректно рассчитывает статистику при отсутствии автомобилей
        /// </summary>
        [Fact]
        public async Task GetStatisticsAsync_WithNoCars_ShouldReturnZeroStatistics()
        {
            storageMock
                .Setup(s => s.GetAllCarsAsync())
                .ReturnsAsync(new List<CarModel>());

            // Act: вызываем метод НАПРЯМУЮ
            var result = await carService.GetStatisticsAsync();

            // Assert
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
