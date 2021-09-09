using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTracker.Models
{
    public class Movie //Defines what makes a movie in the app
    {
        public int ID { get; set; } //Acts as primary key. Uniquely identifes the movie entries within MovieTracker

        [StringLength(60, MinimumLength = 3)]
        [Required] //Error message will occur if no value is entered
        public string Title { get; set; }


        [Display(Name = "ReleaseDate")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")] //This specifies that a string pattern must be entered to run properly
        [Required]
        [StringLength(30)]
        public string Genre { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        [StringLength(50)]
        public string Director { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        [StringLength(15)]
        public string StreamService { get; set; }
    }
}
