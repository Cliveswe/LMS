using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Infrastructure.Data.Configurations;

public class ApplicationUserConfigurations : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.ToTable("ApplicationUser");
        //Add more configurations here
        builder.Property(u => u.FirstName)
                   .HasMaxLength(100);

        builder.Property(u => u.LastName)
               .HasMaxLength(100);

        builder.HasMany(u => u.Courses)
                   .WithMany(c => c.Users)
                   .UsingEntity(j => j.ToTable("UserCourses")); // join table name

    }
}
