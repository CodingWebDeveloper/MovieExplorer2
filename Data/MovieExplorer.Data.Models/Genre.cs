namespace MovieExplorer.Data.Models
{
    using MovieExplorer.Data.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Genre : IDeletableEntity
    {
        public Genre()
        {
            this.Movies = new HashSet<MovieGenre>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<MovieGenre> Movies { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
