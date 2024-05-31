using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MSSQL
{
    public class CarContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public string ConnString;
        public CarContext()
        {
            ConnString = "Server=localhost;Database=test;User Id=sa;Password=yourStrong(!)Password;TrustServerCertificate=True;";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer(ConnString);
        protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.Entity<Car>().Property(c => c.carID).ValueGeneratedOnAdd();
    }


    public class Car
    {
        public int carID { get; set; }
        public required string Maker { get; set; }
        public required string Model { get; set; }
        public int Year { get; set; }
    }

}