using Safeteefy.API.Shared.Domain.Models;

namespace Safeteefy.API.Safeteefy.Domain.Models;

public class Guardian : BaseGuardian, IBaseEntity<int>
{
    public int Id { get; set; }
}