using Microsoft.AspNetCore.Identity;

namespace HospitalSystem.DAL.Entities.Base;

public class User : IdentityUser<Guid>
{
    public string Name { get; set; }
    public string? RefrashToken { get; set; }
    public DateTimeOffset RefrashTokenExpiresAt { get; set; }
}