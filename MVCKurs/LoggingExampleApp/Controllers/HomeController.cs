using LoggingExampleApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LoggingExampleApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Halli Hallo von Index -> Get-Methode");
            return View();
        }

        public IActionResult Privacy()
        {
            _logger.LogInformation("Halli Hallo von Privacy -> Get-Methode");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}