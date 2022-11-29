using System.ComponentModel.DataAnnotations;

namespace Safeteefy.API.Safeteefy.Resources.Save;

public class SaveUrgencyResource
{
    [Required]
    public string Title { get; set; }
    public string Summary { get; set; }
    [Required]
    public double Latitude { get; set; }
    [Required]
    public double Longitude { get; set; }
    public DateTime ReportedAt { get; set; }
}