namespace Safeteefy.API.Shared.Domain.Models;

public class BaseGuardian
{
    public virtual string Username { get; set; }
    public virtual string Email { get; set; }
    public virtual string Firstname { get; set; }
    public virtual string Lastname { get; set; }
    public virtual string Gender { get; set; }
    public virtual string Address { get; set; }
}