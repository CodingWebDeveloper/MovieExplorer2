using MovieExplorer.Data.Common.Repositories;
using MovieExplorer.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieExplorer.Services.Data
{
    public class DirectorService : IDirectorService
    {
        private readonly IDeletableEntityRepository<Director> directorRepository;

        public DirectorService(IDeletableEntityRepository<Director> directorRepository)
        {
            this.directorRepository = directorRepository;
        }

        public void CreateDirector(string firstName, string lastName)
        {
            Director director = new Director
            {
                FirstName = firstName,
                LastName = lastName,
            };

            this.directorRepository.AddAsync(director);

            this.directorRepository.SaveChangesAsync();
        }
    }
}
