using AutoMapper;
using MovieExplorer.Data.Models;
using MovieExplorer.Services.Mapping;
using MovieExplorer.Web.ViewModels.Actors;
using MovieExplorer.Web.ViewModels.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieExplorer.Web.ViewModels.Movies
{
    public class MoviePageViewModel : IMapFrom<Movie>, IHaveCustomMappings, IMapFrom<CommentViewModel>
    {
        public int MovieId { get; set; }

        public string Title { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public string ImageUrl { get; set; }

        public string Trailer { get; set; }

        public string Description { get; set; }

        public string CountryName { get; set; }

        public string DirectorName { get; set; }

        public double? Rate { get; set; }

        public int Minutes { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

        public IEnumerable<ActorViewModel> Actors { get; set; }

        public IEnumerable<string> Genres { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Movie, MoviePageViewModel>()
                .ForMember(x => x.DirectorName, y => y.MapFrom(x => x.Director.FirstName + " " + x.Director.LastName))
                .ForMember(x => x.CountryName, y => y.MapFrom(x => x.Country.Name))
                .ForMember(x => x.MovieId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.Actors, y => y.MapFrom(x => x.MovieActors))
                .ForMember(x => x.Genres, y => y.MapFrom(x => x.Genres.Select(x => x.Genre.Name)));
        }
    }
}
