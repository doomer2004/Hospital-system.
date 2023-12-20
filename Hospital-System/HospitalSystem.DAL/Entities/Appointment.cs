using System.ComponentModel.DataAnnotations.Schema;
using HospitalSystem.DAL.Entities.Base;

namespace HospitalSystem.DAL.Entities;

public class Appointment : BaseEntity<Guid>
{
    public string Diagnosis { get; set; }
    public string AdditionalInformation { get; set; }
    
    public Guid DoctorTimeSlotId { get; set; }
    
    [ForeignKey(nameof(DoctorTimeSlotId))]
    public DoctorTimeSlot DoctorTimeSlot { get; set; }
    
}