using AutoMapper;
using MovieExplorer.Data.Models;
using MovieExplorer.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieExplorer.Web.ViewModels.Countries
{
    public class CountryViewModel : IMapFrom<Country>
    {
        public int Id { get; set; }

        public string Name { get; set; }

    }
}
