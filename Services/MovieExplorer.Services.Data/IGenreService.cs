using Microsoft.AspNetCore.Mvc.Rendering;
using MovieExplorer.Web.ViewModels.Genres;
using MovieExplorer.Web.ViewModels.Movies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieExplorer.Services.Data
{
    public interface IGenreService
    {
        Task CreateGenre(GenreInputModel genreInputModel);

        IEnumerable<SelectListItem> GetListGenres();

        IEnumerable<GenreViewModel> GetAllGenres();

        IEnumerable<MovieViewModel> GetAllMoviesByGenre(int genereId);
    }
}
