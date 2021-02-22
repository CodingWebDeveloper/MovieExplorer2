using AutoMapper;
using MovieExplorer.Data.Models;
using MovieExplorer.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieExplorer.Web.ViewModels.Countries
{
    public class CountryViewModel : IMapFrom<Country>, IHaveCustomMappings
    {
        public int CountryId { get; set; }

        public string CountryName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Country, CountryViewModel>()
                .ForMember(x => x.CountryName, y => y.MapFrom(x => x.Name));
        }
    }
}
