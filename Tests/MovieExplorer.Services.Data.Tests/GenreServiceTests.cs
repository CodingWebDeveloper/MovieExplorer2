using Moq;
using MovieExplorer.Data.Common.Repositories;
using MovieExplorer.Data.Models;
using MovieExplorer.Services.Data.Tests.Common;
using MovieExplorer.Web.ViewModels.Genres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MovieExplorer.Services.Data.Tests
{
    public class GenreServiceTests
    {
        public GenreServiceTests()
        {
            MapperInitializer.InitializeMapper();
        }

        [Fact]
        public void CheckCreateGenre()
        {
            ICollection<Genre> genres = new List<Genre>();

            GenreInputModel firstGenre = new GenreInputModel
            {
                Name = "Romantic",
            };

            GenreInputModel secondGenre = new GenreInputModel
            {
                Name = "Horror",
            };

            Mock<IDeletableEntityRepository<Genre>> mockGenre = new Mock<IDeletableEntityRepository<Genre>>();

            mockGenre.Setup(x => x.AddAsync(It.IsAny<Genre>()))
                .Callback((Genre genre) => genres.Add(genre));

            IGenreService genreService = new GenreService(mockGenre.Object, null);

            genreService.CreateGenre(firstGenre);
            genreService.CreateGenre(secondGenre);

            Assert.Equal(2, genres.Count());
        }
    }
}
