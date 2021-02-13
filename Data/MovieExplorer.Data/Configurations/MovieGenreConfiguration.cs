using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieExplorer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieExplorer.Data.Configurations
{
    public class MovieGenreConfiguration : IEntityTypeConfiguration<MovieGenre>
    {
        public void Configure(EntityTypeBuilder<MovieGenre> builder)
        {
            builder.HasKey(mg => new { mg.MovieId, mg.GenreId });

            builder.HasOne(mg => mg.Genre)
                .WithMany(g => g.Movies)
                .HasForeignKey(mg => mg.GenreId);

            builder.HasOne(mg => mg.Movie)
                .WithMany(m => m.Genres)
                .HasForeignKey(mg => mg.MovieId);
        }
    }
}
