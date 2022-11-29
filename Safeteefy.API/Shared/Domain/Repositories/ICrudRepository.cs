namespace Safeteefy.API.Shared.Domain.Repositories;

public interface ICrudRepository<TEntity, in TId>
{
    Task<IEnumerable<TEntity>> ListAsync();
    Task AddAsync(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);
    Task<TEntity?> FindByIdAsync(TId id);
}