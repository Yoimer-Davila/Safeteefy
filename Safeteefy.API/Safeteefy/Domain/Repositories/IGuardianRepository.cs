using Safeteefy.API.Safeteefy.Domain.Models;
using Safeteefy.API.Shared.Domain.Repositories;

namespace Safeteefy.API.Safeteefy.Domain.Repositories;

public interface IGuardianRepository : ICrudRepository<Guardian, int>
{
    
}