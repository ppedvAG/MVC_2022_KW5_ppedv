using Microsoft.AspNetCore.Mvc;

namespace MVCAndRazorSamples.Controllers
{
    public class StateManagementController : Controller
    {
        public IActionResult ViewDataSample()
        {
            //ViewData ist ein Dictionary Key/Value
            //ViewData ist eine Propery von der Controller-Klasse
            ViewData["abc"] = "Hello World";
            ViewData["def"] = "Hallo liebe Teilnehmer";
            return View();
        }

        public IActionResult ViewBagSampe()
        {
            ViewBag.ghj = "Hallo Welt";

            return View();
        }


        public IActionResult TempDataSample()
        {
            TempData["EmailAdress"] = "kwinter@ppedv.de";
            TempData["Id"] = 123;

            return View();
        }

        public IActionResult TempDataSecondSample()
        {
            return View();
        }

        public IActionResult TempDataThirdSample()
        {
            return View();
        }



    }
}
