using Microsoft.AspNetCore.Mvc.Rendering;
using MovieExplorer.Data.Common.Repositories;
using MovieExplorer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieExplorer.Services.Data
{
    public class DirectorService : IDirectorService
    {
        private readonly IDeletableEntityRepository<Director> directorRepository;

        public DirectorService(IDeletableEntityRepository<Director> directorRepository)
        {
            this.directorRepository = directorRepository;
        }

        public async Task CreateDirector(string firstName, string lastName)
        {
            Director director = new Director
            {
                FirstName = firstName,
                LastName = lastName,
            };

            await this.directorRepository.AddAsync(director);

            await this.directorRepository.SaveChangesAsync();
        }

        public IEnumerable<SelectListItem> GetAllItems()
        {
            return this.directorRepository.All().Select(x => new SelectListItem
            {
                Text = x.FirstName + " " + x.LastName,
                Value = x.Id.ToString(),
            });
        }

    }
}
