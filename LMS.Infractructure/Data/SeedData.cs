using Bogus;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infrastructure.Data;

public class SeedData
{
    public static List<Course> GenerateCourses(int numCourses)
    {
        // Create new faker instance with a fixed seed for reproducibility
        var faker = new Faker("en") { Random = new Randomizer(12345) };

        var generatedCourses = new List<Course>();

        var subjects = new List<string>
        {
            ".NET", "C#", "JavaScript", "TypeScript", "Python",
            "Java", "Azure", "AWS", "DevOps", "Microservices",
            "AI", "MachineLearning", "CyberSecurity", "CloudComputing",
            "Blockchain"
        };

        for (int i = 0; i < numCourses; i++)
        {
            if (subjects.Count == 0) break;

            // Set the start date to today and allow courses to start within the next 4 months
            var startDate = faker.Date.Between(DateTime.Today, DateTime.Today.AddMonths(4));

            // Select a random subject and remove it from the list
            var courseName = faker.PickRandom(subjects);
            subjects.Remove(courseName);


            var course = new Course
            {
                Name = $"{courseName} 2025",
                Description = faker.Lorem.Paragraph(faker.Random.Int(3, 5)),
                StartDate = startDate,
                Modules = GenerateModules(courseName, startDate, faker.Random.Int(5, 10), faker)
            };

            generatedCourses.Add(course);
        }

        return generatedCourses;
    }

    private static List<Module> GenerateModules(string courseName, DateTime courseStartDate, int numModules, Faker faker)
    {
        var generatedModules = new List<Module>();

        // Ensure the module start is after the course start date
        DateTime nextModuleStart = courseStartDate;

        var moduleSuffixes = new List<string>
        {
            "Fundamentals", "Essentials", "Toolkit", "Techniques", "Patterns",
            "Concepts", "Insights", "Principles", "Methods", "Strategies",
            "Practices", "Applications", "Frameworks", "Solutions", "Approach"
        };

        for (int i = 0; i < numModules; i++)
        {
            if (moduleSuffixes.Count == 0) break;

            // Select a random suffix and remove it from the list
            var suffix = faker.PickRandom(moduleSuffixes);
            moduleSuffixes.Remove(suffix);

            // Generate random duration for module (in days)
            int moduleDurationDays = faker.Random.Int(10, 14);

            var moduleName = $"{courseName} {suffix}";

            var module = new Module
            {
                Name = moduleName,
                Description = faker.Lorem.Paragraph(faker.Random.Int(2, 3)),
                StartDate = nextModuleStart,
                EndDate = nextModuleStart.AddDays(moduleDurationDays),
                Activities = GenerateActivities(moduleName, nextModuleStart, nextModuleStart.AddDays(moduleDurationDays), faker)
            };

            generatedModules.Add(module);

            // Add 1 day to the end date of the current module to set the start date for the next module
            nextModuleStart = module.EndDate.AddDays(1);
        }

        return generatedModules;
    }

    private static List<ModuleActivity> GenerateActivities(string moduleName, DateTime moduleStart, DateTime moduleEnd, Faker faker)
    {
        var generatedActivities = new List<ModuleActivity>();
        var existingActivityNames = new HashSet<string>();

        var activityTypes = new[] { "Lecture", "Assignment", "Quiz", "E-learning" };

        // List of all weekdays in module period
        var availableDates = Enumerable.Range(0, (moduleEnd - moduleStart).Days + 1)
                                       .Select(d => moduleStart.AddDays(d))
                                       .Where(d => d.DayOfWeek != DayOfWeek.Saturday && d.DayOfWeek != DayOfWeek.Sunday)
                                       .ToList();

        var numActivities = faker.Random.Int(5, Math.Min(8, availableDates.Count));

        for (int i = 0; i < numActivities; i++)
        {
            var type = faker.PickRandom(activityTypes);
            var baseName = $"{moduleName} - {type}";
            var uniqueName = MakeUniqueName(existingActivityNames.ToList(), baseName);

            // Pick random available date and remove it from list
            var activityDate = faker.PickRandom(availableDates);
            availableDates.Remove(activityDate);

            var activity = new ModuleActivity
            {
                Name = uniqueName,
                Type = type,
                Description = faker.Lorem.Paragraph(faker.Random.Int(1, 2)),
                StartDate = activityDate,
                EndDate = activityDate
            };

            existingActivityNames.Add(uniqueName);
            generatedActivities.Add(activity);
        }

        return generatedActivities;
    }




    private static string MakeUniqueName(List<string> existingNames, string baseName)
    {
        var uniqueName = baseName;
        var counter = 2;

        while (existingNames.Contains(uniqueName))
        {
            uniqueName = $"{baseName} {counter}";
            counter++;
        }

        return uniqueName;
    }
}
