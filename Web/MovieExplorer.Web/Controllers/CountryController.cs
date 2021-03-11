namespace MovieExplorer.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MovieExplorer.Services.Data;
    using System;
    using MovieExplorer.Web.ViewModels.Directors;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MovieExplorer.Web.ViewModels.Countries;
    using MovieExplorer.Common;
    using Microsoft.AspNetCore.Authorization;

    public class CountryController : BaseController
    {
        private readonly ICountryService countryService;

        public CountryController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Create(CountryInputModel countryInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            try
            {
                await this.countryService.CreateCountry(countryInputModel);
            }
            catch (Exception e)
            {
                this.TempData["MessaegErrorCountry"] = e.Message;
                return this.View();
            }

            return this.Redirect("/");
        }
    }
}
