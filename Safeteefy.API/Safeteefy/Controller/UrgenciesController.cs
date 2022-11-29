using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Safeteefy.API.Safeteefy.Domain.Models;
using Safeteefy.API.Safeteefy.Domain.Services;
using Safeteefy.API.Safeteefy.Resources;
using Safeteefy.API.Safeteefy.Resources.Save;
using Safeteefy.API.Shared.Controller;
using Safeteefy.API.Shared.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace Safeteefy.API.Safeteefy.Controller;
[ApiController]
[Route("/api/guardians/{guardianId}/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Create, read, update and delete urgencies")]
public class UrgenciesController : CrudController<Urgency, int, UrgencyResource, SaveUrgencyResource, SaveUrgencyResource>
{
    private readonly IGuardianService _guardianService;
    private readonly IUrgencyService _urgencyService;
    public UrgenciesController(IUrgencyService urgencyService, 
        IGuardianService guardianService, IMapper mapper) : base(urgencyService, mapper)
    {
        _urgencyService = urgencyService;
        _guardianService = guardianService;
    }

    
    
    [HttpGet]
    public async Task<IEnumerable<UrgencyResource>> FindAllAsync(int guardianId)
    {
        var response = await _guardianService.FindByIdAsync(guardianId);
        if (!response.Success)
            return new List<UrgencyResource>();
        var entities = await _urgencyService.ListByGuardianAsync(response.Resource);
        var resources = _mapper.Map<IEnumerable<Urgency>, IEnumerable<UrgencyResource>>(entities);

        return resources;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int guardianId, int id)
    {
        var response = await _guardianService.FindByIdAsync(guardianId);
        if (!response.Success)
            return BadRequest("Guardian not Found");

        var entity = await _urgencyService.GetByGuardianAndId(response.Resource, id);
        if (entity == null)
            return NotFound("Urgency not found");

        var resource = _mapper.Map<Urgency, UrgencyResource>(entity);
        
        return Ok(resource);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(int guardianId, SaveUrgencyResource resource)
    {
        var response = await _guardianService.FindByIdAsync(guardianId);
        if (!response.Success)
            return BadRequest("Guardian not Found");
        
        var urgencyExist = await _urgencyService.FindByGuardianAndTitleAndGeolocationAsync(response.Resource,
            resource.Title, resource.Longitude, resource.Longitude);
        if (urgencyExist != null)
            return BadRequest("The urgency with this information already exist");
        
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var entity = FromSaveResourceToEntity(resource);

        var result = await _urgencyService.SaveAsync(entity!, guardianId);
        if (!result.Success)
            return BadRequest(result.Message);

        var entityResource = FromEntityToResource(result.Resource);

        return Created(nameof(PostAsync), entityResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int guardianId, int id, SaveUrgencyResource resource)
    {
        var response = await _guardianService.FindByIdAsync(guardianId);
        if (!response.Success)
            return BadRequest("Guardian not Found");

        var urgencyExist = await _urgencyService.FindByGuardianAndTitleAndGeolocationAsync(response.Resource,
            resource.Title, resource.Longitude, resource.Longitude);
        if (urgencyExist != null)
            return BadRequest("The urgency with this information already exist");
        
        return await base.PutAsync(id, resource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int guardianId, int id)
    {
        var response = await _guardianService.FindByIdAsync(guardianId);
        if (!response.Success)
            return BadRequest("Guardian not Found");
        return await base.DeleteAsync(id);
    }
}