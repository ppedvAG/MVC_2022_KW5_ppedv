using Microsoft.AspNetCore.Mvc;
using MVCAndRazorSamples.Models;
using MVCAndRazorSamples.ViewModels;

namespace MVCAndRazorSamples.Controllers
{
    public class RazorSamplesController : Controller
    {
        //Get-Methode
        public IActionResult RazorSamplesOverview()
        {
            IList<Person> persons = new List<Person>();
            persons.Add(new Person("Max", 33));
            persons.Add(new Person("Moritz", 33));

            return View(persons);
        }


        //Get-Methode
        public IActionResult GenerateTableWithModel()
        {
            IList<Person> persons = new List<Person>();
            persons.Add(new Person("Max", 33));
            persons.Add(new Person("Moritz", 33));

            return View(persons);
        }

        public IActionResult GenerateTableWithViewModel()
        {
            MovieViewModel vm = new MovieViewModel();

            vm.Movie = new Movie
            {
                Id = 1,
                Title = "Jurrasic Park",
                Description = "TRex wird Veggie",
                Price = 19.99m
            };

            vm.Cast = new List<Artists>();
            vm.Cast.Add(new Artists
            {
                Id = 1,
                FirstName = "Otto",
                LastName = " Walkes"
            });

            vm.Cast.Add(new Artists
            {
                Id = 2,
                FirstName = "Harry",
                LastName = " Weinfuhrt"
            });

            vm.Cast.Add(new Artists
            {
                Id = 3,
                FirstName = "Ralf",
                LastName = " Möller"
            });

            vm.ExterneIMDBRating = 8;

            return View(vm);
        }
    }
}
