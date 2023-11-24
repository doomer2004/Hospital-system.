using HospitalSystem.DAL.Entities.Base;

namespace HospitalSystem.DAL;

public class Doctor : BaseEntity<Guid>
{
    public string FullName { get; set; }
    public string Email { get; set; }
    
    
}