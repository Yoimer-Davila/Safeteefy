using AutoMapper;
using Safeteefy.API.Safeteefy.Domain.Models;
using Safeteefy.API.Safeteefy.Resources;
using Safeteefy.API.Safeteefy.Resources.Save;

namespace Safeteefy.API.Safeteefy.Domain.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveGuardianResource, Guardian>();
        CreateMap<SaveUrgencyResource, Urgency>();
    }
}