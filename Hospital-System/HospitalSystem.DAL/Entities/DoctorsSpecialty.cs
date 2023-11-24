using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalSystem.DAL.Entities;

public class DoctorsSpecialty
{
    public Guid DoctorId { get; set; }
    public Guid SpecialtyId { get; set; }
    
    [ForeignKey(nameof(DoctorId))]
    public Doctor Doctor { get; set; }
    [ForeignKey(nameof(SpecialtyId))]
    public Specialty Specialty { get; set; }
}