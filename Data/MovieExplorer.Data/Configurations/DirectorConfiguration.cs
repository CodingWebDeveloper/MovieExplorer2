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
    public class DirectorConfiguration : IEntityTypeConfiguration<Director>
    {
        public void Configure(EntityTypeBuilder<Director> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.FirstName)
                .HasMaxLength(50)
                .IsRequired(true)
                .IsUnicode(true);

            builder.Property(d => d.LastName)
               .HasMaxLength(50)
               .IsRequired(true)
               .IsUnicode(true);

            builder
                .HasMany(m => m.Movies)
                .WithOne(d => d.Director)
                .HasForeignKey(d => d.DirectorId);
        }
    }
}
