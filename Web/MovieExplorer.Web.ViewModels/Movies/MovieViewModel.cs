using MovieExplorer.Data.Models;
using MovieExplorer.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieExplorer.Web.ViewModels.Movies
{
    public class MovieViewModel : IMapFrom<Movie>
    {
        public string Name { get; set; }

        public string ImageUrl { get; set; }
    }
}
