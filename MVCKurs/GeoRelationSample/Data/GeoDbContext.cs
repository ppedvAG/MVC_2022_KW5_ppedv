#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GeoRelationSample.Models;

namespace GeoRelationSample.Data
{
    public class GeoDbContext : DbContext
    {
        public GeoDbContext (DbContextOptions<GeoDbContext> options)
            : base(options)
        {
        }

        public DbSet<GeoRelationSample.Models.Continent> Continent { get; set; }
        public DbSet<GeoRelationSample.Models.Country> Countries { get; set; }
        public DbSet<GeoRelationSample.Models.Language> Language { get; set; }
        public DbSet<GeoRelationSample.Models.LanguageInCountry> LanguageInCountry { get; set; }
    }
}
