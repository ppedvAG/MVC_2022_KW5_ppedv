using MVCAndRazorSamples.Models;

namespace MVCAndRazorSamples.ViewModels
{
    public class MovieViewModel
    {
        public Movie Movie { get; set; } = default!;

        public List<Artists> Cast { get; set; } = default!;

        public int ExterneIMDBRating { get; set; }
    }
}
