using AutoMapper;
using HospitalSystem.BLL.Services.Auth.Interfaces;
using HospitalSystem.Common.DTO;
using HospitalSystem.Common.Models.DTOs.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_System.Controllers;
[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuth _authService;
    private readonly IMapper _mapper;
    
    public AuthController(IAuth authService)
    {
        _authService = authService;
    }

    [HttpPost("sign-up")]
    public async Task<IActionResult> Register(RegisterUserDTO userDto)
    {
        return Ok(await _authService.RegisterAsync(userDto));
    }

    [HttpPost("sign-in")]
    public async Task<IActionResult> Login(LoginUserDTO userDto)
    {
        return Ok(await _authService.LoginAsync(userDto));
    }
}