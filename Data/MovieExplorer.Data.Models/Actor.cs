using MovieExplorer.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieExplorer.Data.Models
{
    public class Actor : BaseDeletableModel<int>
    {
        public Actor()
        {
            this.ActorMovies = new HashSet<MovieActor>();
        }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<MovieActor> ActorMovies { get; set; }

    }
}
