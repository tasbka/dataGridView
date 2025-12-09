using Microsoft.EntityFrameworkCore;
using DataGridView.Entities2;

namespace Rental.DatabaseStorage
{
        /// <summary>
        /// Контекст базы данных для работы с автомобилями проката
        /// </summary>
        public class RentalDatabaseContext : DbContext
        {
            /// <summary>
            /// Таблица автомобилей
            /// </summary>
            public DbSet<CarModel> Cars { get; set; }

            /// <summary>
            /// Создаёт экземпляр БД
            /// </summary>
            public RentalDatabaseContext()
            {
                Database.EnsureCreated();
            }

            /// <summary>
            /// Конфигурация подключения к базе данных
            /// </summary>
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(
                    @"Server=(localdb)\mssqllocaldb;Database=RentalDatabase;Trusted_Connection=True;");
            }

            /// <summary>
            /// Конфигурация модели данных
            /// </summary>
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<CarModel>(entity =>
                {
                    entity.HasKey(e => e.Id);
                    entity.Property(e => e.AutoNumber)
                        .IsRequired()
                        .HasMaxLength(10);
                    entity.Property(e => e.Mileage)
                        .HasPrecision(18, 2);
                    entity.Property(e => e.FuelConsumption)
                        .HasPrecision(18, 2);
                    entity.Property(e => e.CurrentFuelVolume)
                        .HasPrecision(18, 2);
                    entity.Property(e => e.RentCostPerMinute)
                        .HasPrecision(18, 2);
                    entity.Property(e => e.CarMake)
                        .IsRequired()
                        .HasConversion<int>();
                });
            }
        }
}
