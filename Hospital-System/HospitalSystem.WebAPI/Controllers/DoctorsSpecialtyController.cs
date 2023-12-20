using HospitalSystem.BLL.Services.Doctor.Interfaces;
using HospitalSystem.Common.Constants;
using HospitalSystem.Common.Models.DTOs.Doctor;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_System.Controllers;


[ApiController]
[Route("api/specialties")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class DoctorsSpecialtyController : ControllerBase
{
    private readonly IDoctorsSpecialtyService _doctorsSpecialtyService;


    public DoctorsSpecialtyController(IDoctorsSpecialtyService doctorsSpecialtyService)
    {
        _doctorsSpecialtyService = doctorsSpecialtyService;
    }

    [HttpPost]
    [Authorize(Roles = ApplicationRoles.Staff)]
    public async Task<IActionResult> CreateDoctorsSpecialtyAsync(SpecialtyDTO specialty)
    {
        return Ok(await _doctorsSpecialtyService.CreateDoctorsSpecialtyAsync(specialty));
    }

    [HttpDelete]
    [Authorize(Roles = ApplicationRoles.Staff)]
    public async Task<IActionResult> DeleteDoctorsSpecialtyAsync(Guid id)
    {
        return Ok(await _doctorsSpecialtyService.DeleteDoctorsSpecialtyAsync(id));
    }

    [HttpGet("{id}")]
    [Authorize(Roles = ApplicationRoles.Staff)]
    public async Task<IActionResult> GetDoctorsSpecialtyByIdAsync(Guid id)
    {
        return Ok(await _doctorsSpecialtyService.GetDoctorsSpecialtyByIdAsync(id));
    }

    [HttpGet("by-doctor/{doctorId}")]
    [Authorize(Roles = ApplicationRoles.Staff)]
    public async Task<IActionResult> GetDoctorsSpecialtyByDoctorAsync(DoctorDTO doctor)
    {
        return Ok(await _doctorsSpecialtyService.GetDoctorsSpecialtyByDoctorAsync(doctor));
    }

    [HttpPut]
    [Authorize(Roles = ApplicationRoles.Staff)]
    public async Task<IActionResult> UpdateDoctorsSpecialtyAsync(SpecialtyDTO specialty)
    {
        return Ok(await _doctorsSpecialtyService.UpdateDoctorsSpecialtyAsync(specialty));
    }
}