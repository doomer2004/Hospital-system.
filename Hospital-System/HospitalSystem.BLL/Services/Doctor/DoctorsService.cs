using AutoMapper;
using HospitalSystem.Common.Models.DTOs.Doctor;
using HospitalSystem.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalSystem.BLL.Services.Doctor;

public class DoctorsService
{
    private readonly IRepository<DAL.Doctor> _repository;
    private readonly IMapper _mapper;

    public DoctorsService(IMapper mapper, IRepository<DAL.Doctor> repository)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<bool> CreateDoctorsAsync(DoctorDTO doctor)
    {
        try
        {
            var entity = _mapper.Map<DAL.Doctor>(doctor);
            await _repository.InsertAsync(entity);
            return true;
        }
        catch (Exception e)
        {
            throw new ArgumentException(e.Message);
        }
    }

    public async Task<bool> DeleteDoctorsAsync(Guid id)
    {
        try
        {
            var entity = await _repository.SingleOrDefaultAsync(x => x.Id == id);
            await _repository.DeleteAsync(entity);
            return true;
        }
        catch (Exception e)
        {
            throw new ArgumentException(e.Message);
        }
    }

    public async Task<DAL.Doctor> GetDoctorsByIdAsync(Guid id)
    {
            var entity = await _repository.SingleOrDefaultAsync(x => x.Id == id);
            await _repository.UpdateAsync(entity);
            return entity;
    }

    public async Task<List<DAL.Doctor>> GetDoctorsBySpecialtyAsync(SpecialtyDTO specialty)
    {
        var entity = await _repository
            .Include(x => x.Specialties)
            .Where(x => x.Specialties.Any(d => d.TypeOfSpecialty == specialty.TypeOfSpecialty))
            .ToListAsync();
            return entity;
    }

    public async Task<bool> UpdateDoctorsAsync(DoctorDTO doctor)
    {
        var entity = await _repository.SingleOrDefaultAsync(x => x.FullName == doctor.FullName);
        if (entity == null)
            throw new ArgumentException("Doctor not found");
        _mapper.Map<DAL.Doctor>(doctor);
        await _repository.UpdateAsync(entity);
        return true;
    }
}