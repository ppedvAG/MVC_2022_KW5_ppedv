using KonfigurationSampleApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace KonfigurationSampleApp.Controllers
{
    public class ConfigurationSampleController : Controller
    {
        //Beschreibung -> IConfiguration beinhalt alle ausgelesenen Konfigurationsquellen. 

        public IActionResult ReadExplizietFromICollectionSample([FromServices] IConfiguration configuration)
        {
            string myKeyValue = configuration["MyKey"];
            string title = configuration["Position:Title"];
            string name = configuration["Position:Name"];
            string defaultLogLevel = configuration["Loggin:LogLevel:Default"];

            return View();
        }

        public IActionResult ReadWithPositionOptions([FromServices] PositionOptions positionOptions)
        {

            return View(positionOptions); //Datensäten werden via Parameter an die View übergeben 
        }


        //ISnapshot ermöglicht das automatische Nachladen von Konfiguration
        public IActionResult ReadWithPositionOptionsAsOptionPattern([FromServices] IOptionsSnapshot<PositionOptions> positionOptions)
        {
            return View(positionOptions.Value);
        }


        public IActionResult ReadArrayConfigFile([FromServices] IOptionsSnapshot<ArrayExample> myArray)
        {
            return View(myArray.Value);
        }


        //ContentResult = einfache Stringausgabe
        public ContentResult ShowArray([FromServices] IOptionsSnapshot<ArrayExample> myArray)
        {
            string str = string.Empty;

            foreach (string arrayEntry in myArray.Value.Entries)
                str = str + arrayEntry + "\n";

            return Content(str); //Ausgabe des kompletten Arrays 
        }


        public IActionResult ShowPostConfiguration([FromServices] IConfiguration config)
        {
            PositionOptions positionOptions = new();

            config.GetSection(PositionOptions.Position).Get<PositionOptions>();

            return View();
        }
    }
}
