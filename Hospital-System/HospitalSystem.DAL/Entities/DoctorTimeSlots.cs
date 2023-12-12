using System.ComponentModel.DataAnnotations.Schema;
using HospitalSystem.DAL.Entities.Base;

namespace HospitalSystem.DAL.Entities;

public class DoctorTimeSlots : BaseEntity<Guid>
{
    public DateTime StartsAt { get; set; }
    public DateTime EndsAt { get; set; }
    public List<Patient>? Patients { get; set; } 
    public List<Doctor>? Doctors { get; set; }
}