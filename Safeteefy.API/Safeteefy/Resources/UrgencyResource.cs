using Safeteefy.API.Shared.Domain.Models;

namespace Safeteefy.API.Safeteefy.Resources;

public class UrgencyResource : BaseUrgency, IBaseEntity<int>
{
    public int Id { get; set; }
    
    public GuardianResource Guardian { get; set; }
    
}