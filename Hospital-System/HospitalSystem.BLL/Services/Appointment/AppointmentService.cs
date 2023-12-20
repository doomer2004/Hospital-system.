using AutoMapper;
using HospitalSystem.BLL.Services.Appointment.Interfaces;
using HospitalSystem.Common.Models.DTOs.Appointment;
using HospitalSystem.DAL;
using HospitalSystem.DAL.Entities;
using HospitalSystem.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalSystem.BLL.Services.Appointment;

public class AppointmentService : IAppointmentService
{
    private readonly IRepository<DAL.Entities.Appointment> _repositoryAppointment;
    private readonly IRepository<DoctorTimeSlot> _repositoryDoctorTimeSlot;
    private readonly IRepository<DAL.Entities.Doctor> _repositoryDoctor;
    private readonly IRepository<Patient> _repositoryPatient;
    private readonly IMapper _mapper;

    public AppointmentService(IMapper mapper, IRepository<DAL.Entities.Appointment> repositoryAppointment)
    {
        _mapper = mapper;
        _repositoryAppointment = repositoryAppointment;
    }

    public async Task<bool> CreateAppointmentAsync(AppointmentDTO appointment)
    {
        var entity = _mapper.Map<DAL.Entities.Appointment>(appointment);
        await _repositoryAppointment.InsertAsync(entity);
        return true;
    }

    public async Task<bool> DeleteAppointmentAsync(Guid id)
    {
        var entity = await _repositoryAppointment.SingleOrDefaultAsync(x => x.Id == id);
        await _repositoryAppointment.DeleteAsync(entity);
        return true;
    }

    public async Task<DAL.Entities.Appointment> GetAppointmentByIdAsync(Guid id)
    {
        var entity = await _repositoryAppointment.SingleOrDefaultAsync(x => x.Id == id);
        return entity;
    }

    public async Task<bool> UpdateAppointmentAsync(AppointmentDTO appointment)
    {
        var entity = await _repositoryAppointment.SingleOrDefaultAsync(x => x.DoctorTimeSlotId == appointment.DoctorTimeSlotId);
        if (entity == null)
            throw new ArgumentException("Doctor not found");
        _mapper.Map<DAL.Entities.Doctor>(entity);
        await _repositoryAppointment.UpdateAsync(entity);
        return true;
    }


    public async Task<DAL.Entities.Appointment> GetAppointmentByUserId(Guid id)
    {
        var entity = await _repositoryAppointment.
            Include(x => x.DoctorTimeSlot)
            .ThenInclude(x => x.Patient)
            .SingleOrDefaultAsync(x => x.DoctorTimeSlot.PatientId == id);
        return entity;
    }
}