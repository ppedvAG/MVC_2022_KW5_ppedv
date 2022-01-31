using GoodCar.Entities;
using GoodCar.Interfaces;
using GoodCar.Service;

ICar car = new Car();
car.Brand = "BMW";
car.Modell = "Der von James Bond";
car.ConstructionYear = 2021;

ICar testCarObject = new MockCar();

ICarVersion2 carVersion2 = new CarVersion2();

ICarService service = new CarService();
service.Repair(car);
service.Repair(testCarObject);


service.Repair(carVersion2); //Er verwenden hier nur ICAR 

