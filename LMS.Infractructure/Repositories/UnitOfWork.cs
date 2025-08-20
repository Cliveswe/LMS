using Domain.Contracts.Repositories;
using LMS.Infrastructure.Data;

namespace LMS.Infrastructure.Repositories;
public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext context;
    public IModuleActivityRepository ModuleActivityRepository { get; init; }

    public UnitOfWork(ApplicationDbContext context, IModuleActivityRepository moduleActivityRepository)
    {
        this.context = context ?? throw new ArgumentNullException(nameof(context));
        ModuleActivityRepository = moduleActivityRepository ?? throw new ArgumentNullException(nameof(moduleActivityRepository));
    }

    public async Task CompleteAsync() => await context.SaveChangesAsync();
}
