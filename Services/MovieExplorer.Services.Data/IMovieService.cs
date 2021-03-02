using MovieExplorer.Data.Common.Repositories;
using MovieExplorer.Data.Models;
using MovieExplorer.Web.ViewModels.Movies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieExplorer.Services.Data
{
    public interface IMovieService
    {
        Task CreateMovie(string title, DateTime releaseDate, int minutes, double rate, string imageUrl, string trailer, string description, int directorId, int countryId, List<int> actorsId, List<int> genresId);

        Task DeleteMovie(int movieId);

        Task AddToUser(string userName, int movieId);

        MoviePageViewModel GetMovieById(int movieId);

        IEnumerable<MovieUserViewModel> GetAllMovies(string username);
    }
}
