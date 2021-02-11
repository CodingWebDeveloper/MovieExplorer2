using System;
using System.Collections.Generic;
using System.Text;

namespace MovieExplorer.Data.Models
{
    public class Genre
    {
        public Genre()
        {
            this.Movies = new HashSet<MovieGenre>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<MovieGenre> Movies { get; set; }
    }
}
