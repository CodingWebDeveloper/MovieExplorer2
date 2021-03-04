using AutoMapper;
using MovieExplorer.Data.Models;
using MovieExplorer.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieExplorer.Web.ViewModels.Movies
{
    public class MovieActorViewModel : IMapFrom<MovieActor>, IHaveCustomMappings
    {
        public int MovieId { get; set; }

        public string MovieName { get; set; }

        public DateTime ReleaseDate { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            //configuration.CreateMap<MovieActor, MovieActorViewModel>()
            //    .ForMember(x=>x.MovieId, y=>y.MapFrom(x=>x.));
        }
    }
}
