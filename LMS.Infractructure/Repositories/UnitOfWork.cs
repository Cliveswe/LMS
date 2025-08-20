using Domain.Contracts.Repositories;
using LMS.Infrastructure.Data;

namespace LMS.Infrastructure.Repositories;
public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
    private readonly ApplicationDbContext context = context ?? throw new ArgumentNullException(nameof(context));

    public async Task CompleteAsync() => await context.SaveChangesAsync();
}
