using Domain.Models.Entities;

namespace Domain.Contracts.Repositories;

public interface IModuleRepository
{
    Task<Module?> GetModuleByIdAsync(int moduleId, bool trackChanges = false);
    Task<IEnumerable<Module>> GetModulesAsync(int courseId, bool trackChanges = false);
}