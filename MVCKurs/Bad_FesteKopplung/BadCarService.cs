using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bad_FesteKopplung
{

    //Programmier B: Benötigt 3 Tage -> Programmierer B kann erst an Tag 5 einsteigen 

    //Weitere Nachteile -> Keine Versionierungen, bzw BadCar ist schwer erweiterbar (eventl. Refactoring)
    public class BadCarService
    {
        //Feste Kopplungen haben in Teamarbeit Auswirkungen auf die Arbeit meiner Kollegen
        //-> Wenn Programmeirer BadCar etwas verändert, kann Repair evnetuell nicht mehr funktionieren oder gibt ein Compiler Fehler aus

        
        public void Reapir(BadCar car)
        {

        }

    }
}
