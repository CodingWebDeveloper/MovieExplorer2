namespace MovieExplorer.Web.Controllers
{
    using System.Diagnostics;
    using MovieExplorer.Services.Mapping;
    using MovieExplorer.Web.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using MovieExplorer.Data.Common.Repositories;
    using MovieExplorer.Data.Models;
    using MovieExplorer.Web.ViewModels.Movies;
    using System.Collections;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;
    using MovieExplorer.Services.Data;
    using System.Linq;
    using MovieExplorer.Web.ViewModels.Genres;

    public class HomeController : BaseController
    {
        private readonly IDeletableEntityRepository<Movie> movieRepository;
        private readonly IUserService userService;
        private readonly IMovieService movieService;
        private readonly IGenreService genreService;

        public HomeController(IDeletableEntityRepository<Movie> movieRepository, IUserService userService, IMovieService movieService, IGenreService genreService)
        {
            this.movieRepository = movieRepository;
            this.userService = userService;
            this.movieService = movieService;
            this.genreService = genreService;
        }

        public IActionResult Index()
        {
            var movies = this.movieRepository.All().To<MovieViewModel>().ToList();
            IEnumerable<GenreViewModel> geners = this.genreService.GetAllGenres();
            ListMovieViewModel movie = new ListMovieViewModel
            {
                AllMovies = movies,
                AllGenres = geners.ToArray(),
            };

            this.ViewData["CountOfMovies"] = this.userService.MoviesOfUserCount(this.User.Identity.Name);
            return this.View(movie);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
