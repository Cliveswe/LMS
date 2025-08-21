using LMS.Shared.DTOs.ModuleDtos;

namespace Service.Contracts;

public interface IModuleService
{
    Task<IEnumerable<ModuleDto>> GetAllModulesAsync(int courseId);
    Task<ModuleDto> GetModuleByIdAsync(int courseId, int moduleId);
}