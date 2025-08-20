using LMS.Shared.DTOs;

namespace Service.Contracts;

public interface IModuleService
{
    Task<IEnumerable<ModuleDto>> GetAllModulesAsync(int courseId);
    Task<ModuleDto> GetModuleByIdAsync(int moduleId);
}