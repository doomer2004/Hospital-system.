using System.ComponentModel.DataAnnotations.Schema;
using HospitalSystem.DAL.Entities;
using HospitalSystem.DAL.Entities.Base;
using Microsoft.AspNetCore.Identity;

namespace HospitalSystem.DAL;

public class Patient : BaseEntity<Guid>
{
    public Guid UserId { get; set; }
    
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }

    public List<DoctorTimeSlots> DoctorTimeSlots { get; set; }
}