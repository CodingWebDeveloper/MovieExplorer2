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
    public class MovieUserConfiguration : IEntityTypeConfiguration<MovieUser>
    {
        public void Configure(EntityTypeBuilder<MovieUser> builder)
        {
            builder.HasKey(mu => new
            {
                mu.MovieId,
                mu.UserId
            });

            builder.Property(mu => mu.AddedOn)
                .IsRequired(true)
                .HasDefaultValue(DateTime.UtcNow);

            builder
                .HasOne(mu => mu.User)
                .WithMany(u => u.Movies)
                .HasForeignKey(mu => mu.UserId);

            builder
              .HasOne(mu => mu.Movie)
              .WithMany(m => m.Users)
              .HasForeignKey(mu => mu.MovieId);
        }
    }
}
