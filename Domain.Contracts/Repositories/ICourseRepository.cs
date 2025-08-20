using Domain.Models.Entities;

namespace Domain.Contracts.Repositories;

public interface ICourseRepository
{
    void Add(Course course);

    Task<IEnumerable<Course>> GetAllAsync(bool trackChanges = false);
}