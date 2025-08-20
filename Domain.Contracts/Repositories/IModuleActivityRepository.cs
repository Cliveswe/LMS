using Domain.Models.Entities;
using System.Linq.Expressions;

namespace Domain.Contracts.Repositories
{
    public interface IModuleActivityRepository
    {
        void Create(ModuleActivity activity);
        void Update(ModuleActivity activity);
        Task<ModuleActivity> GetAsync(int id);
        IQueryable<ModuleActivity> FindByCondition(Expression<Func<ModuleActivity, bool>> expression, bool trackChanges = false);
    }
}