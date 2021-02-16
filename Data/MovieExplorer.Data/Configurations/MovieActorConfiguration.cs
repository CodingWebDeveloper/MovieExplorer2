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
    public class MovieActorConfiguration : IEntityTypeConfiguration<MovieActor>
    {
        public void Configure(EntityTypeBuilder<MovieActor> builder)
        {
            builder.HasKey(ma => new { ma.MovieId, ma.ActorId });

            builder
                .HasOne(ma => ma.Actor)
                .WithMany(a => a.ActorMovies)
                .HasForeignKey(ma => ma.ActorId);

            builder
                .HasOne(ma => ma.Movie)
                .WithMany(a => a.MovieActors)
                .HasForeignKey(ma => ma.MovieId);
        }
    }
}
