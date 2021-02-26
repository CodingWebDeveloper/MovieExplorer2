using Microsoft.AspNetCore.Mvc;
using MovieExplorer.Data.Common.Repositories;
using MovieExplorer.Data.Models;
using MovieExplorer.Services.Data;
using MovieExplorer.Web.ViewModels.Movies;
using Microsoft.AspNetCore.Identity;
using System;
using MovieExplorer.Services.Mapping;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieExplorer.Web.ViewModels.Directors;
using Microsoft.AspNetCore.Authorization;
using MovieExplorer.Common;

namespace MovieExplorer.Web.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService movieService;
        private readonly IDirectorService directorService;
        private readonly ICountryService countryService;
        private readonly IActorService actorService;

        public MovieController(IMovieService movieService, IDirectorService directorService, ICountryService countryService, IActorService actorService)
        {
            this.movieService = movieService;
            this.directorService = directorService;
            this.countryService = countryService;
            this.actorService = actorService;
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Create()
        {
            var movies = new MovieInputModel
            {
                AllListDirectors = this.directorService.GetAllItems(),
                AllListCoutries = this.countryService.GetAllCountries(),
                AllListActors = this.actorService.GetAllActors(),
            };


            return this.View(movies);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Create(MovieInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                inputModel.AllListDirectors = this.directorService.GetAllItems();
                inputModel.AllListCoutries = this.countryService.GetAllCountries();
                inputModel.AllListActors = this.actorService.GetAllActors();
                return this.View(inputModel);
            }

            await this.movieService.CreateMovie(inputModel.Title, inputModel.ReleaseDate, inputModel.Minutes, inputModel.Rate, inputModel.ImageUrl, inputModel.Trailer, inputModel.Description, inputModel.DirectorId, inputModel.CountryId, inputModel.ActorsId);
            return this.Redirect("/");
        }

        public async Task<IActionResult> MoviePage(int id)
        {
            MoviePageViewModel movie = this.movieService.GetMovieById(id);

            return this.View(movie);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.movieService.DeleteMovie(id);

            return this.Redirect("/");
        }

        public async Task<IActionResult> AddMovieToUser(int id)
        {
            string userName = this.User.Identity.Name;
            await this.movieService.AddToUser(userName, id);

            return this.Redirect("/");
        }
    }
}
