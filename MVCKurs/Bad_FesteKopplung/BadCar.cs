//#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bad_FesteKopplung
{

    //Programmier A: Benötigt 5 Tage
    public class BadCar
    {
        public string Brand { get; set; } = string.Empty; //String.Empty bitte nicht
        public string Model { get; set; } = default!; //geht fast überall (arrays, string und Referenztypen
        public int ConstructionYear { get; set; }

        public string Color { get; set; } 
    }
}
