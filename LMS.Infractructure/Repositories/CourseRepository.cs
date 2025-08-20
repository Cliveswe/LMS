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
}
