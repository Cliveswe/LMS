using Domain.Contracts.Repositories;
using Domain.Models.Entities;
using LMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Repositories;
public class UserRepository(ApplicationDbContext context) : IUserRepository
{
    public async Task<ApplicationUser> GetByIdAsync(string id) => await Task.FromResult<ApplicationUser>(await context.Users.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync());
    public async Task PostAsync(ApplicationUser user) => await context.Users.AddAsync(user);
}
