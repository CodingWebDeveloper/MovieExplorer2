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
    public class GenreService : IGenreService
    {
        private readonly IDeletableEntityRepository<Genre> genreRepository;

        public GenreService(IDeletableEntityRepository<Genre> genreRepository)
        {
            this.genreRepository = genreRepository;
        }

        public async Task CreateGenre(string genreName)
        {
            if (this.genreRepository.All().Any(g => g.Name == genreName))
            {
                throw new ArgumentException("This genre already exists!");
            }

            Genre genre = new Genre
            {
                Name = genreName,
            };

            await this.genreRepository.AddAsync(genre);
            await this.genreRepository.SaveChangesAsync();
        }

        public IEnumerable<SelectListItem> GetAllGenres()
        {
            return this.genreRepository.All().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            });
        }
    }
}
