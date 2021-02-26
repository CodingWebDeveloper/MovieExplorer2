using Microsoft.AspNetCore.Mvc.Rendering;
using MovieExplorer.Data.Common.Repositories;
using MovieExplorer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieExplorer.Services.Data
{
    public class ActorService : IActorService
    {
        private readonly IDeletableEntityRepository<Actor> actorRepository;

        public ActorService(IDeletableEntityRepository<Actor> actorRepository)
        {
            this.actorRepository = actorRepository;
        }

        public async Task CreateActor(string firstName, string middleName, string lastName)
        {
            Actor actor = new Actor
            {
               FirstName = firstName,
               MiddleName = middleName,
               LastName = lastName,
            };

            await this.actorRepository.AddAsync(actor);
            await this.actorRepository.SaveChangesAsync();
        }

        public IEnumerable<SelectListItem> GetAllActors()
        {
            return this.actorRepository.All().Select(x => new SelectListItem
            {
                Text = x.FirstName + " " + x.MiddleName + " " + x.LastName,
                Value = x.Id.ToString(),
            });
        }
    }
}
