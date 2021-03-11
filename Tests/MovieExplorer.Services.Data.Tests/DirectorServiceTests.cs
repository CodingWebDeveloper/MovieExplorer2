using Moq;
using MovieExplorer.Data.Common.Repositories;
using MovieExplorer.Data.Models;
using MovieExplorer.Services.Data.Tests.Common;
using MovieExplorer.Web.ViewModels.Directors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MovieExplorer.Services.Data.Tests
{
    public class DirectorServiceTests
    {

        public DirectorServiceTests()
        {
            MapperInitializer.InitializeMapper();
        }

        [Fact]
        public void CheckCreateDirector()
        {
            ICollection<Director> directors = new List<Director>();

            DirectorInputModel firstDirector = new DirectorInputModel
            {
                FirstName = "Steven",
                LastName = "Spilberg",
            };

            DirectorInputModel secondDirector = new DirectorInputModel
            {
                FirstName = "some name",
                LastName = "some name",
            };

            Mock<IDeletableEntityRepository<Director>> mockDirector = new Mock<IDeletableEntityRepository<Director>>();

            mockDirector.Setup(x => x.AddAsync(It.IsAny<Director>()))
                .Callback((Director director) => directors.Add(director));

            IDirectorService directorService = new DirectorService(mockDirector.Object);

            directorService.CreateDirector(firstDirector);
            directorService.CreateDirector(secondDirector);

            Assert.Equal(2, directors.Count());
        }
    }
}
