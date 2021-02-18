

using MovieExplorer.Data.Common.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MovieExplorer.Data.Models
{
    public class Movie : IDeletableEntity
    {
        public Movie()
        {
            this.Genres = new HashSet<MovieGenre>();
            this.Users = new HashSet<MovieUser>();
            this.Comments = new HashSet<Comment>();
            this.MovieActors = new HashSet<MovieActor>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public int Minutes { get; set; }

        public double? Rate { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public virtual Director Director { get; set; }

        public int DirectorId { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }

        public virtual ICollection<MovieGenre> Genres { get; set; }

        public virtual ICollection<MovieUser> Users { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<MovieActor> MovieActors { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
