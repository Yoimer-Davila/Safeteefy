using System.ComponentModel.DataAnnotations;

namespace Safeteefy.API.Safeteefy.Resources.Save;

public class SaveGuardianResource
{
    [Required]
    [MaxLength(30)]
    public string Username { get; set; }
    [Required]
    [MaxLength(30)]
    public string Email { get; set; }
    [Required]
    [MaxLength(60)]
    public string Firstname { get; set; }
    [Required]
    [MaxLength(60)]
    public string Lastname { get; set; }
    [Required]
    public string Gender { get; set; }
    public string Address { get; set; }
}