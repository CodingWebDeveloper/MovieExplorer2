using MovieExplorer.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieExplorer.Services.Data
{
    public interface IUserService
    {
        //IEnumerable<MovieUser> GetAllMovies(string username);
        int MoviesOfUserCount(string username);
    }
}
