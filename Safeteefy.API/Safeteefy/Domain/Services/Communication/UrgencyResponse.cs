using Safeteefy.API.Safeteefy.Domain.Models;
using Safeteefy.API.Shared.Domain.Services.Communication;

namespace Safeteefy.API.Safeteefy.Domain.Services.Communication;

public class UrgencyResponse : Response<Urgency>
{
    public UrgencyResponse(string message) : base(message)
    {
    }

    public UrgencyResponse(Urgency resource) : base(resource)
    {
    }
}