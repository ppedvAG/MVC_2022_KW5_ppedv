using GoodCar.Entities;
using GoodCar.Interfaces;
using GoodCar.Service;
using Microsoft.Extensions.DependencyInjection;


//Initiaziere den IOC 
IServiceCollection servicesCollection = new ServiceCollection();
servicesCollection.AddSingleton<ICar, Car>();//Datensatz nur für ShowCase
servicesCollection.AddSingleton<ICar, MockCar>(); //Datensatz nur für ShowCase + MockCar überschreibt Car im IOC Container 
servicesCollection.AddSingleton<ICarService, CarService>(); //Eigentlich werden in einem IOC nur Services abgelegt 

//Mulitple Class implementierung in IOC 

//ISingletonCar singletonCar = new MultiplesCarObj() { Brand = "BMW", Modell="7er", ConstructionYear=2021 };
//IScopedCar scopedCar = new MultiplesCarObj() { Brand = "BMW", Modell = "8er", ConstructionYear = 2022 };
//ITransientCar transientCar = new MultiplesCarObj() { Brand = "BMW", Modell = "5er", ConstructionYear = 2046 };


servicesCollection.AddSingleton<ISingletonCar, MultiplesCarObj>();
servicesCollection.AddSingleton<IScopedCar, MultiplesCarObj>();
servicesCollection.AddSingleton<ITransientCar, MultiplesCarObj>();


//ServiceProvider ist unser IOC Container
IServiceProvider serviceProvider = servicesCollection.BuildServiceProvider(); //Mit Build schließen wir die Initializierung Phase ab

//Wenn Interface nicht gefunden im IOC Container gefunden wird, gibt GetSerivce NULL zurücl 
ICar? mockCar = serviceProvider.GetService<ICar>();

//Wenn Interface nicht gefunden im IOC Container gefunden wird, wird eine Exception geschmissen
ICar mockCar2 = serviceProvider.GetRequiredService<ICar>();


 

