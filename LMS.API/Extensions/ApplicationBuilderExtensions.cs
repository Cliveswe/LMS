using LMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LMS.API.Extensions;

public static class ApplicationBuilderExtensions
{
    public static async Task SeedDataAsync(this IApplicationBuilder builder)
    {
        using (var scope = builder.ApplicationServices.CreateScope())
        {
            // Get the service provider and the database context
            var serviceProvider = scope.ServiceProvider;
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            // Ensure the database exists and apply any pending migrations 
            // before running the seeding logic. This guarantees that the 
            // schema is up to date before checking if seed data already exists.
            await db.Database.MigrateAsync();

            if (await db.Courses.AnyAsync())
            {
                // Skip seeding if data is already present
                return;
            }

            try
            {
                var courses = SeedData.GenerateCourses(4);

                db.AddRange(courses);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not seed database: {ex.Message}");
            }
        }
    }
}
