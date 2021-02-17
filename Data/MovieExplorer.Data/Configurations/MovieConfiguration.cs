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
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Title)
                .IsRequired(true)
                .IsUnicode(true);

            builder.Property(m => m.ReleaseDate)
                .IsRequired(false);

            builder.Property(m => m.Rate)
                .IsRequired(false);

            builder.Property(m => m.ImageUrl)
                .IsRequired(true);

            builder.Property(m => m.Description)
                .IsRequired(false)
                .IsUnicode(true);

            builder.HasOne(m => m.Director)
                .WithMany(d => d.Movies)
                .HasForeignKey(m => m.DirectorId);

            builder.HasOne(m => m.Country)
                .WithMany(c => c.Movies)
                .HasForeignKey(m => m.CountryId);

            builder.HasMany(m => m.Comments)
                .WithOne(c => c.Movie)
                .HasForeignKey(c => c.MovieId);
        }
    }
}
