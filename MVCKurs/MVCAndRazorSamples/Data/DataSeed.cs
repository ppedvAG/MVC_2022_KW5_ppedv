using MVCAndRazorSamples.Models;

namespace MVCAndRazorSamples.Data
{
    public static class DataSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            MovieDbContext ctx = serviceProvider.GetRequiredService<MovieDbContext>();
           
            if(!ctx.Movies.Any())
            {
                ctx.Movies.Add(new Movie() { Title = "Jurassic Park", Description = "T-Rex wird zu Veggie", Price = 10, Genre = GenreTyp.Action });
                ctx.Movies.Add(new Movie() { Title = "Jurassic Park 2", Description = "Das Dinoei", Price = 12, Genre = GenreTyp.Action });
                ctx.SaveChanges(); //Add + SaveChanges -> UnitOfWork
            }
        }
    }
}
