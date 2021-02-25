using Microsoft.AspNetCore.Mvc.Rendering;
using MovieExplorer.Data.Common.Repositories;
using MovieExplorer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieExplorer.Services.Data
{
    public class ActorService : IActorService
    {
        private readonly IDeletableEntityRepository<Actor> actorRepository;

        public ActorService(IDeletableEntityRepository<Actor> actorRepository)
        {
            this.actorRepository = actorRepository;
        }

        public IEnumerable<SelectListItem> GetAllActors()
        {
            return this.actorRepository.All().Select(x => new SelectListItem
            {
                Text = x.FirstName + " " + x.LastName,
                Value = x.Id.ToString(),
            });
        }
    }
}
