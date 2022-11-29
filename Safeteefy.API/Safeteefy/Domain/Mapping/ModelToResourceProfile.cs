using AutoMapper;
using Safeteefy.API.Safeteefy.Domain.Models;
using Safeteefy.API.Safeteefy.Resources;

namespace Safeteefy.API.Safeteefy.Domain.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Urgency, UrgencyResource>();
        CreateMap<Guardian, GuardianResource>();
    }
}