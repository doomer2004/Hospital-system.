namespace HospitalSystem.Common.Models.DTOs.Appointment;

public class AppointmentDTO
{
    public string Diagnosis { get; set; } = string.Empty;
    public string AdditionalInformation { get; set; } = string.Empty;
    public Guid DoctorTimeSlotId { get; set; }
}