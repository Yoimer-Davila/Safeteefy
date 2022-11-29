using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Safeteefy.API.Safeteefy.Domain.Models;
using Safeteefy.API.Safeteefy.Domain.Services;
using Safeteefy.API.Safeteefy.Resources;
using Safeteefy.API.Safeteefy.Resources.Save;
using Safeteefy.API.Shared.Controller;
using Swashbuckle.AspNetCore.Annotations;

namespace Safeteefy.API.Safeteefy.Controller;
[ApiController]
[Route("/api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Create, read, update and delete guardians")]
public class GuardiansController : CrudController<Guardian, int, GuardianResource, SaveGuardianResource, SaveGuardianResource>
{
    public GuardiansController(IGuardianService guardianService, IMapper mapper) : base(guardianService, mapper)
    {
    }
    [HttpGet]
    public new async Task<IEnumerable<GuardianResource>> GetAllAsync()
    {
        return await base.GetAllAsync();
    }

    [HttpGet("{id}")]
    public new async Task<IActionResult> GetByIdAsync(int id)
    {
        return await base.GetByIdAsync(id);
    }

    [HttpPost]
    public new async Task<IActionResult> PostAsync(SaveGuardianResource resource)
    {
        return await base.PostAsync(resource);
    }

    [HttpPut("{id}")]
    public new async Task<IActionResult> PutAsync(int id, SaveGuardianResource resource)
    {
        return await base.PutAsync(id, resource);
    }

    [HttpDelete("{id}")]
    public new async Task<IActionResult> DeleteAsync(int id)
    {
        return await base.DeleteAsync(id);
    }
}