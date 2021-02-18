using MovieExplorer.Data.Common.Repositories;
using MovieExplorer.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieExplorer.Services.Data
{
    public interface IMovieService
    {
        void CreateMovie(string title, DateTime releaseDate, int minutes, double rate, string imageUrl, string description, int directorId, int countryId);
    }
}
