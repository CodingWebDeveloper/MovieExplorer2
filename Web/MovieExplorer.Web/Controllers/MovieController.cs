using Microsoft.AspNetCore.Mvc;
using MovieExplorer.Data.Common.Repositories;
using MovieExplorer.Data.Models;
using MovieExplorer.Services.Data;
using MovieExplorer.Web.ViewModels.Movies;
using System;
using MovieExplorer.Services.Mapping;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieExplorer.Web.ViewModels.Directors;

namespace MovieExplorer.Web.Controllers
{
    public class MovieController : Controller
    {
        private readonly IDeletableEntityRepository<Movie> movieRepository;
        private readonly IMovieService movieService;
        private readonly IDeletableEntityRepository<Director> directorRepository;

        public MovieController(IDeletableEntityRepository<Movie> movieRepository, IMovieService movieService, IDeletableEntityRepository<Director> directorRepository)
        {
            this.movieRepository = movieRepository;
            this.movieService = movieService;
            this.directorRepository = directorRepository;
        }

        public IActionResult Create()
        {
            var directors = this.directorRepository
                .All().To<DirectorViewModel>().ToArray();

            return this.View(directors);
        }

        [HttpPost]
        public IActionResult Create(MovieInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentException("Done");
            }

            this.movieService.CreateMovie(inputModel.Title, inputModel.ReleaseDate, inputModel.Minutes, inputModel.Rate, inputModel.ImageUrl, inputModel.Description, inputModel.DirectorId, inputModel.CountryId);
            return this.RedirectToAction("Index", "Home");
        }
    }
}
