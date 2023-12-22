namespace HospitalSystem.Common.Models.DTOs.Doctor;

public class DoctorDTO
{
    public string FullName { get; set; }
    public string Email { get; set; }
    
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    
    public SpecialtyDTO Specialty { get; set; }
}

public class CreateDoctorDTO
{
    public string FullName { get; set; }
    public string Email { get; set; }
    
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    
    public List<Guid> SpecialtyIds { get; set; }
}

