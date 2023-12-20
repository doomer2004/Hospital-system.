using AutoMapper;
using HospitalSystem.BLL.Services.Appointment.Interfaces;
using HospitalSystem.Common.Models.DTOs.Appointment;
using HospitalSystem.Common.Models.DTOs.Doctor;
using HospitalSystem.DAL.Entities;
using HospitalSystem.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;

namespace HospitalSystem.BLL.Services.Appointment;

public class DoctorTimeSlotsService : IDoctorTimeSlotsService
{
    private readonly IMapper _mapper;
    private readonly IRepository<DoctorTimeSlot> _repository;

    public DoctorTimeSlotsService(IMapper mapper, IRepository<DoctorTimeSlot> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<bool> CreateAppointmentAsync(DoctorTimeSlotsDTO doctorTimeSlots, DateTime startsAt,
        DateTime endsAt)
    {
        var isTimeSlotAvailable = await _repository.AnyAsync(x => x.StartsAt == startsAt && x.EndsAt == endsAt);

        if (isTimeSlotAvailable)
            throw new ArgumentException("Time slot is not available");

        var entity = _mapper.Map<DoctorTimeSlot>(doctorTimeSlots,
            ops => ops.AfterMap((_, dest) =>
            {
                dest.StartsAt = startsAt;
                dest.EndsAt = endsAt;
            }));
        await _repository.InsertAsync(entity);

        return true;
    }

    public async Task<bool> DeleteAppointmentAsync(Guid id)
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

    public async Task<DoctorTimeSlot> GetAppointmentByPatientAsync(Guid patientId)
    {
        var entity = await _repository
            .SingleOrDefaultAsync(x => x.PatientId == patientId);
        return entity;
    }

    public async Task<DoctorTimeSlot> GetAppointmentByDoctorAsync(DoctorDTO doctor)
    {
        var entity = await _repository
            .Include(x => x.Doctor)
            .SingleOrDefaultAsync(x => x.Doctor.Email == doctor.Email);
        return entity;
    }

    public async Task<bool> UpdateAppointmentAsync(Guid id, DateTime startsAt, DateTime endsAt)
    {
        var entity = await _repository.SingleOrDefaultAsync(x => x.Id == id);
        if (entity == null)
            throw new Exception("Appointment not found");

        _mapper.Map<DoctorTimeSlot>(entity, ops => ops.AfterMap((_, dest) =>
        {
            dest.StartsAt = startsAt;
            dest.EndsAt = endsAt;
        }));
        
        await _repository.UpdateAsync(entity);
        return true;
    }
}
    
    