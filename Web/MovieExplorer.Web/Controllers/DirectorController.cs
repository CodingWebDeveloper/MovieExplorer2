using Microsoft.AspNetCore.Mvc;
using MovieExplorer.Data.Common.Repositories;
using MovieExplorer.Data.Models;
using MovieExplorer.Services.Data;
using MovieExplorer.Web.ViewModels.Directors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieExplorer.Web.Controllers
{
    public class DirectorController : Controller
    {
        private readonly IDirectorService directorService;

        public DirectorController(IDirectorService directorService)
        {
            this.directorService = directorService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(DirectorInputModel directorInputModel)
        {
            if(!ModelState.IsValid)
            {
                throw new ArgumentNullException("done");
            }

            this.directorService.CreateDirector(directorInputModel.FirstnName, directorInputModel.LastName);
            return this.View();
        }
    }
}
