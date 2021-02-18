namespace MovieExplorer.Data.Models
{
    using MovieExplorer.Data.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Country : IDeletableEntity
    {
        public Country()
        {
            this.Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Movie> Movies { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
