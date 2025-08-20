using Domain.Models.Entities;

namespace Domain.Contracts.Repositories
{
    public interface IModuleActivityRepository
    {
        void Create(ModuleActivity activity);
        void Update(ModuleActivity activity);

        Task<ModuleActivity> GetAsync(int id);
    }
}