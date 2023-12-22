using HospitalSystem.Common.Models.DTOs.Doctor;

namespace HospitalSystem.BLL.Services.Doctor.Interfaces;

public interface IDoctorsService
{
    Task<bool> CreateDoctorsAsync(CreateDoctorDTO doctor);
    
    Task<bool> DeleteDoctorsAsync(Guid id);
    
    Task<DAL.Entities.Doctor> GetDoctorsByIdAsync(Guid id);
    
    Task<List<DAL.Entities.Doctor>> GetDoctorsBySpecialtyAsync(SpecialtyDTO specialty);
    
    Task<bool> UpdateDoctorsAsync(DoctorDTO doctor);
}