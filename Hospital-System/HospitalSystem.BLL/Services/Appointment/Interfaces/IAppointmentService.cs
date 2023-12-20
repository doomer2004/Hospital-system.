using HospitalSystem.Common.Models.DTOs.Appointment;

namespace HospitalSystem.BLL.Services.Appointment.Interfaces;

public interface IAppointmentService
{
    Task<bool> CreateAppointmentAsync(AppointmentDTO appointment);

    Task<bool> DeleteAppointmentAsync(Guid id);

    Task<DAL.Entities.Appointment> GetAppointmentByIdAsync(Guid id);
    
    Task<bool> UpdateAppointmentAsync(AppointmentDTO appointment);
    
    Task<DAL.Entities.Appointment> GetAppointmentByUserId(Guid id);
}