namespace MovieExplorer.Data.Models
{
    using MovieExplorer.Data.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Comment : IDeletableEntity
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
