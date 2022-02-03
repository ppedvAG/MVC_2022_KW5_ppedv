#nullable disable

using Microsoft.EntityFrameworkCore;
using MVCAndRazorSamples.Models;

namespace MVCAndRazorSamples.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            :base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }    
    }
}
