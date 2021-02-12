using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace MovieExplorer.Data.Models
{
    public class MovieImage
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public string Extensions { get; set; }

        public int MovieId { get; set; }

        public Movie Movie { get; set; }

    }
}
