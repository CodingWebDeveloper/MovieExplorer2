using System;
using System.Collections.Generic;
using System.Text;

namespace MovieExplorer.Web.ViewModels.Comments
{
    public class CommentInputViewModel
    {
        public string Text { get; set; }

        public int MovieId { get; set; }

        public string UserId { get; set; }
    }
}
