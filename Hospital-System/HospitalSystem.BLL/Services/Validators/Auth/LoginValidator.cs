using FluentValidation;
using HospitalSystem.Common.DTO;

namespace HospitalSystem.BLL.Services.Validators.Auth;

public class LoginValidator: AbstractValidator<LoginUserDTO>
{
    public LoginValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
        RuleFor(x => x.Password).NotEmpty();
    }
}