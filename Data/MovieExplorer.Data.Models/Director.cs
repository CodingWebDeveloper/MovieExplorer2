namespace MovieExplorer.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Director
    {

        public Director()
        {
            this.Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
