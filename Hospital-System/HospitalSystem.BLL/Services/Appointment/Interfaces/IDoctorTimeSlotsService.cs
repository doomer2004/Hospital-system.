using HospitalSystem.Common.Models.DTOs.Doctor;
using HospitalSystem.DAL.Entities;

namespace HospitalSystem.BLL.Services.Appointment.Interfaces;

public interface IDoctorTimeSlotsService
{
    Task<bool> CreateAppointmentAsync(DoctorTimeSlotsDTO doctorTimeSlots, DateTime startsAt,
        DateTime endsAt);
    
    Task<bool> DeleteAppointmentAsync(Guid id);

    Task<DoctorTimeSlot> GetAppointmentByPatientAsync(Guid patientId);
    
    Task<DoctorTimeSlot> GetAppointmentByDoctorAsync(DoctorDTO doctor);

    Task<bool> UpdateAppointmentAsync(Guid id, DateTime startsAt, DateTime endsAt);
}