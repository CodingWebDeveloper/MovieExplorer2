using System;
using System.Collections.Generic;
using System.Text;

namespace MovieExplorer.Data.Models
{
    public class Actor
    {
        public Actor()
        {
            this.ActorMovies = new HashSet<MovieActor>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<MovieActor> ActorMovies { get; set; }
    }
}
