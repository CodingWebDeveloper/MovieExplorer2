using AutoMapper;
using MovieExplorer.Data.Models;
using MovieExplorer.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieExplorer.Web.ViewModels.Movies
{
    public class MovieViewModel : IMapFrom<Movie>, IMapFrom<MovieActor>, IMapFrom<MovieGenre>, IHaveCustomMappings
    {
        public string MovieId { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public InputSearchModel SearchInput { get; set; }

        public DateTime ReleaseDate { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Movie, MovieViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(x => x.Title))
                .ForMember(x => x.MovieId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.ReleaseDate, y => y.MapFrom(x => x.ReleaseDate));

            configuration.CreateMap<MovieActor, MovieViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(x => x.Movie.Title))
                .ForMember(x => x.ImageUrl, y => y.MapFrom(x => x.Movie.ImageUrl))
                .ForMember(x => x.ReleaseDate, y => y.MapFrom(x => x.Movie.ReleaseDate));

            configuration.CreateMap<MovieGenre, MovieViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(x => x.Movie.Title))
                .ForMember(x => x.ImageUrl, y => y.MapFrom(x => x.Movie.ImageUrl))
                .ForMember(x => x.ReleaseDate, y => y.MapFrom(x => x.Movie.ReleaseDate));
        }
    }
}
