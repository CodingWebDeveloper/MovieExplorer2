using MovieExplorer.Data.Common.Repositories;
using MovieExplorer.Data.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MovieExplorer.Web.ViewModels;
using MovieExplorer.Services.Mapping;
using MovieExplorer.Web.ViewModels.Movies;
using MovieExplorer.Web.ViewModels.Comments;

namespace MovieExplorer.Services.Data
{
    public class MovieService : IMovieService
    {
        private readonly IDeletableEntityRepository<Movie> movieRepository;
        private readonly IDeletableEntityRepository<Director> directorRepository;
        private readonly IDeletableEntityRepository<Country> countryRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;
        private readonly IDeletableEntityRepository<MovieUser> movieUserRepository;
        private readonly IDeletableEntityRepository<Comment> commentRepository;

        public MovieService(
            IDeletableEntityRepository<Movie> movieRepository,
            IDeletableEntityRepository<Director> directorRepository,
            IDeletableEntityRepository<Country> countryRepository,
            IDeletableEntityRepository<ApplicationUser> userRepository,
            IDeletableEntityRepository<MovieUser> movieUserRepository,
            IDeletableEntityRepository<Comment> commentRepository
            )
        {
            this.movieRepository = movieRepository;
            this.directorRepository = directorRepository;
            this.countryRepository = countryRepository;
            this.userRepository = userRepository;
            this.movieUserRepository = movieUserRepository;
            this.commentRepository = commentRepository;
        }

        public async Task CreateMovie(MovieInputModel movieInputModel)
        {
            if (this.movieRepository.All().Any(x => x.Title == movieInputModel.Title)) 
            {
                throw new ArgumentException("This film already exists!");
            }

            Movie movie = new Movie
            {
                Title = movieInputModel.Title,
                ReleaseDate = movieInputModel.ReleaseDate,
                Minutes = movieInputModel.Minutes,
                Rate = movieInputModel.Rate,
                ImageUrl = movieInputModel.ImageUrl,
                Trailer = movieInputModel.Trailer,
                Description = movieInputModel.Description,
            };

            Director director = this.directorRepository.All().FirstOrDefault(m => m.Id == movieInputModel.DirectorId);
            movie.Director = director;

            Country country = this.countryRepository.All().FirstOrDefault(m => m.Id == movieInputModel.CountryId);
            movie.Country = country;

            foreach (var actorId in movieInputModel.ActorsId)
            {
                MovieActor movieActor = new MovieActor { MovieId = movie.Id, ActorId = actorId };
                movie.MovieActors.Add(movieActor);
            }

            foreach (var genreId in movieInputModel.GenresId)
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

            MovieUser movieUser = this.movieUserRepository.All().FirstOrDefault(m => m.MovieId == movieId);

            this.movieUserRepository.Delete(movieUser);

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

            MovieUser movieUser = this.movieUserRepository.AllWithDeleted().FirstOrDefault(mu => mu.Movie.Id == movieId && mu.User.Id == user.Id);

            if (movieUser == null)
            {
                await this.movieUserRepository.AddAsync(new MovieUser { UserId = user.Id, MovieId = movie.Id });
            }
            else
            {
                if (movieUser.IsDeleted)
                {
                    this.movieUserRepository.Undelete(movieUser);
                }
                else
                {
                    throw new ArgumentException("You have already added this movie!");
                }
            }

            await this.movieUserRepository.SaveChangesAsync();
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

        public async Task RemoveMovieFromUserCollection(string userName, int movieId)
        {
            ApplicationUser user = this.userRepository.All().FirstOrDefault(u => u.UserName == userName);

            MovieUser movieUser = this.movieUserRepository.All().FirstOrDefault(m => m.Movie.Id == movieId && m.User.Id == user.Id);

            this.movieUserRepository.Delete(movieUser);

            await this.movieUserRepository.SaveChangesAsync();
        }

        public IEnumerable<MovieViewModel> SearchMovie(string movieName)
        {
           IEnumerable<MovieViewModel> movie = this.movieRepository.All().To<MovieViewModel>().Where(m => m.Name.ToLower().Contains(movieName.ToLower()));

           return movie;
        }
    }
}
