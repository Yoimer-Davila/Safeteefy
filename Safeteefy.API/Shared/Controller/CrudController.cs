using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Safeteefy.API.Shared.Domain.Services;
using Safeteefy.API.Shared.Extensions;

namespace Safeteefy.API.Shared.Controller;

public class CrudController<TEntity, TId, TResource, TSaveResource, TUpdateResource> : ControllerBase
{
    private readonly ICrudService<TEntity, TId> _crudService;
    protected readonly IMapper _mapper;
    protected CrudController(ICrudService<TEntity, TId> crudService, IMapper mapper)
    {
        _crudService = crudService;
        _mapper = mapper;
    }
    protected TEntity? FromSaveResourceToEntity(TSaveResource resource)
    {
        return _mapper.Map<TSaveResource, TEntity>(resource);
    }
    protected TResource? FromEntityToResource(TEntity entity)
    {
        return _mapper.Map<TEntity, TResource>(entity);
    }

    protected TEntity? FromUpdateResourceToEntity(TUpdateResource resource)
    {
        return _mapper.Map<TUpdateResource, TEntity>(resource);
    }
    
    protected async Task<IEnumerable<TResource>> GetAllAsync()
    {
        var entities = await _crudService.ListAsync();
        var resources = _mapper.Map<IEnumerable<TEntity>, IEnumerable<TResource>>(entities);

        return resources;
    }
    protected async Task<IActionResult> GetByIdAsync(TId id)
    {
        var result = await _crudService.FindByIdAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);

        var entityResource = FromEntityToResource(result.Resource);

        return Ok(entityResource);
    }
    protected async Task<IActionResult> PostAsync([FromBody] TSaveResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var entity = FromSaveResourceToEntity(resource);

        var result = await _crudService.SaveAsync(entity!);
        if (!result.Success)
            return BadRequest(result.Message);

        var entityResource = FromEntityToResource(result.Resource);

        return Created(nameof(PostAsync), entityResource);
    }
    protected async Task<IActionResult> PutAsync(TId id, [FromBody] TUpdateResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var entity = FromUpdateResourceToEntity(resource);
        var result = await _crudService.UpdateAsync(id, entity!);

        if (!result.Success)
            return BadRequest(result.Message);

        var entityResource = FromEntityToResource(result.Resource);

        return Ok(entityResource);
    }
    protected async Task<IActionResult> DeleteAsync(TId id)
    {
        var result = await _crudService.DeleteAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);

        var entityResource = FromEntityToResource(result.Resource);

        return Ok(entityResource);
    }
    
}