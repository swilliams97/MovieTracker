using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTracker.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieTrackerContext(
                serviceProvider.GetRequiredService<
                DbContextOptions<MovieTrackerContext>>()))
            {
                //Looks for movies within SeedData class
                if (context.Movie.Any())
                {
                    return; //DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "Back to the Future",
                        ReleaseDate = DateTime.Parse("1985-7-3"),
                        Genre = "Science Fiction",
                        Director = "Robert Zemeckis",
                        StreamService = "Netflix"
                    },

                    new Movie
                    {
                        Title = "Spider-Man 2",
                        ReleaseDate = DateTime.Parse("2004-6-30"),
                        Genre= "Superhero",
                        Director = "Sam Raimi",
                        StreamService = "iTunes"
                    },

                    new Movie
                    {
                        Title = "An Officer and a Gentleman",
                        ReleaseDate = DateTime.Parse("1982-7-28"),
                        Genre = "Romantic Drama",
                        Director = "Taylor Hackford",
                        StreamService = "iTunes"
                    },

                    new Movie
                    {
                        Title = "John Wick",
                        ReleaseDate = DateTime.Parse("2014-10-24"),
                        Genre = "Action Thriller",
                        Director = "Chad Stahelski",
                        StreamService = "Netflix"
                        
                    },

                    new Movie
                    {
                        Title = "Honey, I Shrunk the Kids",
                        ReleaseDate = DateTime.Parse("1989-6-23"),
                        Genre = "Comic Science Fiction",
                        Director = "Joe Johnston",
                        StreamService = "Disney+"
                    },

                    new Movie
                    {
                        Title = "Mad Max: Fury Road",
                        ReleaseDate = DateTime.Parse("2015-5-15"),
                        Genre = "Action",
                        Director = "George Miller",
                        StreamService = "iTunes"
                    },

                    new Movie
                    {
                        Title = "House of 1000 Corpses",
                        ReleaseDate = DateTime.Parse("2003-4-3"),
                        Genre = "Horror",
                        Director = "Rob Zombie", 
                        StreamService = "Prime Video"
                    }
                    
    
                  );
                context.SaveChanges();
            }
        }
    }
}
