namespace GoodCar.Interfaces
{
    public interface ICar
    {
        public string Brand { get; set; }
        public string Modell { get; set; }
        public int ConstructionYear { get; set; }
    }

    public interface ICarVersion2 : ICar
    {
        string Colour { get; set; }
        bool HatAnhaengerkupplung { get; set; }
    }


    //Für Mulitple Interfaces in IOC Container
    public interface ISingletonCar : ICar
    {

    }
    public interface ITransientCar : ICar
    {

    }

    public interface IScopedCar : ICar
    {

    }
}