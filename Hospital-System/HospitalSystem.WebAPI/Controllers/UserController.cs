using AutoMapper;
using HospitalSystem.BLL;
using HospitalSystem.Common.DTO;
using HospitalSystem.DAL.Entities.Base;
using HospitalSystem.DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_System.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpPost("make-admin")]
    public async Task<IActionResult> MakeAdminAsync(MakeAdminDTO dto)
    {
        return Ok(await _userService.MakeAdminAsync(dto));
    }
    
}