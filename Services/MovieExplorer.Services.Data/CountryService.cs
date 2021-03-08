using Microsoft.AspNetCore.Mvc.Rendering;
using MovieExplorer.Data.Common.Repositories;
using MovieExplorer.Data.Models;
using MovieExplorer.Services.Mapping;
using MovieExplorer.Web.ViewModels.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieExplorer.Services.Data
{
    public class CountryService : ICountryService
    {
        private readonly IDeletableEntityRepository<Country> countryRepository;

        public CountryService(IDeletableEntityRepository<Country> countryRepository)
        {
            this.countryRepository = countryRepository;
        }

        public async Task CreateCountry(string name)
        {
            if (this.countryRepository.All().Any(c => c.Name == name))
            {
                throw new ArgumentException("This country already exists!");
            }

            Country country = new Country
            {
                Name = name,
            };

            await this.countryRepository.AddAsync(country);

            await this.countryRepository.SaveChangesAsync();
        }

        public IEnumerable<SelectListItem> GetAllCountries()
        {
            return this.countryRepository.All().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            });
        }

        public IEnumerable<CountryViewModel> GetCountries()
        {
            return this.countryRepository.All().To<CountryViewModel>().ToList();
        }
    }
}
