using AutoMapper;
using FluentValidation;
using HospitalSystem.BLL.Services.Auth.Base;
using HospitalSystem.Common.DTO;
using HospitalSystem.Common.Models.Configs;
using HospitalSystem.Common.Models.DTOs.Auth;
using HospitalSystem.DAL.Entities.Base;
using Microsoft.AspNetCore.Identity;

namespace HospitalSystem.BLL.Services.Auth;

public class SignIn : AuthBase<LoginUserDTO>
{
    protected SignIn(JwtConfig jwtConfig, UserManager<User> userManager, IValidator<LoginUserDTO> validator) : base(jwtConfig, userManager, validator)
    {
    }
    
    public async Task<AuthSuccessDTO> LoginAsync(LoginUserDTO user)
    {
        var userEntity = await _userManager.FindByEmailAsync(user.Email);
        if (userEntity == null)
            throw new Exception("User with this email does not exist");
        
        var result = await _userManager.CheckPasswordAsync(userEntity, user.Password);
        if (!result)
            throw new Exception("Wrong password");
        
        return await GenerateAuthSuccessDTO(userEntity);
    }
}