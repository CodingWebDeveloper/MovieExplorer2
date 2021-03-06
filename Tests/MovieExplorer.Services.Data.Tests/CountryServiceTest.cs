using Moq;
using MovieExplorer.Data.Common.Repositories;
using MovieExplorer.Data.Models;
using MovieExplorer.Data.Repositories;
using MovieExplorer.Services.Data.Tests.Common;
using MovieExplorer.Web.ViewModels.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MovieExplorer.Services.Data.Tests
{
    public class CountryServiceTest
    {
        public ICollection<Country> GetTestData()
        {
            return new List<Country>() { new Country { Id = 1, Name = "Guinea" } };
        }

        public CountryServiceTest()
        {
            MapperInitializer.InitializeMapper();
        }

        [Fact]
        public void CheckReturnCoutryData()
        {
            Mock<IDeletableEntityRepository<Country>> mock = new Mock<IDeletableEntityRepository<Country>>();
            ICollection<Country> countries = this.GetTestData();
            mock.Setup(x => x.All()).Returns(countries.AsQueryable());
            ICountryService countryService = new CountryService(mock.Object);
            IEnumerable<CountryViewModel> actualCountries = countryService.GetCountries();
            Assert.Equal(countries.Count, actualCountries.Count());
        }

    }
}
