namespace MovieExplorer.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MovieExplorer.Services.Data;
    using MovieExplorer.Web.ViewModels.Comments;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CommentController : Controller
    {
        private readonly ICommentService commentService;

        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CommentInputViewModel commentInputViewModel, int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            string userName = this.User.Identity.Name;
            commentInputViewModel.UserName = userName;
            commentInputViewModel.MovieId = id;
            await this.commentService.AddComment(commentInputViewModel);

            return this.RedirectToAction("MoviePage", "Movie", new { id });
        }
    }
}
