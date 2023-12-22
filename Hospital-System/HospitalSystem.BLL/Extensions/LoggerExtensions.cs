using HospitalSystem.DAL.Entities.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace HospitalSystem.BLL.Extensions;

public static class LoggerExtensions
{
    public static void LogIdentityErrors<T>(this ILogger<T> logger, User user, IdentityResult result)
    {
        if (result.Succeeded)
            return;

        var errors = string.Join("\n", result.Errors.Select(e => e.Description));
        logger.LogError("User with id {1} has following errors:\n{2}", user.Id, errors);
    }
}