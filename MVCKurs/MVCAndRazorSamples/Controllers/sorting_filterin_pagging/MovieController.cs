using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using MovieMVCApp.Data;
//using MovieMVCApp.Helpers;
//using MovieMVCApp.Models;

//namespace MovieMVCApp.Controllers
//{
//    public class MovieController : Controller
//    {
//        private readonly MovieDbContext _context;

//        public MovieController(MovieDbContext context)
//        {
//            _context = context;
//        }

//        // GET: Movie
//        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
//        {
//            ViewData["CurrentSort"] = sortOrder;
//            ViewData["CurrentFilter"] = searchString; 

//            ViewData["TitleSortParm"] = sortOrder == "Title" ? "title_desc" : "Title";
//            ViewData["DescriptionParm"] = sortOrder == "Description" ? "description_desc" : "Description";
//            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";
//            ViewData["GenreTypeSortParm"] = sortOrder == "GenreType" ? "genretype_desc" : "GenreType";
            
//            if (!string.IsNullOrEmpty(searchString))
//            {
//                pageNumber = 1;
//            }
//            else
//            {
//                searchString = currentFilter;
//            }

//            //Hier darf ein Feature programmiert werden, dass mithilfe von ViewData realisiert 
//            //Wir wollen den Suchbegriff in der Textbox angezeigt bekommen, wenn die Suchliste gefilter dargestellt wird

//            //IList<Movie> filteredList = string.IsNullOrEmpty(searchString) ? 
//            //    await _context.Movie.ToListAsync() : 
//            //    await _context.Movie.Where(q => q.Title.Contains(searchString) || q.Description.Contains(searchString)).ToListAsync();


//            IQueryable<Movie> movies = _context.Movie.AsQueryable<Movie>();

//            //List<Movie> movies = _context.Movie.ToList();

//            switch (sortOrder)
//            {
//                case "Title":
//                    movies = movies.OrderBy(s => s.Title); //bei List<Movie> movies = _context.Movie.ToList(); (muss)->  movies = movies.OrderBy(s => s.Title).ToList();
//                    break;
//                case "title_desc":
//                    movies = movies.OrderByDescending(s => s.Title);
//                    break;
//                case "Description":
//                    movies = movies.OrderBy(s => s.Description);
//                    break;
//                case "description_desc":
//                    movies = movies.OrderByDescending(s => s.Description);
//                    break;
//                case "Price":
//                    movies = movies.OrderBy(s => s.Price);
//                    break;
//                case "price_desc":
//                    movies = movies.OrderByDescending(s => s.Price);
//                    break;
//                case "GenreType":
//                    movies = movies.OrderBy(s => s.GenreType);
//                    break;
//                case "genretype_desc":
//                    movies = movies.OrderByDescending(s => s.GenreType);
//                    break;
//                default:
//                    movies = movies.OrderBy(s => s.Id);
//                    break;
//            }
//            int pageSize = 3;

//            //pageNumber ?? 1


//            return View(await PaginatedList<Movie>.CreateAsync(movies.AsNoTracking(), pageNumber ?? 1, pageSize));
//        }

//        public IActionResult GetPartial()
//        {
//            List<string> countries = new List<string>();
//            countries.Add("USA");
//            countries.Add("Germany");
//            countries.Add("India");

//            //return PartialView("_CountriesPartialView", countries);
//            return Json(countries);
//        }
//        // GET: Movie/Details/5


//        [HttpGet("/movie/details/{id}")]
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var movie = await _context.Movie
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (movie == null)
//            {
//                return NotFound();
//            }

//            return View(movie);
//        }

//        [HttpPost("/movie/buy")]
//        public IActionResult Buy(int? id)
//        {
//            if (!id.HasValue)
//            {
//                return BadRequest(); //Fehlercode 400
//            }

//            //Ist Session verfügbar
//            if (HttpContext.Session.IsAvailable)
//            {
//                IList<int> idList = new List<int>();


//                //Ist schon ein Einkaufwagen (ShoppingCart) verfügbar 
//                if (HttpContext.Session.Keys.Contains("ShoppingCart"))
//                {
//                    //Wollen bishere einkaufe auslesen
//                    string jsonIdList = HttpContext.Session.GetString("ShoppingCart");

