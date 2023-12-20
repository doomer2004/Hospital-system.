using HospitalSystem.BLL.Extensions;
using HospitalSystem.Common.Constants;
using HospitalSystem.Common.DTO;
using HospitalSystem.DAL.Entities.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace HospitalSystem.BLL;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly ILogger<UserService> _logger;

    public UserService(UserManager<User> userManager, ILogger<UserService> logger)
    {
        _logger = logger;
        _userManager = userManager;
    }
    
    public async Task<bool> MakeAdminAsync(MakeAdminDTO dto)
    {
        var user = await _userManager.FindByIdAsync(dto.UserId.ToString());
        if (user is null)
            throw new ArgumentException("User with this id does not exist");

        if (await _userManager.IsInRoleAsync(user, ApplicationRoles.Staff))
            return false;

        var roleAdded = await _userManager.AddToRoleAsync(user, ApplicationRoles.Staff);
        if (roleAdded.Succeeded)
        {
            await _userManager.RemoveFromRoleAsync(user, ApplicationRoles.Patient);
            return true;
        }

        
        _logger.LogIdentityErrors(user, roleAdded);
            throw new Exception("Unable to make user admin. Please try again later");

    }
}