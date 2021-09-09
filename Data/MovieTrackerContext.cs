using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MovieTracker.Models
{
    public class MovieTrackerContext : DbContext
    {
        public MovieTrackerContext (DbContextOptions<MovieTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<MovieTracker.Models.Movie> Movie { get; set; }
    }
}
