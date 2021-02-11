

using System.Collections;
using System.Collections.Generic;

namespace MovieExplorer.Data.Models
{
    public class Movie
    {
        public Movie()
        {
            this.Genres = new HashSet<MovieGenre>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public int Minutes { get; set; }

        public double Rate { get; set; }

        public int ImageId { get; set; }

        public virtual MovieImage MovieImage { get; set; }

        public virtual Director Director { get; set; }

        public int DirectorId { get; set; }

        public virtual ICollection<MovieGenre> Genres { get; set; }
    }
}
