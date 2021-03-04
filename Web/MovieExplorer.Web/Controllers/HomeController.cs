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

    public class HomeController : BaseController
    {
        private readonly IDeletableEntityRepository<Movie> movieRepository;

        public HomeController(IDeletableEntityRepository<Movie> movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public IActionResult Index()
        {
            var movies = this.movieRepository.All().To<MovieViewModel>();
            return this.View(movies);
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
