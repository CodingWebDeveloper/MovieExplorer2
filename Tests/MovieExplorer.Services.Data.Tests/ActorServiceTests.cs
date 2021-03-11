using Moq;
using MovieExplorer.Data.Common.Repositories;
using MovieExplorer.Data.Models;
using MovieExplorer.Services.Data.Tests.Common;
using MovieExplorer.Web.ViewModels.Actors;
using MovieExplorer.Web.ViewModels.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MovieExplorer.Services.Data.Tests
{
    public class ActorServiceTests
    {
        public ActorServiceTests()
        {
            MapperInitializer.InitializeMapper();
        }

        [Fact]
        public void CheckCreateActor()
        {
            ICollection<Actor> actors = new List<Actor>();

            ActorInputModel firstActor = new ActorInputModel
            {
              FirstName = "Will",
              LastName = "Smith",
            };

            ActorInputModel secondActor = new ActorInputModel
            {
                FirstName = "Georgi",
                LastName = "Kostadinov",
            };

            Mock<IDeletableEntityRepository<Actor>> mockActor = new Mock<IDeletableEntityRepository<Actor>>();

            mockActor.Setup(x => x.AddAsync(It.IsAny<Actor>()))
               .Callback((Actor actor) => actors.Add(actor));

            IActorService actorService = new ActorService(mockActor.Object, null);

            actorService.CreateActor(firstActor);
            actorService.CreateActor(secondActor);

            Assert.Equal(2, actors.Count);
        }

        [Fact]
        public void CheckForGettingAllMvoiesByActor()
        {
            ICollection<MovieActor> movies = new List<MovieActor>()
            { 
                new MovieActor { MovieId = 1, ActorId = 1 },
                new MovieActor { MovieId = 2, ActorId = 1 },
            };

            IEnumerable<MovieActor> expectedMovies = movies.Where(x => x.ActorId == 1);
            Mock<IDeletableEntityRepository<MovieActor>> mockMovies = new Mock<IDeletableEntityRepository<MovieActor>>();

            mockMovies.Setup(x => x.All()).Returns(expectedMovies.AsQueryable());

            IActorService actorService = new ActorService(null, mockMovies.Object);

            IEnumerable<MovieViewModel> realMovies = actorService.GetAllMoviesByActor(1).ToList();

            Assert.Equal(expectedMovies.Count(), realMovies.Count());
        }
    }
}
