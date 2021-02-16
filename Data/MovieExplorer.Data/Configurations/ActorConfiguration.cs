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
    public class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.HasKey(a => a.Id);

            builder
                .Property(a => a.FirstName)
                .HasMaxLength(30)
                .IsRequired(true)
                .IsUnicode(false);

            builder
                .Property(a => a.LastName)
                .HasMaxLength(30)
                .IsRequired(true)
                .IsUnicode(false);
        }
    }
}
