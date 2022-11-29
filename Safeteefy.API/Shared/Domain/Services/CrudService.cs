using Safeteefy.API.Shared.Domain.Models;
using Safeteefy.API.Shared.Domain.Repositories;
using Safeteefy.API.Shared.Domain.Services.Communication;
using Safeteefy.API.Shared.Mapping;

namespace Safeteefy.API.Shared.Domain.Services;

public class CrudService<TEntity, TId> : ICrudService<TEntity, TId> where TEntity : class, IBaseEntity<TId>
{
    private readonly ICrudRepository<TEntity, TId> _crudRepository;
    private readonly IUnitOfWork _unitOfWork;
    protected string EntityName;
    protected IGenericMap<TEntity, TEntity> GenericMap { get; }

    protected CrudService(ICrudRepository<TEntity, TId> crudRepository, IUnitOfWork unitOfWork, IGenericMap<TEntity, TEntity> genericMap)
    {
        this._crudRepository = crudRepository;
        this._unitOfWork = unitOfWork;
        GenericMap = genericMap;
        this.EntityName = "Entity";
    }

    public async Task<IEnumerable<TEntity>> ListAsync()
    {
        return await this._crudRepository.ListAsync();
    }

    public virtual async Task<Response<TEntity>> SaveAsync(TEntity entity)
    {
        try
        {
            await this._crudRepository.AddAsync(entity);
            await this._unitOfWork.CompleteAsync();
            return Entity(entity);
        }
        catch (Exception e)
        {
            return this.ErrorMessage("saving", e);
        }
    }

    public virtual async Task<Response<TEntity>> UpdateAsync(TId id, TEntity entity)
    {
        var existEntity = await this._crudRepository.FindByIdAsync(id);
        if(existEntity == null)
            return Response<TEntity>.Of(this.EntityName + " Not Found");

        //For update fields
        existEntity = GenericMap.Map(entity, existEntity);
        
        try
        {
            this._crudRepository.Update(existEntity);
            await _unitOfWork.CompleteAsync();
            return Entity(existEntity);
        }
        catch (Exception e)
        {
            return this.ErrorMessage("updating", e);
        }
    }

    public virtual async Task<Response<TEntity>> DeleteAsync(TId id)
    {
        var existEntity = await this._crudRepository.FindByIdAsync(id);
        if(existEntity == null)
            return Response<TEntity>.Of(this.EntityName + " Not Found");
        try
        {
            this._crudRepository.Remove(existEntity);
            await _unitOfWork.CompleteAsync();
            return Entity(existEntity);
        }
        catch (Exception e)
        {
            return ErrorMessage("deleting", e);
        }
        
    }

    public async Task<Response<TEntity>> FindByIdAsync(TId id)
    {
        var existEntity = await _crudRepository.FindByIdAsync(id);
        if(existEntity == null)
            return Response<TEntity>.Of(this.EntityName + " Not Found");

        return Entity(existEntity);
    }

    protected Response<TEntity> ErrorMessage(string what, Exception e)
    {
        return Response<TEntity>.Of("An error occurred while " + what + " the " + this.EntityName + $": {e.Message}");
    }

    protected static Response<TEntity> Entity(TEntity entity)
    {
        return Response<TEntity>.Of(entity);
    }

}