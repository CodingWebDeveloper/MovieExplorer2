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
using Microsoft.AspNetCore.Authorization;
using MovieExplorer.Common;

namespace MovieExplorer.Web.Controllers
{
    public class MovieController : Controller
    {
        private readonly IDeletableEntityRepository<Movie> movieRepository;
        private readonly IMovieService movieService;
        private readonly IDeletableEntityRepository<Director> directorRepository;
        private readonly IDirectorService directorService;
        private readonly ICountryService countryService;

        public MovieController(IDeletableEntityRepository<Movie> movieRepository, IMovieService movieService, IDeletableEntityRepository<Director> directorRepository, IDirectorService directorService, ICountryService countryService)
        {
            this.movieRepository = movieRepository;
            this.movieService = movieService;
            this.directorRepository = directorRepository;
            this.directorService = directorService;
            this.countryService = countryService;
        }

        //[Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Create()
        {
            var directors = new MovieInputModel
            {
                AllListDirectors = this.directorService.GetAllItems(),
                AllListCoutries = this.countryService.GetAllCountries(),
            };


            return this.View(directors);
        }

        [HttpPost]
        //[Authorize(Roles =GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Create(MovieInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                inputModel.AllListDirectors = this.directorService.GetAllItems();
                inputModel.AllListCoutries = this.countryService.GetAllCountries();
                return this.View(inputModel);
            }

            await this.movieService.CreateMovie(inputModel.Title, inputModel.ReleaseDate, inputModel.Minutes, inputModel.Rate, inputModel.ImageUrl, inputModel.Description, inputModel.DirectorId, inputModel.CountryId);
            return this.Redirect("/");
        }
    }
}
