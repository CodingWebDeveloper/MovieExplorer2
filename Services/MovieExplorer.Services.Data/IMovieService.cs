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
        Task CreateMovie(MovieInputModel movieInputModel);

        Task DeleteMovie(int movieId);

        Task AddToUser(string userId, int movieId);

        MoviePageViewModel GetMovieById(int movieId);

        IEnumerable<MovieUserViewModel> GetAllMoviesPerUser(string username);

        Task RemoveMovieFromUserCollection(string userName, int movieId);

        IEnumerable<MovieViewModel> SearchMovie(string movieName);
    }
}
