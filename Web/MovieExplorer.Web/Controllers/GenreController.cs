using Microsoft.AspNetCore.Mvc;
using MovieExplorer.Services.Data;
using MovieExplorer.Web.ViewModels.Genres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieExplorer.Web.Controllers
{
    public class GenreController : BaseController
    {
        private readonly IGenreService genreService;

        public GenreController(IGenreService genreService)
        {
            this.genreService = genreService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GenreInputModel genreInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.genreService.CreateGenre(genreInputModel.Name);
            return this.View();
        }

    }
}
