using AutoMapper;
using MovieExplorer.Data.Models;
using MovieExplorer.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieExplorer.Web.ViewModels.Movies
{
    public class MovieUserViewModel : IMapFrom<MovieUser>, IHaveCustomMappings
    {
        public string UserId { get; set; }

        public string UserName { get; set;  }

        public int MovieId { get; set; }

        public string MovieName { get; set; }

        public string ImageUrl { get; set; }

        public DateTime AddedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<MovieUser, MovieUserViewModel>()
                .ForMember(x => x.UserId, y => y.MapFrom(x => x.UserId))
                .ForMember(x => x.UserName, y => y.MapFrom(x => x.User.UserName))
                .ForMember(x => x.MovieId, y => y.MapFrom(x => x.MovieId))
                .ForMember(x => x.MovieName, y => y.MapFrom(x => x.Movie.Title))
                .ForMember(x => x.ImageUrl, y => y.MapFrom(x => x.Movie.ImageUrl))
                .ForMember(x => x.AddedOn, y => y.MapFrom(x => x.AddedOn));
        }
    }
}
