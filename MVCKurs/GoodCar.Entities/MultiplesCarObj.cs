using GoodCar.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace GoodCar.Entities
{
    public class MultiplesCarObj : ISingletonCar, ITransientCar, IScopedCar
    {
        public string Brand { get; set; }
        public string Modell { get; set ; }
        public int ConstructionYear { get; set; }
    }
}
