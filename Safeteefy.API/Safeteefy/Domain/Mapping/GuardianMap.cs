using Safeteefy.API.Safeteefy.Domain.Models;
using Safeteefy.API.Shared.Mapping;

namespace Safeteefy.API.Safeteefy.Domain.Mapping;

public class GuardianMap : IGenericMap<Guardian, Guardian>
{
    public Guardian Map(Guardian from, Guardian to)
    {
        to.Address = from.Address;
        to.Email = from.Email;
        to.Firstname = from.Firstname;
        to.Lastname = from.Lastname;
        to.Username = from.Username;
        return to;
    }
}