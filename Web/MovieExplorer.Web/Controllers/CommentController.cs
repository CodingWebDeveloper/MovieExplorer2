namespace MovieExplorer.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MovieExplorer.Data.Models;
    using MovieExplorer.Services.Data;
    using MovieExplorer.Web.ViewModels.Comments;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CommentController : Controller
    {
        private readonly ICommentService commentService;
        private readonly UserManager<ApplicationUser> userManager;

        public CommentController(ICommentService commentService, UserManager<ApplicationUser> userManager)
        {
            this.commentService = commentService;
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CommentInputViewModel commentInputViewModel, int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            ApplicationUser user = await this.userManager.GetUserAsync(this.User);
            commentInputViewModel.MovieId = id;
            commentInputViewModel.UserId = user.Id;
            await this.commentService.AddComment(commentInputViewModel);

            return this.RedirectToAction("MoviePage", "Movie", new { id });
        }
    }
}
