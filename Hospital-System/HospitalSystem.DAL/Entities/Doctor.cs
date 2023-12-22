using System.ComponentModel.DataAnnotations;
using HospitalSystem.DAL.Entities.Base;

namespace HospitalSystem.DAL.Entities;

public class Doctor : BaseEntity<Guid>
{
    public string FullName { get; set; }
    public string Email { get; set; }
    [Required]
    public TimeOnly StartTime { get; set; }  
    [Required]
    public TimeOnly EndTime { get; set; }
    public List<DoctorTimeSlot> TimeSlots { get; set; }
    public List<Specialty> Specialties { get; set; }
}