using HospitalSystem.BLL.Services.Doctor.Interfaces;
using HospitalSystem.Common.Constants;
using HospitalSystem.Common.Models.DTOs.Doctor;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_System.Controllers;



[ApiController]
[Route("api/doctors")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class DoctorsController : ControllerBase
{
    private readonly IDoctorsService _doctorsService;

    public DoctorsController(IDoctorsService doctorsService)
    {
        _doctorsService = doctorsService;
    }
    
    [HttpPost]
    [Authorize(Roles = ApplicationRoles.Staff)]
    public async Task<IActionResult> CreateDoctorsAsync(CreateDoctorDTO doctor)
    {
        return Ok(await _doctorsService.CreateDoctorsAsync(doctor));
    }
    
    [HttpDelete]
    [Authorize(Roles = ApplicationRoles.Staff)]
    public async Task<IActionResult> DeleteDoctorsAsync(Guid id)
    {
        return Ok(await _doctorsService.DeleteDoctorsAsync(id));
    }
    
    [HttpGet]
    [Authorize(Roles = ApplicationRoles.Staff)]
    private async Task<IActionResult> GetDoctorsByIdAsync(Guid id)
    {
        return Ok(await _doctorsService.GetDoctorsByIdAsync(id));
    }
    
    [HttpGet]
    [Authorize(Roles = ApplicationRoles.Staff)]
    private async Task<IActionResult> GetDoctorsBySpecialtyAsync(SpecialtyDTO specialty)
    {
        return Ok(await _doctorsService.GetDoctorsBySpecialtyAsync(specialty));
    }
    
    [HttpPut]
    [Authorize(Roles = ApplicationRoles.Staff)]
    private async Task<IActionResult> UpdateDoctorsAsync(DoctorDTO doctor)
    {
        return Ok(await _doctorsService.UpdateDoctorsAsync(doctor));
    }
    
}