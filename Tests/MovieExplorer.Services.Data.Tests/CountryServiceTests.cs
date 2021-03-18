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
    public class CountryServiceTests
    {
        public ICollection<Country> GetTestData()
        {
            return new List<Country>() { new Country { Id = 1, Name = "Guinea" } };
        }

        public CountryServiceTests()
        {
            MapperInitializer.InitializeMapper();
        }

        [Fact]
        public void CheckReturnCoutryData()
        {
            Mock<IDeletableEntityRepository<Country>> mock = new Mock<IDeletableEntityRepository<Country>>();
            IEnumerable<Country> countries = this.GetTestData();
            mock.Setup(x => x.All()).Returns(countries.AsQueryable());
            ICountryService countryService = new CountryService(mock.Object);
            IEnumerable<CountryViewModel> actualCountries = countryService.GetCountries();
            Assert.Equal(countries.Count(), actualCountries.Count());
        }

        [Fact]
        public void CheckCreateCountry()
        {
            ICollection<Country> countries = new List<Country>();
            Country country = new Country
            {
                Name = "USA",
            };

            Mock<IDeletableEntityRepository<Country>> mock = new Mock<IDeletableEntityRepository<Country>>();
            mock.Setup(x => x.AddAsync(It.IsAny<Country>())).Callback((Country country) => countries.Add(country));
            ICountryService countryService = new CountryService(mock.Object);

            CountryInputModel firstCountryInput = new CountryInputModel()
            {
                Name = "USA",
            };
            CountryInputModel secondCountryInput = new CountryInputModel()
            {
                Name = "Canada",
            };

            countryService.CreateCountry(firstCountryInput);
            countryService.CreateCountry(secondCountryInput);
            Assert.Equal(2, countries.Count());
        }
    }
}
