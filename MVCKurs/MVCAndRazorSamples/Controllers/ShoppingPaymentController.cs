using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCAndRazorSamples.Data;
using MVCAndRazorSamples.Models;
using System.Collections.Generic;
using System.Text.Json;

namespace MVCAndRazorSamples.Controllers
{
    public class ShoppingPaymentController : Controller
    {

        private readonly MovieDbContext _ctx;

        public ShoppingPaymentController(MovieDbContext ctx)
        {
            _ctx = ctx;
        }

        public IActionResult ShoppingCartOverview()
        {
            IList<Movie> movieList = new List<Movie>();

            if (HttpContext.Session.IsAvailable)
            {
                if (HttpContext.Session.Keys.Contains("ShoppingCart"))
                {
                    movieList = InitializeShoppingCart();
                }
                else
                {
                    //?
                }
            }

            return View(movieList);
        }

        private IList<Movie> InitializeShoppingCart()
        {
            IList<Movie> movieList = new List<Movie>();

            List<int> idList = ReadShoppingPaymentFromSession();


            foreach(int currentArticleId in idList)
            {
                Movie currentMovie = _ctx.Movies.Find(currentArticleId);
                movieList.Add(currentMovie);
            }


            return movieList;
        }

        private List<int> ReadShoppingPaymentFromSession()
        {
            string shoppingCartJsonString = HttpContext.Session.GetString("ShoppingCart");
            List<int> ids = JsonSerializer.Deserialize<List<int>>(shoppingCartJsonString);
            return ids;
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            if (!HttpContext.Session.Keys.Contains("ShoppingCart"))
                throw new Exception("Warenkorb ist intern noch nicht verfügbar");

            IList<int> ids = ReadShoppingPaymentFromSession();

            if (ids.Contains(id.Value))
            {
                ids.Remove(id.Value);

                if (ids.Count == 0)
                {
                    HttpContext.Session.Remove("ShoppingCart");
                }
                else
                {
                    string jsonString = JsonSerializer.Serialize(ids);
                    HttpContext.Session.SetString("ShoppingCart", jsonString);
                }
            }

            return RedirectToAction(nameof(ShoppingCartOverview));
        }

        [HttpPost]
        [Authorize()]
        [ValidateAntiForgeryToken]
        public IActionResult Pay()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Payment()
        {
            return View();
        }




    }
}
