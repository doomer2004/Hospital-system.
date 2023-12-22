using HospitalSystem.DAL.Entities;
using HospitalSystem.DAL.Entities.Base;

namespace HospitalSystem.DAL;

public class Specialty : BaseEntity<Guid>
{
    public string TypeOfSpecialty { get; set; }
    public List<Doctor> Doctors { get; set; }
}