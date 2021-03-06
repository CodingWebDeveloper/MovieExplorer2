using System;
using System.Collections.Generic;
using System.Text;

namespace MovieExplorer.Web.ViewModels.Movies
{
    public class ListMovieViewModel
    {
        public InputSearchModel Search { get; set; }

        public ICollection<MovieViewModel> AllMovies { get; set; }
    }
}
