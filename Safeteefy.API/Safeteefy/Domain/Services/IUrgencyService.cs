using Safeteefy.API.Safeteefy.Domain.Models;
using Safeteefy.API.Shared.Domain.Services;
using Safeteefy.API.Shared.Domain.Services.Communication;

namespace Safeteefy.API.Safeteefy.Domain.Services;

public interface IUrgencyService : ICrudService<Urgency, int>
{
    Task<Response<Urgency>> SaveAsync(Urgency entity, int guardianId);
    Task<Urgency?> GetByGuardianAndId(Guardian guardian, int id);
    Task<IEnumerable<Urgency>> ListByGuardianAsync(Guardian guardian);
    Task<Urgency?> FindByGuardianAndTitleAndGeolocationAsync(Guardian guardian, string title, double longitude, double latitude);
}