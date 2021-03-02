﻿using MovieExplorer.Data.Common.Repositories;
using MovieExplorer.Data.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MovieExplorer.Web.ViewModels;
using MovieExplorer.Services.Mapping;
using MovieExplorer.Web.ViewModels.Movies;

namespace MovieExplorer.Services.Data
{
    public class MovieService : IMovieService
    {
        private readonly IDeletableEntityRepository<Movie> movieRepository;
        private readonly IDeletableEntityRepository<Director> directorRepository;
        private readonly IDeletableEntityRepository<Country> countryRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;
        private readonly IDeletableEntityRepository<MovieUser> movieUserRepository;


        public MovieService(
            IDeletableEntityRepository<Movie> movieRepository,
            IDeletableEntityRepository<Director> directorRepository,
            IDeletableEntityRepository<Country> countryRepository,
            IDeletableEntityRepository<ApplicationUser> userRepository,
            IDeletableEntityRepository<MovieUser> movieUserRepository
            )
        {
            this.movieRepository = movieRepository;
            this.directorRepository = directorRepository;
            this.countryRepository = countryRepository;
            this.userRepository = userRepository;
            this.movieUserRepository = movieUserRepository;
        }

        public async Task CreateMovie(string title, DateTime releaseDate, int minutes, double rate, string imageUrl, string trailer, string description, int directorId, int countryId, List<int> actorsId, List<int> genresId)
        {
            Movie movie = new Movie
            {
                Title = title,
                ReleaseDate = releaseDate,
                Minutes = minutes,
                Rate = rate,
                ImageUrl = imageUrl,
                Trailer = trailer,
                Description = description,
                Country = this.countryRepository.All().FirstOrDefault(x => x.Id == countryId),
            };

            Director director = this.directorRepository.All().FirstOrDefault(m => m.Id == directorId);
            movie.Director = director;

            Country country = this.countryRepository.All().FirstOrDefault(m => m.Id == countryId);
            movie.Country = country;

            foreach (var actorId in actorsId)
            {
                MovieActor movieActor = new MovieActor { MovieId = movie.Id, ActorId = actorId };
                movie.MovieActors.Add(movieActor);
            }

            foreach (var genreId in genresId)
            {
                MovieGenre movieGenre = new MovieGenre { MovieId = movie.Id, GenreId = genreId };
                movie.Genres.Add(movieGenre);
            }

            await this.movieRepository.AddAsync(movie);

            await this.movieRepository.SaveChangesAsync();
        }

        public async Task DeleteMovie(int movieId)
        {
            Movie movie = this.movieRepository.All().FirstOrDefault(m => m.Id == movieId);

            this.movieRepository.Delete(movie);

            await this.movieRepository.SaveChangesAsync();
        }

        public MoviePageViewModel GetMovieById(int movieId)
        {
            MoviePageViewModel movie = this.movieRepository.All().To<MoviePageViewModel>().FirstOrDefault(x => x.MovieId == movieId);

            return movie;
        }

        public async Task AddToUser(string username, int movieId)
        {
            Movie movie = this.movieRepository.All().FirstOrDefault(m => m.Id == movieId);

            ApplicationUser user = this.userRepository.All().FirstOrDefault(u => u.UserName == username);

            user.Movies.Add(new MovieUser { UserId = user.Id, MovieId = movie.Id });

            await this.userRepository.SaveChangesAsync();
        }

        public IEnumerable<MovieUserViewModel> GetAllMovies(string username)
        {
            ApplicationUser user = this.userRepository.All().FirstOrDefault(u => u.UserName == username);

            List<MovieUserViewModel> usersMovies = this.movieUserRepository
                .All()
                .To<MovieUserViewModel>()
                .Where(x => x.UserName == user.UserName)
                .ToList();

            return usersMovies;
        }

    }
}
