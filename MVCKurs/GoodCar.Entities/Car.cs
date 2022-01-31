#nullable disable

using GoodCar.Interfaces;

namespace GoodCar.Entities
{

    //STRG + . -> Eine Liste von Implementierungsmöglichkeiten
    public class Car : ICar
    {
        public string Brand { get; set; }
        public string Modell { get; set; }
        public int ConstructionYear { get; set; }
    }
}