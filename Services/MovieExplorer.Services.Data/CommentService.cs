using MovieExplorer.Data.Common.Repositories;
using MovieExplorer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieExplorer.Services.Data
{
    public class CommentService : ICommentService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;
        private readonly IDeletableEntityRepository<Movie> movieRepository;

        public CommentService(IDeletableEntityRepository<ApplicationUser> userRepository, IDeletableEntityRepository<Movie> movieRepository)
        {
            this.userRepository = userRepository;
            this.movieRepository = movieRepository;
        }

        public async Task AddComment(string userName, int movieId, string comment)
        {
            Movie movie = this.movieRepository.All().FirstOrDefault(x => x.Id == movieId);

            ApplicationUser user = this.userRepository.All().FirstOrDefault(u => u.UserName == userName);
            movie.Comments.Add(new Comment { Text = comment, UserId = user.Id, MovieId = movieId });

            await this.movieRepository.SaveChangesAsync();
        }

        public IEnumerable<Comment> GetAllCommentsOfMovie(int movieId)
        {
            Movie movie = this.movieRepository.All().FirstOrDefault(x => x.Id == movieId);

            IEnumerable<Comment> comments = movie.Comments;
            return comments;
        }
    }
}
