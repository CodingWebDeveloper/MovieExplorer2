namespace MovieExplorer.Data.Models
{
    using MovieExplorer.Data.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Director : BaseDeletableModel<int>
    {

        public Director()
        {
            this.Movies = new HashSet<Movie>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }

    }
}
