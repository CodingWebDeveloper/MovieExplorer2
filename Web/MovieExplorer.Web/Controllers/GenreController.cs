

namespace MovieExplorer.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MovieExplorer.Services.Data;
    using MovieExplorer.Web.ViewModels.Genres;
    using MovieExplorer.Web.ViewModels.Movies;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class GenreController : BaseController
    {
        private readonly IGenreService genreService;

        public GenreController(IGenreService genreService)
        {
            this.genreService = genreService;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(GenreInputModel genreInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            try
            {
                await this.genreService.CreateGenre(genreInputModel);
            }
            catch (Exception e)
            {
                this.TempData["MessageErrorGenre"] = e.Message;
                return this.View();
            }

            return this.View();
        }

        [Authorize]
        public IActionResult AllMovies(int id)
        {
            ListMovieViewModel movies = new ListMovieViewModel
            {
                AllMovies = this.genreService.GetAllMoviesByGenre(id).ToList(),
                AllGenres = this.genreService.GetAllGenres().ToList(),
            };

            return this.View(movies);
        }
    }
}
