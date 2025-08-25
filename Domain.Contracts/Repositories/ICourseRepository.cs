using Domain.Models.Entities;

namespace Domain.Contracts.Repositories;

public interface ICourseRepository
{
    void Add(Course course);

    Task<IEnumerable<Course>> GetAllAsync(bool trackChanges = false);

    Task<Course?> FindByIDAsync(int courseId, bool trackChanges = false);

    Task<Course?> FindByNameAndStartDateAsync(string name, DateTime startDate, bool trackChanges = false);

    Task<bool> CourseExistsByNameAndStartDateAsync(string name, DateTime startDate);

    void Remove(Course course);

}