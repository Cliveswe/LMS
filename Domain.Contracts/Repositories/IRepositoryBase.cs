namespace Domain.Contracts.Repositories;
public interface IRepositoryBase<T>
{
    void Create(T entity);

    IQueryable<T> FindAll(bool trackChanges = false);

    void Update(T entity);
    void Delete(T entity);

}
