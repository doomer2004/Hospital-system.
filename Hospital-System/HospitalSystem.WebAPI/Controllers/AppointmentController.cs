using HospitalSystem.BLL.Services.Appointment.Interfaces;
using HospitalSystem.Common.Constants;
using HospitalSystem.Common.Models.DTOs.Appointment;
using HospitalSystem.Common.Models.DTOs.Doctor;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_System.Controllers;



[ApiController]
[Route("api/appointments")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class AppointmentController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;

    public AppointmentController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    [HttpPost]
    [Authorize(Roles = ApplicationRoles.Staff)]
    public async Task<IActionResult> CreateAppointmentAsync(AppointmentDTO appointment)
    {
        return Ok(await _appointmentService.CreateAppointmentAsync(appointment));
    }

    [HttpDelete]
    [Authorize(Roles = ApplicationRoles.Staff)]
    public async Task<IActionResult> DeleteAppointmentAsync(Guid id)
    {
        return Ok(await _appointmentService.DeleteAppointmentAsync(id));
    }

    [HttpGet("get-by-id{id}")]
    [Authorize(Roles = ApplicationRoles.Patient)]
    public async Task<IActionResult> GetAppointmentByIdAsync(Guid id)
    {
        return Ok(await _appointmentService.GetAppointmentByIdAsync(id));
    }

    [HttpPut]
    [Authorize(Roles = ApplicationRoles.Staff)]
    public async Task<IActionResult> UpdateAppointmentAsync(AppointmentDTO appointment)
    {
        return Ok(await _appointmentService.UpdateAppointmentAsync(appointment));
    }
    
    [HttpPut("get-by-user{id}")]
    public async Task<IActionResult> GetAppointmentByUserId(Guid id)
    {
        return Ok(await _appointmentService.GetAppointmentByUserId(id));
    }
    
    
}