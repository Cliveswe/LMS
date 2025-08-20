using Domain.Contracts.Repositories;
using LMS.Infrastructure.Data;

namespace LMS.Infrastructure.Repositories;
public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext context;

    private ICourseRepository courseRepository;

    public UnitOfWork(ApplicationDbContext context)
    {
        this.context = context ?? throw new ArgumentNullException(nameof(context));
    }

    //Course repository
    public ICourseRepository Courses => courseRepository ??= new CourseRepository(context);

    public async Task<int> CompleteAsync() => await context.SaveChangesAsync();
}
