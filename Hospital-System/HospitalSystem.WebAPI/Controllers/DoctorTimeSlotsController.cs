using HospitalSystem.BLL.Services.Appointment.Interfaces;
using HospitalSystem.Common.Constants;
using HospitalSystem.Common.Models.DTOs.Doctor;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_System.Controllers;



[ApiController]
[Route("api/time-slots")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class DoctorTimeSlotsController : ControllerBase
{
    private readonly IDoctorTimeSlotsService _doctorTimeSlotsService;

    public DoctorTimeSlotsController(IDoctorTimeSlotsService doctorTimeSlotsService)
    {
        _doctorTimeSlotsService = doctorTimeSlotsService;
    }

    [HttpPost]
    [Authorize(Roles = ApplicationRoles.Patient)]
    public async Task<IActionResult> CreateDoctorTimeSlotsAsync(DoctorTimeSlotsDTO doctorTimeSlots, DateTime startsAt, DateTime endsAt)
    {
        return Ok(await _doctorTimeSlotsService.CreateAppointmentAsync(doctorTimeSlots, startsAt, endsAt));
    }

    [HttpDelete]
    [Authorize(Roles = ApplicationRoles.Patient)]
    public async Task<IActionResult> DeleteDoctorTimeSlotsAsync(Guid id)
    {
        return Ok(await _doctorTimeSlotsService.DeleteAppointmentAsync(id));
    }

    [HttpPut]
    [Authorize(Roles = ApplicationRoles.Patient)]
    public async Task<IActionResult> UpdateDoctorTimeSlotsAsync(Guid id, DateTime startsAt, DateTime endsAt)
    {
        return Ok(await _doctorTimeSlotsService.UpdateAppointmentAsync(id, startsAt, endsAt));
    }
}