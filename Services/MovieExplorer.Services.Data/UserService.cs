using MovieExplorer.Data.Common.Repositories;
using MovieExplorer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieExplorer.Services.Data
{
    public class UserService : IUserService
    {
        //private readonly IDeletableEntityRepository<Movie> movieRepository;
        //private readonly IDeletableEntityRepository<ApplicationUser> userRepository;

        //public UserService(IDeletableEntityRepository<Movie> movieRepository, IDeletableEntityRepository<ApplicationUser> userRepository)
        //{
        //    this.movieRepository = movieRepository;
        //    this.userRepository = userRepository;
        //}

        //public IEnumerable<MovieUser> GetAllMovies(string username)
        //{
        //    ApplicationUser user = this.userRepository.All().FirstOrDefault(u => u.UserName == username);

        //    var userMovies = user.Movies.Where(m => m.User.UserName == username);

        //    return userMovies;
        //}
    }
}
