using Microsoft.AspNetCore.Identity;

namespace HospitalSystem.DAL.Entities.Base;

public class User : IdentityUser<Guid>
{
    public string Name { get; set; }
    public string? RefreshToken { get; set; }
    public DateTimeOffset RefreshTokenExpiresAt { get; set; }
}