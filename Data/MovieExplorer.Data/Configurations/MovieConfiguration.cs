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
                .HasMaxLength(60)
                .IsRequired(true)
                .IsUnicode(true);

            builder.Property(x => x.Rate)
                .IsRequired(false);

            builder.Property(x => x.Description)
                .IsRequired(false);

            builder.Property(x => x.ReleaseDate)
                .IsRequired(false);

            builder.HasOne(x => x.Director)
                .WithMany(x => x.Movies)
                .HasForeignKey(x => x.DirectorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Image)
                .WithOne(x => x.Movie)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
