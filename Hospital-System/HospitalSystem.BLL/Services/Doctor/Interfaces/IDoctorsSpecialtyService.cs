using HospitalSystem.Common.Models.DTOs.Doctor;
using HospitalSystem.DAL;

namespace HospitalSystem.BLL.Services.Doctor.Interfaces;

public interface IDoctorsSpecialtyService
{
    Task<bool> CreateDoctorsSpecialtyAsync(SpecialtyDTO specialty);
    
    Task<bool> DeleteDoctorsSpecialtyAsync(Guid id);
    
    Task<Specialty> GetDoctorsSpecialtyByIdAsync(Guid id);
    
    Task<List<Specialty>> GetDoctorsSpecialtyByDoctorAsync(DoctorDTO doctor);

    Task<bool> UpdateDoctorsSpecialtyAsync(SpecialtyDTO specialty);
}