using Domain.Models.Entities;
using LMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts.Repositories;


namespace LMS.Infrastructure.Repositories
{
    public class ModuleActivityRepository : RepositoryBase<ModuleActivity>, IModuleActivityRepository
    {
        public ModuleActivityRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<ModuleActivity> GetAsync(int id)
        {
            return await DbSet.FirstOrDefaultAsync(m => m.Id == id);
        }

    }
}
