namespace Safeteefy.API.Shared.Domain.Models;

public class BaseUrgency
{
    public virtual string Title { get; set; }
    public virtual string Summary { get; set; }
    public virtual double Latitude { get; set; }
    public virtual double Longitude { get; set; }
    public virtual DateTime ReportedAt { get; set; }
}