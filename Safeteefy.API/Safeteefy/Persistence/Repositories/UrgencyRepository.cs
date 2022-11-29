using Microsoft.EntityFrameworkCore;
using Safeteefy.API.Safeteefy.Domain.Models;
using Safeteefy.API.Safeteefy.Domain.Repositories;
using Safeteefy.API.Shared.Persistence.Contexts;
using Safeteefy.API.Shared.Persistence.Repositories;

namespace Safeteefy.API.Safeteefy.Persistence.Repositories;

public class UrgencyRepository : CrudRepository<Urgency, int>, IUrgencyRepository
{
    public UrgencyRepository(AppDbContext context) : base(context.Urgencies)
    {
    }

    public async Task<Urgency?> GetByGuardianAndId(Guardian guardian, int id)
    {
        return await DataSet
            .Where(u => u.Guardian.Id == guardian.Id && u.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Urgency>> ListByGuardianAsync(Guardian guardian)
    {
        return await DataSet
            .Where(u => u.Guardian.Id == guardian.Id)
            .ToListAsync();
    }

    public async Task<Urgency?> FindByGuardianAndTitleAndGeolocationAsync(Guardian guardian, string title, double longitude, double latitude)
    {
        return await DataSet
            .Where(u => u.Guardian.Id == guardian.Id 
                        && u.Title == title 
                        && Math.Abs(u.Latitude - latitude) == 0.00 
                        && Math.Abs(u.Longitude - longitude) == 0.00)
            .FirstOrDefaultAsync();
    }
}