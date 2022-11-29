using Safeteefy.API.Shared.Domain.Models;

namespace Safeteefy.API.Safeteefy.Domain.Models;

public class Urgency : BaseUrgency, IBaseEntity<int>
{
    public int Id { get; set; }
    
    //relationships
    public int GuardianId { get; set; }
    public Guardian Guardian { get; set; }
}