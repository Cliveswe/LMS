using Domain.Models.Entities;

namespace Domain.Contracts.Repositories;

public interface IModuleRepository
{
    Task<Module?> GetModuleByIdAsync(int courseId, int moduleId, bool trackChanges = false);
    Task<IEnumerable<Module>> GetAllModulesAsync(int courseId, bool trackChanges = false);
}