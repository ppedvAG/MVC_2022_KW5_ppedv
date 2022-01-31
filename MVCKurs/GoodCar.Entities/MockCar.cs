#nullable disable

using GoodCar.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodCar.Entities
{
    public class MockCar : ICar
    {
        public string Brand { get; set; } = "VW";
        public string Modell { get; set; } = "Polo";
        public int ConstructionYear { get; set; } = 2021;
    }
}
