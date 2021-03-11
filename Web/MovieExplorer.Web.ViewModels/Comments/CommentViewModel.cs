using AutoMapper;
using MovieExplorer.Data.Models;
using MovieExplorer.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieExplorer.Web.ViewModels.Comments
{
    public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public string Comment { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
                .ForMember(x => x.Comment, y => y.MapFrom(x => x.Text))
                .ForMember(x => x.CreatedOn, y => y.MapFrom(x => x.CreatedOn))
                .ForMember(x => x.UserName, y => y.MapFrom(x => x.User.UserName));
        }
    }
}
