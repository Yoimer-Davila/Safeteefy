using Safeteefy.API.Safeteefy.Domain.Mapping;
using Safeteefy.API.Safeteefy.Domain.Models;
using Safeteefy.API.Safeteefy.Domain.Repositories;
using Safeteefy.API.Safeteefy.Domain.Services;
using Safeteefy.API.Shared.Domain.Repositories;
using Safeteefy.API.Shared.Domain.Services;
using Safeteefy.API.Shared.Domain.Services.Communication;
using Safeteefy.API.Shared.Mapping;

namespace Safeteefy.API.Safeteefy.Services;

public class GuardianService : CrudService<Guardian, int>, IGuardianService
{
    
    public GuardianService(IGuardianRepository guardianRepository,
        IUnitOfWork unitOfWork) : base(guardianRepository, unitOfWork, new GuardianMap())
    {
        EntityName = "Guardian";
    }
  
}