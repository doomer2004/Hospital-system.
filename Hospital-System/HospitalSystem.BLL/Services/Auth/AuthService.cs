using AutoMapper;
using FluentValidation;
using HospitalSystem.BLL.Extensions;
using HospitalSystem.BLL.Services.Auth.Base;
using HospitalSystem.BLL.Services.Auth.Interfaces;
using HospitalSystem.Common.Constants;
using HospitalSystem.Common.DTO;
using HospitalSystem.Common.Models.Configs;
using HospitalSystem.Common.Models.DTOs.Auth;
using HospitalSystem.DAL;
using HospitalSystem.DAL.Entities.Base;
using HospitalSystem.DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace HospitalSystem.BLL.Services.Auth
{
    public class AuthService : AuthBase<LoginUserDTO>, IAuth
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Patient> _repository;

        public AuthService(
            JwtConfig jwtConfig,
            UserManager<User> userManager, IMapper mapper, IRepository<Patient> repository)
            : base(jwtConfig, userManager)
        {
            _mapper = mapper;
            _repository = repository;
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


            await _repository.InsertAsync(new Patient
            {
                UserId = userEntity.Id
            });
            return await GenerateAuthSuccessDTO(userEntity);
        }

        
        
    }
}
