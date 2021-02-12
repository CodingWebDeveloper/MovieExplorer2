using System;
using System.Collections.Generic;
using System.Text;

namespace MovieExplorer.Data.Models
{
    public class MovieUser
    {
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; } 

        public int UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
