

using System;
using System.Collections;
using System.Collections.Generic;

namespace MovieExplorer.Data.Models
{
    public class Movie
    {
        public Movie()
        {
            this.Genres = new HashSet<MovieGenre>();
            this.Users = new HashSet<MovieUser>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public int Minutes { get; set; }

        public double? Rate { get; set; }

        public int ImageId { get; set; }

        public virtual Image Image { get; set; }

        public string Description { get; set; }

        public virtual Director Director { get; set; }

        public int DirectorId { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }

        public virtual ICollection<MovieGenre> Genres { get; set; }

        public virtual ICollection<MovieUser> Users { get; set; }
    }
}
