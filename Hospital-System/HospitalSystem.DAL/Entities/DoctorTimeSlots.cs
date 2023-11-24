using System.ComponentModel.DataAnnotations.Schema;
using HospitalSystem.DAL.Entities.Base;

namespace HospitalSystem.DAL.Entities;

public class DoctorTimeSlots : BaseEntity<Guid>
{
    public DateTime StartsAt { get; set; }
    public DateTime EndsAt { get; set; }

    public Guid DoctorId { get; set; }
    public Guid PatientId { get; set; }
    
    [ForeignKey(nameof(DoctorId))]
    public Doctor Doctor { get; set; }
    [ForeignKey(nameof(PatientId))]
    public Patient Patient { get; set; }
}