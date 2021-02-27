using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieExplorer.Services.Data;
using MovieExplorer.Web.ViewModels.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieExplorer.Web.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;

        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        public IActionResult Create(int id)
        {
            return this.RedirectToAction("MoviePage", "Movie", id);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CommentInputViewModel commentInputViewModel, int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            string userName = this.User.Identity.Name;

            await this.commentService.AddComment(userName, id, commentInputViewModel.Text);

            return this.RedirectToAction("MoviePage", "Movie", id);
        }
    }
}
