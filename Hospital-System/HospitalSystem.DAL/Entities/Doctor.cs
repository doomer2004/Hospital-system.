using HospitalSystem.DAL.Entities;
using HospitalSystem.DAL.Entities.Base;

namespace HospitalSystem.DAL;

public class Doctor : BaseEntity<Guid>
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public List<DoctorTimeSlots> TimeSlots { get; set; }
    public List<Specialty> Specialties { get; set; }
}