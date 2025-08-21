namespace Domain.Contracts.Repositories;

public interface IUnitOfWork
{
    IModuleRepository Modules { get; }
    Task CompleteAsync();
}