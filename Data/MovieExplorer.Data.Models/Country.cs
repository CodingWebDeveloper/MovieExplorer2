namespace MovieExplorer.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Country
    {
        public Country()
        {
            this.Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
