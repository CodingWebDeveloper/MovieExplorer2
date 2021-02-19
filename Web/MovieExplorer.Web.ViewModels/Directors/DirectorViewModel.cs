using AutoMapper;
using MovieExplorer.Data.Models;
using MovieExplorer.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieExplorer.Web.ViewModels.Directors
{
    public class DirectorViewModel : IMapFrom<Director>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string DirectorName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Director, DirectorViewModel>()
                .ForMember(x => x.DirectorName, y => y.MapFrom(x => $"{x.FirstName} {x.LastName}"));
        }
    }
}
