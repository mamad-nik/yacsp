using System.Linq;
using MSSQL;

using var db = new CarContext();

Console.WriteLine($"Database path: {db.ConnString}.");
if (!db.Cars.Any())
{
    db.Cars.AddRange(
        new Car { Maker = "Toyota", Model = "Corolla", Year = 2020 },
        new Car { Maker = "Honda", Model = "Civic", Year = 2019 },
        new Car { Maker = "Ford", Model = "Mustang", Year = 2021 }
    );
    db.SaveChanges();
}

var cars = db.Cars.ToList();

foreach ( var car in cars)
{
    Console.WriteLine($"{car.carID}: {car.Maker} {car.Model} ({car.Year})");
}
Console.WriteLine(cars);