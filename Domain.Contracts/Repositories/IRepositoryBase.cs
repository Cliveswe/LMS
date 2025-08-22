using System.Linq.Expressions;

namespace Domain.Contracts.Repositories;
public interface IRepositoryBase<T>
{
    void Create(T entity);

    IQueryable<T> FindAll(bool trackChanges = false);
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges = false);

    void Update(T entity);
    void Delete(T entity);

}
