
#nullable disable
using GoodCar.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodCar.Entities
{
    public class CarVersion2 : ICarVersion2
    {
        public string Colour { get; set; }
        public bool HatAnhaengerkupplung { get; set; }
        public string Brand { get; set; }
        public string Modell { get; set; }
        public int ConstructionYear { get; set; }
    }
}
