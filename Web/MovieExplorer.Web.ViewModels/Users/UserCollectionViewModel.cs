using AutoMapper;
using MovieExplorer.Data.Models;
using MovieExplorer.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieExplorer.Web.ViewModels.Users
{
    public class UserCollectionViewModel : IMapFrom<MovieUser>, IHaveCustomMappings
    {
        public string Title { get; set; }

        public string UserName { get; set; }

        public DateTime AddedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<MovieUser, UserCollectionViewModel>()
                .ForMember(x => x.Title, y => y.MapFrom(x => x.Movie.Title))
                .ForMember(x => x.UserName, y => y.MapFrom(x => x.User.UserName));
        }
    }
}
