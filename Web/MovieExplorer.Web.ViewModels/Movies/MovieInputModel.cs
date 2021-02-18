using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieExplorer.Web.ViewModels.Movies
{
    public class MovieInputModel
    {
        [Required]
        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        [Required]
        public int Minutes { get; set; }

        public double Rate { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Description's length should be more than {0}")]
        public string Description { get; set; }

        [Required]
        public int DirectorId { get; set; }

        [Required]
        public int CountryId { get; set; }
    }
}
