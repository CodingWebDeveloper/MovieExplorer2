using MovieExplorer.Data.Models;
using MovieExplorer.Web.ViewModels.Comments;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieExplorer.Services.Data
{
    public interface ICommentService
    {
        Task AddComment(CommentInputViewModel commentInputModel);

        IEnumerable<CommentViewModel> GetAllCommentsOfMovie(int movieId);
    }
}
