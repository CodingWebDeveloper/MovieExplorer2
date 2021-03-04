using AutoMapper;
using MovieExplorer.Data.Models;
using MovieExplorer.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieExplorer.Web.ViewModels.Actors
{
    public class ActorViewModel : IMapFrom<MovieActor>, IHaveCustomMappings
    {
        public int ActorId { get; set; }

        public string ActorName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<MovieActor, ActorViewModel>()
                 .ForMember(x => x.ActorName, y => y.MapFrom(x => $"{x.Actor.FirstName} {x.Actor.MiddleName} {x.Actor.LastName}"));
        }
    }
}
