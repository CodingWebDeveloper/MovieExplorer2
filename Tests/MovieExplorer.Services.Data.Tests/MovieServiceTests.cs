using Moq;
using MovieExplorer.Data.Common.Repositories;
using MovieExplorer.Data.Models;
using MovieExplorer.Services.Data.Tests.Common;
using MovieExplorer.Web.ViewModels.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MovieExplorer.Services.Data.Tests
{
    public class MovieServiceTests
    {
        public MovieServiceTests()
        {
            MapperInitializer.InitializeMapper();
        }

        public IEnumerable<Director> GetDirectors()
        {
            return new List<Director>
            {
                new Director
                {
                   Id = 1,
                   FirstName = "Steven",
                   LastName = "Spilberg",
                },

                new Director
                {
                    Id = 2,
                    FirstName = "Russo",
                    LastName = "Brothers",
                },

            };
        }

        public IEnumerable<Country> GetCountries()
        {
            return new List<Country>
            {
                new Country
                {
                   Id = 1,
                   Name = "Bulgaria",
                },

                new Country
                {
                    Id = 2,
                    Name = "USA",
                },

            };

        }

        [Fact]
        public void CheckCreateMovie()
        {
            ICollection<Movie> movies = new List<Movie>();

            MovieInputModel firstMovie = new MovieInputModel
            {
                Title = "some title",
                ReleaseDate = DateTime.Parse("2020/03/02"),
                Minutes = 123,
                ImageUrl = "image url",
                Trailer = "traile url",
                Description = "description info",
                DirectorId = 1,
                CountryId = 1,
            };

            MovieInputModel secondMovie = new MovieInputModel
            {
                Title = "second title",
                ReleaseDate = DateTime.Parse("2020/03/05"),
                Minutes = 150,
                ImageUrl = "image url",
                Trailer = "traile url",
                Description = "description info",
                DirectorId = 1,
                CountryId = 1,
            };

            Mock<IDeletableEntityRepository<Movie>> mockMovie = new Mock<IDeletableEntityRepository<Movie>>();
            Mock<IDeletableEntityRepository<Director>> mockDirector = new Mock<IDeletableEntityRepository<Director>>();
            Mock<IDeletableEntityRepository<Country>> mockCountry = new Mock<IDeletableEntityRepository<Country>>();
            Mock<IDeletableEntityRepository<MovieActor>> mockMovieActor = new Mock<IDeletableEntityRepository<MovieActor>>();
            Mock<IDeletableEntityRepository<MovieGenre>> mockMovieGenre = new Mock<IDeletableEntityRepository<MovieGenre>>();

            mockMovie.Setup(x => x.AddAsync(It.IsAny<Movie>()))
               .Callback((Movie movie) => movies.Add(movie));

            mockDirector.Setup(x => x.All()).Returns(this.GetDirectors().AsQueryable);
            mockCountry.Setup(x => x.All()).Returns(this.GetCountries().AsQueryable);

            IMovieService movieService = new MovieService(mockMovie.Object, mockDirector.Object, mockCountry.Object, null , null, null);

            movieService.CreateMovie(firstMovie);
            movieService.CreateMovie(secondMovie);

            Assert.Equal(2, movies.Count);
        }

        public IEnumerable<Movie> GetData()
        {
            return new List<Movie>
            {
                new Movie
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
            };
        }

        [Fact]
        public void CheckDeleteMovie()
        {
            List<Movie> movies = this.GetData().ToList();

            Mock<IDeletableEntityRepository<Movie>> mockMovie = new Mock<IDeletableEntityRepository<Movie>>();

            mockMovie.Setup(x => x.Delete(It.IsAny<Movie>()))
              .Callback((Movie movie) => movies.Remove(movie));

            IMovieService movieService = new MovieService(mockMovie.Object, null, null, null, null, null);

            movieService.DeleteMovie(1);

            Assert.Equal(0, movies.Count(x => x.IsDeleted == true));
        }
    }
}
