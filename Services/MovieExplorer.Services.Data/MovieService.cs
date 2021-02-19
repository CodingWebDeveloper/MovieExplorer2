using MovieExplorer.Data.Common.Repositories;
using MovieExplorer.Data.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieExplorer.Services.Data
{
    public class MovieService : IMovieService
    {
        private readonly IDeletableEntityRepository<Movie> movieRepository;
        private readonly IDeletableEntityRepository<Director> directorRepository;
        private readonly IDeletableEntityRepository<Country> countryRepository;

        public MovieService(IDeletableEntityRepository<Movie> movieRepository, IDeletableEntityRepository<Director> directorRepository, IDeletableEntityRepository<Country> countryRepository)
        {
            this.movieRepository = movieRepository;
            this.directorRepository = directorRepository;
            this.countryRepository = countryRepository;
        }

        public async Task CreateMovie(string title, DateTime releaseDate, int minutes, double rate, string imageUrl, string description, int directorId, int countryId)
        {
            Movie movie = new Movie
            {
                Title = title,
                ReleaseDate = releaseDate,
                Minutes = minutes,
                Rate = rate,
                ImageUrl = imageUrl,
                Description = description,
            };

            Director director = this.directorRepository.All().FirstOrDefault(m => m.Id == directorId);
            movie.Director = director;

            Country country = this.countryRepository.All().FirstOrDefault(m => m.Id == countryId);
            movie.Country = country;

            await this.movieRepository.AddAsync(movie);

            await this.movieRepository.SaveChangesAsync();
        }

    }
}
