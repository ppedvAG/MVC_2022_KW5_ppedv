namespace MVCAndRazorSamples.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; } = default!;

        public string Description { get; set; } = default!;

        public decimal Price { get; set; }
    }

    public class Artists
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
    }
}
