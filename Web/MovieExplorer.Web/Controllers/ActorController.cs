using Microsoft.AspNetCore.Mvc;
using MovieExplorer.Services.Data;
using MovieExplorer.Web.ViewModels.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieExplorer.Web.Controllers
{
    public class ActorController : BaseController
    {
        private readonly IActorService actorService;

        public ActorController(IActorService actorService)
        {
            this.actorService = actorService;
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

            await this.actorService.CreateActor(actorInputModel.FirstName, actorInputModel.MiddleName, actorInputModel.LastName);
            return this.Redirect("/");
        }
    }
}
