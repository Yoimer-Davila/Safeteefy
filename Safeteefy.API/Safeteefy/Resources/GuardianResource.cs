using Safeteefy.API.Shared.Domain.Models;

namespace Safeteefy.API.Safeteefy.Resources;

public class GuardianResource : BaseGuardian, IBaseEntity<int>
{
    public int Id { get; set; }
}