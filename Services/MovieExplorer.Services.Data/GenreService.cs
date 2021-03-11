using Microsoft.AspNetCore.Mvc.Rendering;
using MovieExplorer.Data.Common.Repositories;
using MovieExplorer.Data.Models;
using MovieExplorer.Services.Mapping;
using MovieExplorer.Web.ViewModels.Genres;
using MovieExplorer.Web.ViewModels.Movies;
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
        private readonly IDeletableEntityRepository<MovieGenre> movieGenreRepository;

        public GenreService(IDeletableEntityRepository<Genre> genreRepository, IDeletableEntityRepository<MovieGenre> movieGenreRepository)
        {
            this.genreRepository = genreRepository;
            this.movieGenreRepository = movieGenreRepository;
        }

        public async Task CreateGenre(GenreInputModel genreInputModel)
        {
            if (this.genreRepository.All().Any(g => g.Name == genreInputModel.Name))
            {
                throw new ArgumentException("This genre already exists!");
            }

            Genre genre = new Genre
            {
                Name = genreInputModel.Name,
            };

            await this.genreRepository.AddAsync(genre);
            await this.genreRepository.SaveChangesAsync();
        }

        public IEnumerable<SelectListItem> GetListGenres()
        {
            return this.genreRepository.All().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            });
        }

        public IEnumerable<GenreViewModel> GetAllGenres()
        {
            return this.genreRepository.All().To<GenreViewModel>().ToArray();
        }

        public IEnumerable<MovieViewModel> GetAllMoviesByGenre(int genereId)
        {
            IEnumerable<MovieViewModel> movies = this.movieGenreRepository.All().Where(x => x.Genre.Id == genereId).To<MovieViewModel>().ToArray();

            return movies;
        }
    }
}
