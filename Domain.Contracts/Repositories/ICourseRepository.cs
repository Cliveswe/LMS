using Domain.Models.Entities;

namespace Domain.Contracts.Repositories;

public interface ICourseRepository
{
    void Add(Course course);

    Task<IEnumerable<Course>> GetAllAsync(bool trackChanges = false);

    Task<Course?> FindByID(int courseId, bool trackChanges = false);

    Task<bool> CourseExistsByNameAndStartDateAsync(string name, DateTime startDate);
}