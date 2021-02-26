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
        private readonly IDeletableEntityRepository<Movie> userRepository;

        public UserService(IDeletableEntityRepository<Movie> movieRepository)
        {
            this.userRepository = userRepository;
        }

        //public IEnumerable<MovieUser> GetAllMoviesOfUser(string id)
        //{

        //    return this.GetAllMoviesOfUser();
        //}

    }
}
