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
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired(true)
                .IsUnicode(true);

            builder.Property(x => x.ReleaseDate)
                .IsRequired(false);

            builder.Property(x => x.Rate)
                .IsRequired(false);

            builder.Property(x => x.Description)
                .IsRequired(false)
                .IsUnicode(true);

            builder.HasOne(x => x.Director)
                .WithMany(x => x.Movies)
                .HasForeignKey(x => x.DirectorId);

            builder.HasOne(x => x.Country)
                .WithMany(x => x.Movies)
                .HasForeignKey(x => x.CountryId);

            builder.HasOne(x => x.Image);
        }
    }
}
