using AutoMapper;
using MovieExplorer.Data.Models;
using MovieExplorer.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieExplorer.Web.ViewModels.Movies
{
    public class MoviePageViewModel : IMapFrom<Movie>, IHaveCustomMappings
    {
        public int MovieId { get; set; }

        public string Title { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public string ImageUrl { get; set; }

        public string Trailer { get; set; }

        public string Description { get; set; }

        public string CountryName { get; set; }

        public string DirectroName { get; set; }

        public int Minutes { get; set; }

        public List<string> Comments { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Movie, MoviePageViewModel>()
                .ForMember(x => x.DirectroName, y => y.MapFrom(x => x.Director.FirstName + " " + x.Director.LastName))
                .ForMember(x => x.CountryName, y => y.MapFrom(x => x.Country.Name))
                .ForMember(x => x.MovieId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.Comments, y => y.MapFrom(x => x.Comments.Select(x => x.Text)));
        }
    }
}
