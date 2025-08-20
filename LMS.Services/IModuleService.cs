using LMS.Shared.DTOs;

namespace LMS.Services;

public interface IModuleService
{
    Task<IEnumerable<ModuleDto>> GetAllModulesAsync(int courseId);
    Task<ModuleDto> GetModuleByIdAsync(int moduleId);
}