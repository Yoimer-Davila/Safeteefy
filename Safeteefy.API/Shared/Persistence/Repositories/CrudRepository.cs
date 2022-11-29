using Safeteefy.API.Shared.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Safeteefy.API.Shared.Persistence.Repositories;

public class CrudRepository<TEntity, TId> : ICrudRepository<TEntity, TId> where TEntity : class
{
    protected readonly DbSet<TEntity> DataSet;

    protected CrudRepository(DbSet<TEntity> dataSet)
    {
        this.DataSet = dataSet;
    }

    public virtual async Task<IEnumerable<TEntity>> ListAsync()
    {
        return await DataSet
            .ToListAsync();
    }

    public async Task AddAsync(TEntity entity)
    {
        await DataSet.AddAsync(entity);
    }

    public void Update(TEntity entity)
    {
        DataSet.Update(entity);
    }

    public void Remove(TEntity entity)
    {
        DataSet.Remove(entity);
    }

    public virtual async Task<TEntity?> FindByIdAsync(TId id)
    {
        return await DataSet.FindAsync(id);
    }
}