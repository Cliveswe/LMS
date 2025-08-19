namespace Domain.Contracts.Repositories;

public interface IUnitOfWork
{
    //Course repository
    ICourseRepository Courses { get; }
    Task CompleteAsync();
}