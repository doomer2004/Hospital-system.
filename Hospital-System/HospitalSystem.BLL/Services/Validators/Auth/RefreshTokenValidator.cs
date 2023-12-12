using FluentValidation;
using HospitalSystem.Common.Models.DTOs.Auth;

namespace HospitalSystem.BLL.Services.Validators.Auth;

public class RefreshTokenValidator : AbstractValidator<AuthSuccessDTO>
{
    public RefreshTokenValidator()
    {
        RuleFor(x => x.RefreshToken).NotEmpty();
        RuleFor(x => x.AccessToken).NotEmpty();
    }
}