//                    //bekommen eine Id-Liste mit allen vorhandenen Artikel im Warenkorb
//                    idList = JsonSerializer.Deserialize<List<int>>(jsonIdList);
//                }

//                //Artikel wird dem Warenkorb hinzugefügt
//                idList.Add(id.Value);

//                string jsonString = JsonSerializer.Serialize(idList);

//                HttpContext.Session.SetString("ShoppingCart", jsonString);
//            }

//            return RedirectToAction(nameof(Index));
//        }

//        public IActionResult Buy1(int? id)
//        {

//            return RedirectToAction(nameof(Index));
//        }

//        public IActionResult Wish(int? id)
//        {

//            return RedirectToAction(nameof(Index));
//        }


//        // GET: Movie/Create
//        [HttpGet("/movie/create")]
//        public IActionResult Create() //Sende das Formular(Html-Seite mit Formular) an den Browser
//        {
//            return View();
//        }

//        // POST: Movie/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598. //Benutzer füllt das Formular aus und klick den Button (submit) -> Der Browser sendet das Formular an den WebServer 
//        [HttpPost("/movie/create")]
//        [ValidateAntiForgeryToken]

//        public async Task<IActionResult> Create([Bind("Id,Title,Description,GenreType,Price,IMDBRating")] Movie movie)
//        {
//            //Document 
//            // Key / Value
//            // Title | Star Wars
//            // Description | Rückkehr der Jedi-Ritter


//            //string myTilte = Request.Form["Title"];
//            //string myDescription = Request.Form["Title"];

//            //Movie movie = new Movie(myTitle, myDescription....)

//            //Ich will eine Blackliste mit verwenden, die z.b den Film XYZ nicht hinzufügbar machen möchte
//            if (movie.Title == "The Crow")
//            {
//                //AddModelError führt dazu, dass IsValid auf false gesetzt wird
//                ModelState.AddModelError("Title", "Dieser Filmtitel steht auf dem Index");
//            }

//            //Serverseitig Valdierung ->
//            if (ModelState.IsValid) //Ob alle DataAnnotations erfüllt wurden
//            {
//                _context.Add(movie);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index)); //GET Methode -Index (Zeige mir die Tabelle mit allen Movies an) 
//            }
//            return View(movie);
//        }


//        [HttpPost("/movie/randomcreate")]
//        public async Task<IActionResult> RandomCreate(Movie movie)
//        {
//            string[] movieNames = { "Star Wars", "Scary Movie", "Old School", "Die Erde", "Herr der Ringe" };
            
//            Random rnd = new Random();
//            if (string.IsNullOrEmpty(movie.Title))
//            {
//                movie.Title = movieNames[rnd.Next(0, 4)];
//            }

//            if (string.IsNullOrEmpty(movie.Description))
//                movie.Description = "Film ist gut";


//            if (movie.Price == 0)
//                movie.Price = rnd.Next(5, 20);

//            if (movie.GenreType == Genre.Default)
//                movie.GenreType = Genre.Comedy;


//            _context.Add(movie);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));

//        }














//        // GET: Movie/Edit/5
//        [HttpGet("/movie/edit/{id}")]
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var movie = await _context.Movie.FindAsync(id);
//            if (movie == null)
//            {
//                return NotFound();
//            }
//            return View(movie);
//        }

//        // POST: Movie/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost("/movie/edit/{id}")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,GenreType,Price,IMDBRating")] Movie movie)
//        {
//            if (id != movie.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(movie);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!MovieExists(movie.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(movie);
//        }

//        // GET: Movie/Delete/5


//        [HttpGet("/movie/delete/{id}")]
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var movie = await _context.Movie
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (movie == null)
//            {
//                return NotFound();
//            }

//            return View(movie);
//        }

//        // POST: Movie/Delete/5
//        //[HttpPost, ActionName("Delete")]
//        [HttpPost("/movie/Delete/{id}"), ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var movie = await _context.Movie.FindAsync(id);
//            _context.Movie.Remove(movie);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool MovieExists(int id)
//        {
//            return _context.Movie.Any(e => e.Id == id);
//        }
//    }
//}
