﻿namespace MovieExplorer.Data.Models
{
    using MovieExplorer.Data.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Comment : BaseDeletableModel<int>
    {
        public string Text { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
