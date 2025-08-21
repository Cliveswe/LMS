namespace Domain.Contracts.Repositories;

public interface IUnitOfWork
{
    //Course repository
    ICourseRepository CourseRepository { get; }
    Task<int> CompleteAsync();
}