namespace MovieExplorer.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MovieExplorer.Common;
    using MovieExplorer.Data.Common.Repositories;
    using MovieExplorer.Data.Models;
    using MovieExplorer.Services.Data;
    using MovieExplorer.Web.ViewModels.Directors;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DirectorController : BaseController
    {
        private readonly IDirectorService directorService;

        public DirectorController(IDirectorService directorService)
        {
            this.directorService = directorService;
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Create(DirectorInputModel directorInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            try
            {
                await this.directorService.CreateDirector(directorInputModel);
            }
            catch (Exception e)
            {
                this.TempData["MessageErrorDirector"] = e.Message;
                return this.View();
            }

            return this.Redirect("/");
        }
    }
}
