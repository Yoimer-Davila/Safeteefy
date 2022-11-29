using Safeteefy.API.Safeteefy.Domain.Models;
using Safeteefy.API.Shared.Mapping;

namespace Safeteefy.API.Safeteefy.Domain.Mapping;

public class UrgencyMap : IGenericMap<Urgency, Urgency>
{
    public Urgency Map(Urgency from, Urgency to)
    {
        to.Latitude = from.Latitude;
        to.Longitude = from.Longitude;
        to.Title = from.Title;
        to.Summary = from.Summary;
        return to;
    }
}