using FluentValidation;
using HospitalSystem.Common.DTO;

namespace HospitalSystem.BLL.Services.Validators.Auth;

public class RegisterUserValidator : AbstractValidator<RegisterUserDTO>
{
    public RegisterUserValidator()
    {
        RuleFor(x => x.FullName).NotEmpty().MinimumLength(5).MaximumLength(50);
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(p => p.Password).NotEmpty()
            .MinimumLength(8)
            .MaximumLength(16)
            .Matches(@"[A-Z]+")
            .Matches(@"[a-z]+")
            .Matches(@"[0-9]+")
            .Matches(@"[\!\?\*\.]+");
        
    }
}