using HospitalSystem.Common.DTO;
using HospitalSystem.Common.Models.DTOs.Auth;
using HospitalSystem.DAL.Entities.Base;

namespace HospitalSystem.BLL.Services.Auth.Interfaces;

public interface IAuth
{
    Task<AuthSuccessDTO> LoginAsync(LoginUserDTO user);
    Task<AuthSuccessDTO> RegisterAsync(RegisterUserDTO user);

}