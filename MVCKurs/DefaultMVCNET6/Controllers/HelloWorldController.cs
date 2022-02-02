using Microsoft.AspNetCore.Mvc;

namespace DefaultMVCNET6.Controllers
{
    public class HelloWorldController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
