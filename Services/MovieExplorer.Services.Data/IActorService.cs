﻿using Microsoft.AspNetCore.Mvc.Rendering;
using MovieExplorer.Data.Models;
using MovieExplorer.Web.ViewModels.Actors;
using MovieExplorer.Web.ViewModels.Movies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieExplorer.Services.Data
{
    public interface IActorService
    {
        Task CreateActor(ActorInputModel actorInputModel);

        IEnumerable<SelectListItem> GetAllActors();

        IEnumerable<MovieViewModel> GetAllMoviesByActor(int actorId);
    }
}
