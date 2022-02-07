using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCAndRazorSamples.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Bitte ein Titel eingeben")]
        public string Title { get; set; } = default!;


        [Required(AllowEmptyStrings = false)]
        [MinLength(10)]
        public string Description { get; set; } = default!;

        [Range(0, 30)]
        public decimal Price { get; set; }

        public GenreTyp Genre { get; set; }
    }

    public enum GenreTyp { Action, Drama, Thriller, Horror, Roamnce, Comedy, Animations, Documentation }

    public class Artists
    {
        public int Id { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
    }
}
