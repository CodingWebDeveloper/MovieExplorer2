using MovieExplorer.Data.Common.Repositories;
using MovieExplorer.Data.Models;
using MovieExplorer.Services.Mapping;
using MovieExplorer.Web.ViewModels.Comments;
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
        private readonly IDeletableEntityRepository<Comment> commentRepository;
        private readonly IDeletableEntityRepository<Movie> movieRepository;

        public CommentService(IDeletableEntityRepository<ApplicationUser> userRepository, IDeletableEntityRepository<Comment> commentRepository,IDeletableEntityRepository<Movie> movieRepository)
        {
            this.userRepository = userRepository;
            this.commentRepository = commentRepository;
            this.movieRepository = movieRepository;
        }

        public async Task AddComment(CommentInputViewModel commentInputModel)
        {
            Movie movie = this.movieRepository.All().FirstOrDefault(x => x.Id == commentInputModel.MovieId);

            ApplicationUser user = this.userRepository.All().FirstOrDefault(u => u.UserName == commentInputModel.UserName);
            movie.Comments.Add(new Comment { Text = commentInputModel.Text, UserId = user.Id, MovieId = commentInputModel.MovieId });

            await this.movieRepository.SaveChangesAsync();
        }

        public IEnumerable<CommentViewModel> GetAllCommentsOfMovie(int movieId)
        {
            IEnumerable<CommentViewModel> comments = this.commentRepository
                .All().Where(x => x.MovieId == movieId)
                .To<CommentViewModel>().ToArray().OrderByDescending(c => c.CreatedOn);

            return comments;
        }
    }
}
