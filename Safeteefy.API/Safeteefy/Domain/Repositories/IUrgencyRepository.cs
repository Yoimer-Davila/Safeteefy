using Safeteefy.API.Safeteefy.Domain.Models;
using Safeteefy.API.Shared.Domain.Repositories;

namespace Safeteefy.API.Safeteefy.Domain.Repositories;

public interface IUrgencyRepository : ICrudRepository<Urgency, int>
{
    Task<Urgency?> GetByGuardianAndId(Guardian guardian, int id);
    Task<IEnumerable<Urgency>> ListByGuardianAsync(Guardian guardian);
    
    Task<Urgency?> FindByGuardianAndTitleAndGeolocationAsync(Guardian guardian, string title, double longitude, double latitude);
}