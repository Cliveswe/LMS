using Domain.Contracts.Repositories;
using Domain.Models.Entities;
using LMS.Infrastructure.Data;

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
}
