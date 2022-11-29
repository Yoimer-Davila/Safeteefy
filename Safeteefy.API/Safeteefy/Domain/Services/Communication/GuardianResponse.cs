using Safeteefy.API.Safeteefy.Domain.Models;
using Safeteefy.API.Shared.Domain.Services.Communication;

namespace Safeteefy.API.Safeteefy.Domain.Services.Communication;

public class GuardianResponse : Response<Guardian>
{
    public GuardianResponse(string message) : base(message)
    {
    }

    public GuardianResponse(Guardian resource) : base(resource)
    {
    }
}