using Safeteefy.API.Shared.Domain.Services.Communication;

namespace Safeteefy.API.Shared.Domain.Services;

public interface ICrudService<TEntity, in TId>
{
    Task<IEnumerable<TEntity>> ListAsync();
    Task<Response<TEntity>> SaveAsync(TEntity entity);
    Task<Response<TEntity>> UpdateAsync(TId id, TEntity entity);
    Task<Response<TEntity>> DeleteAsync(TId id);
    Task<Response<TEntity>> FindByIdAsync(TId id);
}