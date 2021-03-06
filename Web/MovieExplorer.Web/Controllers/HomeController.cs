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

    public class HomeController : BaseController
    {
        private readonly IDeletableEntityRepository<Movie> movieRepository;
        private readonly IUserService userService;
        private readonly IMovieService movieService;

        public HomeController(IDeletableEntityRepository<Movie> movieRepository, IUserService userService, IMovieService movieService)
        {
            this.movieRepository = movieRepository;
            this.userService = userService;
            this.movieService = movieService;
        }

        public IActionResult Index()
        {
            var movies = this.movieRepository.All().To<MovieViewModel>().ToList();

            ListMovieViewModel movie = new ListMovieViewModel
            {
                AllMovies = movies,
            };

            this.ViewData["CountOfMovies"] = this.userService.MoviesOfCount(this.User.Identity.Name);
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
