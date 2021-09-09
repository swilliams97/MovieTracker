using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieTracker.Models;

namespace MovieTracker.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly MovieTracker.Models.MovieTrackerContext _context;

        public IndexModel(MovieTracker.Models.MovieTrackerContext context)
        {
            _context = context;
        }

        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Movie> Movie { get; set; }

        public async Task OnGetAsync(string sortOrder,
    string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            IQueryable<Movie> movieIQ = from s in _context.Movie
                                            select s;

            switch (sortOrder)
            {
                case "Date":
                    movieIQ = movieIQ.OrderBy(s => s.ReleaseDate);
                    break;
                case "date_desc":
                    movieIQ = movieIQ.OrderByDescending(s => s.ReleaseDate);
                    break;
            }

            int pageSize = 5; //Displays 5 movies at a time
            Movie = await PaginatedList<Movie>.CreateAsync(
                movieIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
