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
        private ActorServiceTests()
        {
            MapperInitializer.InitializeMapper();
        }

        [Fact]
        private void CheckCreateActor()
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


        private IEnumerable<MovieActor> GetData()
        {
            return new List<MovieActor>()
            {
                new MovieActor
                {
                   Movie = new Movie
                   {
                       Id = 1,
                       Title = "some title",
                       ReleaseDate = DateTime.Parse("2020/03/02"),
                       Minutes = 123,
                       ImageUrl = "image url",
                       Trailer = "trailer url",
                       Description = "desription info",
                       Director = new Director
                       {
                           Id = 1,
                           FirstName = "director firstName",
                           LastName = "director lastName",
                       },
                       DirectorId = 1,
                       Country = new Country
                       {
                           Id = 1,
                           Name = "USA",
                       },
                       CountryId = 1,
                   },
                   Actor = new Actor
                   {
                       FirstName = "some firstname",
                       LastName = "some lastname",
                   },
                },
                new MovieActor
                {
                   Movie = new Movie
                   {
                       Id = 1,
                       Title = "some title",
                       ReleaseDate = DateTime.Parse("2020/03/02"),
                       Minutes = 123,
                       ImageUrl = "image url",
                       Trailer = "trailer url",
                       Description = "desription info",
                       Director = new Director
                       {
                           Id = 1,
                           FirstName = "director firstName",
                           LastName = "director lastName",
                       },
                       DirectorId = 1,
                       Country = new Country
                       {
                           Id = 1,
                           Name = "USA",
                       },
                       CountryId = 1,
                   },
                   ActorId = 1,
                },
            };
        }

        [Fact]
        public void CheckForGettingAllMvoiesByActor()
        {

            IEnumerable<MovieActor> expectedMovies = this.GetData().Where(x => x.ActorId == 1);
            Mock<IDeletableEntityRepository<MovieActor>> mockMovies = new Mock<IDeletableEntityRepository<MovieActor>>();

            mockMovies.Setup(x => x.All()).Returns(expectedMovies.AsQueryable());

            IActorService actorService = new ActorService(null, mockMovies.Object);

            IEnumerable<MovieViewModel> realMovies = actorService.GetAllMoviesByActor(1).ToList();

            Assert.Equal(expectedMovies.Count(), realMovies.Count());
        }
    }
}
