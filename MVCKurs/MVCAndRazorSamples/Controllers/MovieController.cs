using Microsoft.AspNetCore.Mvc;
using MVCAndRazorSamples.Data;
using MVCAndRazorSamples.Models;
using System.Text.Json;

namespace MVCAndRazorSamples.Controllers;


// Rückgabetypen in MVC -> IActionResult -> ActionResult | ActionResult<Movie> 
public class MovieController : Controller
{
    private readonly MovieDbContext _ctx;

    public MovieController(MovieDbContext movieDbContext)
    {
        _ctx = movieDbContext;
    }

    //GET - Methode

    public IActionResult Index(string filter)
    {
        if(!string.IsNullOrEmpty(filter))
        {
            ViewData["FilterQuery"] = filter; //Wir wollen an der Oberfläche unseren Suchbegriff anzeigen 
        }

        IList<Movie> filteredList = string.IsNullOrEmpty(filter) ? _ctx.Movies.ToList() : _ctx.Movies.Where(q=>q.Title.Contains(filter) || q.Description.Contains(filter)).ToList();

        return View(filteredList);
    }

    //Get-Methode -> Anzeigen eines Leeren Formulares ohne Daten
    [HttpGet("/movie/create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("/movie/create")]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Movie movie)
    {
        ViewData["TestData"] = "Geht da";
        
        //BusinessRules
        //Beispiel einer Index-Liste, dass nicht alle Filme hinzugefügt werden können :-) 
        if (movie.Title == "The Crow")
        {
            ModelState.AddModelError("Title", "Der Filmtitel steht auf dem Index"); //ModelState -> wird false
        }

        if (ModelState.IsValid)
        {
            _ctx.Movies.Add(movie);
            _ctx.SaveChanges();

            return RedirectToAction("Index"); //wir rufen die Get-Methode Index auf um die Übersicht wieder zu sehen
        }

        return View(movie); //Zeige mir nochmal Create-View mit dem vorhanden ausgefüllten Datensatz und seinen Fehlermeldungen
    }

    //public PartialViewResult GetPartial()
    //{
        
    //    return PartialView()
    //}

    [HttpPost("/movie/Buy/{id}")]
    //Warenkorb Befüllung 
    public IActionResult Buy(int? id)
    {
        if (!id.HasValue)
            return BadRequest(); //404 wird ausgegen

        //Gibt es eine Session Funktionalität
        if (HttpContext.Session.IsAvailable)
        {
            IList<int> idList = new List<int>();

            if (HttpContext.Session.Keys.Contains("ShoppingCart"))
            {
                string jsonIdList = HttpContext.Session.GetString("ShoppingCart");

                idList = JsonSerializer.Deserialize<List<int>>(jsonIdList);
            }

            idList.Add(id.Value);

            string jsonString = JsonSerializer.Serialize(idList);

            HttpContext.Session.SetString("ShoppingCart", jsonString);

        }

        //return RedirectToAction("Index");
        return RedirectToAction(nameof(Index));
    }


}

