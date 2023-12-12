using AutoMapper;
using FluentValidation;
using HospitalSystem.BLL.Extensions;
using HospitalSystem.BLL.Services.Auth.Base;
using HospitalSystem.Common.Constants;
using HospitalSystem.Common.DTO;
using HospitalSystem.Common.Models.Configs;
using HospitalSystem.Common.Models.DTOs.Auth;
using HospitalSystem.DAL.Entities.Base;
using Microsoft.AspNetCore.Identity;

namespace HospitalSystem.BLL.Services.Auth;

public class SignUp : AuthBase<RegisterUserDTO>
{
    private readonly IMapper _mapper;
    protected SignUp(JwtConfig jwtConfig, UserManager<User> userManager, IValidator<RegisterUserDTO> validator) : base(jwtConfig, userManager, validator)
    {
    }
    
    public async Task<AuthSuccessDTO> RegisterAsync(RegisterUserDTO user)
    {
        var userEntity = await _userManager.FindByEmailAsync(user.Email);
        if (userEntity != null)
            throw new Exception("User with this email already exists");
        
        userEntity = _mapper.Map<User>(user);
        var createdUser = await _userManager.CreateAsync(userEntity, user.Password);
        if (!createdUser.Succeeded)
            throw new Exception("Failed to create user");

        var roleAdded = await _userManager.SetUserRoleAsync(userEntity, ApplicationRoles.Patient);
        if (!roleAdded.Succeeded)
            throw new Exception("Failed to create user");
        
        return await GenerateAuthSuccessDTO(userEntity);
    }
}