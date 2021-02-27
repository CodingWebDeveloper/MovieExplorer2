using MovieExplorer.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieExplorer.Services.Data
{
    public interface ICommentService
    {
        Task AddComment(string userId, int movieId, string comment);

        IEnumerable<Comment> GetAllCommentsOfMovie(int movieId);
    }
}
