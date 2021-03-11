using Microsoft.AspNetCore.Mvc.Rendering;
using MovieExplorer.Data.Common.Repositories;
using MovieExplorer.Data.Models;
using MovieExplorer.Services.Mapping;
using MovieExplorer.Web.ViewModels.Actors;
using MovieExplorer.Web.ViewModels.Movies;
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
        private readonly IDeletableEntityRepository<MovieActor> movieActorRepository;
        private readonly IDeletableEntityRepository<Movie> movieRepository;

        public ActorService(IDeletableEntityRepository<Actor> actorRepository, IDeletableEntityRepository<MovieActor> movieActorRepository, IDeletableEntityRepository<Movie> movieRepository)
        {
            this.actorRepository = actorRepository;
            this.movieActorRepository = movieActorRepository;
            this.movieRepository = movieRepository;
        }

        public async Task CreateActor(ActorInputModel actorInputModel)
        {
            if (this.actorRepository.All().Any(a => a.FirstName == actorInputModel.FirstName && a.LastName == actorInputModel.LastName))
            {
                throw new ArgumentException("This actor already exists!");
            }

            Actor actor = new Actor
            {
               FirstName = actorInputModel.FirstName,
               MiddleName = actorInputModel.MiddleName,
               LastName = actorInputModel.LastName,
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

        public IEnumerable<MovieViewModel> GetAllMoviesByActor(int actorId)
        {
            IEnumerable<MovieViewModel> movies = this.movieActorRepository.All().Where(x => x.ActorId == actorId).To<MovieViewModel>();
            return movies;
        }
    }
}
