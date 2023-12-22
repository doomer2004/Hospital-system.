using HospitalSystem.DAL.Entities.Base;
using Microsoft.AspNetCore.Identity;

namespace HospitalSystem.BLL.Extensions;

public static class UserManagerExtensions
{
    public static async Task<IdentityResult> SetUserRoleAsync(this UserManager<User> userManager, User user, string role)
    {
        var roles = await userManager.GetRolesAsync(user);
        if (roles.Contains(role))
            return IdentityResult.Success;
        var removeResult = await userManager.RemoveFromRolesAsync(user, roles);
        if (!removeResult.Succeeded)
            return removeResult;
        
        return await userManager.AddToRoleAsync(user, role);
    }

    public static async Task<string> GetRoleAsync(this UserManager<User> userManager, User user)
    {
        var roles = await userManager.GetRolesAsync(user);
        if (roles.Count == 1)
            return roles.First();
        
        throw new Exception("User has more than one role");
    }
}