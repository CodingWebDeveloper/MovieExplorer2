namespace MovieExplorer.Data.Configurations
{
    using MovieExplorer.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> appUser)
        {
            //appUser.HasKey(au => au.Id);

            //appUser
            //    .Property(au => au.FirstName)
            //    .HasMaxLength(50)
            //    .IsRequired(true)
            //    .IsUnicode(true);

            //appUser
            //   .Property(au => au.LastName)
            //   .HasMaxLength(50)
            //   .IsRequired(true)
            //   .IsUnicode(true);

            //appUser.Property(au => au.Email)
            //    .IsRequired(true)
            //    .IsUnicode(false);

            //appUser.Property(au => au.Password)
            //    .IsRequired(true)
            //    .IsUnicode(false);

            appUser
                .HasMany(e => e.Claims)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            appUser
                .HasMany(e => e.Logins)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            appUser
                .HasMany(e => e.Roles)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
