using Microsoft.AspNetCore.Mvc;
using MVC_DependencyInjectionSamples.Models;
using MVC_DependencyInjectionSamples.Services;
using System.Diagnostics;

namespace MVC_DependencyInjectionSamples.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITimeService _timeService;

        //Konstructor Injection -> Wann verwendet man das? Wenn alle Action Methoden ein Service benötigen
        public HomeController(ILogger<HomeController> logger, ITimeService timeService) 
        {
            _logger = logger;
            _timeService = timeService;
        }

        public IActionResult Index()
        {
            return View(_timeService.GetCurrentTime());
        }


        //Bei nur Explizieten und einmaligen verwenden mit [FromServices]
        public IActionResult Privacy([FromServices] ITimeService timeService)
        {
            //FromServices -> wenn wir einen Dienst nur an einer Stelle benötigen 
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}