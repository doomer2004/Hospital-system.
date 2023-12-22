using AutoMapper;
using HospitalSystem.BLL.Services.Appointment.Interfaces;
using HospitalSystem.BLL.Services.Doctor.Interfaces;
using HospitalSystem.Common.Models.DTOs.Doctor;
using HospitalSystem.DAL;
using HospitalSystem.DAL.Entities;
using HospitalSystem.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalSystem.BLL.Services.Doctor;

public class DoctorsSpecialtyService : IDoctorsSpecialtyService
{
    private readonly IRepository<Specialty> _repository;
    private readonly IMapper _mapper;

    public DoctorsSpecialtyService(IMapper mapper, IRepository<Specialty> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<bool> CreateDoctorsSpecialtyAsync(SpecialtyDTO specialty)
    {
        try
        {
            var entity = _mapper.Map<Specialty>(specialty);
            await _repository.InsertAsync(entity);
            return true;
        }
        catch (Exception e)
        {
            throw new ArgumentException(e.Message);
        }
    }

    public async Task<bool> DeleteDoctorsSpecialtyAsync(Guid id)
    {
        var entity = await _repository.SingleOrDefaultAsync(x => x.Id == id);
        if (entity == null)
            throw new ArgumentException("Specialty not found");
        
        await _repository.DeleteAsync(entity);
        return true;
    }

    public async Task<Specialty> GetDoctorsSpecialtyByIdAsync(Guid id)
    {
        var entity = await _repository.SingleOrDefaultAsync(x => x.Id == id);
        
        if (entity == null)
            throw new ArgumentException("Specialty not found");
        
        return entity;
    }
    
    public async Task<List<Specialty>> GetDoctorsSpecialtyByDoctorAsync(DoctorDTO doctor)
    {
        var entity = await _repository
            .Include(x => x.Doctors)
            .Where(x => x.Doctors.Any(d => d.Email == doctor.Email))
            .ToListAsync();
        return entity;
    }

    public async Task<bool> UpdateDoctorsSpecialtyAsync(SpecialtyDTO specialty)
    {
        var entity = await _repository.SingleOrDefaultAsync(x => x.TypeOfSpecialty == specialty.TypeOfSpecialty);
        if (entity == null)
            throw new ArgumentException("Specialty not found");
        _mapper.Map<Specialty>(specialty);
        await _repository.UpdateAsync(entity);
        return true;
    }
}