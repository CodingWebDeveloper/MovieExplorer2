using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieExplorer.Web.ViewModels.Countries
{
    public class CountryInputModel
    {
        [Required(ErrorMessage = "State countryName!")]
        public string Name { get; set; }
    }
}
