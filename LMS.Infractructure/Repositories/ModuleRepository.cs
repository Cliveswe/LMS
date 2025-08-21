using Domain.Contracts.Repositories;
using Domain.Models.Entities;
using LMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infrastructure.Repositories;

public class ModuleRepository : RepositoryBase<Module>, IModuleRepository
{
    public ModuleRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Module>> GetAllModulesAsync(int courseId, bool trackChanges = false)
    {
        return await FindByCondition(m => m.CourseId.Equals(courseId), trackChanges).ToListAsync();
    }

    public async Task<Module?> GetModuleByIdAsync(int courseId, int moduleId, bool trackChanges = false)
    {
        return await FindByCondition(m => m.CourseId.Equals(courseId) && m.Id.Equals(moduleId), trackChanges).FirstOrDefaultAsync();
    }
}
