using Domain.Contracts.Repositories;
using LMS.Infrastructure.Data;

namespace LMS.Infrastructure.Repositories;
public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext context;

    private readonly Lazy<IModuleRepository> moduleRepository;
    public IModuleRepository ModuleRepository => moduleRepository.Value;

    public UnitOfWork(ApplicationDbContext context, Lazy<IModuleRepository> modulerepository)
    {
        this.context = context ?? throw new ArgumentNullException(nameof(context));
        moduleRepository = modulerepository ?? throw new ArgumentNullException(nameof(modulerepository));
    }

    public async Task CompleteAsync() => await context.SaveChangesAsync();
}
