using HospitalSystem.DAL.Entities.Base;

namespace HospitalSystem.DAL;

public class Doctor : User
{
    public string FullName { get; set; }
    public string Email { get; set; }
    
    
}