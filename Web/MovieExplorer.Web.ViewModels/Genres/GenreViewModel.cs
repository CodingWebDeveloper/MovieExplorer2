using AutoMapper;
using MovieExplorer.Data.Models;
using MovieExplorer.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieExplorer.Web.ViewModels.Genres
{
    public class GenreViewModel : IMapFrom<Genre>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string GenreName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Genre, GenreViewModel>()
                 .ForMember(x => x.GenreName, y => y.MapFrom(x => x.Name));
        }
    }
}
