namespace Domain.Contracts.Repositories;

public interface IUnitOfWork
{
    IModuleActivityRepository ModuleActivityRepository { get; init; }
    Task CompleteAsync();
}