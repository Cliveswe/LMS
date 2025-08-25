using Domain.Contracts.Repositories;
using Domain.Models.Entities;
using LMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Repositories;
public class CourseRepository : RepositoryBase<Course>, ICourseRepository
{
    public CourseRepository(ApplicationDbContext context) : base(context)
    {

    }

    public void Add(Course course)
    {
        Create(course);
    }

    public async Task<IEnumerable<Course>> GetAllAsync(bool trackChanges = false)
    {
        return await FindAll(trackChanges)
            .OrderBy(g => g.Name)
            .ToListAsync();
    }

    public async Task<Course?> FindByIDAsync(int courseId, bool trackChanges = false)
    {
        return await FindByCondition(c => c.Id == courseId, trackChanges)
            .FirstOrDefaultAsync();
    }

    public async Task<Course?> FindByNameAndStartDateAsync(string name, DateTime startDate, bool trackChanges = false)
    {
        return await FindByCondition(c =>
            c.Name == name &&
            c.StartDate == startDate, trackChanges)
            .FirstOrDefaultAsync();
    }

    public Task<bool> CourseExistsByNameAndStartDateAsync(string name, DateTime startDate)
    {
        var startOfDay = startDate.Date;
        //Local variable used for the date range comparison. It does not require any schema change.
        var endOfDay = startOfDay.AddDays(1);

        return FindByCondition(c =>
            c.Name == name &&
            c.StartDate >= startOfDay && c.StartDate < endOfDay,
            false
        ).AnyAsync();
    }
}
