namespace MovieExplorer.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MovieExplorer.Services.Data;
    using MovieExplorer.Web.ViewModels.Actors;
    using MovieExplorer.Web.ViewModels.Movies;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ActorController : BaseController
    {
        private readonly IActorService actorService;
        private readonly IGenreService genreService;

        public ActorController(IActorService actorService, IGenreService genreService)
        {
            this.actorService = actorService;
            this.genreService = genreService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ActorInputModel actorInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            try
            {
                await this.actorService.CreateActor(actorInputModel);
            }
            catch (Exception e)
            {
                this.TempData["MessageErrorActor"] = e.Message;
                return this.View();
            }

            return this.Redirect("/");
        }

        public async Task<IActionResult> AllMovies(int id)
        {
            ListMovieViewModel movies = new ListMovieViewModel
            {
                AllMovies = this.actorService.GetAllMoviesByActor(id).ToList(),
                AllGenres = this.genreService.GetAllGenres().ToList(),
            };

            return this.View(movies);
        }
    }
}
