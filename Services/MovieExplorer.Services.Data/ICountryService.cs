using Microsoft.AspNetCore.Mvc.Rendering;
using MovieExplorer.Web.ViewModels.Countries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieExplorer.Services.Data
{
    public interface ICountryService
    {
        Task CreateCountry(string name);

        IEnumerable<SelectListItem> GetAllCountries();

        IEnumerable<CountryViewModel> GetCountries();
    }
}
