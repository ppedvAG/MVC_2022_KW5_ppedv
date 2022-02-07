using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVCAndRazorSamples.Controllers
{
    public class FilterSampleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [Authorize("Read")]
        public IActionResult Read()
        {
            return View();
        }

        [Authorize("Write")]
        public IActionResult Edit()
        {
            return View();
        }
    }
}
