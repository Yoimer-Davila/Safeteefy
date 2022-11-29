using Microsoft.EntityFrameworkCore;
using Safeteefy.API.Safeteefy.Domain.Models;
using Safeteefy.API.Safeteefy.Domain.Repositories;
using Safeteefy.API.Shared.Persistence.Contexts;
using Safeteefy.API.Shared.Persistence.Repositories;

namespace Safeteefy.API.Safeteefy.Persistence.Repositories;

public class GuardianRepository : CrudRepository<Guardian, int>, IGuardianRepository 
{
    public GuardianRepository(AppDbContext context) : base(context.Guardians)
    {
    }
}