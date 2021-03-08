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
        private readonly IGenreService genreService;

        public MovieController(IMovieService movieService, IDirectorService directorService, ICountryService countryService, IActorService actorService, IGenreService genreService)
        {
            this.movieService = movieService;
            this.directorService = directorService;
            this.countryService = countryService;
            this.actorService = actorService;
            this.genreService = genreService;
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Create()
        {
            var movie = new MovieInputModel
            {
                AllListDirectors = this.directorService.GetAllItems(),
                AllListCoutries = this.countryService.GetAllCountries(),
                AllListActors = this.actorService.GetAllActors(),
                AllListGenres = this.genreService.GetAllGenres(),
            };

            return this.View(movie);
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
                inputModel.AllListGenres = this.genreService.GetAllGenres();
                return this.View(inputModel);
            }

            try
            {
                await this.movieService.CreateMovie(inputModel.Title, inputModel.ReleaseDate, inputModel.Minutes, inputModel.Rate, inputModel.ImageUrl, inputModel.Trailer, inputModel.Description, inputModel.DirectorId, inputModel.CountryId, inputModel.ActorsId, inputModel.GenresId);
            }
            catch (Exception e)
            {
                inputModel.AllListDirectors = this.directorService.GetAllItems();
                inputModel.AllListCoutries = this.countryService.GetAllCountries();
                inputModel.AllListActors = this.actorService.GetAllActors();
                inputModel.AllListGenres = this.genreService.GetAllGenres();
                this.TempData["Message"] = e.Message;
                return this.View(inputModel);
            }

            return this.Redirect("/");
        }

        [Authorize]
        public async Task<IActionResult> MoviePage(int id)
        {
            MoviePageViewModel movie = this.movieService.GetMovieById(id);

            return this.View(movie);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Delete(int id)
        {
            await this.movieService.DeleteMovie(id);

            return this.Redirect("/");
        }

        public async Task<IActionResult> AddMovieToUser(int id)
        {
            string userName = this.User.Identity.Name;
            try
            {
               await this.movieService.AddToUser(userName, id);
            }
            catch (Exception ex)
            {
               this.ViewData["Error"] = ex.Message;
               return this.RedirectToAction("Error", "Home");
            }

            return this.Redirect("/");
        }

        [Authorize]
        public async Task<IActionResult> MovieUserPage(string id)
        {
            var userMovies = this.movieService.GetAllMovies(id);
            return this.View(userMovies);
        }

        public async Task<IActionResult> Remove(int id)
        {
            string userName = this.User.Identity.Name;

            await this.movieService.RemoveMovie(userName, id);

            return this.Redirect("/");
        }

        [HttpPost]
        public IActionResult Search(InputSearchModel search)
        {
            IEnumerable<MovieViewModel> movie = this.movieService.SearchMovie(search.Title);

            return this.View(movie);
        }
    }
}
