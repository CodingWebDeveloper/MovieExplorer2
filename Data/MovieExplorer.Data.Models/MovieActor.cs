﻿using MovieExplorer.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieExplorer.Data.Models
{
    public class MovieActor : BaseDeletableModel<int>
    {
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        public int ActorId { get; set; }

        public virtual Actor Actor { get; set; }
    }
}
