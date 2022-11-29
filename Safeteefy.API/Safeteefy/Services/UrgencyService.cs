using Safeteefy.API.Safeteefy.Domain.Mapping;
using Safeteefy.API.Safeteefy.Domain.Models;
using Safeteefy.API.Safeteefy.Domain.Repositories;
using Safeteefy.API.Safeteefy.Domain.Services;
using Safeteefy.API.Shared.Domain.Repositories;
using Safeteefy.API.Shared.Domain.Services;
using Safeteefy.API.Shared.Domain.Services.Communication;

namespace Safeteefy.API.Safeteefy.Services;

public class UrgencyService : CrudService<Urgency, int>, IUrgencyService
{
    private readonly IUrgencyRepository _urgencyRepository;
    public UrgencyService(IUrgencyRepository urgencyRepository,
        IUnitOfWork unitOfWork) : 
        base(urgencyRepository, unitOfWork, new UrgencyMap())
    {
        _urgencyRepository = urgencyRepository;
        EntityName = "Urgency";
    }

    public async Task<Response<Urgency>> SaveAsync(Urgency entity, int guardianId)
    {
        entity.GuardianId = guardianId;
        return await base.SaveAsync(entity);
    }

    public async Task<Urgency?> GetByGuardianAndId(Guardian guardian, int id)
    {
        return await _urgencyRepository.GetByGuardianAndId(guardian, id);
    }

    public async Task<IEnumerable<Urgency>> ListByGuardianAsync(Guardian guardian)
    {
        return await _urgencyRepository.ListByGuardianAsync(guardian);
    }

    public async Task<Urgency?> FindByGuardianAndTitleAndGeolocationAsync(Guardian guardian, string title, double longitude, double latitude)
    {
        return await _urgencyRepository.FindByGuardianAndTitleAndGeolocationAsync(guardian, title, longitude, latitude);
    }
}