using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieExplorer.Web.ViewModels.Genres
{
    public class GenreInputModel
    {
        [Required(ErrorMessage = "State name!")]
        public string Name { get; set; }
    }
}
