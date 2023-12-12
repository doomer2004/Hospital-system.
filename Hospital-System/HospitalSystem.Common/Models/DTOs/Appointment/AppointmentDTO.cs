namespace HospitalSystem.Common.Models.DTOs.Appointment;

public class AppointmentDTO
{
    public string Diagnosis { get; set; } = string.Empty;
    public string AdditionalInformation { get; set; } = string.Empty;
    public string DoctorName { get; set; } = string.Empty;
    public string PatientName { get; set; } = string.Empty;
    public DateTime StartTime { get; set; } 
    public DateTime EndTime { get; set; } 
}