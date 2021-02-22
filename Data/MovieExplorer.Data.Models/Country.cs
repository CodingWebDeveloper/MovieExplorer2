namespace MovieExplorer.Data.Models
{
    using MovieExplorer.Data.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Country : BaseDeletableModel<int>
    {
        public Country()
        {
            this.Movies = new HashSet<Movie>();
        }

        public string Name { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
