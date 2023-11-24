using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalSystem.DAL.Entities;

public class Appointment
{
    public string Diagnosis { get; set; }
    public string AdditionalInformation { get; set; }
    
    public Guid DoctorTimeSlotId { get; set; }
    
    [ForeignKey(nameof(DoctorTimeSlotId))]
    public DoctorTimeSlots DoctorTimeSlot { get; set; }
    
}